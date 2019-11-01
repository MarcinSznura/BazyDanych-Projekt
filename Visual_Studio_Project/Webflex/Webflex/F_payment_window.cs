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
    public partial class F_payment_window : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        public F_payment_window()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(10);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(25);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(50);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(100);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(200);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            AddFundsToBalance(500);
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void F_payment_window_Load(object sender, EventArgs e)
        {

        }


        private decimal AddFundsToBalance(decimal howMuch)
        {
            decimal balance = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Webflex].[dbo].[Users] SET balance = balance + 10 WHERE id = "+Program.activeUserId+"; ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand("UPDATE [Webflex].[dbo].[Users] SET balance = balance + "+howMuch+" WHERE id = " + Program.activeUserId + "; ", conn);
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            return balance;
        }


        
    }
}
