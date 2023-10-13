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
    public partial class Teren_ostil : Form
    {
        public Teren_ostil()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Intind fereastra cat permite ecranul

            if (Harta_lume.id_teren_ostil==1)
            {
                this.Name = "Codrii ruginii"; //schimbam denumirea si imaginea functie de locul in care a intrat grupul meu
                this.BackgroundImage = Image.FromFile("Harti\\codru.jpg");
                Lupta_noua.Text = "Mergi mai departe în codru";
                Inapoi.Text = "Întoarce-te înapoi";
            }
        }

        private void Lupta_noua_Click(object sender, EventArgs e) //butonul pt a genera o lupta cu inamicii locali
        {
            String msg = "Grupul tau e atacat \n        de niste lupi";
            Mesaj_atac msg_atc = new Mesaj_atac(msg);
            msg_atc.ShowDialog();

            Lupta lupt = new Lupta();
            lupt.Name = "lupt";
            lupt.ShowDialog();
        }

        private void Inapoi_Click(object sender, EventArgs e) //butonul pentru revenirea la harta lumii
        {
            Harta_lume lume = new Harta_lume();
            lume.ShowDialog();
            this.Close(); //inchidem fereastra curenta cu terenul ostil
        }
    }
}
