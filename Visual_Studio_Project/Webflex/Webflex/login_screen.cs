using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webflex
{
    public partial class login_screen : Form
    {

        string connetionString;
        SqlConnection conn;

        public login_screen()
        {
            InitializeComponent();
        }

        private void Connect()
        {
            connetionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
            conn = new SqlConnection(connetionString);
            try
            {
                conn.Open();
                //MessageBox.Show("Connection Open  !");
            }
            catch
            {
                MessageBox.Show("Failed to connect!");
            }
        }

        private void Disconnect()
        {
            try
            {
                conn.Close();
                //MessageBox.Show("Connection Closed  !");
            }
            catch
            {
                MessageBox.Show("Failed to disconnect!");
            }
        }

        private void Login_screen_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT [login],[password] FROM [Webflex].[dbo].[Users]", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string user_login = textBox1.Text;
                string password = textBox2.Text;

                bool wrong_password = true;
                while (reader.Read())
                {
                    if (user_login == reader.GetString(0) && password == reader.GetString(1))
                    {
                        this.Hide();
                        after_siging_in ss = new after_siging_in();
                        ss.Show();
                        wrong_password = false;
                        break;
                    }
                }
                if (wrong_password) MessageBox.Show("Wrong user name or password!");
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            Disconnect();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           Webflex ss = new Webflex();
            ss.Show();
        }
    }
}
