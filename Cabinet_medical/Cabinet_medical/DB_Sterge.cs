using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Pentru MySql
using System.Windows.Forms; // Pentru MessageBox()

namespace Cabinet_medical
{
    class DB_Sterge
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=cabinet_m");

        public static void Sterg_Ultimul_Istoric()
        {
            //Sterg ultimul rand din "Istoric" daca se apasa butonul "Renunta" din fereastra Ad_pres2 si apoi se confirma renuntarea
            MySqlCommand Sterg_ist = new MySqlCommand("DELETE FROM istoric ORDER BY id_istoric DESC LIMIT 1;", conn);
        }

        public static int Sterg_Prescriptia(int id_pac,string data)
        {
            //Sterg prescriptia in functie de id_pacient si data introde in formularul "Ad_pres1"
            MySqlCommand Sterg_pres = new MySqlCommand("DELETE FROM prescriptie WHERE id_pac=@idp AND data=@data;", conn);

            try
            {
                conn.Open();
              
                Sterg_pres.Parameters.AddWithValue("@idp", id_pac);
                Sterg_pres.Parameters.AddWithValue("@data", data);
                Sterg_pres.ExecuteNonQuery();
                Sterg_pres.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }
    }
}
