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
    public partial class Afiseaza_com : Form
    {
        MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database = metalmag");
        MySqlDataAdapter adapt;
        private string selectare = "SELECT denumire AS 'Nume comanda',numepre AS 'Client',nume AS 'Produs',cantitate AS 'Cantitate' FROM comenzi,clienti,produse,detalii_comanda WHERE cod_cli=cod_client AND id_produs=id_p AND cod_comanda=cod_com";
        DataTable informatii = new DataTable();
        public Afiseaza_com()
        {
            InitializeComponent();
            
            umplere_Lista();
        }

        void umplere_Lista()
        {
            List<string> listaCom = new List<string>();
            try
            {
                conn.Open();
                adapt = new MySqlDataAdapter(selectare, conn);
               
                adapt.Fill(informatii);
                grid1.DataSource = informatii;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }
    }
}
