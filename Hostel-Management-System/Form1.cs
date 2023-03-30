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
    public partial class Form1 : Form
    {
        public object BunifuTextBox1 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username = bunifuTextBox1.Text;
            string password = bunifuTextBox2.Text;


            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=users;";
            string query = "SELECT * FROM users where UNAME='" + username + "' and UPASSWD='" + password + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Authorized User");
                    }
                }
                else
                {
                    //MessageBox.Show("Invalid Login");
                    DialogResult dialog = MessageBox.Show($"User Added !!");
                    if (dialog == DialogResult.OK)
                    {
                        grpbox1.Visible = false;
                    }

                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int cnt = 1;
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        

        private void bunifuToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            if (bunifuToggleSwitch21.Checked)
            {
                //grpbox1.Visible = false;
                grpbox1.Visible = false;
            }
            else
            {
               // grpbox1.Visible = true;
                grpbox1.Visible = true;
            }
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

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
                catch(Exception e)
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
                InsertData(username:username, password:password, email:email);
            }
            else { MessageBox.Show("Invalid AuthKey !!"); }

           
        }
    }
}
