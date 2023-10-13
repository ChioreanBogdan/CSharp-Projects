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
    class Efecte_ofensive
    {
        public static int turn_fol_placare,turn_fol_tintire,turn_fol_sag_dubl,turn_fol_ploaie, turn_fol_sfera_foc,tura_fol_viscol,tura_fol_iedera,turn_fol_muscatura,provoaca_rana; //la turn_fol_sfera_foc cred ca am o problema daca sunt mai mult de 1 vrajitori intr-un grup si folosesc sfera de foc la 1-2 ture distanta
        public static int urlet_in_efect = 0; public static int urlet_act=0; //verific daca urletul e in efect (1) sau nu (0),urlet_act erifica daca urletul se activeaza in tura respectiva
        public static int i1_ears = 0; public static int i2_ears = 0; public static int i3_ears = 0; //variabila care devine 1 in functie de ce inamic e ars
        public static int i1_degerat = 0; public static int i2_degerat = 0; public static int i3_degerat = 0; //variabila care devine 1 in functie de ce inamic e afectat de degeraturi
        public static int i1_incalcit = 0; public static int i2_incalcit = 0; public static int i3_incalcit = 0; //variabila care devine 1 in functie de ce inamic e prins in iedera agatatoare
        public static int i1_eplacat = 0; public static int i2_eplacat = 0; public static int i3_eplacat = 0; //variabila care devine 1 in functie de ce inamic e placat
        public static int i1_etintit = 0; public static int i2_etintit = 0; public static int i3_etintit = 0; //variabila care devine 1 in functie de ce inamic e tintit
        public static int p1_fur = 0; public static int p2_fur = 0; public static int p3_fur = 0; //variabila care devine 1 in functie de care personaje fura energie cu abilitatea "Iederă agăţătoare"
        public static int p1_sang = 0; public static int p2_sang = 0; public static int p3_sang = 0; //variabila care devine 1 in functie de care personaje sangereaza

        public static Form lup = Application.OpenForms["lupt"]; //Avem deschis form-ul 0 (RPG) si 1 (Lupta),deci inseram o poza in OpenForms[1]

        public static List<PictureBox> poze_placari = new List<PictureBox>(); //poza cu placare ce apare in dreptul unui inamic placat
        public static List<PictureBox> poze_tintiri = new List<PictureBox>(); //poza cu placare ce apare in dreptul unui inamic tintit,dar si in dreptul arcasului
        public static List<PictureBox> poze_arsuri = new List<PictureBox>(); //poza cu arsuri ce apare in dreptul inamicului afectat de o sfera de foc
        public static List<PictureBox> poze_viscoliri = new List<PictureBox>(); //poza ce apare in dreptul inamicului afectat de efectul de viscolire
        public static List<PictureBox> poze_degeraturi = new List<PictureBox>(); //poza ce apare in dreptul inamicului afectat de efectul de degerare
        public static List<PictureBox> poze_iedere = new List<PictureBox>(); //poza ce apare in dreptul inamicului paralizat de iedera agatatoare
        public static List<PictureBox> poze_sangerare = new List<PictureBox>(); //poze ce apar in dreptul personajului ce e afectat de o sangerare
        public static List<PictureBox> poze_urlete = new List<PictureBox>(); //poze ce apar in dreptul personajului ce e afectat de urletul lupilor
        public static int reincarca_placare_p1 = 0; public static int reincarca_placare_p2 = 0; public static int reincarca_placare_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca placarea sa se reincarce
        public static int reincarca_tintire_p1 = 0; public static int reincarca_tintire_p2 = 0; public static int reincarca_tintire_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca tintirea sa se reincarce
        public static int reincarca_sag_p1 = 0; public static int reincarca_sag_p2 = 0; public static int reincarca_sag_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca lovitura de sageata sa se reincarce
        public static int reincarca_sag_dubl_p1 = 0; public static int reincarca_sag_dubl_p2 = 0; public static int reincarca_sag_dubl_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca lovitura dubla de sageata sa se reincarce
        public static int reincarca_ploaie_sag_p1 = 0; public static int reincarca_ploaie_sag_p2 = 0; public static int reincarca_ploaie_sag_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca ploaia de sageti sa se reincarce
        public static int reincarca_sfera_foc_p1 = 0; public static int reincarca_sfera_foc_p2 = 0; public static int reincarca_sfera_foc_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca sfera de foc sa se reincarce
        public static int reincarca_viscol_p1 = 0; public static int reincarca_viscol_p2 = 0; public static int reincarca_viscol_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca viscolul sa se reincarce
        public static int reincarca_iedera_p1 = 0; public static int reincarca_iedera_p2 = 0; public static int reincarca_iedera_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca abilitatea "Iederă agăţătoare" sa se reincarce

        //Abilitatile ofensive ale clasei "Războinic"

        public static int Lovitura_sabie(int viata, int dmg,int plus,int minus) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {
            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;
            viata = viata - dmg;
            return viata;
        }

        public static int Placare(int viata, int dmg, int plus, int minus, int x, int y) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului,plus bonusurile de atac si minus penalizarile de atac
        {                                                          //x si y reprezinta coordonatele la care va fi inserata poza cu efectul de placare
            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;
            viata = viata - dmg;

            if (viata > 0) //daca inamicul nu ajunge la 0 puncte viata in urma placarii
            {
                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                PictureBox poza_placare = new PictureBox { };
                poza_placare.Name = "Placare";
                poza_placare.Size = new Size(38, 38);
                poza_placare.Location = new Point(x, y);
                poza_placare.Image = Image.FromFile("Abilitati\\Razboinic\\Placare.jpg");
                descriere.SetToolTip(poza_placare, "Inamicul e paralizat \n iar 'Lovitură sabie' \n va provoca cu 10 puncte \n de atac mai mult \n acestui inamic");

                poza_placare.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_placari.Add(poza_placare);
            }

            turn_fol_placare = Lupta.nr_tura; //memoram tura cand a fost folosita placarea
            return viata;
        }

        public static void Inamicul_e_placat(int tura) //verific care inamici sunt placati ATENTIE! Probleme cu poza placare daca avem mai multi razboinici in grup sau timpul de reincarcare<1
        {
            if (tura == turn_fol_placare + 1)
            {
                if (i1_eplacat == 1)
                {
                    Lupta.paraliz_i1 = 0; //inamicul 1 nu mai e paralizat
                }
                if (i2_eplacat == 1)
                {
                    Lupta.paraliz_i2 = 0; //inamicul 2 nu mai e paralizat
                }
                if (i3_eplacat == 1)
                {
                    Lupta.paraliz_i3 = 0; //inamicul 3 nu mai e paralizat
                }

                if (i1_eplacat == 1) i1_eplacat = 0;
                if (i2_eplacat == 1) i2_eplacat = 0;
                if (i3_eplacat == 1) i3_eplacat = 0;
            }

            if (reincarca_placare_p1 != 0) reincarca_placare_p1 = reincarca_placare_p1 - 1;
            if (reincarca_placare_p2 != 0) reincarca_placare_p2 = reincarca_placare_p2 - 1;
            if (reincarca_placare_p3 != 0) reincarca_placare_p3 = reincarca_placare_p3 - 1;
        }

        //Abilitatile ofensive ale clasei "Arcaş"

        public static int Lovitura_sageata(int viata, int dmg, int plus, int minus) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {
            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;
            viata = viata - dmg;
            return viata;
        }

        public static void Tintire(int x_a,int y_a,int x_i,int y_i) //x_i si y_i-coordonatele la care va fi inserata poza de tintire in dreptul inamicului iar x_a si y_a poza care fi inserata in dreptul arcasului
        {
            ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza de tintire ce apare in dreptul inamicului si a arcasului
            PictureBox poza_tintire_i = new PictureBox { }; PictureBox poza_tintire_a = new PictureBox { };
            poza_tintire_i.Name = "Poza tintire inamic"; poza_tintire_a.Name = "Poza tintire arcas";
            poza_tintire_i.Size = new Size(38, 38); poza_tintire_a.Size = new Size(38, 38);
            poza_tintire_i.Location = new Point(x_i, y_i); poza_tintire_a.Location = new Point(x_a, y_a);
            poza_tintire_i.Image = Image.FromFile("Abilitati\\Arcas\\Tintire.jpg"); poza_tintire_a.Image = Image.FromFile("Abilitati\\Arcas\\Tintire.jpg");
            descriere.SetToolTip(poza_tintire_i, "Acest personaj va \n suferi cu 15 puncte \n în plus daune de la \n 'Lovitură săgeată' şi \n 'Lovitură dublă săgeată'");
            descriere.SetToolTip(poza_tintire_a, "Arcaşul foloseşte 'Ţintire' \n această abilitate poate fi \n întreruptă dacă e paralizat");

            poza_tintire_i.SizeMode = PictureBoxSizeMode.StretchImage; poza_tintire_a.SizeMode = PictureBoxSizeMode.StretchImage;

            string durata = "2"; //cat dureaza tintirea

            PointF locatie = new PointF(0, -100);

            using (Graphics graphics = Graphics.FromImage(poza_tintire_i.Image))
            {
                using (Font blackadderFont = new Font("Blackadder ITC", 120))
                {
                    graphics.DrawString(durata, blackadderFont, Brushes.DarkGray, locatie);
                }
            }

            poze_tintiri.Add(poza_tintire_i); poze_tintiri.Add(poza_tintire_a);

            turn_fol_tintire = Lupta.nr_tura;
        }

        public static void Inamicul_e_tintit(int tura) //verific care inamici sunt tintiti ATENTIE! Probleme daca avem mai multi arcasi
        {
            int x = 0; int y = 0; //coordonatele pozei pt arsura
            if ((tura == turn_fol_tintire+1) || (tura == turn_fol_tintire + 2))
            {
                if (i1_etintit == 1 && Lupta.vc_i1 > 0)
                {
                    x = 1049; y = 151;
                }
                if (i2_etintit == 1 && Lupta.vc_i2 > 0)
                {
                    x = 1049; y = 320;
                }
                if (i3_etintit == 1 && Lupta.vc_i3 > 0)
                {
                    x = 1049; y = 493;
                }

                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza de tintire ce apare in dreptul inamicului si a arcasului
                PictureBox poza_tintire_i = new PictureBox { };
                poza_tintire_i.Name = "Poza tintire inamic";
                poza_tintire_i.Size = new Size(38, 38);
                poza_tintire_i.Location = new Point(x, y);
                poza_tintire_i.Image = Image.FromFile("Abilitati\\Arcas\\Tintire.jpg");
                descriere.SetToolTip(poza_tintire_i, "Acest personaj va \n suferi cu 15 puncte \n în plus daune de la \n 'Lovitură săgeată' şi \n 'Lovitură dublă săgeată'");

                poza_tintire_i.SizeMode = PictureBoxSizeMode.StretchImage;

                        string durata = "1"; //cat dureaza tintirea

                        PointF locatie = new PointF(0, -100);

                        using (Graphics graphics = Graphics.FromImage(poza_tintire_i.Image))
                        {
                            using (Font blackadderFont = new Font("Blackadder ITC", 120))
                            {
                                graphics.DrawString(durata, blackadderFont, Brushes.DarkGray, locatie);
                            }
                        }
                if (x!=0 && y!=0) poze_tintiri.Add(poza_tintire_i); //if-ul e ca sa nu apara o poza in coltul stanga sus dupa fiecare tura
            }

            if (tura == turn_fol_tintire + 2)
            {
                if (i1_etintit == 1) i1_etintit = 0;
                if (i2_etintit == 1) i2_etintit = 0;
                if (i3_etintit == 1) i3_etintit = 0;
            }

            if (reincarca_tintire_p1 != 0) reincarca_tintire_p1 = reincarca_tintire_p1 - 1;
            if (reincarca_tintire_p2 != 0) reincarca_tintire_p2 = reincarca_tintire_p2 - 1;
            if (reincarca_tintire_p3 != 0) reincarca_tintire_p3 = reincarca_tintire_p3 - 1;
        }

        public static int Lovitura_dubla_sageata(int viata, double dmg, int plus, int minus) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {
            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;
            viata = viata - Convert.ToInt32(dmg*2); //dmg trebuie sa fie double pentru cazul in care inamicul e tintit si am vrut ca damage-ul total sa fie 45 si nu 60,deci 22.5x2
            turn_fol_sag_dubl = Lupta.nr_tura; //retinem tura cand a fost folosita sageata dubla
            return viata;
        }

        public static void Reincarc_Lovituri_Sageti() //Reîncarc loviturile de săgeţi simple şi duble
        {
            if (reincarca_sag_dubl_p1 != 0) reincarca_sag_dubl_p1 = reincarca_sag_dubl_p1 - 1;
            if (reincarca_sag_dubl_p2 != 0) reincarca_sag_dubl_p2 = reincarca_sag_dubl_p2 - 1;
            if (reincarca_sag_dubl_p3 != 0) reincarca_sag_dubl_p3 = reincarca_sag_dubl_p3 - 1;
            if (reincarca_sag_p1 != 0) reincarca_sag_p1 = reincarca_sag_p1 - 1;
            if (reincarca_sag_p2 != 0) reincarca_sag_p2 = reincarca_sag_p2 - 1;
            if (reincarca_sag_p3 != 0) reincarca_sag_p3 = reincarca_sag_p3 - 1;
        }

        public static void Reincarc_ploaie_sageti() //Reîncarc ploaia de săgeţi
        {
            if (reincarca_ploaie_sag_p1 != 0) reincarca_ploaie_sag_p1 = reincarca_ploaie_sag_p1 - 1;
            if (reincarca_ploaie_sag_p2 != 0) reincarca_ploaie_sag_p2 = reincarca_ploaie_sag_p2 - 1;
            if (reincarca_ploaie_sag_p3 != 0) reincarca_ploaie_sag_p3 = reincarca_ploaie_sag_p3 - 1;
        }

        //Abilitatile ofensive ale clasei "Vrăjitor"

        public static int Sfera_foc(int viata, int dmg, int x, int y) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {                                                          //x si y reprezinta coordonatele la care va fi inserata poza cu efectul de arsura
            viata = viata - dmg;

                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                PictureBox poza_arsura = new PictureBox { };
                poza_arsura.Name = "Arsura";
                poza_arsura.Size = new Size(38, 38);
                poza_arsura.Location = new Point(x, y);
                poza_arsura.Image = Image.FromFile("Abilitati\\Vrajitor\\Arsura.jpg");
                descriere.SetToolTip(poza_arsura, "Inamicul e ars şi va \n pierde 10 puncte");

                poza_arsura.SizeMode = PictureBoxSizeMode.StretchImage;

                string durata = "2"; //cat dureaza arsurile

                PointF locatie = new PointF(0, -100);

                using (Graphics graphics = Graphics.FromImage(poza_arsura.Image))
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                    }
                }

            poze_arsuri.Add(poza_arsura);

            turn_fol_sfera_foc = Lupta.nr_tura; //memoram tura cand a fost folosita sfera de foc
            return viata;
        }

        public static void Inamicul_e_ars(int tura) //verific care inamici sunt arsi ATENTIE! Probleme cu poza de arsura daca avem mai multi vrajitori in grup sau timpul de reincarcare<2
        {
            int x = 0; int y = 0; //coordonatele pozei pt arsura
            if ((tura == turn_fol_sfera_foc + 1) || (tura == turn_fol_sfera_foc + 2))
            {
                if (i1_ears == 1 && Lupta.vc_i1>0)
                {
                    Lupta.vc_i1 = Lupta.vc_i1 - 10;
                    x = 1127; y = 151;
                }
                if (i2_ears == 1 && Lupta.vc_i2 > 0)
                {
                    Lupta.vc_i2 = Lupta.vc_i2 - 10;
                    x = 1127; y = 320;
                }
                if (i3_ears == 1 && Lupta.vc_i3 > 0)
                {
                    Lupta.vc_i3 = Lupta.vc_i3 - 10;
                    x = 1127; y = 493;
                }
            }

            if (tura == turn_fol_sfera_foc+1 && (x != 0 && y != 0)) //daca nu pun x!=0 si y!=0 la a doua tura apare o poza cu arsura in coltul stanga sus (nu stiu de ce)
            {
                PictureBox poza_arsura = new PictureBox { };
                poza_arsura.Name = "Arsura";
                poza_arsura.Size = new Size(38, 38);
                poza_arsura.Location = new Point(x, y);
                poza_arsura.Image = Image.FromFile("Abilitati\\Vrajitor\\Arsura.jpg");
                poza_arsura.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_arsuri.Add(poza_arsura);
                ToolTip desc = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                desc.SetToolTip(poza_arsura, "Inamicul e ars şi va \n pierde 10 puncte");

                string cooldown = "1";

                PointF locatie = new PointF(0, -100);

                using (Graphics graphics = Graphics.FromImage(poza_arsura.Image))
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(cooldown, blackadderFont, Brushes.Black, locatie);
                    }
                }
            }

            if (tura == turn_fol_sfera_foc + 2)
            {
                i1_ears = 0; i2_ears = 0; i3_ears = 0; //dupa 2 ture au trecut efectele arsurilor
                //foreach (PictureBox p in poze_arsuri) poze_arsuri.Remove(p); //dupa 2 ture stergem pozele cu arsuri
            }

            if ((Lupta.vc_i1<=0 && i1_ears==1) || (Lupta.vc_i2 <= 0 && i2_ears == 1) || (Lupta.vc_i3 <= 0 && i3_ears == 1)) //eliminam efectele de arsura daca inamicul a ajuns la 0 viaţă
            {
                i1_ears = 0; i2_ears = 0; i3_ears = 0;
            }

            if (reincarca_sfera_foc_p1 != 0) reincarca_sfera_foc_p1 = reincarca_sfera_foc_p1 - 1;
            if (reincarca_sfera_foc_p2 != 0) reincarca_sfera_foc_p2 = reincarca_sfera_foc_p2 - 1;
            if (reincarca_sfera_foc_p3 != 0) reincarca_sfera_foc_p3 = reincarca_sfera_foc_p3 - 1;
        }

        public static int Viscol(int viata,int dmg,int x_v,int y_v) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {                                                          //x_v si y_v reprezinta coordonatele la care va fi inserata poza cu efectul de viscol
            viata = viata - dmg;
            //adaug poze pentru efectul de degeratura si efetul de viscol
            ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
            PictureBox poza_viscol = new PictureBox {}; PictureBox poza_degeratura = new PictureBox {};
            poza_viscol.Name = "Viscol"; poza_degeratura.Name = "Degeratura";
            poza_viscol.Size = new Size(38, 38); poza_degeratura.Size = new Size(38, 38);
            poza_viscol.Location = new Point(x_v, y_v);
            poza_viscol.Image = Image.FromFile("Abilitati\\Vrajitor\\Gheata.jpg");
            descriere.SetToolTip(poza_viscol,"Inamicul va suferi \n daune de 10 puncte");

            poza_viscol.SizeMode = PictureBoxSizeMode.StretchImage;

            string durata = "2"; //cat dureaza viscolul

            PointF locatie = new PointF(0, -100);

            using (Graphics graphics = Graphics.FromImage(poza_viscol.Image)) //afisez pe poza cat a mai ramas din viscol
            {
                using (Font blackadderFont = new Font("Blackadder ITC", 120))
                {
                    graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                }
            }

            poze_viscoliri.Add(poza_viscol);

            tura_fol_viscol = Lupta.nr_tura; //memoram tura cand a fost folosit viscolul
            return viata;
        }

        public static void Viscoleste(int tura)
        {
            int x_v = 0; int y_v = 0; //coordonatele pozei pt viscolire
            int x_d = 0; int y_d = 0; //coordonatele pozei pt degeratura

            if (((tura == tura_fol_viscol) || (tura == tura_fol_viscol + 1) || (tura == tura_fol_viscol + 2) || (tura == tura_fol_viscol + 3)) && tura_fol_viscol != 0) //aplicam efectele degeraturii daca suntem la o tura/doua sau 3 ture dupa viscol
            {
                if (Lupta.vc_i1 > 0)
                {
                    if ((tura == tura_fol_viscol + 1) || (tura == tura_fol_viscol + 2)) Lupta.vc_i1 = Lupta.vc_i1 - 10; //daunele seaplica in primele 2 ture de la folosirea viscolului
                    x_v = 969; y_v = 151;
                    x_d = 1009; y_d = 151;
                    Poze_viscoleste(tura, x_v, y_v, x_d, y_d);
                }
                if (Lupta.vc_i2 > 0)
                {
                    if ((tura == tura_fol_viscol + 1) || (tura == tura_fol_viscol + 2)) Lupta.vc_i2 = Lupta.vc_i2 - 10;
                    x_v = 969; y_v = 320;
                    x_d = 1009; y_d = 320;
                    Poze_viscoleste(tura, x_v, y_v, x_d, y_d);
                }
                if (Lupta.vc_i3 > 0)
                {
                    if ((tura == tura_fol_viscol + 1) || (tura == tura_fol_viscol + 2)) Lupta.vc_i3 = Lupta.vc_i3 - 10;
                    x_v = 969; y_v = 493;
                    x_d = 1009; y_d = 493;
                    Poze_viscoleste(tura, x_v, y_v, x_d, y_d);
                }

                if (tura == tura_fol_viscol + 1) //daca a trecut o tura de la folosirea viscolului scad atacul fizic al tuturor inamicilor cu 10
                {
                    Lupta.atc_scad_i1_fiz = Lupta.atc_scad_i1_fiz + 10;
                    Lupta.atc_scad_i2_fiz = Lupta.atc_scad_i2_fiz + 10;
                    Lupta.atc_scad_i3_fiz = Lupta.atc_scad_i3_fiz + 10;
                }
            }

            if (tura_fol_viscol!=0 && tura == tura_fol_viscol + 4) //daca au trecut 4 ture de la folosirea viscolului elimin penalizarea de -10 puncte atac fizic
            {
                if (Lupta.atc_scad_i1_fiz >= 10) Lupta.atc_scad_i1_fiz = Lupta.atc_scad_i1_fiz - 10;
                else Lupta.atc_scad_i1_fiz = 0;
                if (Lupta.atc_scad_i2_fiz >= 10) Lupta.atc_scad_i2_fiz = Lupta.atc_scad_i2_fiz - 10;
                else Lupta.atc_scad_i2_fiz = 0;
                if (Lupta.atc_scad_i3_fiz >= 10) Lupta.atc_scad_i3_fiz = Lupta.atc_scad_i3_fiz - 10;
                else Lupta.atc_scad_i3_fiz = 0;
            }

            if (reincarca_viscol_p1 != 0) reincarca_viscol_p1 = reincarca_viscol_p1 - 1;
            if (reincarca_viscol_p2 != 0) reincarca_viscol_p2 = reincarca_viscol_p2 - 1;
            if (reincarca_viscol_p3 != 0) reincarca_viscol_p3 = reincarca_viscol_p3 - 1;
        }

        public static void Poze_viscoleste(int tura,int xv,int yv,int xd,int yd) //xv,yv si xd,yd sunt coordonatele pozelor 
        {
                //adaug poze pentru efectul de degeratura si efetul de viscol
                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                PictureBox poza_viscol = new PictureBox { }; PictureBox poza_degeratura = new PictureBox { };
                poza_viscol.Name = "Viscol"; poza_degeratura.Name = "Degeratura";
                poza_viscol.Size = new Size(38, 38); poza_degeratura.Size = new Size(38, 38);
                poza_viscol.Location = new Point(xv, yv); poza_degeratura.Location = new Point(xd, yd);
                poza_viscol.Image = Image.FromFile("Abilitati\\Vrajitor\\Gheata.jpg"); poza_degeratura.Image = Image.FromFile("Abilitati\\Vrajitor\\Degeratura.jpg");
                descriere.SetToolTip(poza_viscol, "Inamicul va suferi \n daune de 10 puncte"); descriere.SetToolTip(poza_degeratura, "Inamicul e degerat şi atacurile \n fizice ale acestuia vor cauza \n cu 10 mai puţin daune fizice ");

                poza_viscol.SizeMode = PictureBoxSizeMode.StretchImage; poza_degeratura.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_viscoliri.Add(poza_viscol); poze_degeraturi.Add(poza_degeratura);

                string durata_v = "2"; string durata_d="3"; //trebuie sa initializez variabilele astea cu ceva altfel imi da eroare using Graphics

                if (tura == tura_fol_viscol + 1) durata_v = "1"; //cat mai dureaza viscolul

            if (tura == tura_fol_viscol) durata_d = "3"; //cat mai dureaza degeraturile
            if (tura == tura_fol_viscol + 1) durata_d = "2";
            else if (tura == tura_fol_viscol + 2) durata_d = "1";

                PointF locatie = new PointF(0, -100);

                using (Graphics graphics = Graphics.FromImage(poza_viscol.Image)) //afisez pe poza cat a mai ramas din viscol
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(durata_v, blackadderFont, Brushes.Black, locatie);
                    }
                }

                using (Graphics graphics = Graphics.FromImage(poza_degeratura.Image)) //afisez pe poza cat a mai ramas din efectul de degeratura
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(durata_d, blackadderFont, Brushes.Black, locatie);
                    }
                }
         }

        public static int Iedera(int viata, int dmg, int x, int y) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {                                                          //x si y reprezinta coordonatele la care va fi inserata poza cu iedera agatatoare
            viata = viata - dmg;

            ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
            PictureBox poza_iedera = new PictureBox { };
            poza_iedera.Name = "Iedera";
            poza_iedera.Size = new Size(38, 38);
            poza_iedera.Location = new Point(x, y);
            poza_iedera.Image = Image.FromFile("Abilitati\\Vrajitor\\Iedera.jpg");
            descriere.SetToolTip(poza_iedera, "Inamicul e paralizat va \n suferi 5 puncte daune magice \n şi îi vor fi furate 5 puncte \n de energie dacă la are");

            poza_iedera.SizeMode = PictureBoxSizeMode.StretchImage;

            poze_iedere.Add(poza_iedera);

            string durata = "2"; //cat dureaza arsurile

            PointF locatie = new PointF(0, -100);

            using (Graphics graphics = Graphics.FromImage(poza_iedera.Image))
            {
                using (Font blackadderFont = new Font("Blackadder ITC", 120))
                {
                    graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                }
            }

            tura_fol_iedera = Lupta.nr_tura; //memoram tura cand a fost folosita sfera de foc
            return viata;
        }

        public static int Fur_energie(int eng_max,int eng_c,int eng_scad,int eng_fur) //eng_c e energia curenta a celui care fura,eng_max e energia sa maxima,energia eng_scad e energia e energia personajului/inamicului de la care se fura,eng_fur reprezinta cantitatea de enrgie furata
        {
            if (eng_scad>=eng_fur) //daca inamicul/personajul mai are cantitatea de energie care poate fi furata de abilitate
            {
                if (eng_c + eng_fur >= eng_max) eng_c = eng_max; //energia furata+energia personajului nu pot depasi energia sa maxima
                else if (eng_c + eng_fur < eng_max) eng_c = eng_c+eng_fur;
            }
            else if (eng_scad < eng_fur) //daca inamicul/personajul mai are cantitatea de energie care poate fi furata de abilitate se ia ce ramane
            {
                if (eng_c + eng_scad >= eng_max) eng_c = eng_max; //energia furata+energia personajului nu pot depasi energia sa maxima
                else if (eng_c + eng_scad < eng_max) eng_c = eng_c+eng_fur;
            }
            return eng_c;
        }

        public static int Scad_energie(int eng_c, int eng_scad) //eng_c este energia curenta a inamicului,eng scad reprezinta cantitatea de energie care se scade
        {
            if (eng_scad>=eng_c) eng_c = 0; //daca inamicul nu mai are atata energie cat se scade
            if (eng_scad<eng_c) eng_c = eng_c-eng_scad;

            return eng_c;
        }

        public static void Inamicul_e_incalcit(int tura) //verific care inamici sunt incalciti de abilitatea "Iederă agăţătoare"
        {
            int x = 0; int y = 0; //coordonatele pozei pt incalcire
            if (tura == tura_fol_iedera+1)
            {
                if (i1_incalcit == 1 && Lupta.vc_i1 > 0) Lupta.vc_i1 = Lupta.vc_i1 - 5; //scadem 5 puncte de energie din viata inamicului afectat de "Iedera agatatoare"
                else if (i2_incalcit == 1 && Lupta.vc_i2 > 0) Lupta.vc_i2 = Lupta.vc_i2 - 5;
                else if (i3_incalcit == 1 && Lupta.vc_i3 > 0) Lupta.vc_i3 = Lupta.vc_i3 - 5;
                //se vede ce inamic este incalcit pt a i se extrage 5 energie si cine a folosit "Iedera agatatoare",pentru a i se da energia
                if (p1_fur == 1 && i1_incalcit == 1)
                {
                    Lupta.ec_p1 = Efecte_ofensive.Fur_energie(Lupta.emax_p1, Lupta.ec_p1, Lupta.ec_i1, 5); //Fur 5 puncte de energie de la inamicul afectat
                    Lupta.ec_i1 = Efecte_ofensive.Scad_energie(Lupta.ec_i1, 5); //Scad energia inamicului 1
                }
                else if (p1_fur == 1 && i2_incalcit == 1)
                {
                    Lupta.ec_p1 = Efecte_ofensive.Fur_energie(Lupta.emax_p1, Lupta.ec_p1, Lupta.ec_i2, 5);
                    Lupta.ec_i2 = Efecte_ofensive.Scad_energie(Lupta.ec_i2, 5); //Scad energia inamicului 2
                }
                else if (p1_fur == 1 && i3_incalcit == 1)
                {
                    Lupta.ec_p1 = Efecte_ofensive.Fur_energie(Lupta.emax_p1, Lupta.ec_p1, Lupta.ec_i3, 5);
                    Lupta.ec_i3 = Efecte_ofensive.Scad_energie(Lupta.ec_i3, 5); //Scad energia inamicului 3
                }
                else if (p2_fur == 1 && i1_incalcit == 1)
                {
                    Lupta.ec_p2 = Efecte_ofensive.Fur_energie(Lupta.emax_p2, Lupta.ec_p2, Lupta.ec_i1, 5); //Fur 5 puncte de energie de la inamicul afectat
                    Lupta.ec_i1 = Efecte_ofensive.Scad_energie(Lupta.ec_i1, 5); //Scad energia inamicului 1
                }
                else if (p2_fur == 1 && i2_incalcit == 1)
                {
                    Lupta.ec_p2 = Efecte_ofensive.Fur_energie(Lupta.emax_p2, Lupta.ec_p2, Lupta.ec_i2, 5);
                    Lupta.ec_i2 = Efecte_ofensive.Scad_energie(Lupta.ec_i2, 5); //Scad energia inamicului 2
                }
                else if (p2_fur == 1 && i3_incalcit == 1)
                {
                    Lupta.ec_p2 = Efecte_ofensive.Fur_energie(Lupta.emax_p2, Lupta.ec_p2, Lupta.ec_i3, 5);
                    Lupta.ec_i3 = Efecte_ofensive.Scad_energie(Lupta.ec_i3, 5); //Scad energia inamicului 3
                }
                else if (p3_fur == 1 && i1_incalcit == 1)
                {
                    Lupta.ec_p3 = Efecte_ofensive.Fur_energie(Lupta.emax_p3, Lupta.ec_p3, Lupta.ec_i1, 5); //Fur 5 puncte de energie de la inamicul afectat
                    Lupta.ec_i1 = Efecte_ofensive.Scad_energie(Lupta.ec_i1, 5); //Scad energia inamicului 1
                }
                else if (p3_fur == 1 && i2_incalcit == 1)
                {
                    Lupta.ec_p3 = Efecte_ofensive.Fur_energie(Lupta.emax_p3, Lupta.ec_p3, Lupta.ec_i2, 5);
                    Lupta.ec_i2 = Efecte_ofensive.Scad_energie(Lupta.ec_i2, 5); //Scad energia inamicului 2
                }
                else if (p3_fur == 1 && i3_incalcit == 1)
                {
                    Lupta.ec_p3 = Efecte_ofensive.Fur_energie(Lupta.emax_p3, Lupta.ec_p3, Lupta.ec_i3, 5);
                    Lupta.ec_i3 = Efecte_ofensive.Scad_energie(Lupta.ec_i3, 5); //Scad energia inamicului 3
                }
            }

            if (tura == tura_fol_iedera) //daca nu pun x!=0 si y!=0 la a doua tura apare o poza cu iedera in coltul stanga sus (nu stiu de ce)
            {
                if (i1_incalcit == 1 && Lupta.vc_i1 > 0)
                {
                    x = 929; y = 151;
                }
                else if (i2_incalcit == 1 && Lupta.vc_i2 > 0)
                {
                    x = 929; y = 320;
                }
                else if (i3_incalcit == 1 && Lupta.vc_i3 > 0)
                {
                    x = 929; y = 493;
                }

                PictureBox poza_iedera = new PictureBox { };
                poza_iedera.Name = "Iedera";
                poza_iedera.Size = new Size(38, 38);
                poza_iedera.Location = new Point(x, y);
                poza_iedera.Image = Image.FromFile("Abilitati\\Vrajitor\\Iedera.jpg");
                poza_iedera.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_iedere.Add(poza_iedera);
                ToolTip desc = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                desc.SetToolTip(poza_iedera, "Inamicul e încâlcit \n nu poate acţiona şi va pierde \n 5 puncte de viaţă şi energie");

                string cooldown = "1";

                PointF locatie = new PointF(0, -100);

                using (Graphics graphics = Graphics.FromImage(poza_iedera.Image))
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(cooldown, blackadderFont, Brushes.Black, locatie);
                    }
                }
            }

            if (tura == tura_fol_iedera + 1)
            {
                i1_incalcit = 0; i2_incalcit = 0; i3_incalcit = 0; //dupa 2 ture au trecut efectele incalcelii
                Lupta.paraliz_i1 = 0; Lupta.paraliz_i2 = 0; Lupta.paraliz_i3 = 0; //dupa 2 ture inamicul nu mai e paralizat
                p1_fur = 0; p2_fur = 0; p3_fur = 0;
            }

            if ((Lupta.vc_i1 <= 0 && i1_incalcit == 1) || (Lupta.vc_i2 <= 0 && i1_incalcit == 1) || (Lupta.vc_i3 <= 0 && i1_incalcit == 1)) //eliminam efectele de incalceala daca inamicul a ajuns la 0 viaţă
            {
                Lupta.paraliz_i1 = 0; Lupta.paraliz_i2 = 0; Lupta.paraliz_i3 = 0; //daca inamicul moare nu mai e paralizat
            }

            if (reincarca_iedera_p1 != 0) reincarca_iedera_p1 = reincarca_iedera_p1 - 1;
            if (reincarca_iedera_p2 != 0) reincarca_iedera_p2 = reincarca_iedera_p2 - 1;
            if (reincarca_iedera_p3 != 0) reincarca_iedera_p3 = reincarca_iedera_p3 - 1;
        }

        //Abilitatile ofensive comune ale claselor "Tămăduitor"+"Vrăjitor"

        public static int Lovitura_toiag(int viata, int dmg, int plus, int minus) //viata reprezinta viata inamicului afectat,dmg reprezinta punctele de viata care se scad din viata inamicului
        {
            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;
            viata = viata - dmg;
            return viata;
        }

        //Abilitatile ofensive ale inamicului "Lup"

        public static int Muscatura(int pers,int viata, int dmg,int plus,int minus,int scut, int x, int y) //pers reprezinta personajul muscat,viata reprezinta viata personajului afectat,dmg reprezinta punctele de viata care se scad din viata personajului,scut reprezinta punctele de protectie pe care le are personajul la dispozitie
        {                                                         //x si y reprezinta coordonatele la care va fi inserata poza cu efectul de sangerare
            provoaca_rana=0;

            if ((dmg + plus - minus) >= 0) dmg = dmg + plus - minus; //verific daca personajul nu da damage negativ din cauza efectelor de penalizare (altfel atacul vindeca si ar fi cam ciudat)
            else dmg = 0;

            if ((dmg - scut) <= 0)
            {
                viata = viata + 0; //daca damage-ul nu e mai mare decat scutul
                scut = scut-dmg;
                if (pers == 1) Lupta.reduc_mem_p1 = scut;
                else if (pers == 2) Lupta.reduc_mem_p2 = scut;
                else if (pers == 3) Lupta.reduc_mem_p3 = scut;
            }
            else if ((dmg - scut) > 0)
            {
                viata = (viata+scut)-dmg;
                if (pers == 1) Lupta.reduc_mem_p1 =0;
                else if (pers == 2) Lupta.reduc_mem_p2 =0;
                else if (pers == 3) Lupta.reduc_mem_p3 =0;
                if (pers==1 && Efecte_defensive.p1_regen==0) provoaca_rana = 1; //atacul provoaca o rana doar daca personajul nu se afla sub efectul "Regenerare"
                else if (pers == 2 && Efecte_defensive.p2_regen == 0) provoaca_rana = 1; //atacul provoaca o rana doar daca personajul nu se afla sub efectul "Regenerare"
                else if (pers == 3 && Efecte_defensive.p3_regen == 0) provoaca_rana = 1; //atacul provoaca o rana doar daca personajul nu se afla sub efectul "Regenerare"

                if (viata > 0 && provoaca_rana==1) //daca personajul nu moare in urma muscaturii si nu e sub efectul "Regenerare" pun poza cu sangerarea
                {
                    ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                    PictureBox poza_sangerare = new PictureBox {};
                    poza_sangerare.Name = "Sangerare";
                    poza_sangerare.Size = new Size(38, 38);
                    poza_sangerare.Location = new Point(x, y);
                    poza_sangerare.Image = Image.FromFile("Abilitati\\Lup\\sangerare.jpg");
                    poza_sangerare.SizeMode = PictureBoxSizeMode.StretchImage;
                    descriere.SetToolTip(poza_sangerare, "Acest personaj sângerează \n şi va pierde 5 puncte de viaţă");

                    string durata = "∞";

                    PointF locatie = new PointF(-40, -100);

                    using (Graphics graphics = Graphics.FromImage(poza_sangerare.Image))
                    {
                        using (Font blackadderFont = new Font("Blackadder ITC", 120))
                        {
                            graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                        }
                    }
                   poze_sangerare.Add(poza_sangerare);
                }
                turn_fol_muscatura = Lupta.nr_tura; //memoram tura cand a fost folosita muscatura
            }
            return viata;
        }

        public static void Personajul_sangerezaza() //verific care personaje sangereaza
        {
            if (p1_sang == 1 && Lupta.vc_p1>0) Lupta.vc_p1 = Lupta.vc_p1 - 5;
            if (p2_sang == 1 && Lupta.vc_p2>0) Lupta.vc_p2 = Lupta.vc_p2 - 5;
            if (p3_sang == 1 && Lupta.vc_p3>0) Lupta.vc_p3 = Lupta.vc_p3 - 5;

            //if (p1_sang == 1 && Lupta.vc_p1 <= 0) p1_sang = 0;
            //if (p2_sang == 1 && Lupta.vc_p2 <= 0) p2_sang = 0;
            //if (p3_sang == 1 && Lupta.vc_p2 <= 0) p3_sang = 0;
        }

        public static void Urlet_lup(int urlet_activat) //scade atacurile fizice ale tuturor personajelor cu 5 puncte
        {
            if (urlet_activat==1 && urlet_in_efect==0) //cazul:urletul se activeaza si nu e in efect in tura curenta
            {
                urlet_in_efect = 1;

                Lupta.atc_scad_p1_fiz = Lupta.atc_scad_p1_fiz + 5;
                Lupta.atc_scad_p2_fiz = Lupta.atc_scad_p2_fiz + 5;
                Lupta.atc_scad_p3_fiz = Lupta.atc_scad_p3_fiz + 5;

                PictureBox poza_urlet1 = new PictureBox { }; PictureBox poza_urlet2 = new PictureBox { }; PictureBox poza_urlet3 = new PictureBox { };
                poza_urlet1.Name = "Urlet lup"; poza_urlet1.Size = new Size(38, 38); poza_urlet1.Location = new Point(155, 151); poza_urlet1.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet1.SizeMode = PictureBoxSizeMode.StretchImage;
                poza_urlet2.Name = "Urlet lup"; poza_urlet2.Size = new Size(38, 38); poza_urlet2.Location = new Point(155, 320); poza_urlet2.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet2.SizeMode = PictureBoxSizeMode.StretchImage;
                poza_urlet3.Name = "Urlet lup"; poza_urlet3.Size = new Size(38, 38); poza_urlet3.Location = new Point(155, 493); poza_urlet3.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet3.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_urlete.Add(poza_urlet1); poze_urlete.Add(poza_urlet2); poze_urlete.Add(poza_urlet3);
            }

            if (urlet_activat == 1 && urlet_in_efect == 1) //cazul:urletul se activeaza si e in efect in tura curenta
            {
                urlet_in_efect = 1; urlet_act = 1;

                Lupta.atc_scad_p1_fiz = Lupta.atc_scad_p1_fiz - 5; //elimin efectele urletului din tura curenta
                Lupta.atc_scad_p2_fiz = Lupta.atc_scad_p2_fiz - 5;
                Lupta.atc_scad_p3_fiz = Lupta.atc_scad_p3_fiz - 5;

                Lupta.atc_scad_p1_fiz = Lupta.atc_scad_p1_fiz + 5; //adaug efectele unui nou urlet
                Lupta.atc_scad_p2_fiz = Lupta.atc_scad_p2_fiz + 5;
                Lupta.atc_scad_p3_fiz = Lupta.atc_scad_p3_fiz + 5;

                PictureBox poza_urlet1 = new PictureBox { }; PictureBox poza_urlet2 = new PictureBox { }; PictureBox poza_urlet3 = new PictureBox { };
                poza_urlet1.Name = "Urlet lup"; poza_urlet1.Size = new Size(38, 38); poza_urlet1.Location = new Point(155, 151); poza_urlet1.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet1.SizeMode = PictureBoxSizeMode.StretchImage;
                poza_urlet2.Name = "Urlet lup"; poza_urlet2.Size = new Size(38, 38); poza_urlet2.Location = new Point(155, 320); poza_urlet2.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet2.SizeMode = PictureBoxSizeMode.StretchImage;
                poza_urlet3.Name = "Urlet lup"; poza_urlet3.Size = new Size(38, 38); poza_urlet3.Location = new Point(155, 493); poza_urlet3.Image = Image.FromFile("Abilitati\\Lup\\urlet.jpg"); poza_urlet3.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_urlete.Add(poza_urlet1); poze_urlete.Add(poza_urlet2); poze_urlete.Add(poza_urlet3);

                foreach (PictureBox p in poze_urlete)
                {
                    ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                    descriere.SetToolTip(p, "Daunele fizice pe care le \n provoaca acest personaj \n sunt reduse cu 5 puncte");
                }
            }

            if (urlet_activat == 0 && urlet_in_efect == 1) //cazul:urletul nu se activeaza si e in efect in tura curenta
            {
                urlet_in_efect = 0; urlet_act = 0;

                Lupta.atc_scad_p1_fiz = Lupta.atc_scad_p1_fiz - 5; //elimin efectele urletului din tura curenta
                Lupta.atc_scad_p2_fiz = Lupta.atc_scad_p2_fiz - 5;
                Lupta.atc_scad_p3_fiz = Lupta.atc_scad_p3_fiz - 5;
            }
        }

        public static int Consum_Abilitate_of(int energie, int consum) //consuma puncte din energia personajului/inamicului pentru a folosi o abilitate
        {
            if (energie >= consum) energie = energie - consum;
            return energie;
        }
    }
}
