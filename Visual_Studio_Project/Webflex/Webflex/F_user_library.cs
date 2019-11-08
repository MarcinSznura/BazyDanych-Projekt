﻿using System;
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
    public partial class F_user_library : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        string title = "";
        int id, price = 0;
        public F_user_library()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_user_account_window ss = new F_user_account_window();
            ss.Show();
        }

        private void F_user_library_Load(object sender, EventArgs e)
        {
            CenterToParent();
            PopulateItems();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PopulateItems()
        {
            flowLayoutPanel1.Controls.Clear();

            List<int> IDArray = new List<int>();
            List<string> TitleArray = new List<string>();
            List<string> GenreArray = new List<string>();
            List<int> PriceArray = new List<int>();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [id],[title],[genres],[price] FROM [Webflex].[dbo].[Movies]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IDArray.Add(reader.GetInt32(0));
                    TitleArray.Add(reader.GetString(1));
                    GenreArray.Add(reader.GetString(2));
                    PriceArray.Add(reader.GetInt32(3));
                }
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            Console.Write(TitleArray);

            List<int> UserMovies = GetUserMovies();


            ShopListing[] shopListing = new ShopListing[20];
            for (int i = 0; i < TitleArray.Count; i++)
            {
                string Title = TitleArray[i];
                string Genre = GenreArray[i];
                int Price = PriceArray[i];
                int Id = IDArray[i];
                shopListing[i] = new ShopListing();
                shopListing[i].Title = Title;
                shopListing[i].Genre = Genre;
                shopListing[i].Price = Price;

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }

                if (IsInLibrary(Id,UserMovies))
                {
                    flowLayoutPanel1.Controls.Add(shopListing[i]);
                }
               
            }
        }

        private List<int> GetUserMovies()
        {
            List<int> UserMovies = new List<int>();
            SqlCommand cmd2 = new SqlCommand("select [id] from " + Program.activeUserName + "_Library where bought = 1;", conn);
            conn.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                UserMovies.Add(reader2.GetInt32(0));
            }
            conn.Close();
            reader2.Close();
            cmd2.Dispose();
            return UserMovies;
        }

        private void ShopListing1_Load(object sender, EventArgs e)
        {

        }

        private bool IsInLibrary(int id, List<int> UserMovies)
        {
            for (int i=0;i<UserMovies.Count();i++)
            {
                if (id == UserMovies[i]) return true;
            }
            return false;
        }


    }

}
