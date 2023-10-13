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
    public partial class Ad_cont : Form
    {
        string t;

        public Ad_cont(string tip_adaugare)
        {
            t = tip_adaugare;
            InitializeComponent();

            if (t=="r")
            {
                titlu.Text = "Radiografii";
            }

            if (t == "a")
            {
                titlu.Text = "Alergii";
            }

            if (t == "b")
            {
                titlu.Text = "Boli";
            }

            if (t == "c")
            {
                titlu.Text = "Concedii";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int oka, okb, okc, okr;

            try
            {
                if (continut.Text.Length > 0) // Tratarea exceptiei pentru situatia in care nu a fost completat campul continut
                {
                    if (t == "r")
                    {
                        okr = DB_Adaugare.Adaug_radiografii(continut.Text, Ad_istoric.memidp,Ad_istoric.memdat);
                        if (okr == 0)
                        {
                            MessageBox.Show("Datele au fost adaugate");
                        }
                        else
                        {
                            MessageBox.Show("A aparut o eroare la adaugarea datelor");
                        }
                    }

                    if (t == "a")
                    {
                        oka = DB_Adaugare.Adaug_alergii(continut.Text, Ad_istoric.memidp, Ad_istoric.memdat);
                        if (oka == 0)
                        {
                            MessageBox.Show("Datele au fost adaugate");
                        }
                        else
                        {
                            MessageBox.Show("A aparut o eroare la adaugarea datelor");
                        }
                    }

                    if (t == "b")
                    {
                        okb = DB_Adaugare.Adaug_boli(continut.Text, Ad_istoric.memidp, Ad_istoric.memdat);
                        if (okb == 0)
                        {
                            MessageBox.Show("Datele au fost adaugate");
                        }
                        else
                        {
                            MessageBox.Show("A aparut o eroare la adaugarea datelor");
                        }
                    }

                    if (t == "c")
                    {
                        okc = DB_Adaugare.Adaug_concedii(continut.Text, Ad_istoric.memidp, Ad_istoric.memdat);
                        if (okc == 0)
                        {
                            MessageBox.Show("Datele au fost adaugate");
                        }
                        else
                        {
                            MessageBox.Show("A aparut o eroare la adaugarea datelor");
                        }
                    }

                } else throw new Exception("Nu ati completat datele pacientului!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
