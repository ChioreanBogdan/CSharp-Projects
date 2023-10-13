using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Magazin_metal
{
    public partial class Adauga_com2 : Form
    {
        int mem; //Variabila folosita pentru a verifica daca a fost introdus cel putin un produs in comanda
        DataTable categorieT = new DataTable();
        DataTable materialT = new DataTable();
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database = metalmag");
        public Adauga_com2()
        {
            conn.Open(); //Deschid conexiunea cu serverul de BD
            InitializeComponent();
            Completez_Combo_Client();
            Completez_Combo_Material();
            Verifica_buton(); //Ascunde butonul "Finalizeaza comanda" pana cand un produs este adaugat in comanda
        }

        void Completez_Combo_Client()
        {
            categorieT = DB_Interogari.Descarc_Categorii();
            cat.Items.Clear();
            cat.DataSource = categorieT;
            cat.ValueMember = "id_categ";
            cat.DisplayMember = "nume";
        }

        void Completez_Combo_Material()
        {
            materialT = DB_Interogari.Descarc_Materiale();
            mat.Items.Clear();
            mat.DataSource = materialT;
            mat.ValueMember = "id_material";
            mat.DisplayMember = "nume";
        }

        void Adaug_Prodcom() //Functie pentru adaugarea unui produs in comanda
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO detalii_comanda(cantitate, cod_com, id_p) VALUES(@cant, @codcom, @idp); ", conn);
            MySqlCommand comid = new MySqlCommand("SELECT cod_comanda FROM comenzi ORDER BY cod_comanda DESC LIMIT 1", conn); //Selecteaza id-ul ultimei comenzi

            try // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
            {
                mem = 0;
                string x; //memoreaza id-ul ultimei comenzi introduse ca sa stim ce punem in campul cod_com din detaliu comanda si sa stergem comanda daca se apasa pe "Anuleaza comanda"
                x = comid.ExecuteScalar().ToString();
                if (cat.Items.Count > 0 && mat.Items.Count > 0 && cant.Text.Length > 0)
                {
                    cmd.Parameters.AddWithValue("codcom", x);
                    cmd.Parameters.AddWithValue("@idp", prod.SelectedValue);
                    cmd.Parameters.AddWithValue("@cant", cant.Text);
                    cmd.ExecuteNonQuery();
                    comid.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile");
                MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                mem = 1;
                prod.SelectedIndex = -1;
                prod.ResetText();
                cant.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Cauta produse"
        {
            prod.DataSource = null; //Sterge DataTable
            try
            {
                prod.Items.Clear();

                int id_material; //memoreaza id-ul materialului selectat
                int id_categ; //memoreaza id-ul categoriei selectate

                bool resultm = int.TryParse(mat.SelectedValue.ToString(), out id_material);
                bool resultc = int.TryParse(cat.SelectedValue.ToString(), out id_categ);

                MySqlCommand comProd = new MySqlCommand("SELECT * FROM produse WHERE id_mat=" + id_material + " AND id_cat=" + id_categ, conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter(comProd);

                DataTable lista_produse = new DataTable();
                adapt.Fill(lista_produse);

                prod.DataSource = null;
                prod.Items.Clear();
                prod.DataSource = lista_produse;
                prod.ValueMember = "id_produs";
                prod.DisplayMember = "nume";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Adauga produse"
        {
            Adaug_Prodcom();
            Verifica_buton();
        }

        void Verifica_buton() //Verifica butonul "Finalizeaza comanda"
        {
            if (mem == 0) button3.Visible = false;
            if (mem == 1) button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e) //Butonul "Finalizeaza comanda"
        {
            MySqlCommand comnum = new MySqlCommand("SELECT denumire FROM comenzi ORDER BY cod_comanda DESC LIMIT 1", conn); //Selecteaza numele ultimei comenzi
            string x; //memoreaza numele ultimei comenzi introduse
            x = comnum.ExecuteScalar().ToString();

            try
            {
                Confirmare c = new Confirmare("Confirmati finalizarea comenzii:"+ x +" ?");
                DialogResult dr = c.ShowDialog();

                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Comanda " + x + " a fost adaugata");

                    button1.Text = "Inchide";
                    this.Close();
                    conn.Close();
                }

                if (dr == DialogResult.No)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //Butonul "Anuleaza comanda" inchide form-ul si sterge toate randurile cu id-urile comenzii anulate
        {
            MySqlCommand comid = new MySqlCommand("SELECT cod_comanda FROM comenzi ORDER BY cod_comanda DESC LIMIT 1", conn); //Selecteaza id-ul ultimei comenzi
            MySqlCommand comnum = new MySqlCommand("SELECT denumire FROM comenzi ORDER BY cod_comanda DESC LIMIT 1", conn); //Selecteaza numele ultimei comenzi
            MySqlCommand delcom = new MySqlCommand("Delete from comenzi where cod_comanda=@idcomanda", conn); //Sterge ultima comanda introdusa
            MySqlCommand delprod = new MySqlCommand("Delete from detalii_comanda where cod_com=@idcomanda", conn); //Sterge toate produsele introduse in ultima comanda

            string x,y; //x=memoreaza id-ul ultimei comenzi introduse y=memoreaza numele ultimei comenzi introduse
            x = comid.ExecuteScalar().ToString();
            y = comnum.ExecuteScalar().ToString();

            try
            {
                Confirmare c = new Confirmare("Confirmati anularea comenzii:" + y + " ?");
                DialogResult dr = c.ShowDialog();

                if (dr == DialogResult.Yes)
                {
                    delcom.Parameters.AddWithValue("@idcomanda", x);
                    delprod.Parameters.AddWithValue("@idcomanda", x);
                    delprod.ExecuteNonQuery();
                    delcom.ExecuteNonQuery();
                    delprod.Parameters.Clear();
                    delcom.Parameters.Clear();
                    MessageBox.Show("Comanda " + y + " a fost anulata");
                    this.Close();
                    conn.Close();
                }

                if (dr == DialogResult.No)
                {
                    MessageBox.Show("Comanda nu a fost anulata!");
                    //prod.ClearSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
