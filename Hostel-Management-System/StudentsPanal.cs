﻿using MySql.Data.MySqlClient;
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
    public partial class StudentsPanal : UserControl
    {

        public StudentsPanal()
        {
            InitializeComponent();
        }
        private void addData()
        {
            DBConnection db = new DBConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users`", db.getConnection);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                bunifuDataGridView1.Rows.Add(dr.ItemArray);

            }
        }
            private void StudentsPanal_Load(object sender, EventArgs e)
        {
            addData();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton4_Click(object sender, EventArgs e)
        {
            StudentProfileUpdate bio = new StudentProfileUpdate();
            bio.Show();
        }
    }
}
