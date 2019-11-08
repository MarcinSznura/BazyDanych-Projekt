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
using System.Globalization;

namespace Webflex
{
    public partial class ShopListing : UserControl
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        public ShopListing()
        {
            InitializeComponent();
        }



        #region Properties

        private string _title;
        private string _genre;
        private int _price;
        private int _id;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; LTitle.Text = value; }
        }

        [Category("Custom Props")]
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; LGenre.Text = value; }
        }

        [Category("Custom Props")]
        public int Price
        {
            get { return _price; }
            set { _price = value; LPrice.Text = "$" + value.ToString(); }
        }

        [Category("Custom Props")]
        public int Id
        {
            get { return _id; }
            set { _id = value;}
        }

        #endregion

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void Year_Click(object sender, EventArgs e)
        {

        }

        private void ShopListing_Load(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (UserBalance() >= _price)
            {
                BuyAMovie(_id, _price);
                MessageBox.Show("Movie added to your library");

                this.Visible = false;
            }
            else MessageBox.Show("Not sufficient funds");
        }

        private void BuyAMovie(int id,decimal howMuch)
        {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET balance = balance - " + howMuch + " WHERE id = " + Program.activeUserId + "; UPDATE " + Program.activeUserName + "_Library set bought = 1 WHERE id =" + id);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand("UPDATE Users SET balance = balance - " + howMuch + " WHERE id = " + Program.activeUserId + "; UPDATE " + Program.activeUserName + "_Library set bought = 1 WHERE id =" + id, conn);
                adapter.UpdateCommand.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
                adapter.Dispose();
        }

        private decimal UserBalance()
        {
            decimal balance=0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select balance from Users where id=" + Program.activeUserId,conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                balance = reader.GetDecimal(0);
            }
            conn.Close();
            reader.Close();
            cmd.Dispose();

            return balance;
        }

    }
}
