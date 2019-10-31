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
    public partial class F_sign_in_window : Form
    {

        string connetionString;
        SqlConnection conn;

        public F_sign_in_window()
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
            CenterToParent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string activeUser="";
            Connect();
            try
            {
                Program.activeUserName = SignIn();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            Program.activeUserId = SetActiveUser(Program.activeUserName);

            if (Program.activeUserId != "")
            {
                this.Hide();
                F_user_account_window ss = new F_user_account_window();
                ss.Show();
            }

            Disconnect();
        }


        private string SignIn()
        {
            string activeUser="";
            SqlCommand cmd = new SqlCommand("SELECT [login],[password] FROM [Webflex].[dbo].[Users]", conn);
            SqlDataReader reader = cmd.ExecuteReader();


            string user_login = textBox1.Text;
            string password = textBox2.Text;

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
            return activeUser;
        }

        private string SetActiveUser(string user)
        {
            string activeUser="";
            SqlCommand cmd2 = new SqlCommand("SELECT [id] FROM [Webflex].[dbo].[Users] WHERE login = '" + user + "'", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    activeUser = reader2.GetString(0);
                }
            }
            reader2.Close();
            cmd2.Dispose();
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
