using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormPrimaryMenu : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        // External windows to be opened when requested
        FormSelectTopics formSelectTopics;
        FormTaskSetting formTaskSetting;
        FormQuestionBank formQuestionBank;

        public FormPrimaryMenu(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;

            // Decide account access authority.
            if (accountType == "STUDENT")
                this.buttonTaskSetting.Enabled = false;
            else if (accountType == "TEACHER")
                this.buttonTaskSetting.Enabled = true;
        }

        private void ButtonTeaching_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formSelectTopics = new FormSelectTopics(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType);
            formSelectTopics.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
            formSelectTopics.Show();
        }

        private void ButtonTaskSetting_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formTaskSetting = new FormTaskSetting(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, true);
            formTaskSetting.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
            formTaskSetting.Show();
        }

        private void ButtonQuestionBank_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formQuestionBank = new FormQuestionBank(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType);
            formQuestionBank.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
            formQuestionBank.Show();
        }

        private void OtherForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }
    }
}
