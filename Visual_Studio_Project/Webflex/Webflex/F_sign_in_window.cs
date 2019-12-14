﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webflex
{
    public partial class F_sign_in_window : Form
    {

        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        public F_sign_in_window()
        {
            InitializeComponent();
           
        }


        private void Login_screen_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                Program.activeUserName = SignIn();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            Program.activeUserId = SetActiveUser(Program.activeUserName);
            conn.Close();


            if (Program.activeUserId != 0)
            {

                this.Hide();
                F_user_account_window ss = new F_user_account_window();
                ss.Show();
            }

          
        }

        private string SignIn()
        {
            string activeUser="";
            SqlCommand cmd = new SqlCommand("SELECT [login],[password] FROM [Webflex].[dbo].[Users]", conn);
            using(
            SqlDataReader reader = cmd.ExecuteReader()
            )
            {

                var data = Encoding.ASCII.GetBytes(textBox2.Text);
                var sha1 = new SHA1CryptoServiceProvider();
                var sha1data = sha1.ComputeHash(data);
                

                string user_login = textBox1.Text;
                string password = Convert.ToBase64String(sha1data).Substring(0, 20);

                bool wrong_password = true;
                while (reader.Read())
                {
                                        
                    if (user_login == reader.GetString(0) && password == reader.GetString(1))
                    {
                        wrong_password = false;
                        activeUser = reader.GetString(0);
                        break;
                    }
                }
                if (wrong_password) MessageBox.Show("Wrong user name or password!");
                reader.Close();
                cmd.Dispose();
            }
            
            return activeUser;
        }

        private int SetActiveUser(string user)
        {
            int activeUser=0;
            SqlCommand cmd2 = new SqlCommand("SELECT [id] FROM [Webflex].[dbo].[Users] WHERE login = '" + user + "'", conn);
            using (
            SqlDataReader reader2 = cmd2.ExecuteReader()
            )
            {
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        activeUser = reader2.GetInt32(0);
                    }
                }
                reader2.Close();
                cmd2.Dispose();
            }
            return activeUser;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           F_first_window ss = new F_first_window();
            ss.Show();
        }
    }
}
