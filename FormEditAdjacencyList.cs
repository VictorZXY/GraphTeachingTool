using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormEditAdjacencyList : Form
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
        public bool submitSuccessful = false;
        #endregion

        #region Constructor
        public FormEditAdjacencyList(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;

            // Create rows for the data grid view.
            this.dataGridViewAdjacencyList.RowCount = 26;
            for (int i = 0; i < 26; i++)
                this.dataGridViewAdjacencyList[0, i].Value = (Convert.ToChar('A' + i)).ToString();

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
            for (int vertex = 0; vertex < 26; vertex++)
                if (dataGridViewAdjacencyList[1, vertex].Value != null)
                {
                    string adjacentEdges = dataGridViewAdjacencyList[1, vertex].Value.ToString();
                    byte[] adjacentEdgesBytes = Encoding.ASCII.GetBytes(adjacentEdges.Replace(" ", string.Empty).Replace(",", "\n"));
                    MemoryStream adjacentEdgesStream = new MemoryStream(adjacentEdgesBytes);
                    using (StreamReader reader = new StreamReader(adjacentEdgesStream))
                    {
                        try
                        {
                            string newValue;
                            string state = "vertex";
                            char finishingVertex = '\0';
                            double weight;
                            while ((newValue = reader.ReadLine()) != null)
                            {
                                if (state == "vertex")
                                {
                                    finishingVertex = Convert.ToChar(newValue);
                                    if (!(finishingVertex >= 'A' && finishingVertex <= 'Z')) // Invalid vertex name exception
                                    {
                                        dataGridViewAdjacencyList[1, vertex].Style = dataGridViewCellStyle_Invalid;
                                        string vertexName = Convert.ToChar('A' + vertex).ToString();
                                        MessageBox.Show("Invalid input at vertex " + vertexName + "!");
                                        flag = false;
                                        continue;
                                    }
                                    else if (finishingVertex == vertex + 'A') // Self loop exception
                                    {
                                        dataGridViewAdjacencyList[1, vertex].Style = dataGridViewCellStyle_Invalid;
                                        string vertexName = Convert.ToChar('A' + vertex).ToString();
                                        MessageBox.Show("Self loop at vertex " + vertexName + "!");
                                        flag = false;
                                        state = "weight";
                                    }
                                    else // Valid input
                                        state = "weight";
                                }
                                else // if (state == "weight")
                                {
                                    if (newValue.Length == 1 && Convert.ToChar(newValue) >= 'A' && Convert.ToChar(newValue) <= 'Z') // Weight is omitted - default weight 1
                                    {
                                        if (finishingVertex == vertex + 'A') // Self loop exception
                                        {
                                            dataGridViewAdjacencyList[1, vertex].Style = dataGridViewCellStyle_Invalid;
                                            string vertexName = Convert.ToChar('A' + vertex).ToString();
                                            MessageBox.Show("Self loop at vertex " + vertexName + "!");
                                            flag = false;
                                        }
                                        else // Valid input
                                        {
                                            mapMatrix.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), 1);
                                            mapList.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), 1);
                                            finishingVertex = Convert.ToChar(newValue);
                                        }
                                        state = "weight";
                                    }
                                    else // Weight is specified
                                    {
                                        weight = Convert.ToDouble(newValue);
                                        if (weight > 0) // Valid input
                                        {
                                            mapMatrix.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), weight);
                                            mapList.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), weight);
                                        }
                                        else if (weight < 0) // Negative edge exception
                                        {
                                            dataGridViewAdjacencyList[1, vertex].Style = dataGridViewCellStyle_Invalid;
                                            string vStart = Convert.ToChar('A' + vertex).ToString();
                                            string vFinish = finishingVertex.ToString();
                                            MessageBox.Show("Negative weight at edge " + vStart + vFinish + "!");
                                            flag = false;
                                        }
                                        finishingVertex = '\0';
                                        state = "vertex";
                                    }
                                }
                            }
                            if (finishingVertex != '\0')
                            {
                                mapMatrix.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), 1);
                                mapList.SetDirectedEdge(vertex, Convert.ToInt32(finishingVertex - 'A'), 1);
                            }
                        }
                        catch
                        {
                            dataGridViewAdjacencyList[1, vertex].Style = dataGridViewCellStyle_Invalid;
                            string vertexName = Convert.ToChar('A' + vertex).ToString();
                            MessageBox.Show("Invalid input at vertex " + vertexName + "!");
                            flag = false;
                        }
                    }
                }
            submitSuccessful = flag;
        }

        private void DataGridViewAdjacencyList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Detect any text change and then enable submission
            if (e.ColumnIndex != 0) // Exclude text change in initialising column headers
                buttonSubmit.Enabled = true;
        }
        #endregion
    }
}
