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
    class DB_Interogari
    {
        static string connstr = "Data source=localhost;userID=root;database=rpg";
        static MySqlConnection conn = new MySqlConnection(connstr);

        static MySqlCommand comClas = new MySqlCommand("SELECT * FROM clasa", conn);
        static MySqlCommand comPortr = new MySqlCommand("SELECT * FROM portret", conn);
        static MySqlCommand comGrup = new MySqlCommand("SELECT * FROM grup ORDER BY cod_grup DESC LIMIT 1", conn);
        static MySqlCommand comGr = new MySqlCommand("SELECT * FROM grup", conn);
        static MySqlCommand comAbilitati = new MySqlCommand("SELECT * FROM abilitate", conn);
        static MySqlCommand com3Personaje = new MySqlCommand("SELECT * FROM personaj ORDER BY cod_pers DESC LIMIT 3", conn);
        static MySqlCommand comPersonaje = new MySqlCommand("SELECT * FROM personaj", conn);
        static MySqlCommand comInamici = new MySqlCommand("SELECT *,adr_poza AS portret FROM inamic", conn);
        static MySqlCommand comAbilitati_pers = new MySqlCommand("SELECT abilitate.cod_abilitate,abilitate.adr_poza,abilitate.nume AS nume_a,abilitate.descriere,personaj.nume AS nume_p,abilitate_personaj.nr_slot,personaj.cod_pers,personaj.numar,abilitate_afecteaza.cod_afect AS afecteaza FROM abilitate_personaj INNER JOIN abilitate ON abilitate.cod_abilitate=abilitate_personaj.cod_a INNER JOIN personaj ON personaj.cod_pers=abilitate_personaj.cod_p INNER JOIN abilitate_afecteaza ON abilitate_afecteaza.cod_afect=abilitate.cod_af INNER JOIN abilitate AS abilitate_af ON abilitate.cod_abilitate=abilitate_personaj.cod_a", conn);
        static MySqlCommand comAbilitati_inam = new MySqlCommand("SELECT abilitate.cod_abilitate,abilitate.adr_poza,abilitate.nume AS nume_a,abilitate.descriere,inamic.nume AS nume_i,abilitate_inamic.nr_slot,inamic.cod_inamic,inamic.adr_poza AS portret,inamic.viata,inamic.viata_max,inamic.eng,inamic.eng_max,abilitate_afecteaza.cod_afect AS afecteaza FROM abilitate_inamic INNER JOIN abilitate ON abilitate.cod_abilitate=abilitate_inamic.cod_a INNER JOIN inamic ON inamic.cod_inamic=abilitate_inamic.cod_i INNER JOIN abilitate_afecteaza ON abilitate_afecteaza.cod_afect=abilitate.cod_af INNER JOIN abilitate AS abilitate_af ON abilitate.cod_abilitate=abilitate_inamic.cod_a", conn);

        public static DataTable Descarc_Clasele()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comClas);
            DataTable ClaseT = new DataTable();
            adapt.Fill(ClaseT);
            conn.Close();
            return ClaseT;
        }

        public static DataTable Descarc_Portretele()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comPortr);
            DataTable PortretT = new DataTable();
            adapt.Fill(PortretT);
            conn.Close();
            return PortretT;
        }

        public static DataTable Descarc_Inamicii()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comInamici);
            DataTable InamicT = new DataTable();
            adapt.Fill(InamicT);
            conn.Close();
            return InamicT;
        }

        public static DataTable Descarc_Grupurile()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comGr);
            DataTable GrupT = new DataTable();
            adapt.Fill(GrupT);
            conn.Close();
            return GrupT;
        }

        public static DataTable Descarc_Abilitatile()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comAbilitati);
            DataTable AbilitateT = new DataTable();
            adapt.Fill(AbilitateT);
            conn.Close();
            return AbilitateT;
        }

        public static DataTable Descarc_Abilitatile_Personajelor()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comAbilitati_pers);
            DataTable AbilitatePT = new DataTable();
            adapt.Fill(AbilitatePT);
            conn.Close();
            return AbilitatePT;
        }

        public static DataTable Descarc_Abilitatile_Inamicilor() //Descarc abilitatile si portretele inamicilor
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comAbilitati_inam);
            DataTable AbilitateINM = new DataTable();
            adapt.Fill(AbilitateINM);
            conn.Close();
            return AbilitateINM;
        }

        public static int Descarc_Id_grup() //Descarc id-ul ultimului grup creat
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            var rezultat = comGrup.ExecuteScalar();
            conn.Close();
            return Convert.ToInt32(rezultat);
        }

        public static DataTable Descarc_Personaje()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(comPersonaje);
            DataTable PersonajeT = new DataTable();
            adapt.Fill(PersonajeT);
            conn.Close();
            return PersonajeT;
        }

        public static DataTable Descarc_Ultimele_3_Personaje()
        {
            conn.Open();// Deschid conexiunea cu serverul de BD
            MySqlDataAdapter adapt = new MySqlDataAdapter(com3Personaje);
            DataTable PersonajeT = new DataTable();
            adapt.Fill(PersonajeT);
            conn.Close();
            return PersonajeT;
        }

        public static string Caut_Portretul(int cod_portr) //cauta un portret dupa codul cod_portr si returneaza numele pozei portretului
        {
            Descarc_Portretele();
            int nrr_portr = Descarc_Portretele().Rows.Count;
            string nume_poza="";
            for (int i = nrr_portr - 1; i >= 0; i = i - 1)
            {
                DataRow rp = DB_Interogari.Descarc_Portretele().Rows[i];
                if (Convert.ToInt32(rp["cod_portret"]) == cod_portr) nume_poza=rp["adr_poza"].ToString();
            }
            return nume_poza;
        }

        public static string Caut_Inamicul(int cod_inm) //cauta poza unui inamic dupa codul cod_inm si returneaza numele pozei
        {
            Descarc_Inamicii();
            int nrr_inm = Descarc_Inamicii().Rows.Count;
            string nume_poza = "";
            for (int i = nrr_inm - 1; i >= 0; i = i - 1)
            {
                DataRow ri = DB_Interogari.Descarc_Inamicii().Rows[i];
                if (Convert.ToInt32(ri["cod_inamic"]) == cod_inm) nume_poza = ri["adr_poza"].ToString();
            }
            return nume_poza;
        }


    }
}
