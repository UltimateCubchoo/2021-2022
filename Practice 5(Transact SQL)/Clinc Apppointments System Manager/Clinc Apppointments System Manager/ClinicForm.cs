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
    public partial class ClinicForm : Form
    {
        public ClinicForm()
        {
            InitializeComponent();
        }

        private void patientBtn_Click(object sender, EventArgs e)
        {
            PatientForm _patientForm = new PatientForm();
            _patientForm.Show();
        }

        private void appointmentBtn_Click(object sender, EventArgs e)
        {
            AppointmentForm _appointmentForm = new AppointmentForm();
            _appointmentForm.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login_Form _login = new Login_Form();
            _login.Show();
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
