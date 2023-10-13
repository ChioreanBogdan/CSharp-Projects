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
    public partial class Setari : Form
    {
        public Setari()
        {
            InitializeComponent();
            button2.Enabled = false; //nu am programat inca nimic pentru "Setari interfata"
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Setări audio"
        {
            Audio aud = new Audio();
            aud.ShowDialog();
            //Audio.muz_player.controls.stop();
        }

        private void button3_Click(object sender, EventArgs e) //Butonul "Înapoi"
        {
            this.Close();
        }
    }
}
