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
    public partial class F_sign_up_window : Form
    {

        string connetionString;
        SqlConnection conn;

        public F_sign_up_window()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

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

        private int NextId()
        {
            int id=0;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT [id] FROM [Webflex].[dbo].[Users]", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                string new_id = "";

                while (reader.Read())
                {
                    new_id = reader.GetString(0);
                   
                }
                Int32.TryParse(new_id, out id);
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            Disconnect();
            return id+1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string email = textBox5.Text;

            if (login != "" && password != "" && name != "" && surname != "" && email != "")
            {

                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                //string newMovie = "";
                // newMovie = Console.ReadLine();
                //newMovie = textBox1.Text;
                int new_id = 0;
                new_id = NextId();
                Connect();
                try
                {
                    string sql = "INSERT INTO Users (ID, login,password,name,surname,[e-mail],balance) VALUES('"+new_id+"', '"+login+"', '"+password+"', '"+name+"', '"+surname+"', '"+email+"', '0');";
                    cmd = new SqlCommand(sql, conn);
                    adapter.InsertCommand = new SqlCommand(sql, conn);
                    adapter.InsertCommand.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Signing up successful. You can go back to main page and sign in!");
                }
                catch
                {
                    MessageBox.Show("Adding failed");
                }
            }
            else
            {
                MessageBox.Show("Fill empty fields");
            }
            Disconnect();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Webflex ss = new Webflex();
            ss.Show();
        }

        private void F_sign_up_window_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
