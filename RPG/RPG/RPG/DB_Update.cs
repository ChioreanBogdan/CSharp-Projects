using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace RPG
{
    class DB_Update
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database=rpg");

        public static int Update_Lupta(int cp,int vc,int ec,int xp) //cp-codul personajului vc-viata curenta ec-energie curenta xp-experienta
        {
            MySqlCommand updt_lupt = new MySqlCommand("UPDATE personaj SET viata=@viata, eng=@eng, exp=@exp WHERE cod_pers=@cod_pers; ", conn); //comanda pentru a updata viata,energia si experienta unui personaj dupa o lupta

            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                updt_lupt.Parameters.AddWithValue("@cod_pers", cp);
                updt_lupt.Parameters.AddWithValue("@viata", vc);
                updt_lupt.Parameters.AddWithValue("@eng", ec);
                updt_lupt.Parameters.AddWithValue("@exp", 0+xp); //Sistemul de experienta nu e inca activ!

                updt_lupt.ExecuteNonQuery(); //scad viata si energia pierdute in lupta castigata
                conn.Close();
                return 0; //Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; //Adaugare esuata
            }
        }
    }
}
