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
    public partial class ManageForm : Form
    {
        /*
         Key:
            Table Type 0: Students
            Table Type 1: Courses
            Table Type 2: Grades
            Table Type 3: Users
        */
        public int table_type { get; set; }//Receives a number from 0 - 3 changing what table we have to manage
        public ManageForm(int input)
        {
            InitializeComponent();
            this.table_type = input;
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                if(table_type == 0)//Students
                {
                    groupBox0.Visible = true;
                }
                else if(table_type == 1)//Courses
                {
                    groupBox1.Visible = true;
                }
                else if(table_type == 2)//Grades
                {
                    groupBox2.Visible = true;
                }
                else if(table_type == 3)//Users
                {
                    groupBox3.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void insBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "";
                if (table_type == 0)//Students
                {
                    int student_id = Convert.ToInt32(studentDial.Value);
                    string fname = studentFnTextbox.Text;
                    string lname = studentLnTextbox.Text;
                    string address = studentAddTextbox.Text;
                    string phone = studentPhTextbox.Text;
                    string email = studentEmTextbox.Text;

                    query = $"INSERT INTO students(first_name, last_name, address, phone_number, email) VALUES(\'{fname}\', \'{lname}\', \'{address}\', \'{phone}\', \'{email}\' )";
                }
                else if (table_type == 1)//Courses
                {
                    int course_id = Convert.ToInt32(courseDial.Value);
                    string name = courseNmTextbox.Text;
                    string description = courseDesTextbox.Text;
                    string director = courseDirTextbox.Text;
                    int hours = Convert.ToInt32(courseHrDial.Value);

                    query = $"INSERT INTO courses(course_name, description, instructor, hours_amount) VALUES(\'{name}\', \'{description}\', \'{director}\', {hours})";
                }
                else if (table_type == 2)//Grades
                {
                    int grade_id = Convert.ToInt32(gradeDial.Value);
                    char letter = gradeLttrTextbox.Text[0];
                    decimal percentage = Convert.ToDecimal(gradePerTextbox.Text) * (decimal)0.001;
                    int student_id = Convert.ToInt32(gradeStudentDial.Value);
                    int course_id = Convert.ToInt32(gradeCourseDial.Value);

                    query = $"INSERT INTO grades(letter_grade, percentage, student_id, course_id) VALUES(\'{letter}\', {percentage}, {student_id}, {course_id})";
                }
                else if (table_type == 3)//Users
                {
                    int user_id = Convert.ToInt32(userDial.Value);
                    string username = userUsnmTextbox.Text;
                    string password = userPassTextbox.Text;
                    string name = userNameTextbox.Text;
                    int type = 0;
                    if (adminCheckbox.Checked == true)
                    {
                        type = 1;
                    }

                    query = $"INSERT INTO users(username, password, name, type) VALUES(\'{username}\', \'{password}\', \'{name}\', b\'{type}\')";
                }
                _queries.ExecuteNonQuery(query);
                MessageBox.Show("An item was added to the database sucessfully", "Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void updBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "";
                if (table_type == 0)//Students
                {
                    int student_id = Convert.ToInt32(studentDial.Value);
                    string fname = studentFnTextbox.Text;
                    string lname = studentLnTextbox.Text;
                    string address = studentAddTextbox.Text;
                    string phone = studentPhTextbox.Text;
                    string email = studentEmTextbox.Text;

                    query = $"UPDATE students SET first_name = \'{fname}\', last_name = \'{lname}\', address = \'{address}\', phone_number = \'{phone}\', email = \'{email}\' WHERE student_id = {student_id}";
                }
                else if (table_type == 1)//Courses
                {
                    int course_id = Convert.ToInt32(courseDial.Value);
                    string name = courseNmTextbox.Text;
                    string description = courseDesTextbox.Text;
                    string director = courseDirTextbox.Text;
                    int hours = Convert.ToInt32(courseHrDial.Value);

                    query = $"UPDATE courses SET course_name = \'{name}\', description = \'{description}\', instructor = \'{director}\', hours_amount = {hours} WHERE course_id = {course_id}";
                }
                else if (table_type == 2)//Grades
                {
                    int grade_id = Convert.ToInt32(gradeDial.Value);
                    char letter = gradeLttrTextbox.Text[0];
                    decimal percentage = Convert.ToDecimal(gradePerTextbox) / 100;
                    int student_id = Convert.ToInt32(gradeStudentDial.Value);
                    int course_id = Convert.ToInt32(gradeCourseDial.Value);

                    query = $"UPDATE grades SET letter_grade = \'{letter}\', percentage = {percentage}, student_id = {student_id}, course_id = {course_id} WHERE grade_id = {grade_id}";
                }
                else if (table_type == 3)//Users
                {
                    int user_id = Convert.ToInt32(userDial.Value);
                    string username = userUsnmTextbox.Text;
                    string password = userPassTextbox.Text;
                    string name = userNameTextbox.Text;
                    int type = 0;
                    if (adminCheckbox.Checked == true)
                    {
                        type = 1;
                    }

                    query = $"UPDATE users SET username = \'{username}\', password = \'{password}\', name = \'{name}\', type = b\'{type}\' WHERE user_id = {user_id}";
                }
                _queries.ExecuteNonQuery(query);
                MessageBox.Show("An item was update from the database sucessfully", "Results");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "";
                if (table_type == 0)//Students
                {
                    int student_id = Convert.ToInt32(studentDial.Value);
                    query = $"DELETE FROM students WHERE student_id = {student_id}";
                }
                else if (table_type == 1)//Courses
                {
                    int course_id = Convert.ToInt32(courseDial.Value);
                    query = $"DELETE FROM courses WHERE course_id = {course_id}";
                }
                else if (table_type == 2)//Grades
                {
                    int grade_id = Convert.ToInt32(gradeDial.Value);
                    query = $"DELETE FROM grades WHERE grade_id = {grade_id}";
                }
                else if (table_type == 3)//Users
                {
                    int user_id = Convert.ToInt32(userDial.Value);
                    query = $"DELETE FROM users WHERE user_id = {user_id}";
                }
                _queries.ExecuteNonQuery(query);
                MessageBox.Show("An item was deleted from the database sucessfully", "Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void refBtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.GetType() == typeof(GroupBox))
                    {
                        foreach(Control c in ((GroupBox)ctrl).Controls)
                        {
                            if(c.GetType() == typeof(TextBox))
                            {
                                ((TextBox)c).Text = string.Empty;
                            }
                            else if(c.GetType() == typeof(NumericUpDown))
                            {
                                ((NumericUpDown)c).Value = 0;
                            }
                            else if(c.GetType() == typeof(CheckBox))
                            {
                                ((CheckBox)c).Checked = false;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
