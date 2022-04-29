using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace School_System
{
    public partial class MainForm : Form
    {
        public User _user { get; set; }

        public MainForm(User _user)
        {
            InitializeComponent();
            this._user = _user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                int type = _user.type;
                if (type == 1)
                    usersToolStripMenuItem.Visible = true;
                userDisLabel.Text = _user.name;
                userDisLabel.AutoSize = true;
                userDisLabel.Location = new Point((this.Size.Width - (userDisLabel.Size.Width + 30)), userDisLabel.Location.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void Load_Table(string query)
        {
            Queries _queries = new Queries();
            DataTable data = _queries.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }

        //
        //File Tab
        //

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                string fileName = "data_image.jpeg";

                SaveFileDialog saver = new SaveFileDialog();
                saver.Filter = "Image Files | *jpeg";
                saver.InitialDirectory = Application.ExecutablePath;
                saver.FileName = fileName;
                if (saver.ShowDialog() == DialogResult.OK)
                {
                    string path = saver.FileName;
                    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("File was saved", "Results");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                using (PrintDocument printdoc = new PrintDocument())
                {
                    //Print Document Preparation
                    printdoc.DocumentName = "data";
                    printdoc.DefaultPageSettings.Landscape = true;
                    printdoc.PrintPage += new PrintPageEventHandler(printdoc_PrintPage);//Example:  this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
                    printdoc.Print();
                    void printdoc_PrintPage(object senderp, PrintPageEventArgs ep)//LOOK IT'S THE FUNNY FUNCTION
                    {
                        ep.Graphics.DrawImage(bmp, 0, 0);
                    }

                    //Setting up the actual printing
                    PrintPreviewDialog preview = new PrintPreviewDialog();
                    preview.Document = printdoc;
                    if(preview.ShowDialog() == DialogResult.OK)
                    {
                        PrintDialog print = new PrintDialog();
                        print.Document = printdoc;
                        print.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                  Yes I know this was a waste of time but I was 
                    just challenging my self by creating an entire new form form here.
                  Now I know what mostly everything component of these forms its basically a library but FANCY.
                  This is way more annoying so I will likely never do this again.
                */

                //Main value
                string password = "";

                //Practicing making a temp form
                Form tempForm = new Form();
                tempForm.Text = "Change Password";
                Point point = new Point(tempForm.Location.X + 10, tempForm.Location.Y + 10);
                //tempForm.Size = new Size(tempForm.Width, (int)(tempForm.Height * 0.5));

                Label label1 = new Label();
                label1.Font = SystemFonts.MessageBoxFont;
                label1.Text = "Enter New Password";
                label1.AutoSize = true;
                label1.Location = point;


                TextBox textBox1 = new TextBox();
                textBox1.Size = new Size(textBox1.Width * 2, textBox1.Height);
                textBox1.Location = new Point(point.X + 10, point.Y + 30);

                Label label2 = new Label();
                label2.Font = SystemFonts.MessageBoxFont;
                label2.Text = "Enter New Password";
                label2.AutoSize = true;
                label2.Location = new Point(point.X, point.Y + 60);

                TextBox textBox2 = new TextBox();
                textBox2.Size = new Size(textBox2.Width * 2, textBox2.Height);
                textBox2.Location = new Point(point.X + 10, point.Y + 90);


                Button changeBtn = new Button();
                changeBtn.Text = "Change Password";
                changeBtn.AutoSize = true;
                changeBtn.Location = new Point(point.X, point.Y + 120);
                changeBtn.DialogResult = DialogResult.OK;
                changeBtn.Click += new EventHandler(changeBtn_Click);
                void changeBtn_Click(Object senderb, EventArgs eb)
                {
                    try
                    {
                        password = textBox1.Text;
                        string confirm = textBox2.Text;

                        //Making sure they values equal eachother
                        if (password != confirm)
                        {
                            password = string.Empty;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                }

                tempForm.Controls.Add(label1);
                tempForm.Controls.Add(textBox1);
                tempForm.Controls.Add(label2);
                tempForm.Controls.Add(textBox2);
                tempForm.Controls.Add(changeBtn);

                if(tempForm.ShowDialog() == DialogResult.OK && password != string.Empty)
                {
                    Queries _queries = new Queries();
                    _queries.ExecuteNonQuery($"UPDATE users SET password = \'{password}\' WHERE user_id = {_user.user_id}");
                    Program.mainUser.password = password;
                }
                else
                {
                    throw new Exception("Passwords cannot be matching or empty");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                if(ex.Message == "Passwords cannot be matching or empty")
                {
                    changePasswordToolStripMenuItem.PerformClick();
                }
            }
        }

       

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();//Restarts the app which brings the user back to the login form
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        //
        //Student Tab
        //

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageForm _manageForm = new ManageForm(0);
                if(_manageForm.ShowDialog() == DialogResult.OK)
                {
                    string query = "SELECT * FROM students";
                    Load_Table(query);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                QueryForm _queryForm = new QueryForm();
                _queryForm.Text = "Student Search Form";
                _queryForm.searchQuery = "SELECT * FROM students";
                if(_queryForm.ShowDialog() == DialogResult.OK)
                {
                    string query = _queryForm.searchQuery;
                    Load_Table(query);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "SELECT * FROM students";
                Load_Table(query);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        
        //
        //Courses Tab
        //

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageForm _manageForm = new ManageForm(1);
                if (_manageForm.ShowDialog() == DialogResult.OK)
                {
                    string query = "SELECT * FROM courses";
                    Load_Table(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryForm _queryForm = new QueryForm();
            _queryForm.Text = "Courses Search Form";
            _queryForm.searchQuery = "SELECT * FROM courses";
            if (_queryForm.ShowDialog() == DialogResult.OK)
            {
                string query = _queryForm.searchQuery;
                Load_Table(query);
            }
        }

        private void viewCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "SELECT * FROM courses";
                DataTable data = _queries.ExecuteQuery(query);
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        //
        //Grade Tab
        //

        private void manageGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageForm _manageForm = new ManageForm(2);
                if (_manageForm.ShowDialog() == DialogResult.OK)
                {
                    string query = "SELECT * FROM grades";
                    Load_Table(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryForm _queryForm = new QueryForm();
            _queryForm.Text = "Grades Search Form";
            _queryForm.searchQuery = "SELECT * FROM grades";
            if (_queryForm.ShowDialog() == DialogResult.OK)
            {
                string query = _queryForm.searchQuery;
                Load_Table(query);
            }
        }

        private void viewGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "SELECT * FROM grades";
                DataTable data = _queries.ExecuteQuery(query);
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        //
        //User Tab
        //

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageForm _manageForm = new ManageForm(3);
                if (_manageForm.ShowDialog() == DialogResult.OK)
                {
                    string query = "SELECT * FROM users";
                    Load_Table(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                QueryForm _queryForm = new QueryForm();
                _queryForm.Text = "Users Search Form";
                _queryForm.searchQuery = "SELECT * FROM users";
                if (_queryForm.ShowDialog() == DialogResult.OK)
                {
                    string query = _queryForm.searchQuery;
                    Load_Table(query);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Queries _queries = new Queries();
                string query = "SELECT * FROM users";
                DataTable data = _queries.ExecuteQuery(query);
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        //
        //Tool Bar && Logout Link // These just link to other functions
        //

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            manageStudentsToolStripMenuItem.PerformClick();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            searchStudentsToolStripMenuItem.PerformClick();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printToolStripMenuItem.PerformClick();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logOutToolStripMenuItem.PerformClick();
        }
    }
}
