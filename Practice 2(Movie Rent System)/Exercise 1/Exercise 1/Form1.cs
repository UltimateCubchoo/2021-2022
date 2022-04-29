using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Maintenance Tab
        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMain_Form newForm = new UserMain_Form();
            newForm.Show();
        }

        private void rentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentMain_Form newForm = new RentMain_Form();
            newForm.Show();
        }

        //Search Tab
        private void titleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.movieQuery = "Select title from Movies;";
            _form2.Show();
        }

        private void directorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.movieQuery = "Select directors from Movies;";
            _form2.Show();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.movieQuery = "Select genre from Movies;";
            _form2.Show();
        }

        //Reports Tab
        private void listAllAvailibleMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.movieQuery = "Select * from Movies Where [rented?] = 0;";
            _form2.Show();
        }

        private void allRentedMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieMain_Form _form2 = new MovieMain_Form();
            _form2.movieQuery = "Select * from Movies Where [rented?] = 1;";
            _form2.Show();
        }
    }
}
