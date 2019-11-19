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
    public partial class UserLibraryList : UserControl
    {
        public UserLibraryList()
        {
            InitializeComponent();
        }

        #region Properties

        private string _title;
        private string _genre;
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
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

      

        #endregion

        private void UserLibraryList_Load(object sender, EventArgs e)
        {

        }

        private void LTitle_Click(object sender, EventArgs e)
        {

        }

        private void LPrice_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
