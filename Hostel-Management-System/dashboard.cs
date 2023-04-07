using System;
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
            //this.studentsPanal.Show();
            //this.dashboardPanal.Hide();
            // this.btnStudents.BackColor = Color.FromArgb(23, 110, 196);



        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //this.studentsPanal.Hide();
            //this.dashboardPanal.Show();

        }

        private void dashboardPanal_Load(object sender, EventArgs e)
        {
            //this.studentsPanal.Hide();
            //this.dashboardPanal.Show();
        }

        private void dashboardPanal_Load_1(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            //if (authentication.session_user != null)
            //{
            //    lblLoggedUsr.Text = authentication.session_user;
            //    Refresh();
            //}
            //else
            //{
            //    lblLoggedUsr.Text = "No User";
            //}

        }
    }
}
