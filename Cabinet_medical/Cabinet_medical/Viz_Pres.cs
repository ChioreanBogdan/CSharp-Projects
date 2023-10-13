using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Pentru a folosi MessageBox.Show()
using MySql.Data.MySqlClient; //Pentru coneiunea la BD

namespace Cabinet_medical
{
    public partial class Viz_Pres : Form
    {
        MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database = cabinet_m");
        MySqlDataAdapter adapt;
        private string qPac = "SELECT Concat(pacient.nume,' ',prenume) AS 'Nume' ,medicament.nume AS 'Medicament',unitati_masura.nume AS 'Unitate \n Masura',cantitate AS 'cantitate',prescriptie.data AS 'Data emisie',zile AS 'Durata tratament \n (zile)' FROM pacient,medicament,unitati_masura,prescriptie WHERE id_pacient=id_pac AND id_medicament=id_med AND unitati_masura.id_um=prescriptie.id_um AND id_pac=@pac ORDER BY prescriptie.data ASC";
        //selecteaza toate prescriptiile pacientului cu id-ul @pac

        DataTable informatii = new DataTable();

        public Viz_Pres()
        {
            InitializeComponent();
            Completez_Combo_Client();
            umplere_GridPres();
        }

        void Completez_Combo_Client()
        {
            DataTable lista_pacienti = DB_Interogari.Descarc_Pacienti();
            pac.Items.Clear();
            pac.DataSource = lista_pacienti;
            // DataTable din care sunt preluate datele pentru ComboBox pacienti
            pac.ValueMember = "id_pacient";
            pac.DisplayMember = "numprenum";
            // Elementele afisate in ComboBox, preluate din coloana denumire din DataTable
        }

        void umplere_GridPres() //Umplu lista gridview
        {
            try
            {
                conn.Open();

                adapt = new MySqlDataAdapter(qPac, conn);
                int idp = Convert.ToInt32(pac.SelectedValue);
                adapt.SelectCommand.Parameters.AddWithValue("@pac", idp);

                informatii.Clear();
                adapt.Fill(informatii);
                pres_grid.DataSource = informatii;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Cauta"
        {
            umplere_GridPres();
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Renunta"
        {
            this.Close();
        }
    }
}
