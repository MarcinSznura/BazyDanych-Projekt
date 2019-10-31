using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webflex
{
    public partial class F_user_account_window : Form
    {
        public F_user_account_window()
        {
            InitializeComponent();
                label1.Text = "Welcome " + Program.activeUserName;
            label1.Refresh();
        }

        private void After_siging_in_Load(object sender, EventArgs e)
        {
            CenterToParent();
            label1.Text = "Welcome " + Program.activeUserName;
            label1.Refresh();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_user_library ss = new F_user_library();
            ss.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_shop ss = new F_shop();
            ss.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_add_funds ss = new F_add_funds();
            ss.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_account ss = new F_account();
            ss.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.activeUserId = "";
            Program.activeUserName = "";
            this.Hide();
            F_first_window ss = new F_first_window();
            ss.Show();
        }
    }
}
