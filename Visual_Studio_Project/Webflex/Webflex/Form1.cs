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

        string connetionString;
        SqlConnection conn;

        public Webflex()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_screen ss = new login_screen();
            ss.Show();

        }

        private void Webflex_Load(object sender, EventArgs e)
        {
            //todo 
        }
    }


   

}
