namespace Webflex
{
    partial class F_shop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.shopListing1 = new Webflex.ShopListing();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(399, 357);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 40);
            this.button3.TabIndex = 7;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.shopListing1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(590, 306);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // shopListing1
            // 
            this.shopListing1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.shopListing1.Genre = null;
            this.shopListing1.Location = new System.Drawing.Point(2, 2);
            this.shopListing1.Margin = new System.Windows.Forms.Padding(2);
            this.shopListing1.Name = "shopListing1";
            this.shopListing1.Price = 0;
            this.shopListing1.Size = new System.Drawing.Size(275, 82);
            this.shopListing1.TabIndex = 0;
            this.shopListing1.Title = null;
            this.shopListing1.Load += new System.EventHandler(this.ShopListing1_Load_1);
            // 
            // F_shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Name = "F_shop";
            this.Text = "F_shop";
            this.Load += new System.EventHandler(this.F_shop_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ShopListing shopListing1;
    }
}