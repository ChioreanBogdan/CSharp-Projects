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
    public partial class Creare_personaje : Form
    {
        public int mem_cp1, mem_cp2, mem_cp3; //memoreaza id-ul clasei celor 3 personaje
        public int mem_pp1, mem_pp2, mem_pp3; //memoreaza portretele celor 3 personaje
        public int nrr_clas=DB_Interogari.Descarc_Clasele().Rows.Count; //memoreaza numarul de randuri din tabela "clasa" din BD
        public static int nrr_portr = DB_Interogari.Descarc_Portretele().Rows.Count; //memoreaza numarul de randuri din tabela "portet" din BD
        public string[] nume_rand = { "Aegnor", "Aerin", "Amras", "Amrod", "Beleg", "Beren", "Gothmog", "Gundor", "Osse", "Hareth", "Urthel","Uinen","Feanor","Iorlas","Elatan","Azghal" }; //O lista cu nume la intamplare

        public Creare_personaje()
        {
            InitializeComponent();
            Incarc_img_clase();
            Incarc_portrete();
            this.WindowState = FormWindowState.Maximized; //Intind fereastra cat permite ecranul
        }

        public void Incarc_portrete() //incarc un portret la intamplare din baza de date
        {
            Random rnd = new Random();
            int portr1 = rnd.Next(0, nrr_portr-1);
            int portr2,portr3;

            do
            {
                portr2 = rnd.Next(0, nrr_portr - 1);
            } while (portr2 == portr1); //vrem sa avem 3 portrete unice

            do
            {
                portr3 = rnd.Next(0, nrr_portr - 1);
            } while (portr3 == portr1 || portr3 == portr2); //vrem sa avem 3 portrete unice

            DataRow rp1 = DB_Interogari.Descarc_Portretele().Rows[portr1]; //alegem un portret la intamplare
            poz_pers1.Image = Image.FromFile("Portrete\\" + rp1["adr_poza"].ToString());
            this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_pp1 = Convert.ToInt32(rp1["cod_portret"]);

            DataRow rp2 = DB_Interogari.Descarc_Portretele().Rows[portr2]; //alegem un portret la intamplare
            poz_pers2.Image = Image.FromFile("Portrete\\" + rp2["adr_poza"].ToString());
            this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_pp2 = Convert.ToInt32(rp2["cod_portret"]);

            DataRow rp3 = DB_Interogari.Descarc_Portretele().Rows[portr3]; //alegem un portret la intamplare
            poz_pers3.Image = Image.FromFile("Portrete\\" + rp3["adr_poza"].ToString());
            this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_pp3 = Convert.ToInt32(rp3["cod_portret"]);
        }

        public void Incarc_img_clase() //iau numele,descrierea,codul si adresa imaginilor claselor
        {
            int[] clas_cod = new int[4];
            string[] clas_img = new string[4]; //Deocamdata am doar 4 clase
            string[] clas_num = new string[4];
            string[] nume = new string[4];

            int i = 0;

            foreach (DataRow f in DB_Interogari.Descarc_Clasele().Rows)
            {
                clas_cod[i] = Convert.ToInt32(f["cod_clasa"]);
                clas_num[i] = f["nume"].ToString();
                clas_img[i] = f["adr_poza"].ToString();

                if (clas_cod[i] == 1) //Initial vom avea un razboinic(1),un tamaduitor(2) si un vrajitor(3)
                {
                    clas_pers1.Image = Image.FromFile("Clase\\" + clas_img[i]);
                    this.clas_pers1.SizeMode=PictureBoxSizeMode.StretchImage;
                    mem_cp1 = clas_cod[i];
                }

                if (clas_cod[i] == 3)
                {
                    clas_pers2.Image = Image.FromFile("Clase\\" + clas_img[i]);
                    this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                    mem_cp2 = clas_cod[i];
                }

                if (clas_cod[i] == 4)
                {
                    clas_pers3.Image = Image.FromFile("Clase\\" + clas_img[i]);
                    this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                    mem_cp3 = clas_cod[i];
                }
            }
        }

        private void rand_P1_Click(object sender, EventArgs e) //Butonul pentru a genera un portret la intamplare a Personajului 1
        {
            Audio_player.sunet_zar();
            int portr, verif;

            do
            {
                Random rnd = new Random();
                portr = rnd.Next(0, nrr_portr - 1);
                DataRow rpv = DB_Interogari.Descarc_Portretele().Rows[portr]; //resetam 
                verif = Convert.ToInt32(rpv["cod_portret"]);
            } while (verif == mem_pp1 || verif == mem_pp2 || verif == mem_pp3); //verificare pentru a nu obtine acelasi portret de doua ori la rand consecutiv

            DataRow rp = DB_Interogari.Descarc_Portretele().Rows[portr];
            poz_pers1.Image = Image.FromFile("Portrete\\" + rp["adr_poza"].ToString());
            this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_pp1 = Convert.ToInt32(rp["cod_portret"]);
        }

        private void anulez_Click(object sender, EventArgs e) //sageata ce anuleaza crearea personajelor si merge inapoi la meniul principal
        {
            string s = "Doriti anularea crearii personajelor?";
            Confirmare cf = new Confirmare(s);
            if (cf.ShowDialog()== DialogResult.Cancel) cf.Close();
            else if (cf.DialogResult == DialogResult.OK) this.Close();
        }

        private void ant_P1_Click(object sender, EventArgs e) //Sageata inapoi portretul personajului 1
        {
            Audio_player.sunet_click();
            do
            {
                for (int i = nrr_portr - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i];

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp1 && i != 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[i - 1]; //rand anterior
                        poz_pers1.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp1 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp1 && i == 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[nrr_portr - 1]; //resetam la ultimul rand
                        poz_pers1.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp1 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp1 == mem_pp2 || mem_pp1 == mem_pp3); //do while pt a nu avea 2 portrete identice
        }

        private void urm_P1_Click(object sender, EventArgs e) //Sageata inainte portretul personajului 1
        {
            Audio_player.sunet_click();

            do
            {
                for (int i = 0; i <= nrr_portr - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp1 && i != nrr_portr - 1)
                    {
                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[i + 1]; //randul urmator
                        poz_pers1.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp1 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp1 && i == nrr_portr - 1) //daca ajungem la ultimul portret
                    {
                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[0]; //resetam la primul rand
                        poz_pers1.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp1 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp1 == mem_pp2 || mem_pp1 == mem_pp3); //do while pt a nu avea 2 portrete identice
        }

        private void rand_N1_Click(object sender, EventArgs e) //Genereaza un nume la intamplare
        {
            Audio_player.sunet_zar();
            string num=numP1.Text;

            do
            {
                int index = new Random().Next(0, nume_rand.Count()); //generez un nume la intamplare din sirul nume_rand
                numP1.Text = nume_rand[index];
            } while (numP1.Text==num || numP1.Text== numP2.Text || numP1.Text == numP3.Text); //vrem sa avem 3 nume unice
        }

        private void ant_C1_Click(object sender, EventArgs e) //Sageata inapoi clasa personajului 1
        {
            Audio_player.sunet_click();
            do
            {
                for (int i = nrr_clas - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i];

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp1 && i != 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i - 1]; //rand anterior
                        clas_pers1.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp1 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp1 && i == 0)
                    {
                        i = nrr_clas - 1;
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i]; //resetam la ultimul rand
                        clas_pers1.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp1 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp1 == mem_cp2 || mem_cp1 == mem_cp3); //nu vrem sa avem 2-3 clase identice,altfel e problema cu sfera de foc,placarea,etc
         }

        private void urm_C1_Click(object sender, EventArgs e) //Sageata inainte clasa personajului 1
        {
            Audio_player.sunet_click();
            do
            {
                for (int i = 0; i <= nrr_clas - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp1 && i != nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i + 1]; //rand anterior
                        clas_pers1.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp1 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp1 && i == nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[0]; //resetam la primul rand
                        clas_pers1.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp1 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp1 == mem_cp2 || mem_cp1 == mem_cp3); //nu vrem sa avem 2-3 clase identice,altfel e problema cu sfera de foc,placarea,etc
        }

        private void rand_C1_Click(object sender, EventArgs e) //butonul pt a genera 3 clase la intamplare
        {
            Audio_player.sunet_zar();
            int c1,c2,c3, verif1,verif2,verif3;

            do
            {
                Random rnd = new Random();
                c1 =rnd.Next(0, nrr_clas - 1);
                c2 = rnd.Next(0, nrr_clas - 1);
                c3 = rnd.Next(0, nrr_clas - 1);
                DataRow rcv1 = DB_Interogari.Descarc_Clasele().Rows[c1]; DataRow rcv2 = DB_Interogari.Descarc_Clasele().Rows[c2]; DataRow rcv3 = DB_Interogari.Descarc_Clasele().Rows[c3]; //resetam 
                verif1 = Convert.ToInt32(rcv1["cod_clasa"]); verif2 = Convert.ToInt32(rcv2["cod_clasa"]); verif3 = Convert.ToInt32(rcv3["cod_clasa"]);
            } while (verif1 ==verif2 || verif2==verif3 || verif3==verif1); //verificare pentru a nu obtine aceeasi clasa de doua ori la rand

            DataRow rc1 = DB_Interogari.Descarc_Clasele().Rows[c1]; DataRow rc2 = DB_Interogari.Descarc_Clasele().Rows[c2]; DataRow rc3 = DB_Interogari.Descarc_Clasele().Rows[c3]; //resetam 
            clas_pers1.Image = Image.FromFile("Clase\\" + rc1["adr_poza"].ToString()); clas_pers2.Image = Image.FromFile("Clase\\" + rc2["adr_poza"].ToString()); clas_pers3.Image = Image.FromFile("Clase\\" + rc3["adr_poza"].ToString());
            this.clas_pers1.SizeMode = PictureBoxSizeMode.StretchImage; this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage; this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_cp1 = Convert.ToInt32(rc1["cod_clasa"]); mem_cp2 = Convert.ToInt32(rc2["cod_clasa"]); mem_cp3 = Convert.ToInt32(rc3["cod_clasa"]);
        }

        private void rand_P2_Click(object sender, EventArgs e) //Butonul pentru a genera un portret la intamplare a Personajului 2
        {
            Audio_player.sunet_zar();
            int portr, verif;

            do
            {
                Random rnd = new Random();
                portr = rnd.Next(0, nrr_portr - 1);
                DataRow rpv = DB_Interogari.Descarc_Portretele().Rows[portr]; //resetam 
                verif = Convert.ToInt32(rpv["cod_portret"]);
            } while (verif == mem_pp2 || verif== mem_pp1 || verif == mem_pp3); //verificare pentru a nu obtine acelasi portret de doua ori la rand consecutiv

                DataRow rp = DB_Interogari.Descarc_Portretele().Rows[portr];
                poz_pers2.Image = Image.FromFile("Portrete\\" + rp["adr_poza"].ToString());
                this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                mem_pp2 = Convert.ToInt32(rp["cod_portret"]);
        }

        private void ant_P2_Click(object sender, EventArgs e) //Sageata inapoi portretul personajului 2
        {
            Audio_player.sunet_click();
            do {
                for (int i = nrr_portr - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i];

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp2 && i != 0)
                    {
                        if (i == 2 && ((mem_pp3 == 1 && mem_pp1 == 2) || (mem_pp1 == 1 && mem_pp3 == 2))) i = nrr_portr; //if-urile astea sunt ca sa nu avem doua portrete identice a celor 3 personaje
                        else if (i == 1 && ((mem_pp2 == mem_pp1 + 1 || mem_pp2 == mem_pp3 + 1) && (mem_pp3 == nrr_portr || mem_pp1 == nrr_portr))) i = nrr_portr - 1;
                        else if (i == 1 && (mem_pp2 == mem_pp1 + 1 || mem_pp2 == mem_pp3 + 1)) i = nrr_portr;
                        else if ((mem_pp2 == mem_pp1 + 1 && mem_pp2 == mem_pp3 + 2) || (mem_pp2 == mem_pp1 + 2 && mem_pp2 == mem_pp3 + 1)) i = i - 2;
                        else if (mem_pp2 == mem_pp1 + 1 || mem_pp2 == mem_pp3 + 1) i = i - 1;

                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[i - 1]; //rand anterior
                        poz_pers2.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp2 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp2 && i == 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[nrr_portr - 1]; //resetam la ultimul rand
                        poz_pers2.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp2 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp2==mem_pp1 || mem_pp2==mem_pp3);
        }

        private void urm_P2_Click(object sender, EventArgs e) //Sageata inainte portretul personajului 2
        {
            Audio_player.sunet_click();
            do
            {
                for (int i = 0; i <= nrr_portr - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp2 && i != nrr_portr - 1)
                    {
                        if (i == nrr_portr - 3 && ((mem_pp2 == mem_pp1 - 1 && mem_pp2 == mem_pp3 - 2) || (mem_pp2 == mem_pp1 - 2 && mem_pp2 == mem_pp3 - 1))) i = -1; //if-urile astea sunt ca sa nu avem doua portrete identice a celor 3 personaje
                        else if (i == nrr_portr - 2 && ((mem_pp2 == mem_pp1 - 1 || mem_pp2 == mem_pp3 - 1) && (mem_pp3 == 1 || mem_pp2 == 1))) i = 0;
                        else if (i == nrr_portr - 2 && ((mem_pp2 == mem_pp1 - 1 || mem_pp2 == mem_pp3 - 1))) i = -1;
                        else if ((mem_pp2 == mem_pp1 - 1 && mem_pp2 == mem_pp3 - 2) || (mem_pp2 == mem_pp1 - 2 && mem_pp2 == mem_pp3 - 1)) i = i + 2;
                        else if (mem_pp2 == mem_pp1 - 1 || mem_pp2 == mem_pp3 - 1) i = i + 1;
                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[i + 1]; //randul urmator
                        poz_pers2.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp2 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp2 && i == nrr_portr - 1) //daca ajungem la ultimul portret
                    {
                        int j = 0;
                        if ((mem_pp1 == 1 || mem_pp3 == 1) && (mem_pp3 == 2 || mem_pp1 == 2)) j = 2;
                        else if (mem_pp1 == 1 || mem_pp3 == 1) j = 1;

                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[j]; //resetam la primul rand
                        poz_pers2.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp2 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp2 == mem_pp1 || mem_pp2 == mem_pp3);
        }

        private void rand_N2_Click(object sender, EventArgs e) //genereaza un nume la intamplare pentru personajul nr 2
        {
            Audio_player.sunet_zar();
            string num = numP2.Text;

            do
            {
                int index = new Random().Next(0, nume_rand.Count()); //generez un nume la intamplare din sirul nume_rand
                numP2.Text = nume_rand[index];
            } while (numP2.Text == num || numP2.Text == numP1.Text || numP2.Text == numP3.Text); //vrem sa avem 3 nume unice
        }

        private void ant_C2_Click(object sender, EventArgs e) //Sageata inapoi clasa personajului 2
        {
            Audio_player.sunet_click();
            do
            {
                for (int i = nrr_clas - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i];

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp2 && i != 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i - 1]; //rand anterior
                        clas_pers2.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp2 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp2 && i == 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[nrr_clas - 1]; //resetam la ultimul rand
                        clas_pers2.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp2 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp2 == mem_cp1 || mem_cp2 == mem_cp3);
        }

        private void urm_C2_Click(object sender, EventArgs e) //Sageata inainte clasa personajului 2
        {
            Audio_player.sunet_click();

            do
            {
                for (int i = 0; i <= nrr_clas - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp2 && i != nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i + 1]; //rand anterior
                        clas_pers2.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp2 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp2 && i == nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[0]; //resetam la primul rand
                        clas_pers2.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp2 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp2 == mem_cp1 || mem_cp2 == mem_cp3);
        }

        private void rand_P3_Click(object sender, EventArgs e) //genereaza un portret la intamplare pentru Personajul 3
        {
            Audio_player.sunet_zar();
            int portr, verif;

            do
            {
                Random rnd = new Random();
                portr = rnd.Next(0, nrr_portr - 1);
                DataRow rpv = DB_Interogari.Descarc_Portretele().Rows[portr]; //resetam 
                verif = Convert.ToInt32(rpv["cod_portret"]);
            } while (verif == mem_pp3 || verif == mem_pp1 || verif == mem_pp2); //verificare pentru a nu obtine acelasi portret de doua ori la rand consecutiv

            DataRow rp = DB_Interogari.Descarc_Portretele().Rows[portr];
            poz_pers3.Image = Image.FromFile("Portrete\\" + rp["adr_poza"].ToString());
            this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
            mem_pp3 = Convert.ToInt32(rp["cod_portret"]);
        }

        private void ant_P3_Click(object sender, EventArgs e) //sageata inapoi portretul personajului 3
        {
            Audio_player.sunet_click();
            do {
                for (int i = nrr_portr - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i];

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp3 && i != 0)
                    {
                        if (i == 2 && ((mem_pp2 == 1 && mem_pp1 == 2) || (mem_pp1 == 1 && mem_pp2 == 2))) i = nrr_portr; //if-urile astea sunt ca sa nu avem doua portrete identice a celor 3 personaje
                        else if (i == 1 && ((mem_pp3 == mem_pp1 + 1 || mem_pp3 == mem_pp2 + 1) && (mem_pp2 == nrr_portr || mem_pp1 == nrr_portr))) i = nrr_portr - 1;
                        else if (i == 1 && (mem_pp3 == mem_pp1 + 1 || mem_pp3 == mem_pp2 + 1)) i = nrr_portr;
                        else if ((mem_pp3 == mem_pp1 + 1 && mem_pp3 == mem_pp2 + 2) || (mem_pp3 == mem_pp1 + 2 && mem_pp3 == mem_pp2 + 1)) i = i - 2;
                        else if (mem_pp3 == mem_pp1 + 1 || mem_pp3 == mem_pp2 + 1) i = i - 1;

                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[i - 1]; //rand anterior
                        poz_pers3.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp3 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp3 && i == 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Portretele().Rows[nrr_portr - 1]; //resetam la ultimul rand
                        poz_pers3.Image = Image.FromFile("Portrete\\" + ra["adr_poza"].ToString());
                        this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp3 = Convert.ToInt32(ra["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp3==mem_pp1 || mem_pp3==mem_pp2);
        }

        private void urm_P3_Click(object sender, EventArgs e) //sageata inainte portretul personajului 3
        {
            Audio_player.sunet_click();
            do {
                for (int i = 0; i <= nrr_portr - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Portretele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_portret"]) == mem_pp3 && i != nrr_portr - 1)
                    {
                        if (i == nrr_portr - 3 && ((mem_pp3 == mem_pp1 - 1 && mem_pp3 == mem_pp2 - 2) || (mem_pp3 == mem_pp1 - 2 && mem_pp3 == mem_pp2 - 1))) i = -1; //if-urile astea sunt ca sa nu avem doua portrete identice a celor 3 personaje
                        else if (i == nrr_portr - 2 && ((mem_pp3 == mem_pp1 - 1 || mem_pp3 == mem_pp2 - 1) && (mem_pp1 == 1 || mem_pp2 == 1))) i = 0;
                        else if (i == nrr_portr - 2 && ((mem_pp3 == mem_pp1 - 1 || mem_pp3 == mem_pp2 - 1))) i = -1;
                        else if ((mem_pp3 == mem_pp1 - 1 && mem_pp3 == mem_pp2 - 2) || (mem_pp3 == mem_pp1 - 2 && mem_pp3 == mem_pp2 - 1)) i = i + 2;
                        else if (mem_pp3 == mem_pp1 - 1 || mem_pp3 == mem_pp2 - 1) i = i + 1;
                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[i + 1]; //randul urmator
                        poz_pers3.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp3 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_portret"]) == mem_pp3 && i == nrr_portr - 1) //daca ajungem la ultimul portret
                    {
                        int j = 0;
                        if ((mem_pp1 == 1 || mem_pp2 == 1) && (mem_pp1 == 2 || mem_pp2 == 2)) j = 2;
                        else if (mem_pp1 == 1 || mem_pp3 == 1) j = 1;

                        DataRow ru = DB_Interogari.Descarc_Portretele().Rows[j]; //resetam la primul rand
                        poz_pers3.Image = Image.FromFile("Portrete\\" + ru["adr_poza"].ToString());
                        this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_pp3 = Convert.ToInt32(ru["cod_portret"]);
                        break;
                    }
                }
            } while (mem_pp3==mem_pp1 || mem_pp3==mem_pp2);
        }

        private void rand_N3_Click(object sender, EventArgs e) //genereaza un nume la intamplare
        {
            Audio_player.sunet_zar();
            string num = numP3.Text;

            do
            {
                int index = new Random().Next(0, nume_rand.Count()); //generez un nume la intamplare din sirul nume_rand
                numP3.Text = nume_rand[index];
            } while (numP3.Text == num || numP3.Text == numP2.Text || numP3.Text == numP1.Text); //vrem sa avem 3 nume unice
        }

        private void ant_C3_Click(object sender, EventArgs e) //Sageata inapoi clasa personajului 3
        {
            Audio_player.sunet_click();
          do {
                for (int i = nrr_clas - 1; i >= 0; i = i - 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i];

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp3 && i != 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i - 1]; //rand anterior
                        clas_pers3.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp3 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp3 && i == 0)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[nrr_clas - 1]; //resetam la ultimul rand
                        clas_pers3.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp3 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp3==mem_cp1 || mem_cp3==mem_cp2);
        }

        private void urm_C3_Click(object sender, EventArgs e) //Sageata inainte clasa personajului 3
        {
            Audio_player.sunet_click();
         do {
                for (int i = 0; i <= nrr_clas - 1; i = i + 1)
                {
                    DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i]; //randul curentul din tabelul bazei de date

                    if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp3 && i != nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[i + 1]; //rand anterior
                        clas_pers3.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp3 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                    else if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp3 && i == nrr_clas - 1)
                    {
                        DataRow ra = DB_Interogari.Descarc_Clasele().Rows[0]; //resetam la primul rand
                        clas_pers3.Image = Image.FromFile("Clase\\" + ra["adr_poza"].ToString());
                        this.clas_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        mem_cp3 = Convert.ToInt32(ra["cod_clasa"]);
                        break;
                    }
                }
            } while (mem_cp3 == mem_cp1 || mem_cp3 == mem_cp2);
        }

        private void fin_Click(object sender, EventArgs e) //Butonul "Înainte!"
        {
            if (numP1.Text == "" || numP2.Text == "" || numP3.Text == "") MessageBox.Show("Completați toate numele personajelor!");
            else
            {
                string s = "Sunteti sigur?";
                Confirmare cf = new Confirmare(s);
                if (cf.ShowDialog() == DialogResult.Cancel) cf.Close();
                else if (cf.DialogResult == DialogResult.OK)
                {
                    DB_Inserari.Adaug_Grup();
                    DB_Inserari.Adaug_Personaj(numP1.Text, 1, mem_cp1, DB_Interogari.Descarc_Id_grup(), mem_pp1);
                    DB_Inserari.Adaug_Personaj(numP2.Text, 2, mem_cp2, DB_Interogari.Descarc_Id_grup(), mem_pp2);
                    DB_Inserari.Adaug_Personaj(numP3.Text, 3, mem_cp3, DB_Interogari.Descarc_Id_grup(), mem_pp3);
                    DB_Inserari.Adaug_Abilitatile_Personajului();
                    Orasel_start orasel = new Orasel_start();
                    orasel.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Creare_personaje_MouseEnter(object sender, EventArgs e) //aici o sa am descrierile cand pluteste mouse-ul pe imaginile/butoanele
        {
            desc.SetToolTip(rand_P1, "Generează un portret \n la întâmplare");
            desc.SetToolTip(rand_P2, "Generează un portret \n la întâmplare");
            desc.SetToolTip(rand_P3, "Generează un portret \n la întâmplare");

            desc.SetToolTip(rand_N1, "Generează un nume \n la întâmplare");
            desc.SetToolTip(rand_N2, "Generează un nume \n la întâmplare");
            desc.SetToolTip(rand_N3, "Generează un nume \n la întâmplare");

            desc.SetToolTip(rand_clasa, "Generează 3 clase \n la întâmplare pentru\n cele 3 personaje");

            desc.SetToolTip(anulez, "Înapoi la meniul principal");
            desc.SetToolTip(fin, "Începe jocul!");

            for (int i = 0; i <= nrr_clas - 1; i = i + 1)
            {
                DataRow rc = DB_Interogari.Descarc_Clasele().Rows[i]; //parcurem randurile tabelului "clasa"
                if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp1) desc.SetToolTip(clas_pers1, rc["descriere"].ToString());
                if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp2) desc.SetToolTip(clas_pers2, rc["descriere"].ToString());
                if (Convert.ToInt32(rc["cod_clasa"]) == mem_cp3) desc.SetToolTip(clas_pers3, rc["descriere"].ToString());
            }
        }
    }
}
