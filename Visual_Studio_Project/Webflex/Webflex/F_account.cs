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
    public partial class F_account : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        string login, password, name, surname, email = "";
        string oldpass, newpass1, newpass2 = "";
        string password_chcek, newmail1, newmail2 = "";

        public F_account()
        {
            InitializeComponent();
            UserData();
            label3.Text = login;
            label10.Text = name;
            label12.Text = surname;
            label14.Text = email;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_user_account_window ss = new F_user_account_window();
            ss.Show();
        }

        private void F_account_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete you account ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var confirmResult2 = MessageBox.Show("This you will loose all movies you bought!!!",
                                     "Are you sure??",
                                     MessageBoxButtons.YesNo);
                if (confirmResult2 == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand("DROP TABLE "+Program.activeUserName+"_Library", conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand("DELETE FROM Users WHERE id ="+Program.activeUserId, conn);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    conn.Close();
                    adapter.Dispose();

                    MessageBox.Show("Farwell " + Program.activeUserName);

                    Program.activeUserId = 0;
                    Program.activeUserName = "";
                    this.Hide();
                    F_first_window ss = new F_first_window();
                    ss.Show();
                }
            }
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            password_chcek = textBox4.Text;
            newmail1 = textBox5.Text;
            newmail2 = textBox6.Text;
            if (password == password_chcek)
            {
                if (newmail1 == newmail2)
                {
                    ChangeEmail(newmail1);
                    email = newmail1;
                }
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {


        }

        private void Label7_Click(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            oldpass = textBox1.Text;
            newpass1 = textBox2.Text;
            newpass2 = textBox3.Text;
            if (oldpass == password)
            {
                if (newpass1 == newpass2)
                {
                    ChangePassword(newpass1);
                    password = newpass1;
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }


        private void ChangeEmail(string email)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand("UPDATE[Webflex].[dbo].[Users] SET [e-mail] = '"+email+"' WHERE id = "+Program.activeUserId, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void ChangePassword(string newPassword)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand("UPDATE [Webflex].[dbo].[Users] SET [password] = '" + newPassword + "' WHERE id = " + Program.activeUserId, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }


        private void UserData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Webflex].[dbo].[Users] WHERE id = '" + Program.activeUserId + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    login = reader.GetString(1);
                    password = reader.GetString(2);
                    name = reader.GetString(3);
                    surname = reader.GetString(4);
                    email = reader.GetString(5);
                }
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }

       

    }
}
