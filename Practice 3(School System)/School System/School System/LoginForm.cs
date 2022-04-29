using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                User _user = new User(textBox1.Text, textBox2.Text);
                _user.GetInfo();//Should throw if data is incorrect
                Program.mainUser = _user;//Gives the correct User data to mainUser in form
                this.Close();//The Main Form executes after getting user
            }
            catch (Exception ex)
            {
                MessageBox.Show($"User information that was entered is incorrect: {ex.Message}", "Error");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Program.mainUser = null;//Sets the main user to null so main form will not load
            Application.Exit();
        }
    }
}
