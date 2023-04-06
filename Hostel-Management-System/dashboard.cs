using MySql.Data.MySqlClient;
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
    public partial class dashboard : Form
    {


        public dashboard()
        {
            InitializeComponent();
        }
        

        private void btnStudents_Click(object sender, EventArgs e)
        {
            this.studentsPanal.Show();
            this.dashboardPanal.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.studentsPanal.Hide();
            this.dashboardPanal.Show();
        }

        private void dashboardPanal_Load(object sender, EventArgs e)
        {
            this.studentsPanal.Hide();
            this.dashboardPanal.Show();
        }
    }
}
