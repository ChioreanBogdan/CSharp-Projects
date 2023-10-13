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
    public partial class Ad_istoric : Form
    {
        public static int memidp; //memoreaza id-ul pacientului selectat
        public static DateTime memdat; //memoreaza data
        public Ad_istoric()
        {
            InitializeComponent();
            Completez_Combo_Pacient();
            initialID();

            data_ist.Value = DateTime.Now;
            memdat = DateTime.Now.Date; //data initiala a consultatiei e data de azi
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

        private void initialID(){ //functie pentru memorarea valorii initiale a pacientului din ComboBox
            memidp=Convert.ToInt32(pac.SelectedValue.ToString());
                                }

        private void cli_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dv = (DataRowView)pac.SelectedItem;
            memidp = (int)dv.Row["id_pacient"];
        }

        private void data_ist_ValueChanged(object sender, EventArgs e)
        {
            memdat = data_ist.Value.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ad_cont rad = new Ad_cont("r");
            rad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ad_cont alg = new Ad_cont("a");
            alg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ad_cont bol = new Ad_cont("b");
            bol.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ad_cont con = new Ad_cont("c");
            con.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
