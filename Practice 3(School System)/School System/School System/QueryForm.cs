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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }
        public string searchQuery = "";

        private void QueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                searchTextBox.Text = searchQuery;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                searchQuery = searchTextBox.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


    }
}
