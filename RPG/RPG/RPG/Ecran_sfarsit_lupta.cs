using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class Ecran_sfarsit_lupta : Form
    {
        public static int victorie,infrangere; //variabila care va fi 1 daca lupta a fost castigata sau 0 daca a fost pierduta
        public static Form lupta_codru = Application.OpenForms[4]; //Avem deschis form-ul 0 (RPG) si 4 (Lupta)

        public Ecran_sfarsit_lupta(string r,string b1,string b2) //text-ul label-ului si a butoanelor se vor schimba functie de rezultatul luptei
        {
            InitializeComponent();
            rezultat_lupta.Text = r;
            restart_lupta.Text = b1;
            buton_meniu_p.Text = b2;
        }

        private void restart_lupta_Click(object sender, EventArgs e) //butonul de sus va fi "Înapoi la harta" daca e victorie sau "Încearca din nou" daca e o infrangere
        {
            if (victorie == 1)
            {
                Sterg_luptele();

                Lupta.Resetez_timpi_abilitati(); //restez toti timpii de reincarcare la startul unei noi lupte

                if (Lupta.vc_p1 <= 0) DB_Update.Update_Lupta(Lupta.cod_pers1, 1, Lupta.ec_p1, 15); //daca personajul a ajuns la 0 viata in lupta anterioara va primi 1 punct viata pentru lupta urmatoare
                else DB_Update.Update_Lupta(Lupta.cod_pers1, Lupta.vc_p1, Lupta.ec_p1, 15); //scad viata si energia consumate dupa o lupta victorioasa

                if (Lupta.vc_p2 <= 0) DB_Update.Update_Lupta(Lupta.cod_pers2, 1, Lupta.ec_p2, 15);
                else DB_Update.Update_Lupta(Lupta.cod_pers2, Lupta.vc_p2, Lupta.ec_p2, 15); //daca personajul a ajuns la 0 viata in lupta anterioara va primi 1 viata pentru lupta urmatoare

                if (Lupta.vc_p3 <= 0) DB_Update.Update_Lupta(Lupta.cod_pers3, 1, Lupta.ec_p3, 15);
                else DB_Update.Update_Lupta(Lupta.cod_pers3, Lupta.vc_p3, Lupta.ec_p3, 15); //daca personajul a ajuns la 0 viata in lupta anterioara va primi 1 viata pentru lupta urmatoare

                this.Close();
            }
            if (infrangere==1)
            {
                //Sterg_luptele(); //inchid ecranele de lupta
                Resetez_sangerarile(); //resetez ranile cum erau la inceputul luptei
                Lupta.vc_p1 = Lupta.vc_p1_init; Lupta.vc_p2 = Lupta.vc_p2_init; Lupta.vc_p3 = Lupta.vc_p3_init;
                Lupta.ec_p1 = Lupta.ec_p1_init; Lupta.ec_p2 = Lupta.ec_p2_init; Lupta.ec_p3 = Lupta.ec_p3_init;
                this.Close(); //inchid ecranul de reincercare
            //    Lupta lupt = new Lupta();
            //    lupt.Name = "lupt";
            //    lupt.ShowDialog();
            }
        }

        public void Sterg_luptele()
        {
            int nr_form = Application.OpenForms.Count - 1;
            Application.OpenForms[nr_form - 1].Close();
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "lupt" || Application.OpenForms[i].Name == "concluzie" || Application.OpenForms[i].Name == "lupt2") Application.OpenForms[i].Close();
                if (i>=4) Application.OpenForms[i].Close();
            }

        }

        public void Resetez_sangerarile() //resetez ranile la starea de la inceputul luptei
        {
            if (Lupta.p1_sangera == 0)
            {
                Efecte_ofensive.p1_sang = 0;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 151) p.Image=null; //elimin pozele de sangerare daca personajul 1 nu era ranit la inceputul luptei ca sa nu apara poza de sangerare aiurea
            }
            else Efecte_ofensive.p1_sang = 1;

            if (Lupta.p2_sangera == 0)
            {
                Efecte_ofensive.p1_sang = 0;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 320) p.Image = null; //elimin pozele de sangerare daca personajul 2 nu era ranit la inceputul luptei ca sa nu apara poza de sangerare aiurea
            }
            else Efecte_ofensive.p2_sang = 1;

            if (Lupta.p3_sangera == 0)
            {
                Efecte_ofensive.p3_sang = 0;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 493) p.Image = null; //elimin pozele de sangerare daca personajul 3 nu era ranit la inceputul luptei ca sa nu apara poza de sangerare aiurea
            }
            else Efecte_ofensive.p3_sang = 1;
        }

        private void buton_meniu_p_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (i!=0) Application.OpenForms[i].Close(); //inchiden toate form-urile in afara de form-ul 0 (cel cu meniul)
            }
        }
    }
}
