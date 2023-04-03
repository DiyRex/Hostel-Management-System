using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class spalsh : Form
    {
        public spalsh()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            bunifuProgressBar1.Value = bunifuProgressBar1.Value + 2;
            if (bunifuProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                authentication form1 = new authentication();
                form1.Show();
            }
        }
    }
}
