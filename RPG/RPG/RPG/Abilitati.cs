using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using WMPLib;

namespace RPG
{
    class Abilitati //In aceasta facem legatura dintre ecranul de lupta si efectele abilitatilor
    {
        private static void Blocare_abilitati_personaj() //Verifica ce personaj a folosit o abilitate si seteaza ab_fol_p(x) la 1 unde x e nr slot-ului personajului
        {
            if (Lupta.ab_sel_p1 == 1) Lupta.ab_fol_p1 = 1;
            else if (Lupta.ab_sel_p2 == 1) Lupta.ab_fol_p2 = 1;
            else if (Lupta.ab_sel_p3 == 1) Lupta.ab_fol_p3 = 1;
            Lupta.mem_ab_sel = 0;
        }

        public static void Centralizator_abilitati_ofensive(int slot_pers,int id_ab,int nr_inm) //slot_pers=cine foloseste abilitatea personajul din slot-ul 1,2 sau 3
        {
            if ((slot_pers == 1 && Lupta.vc_p1 > 0) || (slot_pers == 2 && Lupta.vc_p2 > 0) || (slot_pers == 3 && Lupta.vc_p3 > 0))
            {
                //Abilităţile ofensive ale clasei "Războinic"

                if (id_ab == 1) //Abilitatea "Lovitură sabie"
                {
                    if (nr_inm == 1 && Efecte_ofensive.i1_eplacat==1) Lupta.vc_i1 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i1, 15+10, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 a fost placat in tura precedenta
                    else if (nr_inm == 1 && Efecte_ofensive.i1_eplacat == 0) Lupta.vc_i1 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i1, 15, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 nu a fost placat in tura precedenta
                    else if (nr_inm == 2 && Efecte_ofensive.i2_eplacat == 1) Lupta.vc_i2 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i2, 15+10, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 a fost placat in tura precedenta
                    else if (nr_inm == 2 && Efecte_ofensive.i2_eplacat == 0) Lupta.vc_i2 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i2, 15, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 nu a fost placat in tura precedenta
                    else if (nr_inm == 3 && Efecte_ofensive.i3_eplacat == 1) Lupta.vc_i3 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i3, 15+10, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 a fost placat in tura precedenta
                    else if (nr_inm == 3 && Efecte_ofensive.i3_eplacat == 0) Lupta.vc_i3 = Efecte_ofensive.Lovitura_sabie(Lupta.vc_i3, 15, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 a fost placat in tura precedenta

                    Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                }

                if (id_ab == 10) //Abilitatea "Placare"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 20) || (slot_pers == 2 && Lupta.ec_p2 >= 20) || (slot_pers == 3 && Lupta.ec_p3 >= 20)) //Verificam daca personajul care foloseste placarea are 20 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_placare_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_placare_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_placare_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            if (nr_inm == 1) Lupta.vc_i1 = Efecte_ofensive.Placare(Lupta.vc_i1, 5, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz, 1089, 151);
                            else if (nr_inm == 2) Lupta.vc_i2 = Efecte_ofensive.Placare(Lupta.vc_i2, 5, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz, 1089, 320);
                            else if (nr_inm == 3) Lupta.vc_i3 = Efecte_ofensive.Placare(Lupta.vc_i3, 5, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz, 1089, 493);

                            if (nr_inm == 1) Efecte_ofensive.i1_eplacat = 1;
                            else if (nr_inm == 2) Efecte_ofensive.i2_eplacat = 1;
                            else if (nr_inm == 3) Efecte_ofensive.i3_eplacat = 1;

                            if (nr_inm == 1) Lupta.paraliz_i1 = 1;
                            else if (nr_inm == 2) Lupta.paraliz_i2 = 1;
                            else if (nr_inm == 3) Lupta.paraliz_i3 = 1;

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 20);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 20);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 20);

