using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinet_medical
{
    public partial class Confirmare : Form
    {
      string c;
        public Confirmare(string tip_confirmare)
        {
            c = tip_confirmare;
            InitializeComponent();

            if (c=="fin")
            {
                text_conf.Text = "Doriti sa finalizati prescriptia \n pacientului "+Ad_pres1.mempac+" ?";
            }

            if (c == "ren")
            {
                text_conf.Text = "Doriti sa anulati prescriptia \n pacientului "+ Ad_pres1.mempac +"?";
            }
        }
    }
}
