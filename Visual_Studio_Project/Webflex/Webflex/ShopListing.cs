using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webflex
{
    public partial class ShopListing : UserControl
    {
        public ShopListing()
        {
            InitializeComponent();
        }



        #region Properties

        private string _title;
        private string _genre;
        private int _price;

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
    }
}
