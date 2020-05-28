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
    public partial class FormEditAdjacencyMatrix : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Adjacency matrix representation of the graph.
        /// </summary>
        AdjacencyMatrix mapMatrix;

        /// <summary>
        /// Adjacency list representation of the graph.
        /// </summary>
        AdjacencyList mapList;

        /// <summary>
        /// Constant cell GUI design for an invalid entry.
        /// </summary>
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle_Invalid = new System.Windows.Forms.DataGridViewCellStyle();

        /// <summary>
        /// Constant cell GUI design for a valid entry.
        /// </summary>
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle_Valid = new System.Windows.Forms.DataGridViewCellStyle();

        /// <summary>
        /// Indicator for a successful submission.
        /// </summary>
        public bool submitSuccessful;
        #endregion

        #region Constructor
        public FormEditAdjacencyMatrix(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            submitSuccessful = false;

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;

            // Create rows for the data grid view.
            this.dataGridViewAdjacencyMatrix.RowCount = 26;
            for (int i = 0; i < 26; i++)
            {
                this.dataGridViewAdjacencyMatrix[0, i].Value = (Convert.ToChar('A' + i)).ToString();
                this.dataGridViewAdjacencyMatrix[i + 1, i].ReadOnly = true; // Prevent self loop
            }

            // Set the cell style for invalid and valid inputs
            dataGridViewCellStyle_Invalid.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC7CE");
            dataGridViewCellStyle_Invalid.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9C0006");
            dataGridViewCellStyle_Valid.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle_Valid.ForeColor = System.Drawing.SystemColors.ControlText;
        }
        #endregion

        #region "Get" Functions
        public AdjacencyMatrix GetMatrix()
        {
            return mapMatrix;
        }

        public AdjacencyList GetList()
        {
            return mapList;
        }
        #endregion

        #region Events
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            mapMatrix = new AdjacencyMatrix();
            mapList = new AdjacencyList();
            for (int col = 1; col <= 26; col++)
                for (int row = 0; row < 26; row++)
                {
                    dataGridViewAdjacencyMatrix[col, row].Style = dataGridViewCellStyle_Valid;
                    try
                    {
                        if (dataGridViewAdjacencyMatrix[col, row].Value != null && dataGridViewAdjacencyMatrix[col, row].Value.ToString() != "")
                        {
                            dataGridViewAdjacencyMatrix[col, row].Value = dataGridViewAdjacencyMatrix[col, row].Value.ToString().Trim();
                            if (dataGridViewAdjacencyMatrix[col, row].Value != null
                                && Convert.ToDouble(dataGridViewAdjacencyMatrix[col, row].Value.ToString()) > 0) // Valid entry
                            {
                                mapMatrix.SetDirectedEdge(col - 1, row, Convert.ToDouble(dataGridViewAdjacencyMatrix[col, row].Value.ToString()));
                                mapList.SetDirectedEdge(col - 1, row, Convert.ToDouble(dataGridViewAdjacencyMatrix[col, row].Value.ToString()));
                            }
                            else if (dataGridViewAdjacencyMatrix[col, row].Value != null
                                && Convert.ToDouble(dataGridViewAdjacencyMatrix[col, row].Value.ToString()) < 0) // Negative edge exception
                            {
                                dataGridViewAdjacencyMatrix[col, row].Style = dataGridViewCellStyle_Invalid;
                                string colName = Convert.ToChar('A' + col - 1).ToString();
                                string rowName = Convert.ToChar('A' + row).ToString();
                                MessageBox.Show("Negative weight at row: " + rowName + ", column: " + colName + "!");
                                flag = false;
                            }
                        }
                    }
                    catch // Invalid weight input
                    {
                        dataGridViewAdjacencyMatrix[col, row].Style = dataGridViewCellStyle_Invalid;
                        string colName = Convert.ToChar('A' + col - 1).ToString();
                        string rowName = Convert.ToChar('A' + row).ToString();
                        MessageBox.Show("Invalid input at row: " + rowName + ", column: " + colName + "!");
                        flag = false;
                    }
                }
            submitSuccessful = flag;
        }

        private void DataGridViewAdjacencyMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Detect any text change and then enable submission
            if (e.ColumnIndex != 0) // Exclude text change in initialising column headers
                buttonSubmit.Enabled = true;
        }
        #endregion
    }
}
