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
    public partial class Stergere : Form
    {
        DataTable categorieT = new DataTable();
        DataTable materialT = new DataTable();
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database = metalmag");

        public Stergere()
        {
            conn.Open(); //Deschid conexiunea cu serverul de BD
            InitializeComponent();
            Completez_Combo_Client();
            Completez_Combo_Material();
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

        private void button3_Click(object sender, EventArgs e) //butonul "Cauta produse"
        {
            prod.DataSource = null; //Sterge DataTable
            try
            {
                prod.Items.Clear();

                        int id_material; //memoreaza id-ul materialului selectat
                        int id_categ; //memoreaza id-ul categoriei selectate

                        bool resultm = int.TryParse(mat.SelectedValue.ToString(), out id_material);
                        bool resultc = int.TryParse(cat.SelectedValue.ToString(), out id_categ);

                        MySqlCommand comProd = new MySqlCommand("SELECT * FROM produse WHERE id_mat=" + id_material+" AND id_cat="+id_categ, conn);
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

        private void button1_Click(object sender, EventArgs e) //Butonul "Sterge"
        {
            MySqlCommand cmd = new MySqlCommand("Delete FROM produse WHERE id_produs=@idprodus", conn);

            try
            {
                if (prod.Items.Count > 0)
                {
                    int idprod; //memoreaza id-ul produsului selectat
                    bool resultm = int.TryParse(prod.SelectedValue.ToString(), out idprod);
                    string numprod = this.prod.GetItemText(this.prod.SelectedItem);
                    int verif = 0; //verifica daca produsul face parte dintr-o comanda. 0-nu e in nicio comanda.1 face parte dintr-o comanda

                    DataTable ProdComT = new DataTable();
                    ProdComT = DB_Interogari.Descarc_ProdCom();

                    foreach (DataRow row in ProdComT.Rows)
                    {
                        string id = row["id_p"].ToString();
                        if (idprod.ToString() == id) verif = 1;
                    }

                    Confirmare c = new Confirmare("Confirmati stergerea produsului:" + numprod + " ?");
                    DialogResult dr = c.ShowDialog();

                    if (dr == DialogResult.Yes)
                        if (verif == 1) throw new Exception("Produsul " + numprod + " nu poate fi sters \n deoarece apare in una sau mai multe comenzi!");
                 else if (verif==0)   {
                            cmd.Parameters.AddWithValue("@idprodus", prod.SelectedValue);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                MessageBox.Show("Produsul " + numprod + " a fost sters");
                                prod.ResetText();
                                prod.SelectedIndex = -1;
                                        }

                    if (dr == DialogResult.No)
                    {
                        MessageBox.Show("Stergerea a fost anulata!");
                    }
                } else throw new Exception("Nu e selectat niciun produs!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Renunta"
        {
            conn.Close();
            this.Close();
        }
    }
}
