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
    public partial class Harta_lume : Form
    {
        public static int id_teren_ostil=0; //se foloseste la teren ostil,in functie de aceasta variabila se va schimba poza de fundal

        public Harta_lume()
        {
            InitializeComponent();

            id_teren_ostil = 0; //initializem aceasta variabila cu 0 apoi va capata valori in functie de zona accesata
            this.WindowState = FormWindowState.Maximized; //Intind fereastra cat permite ecranul
            //da_wey.Image = Deseneaza_cale();
            da_wey.SendToBack(); //ca sa desenez linie intrerupta pt a desena 

            codrii_ruginii.Location= new Point(550, 200); //label-ul cu numele codrului
            codrii_ruginii.BringToFront(); //aducem label-ul in fata

            codru.Location = new Point(460, 0); //imaginea codrului
            codru.Size = new System.Drawing.Size(270, 290);

            corbeni_l.Location = new Point(860, 210); //label-ul cu numele oraselului
            corbeni_l.BringToFront(); //aducem label-ul in fata

            corbeni.Location = new Point(850, 150); //imaginea oraselului
            corbeni.Size = new System.Drawing.Size(120, 120);

        }

        public static Bitmap Deseneaza_cale() //deseneaza o linie intrerupta pe harta
        {
            Bitmap bmp;
            Graphics g;

            bmp = new Bitmap(1200, 1200);
            g = Graphics.FromImage(bmp);

            Point[] puncte_codru = { new Point(0, 0), new Point(1000, 200) }; //new Point(0, 120), new Point(0, 180), new Point(0, 1000) };
            Pen pen= new Pen (Color.Black);
            pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
            pen.Width = 0.001F;
            g.DrawCurve(pen, puncte_codru);

            return bmp;
        }

        private void codru_MouseHover(object sender, EventArgs e) //cand umblu cu mouse-ul peste poza codrilor
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            codru.SendToBack();
            codru_t.BringToFront();
            codru_t.Image = Image.FromFile("Harti\\codrii_ruginii.jpg");
            codru_t.SizeMode = PictureBoxSizeMode.StretchImage;
            codru_t.Location = new Point(460,0); //imaginea iesirii din orasel
            codru_t.Size = new System.Drawing.Size(270, 255);
            descriere.SetToolTip(codru_t, "Cea mai mare pădure din această zonă");
        }

        private void codrii_ruginii_MouseHover(object sender, EventArgs e) //cand umblu cu mouse-ul peste numele "Codrii ruginii"
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            codru.SendToBack();
            codru_t.BringToFront();
            codru_t.Image = Image.FromFile("Harti\\codrii_ruginii.jpg");
            codru_t.SizeMode = PictureBoxSizeMode.StretchImage;
            codru_t.Location = new Point(460, 0); //imaginea iesirii din orasel
            codru_t.Size = new System.Drawing.Size(270, 255);
            descriere.SetToolTip(codru_t, "Cea mai mare pădure din această zonă");
        }

        private void codru_t_MouseLeave(object sender, EventArgs e) //Imaginea se decoloreaza cand mouse-ul paraseste zona iesirii din codru
        {
            codru.BringToFront();
            codrii_ruginii.BringToFront();
        }

        private void codru_t_DoubleClick(object sender, EventArgs e) //dublu click pe poza codrului
        {
            id_teren_ostil = 1; //1 corespunde terenului ostil codru (ar trebui adaptata cu baza de date daca mai e timp)
            Teren_ostil codrii_ruginii = new Teren_ostil();
            codrii_ruginii.ShowDialog();
            this.Close(); //inchidem fereastra curenta cu harta lumii
        }

        private void corbeni_MouseHover(object sender, EventArgs e) //cand umblu cu mouse-ul peste poza oraselului "Corbeni"
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            corbeni.SendToBack();
            corbeni_t.BringToFront();
            corbeni_t.Image = Image.FromFile("Harti\\Corbeni.jpg");
            corbeni_t.SizeMode = PictureBoxSizeMode.StretchImage;
            corbeni_t.Location = new Point(870, 150); //imaginea iesirii din orasel
            corbeni_t.Size = new System.Drawing.Size(100,100);
            descriere.SetToolTip(corbeni_t, "Un orăşel izolat");
        }

        private void corbeni_l_MouseHover(object sender, EventArgs e) //cand umblu cu mouse-ul peste numele oraselului "Corbeni"
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            corbeni.SendToBack();
            corbeni_t.BringToFront();
            corbeni_t.Image = Image.FromFile("Harti\\Corbeni.jpg");
            corbeni_t.SizeMode = PictureBoxSizeMode.StretchImage;
            corbeni_t.Location = new Point(870, 150); //imaginea iesirii din orasel
            corbeni_t.Size = new System.Drawing.Size(100, 100);
            descriere.SetToolTip(corbeni_t, "Un orăşel izolat");
        }

        private void corbeni_t_MouseLeave(object sender, EventArgs e) //Imaginea se decoloreaza cand mouse-ul paraseste zona oraselului
        {
            corbeni.BringToFront();
            corbeni_l.BringToFront();
        }
    }
}
