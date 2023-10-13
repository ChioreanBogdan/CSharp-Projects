using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Pentru MySql
using System.Windows.Forms; // Pentru MessageBox()

namespace Cabinet_medical
{
    class DB_Timp
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=cabinet_m");
        static string qToate;

        public static List<string> Lista_timp_inc(string zi) //Returneaza o lista cu toate inceputurile de programare dintr-o zi
        {
            List<string> listaTimpInc = new List<string>();
            qToate = "SELECT * FROM consult WHERE data=@zi";
            conn.Open();// Deschid conexiunea cu serverul de BD

            MySqlCommand cautTimpInc = conn.CreateCommand();
            cautTimpInc.CommandText = qToate;
            cautTimpInc.Parameters.AddWithValue("@zi",zi);

            MySqlDataReader readerTimpInc = cautTimpInc.ExecuteReader();
            // Parcurgem pe rand datele din DataReader si le incarcam in lista
            while (readerTimpInc.Read())
            {
                listaTimpInc.Add(""+readerTimpInc["ora_inc"]);
            }
            readerTimpInc.Close();
            conn.Close();
            return listaTimpInc;
        }

        public static List<string> Lista_timp_fin(string zi) //Returneaza o lista cu toate finalurile de programare dintr-o zi
        {
            List<string> listaTimpFin = new List<string>();
            qToate = "SELECT * FROM consult WHERE data=@zi";
            conn.Open();// Deschid conexiunea cu serverul de BD

            MySqlCommand cautTimpFin = conn.CreateCommand();
            cautTimpFin.CommandText = qToate;
            cautTimpFin.Parameters.AddWithValue("@zi", zi);

            MySqlDataReader readerTimpFin = cautTimpFin.ExecuteReader();
            // Parcurgem pe rand datele din DataReader si le incarcam in lista
            while (readerTimpFin.Read())
            {
                listaTimpFin.Add("" + readerTimpFin["ora_fin"]);
            }
            readerTimpFin.Close();
            conn.Close();
            return listaTimpFin;
        }
    }
}
