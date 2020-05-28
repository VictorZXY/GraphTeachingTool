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
    public partial class FormLogin : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// The sign up window to be opened when required.
        /// </summary>
        FormSignUp formSignUp;

        /// <summary>
        /// The primary menu window to be opened when a log in attempt is accepted.
        /// </summary>
        FormPrimaryMenu formPrimaryMenu;

        /// <summary>
        /// The SQLite command.
        /// </summary>
        string sql;
        #endregion

        #region Constructor
        public FormLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        // Hashing (Group A) is implemented here
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Validation
            if (textBoxUsername.Text == "" && textBoxPassword.Text == "")
                labelErrorMessage.Text = "Please enter your username and password!";
            else if (textBoxUsername.Text == "")
                labelErrorMessage.Text = "Please enter your username!";
            else if (textBoxPassword.Text == "")
                labelErrorMessage.Text = "Please enter your password!";
            // Respond to valid log in attempt
            else
            {
                // Get username and hashed password value
                string usernameText = textBoxUsername.Text;
                string passwordText = textBoxPassword.Text;
                string hashedPasswordValue = new MD5Hashing().Encrypt(passwordText);

                // Compare the values with the attributes saved in the database
                // Cross-table parameterised SQL (Group A) is implemented here.
                using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                {
                    database.Open();
                    sql = "SELECT AccountType FROM ACCOUNTS "
                        + "WHERE Username = @Username "
                        + "      AND Password = @Password;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.AddRange(new SQLiteParameter[]
                        {
                            new SQLiteParameter("@Username", DbType.String) { Value = usernameText },
                            new SQLiteParameter("@Password", DbType.String) { Value = hashedPasswordValue }
                        });
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelErrorMessage.Text = "";
                                string accountType = reader["AccountType"].ToString();
                                //if (accountType == "ADMINISTRATOR")
                                //{
                                //    This is used for the potential administrator control functionalities in future updates.
                                //}
                                //else
                                //{
                                sql = "SELECT " + accountType + "S.AccountID, " + accountType + "S.Forename, " + accountType + "S.Surname "
                                    + "FROM " + accountType + "S, ACCOUNTS "
                                    + "WHERE ACCOUNTS.Username = @Username "
                                    + "AND ACCOUNTS.AccountID = " + accountType + "S.AccountID;";
                                using (SQLiteCommand command2 = new SQLiteCommand(sql, database))
                                {
                                    command2.Parameters.Add(new SQLiteParameter("@Username", DbType.String) { Value = usernameText });
                                    using (SQLiteDataReader reader2 = command2.ExecuteReader())
                                    {
                                        this.Enabled = false;
                                        this.Hide();
                                        reader2.Read();
                                        int accountID = Convert.ToInt32(reader2["AccountID"]);
                                        string username = textBoxUsername.Text;
                                        string accountName = reader2["Forename"].ToString() + " " + reader2["Surname"].ToString();
                                        formPrimaryMenu = new FormPrimaryMenu(accountID, username, accountName, accountType);
                                        formPrimaryMenu.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
                                        formPrimaryMenu.Show();
                                    }
                                }
                                //}
                            }
                            else
                            {
                                labelErrorMessage.Text = "Invalid username/password!";
                            }
                        }
                    }
                }
            }
        }

        private void LinkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formSignUp = new FormSignUp();
            formSignUp.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
            formSignUp.buttonSignUp.Click += new System.EventHandler(this.FormSignUp_buttonSignUp_Click);
            formSignUp.Show();
        }

        private void OtherForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }

        // Hashing (Group A) is implemented here
        private void FormSignUp_buttonSignUp_Click(object sender, EventArgs e)
        {
            if (formSignUp.ValidateSignUp(""))
            {
                int accountID;
                string accountType;
                if (formSignUp.radioButtonTeacher.Checked)
                    accountType = "TEACHER";
                else accountType = "STUDENT";

                using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                {
                    database.Open();

                    // Insert new account credential record 
                    sql = "INSERT INTO ACCOUNTS (Username, Password, AccountType) "
                    + "VALUES (@Username, @Password, @AccountType);";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.AddRange(new SQLiteParameter[]
                        {
                            new SQLiteParameter("@Username", DbType.String) { Value = formSignUp.textBoxUsername.Text },
                            new SQLiteParameter("@Password", DbType.String) { Value = new MD5Hashing().Encrypt(formSignUp.textBoxPassword.Text)},
                            new SQLiteParameter("@AccountType", DbType.String) { Value = accountType }
                        });
                        command.ExecuteNonQuery();
                    }

                    // Retrieve AccountID from the newly inserted account credential record
                    sql = "SELECT AccountID FROM ACCOUNTS "
                        + "WHERE Username = @Username;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@Username", DbType.String) { Value = formSignUp.textBoxUsername.Text });
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            accountID = Convert.ToInt32(reader["AccountID"]);
                        }
                    }

                    // Insert new personal information record, with consistent foreign key value (AccountID)
                    sql = "INSERT INTO " + accountType + "S (Forename, Surname, DateOfBirth, Email, School, AccountID) "
                        + "VALUES (@Forename, @Surname, @DateOfBirth, @Email, @School, @AccountID);";
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
                    }
                }
                foreach (Control control in formSignUp.Controls)
                    if (control is TextBox || control.Name.Contains("labelErrorMessage"))
                        control.ResetText();
                formSignUp.Close();
                this.Enabled = true;
                this.Show();
            }
        }
        #endregion
    }
}
