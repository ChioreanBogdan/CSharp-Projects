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
    public partial class Viz_Consult : Form
    {
        int verif = 0; //verifica daca intervalul de sfarsit e cu cel putin 15 minute dupa intervalul de inceput
        string v;
        MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database = cabinet_m");
        MySqlDataAdapter adapt;
        private string qZi = "SELECT Concat(nume,' ',prenume) AS 'Nume' ,data AS 'Ziua',ora_inc AS 'Inceput consult',ora_fin AS 'Sfarsit consult' FROM pacient,pacon,consult WHERE id_pacient=id_pa AND id_consult=id_con AND data=@zi ORDER BY ora_inc ASC";
        //selecteaza toate consultatiile dintr-o zi
        private string qInt = "SELECT Concat(nume,' ',prenume) AS 'Nume' ,data AS 'Ziua',ora_inc AS 'Inceput consult',ora_fin AS 'Sfarsit consult' FROM pacient,pacon,consult WHERE id_pacient=id_pa AND id_consult=id_con AND data=@zi AND ora_inc>=@inc AND ora_fin<=@fin ORDER BY ora_inc ASC";
        //selecteaza consultatiile dintr-o zi intr-un interval orar dat

        DataTable informatii = new DataTable();

        public Viz_Consult(string tip_vizuaizare)
        {
            v = tip_vizuaizare;
            InitializeComponent();

            if (v=="i") umplere_Lista_Int();

            Interval_inc.Format = DateTimePickerFormat.Time; //Interval_inc stabileste inceputul consultatiei. Trebuie sa fie cuprins intre 8 am si 5 pm cand functioneaza cabinetul
            Interval_inc.ShowUpDown = true;
            Interval_inc.Format = DateTimePickerFormat.Custom;
            Interval_inc.CustomFormat = "HH:mm tt";
            Interval_inc.MinDate = Convert.ToDateTime("08:00 AM");
            Interval_inc.MaxDate = Convert.ToDateTime("18:00 PM");
            Interval_inc.Value = Convert.ToDateTime("8:00 AM");

            Interval_fin.Format = DateTimePickerFormat.Time;
            Interval_fin.ShowUpDown = true;
            Interval_fin.Format = DateTimePickerFormat.Custom;
            Interval_fin.CustomFormat = "HH:mm tt";
            Interval_fin.MinDate = Convert.ToDateTime("08:00 AM");
            Interval_fin.MaxDate = Convert.ToDateTime("18:00 PM");
            Interval_fin.Value = Convert.ToDateTime("8:15 AM");

            if (v=="z")//Daca se alege sortarea pe zile
            {
                mesaj2.Hide();
                mesaj3.Hide();
                Interval_inc.Hide();
                Interval_fin.Hide();
            }
        }

        void umplere_Lista_Int()
        {
            try
            {
                conn.Open();

                adapt = new MySqlDataAdapter(qInt, conn);
                string zi = dat.Value.ToString("yyyy-MM-dd");
                adapt.SelectCommand.Parameters.AddWithValue("@zi", zi);
                adapt.SelectCommand.Parameters.AddWithValue("@inc", Interval_inc.Value);
                adapt.SelectCommand.Parameters.AddWithValue("@fin", Interval_fin.Value);

                informatii.Clear();
                adapt.Fill(informatii);
                consult_grid.DataSource = informatii;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void umplere_Lista_Zi()
        {
            try
            {
                conn.Open();

                adapt = new MySqlDataAdapter(qZi, conn);
                string zi = dat.Value.ToString("yyyy-MM-dd");
                adapt.SelectCommand.Parameters.AddWithValue("@zi", zi);

                informatii.Clear();
                adapt.Fill(informatii);
                consult_grid.DataSource = informatii;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Cauta"
        {
            DateTime int_i, int_f; //aici memoram inceputul si sfarsitul consultatiei
            int_i = Interval_inc.Value.AddMinutes(14); //un consult trebuie sa aiba minim 15 minute
            int_f = Interval_fin.Value;
            verif = DateTime.Compare(int_f, int_i); //Compara data inceputului cu data sfarsituluisi returneaza eroare daca data de inceput e mai mare decat data de sfarsit cu cel putin 14 minute
            try
            {
                if (verif <= 0) throw new Exception("Va rugam asigurati-va ca sfarsitul intervalului este cu cel putin 15 minute dupa inceput!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (v=="i") umplere_Lista_Int();
            if (v=="z") umplere_Lista_Zi();
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Inapoi"
        {
            this.Close();
        }
    }
}
