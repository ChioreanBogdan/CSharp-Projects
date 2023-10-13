using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient; //Pentru MySql
using System.Windows.Forms; // Pentru MessageBox()

namespace Cabinet_medical
{
    class DB_Adaugare
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=cabinet_m");

        public static int Adaug_Pacient(string nume, string prenume, string telefon, string adresa, string email, string tip_asigurare)
        {
            //Comanda pentru a adauga date in tabelul "pacient"
            MySqlCommand Adaug_pac = new MySqlCommand("INSERT INTO pacient(nume,prenume,telefon,adresa,email,tip_asigurare) VALUES(@nume,@prenume,@telefon,@adresa,@email,@asig);", conn);

            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_pac.Parameters.AddWithValue("@nume", nume);
                Adaug_pac.Parameters.AddWithValue("@prenume", prenume);
                Adaug_pac.Parameters.AddWithValue("@telefon", telefon);
                Adaug_pac.Parameters.AddWithValue("@adresa", adresa);
                Adaug_pac.Parameters.AddWithValue("@email", email);
                Adaug_pac.Parameters.AddWithValue("@asig", tip_asigurare);
                Adaug_pac.ExecuteNonQuery();
                Adaug_pac.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Id_Ult_Pac()
        {
            int idp;
            //Returneaza ultimul id din tabelul pacienti
            MySqlCommand Caut_id = new MySqlCommand("SELECT id_pacient FROM pacient ORDER BY id_pacient DESC LIMIT 1", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                idp=(int) (Caut_id.ExecuteScalar());
                conn.Close();
                return idp; // Selectare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0; // Selectare esuata
            }
        }

        public static int Adaug_Stare(int id_pac,DateTime data_ist)
        {
            //Comanda pentru a adauga starea curenta in tabelul "istoric"
            MySqlCommand Adaug_ist = new MySqlCommand("INSERT INTO istoric(id_p,data) VALUES(@idp,@data);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_ist.Parameters.AddWithValue("@idp", id_pac);
                Adaug_ist.Parameters.AddWithValue("@data", data_ist);
                Adaug_ist.ExecuteNonQuery();
                Adaug_ist.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_radiografii(string textul,int id_pac,DateTime data)
        {
            //Comanda pentru a adauga radiografii in tabelul "istoric"
            MySqlCommand Adaug_rad = new MySqlCommand("INSERT INTO istoric(radiografii,id_p,data) VALUES(@rad,@idp,@data);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_rad.Parameters.AddWithValue("@rad", textul);
                Adaug_rad.Parameters.AddWithValue("@idp", id_pac);
                Adaug_rad.Parameters.AddWithValue("@data", data);
                Adaug_rad.ExecuteNonQuery();
                Adaug_rad.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_alergii(string textul,int id_pac,DateTime data)
        {
            //Comanda pentru a adauga alergii in tabelul "istoric"
            MySqlCommand Adaug_alg = new MySqlCommand("INSERT INTO istoric(alergii,id_p,data) VALUES(@alg,@idp,@data);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_alg.Parameters.AddWithValue("@alg", textul);
                Adaug_alg.Parameters.AddWithValue("@idp", id_pac);
                Adaug_alg.Parameters.AddWithValue("@data", data);
                Adaug_alg.ExecuteNonQuery();
                Adaug_alg.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_boli(string textul,int id_pac, DateTime data)
        {
            //Comanda pentru a adauga boli in tabelul "istoric"
            MySqlCommand Adaug_bol = new MySqlCommand("INSERT INTO istoric(boli,id_p,data) VALUES(@bol,@idp,@data);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_bol.Parameters.AddWithValue("@bol", textul);
                Adaug_bol.Parameters.AddWithValue("@idp", id_pac);
                Adaug_bol.Parameters.AddWithValue("@data", data);
                Adaug_bol.ExecuteNonQuery();
                Adaug_bol.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_concedii(string textul, int id_pac, DateTime data)
        {
            //Comanda pentru a adauga concedii in tabelul "istoric"
            MySqlCommand Adaug_con = new MySqlCommand("INSERT INTO istoric(concedii,id_p,data) VALUES(@con,@idp,@data);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_con.Parameters.AddWithValue("@con", textul);
                Adaug_con.Parameters.AddWithValue("@idp", id_pac);
                Adaug_con.Parameters.AddWithValue("@data", data);
                Adaug_con.ExecuteNonQuery();
                Adaug_con.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Id_Ult_Ist()
        {
            int idi;
            //Returneaza ultimul id din tabelul "Istoric"
            MySqlCommand Caut_id = new MySqlCommand("SELECT id_istoric FROM istoric ORDER BY id_istoric DESC LIMIT 1", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                idi = (int)(Caut_id.ExecuteScalar());
                conn.Close();
                return idi; // Selectare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0; // Selectare esuata
            }
        }

        public static int Adaug_id_ist_pres(int id_i)
        {
            //Comanda pentru a adauga ultimul id_istoric din "Istoric" in id_ist din "Prescriptie"
            MySqlCommand Adaug_ist = new MySqlCommand("INSERT INTO prescriptie(id_ist) VALUES(@idi);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_ist.Parameters.AddWithValue("@idi", id_i);
                Adaug_ist.ExecuteNonQuery();
                Adaug_ist.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_consult(string data, DateTime orai, DateTime oraf, string mot, int idp)
        {
            int id_con; //memoreaza id-ul ultimul consultatii pt a il lega de pacient
            //Comanda pentru a adauga o consultatie in tabelul "consult"
            MySqlCommand Adaug_consult = new MySqlCommand("INSERT INTO consult(data,ora_inc,ora_fin,motiv) VALUES(@data,@orai,@oraf,@mot);", conn);
            MySqlCommand Iau_id_consult = new MySqlCommand("SELECT id_consult FROM consult ORDER BY id_consult DESC LIMIT 1;", conn); //selecteaza ultimul id consult
            MySqlCommand Adaug_pacon = new MySqlCommand("INSERT INTO pacon(id_pa,id_con) VALUES(@idp,@idc);", conn);
            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_consult.Parameters.AddWithValue("@data", data);
                Adaug_consult.Parameters.AddWithValue("@orai", orai);
                Adaug_consult.Parameters.AddWithValue("@oraf", oraf);
                Adaug_consult.Parameters.AddWithValue("@mot", mot);
                Adaug_consult.ExecuteNonQuery();
                Adaug_consult.Parameters.Clear();

                id_con=(int) Iau_id_consult.ExecuteScalar();

                Adaug_pacon.Parameters.AddWithValue("@idp", idp);
                Adaug_pacon.Parameters.AddWithValue("@idc", id_con);
                Adaug_pacon.ExecuteNonQuery();
                Adaug_pacon.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_medicament(string num, string spec)
        {
            //Comanda pentru a adauga un medicament in tabelul "medicament"
            MySqlCommand Adaug_med = new MySqlCommand("INSERT INTO medicament(nume,specificatii) VALUES(@num,@spec);", conn);

            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_med.Parameters.AddWithValue("@num", num);
                Adaug_med.Parameters.AddWithValue("@spec", spec);
                Adaug_med.ExecuteNonQuery();
                Adaug_med.Parameters.Clear();

                conn.Close();
                return 0; // Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Adaugare esuata
            }
        }

        public static int Adaug_prescriptie(int idp, int idm,int idum,double cant,int zi,string data)
        {
            //Comanda pentru a adauga o prescriptue in tabelul "prescriptie"
            MySqlCommand Adaug_pres = new MySqlCommand("INSERT INTO prescriptie(id_pac,id_med,id_um,cantitate,zile,data) VALUES(@idp,@idm,@idum,@cant,@zile,@dat);", conn);

            try
            {// Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                Adaug_pres.Parameters.AddWithValue("@idp", idp);
                Adaug_pres.Parameters.AddWithValue("@idm", idm);
                Adaug_pres.Parameters.AddWithValue("@idum", idum);
                Adaug_pres.Parameters.AddWithValue("@cant", cant);
                Adaug_pres.Parameters.AddWithValue("@zile", zi);
                Adaug_pres.Parameters.AddWithValue("@dat", data);
                Adaug_pres.ExecuteNonQuery();
                Adaug_pres.Parameters.Clear();

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
