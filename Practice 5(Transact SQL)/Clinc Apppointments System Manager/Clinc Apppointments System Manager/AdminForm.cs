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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void doctorBtn_Click(object sender, EventArgs e)
        {
            DoctorForm _doctors = new DoctorForm();
            _doctors.Show();
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            AccountForm _accounts = new AccountForm();
            _accounts.Show();
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
