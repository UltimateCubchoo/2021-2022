namespace Clinc_Apppointments_System_Manager
{
    partial class PatientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.exitBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.phoneTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lnameTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fnameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zipTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addressTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.genderCombobox = new System.Windows.Forms.ComboBox();
            this.dobDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clinicDBDataSet = new Clinc_Apppointments_System_Manager.ClinicDBDataSet();
            this.clinicDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(679, 66);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(95, 48);
            this.exitBtn.TabIndex = 45;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(679, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(95, 48);
            this.deleteBtn.TabIndex = 44;
            this.deleteBtn.Text = "Delete Patient";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(578, 66);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(95, 48);
            this.updateBtn.TabIndex = 43;
            this.updateBtn.Text = "Update Patient";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(578, 12);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(95, 48);
            this.insertBtn.TabIndex = 42;
            this.insertBtn.Text = "Add Patient";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 207);
            this.dataGridView1.TabIndex = 40;
            // 
            // phoneTextbox
            // 
            this.phoneTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.phoneTextbox.Location = new System.Drawing.Point(391, 9);
            this.phoneTextbox.Name = "phoneTextbox";
            this.phoneTextbox.Size = new System.Drawing.Size(121, 23);
            this.phoneTextbox.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(300, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Phone:";
            // 
            // lnameTextbox
            // 
            this.lnameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lnameTextbox.Location = new System.Drawing.Point(118, 35);
            this.lnameTextbox.Name = "lnameTextbox";
            this.lnameTextbox.Size = new System.Drawing.Size(121, 23);
            this.lnameTextbox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Last Name:";
            // 
            // fnameTextbox
            // 
            this.fnameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fnameTextbox.Location = new System.Drawing.Point(118, 9);
            this.fnameTextbox.Name = "fnameTextbox";
            this.fnameTextbox.Size = new System.Drawing.Size(121, 23);
            this.fnameTextbox.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "First Name:";
            // 
            // zipTextbox
            // 
            this.zipTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.zipTextbox.Location = new System.Drawing.Point(391, 91);
            this.zipTextbox.Name = "zipTextbox";
            this.zipTextbox.Size = new System.Drawing.Size(121, 23);
            this.zipTextbox.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(300, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Zip Code:";
            // 
            // addressTextbox
            // 
            this.addressTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressTextbox.Location = new System.Drawing.Point(391, 50);
            this.addressTextbox.Name = "addressTextbox";
            this.addressTextbox.Size = new System.Drawing.Size(121, 23);
            this.addressTextbox.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(300, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "Address:";
            // 
            // genderCombobox
            // 
            this.genderCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genderCombobox.FormattingEnabled = true;
            this.genderCombobox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderCombobox.Location = new System.Drawing.Point(118, 63);
            this.genderCombobox.Name = "genderCombobox";
            this.genderCombobox.Size = new System.Drawing.Size(121, 24);
            this.genderCombobox.TabIndex = 50;
            // 
            // dobDateTimePicker
            // 
            this.dobDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dobDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dobDateTimePicker.Location = new System.Drawing.Point(118, 93);
            this.dobDateTimePicker.Name = "dobDateTimePicker";
            this.dobDateTimePicker.Size = new System.Drawing.Size(121, 23);
            this.dobDateTimePicker.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 17);
            this.label7.TabIndex = 53;
            this.label7.Text = "Date of Birth:";
            // 
            // clinicDBDataSet
            // 
            this.clinicDBDataSet.DataSetName = "ClinicDBDataSet";
            this.clinicDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clinicDBDataSetBindingSource
            // 
            this.clinicDBDataSetBindingSource.DataSource = this.clinicDBDataSet;
            this.clinicDBDataSetBindingSource.Position = 0;
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dobDateTimePicker);
            this.Controls.Add(this.genderCombobox);
            this.Controls.Add(this.addressTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zipTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.phoneTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fnameTextbox);
            this.Controls.Add(this.label1);
            this.Name = "PatientForm";
            this.Text = "PatientForm";
            this.Load += new System.EventHandler(this.PatientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox phoneTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lnameTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fnameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zipTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addressTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genderCombobox;
        private System.Windows.Forms.DateTimePicker dobDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ClinicDBDataSet clinicDBDataSet;
        private System.Windows.Forms.BindingSource clinicDBDataSetBindingSource;
    }
}