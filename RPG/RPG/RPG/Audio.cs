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
    public partial class Audio : Form
    {
        public static int muz_aud = 1; //variabila ce va fi "1" daca muzica e pornita si "0" daca e oprita
        public static int sun_aud = 1; //variabila ce va fi "1" daca sunetele sunt pornite si "0" daca sunt oprite

        public Audio()
        {
            InitializeComponent();
            volmuz.Minimum = 0;
            volmuz.Maximum = 110;
            volmuz.Value = Audio_player.muz_player.settings.volume;

            volsun.Minimum = 0;
            volsun.Maximum = 110;
            volsun.Value = Audio_player.sun_player.settings.volume;
        }

        private void poz_volmuz_Click(object sender, EventArgs e) //click pe pictograma audio de la muzica
        {
            if (muz_aud == 1)
            {
                poz_volmuz.BackgroundImageLayout = ImageLayout.Stretch;
                poz_volmuz.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound on.jpg");
                Audio_player.muz_player.settings.mute = true;
                volmuz.Value =0; //duc bara de volum la 0
                Audio_player.muz_player.settings.volume = volmuz.Value; //setez volumul
                muz_aud = 0;
            }
            else if (muz_aud == 0)
            {
                Audio_player.muz_player.settings.volume = volmuz.Value;
                poz_volmuz.BackgroundImageLayout = ImageLayout.Stretch;
                poz_volmuz.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound off.jpg");
                Audio_player.muz_player.settings.mute = false;
                volmuz.Value = 50; //duc bara de volum la 50
                Audio_player.muz_player.settings.volume = volmuz.Value; //setez volumul
                muz_aud = 1;
            }
        }

        private void poz_volsun_Click(object sender, EventArgs e) //click pe pictograma audio de la sunete
        {
            if (sun_aud == 1)
            {
                poz_volsun.BackgroundImageLayout = ImageLayout.Stretch;
                poz_volsun.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound on.jpg");
                Audio_player.sun_player.settings.mute = true;
                volsun.Value = 0; //duc bara de volum la 0
                Audio_player.sun_player.settings.volume = volsun.Value; //setez volumul
                sun_aud = 0;
            }
            else if (sun_aud == 0)
            {
                Audio_player.sun_player.settings.volume = volsun.Value;
                poz_volsun.BackgroundImageLayout = ImageLayout.Stretch;
                poz_volsun.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound off.jpg");
                Audio_player.sun_player.settings.mute = false;
                volsun.Value = 70; //duc bara de volum la 70
                Audio_player.sun_player.settings.volume = volsun.Value; //setez volumul
                sun_aud = 1;
            }
        }

        private void volmuz_Scroll(object sender, EventArgs e) //controlez ce se intampla cand trag de slider-ul pt volumul muzicii
        {
            Audio_player.muz_player.settings.volume = volmuz.Value;
            if (volmuz.Value > 0)
            {
                poz_volmuz.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound off.jpg");
                muz_aud = 1;
            }
            else if (volmuz.Value == 0)
            {
                poz_volmuz.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound on.jpg");
                muz_aud = 0;
            }
        }

        private void volsun_Scroll(object sender, EventArgs e) //controlez ce se intampla cand trag de slider-ul pt volumul sunetelor ambientale
        {
            Audio_player.sun_player.settings.volume = volsun.Value;
            if (volsun.Value > 0)
            {
                poz_volsun.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound off.jpg");
                sun_aud = 1;
            }
            else if (volmuz.Value == 0)
            {
                poz_volsun.BackgroundImage = System.Drawing.Image.FromFile(@"C:\postuniv\C#\RPG\RPG\RPG\Resources\Sound on.jpg");
                sun_aud = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e) //butonul "Înapoi" inchide fereastra dupa ce userul a reglat sau nu volumul
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //butonul "Resetează" duce ambele volume inapoi la valoarea "default" de 50
        {
            Audio_player.muz_player.settings.volume = 50;
            Audio_player.sun_player.settings.volume = 70;
            volmuz.Value = 50;
            volsun.Value = 70;
        }
    }
}
