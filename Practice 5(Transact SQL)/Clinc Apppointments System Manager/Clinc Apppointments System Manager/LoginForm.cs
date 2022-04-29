using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Clinc_Apppointments_System_Manager
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
        //I need to create 4 dbs: users, doctors, patients, and appointments 
        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string input_user = userTextbox.Text;
                string input_pass = passTextbox.Text;
                User _user = new User(input_user, input_pass);
                bool userCheck = false;
                bool adminCheck = false;
                try
                {
                    userCheck = _user.checkUser();
                    adminCheck = _user.checkAdmin();
                }
                catch { }

                //Sends the user to different form depending on admin status
                if (userCheck == true && adminCheck == false)
                {
                    ClinicForm _clinicForm = new ClinicForm();
                    _clinicForm.Show();
                    this.Hide();

                }
                else if (userCheck == true && adminCheck == true)
                { 
                    AdminForm _adminForm = new AdminForm();
                    _adminForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This user is not valid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
