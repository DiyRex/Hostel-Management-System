using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hostel_Management_System
{
    public partial class authentication : Form
    {
        public object BunifuTextBox1 { get; private set; }
        public static string session_user;

        public authentication()
        {
            InitializeComponent();
            this.ActiveControl = username;
            username.Focus();
        }

        private void loguser(string username, string password)
        {
            
            DBConnection db = new DBConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `UNAME`=@name AND `UPASSWD`=@pwd", db.getConnection);

            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                session_user = username;
                this.DialogResult = DialogResult.OK;
                MainWIndow dash = new MainWIndow();
                this.Hide();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }

        private int cnt = 1;


        private void bunifuToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            if (bunifuToggleSwitch21.Checked)
            {
                grpbox1.Visible = false;
            }
            else
            {
                grpbox1.Visible = true;
            }
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public void InsertData(string username, string email, string password)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=users;";
            string queryx = "INSERT INTO users (Default, 'UNAME', 'UMAIL', 'UPASSWD')'" + username + "' and UPASSWD='" + password + "'";
            string query = $"INSERT INTO `users` (`UID`, `UNAME`, `UMAIL`, `UPASSWD`) VALUES (NULL, '{username}', '{email}', '{password}');";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                try
                {
                    reader = commandDatabase.ExecuteReader();
                    DialogResult dialog = MessageBox.Show($"User {username} Added !!");
                    if (dialog == DialogResult.OK)
                    {
                        grpbox1.Visible = true;
                        bunifuToggleSwitch21.Checked = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            string email = tbemail.Text;
            string authkey = tbauthkey.Text;

            string verifiedKey = "FTHMS";

            if (authkey == verifiedKey)
            {
                InsertData(username: username, password: password, email: email);
            }
            else { MessageBox.Show("Invalid AuthKey !!"); }


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = bunifuTextBox2.Text;
            loguser(username, password);
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuTextBox2.Focus();
                e.Handled = true;
            }
        }
    }
}
