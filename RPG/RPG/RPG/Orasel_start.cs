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
    public partial class Orasel_start : Form
    {
        public Orasel_start()
        {
            InitializeComponent();

            ToolTip descriere = new ToolTip(); //descrierea 
            this.WindowState = FormWindowState.Maximized; //Intind fereastra cat permite ecranul

            han.Location = new Point(590, -10); //imaginea hanului
            han.Size = new System.Drawing.Size(220, 445);

            ies.Location = new Point(0, 530); //imaginea iesirii din orasel
            ies.Size = new System.Drawing.Size(180, 130);
        }

        private void han_MouseHover(object sender, EventArgs e) //Imaginea se va colora diferit cand fac hover cu mouse-ul peste ea
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            han.SendToBack();
            han_t.BringToFront();
            han_t.Image = Image.FromFile("Harti\\han.jpg");
            han_t.SizeMode = PictureBoxSizeMode.StretchImage;
            han_t.Location = new Point(900, 120); //imaginea hanului
            han_t.Size = new System.Drawing.Size(185, 440);
            descriere.SetToolTip(han_t,"                  Hanul: \n Locul unde  se pot primi sarcini \n iar grupul se poate odihni");
        }

        private void han_t_MouseLeave(object sender, EventArgs e) //Imaginea se decoloreaza cand mouse-ul paraseste zona hanului
        {
            han.BringToFront();
        }

        private void ies_MouseHover(object sender, EventArgs e) //Imaginea se va colora diferit cand fac hover cu mouse-ul peste iesire
        {
            ToolTip descriere = new ToolTip(); //descrierea 
            ies.SendToBack();
            ies_t.BringToFront();
            ies_t.Image = Image.FromFile("Harti\\ies.jpg");
            ies_t.SizeMode = PictureBoxSizeMode.StretchImage;
            ies_t.Location = new Point(0, 530); //imaginea iesirii din orasel
            ies_t.Size = new System.Drawing.Size(165, 140);
            descriere.SetToolTip(ies_t, "Ieşirea din orăşel");
        }

        private void ies_t_MouseDoubleClick(object sender, MouseEventArgs e) //daca dau dublu click pe iesire trebuie sa imi apara harta lumii
        {
            Harta_lume lume = new Harta_lume();
            lume.ShowDialog();
            this.Close(); //inchidem fereastra curenta cu oraselul
        }

        private void ies_t_MouseLeave(object sender, EventArgs e) //Imaginea se decoloreaza cand mouse-ul paraseste zona iesirii din orasel
        {
            ies.BringToFront();
        }
    }
}
