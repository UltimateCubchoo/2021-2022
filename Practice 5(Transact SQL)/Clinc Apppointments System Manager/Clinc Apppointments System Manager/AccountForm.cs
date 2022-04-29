using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinc_Apppointments_System_Manager
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        public void Load_Table(string query)
        {
            DataTable _data = Queries.ExecuteQuery(query);
            dataGridView1.DataSource = _data;
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Table("select * from Users");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = userTextbox.Text;
                string password = passTextbox.Text;
                string confirm = conPassTextBox.Text;
                if (password != confirm)
                    throw new Exception("Confirmed password must be the same as original");
                int status = Convert.ToInt32(statusCombobox.Text);

                Queries _nonquery = new Queries();
                _nonquery.ExecuteNonQuery($"INSERT INTO Users(username, password, [admin?]) VALUES(\'{username}\', \'{password}\', {status});");
                Load_Table("select * from Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = userTextbox.Text;
                string password = passTextbox.Text;
                string confirm = conPassTextBox.Text;
                if (password != confirm)
                    throw new Exception("Confirmed password must be the same as original");
                int status = Convert.ToInt32(statusCombobox.Text);

                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Please select at least one row before updating.");
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int user_id = (int)row.Cells[0].Value;
                    Queries _nonquery = new Queries();
                    _nonquery.ExecuteNonQuery($"UPDATE Users SET username = \'{username}\', password = \'{password}\', [admin?] = {status} WHERE user_id = {user_id}");
                }
                Load_Table("select * from Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int user_id = Convert.ToInt32(row.Cells[0].Value);
                    Queries _nonquery = new Queries();
                    _nonquery.ExecuteNonQuery($"DELETE FROM Users WHERE user_id = {user_id}");
                }
                Load_Table("select * from Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
