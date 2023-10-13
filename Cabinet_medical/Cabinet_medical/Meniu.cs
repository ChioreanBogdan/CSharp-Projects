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
    public partial class Meniu : Form
    {
        int login;
        string user, parola;

        public Meniu()
        {
            InitializeComponent();
            //Ascundem meniul care va deveni vizibil dupa ce operatia de log-in a avut succes
            menuStrip1.Hide();
            button1.Text = "Log in";
            login = 0;
            user = parola = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (login == 0)
                {
                    //Preluam user si parola, stergem eventualele spatii din fata si spatele numelui utilizator
                     user = usr.Text.Trim();
                    parola = pwd.Text;
                    if (user == "") throw new Exception("Completati campul User");
                    if (parola == "") throw new Exception("Completati campul Parola");
                    if (user == "1" && parola == "1") // Daca este administrator are drepturi depline
                    {
                        login = 1;
                        menuStrip1.Show();
                        button2.Hide();
                        button1.Text = "Log out";
                    }
                    if (user == "angajat" && parola == "123") //Daca este un angajat nu are dreptul sa ???
                {
                        login = 2;
                        menuStrip1.Show();
                        button2.Hide();
                        button1.Text = "Log out";
                    }
                    if (login == 0)
                        throw new Exception("User sau Parola incorecte");
                }
                else
                {
                    // A fost apasat butonul log-out. Resetam
                    usr.Text = "";
                    pwd.Text = "";
                    menuStrip1.Hide();
                    button2.Show();
                    button1.Text = "Log in";
                    login = 0;
                    user = parola = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ad_pacientToolStripMenuItem_Click(object sender, EventArgs e) //Pacienti->Adaugare
        {
            Ad_Pacient adp = new Ad_Pacient();
            adp.ShowDialog();
        }

        private void istoricToolStripMenuItem_Click(object sender, EventArgs e)//Adaugare istoric
        {
            Ad_istoric ad_ist = new Ad_istoric();
            ad_ist.ShowDialog();
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e) //Prescriptii->Adaugare
        {
            Ad_pres1 ad_pres1 = new Ad_pres1();
            ad_pres1.ShowDialog();
        }

        private void coToolStripMenuItem_Click(object sender, EventArgs e) //Prescriptii->Vizualizare
        {
            Viz_Pres viz_pres = new Viz_Pres();
            viz_pres.ShowDialog();
        }

        private void programareToolStripMenuItem1_Click(object sender, EventArgs e) //Consultatii->Programare
        {
            Programare prog = new Programare();
            prog.ShowDialog();
        }

        private void peToolStripMenuItem_Click(object sender, EventArgs e) //Afisare consultatii pe zile
        {
            Viz_Consult viz_zi = new Viz_Consult("z");
            viz_zi.ShowDialog();
        }

        private void peIntervalOrarToolStripMenuItem_Click(object sender, EventArgs e) //Afisare consultatii pe interval orar
        {
            Viz_Consult viz_zi = new Viz_Consult("i");
            viz_zi.ShowDialog();
        }

        private void incarcareCabinetToolStripMenuItem_Click(object sender, EventArgs e) //Incarcare cabinet pe zile
        {
            Inc_cabinet inc_cab = new Inc_cabinet();
            inc_cab.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //butonul "Iesire"
        {
            Application.Exit();
        }

    }
}
