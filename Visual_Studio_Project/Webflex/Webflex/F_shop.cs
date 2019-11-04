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
    public partial class F_shop : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        string title = "";
        int id, price = 0;
        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public F_shop()
        {
            InitializeComponent();
            MoviesData();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_user_account_window ss = new F_user_account_window();
            ss.Show();
        }

        private void F_shop_Load(object sender, EventArgs e)
        {
            CenterToParent();
            /*dataGridView1.DataSource = bindingSource1;
            GetData("SELECT [id],[title],[price] FROM [Webflex].[dbo].[Movies]");*/
            PopulateItems();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        /*void GetData(string cmd)
        {
            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(cmd, conn);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. 
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            bindingSource1.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            dataAdapter.Dispose();


        }*/

        private void MoviesData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [id],[title],[price] FROM [Webflex].[dbo].[Movies]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    title = reader.GetString(1);
                    price = reader.GetInt32(2);
                }
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void shopListing1_Load(object sender, EventArgs e)
        {

        }

        private void PopulateItems()
        {
            flowLayoutPanel1.Controls.Clear();

            List<int> IDArray = new List<int>();
            List<String> TitleArray = new List<String>();
            List<String> GenreArray = new List<String>();
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

            ShopListing[] shopListing = new ShopListing[20];
            for(int i = 0; i < TitleArray.Count; i++)
            {
                String Title = TitleArray[i];
                String Genre = GenreArray[i];
                int Price = PriceArray[i];
                shopListing[i] = new ShopListing();
                shopListing[i].Title = Title;
                shopListing[i].Genre = Genre;
                shopListing[i].Price = Price;

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }

                flowLayoutPanel1.Controls.Add(shopListing[i]);

            }
        }
        
    }
}
