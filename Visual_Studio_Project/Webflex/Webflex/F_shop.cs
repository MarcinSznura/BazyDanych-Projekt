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
        string connetionString;
        SqlConnection conn;
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
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT [id],[title],[price] FROM [Webflex].[dbo].[Movies]");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        void GetData(string cmd)
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


        }

        private void MoviesData()
        {
            Connect();
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
            Disconnect();
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
    }
}
