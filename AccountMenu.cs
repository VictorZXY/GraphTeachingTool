using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class AccountMenu : UserControl
    {
        #region Variables
        /// <summary>
        /// The ID of the account obtained from the database.
        /// </summary>
        public int accountID;
        
        /// <summary>
        /// The username of the account obtained from the database.
        /// </summary>
        public string username;
        
        /// <summary>
        /// The type of the account obtained from the database.
        /// </summary>
        public string accountType;

        /// <summary>
        /// The SQLite commands.
        /// </summary>
        string sql;

        /// <summary>
        /// The Sign up window to be opened when required.
        /// </summary>
        FormSignUp formSignUp;
        #endregion

        #region Constructor
        public AccountMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Represents an Account Menu, with all the necessary details. 
        /// </summary>
        public AccountMenu(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();
            this.accountID = accountID;
            this.username = username;
            this.labelAccountName.Text = accountName;
            this.accountType = accountType;
        }
        #endregion

        #region Events
        /// <summary>
        /// Show/hide the account option buttons.
        /// </summary>
        private void PictureBoxAccountOptions_Click(object sender, EventArgs e)
        {
            this.panelAccountOptions.Visible = !this.panelAccountOptions.Visible;
            if (this.panelAccountOptions.Visible)
                this.pictureBoxAccountOptions.Image = global::GraphTeachingTool.Properties.Resources.close;
            else
                this.pictureBoxAccountOptions.Image = global::GraphTeachingTool.Properties.Resources.menu;
        }

        /// <summary>
        /// Proceeds to the Account Settings Module.
        /// </summary>
        private void ButtonAccountSettings_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Enabled = false;
            ((Form)this.TopLevelControl).Hide();
            formSignUp = new FormSignUp();
            formSignUp.Text = "Account Settings";
            formSignUp.textBoxUsername.Text = this.username;
            formSignUp.textBoxUsername.Enabled = false;
            formSignUp.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSignUp_FormClosed);
            formSignUp.buttonSignUp.Text = "Submit";
            formSignUp.buttonSignUp.Click += new System.EventHandler(this.FormSignUp_buttonSignUp_Click);
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();
                sql = "SELECT Forename, Surname, DateOfBirth, Email, School "
                    + "FROM " + accountType + "S "
                    + "WHERE " + accountType + "S.AccountID = @AccountID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@AccountID", DbType.Int32) { Value = accountID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        switch (accountType)
                        {
                            case "TEACHER":
                                formSignUp.radioButtonTeacher.Checked = true;
                                formSignUp.radioButtonStudent.Checked = false;
                                break;
                            case "STUDENT":
                                formSignUp.radioButtonTeacher.Checked = false;
                                formSignUp.radioButtonStudent.Checked = true;
                                break;
                        }
                        formSignUp.labelAccountType.Enabled = false;
                        formSignUp.labelRequiredFieldAccountType.Enabled = false;
                        formSignUp.radioButtonTeacher.Enabled = false;
                        formSignUp.radioButtonStudent.Enabled = false;
                        formSignUp.textBoxForename.Text = reader["Forename"].ToString();
                        formSignUp.textBoxSurname.Text = reader["Surname"].ToString();
                        formSignUp.textBoxDateOfBirth.Text = reader["DateOfBirth"].ToString();
                        formSignUp.textBoxEmail.Text = reader["Email"].ToString();
                        formSignUp.textBoxSchool.Text = reader["School"].ToString();
                    }
                }
            }
            formSignUp.Show();
        }

        /// <summary>
        /// Resolve Sign Up button event in the Account Setting Module:
        /// Update new account information to the database
        /// </summary>
        private void FormSignUp_buttonSignUp_Click(object sender, EventArgs e)
        {
            if (formSignUp.ValidateSignUp(username))
            {
                using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                {
                    database.Open();
                    sql = "UPDATE ACCOUNTS "
                        + "SET Password = @Password "
                        + "WHERE AccountID = @AccountID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.AddRange(new SQLiteParameter[]
                        {
                            new SQLiteParameter("@Username", DbType.String) { Value = formSignUp.textBoxUsername.Text },
                            new SQLiteParameter("@Password", DbType.String) { Value = new MD5Hashing().Encrypt(formSignUp.textBoxPassword.Text) },
                            new SQLiteParameter("@AccountID", DbType.Int32) { Value = accountID }
                        });
                        command.ExecuteNonQuery();
                    }
                    sql = "UPDATE " + accountType + "S "
                        + "SET Forename = @Forename, "
                        + "    Surname = @Surname, "
                        + "    DateOfBirth = @DateOfBirth, "
                        + "    Email = @Email, "
                        + "    School = @School "
                        + "WHERE AccountID = @AccountID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.AddRange(new SQLiteParameter[]
                        {
                            new SQLiteParameter("@Forename", DbType.String) { Value = formSignUp.textBoxForename.Text },
                            new SQLiteParameter("@Surname", DbType.String) { Value = formSignUp.textBoxSurname.Text },
                            new SQLiteParameter("@DateOfBirth", DbType.String) { Value = formSignUp.textBoxDateOfBirth.Text },
                            new SQLiteParameter("@Email", DbType.String) { Value = formSignUp.textBoxEmail.Text },
                            new SQLiteParameter("@School", DbType.String) { Value = formSignUp.textBoxSchool.Text },
                            new SQLiteParameter("@AccountID", DbType.Int32) { Value = accountID }
                        });
                        command.ExecuteNonQuery();
                        this.labelAccountName.Text = command.Parameters["@Forename"].Value.ToString() + " " + command.Parameters["@Surname"].Value.ToString();
                    }
                }
                formSignUp.Close();
            }
        }

        /// <summary>
        /// Return to the original window.
        /// </summary>
        private void FormSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)this.TopLevelControl).Enabled = true;
            ((Form)this.TopLevelControl).Show();
        }

        /// <summary>
        /// Quit the system.
        /// </summary>
        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
