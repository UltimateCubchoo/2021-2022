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
    public partial class RentMain_Form : Form
    {
        public RentMain_Form()
        {
            InitializeComponent();
        }
        public string RentQuery = "";
        public void LoadTable()
        {
            try
            {
                dataGridView1.DataSource = "";
                dataGridView1.DataSource = Queries.ExecuteQuery(RentQuery);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void RentMain_Form_Load(object sender, EventArgs e)
        {
            try
            {
                if (RentQuery == string.Empty)
                    RentQuery = "Select * from Rents;";
                LoadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }    
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userTextBox.Text == "" || movieTextBox.Text == "" || loanTextBox.Text == "" || dueTextBox.Text == "")
                    throw new Exception("All fields must be filled.");
                int userId = int.Parse(userTextBox.Text);
                int movieId = int.Parse(movieTextBox.Text);
                string loanDate = loanTextBox.Text;
                string dueDate = dueTextBox.Text;
                Queries newQuery = new Queries();
                newQuery.ExecuteNonQuery($"Insert into Rents(userId, movieId, loanDate, dueDate) Values(\'{userId}\', \'{movieId}\', \'{loanDate}\', \'{dueDate}\');");
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userTextBox.Text == "" || movieTextBox.Text == "" || loanTextBox.Text == "" || dueTextBox.Text == "")
                    throw new Exception("All fields must be filled.");
                int userId = int.Parse(userTextBox.Text);
                int movieId = int.Parse(movieTextBox.Text);
                string loanDate = loanTextBox.Text;
                string dueDate = dueTextBox.Text;
                if (dataGridView1.SelectedRows.Count <= 0)
                    throw new Exception("At least one row must be selected to be able to edit it.");
                Queries newQuery = new Queries();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int rowIndex = row.Index;
                    string rentId = row.Cells["rentid"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Update Rents Set userId = \'{userId}\', movieId = \'{movieId}\', loanDate = \'{loanDate}\', dueDate = \'{dueDate}\' Where rentId = \'{rentId}\'");
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
                    string rentId = row.Cells["rentid"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Delete From Rents Where rentId = {rentId}");
                }
                LoadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
