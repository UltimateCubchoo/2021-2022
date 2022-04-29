namespace Exercise_1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.maintanenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.directorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAllAvailibleMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRentedMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintanenceToolStripMenuItem,
            this.securityToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // maintanenceToolStripMenuItem
            // 
            this.maintanenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.rentsToolStripMenuItem});
            this.maintanenceToolStripMenuItem.Name = "maintanenceToolStripMenuItem";
            this.maintanenceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintanenceToolStripMenuItem.Text = "Maintanence";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.moviesToolStripMenuItem.Text = "Movies";
            this.moviesToolStripMenuItem.Click += new System.EventHandler(this.moviesToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // rentsToolStripMenuItem
            // 
            this.rentsToolStripMenuItem.Name = "rentsToolStripMenuItem";
            this.rentsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.rentsToolStripMenuItem.Text = "Rents";
            this.rentsToolStripMenuItem.Click += new System.EventHandler(this.rentsToolStripMenuItem_Click);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleToolStripMenuItem1,
            this.directorToolStripMenuItem1,
            this.genreToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.securityToolStripMenuItem.Text = "Search";
            // 
            // titleToolStripMenuItem1
            // 
            this.titleToolStripMenuItem1.Name = "titleToolStripMenuItem1";
            this.titleToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.titleToolStripMenuItem1.Text = "Title";
            this.titleToolStripMenuItem1.Click += new System.EventHandler(this.titleToolStripMenuItem1_Click);
            // 
            // directorToolStripMenuItem1
            // 
            this.directorToolStripMenuItem1.Name = "directorToolStripMenuItem1";
            this.directorToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.directorToolStripMenuItem1.Text = "Director";
            this.directorToolStripMenuItem1.Click += new System.EventHandler(this.directorToolStripMenuItem1_Click);
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.genreToolStripMenuItem.Text = "Genre";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.genreToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listAllAvailibleMoviesToolStripMenuItem,
            this.allRentedMoviesToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // listAllAvailibleMoviesToolStripMenuItem
            // 
            this.listAllAvailibleMoviesToolStripMenuItem.Name = "listAllAvailibleMoviesToolStripMenuItem";
            this.listAllAvailibleMoviesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.listAllAvailibleMoviesToolStripMenuItem.Text = "All Availible Movies";
            this.listAllAvailibleMoviesToolStripMenuItem.Click += new System.EventHandler(this.listAllAvailibleMoviesToolStripMenuItem_Click);
            // 
            // allRentedMoviesToolStripMenuItem
            // 
            this.allRentedMoviesToolStripMenuItem.Name = "allRentedMoviesToolStripMenuItem";
            this.allRentedMoviesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.allRentedMoviesToolStripMenuItem.Text = "All Rented Movies";
            this.allRentedMoviesToolStripMenuItem.Click += new System.EventHandler(this.allRentedMoviesToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(171, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::Exercise_1.Properties.Resources.R;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Movie System";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem maintanenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem directorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listAllAvailibleMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRentedMoviesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

