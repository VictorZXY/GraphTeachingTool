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
    public partial class FormPrimOnGraph : Form
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
        /// The example number.
        /// </summary>
        readonly int example;

        /// <summary>
        /// The example graph.
        /// </summary>
        MinimumSpanningTreeExample exampleGraph;

        /// <summary>
        /// A list of indices of vertices that have been visited by Prim's algorithm.
        /// </summary>
        List<int> visitedVertices = new List<int>();

        /// <summary>
        /// A list of indices of vertices that have not yet been visited by Prim's algorithm.
        /// </summary>
        List<int> remainingVertices = new List<int>();

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
        #endregion

        #region Constructors
        public FormPrimOnGraph(int accountID, string username, string accountName, string accountType, int example)
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
            foreach (Vertex vertex in exampleGraph.vertices)
                vertex.MouseDown += new MouseEventHandler(Vertex_MouseDown_ChooseStartingVertex);
            foreach (Label label in exampleGraph.labelWeights)
                label.Click += new EventHandler(LabelWeights_Click);
            vertices = exampleGraph.GetVertices();
            mapMatrix = exampleGraph.GetMatrix();
        }
        #endregion

        #region Events and Functions for GUI
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Font regularFont = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                Font boldFont = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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

                    // Initialise Prim's algorithm
                    for (int i = 0; i < mapMatrix.GetSize(); i++)
                        if (mapMatrix.IsVertexExisting(i))
                            remainingVertices.Add(i);
                    labelInformation.Text = "Please pick a vertex of your choice:\nPlease click on the vertex of the graph.";
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

                    // Find minimum value of edge weight and candidate edges
                    double min = Double.MaxValue;
                    List<int[]> candidateEdges = new List<int[]>();

                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (mapMatrix.ContainsEdge(i, j) && mapMatrix.GetEdge(i, j) < min) // Find minimum value of edge weight
                                min = mapMatrix.GetEdge(i, j);

                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (mapMatrix.ContainsEdge(i, j) && mapMatrix.GetEdge(i, j) == min) // Find candidate edges
                                candidateEdges.Add(new int[2] { i, j });

                    // More than two candidate edges - User operation required
                    if (candidateEdges.Count >= 2)
                    {
                        // Show explanation
                        labelInformation.Text = "Edges ";
                        foreach (int[] edge in candidateEdges)
                            labelInformation.Text += Convert.ToChar(edge[0] + 'A').ToString() + Convert.ToChar(edge[1] + 'A').ToString() + ", ";
                        labelInformation.Text = labelInformation.Text.TrimEnd(", ".ToCharArray());
                        labelInformation.Text += " have the same weight (" + min.ToString() + "). Please pick one of your choice:\n"
                            + "Please click on the vertex or the weight.";

                        // Highlight candidate edges
                        for (int i = 0; i < candidateEdges.Count; i++)
                        {
                            int v1 = Math.Min(candidateEdges[i][0], candidateEdges[i][1]);
                            int v2 = Math.Max(candidateEdges[i][0], candidateEdges[i][1]);
                            string labelName = "label" + Convert.ToChar(v1 + 'A').ToString() + Convert.ToChar(v2 + 'A').ToString();
                            foreach (Label label in exampleGraph.labelWeights)
                                if (label.Name == labelName)
                                {
                                    label.ForeColor = Color.Red;
                                    break;
                                }
                            foreach (Vertex vertex in vertices)
                                if (vertex.GetNumberIndex() == candidateEdges[i][1])
                                {
                                    vertex.labelName.ForeColor = Color.Red;
                                    break;
                                }
                        }

                        currentStep = 2;
                        buttonNext.Enabled = false;
                    }

                    // Only one candidate edge avaliable - No user operation needed
                    else
                    {
                        // Show explanation
                        int[] newEdge = new int[2] { candidateEdges[0][0], candidateEdges[0][1] };
                        labelInformation.Text = "Edge " + Convert.ToChar(candidateEdges[0][0] + 'A').ToString() + Convert.ToChar(candidateEdges[0][1] + 'A').ToString()
                            + " has the minimum weight joining a vertex already included to a vertex not already included (" + min.ToString() + "),"
                            + " therefore it has been added to the Minimum Spanning Tree.";

                        // Update Prim's algorithm
                        foreach (Vertex vertex in vertices)
                            if (vertex.GetNumberIndex() == newEdge[1])
                            {
                                weightMST += min;
                                labelTotalWeight.Text += min.ToString() + " + ";
                                visitedVertices.Add(newEdge[1]);
                                remainingVertices.Remove(newEdge[1]);
                                EdgeFocusOn(newEdge[0], newEdge[1]);
                                exampleGraph.LabelFocusOn(newEdge[0], newEdge[1]);
                                currentStep = 3;
                                break;
                            }
                    }
                }

                // Step 3 operation
                else // if (currentStep == 3)
                {
                    // Highlight current steps
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = Color.Red;
                    labelStep3.ForeColor = Color.Red;

                    // Check if Prim's algorithm has finished
                    if (remainingVertices.Any())
                    {
                        labelInformation.Text = "We have not yet formed a Minimum Spanning Tree, so go back to STEP 2.";
                        currentStep = 2;
                    }
                    else
                    {
                        labelInformation.Text = "Now we have picked " + (mapMatrix.Count() - 1).ToString() + " edges and has formed a Minimum Spanning Tree.\nTherefore Prim's algorithm has finished.";
                        labelTotalWeight.Text = labelTotalWeight.Text.TrimEnd(" + ".ToCharArray());
                        labelTotalWeight.Text += " = " + weightMST.ToString();
                        labelTotalWeight.Visible = true;
                        buttonNext.Text = "Close";
                    }
                }
            }
        }

        private bool CheckVertexCandidate(Vertex vertex)
        {
            if (vertex.labelName.ForeColor == Color.Red && remainingVertices.Contains(vertex.GetNumberIndex()))
                return true;
            else return false;
        }

        private void Vertex_MouseDown_ChooseStartingVertex(object sender, MouseEventArgs e)
        {
            // Resolve user operation on graph
            if (currentStep == 1 && !buttonNext.Enabled) // Step 1 user operation on graph: choosing a starting vertex
            {
                labelInformation.Text = "You have chosen vertex " + (sender as Vertex).GetName().ToString() + ".";
                visitedVertices.Add((sender as Vertex).GetNumberIndex());
                remainingVertices.Remove((sender as Vertex).GetNumberIndex());
                panelGraph.Refresh();
                currentStep = 2;
                buttonNext.Enabled = true;
            }
            else if (currentStep == 2 && !buttonNext.Enabled && CheckVertexCandidate(sender as Vertex)) // Step 2 user operation on graph: choosing one of the candidate edges
                foreach (Vertex vertex in (sender as Vertex).GetEdges())
                {
                    int v1 = Math.Min(vertex.GetNumberIndex(), (sender as Vertex).GetNumberIndex());
                    int v2 = Math.Max(vertex.GetNumberIndex(), (sender as Vertex).GetNumberIndex());
                    if (exampleGraph.labelWeights[v1,v2].ForeColor == Color.Red && !edgeFocused[v1, v2])
                    {
                        string edgeName = Convert.ToChar(v1 + 'A').ToString() + Convert.ToChar(v2 + 'A').ToString();
                        labelInformation.Text = "Edge " + edgeName + " has been added to the Minimum Spanning Tree.";
                        weightMST += mapMatrix.GetEdge(v1, v2);
                        labelTotalWeight.Text += mapMatrix.GetEdge(v1, v2).ToString() + " + ";
                        visitedVertices.Add((sender as Vertex).GetNumberIndex());
                        remainingVertices.Remove((sender as Vertex).GetNumberIndex());
                        EdgeFocusOn(v1, v2);
                        exampleGraph.LabelFocusOn(v1, v2);
                        currentStep = 3;
                        buttonNext.Enabled = true;
                        break;
                    }
                }
        }

        private void LabelWeights_Click(object sender, EventArgs e)
        {
            // Resolve user operation on graph - Choosing one of the candidate edges
            string edgeName = (sender as Label).Name.Trim("label".ToCharArray());
            int v1 = edgeName[0] - 'A';
            int v2 = edgeName[1] - 'A';
            if ((sender as Label).ForeColor == Color.Red && !buttonNext.Enabled && !edgeFocused[v1, v2])
            {
                labelInformation.Text = "Edge " + edgeName + " has been added to the Minimum Spanning Tree.";
                weightMST += Convert.ToDouble((sender as Label).Text);
                labelTotalWeight.Text += (sender as Label).Text + " + ";
                if (visitedVertices.Contains(v1))
                {
                    visitedVertices.Add(v2);
                    remainingVertices.Remove(v2);
                }
                else
                {
                    visitedVertices.Add(v1);
                    remainingVertices.Remove(v1);
                }
                EdgeFocusOn(v1, v2);
                exampleGraph.LabelFocusOn(v1, v2);
                currentStep = 3;
                buttonNext.Enabled = true;
            }
        }
        #endregion
    }
}
