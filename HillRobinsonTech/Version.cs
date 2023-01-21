using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HillRobinsonTech
{
    public partial class Version : Form
    {
        public Version()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_VisibleChanged(object sender, EventArgs e)
        {
            lbversiune.Text = "Version " + Util.fullVersionInfo;
        }
    }
}
