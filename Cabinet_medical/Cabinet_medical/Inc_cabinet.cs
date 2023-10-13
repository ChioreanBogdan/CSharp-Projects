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
    public partial class Inc_cabinet : Form
    {
        int verif = 0; //verific ca Dat_inc sa fie mai mica decat Dat_fin

        public Inc_cabinet()
        {
            InitializeComponent();
            Dat_inc.Value = DateTime.Now;
            Dat_fin.Value = DateTime.Now.AddDays(1);
        }

        void Calc_Timp(string data) //Calculez orele liberele si orele rezervate consultului intr-o zi
        {
            double ore_lib = 0;
            double min_lib = 600;
            double ore_con = 0;
            double min_con = 0;
            TimeSpan dif;

            List<string> listaTimpInc = new List<string>();
            List<string> listaTimpFin = new List<string>();
            // In listaTimpInc si listaTimpFin aducem valorile citite din baza de date folosind DataReader
            // metoda citire_Lista() din clasa DB_Timp
            try
            {
                String ds = data;
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
                    dif = Convert.ToDateTime(listaTimpFin[i]) - Convert.ToDateTime(listaTimpInc[i]);
                    min_con = min_con + (int)dif.TotalMinutes;
                    // Do something with stream1Enumerator.Current and stream2Enumerator.Current
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            min_lib = min_lib - min_con;

            while(min_lib>=60)
            {
                min_lib = min_lib - 60;
                ore_lib = ore_lib + 1;
            }

            while (min_con >= 60)
            {
                min_con = min_con - 60;
                ore_con = ore_con + 1;
            }
            if(min_lib>=9 && min_con>=9) incarcare.Text = incarcare.Text + "   " + data + "                      " + ore_con + ":" + min_con + "                                   " + ore_lib + ":" + min_lib +"\n" + "\n";
       else if(min_lib<=9 && min_con>=9) incarcare.Text = incarcare.Text + "   " + data + "                      " + ore_con + ":" + min_con + "                                   " + ore_lib + ":0" + min_lib +"\n" + "\n";
       else if(min_lib>=9 && min_con<=9) incarcare.Text = incarcare.Text + "   " + data + "                      " + ore_con + ":0" + min_con +"                                  " + ore_lib + ":" + min_lib +"\n" + "\n";
       else if(min_lib<=9 && min_con<=9) incarcare.Text = incarcare.Text + "   " + data + "                      " + ore_con + ":0" + min_con +"                                  " + ore_lib + ":0" + min_lib +"\n" + "\n";
        }

        private void Parcurg_datele() //Functie folosita pentru a parcurge zilele dintre "Data inceput" si "Data final"
        {
            DateTime dat = Dat_inc.Value;
            while (dat.ToString("yyyy-MM-dd")!= Dat_fin.Value.AddDays(1).ToString("yyyy-MM-dd"))
            {
                Calc_Timp(dat.ToString("yyyy-MM-dd"));
                dat = dat.AddDays(1);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Cauta"
        {
            DateTime di, df; //aici memoram inceputul si sfarsitul datelor intre care se face raportul
            string si, sf; //aici memoram inceputul si sfarsitul intervalului in format string
            si= Dat_inc.Value.ToString("yyyy-MM-dd");
            sf = Dat_fin.Value.ToString("yyyy-MM-dd");
            di = Convert.ToDateTime(si);
            df = Convert.ToDateTime(sf);
            //Nota: Am folosit si si sf pt ca atunci cand am folosit direct di si df si nu am schimbat data verif nu returna valoarea bine

            try
            {
                verif = DateTime.Compare(df, di);
                if (verif <= 0) throw new Exception("Va rugam asigurati-va ca data de final a \n intervalului este cu cel putin o zi \n mai mare decat data de inceput!");
                incarcare.Text = "";
                Parcurg_datele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
