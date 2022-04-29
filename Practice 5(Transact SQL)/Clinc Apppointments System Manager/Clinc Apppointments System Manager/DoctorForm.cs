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
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }


        public void Load_Table(string query)
        {
            DataTable _data = Queries.ExecuteQuery(query);
            dataGridView1.DataSource = _data;
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Table("select * from Doctors");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = fnameTextbox.Text;
                string lname = lnameTextbox.Text;
                string phone = phoneTextbox.Text;
                string specialty = specialtyTextBox.Text;

                Queries _nonquery = new Queries();
                _nonquery.ExecuteNonQuery($"INSERT INTO Doctors(first_name, last_name, phone_number, specialty) VALUES(\'{fname}\', \'{lname}\', \'{phone}\', \'{specialty}\');");
                Load_Table("select * from Doctors");
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
                string fname = fnameTextbox.Text;
                string lname = lnameTextbox.Text;
                string phone = phoneTextbox.Text;
                string specialty = specialtyTextBox.Text;

                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Please select at least one row before updating.");
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int doctor_id = Convert.ToInt32(row.Cells[0].Value);
                    Queries _nonquery = new Queries();
                    _nonquery.ExecuteNonQuery($"UPDATE Doctors SET first_name = \'{fname}\', last_name = \'{lname}\', phone_number = \'{phone}\', specialty = \'{specialty}\' " +
                        $"WHERE doctor_id = {doctor_id}");
                }
                Load_Table("select * from Doctors");
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
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int doctor_id = Convert.ToInt32(row.Cells[0].Value);
                    Queries _nonquery = new Queries();
                    _nonquery.ExecuteNonQuery($"DELETE FROM Doctors WHERE doctor_id = {doctor_id}");
                }
                Load_Table("select * from Doctors");
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
