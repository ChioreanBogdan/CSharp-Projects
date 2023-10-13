using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Pentru MySql
using System.Windows.Forms; // Pentru MessageBox()

namespace Cabinet_medical
{
    public partial class Ad_med : Form
    {
        public Ad_med()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Adauga"
        {
            int okm;

            try
            {
                if (num.Text == "") throw new Exception("Completati numele medicamentului!");
                okm = DB_Adaugare.Adaug_medicament(num.Text,spec.Text);
                if (okm==0)
                {
                    MessageBox.Show("Medicamentul " + num.Text + " a fost adaugat");
                    num.Text = "";
                    spec.Text = "";
                }
                else
                {
                    MessageBox.Show("A aparut o eroare la adaugarea medicamentului");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Inapoi"
        {
            this.Close();
        }
    }
}
