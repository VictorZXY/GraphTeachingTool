using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormSignUp : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        /// <summary>
        /// The SQLite commands.
        /// </summary>
        string sql;

        public FormSignUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks if the input email address is in a valid syntax.
        /// </summary>
        /// <param name="email">The input email address.</param>
        /// <returns>Returns TRUE if the input email address is valid.</returns>
        private bool ValidateEmail(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateSignUp(string currentUsername)
        {
            bool validation = true;

            // Reset error message labels
            foreach (Control control in this.Controls)
                if (control.Name.Contains("labelErrorMessage"))
                    control.ResetText();

            // Check if the username is empty
            if (this.textBoxUsername.Text.Trim() == "")
            {
                this.labelErrorMessageUsername.Text = "Please choose a username!";
                validation = false;
            }

            // Check if the username does not meet the length requirements
            if (this.textBoxUsername.Text.Trim() != ""
                && (this.textBoxUsername.Text.Length < 6 || this.textBoxUsername.Text.Length > 20))
            {
                this.labelErrorMessageUsername.Text = "Invalid username!";
                validation = false;
            }

            // Check if the username has already been used
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();
                sql = "SELECT * FROM ACCOUNTS "
                    + "WHERE Username = @Username "
                    + "AND Username != @CurrentUsername;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.AddRange(new SQLiteParameter[]
                    {
                        new SQLiteParameter("@Username", DbType.String) { Value = this.textBoxUsername.Text },
                        new SQLiteParameter("@CurrentUsername", DbType.String) { Value = currentUsername }
                    });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.labelErrorMessageUsername.Text = "This username has already been taken!";
                            validation = false;
                        }
                    }
                }
            }

            // Check if the password is empty
            if (this.textBoxPassword.Text == "")
            {
                this.labelErrorMessagePassword.Text = "Please choose a password!";
                validation = false;
            }

            // Check if the password does not meet the length requirements
            if (this.textBoxPassword.Text != ""
                && (this.textBoxPassword.Text.Length < 8 || this.textBoxPassword.Text.Length > 20))
            {
                this.labelErrorMessagePassword.Text = "Invalid password!";
                validation = false;
            }

            // Check if the repeated password does not match the password
            if (this.textBoxRepeatPassword.Text != this.textBoxPassword.Text)
            {
                this.labelErrorMessageRepeatPassword.Text = "The repeated password does not match the password!";
                validation = false;
            }

            // Check if the forename is empty
            if (this.textBoxForename.Text == "")
            {
                this.labelErrorMessageForename.Text = "Please enter your forename!";
                validation = false;
            }

            // Check if the surname is empty
            if (this.textBoxSurname.Text == "")
            {
                this.labelErrorMessageSurname.Text = "Please enter your surname!";
                validation = false;
            }

            // Check if the school name is empty
            if (this.textBoxSchool.Text == "")
            {
                this.labelErrorMessageSchool.Text = "Please enter your school name!";
                validation = false;
            }

            // Check if the email is valid
            if (this.textBoxEmail.Text.Trim() != "" && !ValidateEmail(this.textBoxEmail.Text))
            {
                this.labelErrorMessageEmail.Text = "Invalid email address!";
                validation = false;
            }

            return validation;
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.textBoxRepeatPassword.Text = "";
        }

        private void ButtonShowCalendar_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = !monthCalendar.Visible;
            if (buttonShowCalendar.Text == "+")
                buttonShowCalendar.Text = "×";
            else
                buttonShowCalendar.Text = "+";
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar.SelectionStart.CompareTo(DateTime.Now.AddDays(-1)) < 0)
                textBoxDateOfBirth.Text = monthCalendar.SelectionStart.ToShortDateString();
            else textBoxDateOfBirth.Text = "";
        }
    }
}
