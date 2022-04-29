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
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }
        public void Load_Table(string query)
        {
            DataTable _data = Queries.ExecuteQuery(query);
            dataGridView1.DataSource = _data;
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Table($"SELECT * FROM Patients");
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
                string fname = fnameTextbox.Text;
                string lname = lnameTextbox.Text;
                string sex = genderCombobox.Text;
                string address = addressTextbox.Text;
                string zip = zipTextbox.Text;
                string phone = phoneTextbox.Text;
                string dob = dobDateTimePicker.Text;

                Queries _queries = new Queries();
                _queries.ExecuteNonQuery($"INSERT INTO Patients(first_name, last_name, sex, address, zip_code, phone_number, date_of_birth) VALUES(\'{fname}\', \'{lname}\' ,\'{sex}\', \'{address}\', \'{zip}\', \'{phone}\', \'{dob}\')");
                Load_Table("SELECT * FROM Patients");
            }
            catch(Exception ex)
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
                string sex = genderCombobox.Text;
                string address = addressTextbox.Text;
                string zip = zipTextbox.Text;
                string phone = phoneTextbox.Text;
                string dob = dobDateTimePicker.Text;

                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Please select at least one row before updating.");
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    Queries _queries = new Queries();
                    int patient_id = Convert.ToInt32(row.Cells[0].Value);
                    _queries.ExecuteNonQuery($"UPDATE Patients SET first_name = \'{fname}\', last_name = \'{lname}\', sex = \'{sex}\', address = \'{address}\', zip_code = \'{zip}\', phone_number = \'{phone}\', date_of_birth = \'{dob}\' WHERE patient_id = {patient_id}");
                }
                Load_Table("SELECT * FROM Patients");
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
                    Queries _queries = new Queries();
                    int patient_id = Convert.ToInt32(row.Cells[0].Value);
                    _queries.ExecuteNonQuery($"DELETE FROM Patients WHERE patient_id = {patient_id}");
                }
                Load_Table("SELECT * FROM Patients");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
