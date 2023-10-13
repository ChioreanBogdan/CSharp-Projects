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
    public partial class Programare : Form
    {
        int verif=0;

        public Programare()
        {
            InitializeComponent();

            Completez_Combo_Client();

            Timp_inc.Format = DateTimePickerFormat.Time; //Timp_inc stabileste inceputul consultatiei. Trebuie sa fie cuprins intre 8 am si 6 pm cand functioneaza cabinetul
            Timp_inc.ShowUpDown = true;
            Timp_inc.Format = DateTimePickerFormat.Custom;
            Timp_inc.CustomFormat = "HH:mm tt";
            Timp_inc.MinDate = Convert.ToDateTime("08:00 AM");
            Timp_inc.MaxDate = Convert.ToDateTime("18:00 PM");
            Timp_inc.Value = Convert.ToDateTime("8:00 AM");

            Timp_fin.Format = DateTimePickerFormat.Time;
            Timp_fin.ShowUpDown = true;
            Timp_fin.Format = DateTimePickerFormat.Custom;
            Timp_fin.CustomFormat = "HH:mm tt";
            Timp_fin.MinDate = Convert.ToDateTime("08:00 AM");
            Timp_fin.MaxDate = Convert.ToDateTime("18:00 PM");
            Timp_fin.Value = Convert.ToDateTime("8:15 AM");

            Timp_inc.Format = DateTimePickerFormat.Custom;
            dat.MinDate = DateTime.Now;
            dat.MaxDate = DateTime.Now.AddMonths(3);
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

        int Verific_Timp() //Verific ca consultatia introdusa sa nu se suprapuna cu alta
        {
            int overlap = 0; //devine 1 daca ce introducem se suprapune peste o alta programare

            List<string> listaTimpInc = new List<string>();
            List<string> listaTimpFin = new List<string>();
            // In listaTimpInc si listaTimpFin aducem valorile citite din baza de date folosind DataReader
            // metoda citire_Lista() din clasa DB_Timp
            try
            {
                String ds = dat.Value.ToString("yyyy-MM-dd");
                listaTimpInc.Clear();
                listaTimpFin.Clear();
                listaTimpInc = DB_Timp.Lista_timp_inc(ds);
                listaTimpFin = DB_Timp.Lista_timp_fin(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var Lista_timp_incEnum = listaTimpInc.GetEnumerator();
            var Lista_timp_finEnum = listaTimpFin.GetEnumerator();

            try
            {
                int i = -1;
                while (Lista_timp_incEnum.MoveNext())
                {
                    {
                        Lista_timp_finEnum.MoveNext();
                        i = i + 1;
                    }
                    if (Timp_inc.Value < Convert.ToDateTime(listaTimpFin[i]) && Convert.ToDateTime(listaTimpInc[i]) < Timp_fin.Value) overlap= 1;
                    // Do something with stream1Enumerator.Current and stream2Enumerator.Current
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (overlap == 1) return 1;
            else return 0;
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Adauga"
        {
            int okc;

            DateTime ti, tf; //aici memoram inceputul si sfarsitul consultatiei
            ti = Timp_inc.Value.AddMinutes(14); //un consult trebuie sa aiba minim 15 minute
            tf = Timp_fin.Value;
            verif = DateTime.Compare(tf, ti); //Compara data inceputului cu data sfarsitului si returneaza nr negativ/zero daca data de inceput e mai mare decat data de sfarsit cu cel putin 14 minute
            try
            {
                Verific_Timp(); //Verific ca ce am programat sa nu se suprapuna peste o programare anterioara
                if (verif <= 0) throw new Exception("Va rugam asigurati-va ca timpul pentru consulatie este de cel putin 15 minute!");
                if (Verific_Timp() == 1) throw new Exception("Un alt pacient e programat pe acest interval.Va rugam reprogramati!");

                okc = DB_Adaugare.Adaug_consult(dat.Value.ToString("yyyy-MM-dd"), Timp_inc.Value, Timp_fin.Value, motiv.Text, (int) pac.SelectedValue);
                    if (okc == 0)
                    {
                    string numcli = this.pac.GetItemText(this.pac.SelectedItem);
                    MessageBox.Show("" + numcli + " sunteti programat de la "+Timp_inc.Value.ToString("HH: mm tt")+"\n in data de:"+dat.Value.ToString("dd-MM"));
                    motiv.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("A aparut o eroare la adaugarea consultului");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Anuleaza"
        {
            this.Close();
        }
    }
}
