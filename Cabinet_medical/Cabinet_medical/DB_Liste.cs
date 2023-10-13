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
    class DB_Liste
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=cabinet_m");
        static string qToate;

        public static List<string> citire_Data_istoric()
        {
            List<string> listaToateIst = new List<string>();
            qToate = "SELECT data FROM istoric ORDER BY id_istoric";
            conn.Open();
            MySqlCommand cautToateIst = conn.CreateCommand();
            cautToateIst.CommandText = qToate;
            MySqlDataReader readerToateIst = cautToateIst.ExecuteReader();
            // Parcurgem pe rand datele din DataReader si le incarcam in lista
            while (readerToateIst.Read())
            {
                listaToateIst.Add(""+readerToateIst["data"]);
            }
            readerToateIst.Close();
            conn.Close();
            return listaToateIst;
        }

    }


}

