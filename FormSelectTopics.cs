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
    public partial class FormSelectTopics : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        FormTopicOverview formTopicOverview;

        public FormSelectTopics(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;
        }

        private void ButtonAlgorithms_Click(object sender, EventArgs e)
        {
            string algorithmName = (sender as Button).Name.Trim("button".ToCharArray());
            this.Enabled = false;
            this.Hide();
            formTopicOverview = new FormTopicOverview(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType, algorithmName);
            formTopicOverview.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTopicOverview_FormClosed);
            formTopicOverview.Show();
        }

        private void FormTopicOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }
    }
}
