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

namespace Cabinet_medical
{
    public partial class Ad_Pacient : Form
    {
        public Ad_Pacient()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) //Butonul pt adaugare pacient nou
        {
            int okp;

            try
            {
                if (num.Text.Length > 0) // Tratarea exceptiei pentru situatia in care nu a fost completat campul pentru "Nume"
                {
                    if (prenum.Text.Length > 0) // Tratarea exceptiei pentru situatia in care nu a fost completat campul pentru "Prenume"
                    {

                        okp = DB_Adaugare.Adaug_Pacient(num.Text, prenum.Text, tel.Text, adr.Text, mail.Text, asig.Text);
                        if (okp == 0)
                        {
                            MessageBox.Show("Pacientul " + num.Text + " " + prenum.Text + " a fost adaugat");
                            num.Text = "";
                            prenum.Text = "";
                            tel.Text = "";
                            adr.Text = "";
                            mail.Text = "";
                            asig.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("A aparut o eroare la adaugarea pacientului");
                        }
                    }
                    else throw new Exception("Completati campul Prenume");
                }
                else throw new Exception("Completati campul Nume");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) //Butonul pt renuntare/iesire
        {
            this.Close();
        }
    }
}