                            if (slot_pers == 1) Efecte_ofensive.reincarca_placare_p1 = 2;
                            else if (slot_pers == 2) Efecte_ofensive.reincarca_placare_p2 = 2;
                            else if (slot_pers == 3) Efecte_ofensive.reincarca_placare_p3 = 2;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reincarcat");
                    }
                    else MessageBox.Show("Energie insuficienta pentru \n a folosi aceasta abilitate");
                }

                //Abilităţile ofensive ale clasei "Arcaş"

                if (id_ab==2) //Abilitatea "Lovitură săgeată"
                {
                    if ((slot_pers == 1 && Efecte_ofensive.reincarca_sag_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_sag_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_sag_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                    {
                        if (nr_inm == 1 && Efecte_ofensive.i1_etintit == 1) Lupta.vc_i1 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i1, 15*2, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 e tintit
                        else if (nr_inm == 1 && Efecte_ofensive.i1_etintit == 0) Lupta.vc_i1 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i1, 15, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 nu e tintit
                        else if (nr_inm == 2 && Efecte_ofensive.i2_etintit == 1) Lupta.vc_i2 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i2, 15*2, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 e tintit
                        else if (nr_inm == 2 && Efecte_ofensive.i2_etintit == 0) Lupta.vc_i2 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i2, 15, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 nu e tintit
                        else if (nr_inm == 3 && Efecte_ofensive.i3_etintit == 1) Lupta.vc_i3 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i3, 15*2, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 e tintit
                        else if (nr_inm == 3 && Efecte_ofensive.i3_etintit == 0) Lupta.vc_i3 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i3, 15, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 nu e tintit

                        Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                    }
                    else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                }

                if (id_ab == 12) //Abilitatea "Ţintire"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 15) || (slot_pers == 2 && Lupta.ec_p2 >= 15) || (slot_pers == 3 && Lupta.ec_p3 >= 15)) //Verificam daca personajul care foloseste tintirea are 15 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_tintire_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_tintire_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_tintire_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            if (slot_pers == 1 && nr_inm == 1) //vedem care dintre cele 3 personaje e arcasul si ce inamic tinteste 
                            {
                                Efecte_ofensive.i1_etintit = 1;
                                Efecte_ofensive.Tintire(235,151,1049,151);
                            }
                            else if (slot_pers == 1 && nr_inm == 2)
                            {
                                Efecte_ofensive.i2_etintit = 1;
                                Efecte_ofensive.Tintire(235, 151, 1049, 320);
                            }
                            else if (slot_pers == 1 && nr_inm == 3)
                            {
                                Efecte_ofensive.i3_etintit = 1;
                                Efecte_ofensive.Tintire(235, 151, 1049, 493);
                            }
                            else if (slot_pers == 2 && nr_inm == 1)
                            {
                                Efecte_ofensive.i1_etintit = 1;
                                Efecte_ofensive.Tintire(235, 320, 1049, 151);
                            }
                            else if (slot_pers == 2 && nr_inm == 2)
                            {
                                Efecte_ofensive.i2_etintit = 1;
                                Efecte_ofensive.Tintire(235, 320, 1049, 320);
                            }
                            else if (slot_pers == 2 && nr_inm == 3)
                            {
                                Efecte_ofensive.i3_etintit = 1;
                                Efecte_ofensive.Tintire(235, 320, 1049, 493);
                            }
                            else if (slot_pers == 3 && nr_inm == 1)
                            {
                                Efecte_ofensive.i1_etintit = 1;
                                Efecte_ofensive.Tintire(235, 493, 1049, 151);
                            }
                            else if (slot_pers == 3 && nr_inm == 2)
                            {
                                Efecte_ofensive.i2_etintit = 1;
                                Efecte_ofensive.Tintire(235, 493, 1049, 320);
                            }
                            else if (slot_pers == 3 && nr_inm == 3)
                            {
                                Efecte_ofensive.i3_etintit = 1;
                                Efecte_ofensive.Tintire(235, 493, 1049, 493);
                            }

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 15);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 15);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 15);

                            if (slot_pers == 1) Efecte_ofensive.reincarca_tintire_p1 = 4;
                            else if (slot_pers == 2) Efecte_ofensive.reincarca_tintire_p2 = 4;
                            else if (slot_pers == 3) Efecte_ofensive.reincarca_tintire_p3 = 4;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                    }
                    else MessageBox.Show("Energie insuficienta pentru \n a folosi aceasta abilitate");
                }

                if (id_ab == 13) //Abilitatea "Lovitură dublă săgeată"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 15) || (slot_pers == 2 && Lupta.ec_p2 >= 15) || (slot_pers == 3 && Lupta.ec_p3 >= 15)) //Verificam daca personajul care foloseste tintirea are 15 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_sag_dubl_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_sag_dubl_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_sag_dubl_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            if (nr_inm == 1 && Efecte_ofensive.i1_etintit == 1) Lupta.vc_i1 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i1, 22.5, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 e tintit
                            else if (nr_inm == 1 && Efecte_ofensive.i1_etintit == 0) Lupta.vc_i1 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i1, 15, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //daca inamicul 1 nu e tintit
                            else if (nr_inm == 2 && Efecte_ofensive.i2_etintit == 1) Lupta.vc_i2 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i2, 22.5, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 e tintit
                            else if (nr_inm == 2 && Efecte_ofensive.i2_etintit == 0) Lupta.vc_i2 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i2, 15, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz); //daca inamicul 2 nu e tintit
                            else if (nr_inm == 3 && Efecte_ofensive.i3_etintit == 1) Lupta.vc_i3 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i3, 22.5, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 e tintit
                            else if (nr_inm == 3 && Efecte_ofensive.i3_etintit == 0) Lupta.vc_i3 = Efecte_ofensive.Lovitura_dubla_sageata(Lupta.vc_i3, 15, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz); //daca inamicul 3 nu e tintit

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 15);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 15);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 15);

                            if (slot_pers == 1)
                            {
                                Efecte_ofensive.reincarca_sag_p1 = 2; //blochez "Lovitură săgeată" 
                                Efecte_ofensive.reincarca_sag_dubl_p1 = 3; //blochez "Lovitură dublă săgeată"
                            }
                            if (slot_pers == 2)
                            {
                                Efecte_ofensive.reincarca_sag_p2 = 2; //blochez "Lovitură săgeată" 
                                Efecte_ofensive.reincarca_sag_dubl_p2 = 3; //blochez "Lovitură dublă săgeată"
                            }
                            if (slot_pers == 3)
                            {
                                Efecte_ofensive.reincarca_sag_p3 = 2; //blochez "Lovitură săgeată" 
                                Efecte_ofensive.reincarca_sag_dubl_p3 = 3; //blochez "Lovitură dublă săgeată"
                            }

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reincărcat");
                    }
                    else MessageBox.Show("Energie insuficienta pentru \n a folosi aceasta abilitate");
                }

                if (id_ab == 14) //Abilitatea "Ploaie de săgeţi"
                {
                    int i1_ploaie_sag, i2_ploaie_sag, i3_ploaie_sag;
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 15) || (slot_pers == 2 && Lupta.ec_p2 >= 15) || (slot_pers == 3 && Lupta.ec_p3 >= 15)) //Verificam daca personajul care foloseste ploaia de săgeţi are 15 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_ploaie_sag_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_ploaie_sag_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_ploaie_sag_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            do
                            {
                                Random rnd = new Random();
                                i1_ploaie_sag = rnd.Next(1, 4); //generez un numar la intamplare intre 1 si 3 (???)
                                i2_ploaie_sag = rnd.Next(1, 4);
                                i3_ploaie_sag = rnd.Next(1, 4);
                            } while (i1_ploaie_sag == i2_ploaie_sag || i2_ploaie_sag == i3_ploaie_sag || i1_ploaie_sag == i3_ploaie_sag); //generam 3 numere intre 1 si 3 la intamplare si repetam pana cand sunt distincte

                            if (nr_inm == 1 || nr_inm==2 || nr_inm==3) //indiferent de inamicul tintit
                            {
                                Lupta.vc_i1 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i1, 5 * i1_ploaie_sag, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz); //cate puncte de viata se scad de la primul,al doilea si al treilea personaj (5,10 sau 15)
                                Lupta.vc_i2 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i2, 5 * i2_ploaie_sag, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz);
                                Lupta.vc_i3 = Efecte_ofensive.Lovitura_sageata(Lupta.vc_i3, 5 * i3_ploaie_sag, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz);
                            }

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 15);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 15);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 15);

                            if (slot_pers == 1) Efecte_ofensive.reincarca_ploaie_sag_p1 = 3;
                            else if (slot_pers == 2) Efecte_ofensive.reincarca_ploaie_sag_p2 = 3;
                            else if (slot_pers == 3) Efecte_ofensive.reincarca_ploaie_sag_p3 = 3;

                            Efecte_ofensive.turn_fol_ploaie = Lupta.nr_tura; //memorez tura cand a fost folosita ploaia de sageti
                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reincărcat");
                    }
                        else MessageBox.Show("Energie insuficienta pentru \n a folosi aceasta abilitate");
                }

                //Abilităţile ofensive ale clasei "Vrăjitor"

                if (id_ab == 19) //Abilitatea "Lovitură toiag"
                {
                    if (nr_inm == 1) Lupta.vc_i1 = Efecte_ofensive.Lovitura_toiag(Lupta.vc_i1, 5, Lupta.atc_cresc_p1_fiz, Lupta.atc_scad_p1_fiz);
                    else if (nr_inm == 2) Lupta.vc_i2 = Efecte_ofensive.Lovitura_toiag(Lupta.vc_i2, 5, Lupta.atc_cresc_p2_fiz, Lupta.atc_scad_p2_fiz);
                    else if (nr_inm == 3) Lupta.vc_i3 = Efecte_ofensive.Lovitura_toiag(Lupta.vc_i3, 5, Lupta.atc_cresc_p3_fiz, Lupta.atc_scad_p3_fiz);

                    Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                }

                    if (id_ab == 4) //Abilitatea "Sferă de foc"
                    {
                        if ((slot_pers == 1 && Lupta.ec_p1 >= 25) || (slot_pers == 2 && Lupta.ec_p2 >= 25) || (slot_pers == 3 && Lupta.ec_p3 >= 25)) //Verificam daca personajul care foloseste sfera de foc are 25 de puncte de energie pt a consuma
                        {
                            if ((slot_pers == 1 && Efecte_ofensive.reincarca_sfera_foc_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_sfera_foc_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_sfera_foc_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                            {
                                if (nr_inm == 1) Lupta.vc_i1 = Efecte_ofensive.Sfera_foc(Lupta.vc_i1, 20, 1127, 151);
                                else if (nr_inm == 2) Lupta.vc_i2 = Efecte_ofensive.Sfera_foc(Lupta.vc_i2, 20, 1127, 320);
                                else if (nr_inm == 3) Lupta.vc_i3 = Efecte_ofensive.Sfera_foc(Lupta.vc_i3, 20, 1127, 493);

                                if (nr_inm == 1) Efecte_ofensive.i1_ears = 1;
                                else if (nr_inm == 2) Efecte_ofensive.i2_ears = 1;
                                else if (nr_inm == 3) Efecte_ofensive.i3_ears = 1;

                                if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 25);
                                else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 25);
                                else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 25);

                                if (slot_pers == 1) Efecte_ofensive.reincarca_sfera_foc_p1 = 3;
                                else if (slot_pers == 2) Efecte_ofensive.reincarca_sfera_foc_p2 = 3;
                                else if (slot_pers == 3) Efecte_ofensive.reincarca_sfera_foc_p3 = 3;

                                Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                            }
                            else MessageBox.Show("Abilitatea nu s-a reincarcat");
                        }
                        else MessageBox.Show("Energie insuficienta pentru \n a folosi aceasta abilitate");
                    }

                if (id_ab == 17) //Abilitatea "Viscol"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 30) || (slot_pers == 2 && Lupta.ec_p2 >= 30) || (slot_pers == 3 && Lupta.ec_p3 >= 30)) //Verificam daca personajul care foloseste sfera de foc are 25 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_viscol_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_viscol_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_viscol_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            Lupta.vc_i1 = Efecte_ofensive.Viscol(Lupta.vc_i1, 10,969, 151);
                            Lupta.vc_i2 = Efecte_ofensive.Viscol(Lupta.vc_i2, 10,969, 320);
                            Lupta.vc_i3 = Efecte_ofensive.Viscol(Lupta.vc_i3, 10,969, 493);

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 30);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 30);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 30);

                            if (slot_pers == 1) Efecte_ofensive.reincarca_viscol_p1 = 5;
                            else if (slot_pers == 2) Efecte_ofensive.reincarca_viscol_p2 = 5;
                            else if (slot_pers == 3) Efecte_ofensive.reincarca_viscol_p3 = 5;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reincarcat");
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }

                if (id_ab == 18) //Abilitatea "Iederă agăţătoare"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 20) || (slot_pers == 2 && Lupta.ec_p2 >= 20) || (slot_pers == 3 && Lupta.ec_p3 >= 20)) //Verificam daca personajul care foloseste iedera agatatoare are 20 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_ofensive.reincarca_iedera_p1 == 0) || (slot_pers == 2 && Efecte_ofensive.reincarca_iedera_p2 == 0) || (slot_pers == 3 && Efecte_ofensive.reincarca_iedera_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            if (slot_pers == 1)
                            {
                                Lupta.ec_p1 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p1, 20); //Aplic consumul de 20 puncte energie
                                Lupta.ec_p1 = Efecte_ofensive.Fur_energie(Lupta.emax_p1, Lupta.ec_p1, Lupta.ec_i1, 5); //Fur 5 puncte de enrgie de la inamicul afectat
                                Efecte_ofensive.p1_fur = 1; //personajul care fura energie
                            }
                            else if (slot_pers == 2)
                            {
                                Lupta.ec_p2 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p2, 20);
                                Lupta.ec_p2 = Efecte_ofensive.Fur_energie(Lupta.emax_p2, Lupta.ec_p2, Lupta.ec_i2, 5);
                                Efecte_ofensive.p2_fur = 1;
                            }
                            else if (slot_pers == 3)
                            {
                                Lupta.ec_p3 = Efecte_ofensive.Consum_Abilitate_of(Lupta.ec_p3, 20);
                                Lupta.ec_p3 = Efecte_ofensive.Fur_energie(Lupta.emax_p3, Lupta.ec_p3, Lupta.ec_i3, 5);
                                Efecte_ofensive.p3_fur = 1;
                            }

                            if (nr_inm == 1)
                            {
                                Lupta.vc_i1 = Efecte_ofensive.Iedera(Lupta.vc_i1, 5, 929, 151); //aplic damage-ul si poza de la abilitatea "Iederă agăţătoare"
                                Lupta.ec_i1 = Efecte_ofensive.Scad_energie(Lupta.ec_i1, 5); //Scad energia inamicului 1
                                Lupta.paraliz_i1 = 1; //paralizez inamicul din slot-ul 1
                                Efecte_ofensive.i1_incalcit = 1;
                            }
                            else if (nr_inm == 2)
                            {
                                Lupta.vc_i2 = Efecte_ofensive.Iedera(Lupta.vc_i2, 5, 929, 320);
                                Lupta.ec_i2 = Efecte_ofensive.Scad_energie(Lupta.ec_i2, 5); //Scad energia inamicului 2
                                Lupta.paraliz_i2 = 1; //paralizez inamicul din slot-ul 2
                                Efecte_ofensive.i2_incalcit = 1;
                            }
                            else if (nr_inm == 3)
                            {
                                Lupta.vc_i3 = Efecte_ofensive.Iedera(Lupta.vc_i3, 5, 929, 493);
                                Lupta.ec_i3 = Efecte_ofensive.Scad_energie(Lupta.ec_i3, 5); //Scad energia inamicului 3
                                Lupta.paraliz_i3 = 1; //paralizez inamicul din slot-ul 3
                                Efecte_ofensive.i3_incalcit = 1;
                            }

                            if (slot_pers == 1) Efecte_ofensive.reincarca_iedera_p1 = 3;
                            else if (slot_pers == 2) Efecte_ofensive.reincarca_iedera_p2 = 3;
                            else if (slot_pers == 3) Efecte_ofensive.reincarca_iedera_p3 = 3;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }
            } else MessageBox.Show("Personajul e prea grav rănit \n pentru a actiona");
        }

        public static void Centralizator_abilitati_defensive(int slot_pers, int id_ab, int nr_pers) //slot_pers=cine foloseste abilitatea personajul din slot-ul 1,2 sau 3
        {
            if ((slot_pers == 1 && Lupta.vc_p1 > 0) || (slot_pers == 2 && Lupta.vc_p2 > 0) || (slot_pers == 3 && Lupta.vc_p3 > 0)) //verificam ca personajele vindecate sa aiba mai mult de 0 puncte viata
            {

                //Abilităţile defensive ale clasei "Războinic"

                if (id_ab == 9) //Abilitatea "Apărare scut"
                {
                    if (nr_pers == 1) Lupta.reduc_p1 = Efecte_defensive.Aparare_scut(Lupta.reduc_p1, 20, 1);
                    else if (nr_pers == 2) Lupta.reduc_p2 = Efecte_defensive.Aparare_scut(Lupta.reduc_p2, 20, 2);
                    else if (nr_pers == 3) Lupta.reduc_p3 = Efecte_defensive.Aparare_scut(Lupta.reduc_p3, 20, 3);

                    Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                }

                if (id_ab == 11) //Abilitatea "Strigăt de luptă"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 5) || (slot_pers == 2 && Lupta.ec_p2 >= 5) || (slot_pers == 3 && Lupta.ec_p3 >= 5)) //Verificam daca personajul care foloseste strigatul are 5 puncte pentru a consuma
                    {
                        if ((slot_pers == 1 && Efecte_defensive.reincarca_strigat_p1 == 0) || (slot_pers == 2 && Efecte_defensive.reincarca_strigat_p2 == 0) || (slot_pers == 3 && Efecte_defensive.reincarca_strigat_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reincarcat
                        {
                            Efecte_defensive.Strigat_lupta();

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p1, 5);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p2, 5);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p3, 5);

                            if (slot_pers == 1) Efecte_defensive.reincarca_strigat_p1 = 2;
                            else if (slot_pers == 2) Efecte_defensive.reincarca_strigat_p2 = 2;
                            else if (slot_pers == 3) Efecte_defensive.reincarca_strigat_p3 = 2;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }

                //Abilităţile defensive ale clasei "Tămăduitor"

                if (id_ab == 3) //Abilitatea "Vindeca"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 15) || (slot_pers == 2 && Lupta.ec_p2 >= 15) || (slot_pers == 3 && Lupta.ec_p3 >= 15)) //Verificam daca personajul care foloseste sfera de foc are 15 de puncte de energie pt a consuma
                    {
                        if (nr_pers == 1) Lupta.vc_p1 = Efecte_defensive.Vindeca(Lupta.vc_p1, Lupta.vmax_p1, 20);
                        if (nr_pers == 2) Lupta.vc_p2 = Efecte_defensive.Vindeca(Lupta.vc_p2, Lupta.vmax_p2, 20);
                        if (nr_pers == 3) Lupta.vc_p3 = Efecte_defensive.Vindeca(Lupta.vc_p3, Lupta.vmax_p3, 20);

                        if (slot_pers == 1) Lupta.ec_p1 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p1, 15);
                        else if (slot_pers == 2) Lupta.ec_p2 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p2, 15);
                        else if (slot_pers == 3) Lupta.ec_p3 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p3, 15);

                        Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }

                if (id_ab == 15) //Abilitatea "Regenerare"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 20) || (slot_pers == 2 && Lupta.ec_p2 >= 20) || (slot_pers == 3 && Lupta.ec_p3 >= 20)) //Verificam daca personajul care foloseste regenerarea are 20 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_defensive.reincarca_regen_p1 == 0) || (slot_pers == 2 && Efecte_defensive.reincarca_regen_p2 == 0) || (slot_pers == 3 && Efecte_defensive.reincarca_regen_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reîncarcat
                        {
                            if (nr_pers == 1) Lupta.vc_p1 = Efecte_defensive.Regenerare(1, Lupta.vc_p1, Lupta.vmax_p1, 5, 115, 151, 2);
                            else if (nr_pers == 2) Lupta.vc_p2 = Efecte_defensive.Regenerare(2, Lupta.vc_p2, Lupta.vmax_p2, 5, 115, 320, 2);
                            else if (nr_pers == 3) Lupta.vc_p3 = Efecte_defensive.Regenerare(3, Lupta.vc_p3, Lupta.vmax_p3, 5, 115, 493, 2);

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p1, 20);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p2, 20);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p3, 20);

                            if (slot_pers == 1) Efecte_defensive.reincarca_regen_p1 = 4;
                            else if (slot_pers == 2) Efecte_defensive.reincarca_regen_p2 = 4;
                            else if (slot_pers == 3) Efecte_defensive.reincarca_regen_p3 = 4;

                            Blocare_abilitati_personaj(); //blochez abilitatile personajului care a folosit o abilitate
                        }
                        else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }

                if (id_ab == 16) //Abilitatea "Vindecare în masă"
                {
                    if ((slot_pers == 1 && Lupta.ec_p1 >= 30) || (slot_pers == 2 && Lupta.ec_p2 >= 30) || (slot_pers == 3 && Lupta.ec_p3 >= 30)) //Verificam daca personajul care foloseste vindecarea in masa are 30 de puncte de energie pt a consuma
                    {
                        if ((slot_pers == 1 && Efecte_defensive.reincarca_vind_mas_p1 == 0) || (slot_pers == 2 && Efecte_defensive.reincarca_vind_mas_p2 == 0) || (slot_pers == 3 && Efecte_defensive.reincarca_vind_mas_p3 == 0)) //Verificam ca personajul care foloseste abilitatea sa nu o aiba la reîncarcat
                        {
                            Lupta.vc_p1 = Efecte_defensive.Vindecare_mas(Lupta.vc_p1, Lupta.vmax_p1);
                            Lupta.vc_p2 = Efecte_defensive.Vindecare_mas(Lupta.vc_p2, Lupta.vmax_p2);
                            Lupta.vc_p3 = Efecte_defensive.Vindecare_mas(Lupta.vc_p3, Lupta.vmax_p3);

                            if (slot_pers == 1) Lupta.ec_p1 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p1, 30);
                            else if (slot_pers == 2) Lupta.ec_p2 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p2, 30);
                            else if (slot_pers == 3) Lupta.ec_p3 = Efecte_defensive.Consum_Abilitate_def(Lupta.ec_p3, 30);

                            if (slot_pers == 1) Efecte_defensive.reincarca_vind_mas_p1 = 3;
                            else if (slot_pers == 2) Efecte_defensive.reincarca_vind_mas_p2 = 3;
                            else if (slot_pers == 3) Efecte_defensive.reincarca_vind_mas_p3 = 3;
                        }
                        else MessageBox.Show("Abilitatea nu s-a reîncărcat");
                    }
                    else MessageBox.Show("Energie insuficientă pentru \n a folosi această abilitate");
                }
            }
            else MessageBox.Show("Personajul e prea grav rănit \n pentru a acţiona");
        }
    }
}
