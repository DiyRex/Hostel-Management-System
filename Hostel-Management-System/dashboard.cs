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
        DataTable dt = new DataTable();

        public dashboard()
        {
            InitializeComponent();
        }
        private void addData()
        {
            DBConnection db = new DBConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users`", db.getConnection);

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                bunifuDataGridView1.Rows.Add(dr.ItemArray);
                // //DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                // {
                //    button.Name = "button";
                //     button.HeaderText = "Button";
                //    button.Text = "Button";
                //    button.UseColumnTextForButtonValue = true; //dont forget this line
                //    this.bunifuDataGridView1.Columns.Add(button);
                // }

            }
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            addData();
        }
    }
}
