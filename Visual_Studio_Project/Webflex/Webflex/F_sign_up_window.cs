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

        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        public F_sign_up_window()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

      

        private int NextId()
        {
            int id=0;
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT [id] FROM [Webflex].[dbo].[Users]", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                   
                }
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            conn.Close();
            return id+1;
        }


        private bool LoginTaken(string newLogin)
        {
            bool taken = false;
            string name = "";
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT [login] FROM [Webflex].[dbo].[Users]", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name = reader.GetString(0);
                    if (name == newLogin)
                    {
                        reader.Close();
                        cmd.Dispose();
                        conn.Close();
                        return true;
                    }

                }
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            conn.Close();
            return false;
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
                int new_id = 0;
                new_id = NextId();
                
                
                    if (!LoginTaken(login))
                    {

                    string sql = "DECLARE @RC int EXECUTE @RC = [dbo].[AddNewUser] @id = "+new_id+",@login = '"+login+"' ,@password = '"+password + @"' ,@name = '"+name+@"'
                                     ,@surname = '"+surname+"'  ,@mail = '"+email+"'  ,@balance = 0";
                   
                        cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    adapter.InsertCommand = new SqlCommand(sql, conn);
                        adapter.InsertCommand.ExecuteNonQuery();

                    conn.Close();
                    cmd.Dispose();
                        adapter.Dispose();
                        MessageBox.Show("Signing up successful. You can go back to main page and sign in!");
                }
                    else MessageBox.Show("Login taken");
               
            }
            else
            {
                MessageBox.Show("Fill empty fields");
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_first_window ss = new F_first_window();
            ss.Show();
        }

        private void F_sign_up_window_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
