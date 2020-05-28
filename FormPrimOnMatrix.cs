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
    public partial class FormPrimOnMatrix : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Represents the current step of the algorithm demonstration.
        /// </summary>
        int currentStep = 1;

        /// <summary>
        /// Total weight of the Minimum Spanning Tree.
        /// </summary>
        double weightMST = 0;

        /// <summary>
        /// A list of indices of vertices that have been visited by Prim's algorithm.
        /// </summary>
        List<int> visitedVertices = new List<int>();

        /// <summary>
        /// A list of indices of vertices that have not yet been visited by Prim's algorithm.
        /// </summary>
        List<int> remainingVertices = new List<int>();

        /// <summary>
        /// A list of candidate edges, specified by its starting vertex and finishing vertex.
        /// </summary>
        List<int[]> candidateEdges = new List<int[]>();

        /// <summary>
        /// The newly selected edge to be used in the current iteration. 
        /// </summary>
        int[] newEdge = new int[2];

        /// <summary>
        /// The example number.
        /// </summary>
        readonly int example;

        /// <summary>
        /// The example graph.
        /// </summary>
        MinimumSpanningTreeExample exampleGraph;

        /// <summary>
        /// A list of all the vertex controls on the painted graph.
        /// </summary>
        List<Vertex> vertices;

        /// <summary>
        /// The adjacency matrix representation of the example graph.
        /// </summary>
        AdjacencyMatrix mapMatrix = new AdjacencyMatrix();

        /// <summary>
        /// Array of the highlighting states of all the edges in the graph (highlighted/not highlighted).
        /// </summary>
        bool[,] edgeFocused = new bool[26, 26];

        // Readonly fonts for entries in the table 
        readonly Font strikeoutFont = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        readonly Font regularFont = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        readonly Font boldFont = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        #endregion

        #region Constructor
        public FormPrimOnMatrix(int accountID, string username, string accountName, string accountType, int example)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;
            this.example = example;

            // Select the correct example graph to perform the demonstration.
            if (example == 1)
                exampleGraph = new MinimumSpanningTreeExample1(this.panelGraph);
            else
                exampleGraph = new MinimumSpanningTreeExample2(this.panelGraph);

            // Initialise the example graph.
            vertices = exampleGraph.GetVertices();
            mapMatrix = exampleGraph.GetMatrix();

            // Initialise the table for the example graph.
            for (int i = 0; i <= mapMatrix.Count(); i++)
            {
                DataGridViewColumn newColumn = new DataGridViewColumn
                {
                    CellTemplate = new DataGridViewTextBoxCell(),
                    SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                    Width = 60
                };
                if (i == 0)
                    newColumn.Width = 41;
                dataGridViewGraph.Columns.Add(newColumn);
            }

            int count = 1;
            for (int i = 0; i < mapMatrix.GetSize(); i++)
                if (mapMatrix.IsVertexExisting(i))
                {
                    dataGridViewGraph.Columns[count].HeaderText = Convert.ToChar('A' + i).ToString();
                    dataGridViewGraph.Columns[count].Name = "Column" + dataGridViewGraph.Columns[count].HeaderText;
                    count++;
                }

            count = 0;
            this.dataGridViewGraph.RowCount = mapMatrix.Count();
            for (int i = 0; i < mapMatrix.GetSize(); i++)
                if (mapMatrix.IsVertexExisting(i))
                    this.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

            for (int col = 1; col <= mapMatrix.Count(); col++)
                for (int row = 0; row < mapMatrix.Count(); row++)
                {
                    int vStartIndex = mapMatrix.GetVertexIndex(dataGridViewGraph.Columns[col].HeaderText);
                    int vFinishIndex = mapMatrix.GetVertexIndex(this.dataGridViewGraph[0, row].Value.ToString());
                    if (mapMatrix.ContainsEdge(vStartIndex, vFinishIndex))
                        this.dataGridViewGraph[col, row].Value = mapMatrix.GetEdge(vStartIndex, vFinishIndex);
                    else
                        this.dataGridViewGraph[col, row].Value = "-";
                }
        }
        #endregion

        #region Events and Functions for GUI
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (Vertex vertex in vertices)
                {
                    if (remainingVertices.Contains(vertex.GetNumberIndex()))
                    {
                        vertex.labelName.ForeColor = SystemColors.ControlText;
                        vertex.labelName.Font = regularFont;
                    }
                    if (visitedVertices.Contains(vertex.GetNumberIndex()))
                    {
                        vertex.labelName.ForeColor = Color.Red;
                        vertex.labelName.Font = boldFont;
                    }
                }
                foreach (Vertex v1 in vertices)
                    foreach (Vertex v2 in v1.GetEdges())
                        if (v2.GetNumberIndex() > v1.GetNumberIndex())
                        {
                            if (edgeFocused[v1.GetNumberIndex(), v2.GetNumberIndex()])
                            {
                                g.DrawLine(new Pen(Color.Red, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                                exampleGraph.labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].ForeColor = Color.Red;
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Black, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                                exampleGraph.labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].ForeColor = SystemColors.ControlText;
                            }
                            Point midPoint = new Point
                            (
                                (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                            );
                        }
            }
        }

        // Polymorphism (Group A) is implemented here.
        private void EdgeFocusOn(Vertex v1, Vertex v2)
        {
            edgeFocused[v1.GetNumberIndex(), v2.GetNumberIndex()] = true;
            edgeFocused[v2.GetNumberIndex(), v1.GetNumberIndex()] = true;
            this.panelGraph.Refresh();
        }

        // Polymorphism (Group A) is implemented here.
        private void EdgeFocusOn(int v1, int v2)
        {
            edgeFocused[v1, v2] = true;
            edgeFocused[v2, v1] = true;
            this.panelGraph.Refresh();
        }

        // Polymorphism (Group A) is implemented here.
        private void EdgeFocusOff(Vertex v1, Vertex v2)
        {
            edgeFocused[v1.GetNumberIndex(), v2.GetNumberIndex()] = false;
            edgeFocused[v2.GetNumberIndex(), v1.GetNumberIndex()] = false;
            this.panelGraph.Refresh();
        }

        // Polymorphism (Group A) is implemented here.
        private void EdgeFocusOff(int v1, int v2)
        {
            edgeFocused[v1, v2] = false;
            edgeFocused[v2, v1] = false;
            this.panelGraph.Refresh();
        }
        #endregion

        #region Events and Functions for Algorithms
        // Graph/Tree Traversal (Group A) is implemented here.
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (buttonNext.Text == "Close")
            {
                this.Close();
            }
            else
            {
                labelInformation.Visible = true;
                double min;

                // Step 1 operation
                if (currentStep == 1)
                {
                    // Highlight current step
                    label1.ForeColor = Color.Red;
                    labelStep1.ForeColor = Color.Red;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = SystemColors.ControlText;
                    labelStep3.ForeColor = SystemColors.ControlText;
                    label4.ForeColor = SystemColors.ControlText;
                    labelStep4.ForeColor = SystemColors.ControlText;
                    label5.ForeColor = SystemColors.ControlText;
                    labelStep5.ForeColor = SystemColors.ControlText;

                    // Initialise Prim's algorithm
                    for (int i = 0; i < mapMatrix.GetSize(); i++)
                        if (mapMatrix.IsVertexExisting(i))
                            remainingVertices.Add(i);
                    labelInformation.Text = "Please pick a vertex of your choice:\nPlease click on the headers of the tableau.";
                    buttonNext.Enabled = false;
                }

                // Step 2 operation
                else if (currentStep == 2)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = Color.Red;
                    labelStep2.ForeColor = Color.Red;
                    label3.ForeColor = SystemColors.ControlText;
                    labelStep3.ForeColor = SystemColors.ControlText;
                    label4.ForeColor = SystemColors.ControlText;
                    labelStep4.ForeColor = SystemColors.ControlText;
                    label5.ForeColor = SystemColors.ControlText;
                    labelStep5.ForeColor = SystemColors.ControlText;

                    // Find minimum value of edge weight and candidate edges
                    min = double.MaxValue;
                    candidateEdges.Clear();

                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (mapMatrix.ContainsEdge(i, j) && mapMatrix.GetEdge(i, j) < min) // Find minimum value of edge weight
                                min = mapMatrix.GetEdge(i, j);

                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (mapMatrix.ContainsEdge(i, j) && mapMatrix.GetEdge(i, j) == min) // Find candidate edges
                                candidateEdges.Add(new int[2] { i, j });

                    // Show candidate edges on the table
                    for (int i = 0; i < candidateEdges.Count; i++)
                    {
                        char v1 = Convert.ToChar(candidateEdges[i][0] + 'A');
                        char v2 = Convert.ToChar(candidateEdges[i][1] + 'A');
                        for (int col = 1; col < dataGridViewGraph.ColumnCount; col++)
                            if (dataGridViewGraph.Columns[col].HeaderText[0] == v1)
                                for (int row = 0; row < dataGridViewGraph.RowCount; row++)
                                    if (dataGridViewGraph[0, row].Value.ToString() == v2.ToString())
                                    {
                                        dataGridViewGraph[col, row].Style.ForeColor = Color.Red;
                                        dataGridViewGraph[col, row].Style.SelectionForeColor = Color.Red;
                                    }
                    }

                    // More than two candidate edges - User operation required
                    if (candidateEdges.Count >= 2)
                    {
                        labelInformation.Text = "Edges ";
                        foreach (int[] edge in candidateEdges)
                            labelInformation.Text += Convert.ToChar(edge[0] + 'A').ToString() + Convert.ToChar(edge[1] + 'A').ToString() + ", ";
                        labelInformation.Text = labelInformation.Text.TrimEnd(", ".ToCharArray());
                        labelInformation.Text += " have the same weight (" + min.ToString() + "). Please pick one of your choice:\n"
                            + "Please click on the weights in the tableau.";
                        currentStep = 2;
                        buttonNext.Enabled = false;
                    }

                    // Only one candidate edge avaliable - No user operation needed
                    else if (candidateEdges.Count == 1)
                    {
                        newEdge = new int[2] { candidateEdges[0][0], candidateEdges[0][1] };
                        labelInformation.Text = "Edge " + Convert.ToChar(candidateEdges[0][0] + 'A').ToString() + Convert.ToChar(candidateEdges[0][1] + 'A').ToString()
                            + " has the minimum weight from the uncircled entries in the marked column(s) (" + min.ToString() + "),"
                            + " therefore it has been chosen.";
                        currentStep = 3;
                    }

                    // No candidate edge found - Algorithm about to finish
                    else
                    {
                        labelInformation.Text = "";
                        currentStep = 3;
                    }
                }

                // Step 3 operation
                else if (currentStep == 3)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = Color.Red;
                    labelStep3.ForeColor = Color.Red;
                    label4.ForeColor = SystemColors.ControlText;
                    labelStep4.ForeColor = SystemColors.ControlText;
                    label5.ForeColor = SystemColors.ControlText;
                    labelStep5.ForeColor = SystemColors.ControlText;

                    // Check if Prim's algorithm has finished
                    if (candidateEdges.Count == 0)
                    {
                        labelInformation.Text = "There is no available entry to be chosen, and therefore Prim's algorithm has finished.\n"
                            + "We have found a Minimum Spanning Tree.";
                        labelTotalWeight.Text = labelTotalWeight.Text.TrimEnd(" + ".ToCharArray());
                        labelTotalWeight.Text += " = " + weightMST.ToString();
                        labelTotalWeight.Visible = true;
                        buttonNext.Text = "Close";
                    }
                    else
                    {
                        labelInformation.Text += "\nNow that we have found an entry, we should go to STEP 4.";
                        currentStep = 4;
                    }
                }

                // Step 4 operation
                else if (currentStep == 4)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = SystemColors.ControlText;
                    labelStep3.ForeColor = SystemColors.ControlText;
                    label4.ForeColor = Color.Red;
                    labelStep4.ForeColor = Color.Red;
                    label5.ForeColor = SystemColors.ControlText;
                    labelStep5.ForeColor = SystemColors.ControlText;

                    // Update Prim's algorithm and show demonstration
                    labelInformation.Text = "";

                    weightMST += mapMatrix.GetEdge(newEdge[0], newEdge[1]);
                    labelTotalWeight.Text += mapMatrix.GetEdge(newEdge[0], newEdge[1]).ToString() + " + ";
                    visitedVertices.Add(newEdge[1]);
                    remainingVertices.Remove(newEdge[1]);
                    EdgeFocusOn(newEdge[0], newEdge[1]);
                    exampleGraph.LabelFocusOn(newEdge[0], newEdge[1]);

                    char v1 = Convert.ToChar(newEdge[0] + 'A');
                    char v2 = Convert.ToChar(newEdge[1] + 'A');
                    for (int col = 1; col < dataGridViewGraph.ColumnCount; col++)
                        for (int row = 0; row < dataGridViewGraph.RowCount; row++)
                        {
                            if (dataGridViewGraph.Columns[col].HeaderText[0] == v1 && dataGridViewGraph[0, row].Value.ToString() == v2.ToString())
                            {
                                dataGridViewGraph.Columns[row + 1].HeaderCell.Style.ForeColor = Color.Red;
                                dataGridViewGraph.Columns[row + 1].HeaderCell.Style.SelectionForeColor = Color.Red;
                                dataGridViewGraph.Columns[row + 1].HeaderCell.Value = dataGridViewGraph.Columns[row + 1].HeaderCell.Value.ToString() + " " + visitedVertices.Count.ToString();
                                dataGridViewGraph[col, row].Style.Font = boldFont;
                                dataGridViewGraph[col, row].Style.ForeColor = Color.Red;
                                dataGridViewGraph[col, row].Style.SelectionForeColor = Color.Red;
                            }
                            else if (dataGridViewGraph[col, row].Style.Font != boldFont)
                            {
                                dataGridViewGraph[col, row].Style.ForeColor = SystemColors.ControlText;
                                dataGridViewGraph[col, row].Style.SelectionForeColor = SystemColors.ControlText;
                                if (visitedVertices.Contains(Convert.ToInt32(Convert.ToChar(dataGridViewGraph[0, row].Value) - 'A')))
                                    dataGridViewGraph[col, row].Style.Font = strikeoutFont;
                            }
                        }

                    currentStep = 5;
                }

                // Step 5 operation
                else // if (currentStep == 5)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = SystemColors.ControlText;
                    labelStep3.ForeColor = SystemColors.ControlText;
                    label4.ForeColor = SystemColors.ControlText;
                    labelStep4.ForeColor = SystemColors.ControlText;
                    label5.ForeColor = Color.Red;
                    labelStep5.ForeColor = Color.Red;

                    // Refresh and go to Step 2
                    labelInformation.Text = "";
                    currentStep = 2;
                }
            }
        }

        private void DataGridViewGraph_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Resolve user operation on table
            if (currentStep == 1 && !buttonNext.Enabled && (e.ColumnIndex == 0 || e.RowIndex == -1)) // Step 1 operation on table - Choosing starting vertex
            {
                string vSelectedString;
                if (e.RowIndex == -1)
                    vSelectedString = dataGridViewGraph.Columns[e.ColumnIndex].HeaderText;
                else
                    vSelectedString = dataGridViewGraph[e.ColumnIndex, e.RowIndex].Value.ToString();
                int vSelectedInt = Convert.ToChar(vSelectedString) - 'A';
                for (int i = 0; i < dataGridViewGraph.RowCount; i++)
                {
                    if (dataGridViewGraph[0, i].Value.ToString() == vSelectedString)
                    {
                        dataGridViewGraph.Columns[i + 1].HeaderCell.Style.ForeColor = Color.Red;
                        dataGridViewGraph.Columns[i + 1].HeaderCell.Style.SelectionForeColor = Color.Red;
                        dataGridViewGraph.Columns[i + 1].HeaderCell.Value = vSelectedString + " 1";
                        for (int col = 0; col < dataGridViewGraph.ColumnCount; col++)
                            dataGridViewGraph[col, i].Style.Font = strikeoutFont;
                        labelInformation.Text = "You have chosen vertex " + vSelectedString + ".";
                        visitedVertices.Add(vSelectedInt);
                        remainingVertices.Remove(vSelectedInt);
                        panelGraph.Refresh();
                        currentStep = 2;
                        buttonNext.Enabled = true;
                    }
                    else
                    {
                        dataGridViewGraph.Columns[i + 1].HeaderCell.Style.ForeColor = SystemColors.ControlText;
                        dataGridViewGraph.Columns[i + 1].HeaderCell.Style.SelectionForeColor = SystemColors.ControlText;
                    }
                }
            }
            else if(currentStep == 2 && !buttonNext.Enabled && (e.ColumnIndex != 0 || e.RowIndex != -1)
                && dataGridViewGraph[e.ColumnIndex, e.RowIndex].Style.ForeColor == Color.Red) // Step 2 operation on table - Choosing one of the candidate edges
            {
                labelInformation.Text = "You have chosen edge " + dataGridViewGraph[0, e.RowIndex].Value.ToString() + dataGridViewGraph.Columns[e.ColumnIndex].HeaderText[0].ToString() + ".";
                newEdge = new int[2]
                {
                    Convert.ToInt32(dataGridViewGraph.Columns[e.ColumnIndex].HeaderText[0] - 'A'),
                    Convert.ToInt32(Convert.ToChar(dataGridViewGraph[0, e.RowIndex].Value) - 'A')
                };
                for (int col = 1; col < dataGridViewGraph.ColumnCount; col++)
                    for (int row = 0; row < dataGridViewGraph.RowCount; row++)
                        if ((col != e.ColumnIndex || row != e.RowIndex) && dataGridViewGraph[col, row].Style.Font != boldFont && dataGridViewGraph[col, row].Style.ForeColor == Color.Red)
                        {
                            dataGridViewGraph[col, row].Style.ForeColor = SystemColors.ControlText;
                            dataGridViewGraph[col, row].Style.SelectionForeColor = SystemColors.ControlText;
                        }
                currentStep = 3;
                buttonNext.Enabled = true;
            }
        }
        #endregion
    }
}
