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
    public partial class UserMain_Form : Form
    {
        public UserMain_Form()
        {
            InitializeComponent();
        }
        public string userQuery = "";
        public void LoadTable()
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = Queries.ExecuteQuery(userQuery);
        }
        private void UserMain_Form_Load(object sender, EventArgs e)
        {
            if (userQuery == string.Empty)
                userQuery = "Select * From Users";
            LoadTable();
        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text == string.Empty || addressTextBox.Text == string.Empty || debtTextBox.Text == string.Empty)
                    throw new Exception("All fields must be filled before");
                string name = nameTextBox.Text;
                string address = addressTextBox.Text;
                int debt = int.Parse(debtTextBox.Text);
                Queries newQuery = new Queries();
                newQuery.ExecuteNonQuery($"Insert into Users (name, address, debt) Values (\'{name}\', \'{address}\', \'{debt}\')");
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
                if (nameTextBox.Text == string.Empty || addressTextBox.Text == string.Empty || debtTextBox.Text == string.Empty)
                    throw new Exception("All fields must be filled before");
                string name = nameTextBox.Text;
                string address = addressTextBox.Text;
                int debt = int.Parse(debtTextBox.Text);
                if (dataGridView1.SelectedRows.Count <= 0)
                    throw new Exception("At least one row must be selected to be able to edit it.");
                Queries newQuery = new Queries();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int rowIndex = row.Index;
                    string userId = row.Cells["UserId"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Update Users Set name = \'{name}\', address = \'{address}\', debt = {debt} Where userId = {userId}");
                }
                LoadTable();
            }
            catch (Exception ex)
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
                    string userId = row.Cells["UserId"].Value.ToString();
                    newQuery.ExecuteNonQuery($"Delete From Users Where userId = {userId}");
                }
                LoadTable();
            }
            catch (Exception ex)
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
