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

namespace Webflex
{
    public partial class Webflex : Form
    {

        public Webflex()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_sign_in_window ss = new F_sign_in_window();
            ss.Show();

        }

        private void Webflex_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_sign_up_window ss = new F_sign_up_window();
            ss.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


   

}
