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
    class DB_Inserari
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID = root; database=rpg");

        public static int Adaug_Grup()
        {
            MySqlCommand ins_grup = new MySqlCommand("INSERT INTO grup(aur) VALUES(@aur); ", conn); //comanda pentru a insera codul grupului si aurul

            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                ins_grup.Parameters.AddWithValue("@aur", 500);
                ins_grup.ExecuteNonQuery();
                conn.Close();
                return 0; //Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; //Adaugare esuata
            }
        }

        public static int Adaug_Personaj(string num, int nr, int cls, int grup, int p)
        {
            MySqlCommand ins_personaj = new MySqlCommand("INSERT INTO personaj(nume,numar,cod_cl,cod_gr,cod_port) VALUES(@nume,@numar,@clasa,@grup,@portret); ", conn); //comanda pt a insera datele din form-ul "Creare_personaje" pt cele 3 personaje
            MySqlCommand ins_parametri = new MySqlCommand("UPDATE personaj SET viata=@viata, viata_max=@viata_max, eng=@eng, eng_max=@eng_max, nivel=@niv, exp=@exp, exp_urm=@exp_urm WHERE cod_cl=@cod_cl AND cod_gr=@cod_gr; ", conn); //comanda pentru a insera viata,energia,nivelul si experienta in functie de clasa aleasa

            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                conn.Open();
                ins_personaj.Parameters.AddWithValue("@nume", num);
                ins_personaj.Parameters.AddWithValue("@numar", nr);
                ins_personaj.Parameters.AddWithValue("@clasa", cls);
                ins_personaj.Parameters.AddWithValue("@grup", grup);
                ins_personaj.Parameters.AddWithValue("@portret", p);

                if (cls == 1) //parametrii pentru clasa "războinic"
                {
                    ins_parametri.Parameters.AddWithValue("@viata", 120);
                    ins_parametri.Parameters.AddWithValue("@viata_max", 120);
                    ins_parametri.Parameters.AddWithValue("@eng_max", 50);
                    ins_parametri.Parameters.AddWithValue("@eng", 50);
                    ins_parametri.Parameters.AddWithValue("@niv", 1);
                    ins_parametri.Parameters.AddWithValue("@exp", 0);
                    ins_parametri.Parameters.AddWithValue("@exp_urm", 50);
                    ins_parametri.Parameters.AddWithValue("@cod_gr", grup);
                    ins_parametri.Parameters.AddWithValue("@cod_cl", cls);
                }

                else if (cls == 2) //parametrii pentru clasa "arcaș"
                {
                    ins_parametri.Parameters.AddWithValue("@viata", 90);
                    ins_parametri.Parameters.AddWithValue("@viata_max", 90);
                    ins_parametri.Parameters.AddWithValue("@eng_max", 75);
                    ins_parametri.Parameters.AddWithValue("@eng", 75);
                    ins_parametri.Parameters.AddWithValue("@niv", 1);
                    ins_parametri.Parameters.AddWithValue("@exp", 0);
                    ins_parametri.Parameters.AddWithValue("@exp_urm", 50);
                    ins_parametri.Parameters.AddWithValue("@cod_gr", grup);
                    ins_parametri.Parameters.AddWithValue("@cod_cl", cls);
                }

                else if (cls == 3) //parametrii pentru clasa "tămăduitor"
                {
                    ins_parametri.Parameters.AddWithValue("@viata", 70);
                    ins_parametri.Parameters.AddWithValue("@viata_max", 70);
                    ins_parametri.Parameters.AddWithValue("@eng_max", 100);
                    ins_parametri.Parameters.AddWithValue("@eng", 100);
                    ins_parametri.Parameters.AddWithValue("@niv", 1);
                    ins_parametri.Parameters.AddWithValue("@exp", 0);
                    ins_parametri.Parameters.AddWithValue("@exp_urm", 50);
                    ins_parametri.Parameters.AddWithValue("@cod_gr", grup);
                    ins_parametri.Parameters.AddWithValue("@cod_cl", cls);
                }

                else if (cls == 4) //parametrii pentru clasa "vrăjitor"
                {
                    ins_parametri.Parameters.AddWithValue("@viata", 70);
                    ins_parametri.Parameters.AddWithValue("@viata_max", 70);
                    ins_parametri.Parameters.AddWithValue("@eng_max", 100);
                    ins_parametri.Parameters.AddWithValue("@eng", 100);
                    ins_parametri.Parameters.AddWithValue("@niv", 1);
                    ins_parametri.Parameters.AddWithValue("@exp", 0);
                    ins_parametri.Parameters.AddWithValue("@exp_urm", 50);
                    ins_parametri.Parameters.AddWithValue("@cod_gr", grup);
                    ins_parametri.Parameters.AddWithValue("@cod_cl", cls);
                }

                ins_personaj.ExecuteNonQuery();
                ins_parametri.ExecuteNonQuery();
                conn.Close();   
                return 0; //Adaugare cu succes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; //Adaugare esuata
            }
        }

        public static int Adaug_Abilitatile_Personajului()
        {
           int[] id_pers=new int[] { 0, 0, 0 }; //aici vom memora id-urile personajelor din ultimul grup introdus
           int[] id_cls = new int[] { 0, 0, 0 }; //aici vom memora clasele personajelor din ultimul grup introdus

            MySqlCommand ins_abilitati = new MySqlCommand("INSERT INTO abilitate_personaj(cod_a,cod_p,nr_slot) VALUES(@cod_a,@cod_p,@nr_slot)", conn);
            MySqlCommand ins_abilitate1 = new MySqlCommand("INSERT INTO abilitate_personaj(cod_a,cod_p,nr_slot) VALUES(@cod_a1,@cod_p,@nr_slot1)", conn);
            MySqlCommand ins_abilitate2 = new MySqlCommand("INSERT INTO abilitate_personaj(cod_a,cod_p,nr_slot) VALUES(@cod_a2,@cod_p,@nr_slot2)", conn);
            MySqlCommand ins_abilitate3 = new MySqlCommand("INSERT INTO abilitate_personaj(cod_a,cod_p,nr_slot) VALUES(@cod_a3,@cod_p,@nr_slot3)", conn);
            MySqlCommand ins_abilitate4 = new MySqlCommand("INSERT INTO abilitate_personaj(cod_a,cod_p,nr_slot) VALUES(@cod_a4,@cod_p,@nr_slot4)", conn);

            try
            {
                int nrr_ab = DB_Interogari.Descarc_Abilitatile().Rows.Count; //memoreaza numarul de randuri din tabela "abilitate" din BD

                conn.Open();

                for (int i = 0; i <= 2; i = i + 1)
                {
                    DataRow rp3 = DB_Interogari.Descarc_Ultimele_3_Personaje().Rows[i]; //parcurgem id-urile ultimelor 3 personaje introduse
                    id_pers[i] = Convert.ToInt32(rp3["cod_pers"]);
                    id_cls[i] = Convert.ToInt32(rp3["cod_cl"]);
                    ins_abilitati.Parameters.Clear();
                    ins_abilitate1.Parameters.Clear(); ins_abilitate2.Parameters.Clear(); ins_abilitate3.Parameters.Clear(); ins_abilitate4.Parameters.Clear();
                    ins_abilitate1.Parameters.AddWithValue("@cod_p", id_pers[i]);
                    ins_abilitate2.Parameters.AddWithValue("@cod_p", id_pers[i]);
                    ins_abilitate3.Parameters.AddWithValue("@cod_p", id_pers[i]);
                    ins_abilitate4.Parameters.AddWithValue("@cod_p", id_pers[i]);

                    if (id_cls[i] == 1) //abilitatile pentru clasa "războinic"
                    {
                        ins_abilitate1.Parameters.AddWithValue("@cod_a1", 1);
                        ins_abilitate1.Parameters.AddWithValue("@nr_slot1", 1);

                        ins_abilitate2.Parameters.AddWithValue("@cod_a2", 9);
                        ins_abilitate2.Parameters.AddWithValue("@nr_slot2", 2);

                        ins_abilitate3.Parameters.AddWithValue("@cod_a3", 10);
                        ins_abilitate3.Parameters.AddWithValue("@nr_slot3", 3);

                        ins_abilitate4.Parameters.AddWithValue("@cod_a4", 11);
                        ins_abilitate4.Parameters.AddWithValue("@nr_slot4", 4);

                        ins_abilitate1.ExecuteNonQuery();
                        ins_abilitate2.ExecuteNonQuery();
                        ins_abilitate3.ExecuteNonQuery();
                        ins_abilitate4.ExecuteNonQuery();
                    }
                    else if (id_cls[i] == 2) //abilitatile pentru clasa "arcaș"
                    {
                        ins_abilitate1.Parameters.AddWithValue("@cod_a1", 2);
                        ins_abilitate1.Parameters.AddWithValue("@nr_slot1", 1);

                        ins_abilitate2.Parameters.AddWithValue("@cod_a2", 12);
                        ins_abilitate2.Parameters.AddWithValue("@nr_slot2", 2);

                        ins_abilitate3.Parameters.AddWithValue("@cod_a3", 13);
                        ins_abilitate3.Parameters.AddWithValue("@nr_slot3", 3);

                        ins_abilitate4.Parameters.AddWithValue("@cod_a4", 14);
                        ins_abilitate4.Parameters.AddWithValue("@nr_slot4", 4);

                        ins_abilitate1.ExecuteNonQuery();
                        ins_abilitate2.ExecuteNonQuery();
                        ins_abilitate3.ExecuteNonQuery();
                        ins_abilitate4.ExecuteNonQuery();
                    }
                    else if (id_cls[i] == 3) //abilitatile pentru clasa "tămăduitor"
                    {
                        ins_abilitate1.Parameters.AddWithValue("@cod_a1", 19);
                        ins_abilitate1.Parameters.AddWithValue("@nr_slot1", 1);

                        ins_abilitate2.Parameters.AddWithValue("@cod_a2", 3);
                        ins_abilitate2.Parameters.AddWithValue("@nr_slot2", 2);

                        ins_abilitate3.Parameters.AddWithValue("@cod_a3", 16);
                        ins_abilitate3.Parameters.AddWithValue("@nr_slot3", 3);

                        ins_abilitate4.Parameters.AddWithValue("@cod_a4", 15);
                        ins_abilitate4.Parameters.AddWithValue("@nr_slot4", 4);

                        ins_abilitate1.ExecuteNonQuery();
                        ins_abilitate2.ExecuteNonQuery();
                        ins_abilitate3.ExecuteNonQuery();
                        ins_abilitate4.ExecuteNonQuery();
                    }
                    else if (id_cls[i] == 4) //abilitatile pentru clasa "vrăjitor"
                    {
                        ins_abilitate1.Parameters.AddWithValue("@cod_a1", 19);
                        ins_abilitate1.Parameters.AddWithValue("@nr_slot1", 1);

                        ins_abilitate2.Parameters.AddWithValue("@cod_a2", 4);
                        ins_abilitate2.Parameters.AddWithValue("@nr_slot2", 2);

                        ins_abilitate3.Parameters.AddWithValue("@cod_a3", 17);
                        ins_abilitate3.Parameters.AddWithValue("@nr_slot3", 3);

                        ins_abilitate4.Parameters.AddWithValue("@cod_a4", 18);
                        ins_abilitate4.Parameters.AddWithValue("@nr_slot4", 4);

                        ins_abilitate1.ExecuteNonQuery();
                        ins_abilitate2.ExecuteNonQuery();
                        ins_abilitate3.ExecuteNonQuery();
                        ins_abilitate4.ExecuteNonQuery();
                    }     
                }
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
