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
    public partial class RPG : Form
    {
        public RPG()
        {
            InitializeComponent();
            Audio_player.playm(); //playm e playerul pentru muzica
            Audio_player.plays(); //plays e playerul pentru sunete

            button2.Enabled=false; //"butonul incarca"-nu au fost inca scrise functiile pentru incarcare
            button3.Enabled = false; //"butonul incarca"-nu au fost inca scrise functiile pentru salvare

            test.Visible = false; orasel_test.Visible = false; //butoanele pt teste rapide a luptei
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Joc nou"
        {
            Creare_personaje cp = new Creare_personaje();
            cp.ShowDialog();
        }

        private void set_Click(object sender, EventArgs e) //Butonul "Setări"
        {
            Setari set = new Setari();
            set.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) //Butonul "Ieșire"
        {
            Application.Exit();
        }

        private void test_Click(object sender, EventArgs e) //Butonul pt test ecran lupta NU UITA SA IL STERGI!
        {
            Lupta lupt = new Lupta();
            lupt.ShowDialog();
        }

        private void orasel_test_Click(object sender, EventArgs e)
        {
            Orasel_start orasel = new Orasel_start();
            orasel.ShowDialog();
        }
    }
}
