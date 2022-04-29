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
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Table("SELECT appointment_id as [Appointment ID], status as [Status], (p.first_name + p.last_name) as [Patient], ('Dr. ' + d.last_name) as [Doctor], location as [Location], date as [Date], time as [Time]"
                    + "FROM Appointments a INNER JOIN Doctors d ON a.doctor_id = d.doctor_id INNER JOIN Patients p on a.patient_id = p.patient_id; ");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void Load_Table(string query)
        {
            DataTable data = Queries.ExecuteQuery(query);
            dataGridView1.DataSource = data;
            Configure_Combos();
        }
        private void Configure_Combos()
        {
            try
            {
                //Assigning the comboboxes with actual people in the database
                DataTable patient_data = Queries.ExecuteQuery("SELECT patient_id, first_name, last_name FROM Patients");
                List<string> patients_names = new List<string>();
                foreach (DataRow row in patient_data.Rows)
                {
                    patients_names.Add(row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString());
                }
                patientCombobox.DataSource = patients_names;

                DataTable doctor_data = Queries.ExecuteQuery("SELECT doctor_id, last_name FROM Doctors");
                List<string> doctor_names = new List<string>();
                foreach (DataRow row in doctor_data.Rows)
                {
                    doctor_names.Add("Dr. " + row.ItemArray[1].ToString());
                }
                doctorCombobox.DataSource = doctor_names;
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
                int patient_index = (int)patientCombobox.SelectedIndex;
                int doctor_index = (int)doctorCombobox.SelectedIndex;
                string location = locationTextbox.Text;
                string date = datePicker.Text;
                string time = TimePicker.Text;
                string status = statusCombobox.Text;

                //Getting the ids for the patients and the doctors
                DataTable patient_data = Queries.ExecuteQuery("SELECT patient_id, first_name, last_name FROM Patients");
                List<int> patient_ids = new List<int>();
                DataTable doctor_data = Queries.ExecuteQuery("SELECT doctor_id, last_name FROM Doctors");
                List<int> doctor_ids = new List<int>();
                foreach (DataRow row in patient_data.Rows)
                {
                    patient_ids.Add(Convert.ToInt32(row.ItemArray[0]));
                }
                foreach (DataRow row in doctor_data.Rows)
                {
                    doctor_ids.Add(Convert.ToInt32(row.ItemArray[0]));
                }

                //Ids that are used in the db instead of the names we have in the comboboxes
                int patient_id = patient_ids[patient_index];
                int doctor_id = doctor_ids[doctor_index];

                Queries _queries = new Queries();
                _queries.ExecuteNonQuery($"INSERT INTO Appointments(status, location, doctor_id, patient_id, date, time) VALUES(\'{status}\', \'{location}\', {doctor_id}, {patient_id}, \'{date}\', \'{time}\')");

                Load_Table("SELECT appointment_id as [Appointment ID], status as [Status], (p.first_name + p.last_name) as [Patient], ('Dr. ' + d.last_name) as [Doctor], location as [Location], date as [Date], time as [Time]"
                    + "FROM Appointments a INNER JOIN Doctors d ON a.doctor_id = d.doctor_id INNER JOIN Patients p on a.patient_id = p.patient_id; ");
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
                    int appointment_id = Convert.ToInt32(row.Cells[0].Value);
                    Queries _queries = new Queries();
                    _queries.ExecuteNonQuery($"DELETE FROM Appointments WHERE appointment_id = {appointment_id}");
                }
                Load_Table("SELECT appointment_id as [Appointment ID], status as [Status], (p.first_name + p.last_name) as [Patient], ('Dr. ' + d.last_name) as [Doctor], location as [Location], date as [Date], time as [Time]"
                    + "FROM Appointments a INNER JOIN Doctors d ON a.doctor_id = d.doctor_id INNER JOIN Patients p on a.patient_id = p.patient_id; ");
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
