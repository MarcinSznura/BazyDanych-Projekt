namespace Webflex
{
    partial class ShopListing
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.LTitle = new System.Windows.Forms.Label();
            this.LGenre = new System.Windows.Forms.Label();
            this.LPrice = new System.Windows.Forms.Label();
            this.Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LTitle
            // 
            this.LTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LTitle.Location = new System.Drawing.Point(3, 5);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(205, 34);
            this.LTitle.TabIndex = 1;
            this.LTitle.Text = "label1";
            this.LTitle.Click += new System.EventHandler(this.Title_Click);
            // 
            // LGenre
            // 
            this.LGenre.Location = new System.Drawing.Point(7, 52);
            this.LGenre.Name = "LGenre";
            this.LGenre.Size = new System.Drawing.Size(103, 30);
            this.LGenre.TabIndex = 2;
            this.LGenre.Text = "label2";
            this.LGenre.Click += new System.EventHandler(this.Year_Click);
            // 
            // LPrice
            // 
            this.LPrice.AutoSize = true;
            this.LPrice.Location = new System.Drawing.Point(219, 11);
            this.LPrice.Name = "LPrice";
            this.LPrice.Size = new System.Drawing.Size(35, 13);
            this.LPrice.TabIndex = 4;
            this.LPrice.Text = "label2";
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(202, 45);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(63, 30);
            this.Button.TabIndex = 5;
            this.Button.Text = "BUY";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // ShopListing
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.Button);
            this.Controls.Add(this.LPrice);
            this.Controls.Add(this.LGenre);
            this.Controls.Add(this.LTitle);
            this.Name = "ShopListing";
            this.Size = new System.Drawing.Size(272, 83);
            this.Load += new System.EventHandler(this.ShopListing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.PictureBox ListingPicture;
        //private System.Windows.Forms.Label ListingTitle;
        //private System.Windows.Forms.Label ListingYear;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Label LGenre;
        private System.Windows.Forms.Label LPrice;
        private System.Windows.Forms.Button Button;
    }
}
