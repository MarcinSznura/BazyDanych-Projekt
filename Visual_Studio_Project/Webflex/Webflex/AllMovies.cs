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
    public partial class AllMovies : Form
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=Webflex;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(connectionString);

        string genre = "all";

        public AllMovies()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_first_window ss = new F_first_window();
            ss.Show();
        }

        private void PopulateItems()
        {
            flowLayoutPanel1.Controls.Clear();

            List<int> IDArray = new List<int>();
            List<string> TitleArray = new List<string>();
            List<string> GenreArray = new List<string>();
            List<int> PriceArray = new List<int>();

            conn.Open();

            string view = "";
            switch (genre)
            {
                case "all":
                    view = "SELECT [id],[title],[genres],[price] FROM [Webflex].[dbo].[Movies]";
                    break;

                case "Actions":
                    view = "select [id],[title],[genres],[price] from [ActionsMovies]";
                    break;

                case "Comedy":
                    view = "select [id],[title],[genres],[price] from [ComedyMovies]";
                    break;

                case "Crime":
                    view = "select [id],[title],[genres],[price] from [CrimeMovies]";
                    break;

                case "Documentary":
                    view = "select [id],[title],[genres],[price] from [DocumentaryMovies]";
                    break;

                case "Drama":
                    view = "select [id],[title],[genres],[price] from [DramaMovies]";
                    break;

                case "Horror":
                    view = "select [id],[title],[genres],[price] from [HorrorMovies]";
                    break;

                case "Science Fiction":
                    view = "select [id],[title],[genres],[price] from [ScienceFictionMovies]";
                    break;

                default:
                    view = "SELECT [id],[title],[genres],[price] FROM [Webflex].[dbo].[Movies]";
                    break;
            }
            SqlCommand cmd = new SqlCommand(view, conn);
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

           UserLibraryList[] shopListing = new UserLibraryList[21];
            for (int i = 0; i < TitleArray.Count; i++)
            {
                string Title = TitleArray[i];
                string Genre = GenreArray[i];
                int Price = PriceArray[i];
                int Id = IDArray[i];
                shopListing[i] = new UserLibraryList();
                shopListing[i].Title = Title;
                shopListing[i].Genre = Genre;
                shopListing[i].Id = Id;

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }

                    flowLayoutPanel1.Controls.Add(shopListing[i]);

            }
        }

       

        private bool IsInLibrary(int id, List<int> UserMovies)
        {
            for (int i = 0; i < UserMovies.Count(); i++)
            {
                if (id == UserMovies[i]) return true;
            }
            return false;
        }

        private void AllMovies_Load(object sender, EventArgs e)
        {
            CenterToParent();
            PopulateItems();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = comboBox1.Text;
            PopulateItems();
        }

        private void UserLibraryList1_Load(object sender, EventArgs e)
        {

        }
    }
}
