using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exercise_1
{
    public partial class MovieMain_Form : Form
    {
        public MovieMain_Form()
        {
            InitializeComponent();
        }
        public string movieQuery = "";
        public void LoadTable()
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = Queries.ExecuteQuery(movieQuery);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (movieQuery == string.Empty)
                movieQuery = "Select * from Movies;";
            LoadTable();
        }

        //This inserts a new value into the database
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleTextBox.Text == "" || directorTextBox.Text == "" || actorTextBox.Text == "" || genreTextBox.Text == "")
                    throw new Exception("All fields must be submitted before inserting!!!");
                string title = titleTextBox.Text;
                string director = directorTextBox.Text;
                string actors = actorTextBox.Text;
                string genre = genreTextBox.Text;
                bool availiblity = availCheck.Checked;
                int rentCheck = 1;
                if (availiblity == true)
                    rentCheck = 0;
                Queries newQuery = new Queries();
                newQuery.ExecuteNonQuery($"Insert into Movies(title, director, actors, genre, [rented?]) Values(\'{title}\', \'{director}\', \'{actors}\', \'{genre}\', {rentCheck});");
                LoadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleTextBox.Text == "" || directorTextBox.Text == "" || actorTextBox.Text == "" || genreTextBox.Text == "")
                    throw new Exception("All fields must be submitted before inserting!!!");
                //New Values
                string title = titleTextBox.Text;
                string director = directorTextBox.Text;
                string actors = actorTextBox.Text;
                string genre = genreTextBox.Text;
                bool availiblity = availCheck.Checked;
                int rentCheck = 1;
                if (availiblity == true)
                    rentCheck = 0;
                //Sql and Gridtable stuff
                if (dataGridView1.SelectedRows.Count <= 0)
                  throw new Exception("At least one row must be selected to be able to edit it.");
                Queries newQuery = new Queries();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int rowIndex = row.Index;
                    string movieId = row.Cells["MovieId"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Update Movies Set title = \'{title}\', director = \'{director}\', actors = \'{actors}\', genre = \'{genre}\', [rented?] = {rentCheck} Where movieId = {movieId};");
                }
                LoadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                    throw new Exception("At least one row must be selected to be able to delete anything");
                Queries newQuery = new Queries();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int rowIndex = row.Index;
                    string movieId = row.Cells["MovieId"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Delete From Movies Where movieId = {movieId}");
                }
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
