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
    public partial class F_add_funds : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        public F_add_funds()
        {
            InitializeComponent();
            label1.Text = Program.activeUserName;
            label3.Text = ReadUserBalance().ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_user_account_window ss = new F_user_account_window();
            ss.Show();
        }

        private void F_add_funds_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private decimal ReadUserBalance()
            {
            decimal balance = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [balance] FROM [Webflex].[dbo].[Users] WHERE id = "+Program.activeUserId+"", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    balance = reader.GetDecimal(0);
                }
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return balance;
            }


        

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_payment_window ss = new F_payment_window();
            ss.Show();
        }
    }
}
