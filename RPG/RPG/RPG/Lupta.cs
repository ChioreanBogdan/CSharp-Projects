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
    public partial class Lupta : Form
    {
        public static int bar_latime, bar_inaltime;
        int grup = DB_Interogari.Descarc_Id_grup(); //descarc ID-ul ultimului grup introdus
        public static int cod_pers1, cod_pers2, cod_pers3; //coduri cu ajutorul carora o sa identific cele 3 personaje ca apoi sa le extrag abilitatile
        public static int vmax_p1, vc_p1, emax_p1, ec_p1, vmax_p2, vc_p2, emax_p2, ec_p2, vmax_p3, vc_p3, emax_p3, ec_p3, vmax_i1, vc_i1, emax_i1, ec_i1, vmax_i2, vc_i2, emax_i2, ec_i2, vmax_i3, vc_i3, emax_i3, ec_i3; //aici memorez viata si energia maxima si curenta a celor 3 personaje precum si a inamicilor
        public static int vc_p1_init, vc_p2_init, vc_p3_init, ec_p1_init, ec_p2_init, ec_p3_init; //memorez punctele de energie si viata a personajelor de la inceputul luptei
        public static int p1_sangera,p2_sangera,p3_sangera; //memoram care personaj sangera la inceputul luptei pentru a sti cui sa aplicam rani daca lupta se reia
        public static int paraliz_p1, paraliz_p2, paraliz_p3, paraliz_i1, paraliz_i2, paraliz_i3; //variabile care verifica daca inamicii/personajele din grup sunt paralizate (nu pot actiona)
        public static int atc_scad_p1_fiz, atc_scad_p2_fiz, atc_scad_p3_fiz, atc_scad_i1_fiz, atc_scad_i2_fiz, atc_scad_i3_fiz; //cate puncte se scad din atacurile fizice ale personajelor/inamicilor
        public static int atc_cresc_p1_fiz, atc_cresc_p2_fiz, atc_cresc_p3_fiz, atc_cresc_i1_fiz, atc_cresc_i2_fiz, atc_cresc_i3_fiz; //cu cate puncte cresc atacurile fizice ale personajelor/inamicilor
        public static int atc_scad_p1_magic, atc_scad_p2_magic, atc_scad_p3_magic, atc_scad_i1_magic, atc_scad_i2_magic, atc_scad_i3_magic; //cate puncte se scad din atacurile magice ale personajelor/inamicilor
        public static int atc_cresc_p1_magic, atc_cresc_p2_magic, atc_cresc_p3_magic, atc_cresc_i1_magic, atc_cresc_i2_magic, atc_cresc_i3_magic; //cu cate puncte cresc atacurile magice ale personajelor/inamicilor
        public static int reduc_p1, reduc_p2, reduc_p3, reduc_i1, reduc_i2, reduc_i3; //cate puncte de atac pot bloca inamicii/aliatii
        public static int reduc_mem_p1, reduc_mem_p2, reduc_mem_p3, reduc_mem_i1, reduc_mem_i2, reduc_mem_i3; //aici memorez blocarile intr-o tura,in cazul in care mai multi inamici ataca aceeasi persoana

        int[] a_p1 = new int[5]; int[] a_p2 = new int[5]; int[] a_p3 = new int[5]; //aici memoram abilitatile personajelor din fiecare slot

        int[] af_p1 = new int[5]; int[] af_p2 = new int[5]; int[] af_p3 = new int[5]; //aici memoram pe cine afecteaza abilitatile personajelor din fiecare slot

        public static int ab_fol_p1 = 0, ab_fol_p2 = 0, ab_fol_p3 = 0, ab_fol_i1 = 0, ab_fol_i2 = 0, ab_fol_i3 = 0; //aceste variabile devin 1 cand personajele 1,2 si 3/inamicii 1,2, si 3 folosesc o abilitate

        int pers_sel = 0; //memoreaza ce personaj actioneaza (se foloseste impreuna cu centralizatorul de abilitati pt a scadea energia)
        public static int ab_sel_p1 = 0, ab_sel_p2 = 0, ab_sel_p3 = 0, ab_sel_i1 = 0, ab_sel_i2 = 0, ab_sel_i3 = 0; //exemplu: ab_sel_p1=1; ab_sel_p2=0; ab_sel_p1=0; cand e selectata o abilitate a personajului 1
        public static int mem_ab_sel = 0; //memoreaza ultima abilitate selectata 0 inseamna ca nicio abilitate nu a fost selectata
        int mem_ab_af = 0; //memoreaza pe cine afecteaza abilitatea selectata a personajului 0 inseamna ca nu a fost selectata o abilitate
                           //1 afecteaza un inamic
                           //2 afecteaza sine sau aliat
                           //3 afecteaza toti inamicii
                           //4 afecteaza sine+toti aliatii
        int mem_inm_af = 0; //memoreaza numarul slot-ului inamicului afectat
        int mem_pers_af = 0; //memoreaza numarul slot-ului personajului afectat

        int[] a_i1 = new int[5]; int[] a_i2 = new int[5]; int[] a_i3 = new int[5]; //aici memoram abilitatile inamicilor din fiecare slot
        int[] af_i1 = new int[5]; int[] af_i2 = new int[5]; int[] af_i3 = new int[5]; //aici memoram pe cine afecteaza abilitatile inamicilor din fiecare slot

        public static int nr_tura = 1; //memoreaza in ce tura suntem (o tura trece cand au actionat atat personajele cat si inamicii)

        public int nrr_pers = DB_Interogari.Descarc_Personaje().Rows.Count; //memoreaza numarul de randuri din tabela "grup" din BD
        public int nrr_inamici = DB_Interogari.Descarc_Inamicii().Rows.Count; //memoreaza numarul de randuri din tabela "inamic" din BD
        public int nrr_portr = DB_Interogari.Descarc_Portretele().Rows.Count; //memoreaza numarul de randuri din tabela "portret" din BD
        public int nrr_ab_pers = DB_Interogari.Descarc_Abilitatile_Personajelor().Rows.Count; //memoreaza numarul elementelor comune dintre abilitati si personaje din tabela "abilitate_personaj"
        public int nrr_ab_inm = DB_Interogari.Descarc_Abilitatile_Inamicilor().Rows.Count; //memoreaza numarul elementelor comune dintre abilitati si inamici din tabela "abilitate_inamic"

        public Lupta() //ALTER TABLE tablename AUTO_INCREMENT = 1 <-cod SQL pt a reseta auto incrementarea
        {
            InitializeComponent();
            Inceput_lupta();
        }

        public void Inceput_lupta()
        {
            paraliz_p1 = 0; paraliz_p2 = 0; paraliz_p3 = 0; paraliz_i1 = 0; paraliz_i2 = 0; paraliz_i3 = 0; //initial nimeni nu e paralizat
            atc_scad_p1_fiz = 0; atc_scad_p2_fiz = 0; atc_scad_p3_fiz = 0; atc_scad_i1_fiz = 0; atc_scad_i2_fiz = 0; atc_scad_p3_fiz = 0; //penalizarile atacurilor fizice sunt initial 0
            atc_cresc_p1_fiz = 0; atc_cresc_p2_fiz = 0; atc_cresc_p3_fiz = 0; atc_cresc_i1_fiz = 0; atc_cresc_i2_fiz = 0; atc_cresc_i3_fiz = 0; //bonusurile de atac fizic sunt initial 0
            atc_scad_p1_magic = 0; atc_scad_p2_magic = 0; atc_scad_p3_magic = 0; atc_scad_i1_magic = 0; atc_scad_i2_magic = 0; atc_scad_i3_magic = 0; //penalizarile atacurilor magice sunt initial 0
            atc_cresc_p1_magic = 0; atc_cresc_p2_magic = 0; atc_cresc_p3_magic = 0; atc_cresc_i1_magic = 0; atc_cresc_i2_magic = 0; atc_cresc_i3_magic = 0; //bonusurile de atac magic sunt initial 0
            reduc_p1 = 0; reduc_p2 = 0; reduc_p3 = 0; reduc_i1 = 0; reduc_i2 = 0; reduc_i3 = 0; //scuturile personajelor si a inamicilor
            Efecte_ofensive.urlet_act = 0; //resetez urletul

            Incarc_pozele_personajelor();
            Incarc_portretele_inamicilor(2, 2, 2);

            p1_sangera = Efecte_ofensive.p1_sang; p2_sangera = Efecte_ofensive.p2_sang; p3_sangera = Efecte_ofensive.p3_sang; //memoram care personaj are rani deschise la inceputul luptei

            this.WindowState = FormWindowState.Maximized; //Intind fereastra cat permite ecranul
            Fugi.Enabled = false; //Nu am programat inca butonul "Fugi!"
            desc.Visible = false; desc_urm.Visible = false; //Vroiam ca "desc" sa descrie fiecare atac al inamicului iar "desc_urm" butonul pe care,cand apasai sa treaca la descrierea urmatoarei abilitati folosite de inamic

            bar_latime = viata_pers1.Width; //luam latimea si inaltimea unei bare si o folosim la toate pt ca au aceleasi dimensiuni
            bar_inaltime = viata_pers1.Height;

            viata_pers1.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_p1, vc_p1); //incarcam barele de viata si energia in functie de clasa personajului
            eng_pers1.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_p1, ec_p1);
            viata_pers2.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_p2, vc_p2); //incarcam barele de viata si energia in functie de clasa personajului
            eng_pers2.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_p2, ec_p2);
            viata_pers3.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_p3, vc_p3); //incarcam barele de viata si energia in functie de clasa personajului
            eng_pers3.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_p3, ec_p3);

            Updatez_bare_viata();
            Updatez_bare_energie();
            Adaug_poze_sangerari(); //adaug pozele cu sangerari daca personajele au incheiat cu rani ultima lupta

            vc_p1_init = vc_p1; vc_p2_init = vc_p2; vc_p3_init = vc_p3; //memorez viata curenta a personajelor la inceputul luptei
            ec_p1_init = ec_p1; ec_p2_init = ec_p2; ec_p3_init = ec_p3; //memorez energia curenta a personajelor la inceputul luptei
        }

        public void Incarc_pozele_personajelor() //iau portretle personajelor in functie de grupul din care fac parte
        {
            for (int i = nrr_pers - 1; i >= 0; i = i - 1)
            {
                DataRow rg = DB_Interogari.Descarc_Personaje().Rows[i];
                ToolTip descriere = new ToolTip();

                if (Convert.ToInt32(rg["cod_gr"]) == grup) //grup e doar pt test si o sa trebuiasca inlocuit!
                {
                    if (Convert.ToInt32(rg["numar"]) == 1) //Caut portretul care apare la personajul 1 din grupul "grup" si il afisez in poz_pers1 iau si viata si energia maxima si curenta a personajului
                    {
                        poz_pers1.Image = Image.FromFile("Portrete\\" + DB_Interogari.Caut_Portretul(Convert.ToInt32(rg["cod_port"])));
                        this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        cod_pers1 = Convert.ToInt32(rg["cod_pers"]);
                        vmax_p1 = Convert.ToInt32(rg["viata_max"]);
                        vc_p1 = Convert.ToInt32(rg["viata"]);
                        emax_p1 = Convert.ToInt32(rg["eng_max"]);
                        ec_p1 = Convert.ToInt32(rg["eng"]);
                        descriere.SetToolTip(poz_pers1, rg["nume"].ToString()); //apare numele personajului cand dau hover pe portret
                    }

                    if (Convert.ToInt32(rg["numar"]) == 2) //Caut portretul care apare la personajul 2 din grupul "grup" si il afisez in poz_pers2 iau si viata si energia maxima si curenta a personajului
                    {
                        poz_pers2.Image = Image.FromFile("Portrete\\" + DB_Interogari.Caut_Portretul(Convert.ToInt32(rg["cod_port"])));
                        this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        cod_pers2 = Convert.ToInt32(rg["cod_pers"]);
                        vmax_p2 = Convert.ToInt32(rg["viata_max"]);
                        vc_p2 = Convert.ToInt32(rg["viata"]);
                        emax_p2 = Convert.ToInt32(rg["eng_max"]);
                        ec_p2 = Convert.ToInt32(rg["eng"]);
                        descriere.SetToolTip(poz_pers2, rg["nume"].ToString()); //apare numele personajului cand dau hover pe portret
                    }

                    if (Convert.ToInt32(rg["numar"]) == 3) //Caut portretul care apare la personajul 3 din grupul "grup" si il afisez in poz_pers3 iau si viata si energia maima si curenta a personajului
                    {
                        poz_pers3.Image = Image.FromFile("Portrete\\" + DB_Interogari.Caut_Portretul(Convert.ToInt32(rg["cod_port"])));
                        this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        cod_pers3 = Convert.ToInt32(rg["cod_pers"]);
                        vmax_p3 = Convert.ToInt32(rg["viata_max"]);
                        vc_p3 = Convert.ToInt32(rg["viata"]);
                        emax_p3 = Convert.ToInt32(rg["eng_max"]);
                        ec_p3 = Convert.ToInt32(rg["eng"]);
                        descriere.SetToolTip(poz_pers3, rg["nume"].ToString()); //apare numele personajului cand dau hover pe portret
                    }
                }
            }

            for (int j = nrr_ab_pers - 1; j >= 0; j = j - 1)
            {
                DataRow rap = DB_Interogari.Descarc_Abilitatile_Personajelor().Rows[j];

                if (Convert.ToInt32(rap["cod_pers"]) == cod_pers1)
                {
                    if (Convert.ToInt32(rap["nr_slot"]) == 1)
                    {
                        ab1_pers1.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab1_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p1[1] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a personajului 1
                        af_p1[1] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a personajului 1
                        descriere.SetToolTip(ab1_pers1, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 2)
                    {
                        ab2_pers1.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab2_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p1[2] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a personajului 1
                        af_p1[2] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a personajului 1
                        descriere.SetToolTip(ab2_pers1, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 3)
                    {
                        ab3_pers1.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab3_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p1[3] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a personajului 1
                        af_p1[3] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a personajului 1
                        descriere.SetToolTip(ab3_pers1, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 4)
                    {
                        ab4_pers1.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab4_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p1[4] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a personajului 1
                        af_p1[4] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a personajului 1
                        descriere.SetToolTip(ab4_pers1, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                }

                if (Convert.ToInt32(rap["cod_pers"]) == cod_pers2)
                {
                    if (Convert.ToInt32(rap["nr_slot"]) == 1)
                    {
                        ab1_pers2.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab1_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p2[1] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a personajului 2
                        af_p2[1] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a personajului 2
                        descriere.SetToolTip(ab1_pers2, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 2)
                    {
                        ab2_pers2.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab2_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p2[2] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a personajului 2
                        af_p2[2] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a personajului 2
                        descriere.SetToolTip(ab2_pers2, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 3)
                    {
                        ab3_pers2.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab3_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p2[3] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a personajului 2
                        af_p2[3] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a personajului 2
                        descriere.SetToolTip(ab3_pers2, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 4)
                    {
                        ab4_pers2.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab4_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p2[4] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a personajului 2
                        af_p2[4] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a personajului 2
                        descriere.SetToolTip(ab4_pers2, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                }

                if (Convert.ToInt32(rap["cod_pers"]) == cod_pers3)
                {
                    if (Convert.ToInt32(rap["nr_slot"]) == 1)
                    {
                        ab1_pers3.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab1_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p3[1] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a personajului 3
                        af_p3[1] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a personajului 3
                        descriere.SetToolTip(ab1_pers3, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 2)
                    {
                        ab2_pers3.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab2_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p3[2] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a personajului 3
                        af_p3[2] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a personajului 3
                        descriere.SetToolTip(ab2_pers3, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 3)
                    {
                        ab3_pers3.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab3_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p3[3] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a personajului 3
                        af_p3[3] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a personajului 3
                        descriere.SetToolTip(ab3_pers3, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                    if (Convert.ToInt32(rap["nr_slot"]) == 4)
                    {
                        ab4_pers3.Image = Image.FromFile("Abilitati\\" + rap["adr_poza"]);
                        this.ab4_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_p3[4] = Convert.ToInt32(rap["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a personajului 3
                        af_p3[4] = Convert.ToInt32(rap["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a personajului 3
                        descriere.SetToolTip(ab4_pers3, rap["descriere"].ToString()); //apare descrierea abilitatii cand plutesc cu mouse-ul peste ea prin tooltip
                    }
                }
            }
        }

        public void Incarc_portretele_inamicilor(int cod_inm1, int cod_inm2, int cod_inm3) //iau portretle inamicilor in functie de id
        {
            bar_latime = viata_inm1.Width; //luam latimea si inaltimea unei bare si o folosim la toate pt ca au aceleasi dimensiuni
            bar_inaltime = viata_inm1.Height;

             for (int i = nrr_inamici - 1; i >= 0; i = i - 1)
             {
                DataRow ri = DB_Interogari.Descarc_Inamicii().Rows[i];

                if (Convert.ToInt32(ri["cod_inamic"]) == cod_inm1)
                {
                    poz_inm1.Image = Image.FromFile("Inamici\\" + ri["portret"].ToString());
                    this.poz_inm1.SizeMode = PictureBoxSizeMode.StretchImage;

                    vmax_i1 = Convert.ToInt32(ri["viata_max"]); vc_i1 = Convert.ToInt32(ri["viata"]);
                    emax_i1 = Convert.ToInt32(ri["eng_max"]); ec_i1 = Convert.ToInt32(ri["eng"]);
                    viata_inm1.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_i1, vc_i1);
                    eng_inm1.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_i1, ec_i1);
                    descriere.SetToolTip(poz_inm1, ri["nume"].ToString()); //apare numele inamicului cand dau hover pe portret
                }

                if (Convert.ToInt32(ri["cod_inamic"]) == cod_inm2)
                {
                    poz_inm2.Image = Image.FromFile("Inamici\\" + ri["portret"].ToString());
                    this.poz_inm2.SizeMode = PictureBoxSizeMode.StretchImage;

                    vmax_i2 = Convert.ToInt32(ri["viata_max"]); vc_i2 = Convert.ToInt32(ri["viata"]);
                    emax_i2 = Convert.ToInt32(ri["eng_max"]); ec_i2 = Convert.ToInt32(ri["eng"]);
                    viata_inm2.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_i2, vc_i2); //incarcam barele de viata si energie a inamicului 2
                    eng_inm2.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_i2, ec_i2);
                    descriere.SetToolTip(poz_inm2, ri["nume"].ToString()); //apare numele inamicului cand dau hover pe portret
                }

                if (Convert.ToInt32(ri["cod_inamic"]) == cod_inm3)
                {
                    poz_inm3.Image = Image.FromFile("Inamici\\" + ri["portret"].ToString());
                    this.poz_inm3.SizeMode = PictureBoxSizeMode.StretchImage;

                    vmax_i3 = Convert.ToInt32(ri["viata_max"]); vc_i3 = Convert.ToInt32(ri["viata"]);
                    emax_i3 = Convert.ToInt32(ri["eng_max"]); ec_i3 = Convert.ToInt32(ri["eng"]);
                    viata_inm3.Image = Bare.Umple_bara_viata(bar_latime, bar_inaltime, vmax_i3, vc_i3); //incarcam barele de viata si energie a inamicului 2
                    eng_inm3.Image = Bare.Umple_bara_energie(bar_latime, bar_inaltime, emax_i3, ec_i3);
                    descriere.SetToolTip(poz_inm3, ri["nume"].ToString()); //apare numele inamicului cand dau hover pe portret
                }
            }

            for (int j = nrr_ab_inm - 1; j >= 0; j = j - 1)
            {
                DataRow rai = DB_Interogari.Descarc_Abilitatile_Inamicilor().Rows[j];
                ToolTip descriere = new ToolTip(); //descrierea ce apare cand facem hover peste poza

                if (Convert.ToInt32(rai["cod_inamic"]) == cod_inm1)
                {
                    if (Convert.ToInt32(rai["nr_slot"]) == 1)
                    {
                        ab1_inm1.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab1_inm1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i1[1] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a inamicului 1
                        af_i1[1] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a inamicului 1
                        descriere.SetToolTip(ab1_inm1, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 2)
                    {
                        ab2_inm1.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab2_inm1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i1[2] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a inamicului 1
                        af_i1[2] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a inamicului 1
                        descriere.SetToolTip(ab2_inm1, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 3)
                    {
                        ab3_inm1.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab3_inm1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i1[3] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a inamicului 1
                        af_i1[3] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a inamicului 1
                        descriere.SetToolTip(ab3_inm1, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 4)
                    {
                        ab4_inm1.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab4_inm1.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i1[4] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a inamicului 1
                        af_i1[4] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a inamicului 1
                        descriere.SetToolTip(ab4_inm1, rai["descriere"].ToString());
                    }
                }

                if (Convert.ToInt32(rai["cod_inamic"]) == cod_inm2)
                {
                    if (Convert.ToInt32(rai["nr_slot"]) == 1)
                    {
                        ab1_inm2.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab1_inm2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i2[1] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a inamicului 2
                        af_i2[1] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a inamicului 2
                        descriere.SetToolTip(ab1_inm2, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 2)
                    {
                        ab2_inm2.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab2_inm2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i2[2] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a inamicului 2
                        af_i2[2] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a inamicului 2
                        descriere.SetToolTip(ab2_inm2, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 3)
                    {
                        ab3_inm2.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab3_inm2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i2[3] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a inamicului 2
                        af_i2[3] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a inamicului 2
                        descriere.SetToolTip(ab3_inm2, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 4)
                    {
                        ab4_inm2.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab4_inm2.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i2[4] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a inamicului 2
                        af_i2[4] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a inamicului 2
                        descriere.SetToolTip(ab4_inm2, rai["descriere"].ToString());
                    }
                }

                if (Convert.ToInt32(rai["cod_inamic"]) == cod_inm3)
                {
                    if (Convert.ToInt32(rai["nr_slot"]) == 1)
                    {
                        ab1_inm3.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab1_inm3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i3[1] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 1 a inamicului 3
                        af_i3[1] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 1 a inamicului 3
                        descriere.SetToolTip(ab1_inm3, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 2)
                    {
                        ab2_inm3.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab2_inm3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i3[2] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 2 a inamicului 3
                        af_i3[2] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 2 a inamicului 3
                        descriere.SetToolTip(ab2_inm3, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 3)
                    {
                        ab3_inm3.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab3_inm3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i3[3] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 3 a inamicului 3
                        af_i3[3] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 3 a inamicului 3
                        descriere.SetToolTip(ab3_inm3, rai["descriere"].ToString());
                    }
                    if (Convert.ToInt32(rai["nr_slot"]) == 4)
                    {
                        ab4_inm3.Image = Image.FromFile("Abilitati\\" + rai["adr_poza"]);
                        this.ab4_inm3.SizeMode = PictureBoxSizeMode.StretchImage;
                        a_i3[4] = Convert.ToInt32(rai["cod_abilitate"]); //memorez id-ul abilitatii din slot-ul 4 a inamicului 3
                        af_i3[4] = Convert.ToInt32(rai["afecteaza"]); //memoreaza pe cine afecteaza abilitatea din slot-ul 4 a inamicului 3
                        descriere.SetToolTip(ab4_inm3, rai["descriere"].ToString());
                    }
                }
            }
        }

        public void Poze_0_viata() //schimb poza inamicilor/personajelor care au ajuns la 0 viata cu un x rosu
        {
            if (vc_p1 <= 0)
            {
                poz_pers1.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_pers1.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele de sangerare daca personajul 1 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_regenerari) if (p.Location.X == 115 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele regenerarilor de lupta daca personajul 1 ajunge la 0 viata
                if (Efecte_defensive.poza_scut.Location.X == 193 && Efecte_defensive.poza_scut.Location.Y == 151) this.Controls.Remove(Efecte_defensive.poza_scut); //elimin pozele scuturilor de lupta daca personajul 1 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_urlete) if (p.Location.X == 155 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele urletelor lupilor daca personajul 1 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_strigate) if (p.Location.X == 195 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele strigatelor de lupta daca personajul 1 ajunge la 0 viata
            }

            if (vc_p2 <= 0)
            {
                poz_pers2.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_pers2.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele de sangerare daca personajul 2 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_regenerari) if (p.Location.X == 115 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele regenerarilor de lupta daca personajul 2 ajunge la 0 viata
                if (Efecte_defensive.poza_scut.Location.X == 193 && Efecte_defensive.poza_scut.Location.Y == 320) this.Controls.Remove(Efecte_defensive.poza_scut); //elimin pozele scuturilor de lupta daca personajul 2 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_urlete) if (p.Location.X == 155 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele urletelor lupilor daca personajul 2 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_strigate) if (p.Location.X == 195 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele strigatelor de lupta daca personajul 2 ajunge la 0 viata
            }

            if (vc_p3 <= 0)
            {
                poz_pers3.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_pers3.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_sangerare) if (p.Location.X == 115 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele de sangerare daca personajul 3 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_regenerari) if (p.Location.X == 115 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele regenerarilor de lupta daca personajul 3 ajunge la 0 viata
                if (Efecte_defensive.poza_scut.Location.X == 193 && Efecte_defensive.poza_scut.Location.Y == 493) this.Controls.Remove(Efecte_defensive.poza_scut); //elimin pozele scuturilor de lupta daca personajul 3 ajunge la 0 viata          
                foreach (PictureBox p in Efecte_defensive.poze_regenerari) if (p.Location.X == 115 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele regenerarilor de lupta daca personajul 3 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_urlete) if (p.Location.X == 155 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele urletelor lupilor daca personajul 3 ajunge la 0 viata
                foreach (PictureBox p in Efecte_defensive.poze_strigate) if (p.Location.X == 195 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele strigatelor de lupta daca personajul 3 ajunge la 0 viata
            }

            if (vc_i1<=0)
            {
                poz_inm1.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_inm1.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_arsuri) if (p.Location.X == 1127 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele de arsuri daca inamicul 1 ajunge la 0 daca e lovit de "Sfera de foc"
                foreach (PictureBox p in Efecte_ofensive.poze_placari) if (p.Location.X == 1089 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele de placare daca inamicul 1 ajunge la 0 viata in urma placarii
                foreach (PictureBox p in Efecte_ofensive.poze_tintiri) this.Controls.Remove(p); //elimin pozele de tintire daca inamicul 1 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_viscoliri) if (p.Location.X == 969 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele de viscolire daca inamicul 1 ajunge la 0 viata in urma viscolirii
                foreach (PictureBox p in Efecte_ofensive.poze_degeraturi) if (p.Location.X == 1009 && p.Location.Y == 151) this.Controls.Remove(p); //elimin pozele de degerare daca inamicul ajunge la 0 viata
            }

            if (vc_i2 <= 0)
            {
                poz_inm2.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_inm2.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_arsuri) if (p.Location.X == 1127 && p.Location.Y == 320) this.Controls.Remove(p); //elimin arsuri de placare daca inamicul 2 ajunge la 0 daca e lovit de "Sfera de foc"
                foreach (PictureBox p in Efecte_ofensive.poze_placari) if (p.Location.X == 1089 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele de placare daca inamicul 2 ajunge la 0 viata in urma placarii
                foreach (PictureBox p in Efecte_ofensive.poze_tintiri) this.Controls.Remove(p); //elimin pozele de tintire daca inamicul 2 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_viscoliri) if (p.Location.X == 969 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele de viscolire daca inamicul 1 ajunge la 0 viata in urma viscolirii
                foreach (PictureBox p in Efecte_ofensive.poze_degeraturi) if (p.Location.X == 1009 && p.Location.Y == 320) this.Controls.Remove(p); //elimin pozele de degerare daca inamicul ajunge la 0 viata
            }

            if (vc_i3 <= 0)
            {
                poz_inm3.Image = Image.FromFile("Altele\\x_rosu.png");
                this.poz_inm3.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (PictureBox p in Efecte_ofensive.poze_arsuri) if (p.Location.X == 1127 && p.Location.Y == 493) this.Controls.Remove(p); //elimin arsuri de placare daca inamicul 3 ajunge la 0 daca e lovit de "Sfera de foc"
                foreach (PictureBox p in Efecte_ofensive.poze_placari) if (p.Location.X == 1089 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele de placare daca inamicul 3 ajunge la 0 viata in urma placarii
                foreach (PictureBox p in Efecte_ofensive.poze_tintiri) this.Controls.Remove(p); //elimin pozele de tintire daca inamicul 3 ajunge la 0 viata
                foreach (PictureBox p in Efecte_ofensive.poze_viscoliri) if (p.Location.X == 969 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele de viscolire daca inamicul 1 ajunge la 0 viata in urma viscolirii
                foreach (PictureBox p in Efecte_ofensive.poze_degeraturi) if (p.Location.X == 1009 && p.Location.Y == 493) this.Controls.Remove(p); //elimin pozele de degerare daca inamicul ajunge la 0 viata
            }
        }

        public void Verific_0_viata() //verific daca toate personajele sau toti inamicii au ajuns la 0 viata pentru a incheia lupta
        {
            if (vc_p1<=0 && vc_p2 <= 0 && vc_p3 <= 0)
                {
                string r = "Din pacate grupul tau \n            a fost învins";
                string b1 = "Încearca din nou";
                string b2 = "Înapoi la meniul principal";
                Ecran_sfarsit_lupta.victorie = 0; Ecran_sfarsit_lupta.infrangere = 1;
                Ecran_sfarsit_lupta pierd = new Ecran_sfarsit_lupta(r,b1,b2);
                pierd.Name = "concluzie";
                pierd.ShowDialog();
                vc_p1 = vc_p1_init; vc_p2 = vc_p2_init; vc_p3 = vc_p3_init;
                ec_p1 = ec_p1_init; ec_p2 = ec_p2_init; ec_p3 = ec_p3_init;
                vc_i1 = vmax_i1; vc_i2 = vmax_i2; vc_i3 = vmax_i3;
                ec_i1 = emax_i1; ec_i2 = emax_i2; ec_i3 = emax_i3;
                Inceput_lupta();
            }
            if (vc_i1 <= 0 && vc_i2 <= 0 && vc_i3 <= 0)
            {
                string r = "             Victorie! \n inamicii au fost învinsi";
                string b1 = "Înapoi la harta";
                string b2 = "Înapoi la meniul principal";
                Ecran_sfarsit_lupta.victorie = 1; Ecran_sfarsit_lupta.infrangere = 0;
                Ecran_sfarsit_lupta castig = new Ecran_sfarsit_lupta(r,b1,b2);
                castig.Name = "concluzie";
                castig.ShowDialog();
            }
        }

        private void Abilitate_selectata_personaj(int personaj,int abilitate) //variabila ab_sel_p(x) a personajului care foloseste o abilitate primeste valoarea 1 iar celelalte valoarea 0
        {                                                                     //variabila mem_ab_sel primeste valoarea id-ului abilitatii selectate apartinand personajului "personaj"
            if (personaj==1)
            {
                pers_sel = 1; //actioneaza personajul din slot-ul 1
                ab_sel_p1=1; ab_sel_p2=0; ab_sel_p3=0; //in acest moment e selectata o abilitate a personajului 1
                if (abilitate==1)
                {
                 mem_ab_sel = a_p1[1]; //a fost selectata abilitatea 1 a pesonajului 1
                 mem_ab_af = af_p1[1]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate==2)
                {
                    mem_ab_sel=a_p1[2]; //a fost selectata abilitatea 2 a pesonajului 1
                    mem_ab_af=af_p1[2]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 3)
                {
                    mem_ab_sel = a_p1[3]; //a fost selectata abilitatea 3 a pesonajului 1
                    mem_ab_af = af_p1[3]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 4)
                {
                    mem_ab_sel = a_p1[4]; //a fost selectata abilitatea 4 a pesonajului 1
                    mem_ab_af = af_p1[4]; //ma uit pe cine afecteaza abilitatea respectiva
                }
            }

            if (personaj == 2)
            {
                pers_sel = 2; //actioneaza personajul din slot-ul 2
                ab_sel_p1 = 0; ab_sel_p2 = 1; ab_sel_p3 = 0; //in acest moment e selectata o abilitate a personajului 2
                if (abilitate == 1)
                {
                    mem_ab_sel = a_p2[1]; //a fost selectata abilitatea 1 a pesonajului 2
                    mem_ab_af = af_p2[1]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 2)
                {
                    mem_ab_sel = a_p2[2]; //a fost selectata abilitatea 2 a pesonajului 2
                    mem_ab_af = af_p2[2]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 3)
                {
                    mem_ab_sel = a_p2[3]; //a fost selectata abilitatea 3 a pesonajului 2
                    mem_ab_af = af_p2[3]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 4)
                {
                    mem_ab_sel = a_p2[4]; //a fost selectata abilitatea 4 a pesonajului 2
                    mem_ab_af = af_p2[4]; //ma uit pe cine afecteaza abilitatea respectiva
                }
            }

            if (personaj == 3)
            {
                pers_sel = 3; //actioneaza personajul din slot-ul 3
                ab_sel_p1 = 0; ab_sel_p2 = 0; ab_sel_p3 = 1; //in acest moment e selectata o abilitate a personajului 3
                if (abilitate == 1)
                {
                    mem_ab_sel = a_p3[1]; //a fost selectata abilitatea 1 a pesonajului 3
                    mem_ab_af = af_p3[1]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 2)
                {
                    mem_ab_sel = a_p3[2]; //a fost selectata abilitatea 2 a pesonajului 3
                    mem_ab_af = af_p3[2]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 3)
                {
                    mem_ab_sel = a_p3[3]; //a fost selectata abilitatea 3 a pesonajului 3
                    mem_ab_af = af_p3[3]; //ma uit pe cine afecteaza abilitatea respectiva
                }

                if (abilitate == 4)
                {
                    mem_ab_sel = a_p3[4]; //a fost selectata abilitatea 4 a pesonajului 3
                    mem_ab_af = af_p3[4]; //ma uit pe cine afecteaza abilitatea respectiva
                }
            }
        }

        private void Updatez_bare_viata() //Updatez barele de viata a celor 3 personaje
        {
            viata_pers1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p1, vc_p1); //updatez bara de viata a personajului din slot-ul 1
            viata_pers2.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p2, vc_p2); //updatez bara de viata a personajului din slot-ul 2
            viata_pers3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p3, vc_p3); //updatez bara de viata a personajului din slot-ul 3

            viata_inm1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i1, vc_i1); //updatez bara de viata a inamicului din slot-ul 1
            viata_inm2.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i2, vc_i2); //updatez bara de viata a inamicului din slot-ul 2
            viata_inm3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i3, vc_i3); //updatez bara de viata a inamicului din slot-ul 3
        }   

        private void Updatez_bare_energie() //Updatez barele de energie a celor 3 personaje
        {
            eng_pers1.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_p1, ec_p1); //updatez bara de energie a personajului din slot-ul 1
            eng_pers2.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_p2, ec_p2); //updatez bara de energie a personajului din slot-ul 2
            eng_pers3.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_p3, ec_p3); //updatez bara de energie a personajului din slot-ul 3

            eng_inm1.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_i1, ec_i1); //updatez bara de energie a inamicului din slot-ul 1
            eng_inm2.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_i2, ec_i2); //updatez bara de energie a inamicului din slot-ul 2
            eng_inm3.Image = Bare.Update_bara_energie(bar_latime, bar_inaltime, emax_i3, ec_i3); //updatez bara de energie a inamicului din slot-ul 3
        }

        private void Adaug_poze_efecte_ofensive()
        {
            //Abilitatile ofensive ale clasei "Războinic"

            //Abilitatea "Placare"
            foreach (PictureBox p in Efecte_ofensive.poze_placari)
            {
                this.Controls.Add(p);
                p.BringToFront();
            }
            if ((nr_tura >= Efecte_ofensive.turn_fol_placare + 1) || ((Efecte_ofensive.i1_eplacat == 1 && vc_i1 <= 0) || (Efecte_ofensive.i2_eplacat == 1 && vc_i2 <= 0) || (Efecte_ofensive.i3_eplacat == 1 && vc_i3 <= 0)))
                foreach (PictureBox p in Efecte_ofensive.poze_placari)
                {
                    this.Controls.Remove(p); //scot pozele daca inamicul ajunge la 0 viata sau trece o tura de la folosirea placarii
                    p.Image = null; //sterg poza din lista de poze
                }

            //Abilitatile ofensive ale clasei "Arcaş"

            //Abilitatea "Tintire"
            foreach (PictureBox p in Efecte_ofensive.poze_tintiri)
            {
                if (nr_tura <= Efecte_ofensive.turn_fol_tintire + 2)
                {
                    this.Controls.Add(p);
                    p.BringToFront();
                }
            }
            foreach (PictureBox p in Efecte_ofensive.poze_tintiri) if ((p.Left == 235 && p.Top == 151 && vc_p1 <= 0) || (p.Left == 235 && p.Top == 320 && vc_p2 <= 0) || (p.Left == 235 && p.Top == 493 && vc_p3 <= 0)) foreach (PictureBox p2 in Efecte_ofensive.poze_tintiri)
                    {
                        this.Controls.Remove(p2); //stergem pozele de tintire daca arcasul ajunge la 0 viata
                        p2.Image = null;
                    }
            if ((Efecte_ofensive.i1_etintit == 1 && vc_i1 <= 0) || (Efecte_ofensive.i2_etintit == 1 && vc_i2 <= 0) || (Efecte_ofensive.i3_etintit == 1 && vc_i3 <= 0)) foreach (PictureBox p2 in Efecte_ofensive.poze_tintiri)
                {
                    this.Controls.Remove(p2); //stergem pozele de tintire daca inamicul tintit ajunge la 0 viata
                    p2.Image = null;
                }
            if (nr_tura == Efecte_ofensive.turn_fol_tintire + 2) foreach (PictureBox p in Efecte_ofensive.poze_tintiri)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }

            //Abilitatile ofensive ale clasei "Vrăjitor"

            //Abilitatea "Sfera de foc"
            foreach (PictureBox p in Efecte_ofensive.poze_arsuri)
            {
                if ((nr_tura <= Efecte_ofensive.turn_fol_sfera_foc + 2) && (Efecte_ofensive.i1_ears == 1 || Efecte_ofensive.i2_ears == 1 || Efecte_ofensive.i3_ears == 1)) //ne asiguram ca sunt adaugate poze doar in intervalul in care se produc efectele sferei de foc si daca inamicul ars e in viata
                {
                    this.Controls.Add(p);
                    p.BringToFront();
                }
            }

            if (nr_tura == Efecte_ofensive.turn_fol_sfera_foc + 2) foreach (PictureBox p in Efecte_ofensive.poze_arsuri)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }

            if ((vc_i1 <= 0 && Efecte_ofensive.i1_ears == 1) || (vc_i2 <= 0 && Efecte_ofensive.i2_ears == 1) || (vc_i3 <= 0 && Efecte_ofensive.i3_ears == 1)) //eliminam efectele de arsuri daca inamicul a ajuns la 0 viaţă
            {
                foreach (PictureBox p in Efecte_ofensive.poze_arsuri)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                Efecte_ofensive.i1_ears = 0; Efecte_ofensive.i2_ears = 0; Efecte_ofensive.i3_ears = 0;
            }

            //Abilitatea "Viscol"
            foreach (PictureBox p in Efecte_ofensive.poze_viscoliri)
            {
                if (nr_tura <= Efecte_ofensive.tura_fol_viscol + 2) //ne asiguram ca sunt adaugate poze doar in intervalul in care se produc efectele viscolului
                {
                    this.Controls.Add(p);
                    p.BringToFront();
                }
            }

            foreach (PictureBox p in Efecte_ofensive.poze_degeraturi)
            {
                if (nr_tura <= Efecte_ofensive.tura_fol_viscol + 3) //ne asiguram ca sunt adaugate poze doar in intervalul in care se produc degeraturile
                {
                    this.Controls.Add(p);
                    p.BringToFront();
                }
            }

            foreach (PictureBox p in Efecte_ofensive.poze_viscoliri) if ((p.Left == 969 && p.Top == 151 && vc_i1 <= 0) || (p.Left == 969 && p.Top == 320 && vc_i2 <= 0) || (p.Left == 969 && p.Top == 493 && vc_i3 <= 0))
                {
                    this.Controls.Remove(p); //stergem pozele de viscolire daca inamicul ajunge la 0 viata
                    p.Image = null;
                }
            foreach (PictureBox p in Efecte_ofensive.poze_degeraturi) if ((p.Left == 1009 && p.Top == 151 && vc_i1 <= 0) || (p.Left == 1009 && p.Top == 320 && vc_i2 <= 0) || (p.Left == 1009 && p.Top == 493 && vc_i3 <= 0))
                {
                    this.Controls.Remove(p); //stergem pozele de degeraturi daca inamicul ajunge la 0 viata
                    p.Image = null;
                }

            if (nr_tura == Efecte_ofensive.tura_fol_viscol + 2) foreach (PictureBox p in Efecte_ofensive.poze_viscoliri)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
            if (nr_tura == Efecte_ofensive.tura_fol_viscol + 3) foreach (PictureBox p in Efecte_ofensive.poze_degeraturi)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }

             //Abilitatea "Iederă agăţătoare"
            foreach (PictureBox p in Efecte_ofensive.poze_iedere)
            {
                this.Controls.Add(p);
                p.BringToFront();
            }

            if (nr_tura == Efecte_ofensive.tura_fol_iedera + 2) foreach (PictureBox p in Efecte_ofensive.poze_iedere)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }

            if ((vc_i1 <= 0 && Efecte_ofensive.i1_incalcit == 1) || (vc_i2 <= 0 && Efecte_ofensive.i2_incalcit == 1) || (vc_i3 <= 0 && Efecte_ofensive.i3_incalcit == 1)) //eliminam efectele de incalceala daca inamicul a ajuns la 0 viaţă
            {
                foreach (PictureBox p in Efecte_ofensive.poze_iedere)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                Efecte_ofensive.i1_incalcit = 0; Efecte_ofensive.i2_incalcit = 0; Efecte_ofensive.i3_incalcit = 0;
            }

            //Abilitatile ofensive ale inamicului "Lup"
            //Abilitatea "Urlet lup"
            foreach (PictureBox p in Efecte_ofensive.poze_urlete)
            {

                    if (p.Left == 155 && p.Top == 151 && vc_p1 > 0) this.Controls.Add(p);
                    if (p.Left == 155 && p.Top == 320 && vc_p2 > 0) this.Controls.Add(p);
                    if (p.Left == 155 && p.Top == 493 && vc_p3 > 0) this.Controls.Add(p);
                    p.BringToFront();
            }

            if (Efecte_ofensive.urlet_act == 0) //daca urletul nu se activeaza din nou stergem poza
            {
                foreach (PictureBox p in Efecte_ofensive.poze_urlete) this.Controls.Remove(p);
            }

            foreach (PictureBox p in Efecte_ofensive.poze_sangerare)
            {
                if (p.Left == 115 && p.Top == 151 && vc_p1 > 0) this.Controls.Add(p);
                if (p.Left == 115 && p.Top == 320 && vc_p2 > 0) this.Controls.Add(p);
                if (p.Left == 115 && p.Top == 493 && vc_p3 > 0) this.Controls.Add(p);
                p.BringToFront();
            }
        }

        private void Adaug_poze_sangerari() //adaug pozele cu sangerari daca personajele au rani ce nu s-au vindecat in tura precedenta
        {
            //foreach (PictureBox p in Efecte_ofensive.poze_sangerare)
            //{
            //    if (p.Left == 115 && p.Top == 151 && vc_p1 > 0) this.Controls.Add(p);
            //    if (p.Left == 115 && p.Top == 320 && vc_p2 > 0) this.Controls.Add(p);
            //    if (p.Left == 115 && p.Top == 493 && vc_p3 > 0) this.Controls.Add(p);
            //    p.BringToFront();
            //}

            //foreach (PictureBox p in Efecte_defensive.poze_regenerari)
            //{
            //    if (p.Left == 115 && p.Top == 151 && vc_p1 > 0 && Efecte_defensive.p1_regen==1) this.Controls.Add(p);
            //    if (p.Left == 115 && p.Top == 320 && vc_p2 > 0 && Efecte_defensive.p2_regen == 1) this.Controls.Add(p);
            //    if (p.Left == 115 && p.Top == 493 && vc_p3 > 0 && Efecte_defensive.p3_regen == 1) this.Controls.Add(p);
            //    p.BringToFront();
            //}
        }

        private void Sterg_poze_sangerari() //sterg pozele cu sangerari in dreptul personajelor afectate de "regenerare"
        {
            foreach (PictureBox p in Efecte_ofensive.poze_sangerare)
            {
                if (p.Left == 115 && p.Top == 151 && Efecte_defensive.p1_regen == 1)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                if (p.Left == 115 && p.Top == 320 && Efecte_defensive.p2_regen == 1)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                if (p.Left == 115 && p.Top == 493 && Efecte_defensive.p3_regen == 1)
                {
                this.Controls.Remove(p);
                p.Image = null;
                }
            }
        }

        private void Adaug_poze_scut() //adaug pozele cu scuturi ale razboinicului
        {
            //Abilitatile defensive ale razboinicului
            this.Controls.Add(Efecte_defensive.poza_scut);
            Efecte_defensive.poza_scut.BringToFront();
        }

        private void Adaug_poze_efecte_defensive()
        {
            foreach (PictureBox p in Efecte_defensive.poze_strigate)
            {
                if (nr_tura <= Efecte_defensive.tura_fol_strigat)
                {
                    if (vc_p1 > 0 && p.Left == 195 && p.Top == 151) this.Controls.Add(p);
                    if (vc_p2 > 0 && p.Left == 195 && p.Top == 320) this.Controls.Add(p);
                    if (vc_p3 > 0 && p.Left == 195 && p.Top == 493) this.Controls.Add(p);
                    p.BringToFront();
                }
            }

            foreach (PictureBox p in Efecte_defensive.poze_regenerari)
            {
                this.Controls.Add(p);
                p.BringToFront();
                poz_pers1.BringToFront();
            }

            foreach (PictureBox p in Efecte_defensive.poze_regenerari)
            {
                if (p.Left == 115 && p.Top == 151 && Efecte_defensive.p1_regen == 0)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                if (p.Left == 115 && p.Top == 320 && Efecte_defensive.p2_regen == 0)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
                if (p.Left == 115 && p.Top == 493 && Efecte_defensive.p3_regen == 0)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }

                if (nr_tura >= Efecte_defensive.tura_fol_regen + 1)
                {
                    this.Controls.Remove(p);
                    p.Image = null;
                }
            }
        }

        public static void Resetez_timpi_abilitati() //restez toti timpii de reincarcare la startul unei noi lupte
        {
            ab_fol_p1 = 0; ab_fol_p2 = 0; ab_fol_p3 = 0; ab_fol_i1 = 0; ab_fol_i2 = 0; ab_fol_i3 = 0;
            //resetez timpii efectelor ofensive
            Efecte_ofensive.reincarca_placare_p1 = 0; Efecte_ofensive.reincarca_placare_p2 = 0; Efecte_ofensive.reincarca_placare_p3 = 0;
            Efecte_ofensive.reincarca_tintire_p1 = 0; Efecte_ofensive.reincarca_tintire_p2 = 0; Efecte_ofensive.reincarca_tintire_p3 = 0;
            Efecte_ofensive.reincarca_sag_p1 = 0; Efecte_ofensive.reincarca_sag_p2 = 0; Efecte_ofensive.reincarca_sag_p3 = 0;
            Efecte_ofensive.reincarca_sag_dubl_p1 = 0; Efecte_ofensive.reincarca_sag_dubl_p2 = 0; Efecte_ofensive.reincarca_sag_dubl_p3 = 0;
            Efecte_ofensive.reincarca_ploaie_sag_p1 = 0; Efecte_ofensive.reincarca_ploaie_sag_p2 = 0; Efecte_ofensive.reincarca_ploaie_sag_p3 = 0;
            Efecte_ofensive.reincarca_sfera_foc_p1 = 0; Efecte_ofensive.reincarca_sfera_foc_p2 = 0; Efecte_ofensive.reincarca_sfera_foc_p3 = 0;
            Efecte_ofensive.reincarca_viscol_p1= 0; Efecte_ofensive.reincarca_viscol_p2 = 0; Efecte_ofensive.reincarca_viscol_p3 = 0;
            Efecte_ofensive.reincarca_iedera_p1 = 0; Efecte_ofensive.reincarca_iedera_p2 = 0; Efecte_ofensive.reincarca_iedera_p3 = 0;

            //resetez timpii efectelor defensive
            Efecte_defensive.reincarca_strigat_p1 = 0; Efecte_defensive.reincarca_strigat_p2 = 0; Efecte_defensive.reincarca_strigat_p3 = 0;
            Efecte_defensive.reincarca_regen_p1 = 0; Efecte_defensive.reincarca_regen_p2 = 0; Efecte_defensive.reincarca_regen_p3 = 0;
            Efecte_defensive.reincarca_vind_mas_p1 = 0; Efecte_defensive.reincarca_vind_mas_p2 = 0; Efecte_defensive.reincarca_vind_mas_p3 = 0;
        }

        private void p1_a1_click(object sender, EventArgs e) //click pe abilitatea din primul slot a personajului 1
        {
            if (ab_fol_p1 == 0) Abilitate_selectata_personaj(1, 1);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate in tura aceasta");
        }

        private void ab2_pers1_Click(object sender, EventArgs e) //click pe abilitatea din al doilea slot a personajului 1
        {
            if (ab_fol_p1 == 0) Abilitate_selectata_personaj(1, 2);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate in tura aceasta");
        }

        private void ab3_pers1_Click(object sender, EventArgs e) //click pe abilitatea din al treilea slot a personajului 1
        {
            if (ab_fol_p1 == 0) Abilitate_selectata_personaj(1, 3);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate in tura aceasta");
        }

        private void ab4_pers1_Click(object sender, EventArgs e)
        {
            if (ab_fol_p1 == 0) Abilitate_selectata_personaj(1, 4);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab1_pers2_Click(object sender, EventArgs e) //click pe a prima abilitate a personajului 2
        {
            if (ab_fol_p2 == 0) Abilitate_selectata_personaj(2, 1);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab2_pers2_Click(object sender, EventArgs e) //click pe a doua abilitate a personajului 2
        {
            if (ab_fol_p2 == 0) Abilitate_selectata_personaj(2, 2);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab3_pers2_Click(object sender, EventArgs e) //click pe a treia abilitate a personajului 2
        {
            if (ab_fol_p2 == 0) Abilitate_selectata_personaj(2, 3);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab4_pers2_Click(object sender, EventArgs e) //click pe a patra abilitate a personajului 2
        {
            if (ab_fol_p2 == 0) Abilitate_selectata_personaj(2, 4);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab1_pers3_Click(object sender, EventArgs e) //click pe a prima abilitate a personajului 3
        {
            if (ab_fol_p3 == 0) Abilitate_selectata_personaj(3, 1);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void p3_a2_click(object sender, EventArgs e) //click pe a doua abilitate a personajului 3
        {
            if (ab_fol_p3 == 0) Abilitate_selectata_personaj(3, 2);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab3_pers3_Click(object sender, EventArgs e) //click pe a treia abilitate a personajului 3
        {
            if (ab_fol_p3 == 0) Abilitate_selectata_personaj(3, 3);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void ab4_pers3_Click(object sender, EventArgs e) //click pe a patra abilitate a personajului 3
        {
            if (ab_fol_p3 == 0) Abilitate_selectata_personaj(3, 4);
            else MessageBox.Show("Acest personaj a folosit deja\n o abilitate în tura aceasta");
        }

        private void poz_pers1_Click(object sender, EventArgs e) //click pe portretul primului personaj
        {
            if (vc_p1 > 0) //abilitatea nu va functiona daca aliatul are 0 viata
            {
                if (mem_ab_af == 2 || mem_ab_af == 4)//daca s-a selectat o abilitate care afecteaza un singur aliat sau toti aliatii
                {
                    mem_pers_af = 1;
                    Abilitati.Centralizator_abilitati_defensive(pers_sel, mem_ab_sel, mem_pers_af); //abilitatea cu id-ul mem_ab_sel afecteza personajul din slot-ul mem_pers_af
                    Adaug_poze_efecte_defensive();
                    Sterg_poze_sangerari();
                    if (mem_ab_af == 2) viata_pers1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p1, vc_p1); //updatez bara de viata a personajului din slot-ul 1 daca abilitatea afecteaza un singur personaj
                    else if (mem_ab_af == 4) Updatez_bare_viata(); //updatez bara de viata a tuturor personajelor
                    Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
                    Adaug_poze_scut();
                    Adaug_poze_sangerari();
                    Sterg_poze_sangerari();
                    poz_pers1.BringToFront(); //daca nu pun asta se taie din poza primului personaj (nu stiu de ce)
                }
            }
            else MessageBox.Show("Aliatul e prea grav ranit pentru ca \n aceasta abilitate sa functioneze");
            poz_pers1.BringToFront(); //daca nu pun asta apare un bug ciudat cu poza de sus (nu stiu de ce)
        }

        private void poz_pers2_Click(object sender, EventArgs e) //click pe portretul celui de-al doilea personaj
        {
            if (vc_p2 > 0) //abilitatea nu va functiona daca aliatul are 0 viata
            {
                if (mem_ab_af == 2 || mem_ab_af == 4)//daca s-a selectat o abilitate care afecteaza un singur aliat sau toti aliatii
                {
                    mem_pers_af = 2;
                    Abilitati.Centralizator_abilitati_defensive(pers_sel, mem_ab_sel, mem_pers_af); //abilitatea cu id-ul mem_ab_sel afecteza personajul din slot-ul mem_pers_af
                    if (mem_ab_af == 2) viata_pers2.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p2, vc_p2); //updatez bara de viata a personajului din slot-ul 2 daca abilitatea afecteaza un singur personaj
                    else if (mem_ab_af == 4) Updatez_bare_viata(); //updatez bara de viata a tuturor personajelor
                    Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
                    Adaug_poze_efecte_defensive();
                    Adaug_poze_sangerari();
                    Sterg_poze_sangerari();
                    Adaug_poze_scut();
                }
            }
            else MessageBox.Show("Aliatul e prea grav ranit pentru ca \n aceasta abilitate sa functioneze");
            poz_pers1.BringToFront(); //daca nu pun asta apare un bug ciudat cu poza de sus (nu stiu de ce)
        }

        private void poz_pers3_Click(object sender, EventArgs e) //click pe portretul celui de-al treilea personaj
        {
            poz_pers1.BringToFront();
            if (vc_p3 > 0) //abilitatea nu va functiona daca aliatul are 0 viata
            {
                if (mem_ab_af == 2 || mem_ab_af == 4)//daca s-a selectat o abilitate care afecteaza un singur aliat sau toti aliatii
                {
                    mem_pers_af = 3;
                    Abilitati.Centralizator_abilitati_defensive(pers_sel, mem_ab_sel, mem_pers_af); //abilitatea cu id-ul mem_ab_sel afecteza personajul din slot-ul mem_pers_af
                    if (mem_ab_af == 2) viata_pers3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p3, vc_p3); //updatez bara de viata a personajului din slot-ul 3 daca abilitatea afecteaza un singur personaj
                    else if (mem_ab_af == 4) Updatez_bare_viata(); //updatez bara de viata a tuturor personajelor
                    Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
                    Adaug_poze_efecte_defensive();
                    Adaug_poze_sangerari();
                    Sterg_poze_sangerari();
                    Adaug_poze_scut();
                }
            } else MessageBox.Show("Aliatul e prea grav ranit pentru ca \n aceasta abilitate sa functioneze");
            poz_pers1.BringToFront(); //daca nu pun asta apare un bug ciudat cu poza de sus (nu stiu de ce)
        }

        private void i1_click(object sender, EventArgs e) //click pe portretul primului inamic
        {
            if (vc_i1>0) //atacul nu va functiona daca inamicul e deja mort
            {
                if (mem_ab_af == 1 || mem_ab_af == 3)//daca s-a selectat o abilitate care afecteaza un singur inamic sau toti inamicii
                {
                    mem_inm_af = 1;
                    Abilitati.Centralizator_abilitati_ofensive(pers_sel, mem_ab_sel, mem_inm_af); //abilitatea cu id-ul mem_ab_sel afecteza inamicul din slot-ul mem_inm_af
                    if (mem_ab_af==1) viata_inm1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i1, vc_i1); //updatez bara de viata a inamicului din slot-ul 1
                    else if (mem_ab_af == 3) Updatez_bare_viata(); //daca s-a folosit o abilitate care afecteaza toti inamicii updatez bara de viata a tuturor
                    Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
                }
            }
            Poze_0_viata(); //daca atacul omoara un inamic schimba poza inamicului cu un x rosu
            Verific_0_viata(); //verific daca toti inamicii au fost invinsi
            Adaug_poze_efecte_ofensive(); //Adaug pozele efectelor ofensive cauzate de abilitatile personajelor (daca exista)
            Adaug_poze_sangerari();
            Sterg_poze_sangerari();
        }

        private void i2_click(object sender, EventArgs e) //click pe portretului celui de-al doilea inamic
        {
            if (mem_ab_af==1 || mem_ab_af==3)//daca s-a selectat o abilitate care afecteaza un singur inamic sau toti inamicii
            {
                mem_inm_af = 2; 
                Abilitati.Centralizator_abilitati_ofensive(pers_sel,mem_ab_sel,mem_inm_af); //abilitatea cu id-ul mem_ab_sel afecteza inamicul din slot-ul mem_inm_af
                if (mem_ab_af == 1) viata_inm2.Image=Bare.Update_bara_viata(bar_latime,bar_inaltime,vmax_i2,vc_i2); //updatez bara de viata a inamicului din slot-ul 2
                else if (mem_ab_af == 3) Updatez_bare_viata(); //daca s-a folosit o abilitate care afecteaza toti inamicii updatez bara de viata a tuturor
                Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
            }
            Poze_0_viata(); //daca atacul omoara un inamic schimba poza inamicului cu un x rosu     
            Verific_0_viata(); //verific daca toti inamicii au fost invinsi
            Adaug_poze_efecte_ofensive(); //Adaug pozele efectelor ofensive cauzate de abilitatile personajelor (daca exista)
            Adaug_poze_sangerari();
            Sterg_poze_sangerari();
        }

        private void i3_click(object sender, EventArgs e)
        {
            if (mem_ab_af == 1 || mem_ab_af == 3)//daca s-a selectat o abilitate care afecteaza un singur inamic sau toti inamicii
            {
                mem_inm_af = 3;
                Abilitati.Centralizator_abilitati_ofensive(pers_sel,mem_ab_sel, mem_inm_af); //abilitatea cu id-ul mem_ab_sel afecteza inamicul din slot-ul mem_inm_af
                if (mem_ab_af == 1) viata_inm3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i3, vc_i3); //updatez bara de viata a inamicului din slot-ul 3
                else if (mem_ab_af == 3) Updatez_bare_viata(); //daca s-a folosit o abilitate care afecteaza toti inamicii updatez bara de viata a tuturor
                Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje
            }
            Poze_0_viata(); //daca atacul omoara un inamic schimba poza inamicului cu un x rosu 
            Verific_0_viata(); //verific daca toti inamicii au fost invinsi
            Adaug_poze_efecte_ofensive(); //Adaug pozele efectelor ofensive cauzate de abilitatile personajelor (daca exista)
            Adaug_poze_sangerari();
            Sterg_poze_sangerari();
        }

        private void Act_schimb_tura_vs_3lupi() //Aici pun toate verificarile si actiunile cand schim tura (in cazul asta ma lupt cu 3 lupi)
        {
            reduc_mem_p1 = reduc_p1; reduc_mem_p2 = reduc_p2; reduc_mem_p3 = reduc_p3; //memorez punctele de reducere a personajelor (pt ca punctele de reducere sa ramana in cazul in care ataca mai multi inamici)
            reduc_mem_i1 = reduc_i1; reduc_mem_i2 = reduc_i2; reduc_mem_i3 = reduc_i3; //memorez punctele de reducere a inamicilor (pt ca punctele de reducere sa ramana in cazul in care ataca mai multi inamici)
            pers_sel = 0; //deselectam slotul personajului ce actioneaza
            ab_fol_p1 = 0; ab_fol_p2 = 0; ab_fol_p3 = 0; //deblocam abilitatile tuturor personajelor
            ab_sel_p1 = 0; ab_sel_p2 = 0; ab_sel_p3 = 0; //deselectam toate abilitatile (daca ramasesera selectate)
            mem_ab_sel = 0; mem_inm_af = 0; mem_ab_af = 0; //deselectam toate abilitatile (daca ramasesera selectate)
            Efecte_ofensive.Inamicul_e_placat(nr_tura); //aplicam/stergem efectele placarii daca vreun inamic e placat
            Efecte_ofensive.Inamicul_e_tintit(nr_tura); //aplicam/stergem efectele tintirii daca vreun inamic e tintit
            Efecte_ofensive.Reincarc_Lovituri_Sageti(); //vedem daca loviturile de sageti simple si duble s-au reincarcat
            Efecte_ofensive.Reincarc_ploaie_sageti(); //vedem daca ploaia de săgeţi s-a reîncărcat
            Efecte_defensive.Strigatul_e_activat(nr_tura); //eliminam efectele strigatului de lupta daca a fost folosit in tura anterioara
            Efecte_defensive.Reincarc_vindecare_mas(); //reincarc vindecarea de masa daca a fost folosita
            Efecte_ofensive.Inamicul_e_ars(nr_tura); //scadem viata inamicilor arsi
            Efecte_ofensive.Viscoleste(nr_tura); //aplicam daune din viscolire si efecte de degerare
            Efecte_ofensive.Personajul_sangerezaza(); //scadem viata personajului care sangereaza
            this.Controls.Remove(Efecte_defensive.poza_scut); //sterg poza scutirilor
            foreach (PictureBox p in Efecte_defensive.poze_strigate) this.Controls.Remove(p); //sterg poza strigatelor de lupta
            Efecte_defensive.Sterg_scutirile_anterioare(20);
            Efecte_defensive.Personaj_regen(nr_tura); //aplic efecte de regenerare pt un personaj
            AI_3_lupi.Actiune_lup1(); //Actioneaza lupul 1
            AI_3_lupi.Actiune_lup2(); //Actioneaza lupul 2
            AI_3_lupi.Actiune_lup3(); //Actioneaza lupul 3
            Efecte_ofensive.Inamicul_e_incalcit(nr_tura); //aplicam efecte de incalcire daca inamicul e afectat de "Iedera agatatoare"
            Efecte_ofensive.Urlet_lup(AI_3_lupi.urlet_lup1_act); //vedem daca urletul lupului 1 e in efect
            Updatez_bare_energie(); //Updatez barele de energie a celor 3 personaje si 3 inamici
            viata_pers1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p1, vc_p1); //updatez bara de viata a personajului din slot-ul 1
            viata_pers2.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p2, vc_p2); //updatez bara de viata a personajului din slot-ul 2
            viata_pers3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_p3, vc_p3); //updatez bara de viata a personajului din slot-ul 3
            viata_inm1.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i1, vc_i1); //updatez bara de viata a inamicului din slot-ul 1
            viata_inm2.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i2, vc_i2); //updatez bara de viata a inamicului din slot-ul 2
            viata_inm3.Image = Bare.Update_bara_viata(bar_latime, bar_inaltime, vmax_i3, vc_i3); //updatez bara de viata a inamicului din slot-ul 3
            Poze_0_viata(); //inlocuieste pozele inamicilor/aliatilor eliminati cu un x rosu
            Verific_0_viata(); //verific daca in urma efectelor pasive personajele sau inamicii au fost invinsi
            Adaug_poze_efecte_ofensive();
            Adaug_poze_efecte_defensive();
            Sterg_poze_sangerari();
            nr_tura = nr_tura + 1;
        }

        private void sfarsit_tura_Click(object sender, EventArgs e) //Butonul "Sfarsit tura"
        {
            if (ab_fol_p1 == 0 || ab_fol_p2 == 0 || ab_fol_p3 == 0)
            {
                string s = "Nu toate personajele au actionat\n Sigur doriti sa sfârsiti tura?";
                Confirmare cf = new Confirmare(s);
                if (cf.ShowDialog() == DialogResult.Cancel) cf.Close();
                else if (cf.DialogResult == DialogResult.OK)
                {
                    Act_schimb_tura_vs_3lupi();
                }
            }
            else Act_schimb_tura_vs_3lupi();
        }
    }
}
