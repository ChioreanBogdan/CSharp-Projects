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
    public partial class Confirmare : Form
    {
        public Confirmare(string s)
        {
            InitializeComponent();
            Text_Confirm.Text = s;
        }
    }
}
