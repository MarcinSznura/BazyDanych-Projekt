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

                    //AddNewUser
                    string sql = "DECLARE @RC int EXECUTE @RC = [dbo].[AddNewUser] @id = "+new_id+",@login = '"+login+"' ,@password = '"+password + @"' ,@name = '"+name+@"'
                                     ,@surname = '"+surname+"'  ,@mail = '"+email+"'  ,@balance = 0";
                    //string sql = "INSERT INTO Users (ID, login,password,name,surname,[e-mail],balance) VALUES('" + new_id + "', '" + login + "', '" + password + "', '" + name + "', '" + surname + "', '" + email + "', '0');";
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

        private void CreateUserLibraryView(string login)
        {
            string createUserView = "CREATE VIEW "+login+"_LibraryView AS select * from "+login+"_Library;";
            conn.Open();

            SqlCommand command = new SqlCommand(createUserView, conn);
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();

        }

        private void CreateUserProcedureLibraryFilter(string name)
        {
            string createUserProcedure = @"
                CREATE PROCEDURE[dbo].[FilterLibraryOfUser" + name + @"]
@genres varchar(20)
AS
BEGIN
    SET NOCOUNT ON;

           SELECT dbo.Movies.id, dbo.Movies.title, dbo.Movies.genres, dbo.Movies.[maturity ratings], dbo.Movies.country, dbo.Movies.[release date], dbo.Movies.poster, dbo.Movies.price, dbo." + name + @"_Library.id AS Expr1,
                                dbo."+name+@"_Library.bought
       FROM            dbo.Movies INNER JOIN
       
                                dbo." + name + "_Library ON dbo.Movies.id = dbo." + name + @"_Library.id
       WHERE(dbo.Movies.genres = @genres) AND(dbo." + name + "_Library.bought = 1) END";
            conn.Open();

            SqlCommand command = new SqlCommand(createUserProcedure, conn);
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }

        private void CreateUserProcedureShopFilter(string name)
        {
            string createUserProcedure = @"
                CREATE PROCEDURE[dbo].[FilterShopOfUser" + name + @"]
@genres varchar(20)
AS
BEGIN
    SET NOCOUNT ON;

           SELECT dbo.Movies.id, dbo.Movies.title, dbo.Movies.genres, dbo.Movies.[maturity ratings], dbo.Movies.country, dbo.Movies.[release date], dbo.Movies.poster, dbo.Movies.price, dbo." + name + @"_Library.id AS Expr1,
                                dbo." + name + @"_Library.bought
       FROM            dbo.Movies INNER JOIN
       
                                dbo." + name + "_Library ON dbo.Movies.id = dbo." + name + @"_Library.id
       WHERE(dbo.Movies.genres = @genres) AND(dbo." + name + "_Library.bought = 0) END";
            conn.Open();

            SqlCommand command = new SqlCommand(createUserProcedure, conn);
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }

        private void CreateUserLibrary(string login)
        {
            string createUserTable = "CREATE TABLE " + login + "_Library (id int NOT NULL,title varchar(255) NOT NULL,bought bit NOT NULL CONSTRAINT "+login+"_pk PRIMARY KEY(id));";
            string populateUserTable = "INSERT INTO [" + login + "_Library] VALUES ";
            conn.Open();
            for (int i = 1; i <= AllMoviesNumber(); i++)
            {
                populateUserTable = populateUserTable + "(" + i + ", 'a', 0)";
                if (i + 1 <= AllMoviesNumber())
                    populateUserTable = populateUserTable + ",";
            }
            string updateUserTable = "UPDATE " + login + "_Library SET " + login + "_Library.id = Movies.id, " + login + "_Library.title = Movies.title, " + login + "_Library.bought = 0 FROM dbo.Movies WHERE " + login + "_Library.id = dbo.Movies.id;";

            SqlCommand command = new SqlCommand(createUserTable, conn);
            command.ExecuteNonQuery();
            command.Dispose();


            SqlCommand cmd2;
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            cmd2 = new SqlCommand(populateUserTable, conn);
            adapter2.InsertCommand = new SqlCommand(populateUserTable, conn);
            adapter2.InsertCommand.ExecuteNonQuery();
            adapter2.Dispose();

            SqlCommand cmd3;
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            cmd3 = new SqlCommand(populateUserTable, conn);
            adapter3.UpdateCommand = new SqlCommand(updateUserTable, conn);
            adapter3.UpdateCommand.ExecuteNonQuery();
            adapter3.Dispose();
            conn.Close();
        }

        private int AllMoviesNumber()
        {
            int number = 0;
            SqlCommand cmd = new SqlCommand(" Select count(*) from Movies;", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                number = reader.GetInt32(0);
            }
            reader.Dispose();
            cmd.Dispose();
            return number;
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
