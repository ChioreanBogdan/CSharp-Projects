using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinet_medical
{
    public partial class Ad_pres1 : Form
    {
        public static int memidp; //memoreaza id-ul pacientului selectat
        public static string memdat; //memoreaza data in format yyyy-MM-dd
        public static string mempac; //memoreaza numele pacientului selectat

        public Ad_pres1()
        {
            InitializeComponent();
            Completez_Combo_Pacient();
        }

        void Completez_Combo_Pacient()
        {
            DataTable lista_pacienti = DB_Interogari.Descarc_Pacienti();
            pac.Items.Clear();
            pac.DataSource = lista_pacienti;
            // DataTable din care sunt preluate datele pentru ComboBox pacienti
            pac.ValueMember = "id_pacient";
            pac.DisplayMember = "numprenum";
            // Elementele afisate in ComboBox, preluate din coloana denumire din DataTable
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Inainte". Inserez id client si data in tabelul istoric
        {
            memidp = Convert.ToInt32(pac.SelectedValue); //id-ul clientului selectat
            memdat = dat.Value.ToString("yyyy-MM-dd"); //data selectata;
            mempac = this.pac.GetItemText(this.pac.SelectedItem);
            Ad_pres2 adp2 = new Ad_pres2();
            adp2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Renunta"
        {
            this.Close();
        }
    }
}
