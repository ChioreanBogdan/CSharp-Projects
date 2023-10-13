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
    class Efecte_defensive
    {
        public static int tura_fol_strigat,tura_fol_regen,tura_fol_vindecare_mas; //verific daca abilitatea e in efect (1) sau nu (0)
        public static int reincarca_strigat_p1 = 0; public static int reincarca_strigat_p2 = 0; public static int reincarca_strigat_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca strigatul sa se reincarce
        public static int reincarca_regen_p1 = 0; public static int reincarca_regen_p2 = 0; public static int reincarca_regen_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca regenerarea sa se reincarce
        public static int reincarca_vind_mas_p1 = 0; public static int reincarca_vind_mas_p2 = 0; public static int reincarca_vind_mas_p3 = 0;//Variabila masoara cate ture trebuie sa treaca pt ca vindecarea in masa sa se reincarce

        public static PictureBox poza_scut = new PictureBox { }; //poza cu scut ce apare in dreptul personajului aparat
        public static List<PictureBox> poze_strigate = new List<PictureBox>(); //poza cu strigate ce apare in dreptul personajului afectat
        public static List<PictureBox> poze_regenerari = new List<PictureBox>(); //poze ce apar in dreptul personajului afectat de "Regenerare"

        public static Form lup = Application.OpenForms["lupt"]; //Avem deschis form-ul 0 (RPG) si 1 (Lupta),deci inseram o poza in OpenForms[1]

        public static int scut_act_p1=0; public static int scut_act_p2=0; public static int scut_act_p3=0; //verific daca scutul a fost activat tura precedenta la personajul 1,2 si 3 (1) sau nu (0)
        public static int p1_regen = 0; public static int p2_regen = 0; public static int p3_regen = 0; //variabila care devine 1 in functie de care inamici sangereaza

        //Abilitatile defensive ale Războinicului

        public static int Aparare_scut(int scut,int prot,int pers) //pers:persoana care e scutita,scut-punctele de scut a persoanei respective
        {
            if (pers == 1) //scutul apara personajul din slot-ul 1
            {
                poza_scut.Name = "Aparare_scut"; poza_scut.Size = new Size(38, 38); poza_scut.Location = new Point(235, 151); poza_scut.Image = Image.FromFile("Abilitati\\Razboinic\\Aparare_scut.jpg"); poza_scut.SizeMode = PictureBoxSizeMode.StretchImage;
                scut_act_p1 = 1;
                scut = scut + prot;
            }

            else if (pers == 2) //scutul apara personajul din slot-ul 2
            {
                poza_scut.Name = "Aparare_scut"; poza_scut.Size = new Size(38, 38); poza_scut.Location = new Point(235, 320); poza_scut.Image = Image.FromFile("Abilitati\\Razboinic\\Aparare_scut.jpg"); poza_scut.SizeMode = PictureBoxSizeMode.StretchImage;
                scut_act_p2 = 1;
                scut = scut + 20;
            }

            else if (pers == 3) //scutul apara personajul din slot-ul 3
            {
                poza_scut.Name = "Aparare_scut"; poza_scut.Size = new Size(38, 38); poza_scut.Location = new Point(235, 493); poza_scut.Image = Image.FromFile("Abilitati\\Razboinic\\Aparare_scut.jpg"); poza_scut.SizeMode = PictureBoxSizeMode.StretchImage;
                scut_act_p3 = 1;
                scut = scut + 20;
            }
                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                descriere.SetToolTip(poza_scut, "Daunele suferite de acest personaj \n sunt reduse cu 20 de puncte");

            return scut;
        }

        public static void Sterg_scutirile_anterioare(int prot) //elimin pozele si punctele de scut de la abilitatea "Aparare_scut"  scut folosita anterior ca sa nu se deterioreze
        {
            if (scut_act_p1 == 1)
            {
                Lupta.reduc_p1 = Lupta.reduc_p1 - prot;
                scut_act_p1 = 0;
            }
            else if (scut_act_p2 == 1)
            {
                Lupta.reduc_p2 = Lupta.reduc_p2 - prot;
                scut_act_p2 = 0;
            }
            else if (scut_act_p3 == 1)
            {
                Lupta.reduc_p3 = Lupta.reduc_p3 - prot;
                scut_act_p3 = 0;
            }
        }

        public static void Strigat_lupta() //creste atacurile fizice ale tuturor personajelor cu 5 puncte
        {
            Lupta.atc_cresc_p1_fiz = Lupta.atc_cresc_p1_fiz + 5;
            Lupta.atc_cresc_p2_fiz = Lupta.atc_cresc_p2_fiz + 5;
            Lupta.atc_cresc_p3_fiz = Lupta.atc_cresc_p3_fiz + 5;

            ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
            PictureBox poza_strigat1 = new PictureBox {}; PictureBox poza_strigat2 = new PictureBox {}; PictureBox poza_strigat3 = new PictureBox {};
            poza_strigat1.Name = "Strigat lupta"; poza_strigat1.Size = new Size(38, 38); poza_strigat1.Location = new Point(195, 151); poza_strigat1.Image = Image.FromFile("Abilitati\\Razboinic\\Strigat_lupta.jpg"); poza_strigat1.SizeMode = PictureBoxSizeMode.StretchImage;
            poza_strigat2.Name = "Strigat lupta"; poza_strigat2.Size = new Size(38, 38); poza_strigat2.Location = new Point(195, 320); poza_strigat2.Image = Image.FromFile("Abilitati\\Razboinic\\Strigat_lupta.jpg"); poza_strigat2.SizeMode = PictureBoxSizeMode.StretchImage;
            poza_strigat3.Name = "Strigat lupta"; poza_strigat3.Size = new Size(38, 38); poza_strigat3.Location = new Point(195, 493); poza_strigat3.Image = Image.FromFile("Abilitati\\Razboinic\\Strigat_lupta.jpg"); poza_strigat3.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Lupta.vc_p1>0) poze_strigate.Add(poza_strigat1); if (Lupta.vc_p2>0) poze_strigate.Add(poza_strigat2); if (Lupta.vc_p3>0) poze_strigate.Add(poza_strigat3); //Adaug pozele strigatului de lupta doar daca personajul nu a ajuns cu punctele de viata la 0

            foreach (PictureBox p in poze_strigate) descriere.SetToolTip(p, "Atacurile fizice ale acestui \n personaj provoacă cu 5 \n puncte mai mult daune");

            tura_fol_strigat = Lupta.nr_tura; //memoram tura cand a fost folosit strigatul de lupta
        }

        public static void Strigatul_e_activat(int tura) //dezactivez strigatul in tura urmatoare folosirii lui
        {
            if (tura == tura_fol_strigat + 1 && tura_fol_strigat!=0)
            {
                if (Lupta.atc_cresc_p1_fiz>0) Lupta.atc_cresc_p1_fiz = Lupta.atc_cresc_p1_fiz-5;
                if (Lupta.atc_cresc_p2_fiz>0) Lupta.atc_cresc_p2_fiz = Lupta.atc_cresc_p2_fiz-5;
                if (Lupta.atc_cresc_p3_fiz>0) Lupta.atc_cresc_p3_fiz = Lupta.atc_cresc_p3_fiz-5;
                foreach (PictureBox p in poze_strigate)
                {
                    lup.Controls.Remove(p);
                }
            }
            if (reincarca_strigat_p1 != 0) reincarca_strigat_p1 = reincarca_strigat_p1 - 1;
            if (reincarca_strigat_p2 != 0) reincarca_strigat_p2 = reincarca_strigat_p2 - 1;
            if (reincarca_strigat_p3 != 0) reincarca_strigat_p3 = reincarca_strigat_p3 - 1;
        }

        //Abilitatile defensive ale clasei "Tămăduitor"

        public static int Vindeca(int viata, int viata_max, int heal) //viata reprezinta viata alitatului/personajului iar heal cu cate puncte se vindeca,viata nu poate creste mai mult decat viata maxima a personajului
        {
            viata = viata + heal;
            if (viata > viata_max) viata = viata_max; //verificam ca prin vindecare viata maxima a personajului sa nu depaseasca viata maxima a personajului
            return viata;
        }

        public static int Regenerare(int pers,int viata, int viata_max, int heal,int x,int y,int tur) //pers=nr personajului afectat,x si y reprezinta coordonatele pozei cu regenerarea.tur=numarul de ture cat e activa regenerarea
        {
            if (pers == 1) {
                Efecte_ofensive.p1_sang = 0; //opresc sangerarea personajului 1
                p1_regen = 1;
                           }
            else if (pers == 2)
            {
                Efecte_ofensive.p2_sang = 0; //opresc sangerarea personajului 2
                p2_regen = 1;
            }
            else if (pers == 3)
            {
                Efecte_ofensive.p3_sang = 0; //opresc sangerarea personajului 3
                p3_regen = 1;
            }

            ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza
            PictureBox poza_regen = new PictureBox { };
            poza_regen.Name = "Regenerare";
            poza_regen.Size = new Size(38, 38);
            poza_regen.Location = new Point(x, y);
            poza_regen.Image = Image.FromFile("Abilitati\\Tamaduitor\\Regenerare.jpg");
            descriere.SetToolTip(poza_regen, "Sângerările acestui personaj vor dispărea \n şi acesta se va vindeca câte 5 puncte \n în fiecare tură");

            poza_regen.SizeMode = PictureBoxSizeMode.StretchImage;

            string durata = "" + tur + ""; //durata efectului de regenerare

            PointF locatie = new PointF(0, -110); //afiseaza cate ture mai dureaza efectul

            using (Graphics graphics = Graphics.FromImage(poza_regen.Image))
            {
                using (Font blackadderFont = new Font("Blackadder ITC", 120))
                {
                    graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                }
            }

            poze_regenerari.Add(poza_regen);

            viata = viata + heal;
            if (viata > viata_max) viata = viata_max; //verificam ca prin vindecare viata maxima a personajului sa nu depaseasca viata maxima a personajului

            tura_fol_regen = Lupta.nr_tura;
            return viata;
        }

        public static void Personaj_regen(int tura) //verific care personaje se regenereaza
        {
            int x=0; int y=0;

            if ((tura >= tura_fol_regen) && (tura < tura_fol_regen + 2))
            {
                if (p1_regen == 1 && Lupta.vc_p1 > 0)
                {
                    if (Lupta.vc_p1 + 5 <= Lupta.vmax_p1) Lupta.vc_p1 = Lupta.vc_p1 + 5;
                    else Lupta.vc_p1 = Lupta.vmax_p1; //ne asiguram ca viata vindecata nu depaseste viata maxima a personajului
                    x = 115; y = 151;
                }
                if (p2_regen == 1 && Lupta.vc_p2 > 0)
                {
                    if (Lupta.vc_p2 + 5 <= Lupta.vmax_p2) Lupta.vc_p2 = Lupta.vc_p2 + 5;
                    else Lupta.vc_p2 = Lupta.vmax_p2; //ne asiguram ca viata vindecata nu depaseste viata maxima a personajului
                    x = 115; y = 320;
                }
                if (p3_regen == 1 && Lupta.vc_p3 > 0)
                {
                    if (Lupta.vc_p3 + 5 <= Lupta.vmax_p3) Lupta.vc_p3 = Lupta.vc_p3 + 5;
                    else Lupta.vc_p3 = Lupta.vmax_p3; //ne asiguram ca viata vindecata nu depaseste viata maxima a personajului
                    x = 115; y = 493;
                }
            }

            if ((tura >= tura_fol_regen) && (tura < tura_fol_regen + 1) && (x != 0 && y != 0)) //daca nu pun x!=0 si y!=0 la a doua tura apare o poza cu regenerarea in coltul stanga sus (nu stiu de ce)
            {
                PictureBox poza_regen = new PictureBox { };
                poza_regen.Name = "Regenerare";
                poza_regen.Size = new Size(38, 38);
                poza_regen.Location = new Point(x, y);
                poza_regen.Image = Image.FromFile("Abilitati\\Tamaduitor\\Regenerare.jpg");
                poza_regen.SizeMode = PictureBoxSizeMode.StretchImage;

                poze_regenerari.Add(poza_regen);
                ToolTip desc = new ToolTip(); //descrierea ce apare cand facem hover peste poza
                desc.SetToolTip(poza_regen, "Rănile personajului se vor închide \n şi acesta se va vindeca câte 5 puncte \n în fiecare tură");

                string durata = ""+((tura_fol_regen+1)-tura)+"";

                PointF locatie = new PointF(0, -110); //afiseaza cate ture mai dureaza efectul

                using (Graphics graphics = Graphics.FromImage(poza_regen.Image))
                {
                    using (Font blackadderFont = new Font("Blackadder ITC", 120))
                    {
                        graphics.DrawString(durata, blackadderFont, Brushes.Black, locatie);
                    }
                }
            }

            if (tura == tura_fol_regen + 2)
            {
                if (p1_regen == 1) p1_regen = 0;
                else if (p2_regen == 1) p2_regen = 0;
                else if (p3_regen == 1) p3_regen = 0;
            }

            if (reincarca_regen_p1 != 0) reincarca_regen_p1 = reincarca_regen_p1 - 1;
            if (reincarca_regen_p2 != 0) reincarca_regen_p2 = reincarca_regen_p2 - 1;
            if (reincarca_regen_p3 != 0) reincarca_regen_p3 = reincarca_regen_p3 - 1;
        }

        public static int Vindecare_mas(int viata,int viata_max) //viata maxima si viata curenta a celor 3 personaje
        {
            if (viata >= 0)
            {
                if (viata + 15 > viata_max) viata = viata_max;
                else if (viata + 15 <= viata_max) viata = viata + 15;
            }
            tura_fol_vindecare_mas = Lupta.nr_tura; //memorez tura in care a fost folosita vindecarea de masa
            return viata;
        }

        public static void Reincarc_vindecare_mas()
        {
            if (reincarca_vind_mas_p1 != 0) reincarca_vind_mas_p1 = reincarca_vind_mas_p1 - 1;
            if (reincarca_vind_mas_p2 != 0) reincarca_vind_mas_p2 = reincarca_vind_mas_p2 - 1;
            if (reincarca_vind_mas_p3 != 0) reincarca_vind_mas_p3 = reincarca_vind_mas_p3 - 1;
        }

        public static int Consum_Abilitate_def(int energie,int consum) //consuma puncte din energia personajului pentru a folosi o abilitate
        {
            if (energie >= consum) energie = energie - consum;
            return energie;
        }
    }
}
