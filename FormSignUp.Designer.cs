namespace GraphTeachingTool
{
    partial class FormSignUp
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelRequiredFieldUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelRequiredFieldPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelRepeatPassword = new System.Windows.Forms.Label();
            this.labelRequiredFieldRepeatPassword = new System.Windows.Forms.Label();
            this.textBoxRepeatPassword = new System.Windows.Forms.TextBox();
            this.labelAccountType = new System.Windows.Forms.Label();
            this.labelRequiredFieldAccountType = new System.Windows.Forms.Label();
            this.radioButtonTeacher = new System.Windows.Forms.RadioButton();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.labelForename = new System.Windows.Forms.Label();
            this.labelRequiredFieldForename = new System.Windows.Forms.Label();
            this.textBoxForename = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelRequiredFieldSurname = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.textBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.buttonShowCalendar = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxSchool = new System.Windows.Forms.TextBox();
            this.labelRequiredFieldSchool = new System.Windows.Forms.Label();
            this.labelSchool = new System.Windows.Forms.Label();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.labelErrorMessageUsername = new System.Windows.Forms.Label();
            this.labelErrorMessagePassword = new System.Windows.Forms.Label();
            this.labelErrorMessageRepeatPassword = new System.Windows.Forms.Label();
            this.labelErrorMessageForename = new System.Windows.Forms.Label();
            this.labelErrorMessageSurname = new System.Windows.Forms.Label();
            this.labelErrorMessageSchool = new System.Windows.Forms.Label();
            this.labelErrorMessageEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(553, 153);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(375, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username (6-20 characters, case sensitive):";
            // 
            // labelRequiredFieldUsername
            // 
            this.labelRequiredFieldUsername.AutoSize = true;
            this.labelRequiredFieldUsername.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldUsername.Location = new System.Drawing.Point(805, 153);
            this.labelRequiredFieldUsername.Name = "labelRequiredFieldUsername";
            this.labelRequiredFieldUsername.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldUsername.TabIndex = 1;
            this.labelRequiredFieldUsername.Text = "*";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(557, 180);
            this.textBoxUsername.MaxLength = 20;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(371, 31);
            this.textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(553, 214);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(246, 24);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password (8-20 characters):";
            // 
            // labelRequiredFieldPassword
            // 
            this.labelRequiredFieldPassword.AutoSize = true;
            this.labelRequiredFieldPassword.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldPassword.Location = new System.Drawing.Point(716, 214);
            this.labelRequiredFieldPassword.Name = "labelRequiredFieldPassword";
            this.labelRequiredFieldPassword.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldPassword.TabIndex = 4;
            this.labelRequiredFieldPassword.Text = "*";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(557, 241);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(371, 31);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            // 
            // labelRepeatPassword
            // 
            this.labelRepeatPassword.AutoSize = true;
            this.labelRepeatPassword.Location = new System.Drawing.Point(553, 275);
            this.labelRepeatPassword.Name = "labelRepeatPassword";
            this.labelRepeatPassword.Size = new System.Drawing.Size(162, 24);
            this.labelRepeatPassword.TabIndex = 6;
            this.labelRepeatPassword.Text = "Repeat password:";
            // 
            // labelRequiredFieldRepeatPassword
            // 
            this.labelRequiredFieldRepeatPassword.AutoSize = true;
            this.labelRequiredFieldRepeatPassword.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldRepeatPassword.Location = new System.Drawing.Point(660, 275);
            this.labelRequiredFieldRepeatPassword.Name = "labelRequiredFieldRepeatPassword";
            this.labelRequiredFieldRepeatPassword.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldRepeatPassword.TabIndex = 7;
            this.labelRequiredFieldRepeatPassword.Text = "*";
            // 
            // textBoxRepeatPassword
            // 
            this.textBoxRepeatPassword.Location = new System.Drawing.Point(557, 302);
            this.textBoxRepeatPassword.MaxLength = 20;
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.Size = new System.Drawing.Size(371, 31);
            this.textBoxRepeatPassword.TabIndex = 8;
            this.textBoxRepeatPassword.UseSystemPasswordChar = true;
            // 
            // labelAccountType
            // 
            this.labelAccountType.AutoSize = true;
            this.labelAccountType.Location = new System.Drawing.Point(553, 336);
            this.labelAccountType.Name = "labelAccountType";
            this.labelAccountType.Size = new System.Drawing.Size(96, 24);
            this.labelAccountType.TabIndex = 9;
            this.labelAccountType.Text = "Are you a:";
            // 
            // labelRequiredFieldAccountType
            // 
            this.labelRequiredFieldAccountType.AutoSize = true;
            this.labelRequiredFieldAccountType.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldAccountType.Location = new System.Drawing.Point(614, 336);
            this.labelRequiredFieldAccountType.Name = "labelRequiredFieldAccountType";
            this.labelRequiredFieldAccountType.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldAccountType.TabIndex = 10;
            this.labelRequiredFieldAccountType.Text = "*";
            // 
            // radioButtonTeacher
            // 
            this.radioButtonTeacher.AutoSize = true;
            this.radioButtonTeacher.Location = new System.Drawing.Point(692, 334);
            this.radioButtonTeacher.Name = "radioButtonTeacher";
            this.radioButtonTeacher.Size = new System.Drawing.Size(102, 28);
            this.radioButtonTeacher.TabIndex = 11;
            this.radioButtonTeacher.Text = "Teacher";
            this.radioButtonTeacher.UseVisualStyleBackColor = true;
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Checked = true;
            this.radioButtonStudent.Location = new System.Drawing.Point(825, 334);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(103, 28);
            this.radioButtonStudent.TabIndex = 12;
            this.radioButtonStudent.TabStop = true;
            this.radioButtonStudent.Text = "Student";
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            // 
            // labelForename
            // 
            this.labelForename.AutoSize = true;
            this.labelForename.Location = new System.Drawing.Point(553, 366);
            this.labelForename.Name = "labelForename";
            this.labelForename.Size = new System.Drawing.Size(100, 24);
            this.labelForename.TabIndex = 13;
            this.labelForename.Text = "Forename:";
            // 
            // labelRequiredFieldForename
            // 
            this.labelRequiredFieldForename.AutoSize = true;
            this.labelRequiredFieldForename.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldForename.Location = new System.Drawing.Point(616, 366);
            this.labelRequiredFieldForename.Name = "labelRequiredFieldForename";
            this.labelRequiredFieldForename.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldForename.TabIndex = 14;
            this.labelRequiredFieldForename.Text = "*";
            // 
            // textBoxForename
            // 
            this.textBoxForename.Location = new System.Drawing.Point(557, 393);
            this.textBoxForename.MaxLength = 140;
            this.textBoxForename.Name = "textBoxForename";
            this.textBoxForename.Size = new System.Drawing.Size(371, 31);
            this.textBoxForename.TabIndex = 15;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(557, 454);
            this.textBoxSurname.MaxLength = 140;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(371, 31);
            this.textBoxSurname.TabIndex = 18;
            // 
            // labelRequiredFieldSurname
            // 
            this.labelRequiredFieldSurname.AutoSize = true;
            this.labelRequiredFieldSurname.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldSurname.Location = new System.Drawing.Point(609, 427);
            this.labelRequiredFieldSurname.Name = "labelRequiredFieldSurname";
            this.labelRequiredFieldSurname.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldSurname.TabIndex = 17;
            this.labelRequiredFieldSurname.Text = "*";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(553, 427);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(90, 24);
            this.labelSurname.TabIndex = 16;
            this.labelSurname.Text = "Surname:";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.monthCalendar.Location = new System.Drawing.Point(556, 538);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 19;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDateOfBirth.Location = new System.Drawing.Point(557, 515);
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.ReadOnly = true;
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(349, 31);
            this.textBoxDateOfBirth.TabIndex = 22;
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Location = new System.Drawing.Point(553, 488);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(124, 24);
            this.labelDateOfBirth.TabIndex = 20;
            this.labelDateOfBirth.Text = "Date of birth:";
            // 
            // buttonShowCalendar
            // 
            this.buttonShowCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCalendar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonShowCalendar.Location = new System.Drawing.Point(905, 515);
            this.buttonShowCalendar.Name = "buttonShowCalendar";
            this.buttonShowCalendar.Size = new System.Drawing.Size(23, 23);
            this.buttonShowCalendar.TabIndex = 23;
            this.buttonShowCalendar.Text = "+";
            this.buttonShowCalendar.UseVisualStyleBackColor = true;
            this.buttonShowCalendar.Click += new System.EventHandler(this.ButtonShowCalendar_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(557, 576);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(371, 31);
            this.textBoxEmail.TabIndex = 26;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(553, 549);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(61, 24);
            this.labelEmail.TabIndex = 24;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxSchool
            // 
            this.textBoxSchool.Location = new System.Drawing.Point(557, 637);
            this.textBoxSchool.Name = "textBoxSchool";
            this.textBoxSchool.Size = new System.Drawing.Size(371, 31);
            this.textBoxSchool.TabIndex = 29;
            // 
            // labelRequiredFieldSchool
            // 
            this.labelRequiredFieldSchool.AutoSize = true;
            this.labelRequiredFieldSchool.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredFieldSchool.Location = new System.Drawing.Point(597, 610);
            this.labelRequiredFieldSchool.Name = "labelRequiredFieldSchool";
            this.labelRequiredFieldSchool.Size = new System.Drawing.Size(18, 24);
            this.labelRequiredFieldSchool.TabIndex = 28;
            this.labelRequiredFieldSchool.Text = "*";
            // 
            // labelSchool
            // 
            this.labelSchool.AutoSize = true;
            this.labelSchool.Location = new System.Drawing.Point(553, 610);
            this.labelSchool.Name = "labelSchool";
            this.labelSchool.Size = new System.Drawing.Size(71, 24);
            this.labelSchool.TabIndex = 27;
            this.labelSchool.Text = "School:";
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignUp.Location = new System.Drawing.Point(682, 674);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(120, 31);
            this.buttonSignUp.TabIndex = 33;
            this.buttonSignUp.Text = "Sign up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            // 
            // labelErrorMessageUsername
            // 
            this.labelErrorMessageUsername.AutoSize = true;
            this.labelErrorMessageUsername.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageUsername.Location = new System.Drawing.Point(934, 183);
            this.labelErrorMessageUsername.Name = "labelErrorMessageUsername";
            this.labelErrorMessageUsername.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageUsername.TabIndex = 34;
            // 
            // labelErrorMessagePassword
            // 
            this.labelErrorMessagePassword.AutoSize = true;
            this.labelErrorMessagePassword.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessagePassword.Location = new System.Drawing.Point(934, 244);
            this.labelErrorMessagePassword.Name = "labelErrorMessagePassword";
            this.labelErrorMessagePassword.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessagePassword.TabIndex = 35;
            // 
            // labelErrorMessageRepeatPassword
            // 
            this.labelErrorMessageRepeatPassword.AutoSize = true;
            this.labelErrorMessageRepeatPassword.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageRepeatPassword.Location = new System.Drawing.Point(934, 305);
            this.labelErrorMessageRepeatPassword.Name = "labelErrorMessageRepeatPassword";
            this.labelErrorMessageRepeatPassword.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageRepeatPassword.TabIndex = 36;
            // 
            // labelErrorMessageForename
            // 
            this.labelErrorMessageForename.AutoSize = true;
            this.labelErrorMessageForename.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageForename.Location = new System.Drawing.Point(934, 396);
            this.labelErrorMessageForename.Name = "labelErrorMessageForename";
            this.labelErrorMessageForename.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageForename.TabIndex = 38;
            // 
            // labelErrorMessageSurname
            // 
            this.labelErrorMessageSurname.AutoSize = true;
            this.labelErrorMessageSurname.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageSurname.Location = new System.Drawing.Point(934, 457);
            this.labelErrorMessageSurname.Name = "labelErrorMessageSurname";
            this.labelErrorMessageSurname.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageSurname.TabIndex = 39;
            // 
            // labelErrorMessageSchool
            // 
            this.labelErrorMessageSchool.AutoSize = true;
            this.labelErrorMessageSchool.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageSchool.Location = new System.Drawing.Point(934, 640);
            this.labelErrorMessageSchool.Name = "labelErrorMessageSchool";
            this.labelErrorMessageSchool.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageSchool.TabIndex = 40;
            // 
            // labelErrorMessageEmail
            // 
            this.labelErrorMessageEmail.AutoSize = true;
            this.labelErrorMessageEmail.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessageEmail.Location = new System.Drawing.Point(934, 579);
            this.labelErrorMessageEmail.Name = "labelErrorMessageEmail";
            this.labelErrorMessageEmail.Size = new System.Drawing.Size(0, 24);
            this.labelErrorMessageEmail.TabIndex = 41;
            // 
            // FormSignUp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelErrorMessageEmail);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.labelErrorMessageSchool);
            this.Controls.Add(this.labelErrorMessageSurname);
            this.Controls.Add(this.labelErrorMessageForename);
            this.Controls.Add(this.labelErrorMessageRepeatPassword);
            this.Controls.Add(this.labelErrorMessagePassword);
            this.Controls.Add(this.labelErrorMessageUsername);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.textBoxSchool);
            this.Controls.Add(this.labelRequiredFieldSchool);
            this.Controls.Add(this.labelSchool);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.buttonShowCalendar);
            this.Controls.Add(this.textBoxDateOfBirth);
            this.Controls.Add(this.labelDateOfBirth);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelRequiredFieldSurname);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxForename);
            this.Controls.Add(this.labelRequiredFieldForename);
            this.Controls.Add(this.labelForename);
            this.Controls.Add(this.radioButtonStudent);
            this.Controls.Add(this.radioButtonTeacher);
            this.Controls.Add(this.labelRequiredFieldAccountType);
            this.Controls.Add(this.labelAccountType);
            this.Controls.Add(this.textBoxRepeatPassword);
            this.Controls.Add(this.labelRequiredFieldRepeatPassword);
            this.Controls.Add(this.labelRepeatPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelRequiredFieldPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelRequiredFieldUsername);
            this.Controls.Add(this.labelUsername);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelRequiredFieldUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRequiredFieldPassword;
        private System.Windows.Forms.Label labelRepeatPassword;
        private System.Windows.Forms.Label labelRequiredFieldRepeatPassword;
        private System.Windows.Forms.Label labelForename;
        private System.Windows.Forms.Label labelRequiredFieldForename;
        private System.Windows.Forms.Label labelRequiredFieldSurname;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Button buttonShowCalendar;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelRequiredFieldSchool;
        private System.Windows.Forms.Label labelSchool;
        public System.Windows.Forms.Button buttonSignUp;
        public System.Windows.Forms.Label labelErrorMessageUsername;
        public System.Windows.Forms.Label labelErrorMessagePassword;
        public System.Windows.Forms.Label labelErrorMessageRepeatPassword;
        public System.Windows.Forms.Label labelErrorMessageForename;
        public System.Windows.Forms.Label labelErrorMessageSurname;
        public System.Windows.Forms.Label labelErrorMessageSchool;
        public System.Windows.Forms.TextBox textBoxUsername;
        public System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxRepeatPassword;
        public System.Windows.Forms.TextBox textBoxForename;
        public System.Windows.Forms.TextBox textBoxSurname;
        public System.Windows.Forms.TextBox textBoxDateOfBirth;
        public System.Windows.Forms.TextBox textBoxEmail;
        public System.Windows.Forms.TextBox textBoxSchool;
        public System.Windows.Forms.RadioButton radioButtonTeacher;
        public System.Windows.Forms.RadioButton radioButtonStudent;
        public System.Windows.Forms.Label labelAccountType;
        public System.Windows.Forms.Label labelRequiredFieldAccountType;
        public System.Windows.Forms.Label labelErrorMessageEmail;
    }
}