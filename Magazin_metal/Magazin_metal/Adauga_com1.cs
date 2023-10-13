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
    public partial class Adauga_com1 : Form
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=metalmag");

        public Adauga_com1()
        {
            conn.Open(); //Deschid conexiunea cu serverul de BD
            InitializeComponent();
            Completez_Combo_Clienti();
        }

        void Completez_Combo_Clienti()
        {
            MySqlCommand comClienti = new MySqlCommand("SELECT * FROM clienti", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comClienti);
            DataTable lista_clienti = new DataTable();
            adapt.Fill(lista_clienti);
            cli.Items.Clear();
            cli.DataSource = lista_clienti;
            // DataTable din care sunt preluate datele pentru ComboBox clienti
            cli.ValueMember = "cod_client";
            cli.DisplayMember = "numepre";
            // Elementele afisate in ComboBox, preluate din coloana numepre din DataTable
            data_liv.MinDate = DateTime.Now.AddDays(5); //Minim 5 zile calendaristice pentru livrare de la inregistrarea comenzii!
        }

        void Adaug_Comanda()
        {
            DateTime azi = DateTime.Now.Date;
            MySqlCommand cmd = new MySqlCommand("INSERT INTO comenzi(denumire,cod_cli,data_int,data_livr) VALUES(@nume_com, @id_client, cast(@data_intrare as datetime), cast(@data_livrare as datetime)); ", conn);

            try
            {
                if (com.Text.Length > 0 && cli.Items.Count > 0)
                {
                    cmd.Parameters.AddWithValue("@nume_com", com.Text);
                    cmd.Parameters.AddWithValue("@id_client", cli.SelectedValue);
                    cmd.Parameters.AddWithValue("@data_intrare", azi);
                    cmd.Parameters.AddWithValue("@data_livrare", data_liv.Value);
                    cmd.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adaug_Comanda();
            Adauga_com2 ad = new Adauga_com2(); //Meniul pentru partea a doua din adaugare comanda
            ad.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Close();
            this.Close();
        }
    }
}
