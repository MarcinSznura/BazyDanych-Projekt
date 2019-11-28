namespace Webflex
{
    partial class UserLibraryList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLibraryList));
            this.LGenre = new System.Windows.Forms.Label();
            this.LTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LGenre
            // 
            this.LGenre.Location = new System.Drawing.Point(5, 29);
            this.LGenre.Name = "LGenre";
            this.LGenre.Size = new System.Drawing.Size(226, 19);
            this.LGenre.TabIndex = 7;
            this.LGenre.Text = "label2";
            // 
            // LTitle
            // 
            this.LTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LTitle.Location = new System.Drawing.Point(4, 4);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(265, 34);
            this.LTitle.TabIndex = 6;
            this.LTitle.Text = "label1";
            this.LTitle.Click += new System.EventHandler(this.LTitle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(221, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 35);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // UserLibraryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LGenre);
            this.Controls.Add(this.LTitle);
            this.Name = "UserLibraryList";
            this.Size = new System.Drawing.Size(272, 46);
            this.Load += new System.EventHandler(this.UserLibraryList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LGenre;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
