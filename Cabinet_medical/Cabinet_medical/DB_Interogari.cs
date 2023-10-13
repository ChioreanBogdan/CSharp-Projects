using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Pentru MySql
using System.Windows.Forms; // Pentru MessageBox()
using System.Data; // Pentru DataTable

namespace Cabinet_medical
{
    class DB_Interogari
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=cabinet_m");
        static MySqlCommand comPacient = new MySqlCommand("SELECT *, Concat(nume,' ',prenume) AS numprenum FROM pacient ORDER BY nume",conn);
        static MySqlCommand comUM = new MySqlCommand("SELECT * FROM unitati_masura ORDER BY nume", conn);
        static MySqlCommand comMed = new MySqlCommand("SELECT * FROM medicament ORDER BY nume", conn);

        public static DataTable Descarc_Pacienti()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comPacient);
            DataTable pacientT = new DataTable();
            adapt.Fill(pacientT);
            conn.Close();
            return pacientT;
        }

        public static DataTable Descarc_UM()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comUM);
            DataTable UMT = new DataTable();
            adapt.Fill(UMT);
            conn.Close();
            return UMT;
        }

        public static DataTable Descarc_Med()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comMed);
            DataTable MedT = new DataTable();
            adapt.Fill(MedT);
            conn.Close();
            return MedT;
        }
    }
}
