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
    public partial class Mesaj_atac : Form
    {
        public static int crono; //numara 5 secunde dupa care inchide fereastra
        public Mesaj_atac(String s)
        {
            InitializeComponent();
            crono = 0;
            timer_msg_atc.Interval = 1000;
            timer_msg_atc.Enabled = true;
            desc_atac.Text =s;

            timer_msg_atc.Tick += new EventHandler(timer_msg_atc_Tick);
        }

        private void timer_msg_atc_Tick(object sender, EventArgs e)
        {
            timer_msg_atc.Start();
            if (crono >= 5) this.Close();
            else crono = crono + 1;
        }
    }
}
