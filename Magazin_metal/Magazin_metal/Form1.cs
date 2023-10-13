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
    public partial class Form1 : Form
    {
        int login;
        string user, parola;
        public Form1()
        {
            InitializeComponent();
            //Ascundem meniul (care va deveni vizibil dupa ce operatia log-in a avut succes)
            menuStrip1.Hide();
            button1.Text = "Log in";
            login = 0;
            user = parola = "";
        }

        private void tablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_prod ad = new Adauga_prod("t"); //Meniul pentru adaugare tabla
            ad.ShowDialog();
        }

        private void teavaRotundaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_prod ad = new Adauga_prod("tc"); //Meniul pentru adaugare teava circulara
            ad.ShowDialog();
        }

        private void teavaRectangularaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_prod ad = new Adauga_prod("tr"); //Meniul pentru adaugare teava rectangulara
            ad.ShowDialog();
        }

        private void baraRotundaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_prod ad = new Adauga_prod("bc"); //Meniul pentru adaugare bara circulara
            ad.ShowDialog();
        }

        private void baraRectangularaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_prod ad = new Adauga_prod("br"); //Meniul pentru adaugare bara rectangulara
            ad.ShowDialog();
        }

        private void stergeProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stergere st = new Stergere(); //Fereastra pentru stergere
            st.ShowDialog();
        }

        private void adaugaComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adauga_com1 ad_com = new Adauga_com1(); //Fereastra pentru adaugare comanda
            ad_com.ShowDialog();
        }

        private void afiseazaComenziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afiseaza_com afis = new Afiseaza_com(); //Fereastra pentru afisare comanda
            afis.ShowDialog();
        }

        private void finalizeazaComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Livreaza_com liv_com = new Livreaza_com(); //Fereastra pentru livrare comanda
            liv_com.ShowDialog();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "Log out")
                {
                    button1.Text = "Log in";
                    button2.Show();
                    login = 0;
                    usr.Text = "";
                    pwd.Text = "";
                    menuStrip1.Hide();
                }
                else {
                    if (login == 0)
                    {
                        //Preluam user si parola, stergem eventualele spatii din fata si spatele numelui utilizator
                        user = usr.Text.Trim();
                        parola = pwd.Text;
                        if (user == "") throw new Exception("Completati campul User");
                        if (parola == "") throw new Exception("Completati campul Parola");

                        if (user == "admin" && parola == "1234") //daca este administrator are drepturi depline
                        {
                            login = 1;
                            produseToolStripMenuItem.Visible = true;
                            menuStrip1.Show();
                            button2.Hide();
                            button1.Text = "Log out";

                        }

                        if (user == "angajat" && parola == "123") //daca este un angajat nu are dreptul sa adauge un produs in BD
                        {
                            login = 2;
                            produseToolStripMenuItem.Visible = false;
                            menuStrip1.Show();
                            button2.Hide();
                            button1.Text = "Log out";
                        }


                        if (login == 0)
                            throw new Exception("User sau Parola incorecte");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
