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
    public partial class FormKruskal : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Represents the current step of the algorithm demonstration.
        /// </summary>
        int currentStep = 1;

        /// <summary>
        /// Represents the smallest feasible weight in current iteration.
        /// </summary>
        double currentWeight = 0;

        /// <summary>
        /// Represents the index of the edge with the smallest feasible weight in current iteration.
        /// </summary>
        int currentEdgeIndex = -1;

        /// <summary>
        /// Represents the number of edge
        /// </summary>
        int treeEdgeCount = 0;

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
        /// A list of labels showing the names of the edges of the graph.
        /// </summary>
        List<Label> labelEdges = new List<Label>();

        /// <summary>
        /// A list of labels showing the weights of the edges of the graph.
        /// </summary>
        List<Label> labelWeights = new List<Label>();

        /// <summary>
        /// A list of labels indicating if the edge has been traversed.
        /// </summary>
        List<Label> labelEdgeUsed = new List<Label>();

        /// <summary>
        /// A list of all edges in the graph.
        /// </summary>
        List<Edge> edgeList = new List<Edge>();

        /// <summary>
        /// A Union-Find set of all the vertices.
        /// </summary>
        List<UnionFind> unionFindVertices = new List<UnionFind>();

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

        #region Constructor
        public FormKruskal(int accountID, string username, string accountName, string accountType, int example)
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
            InitialiseUnionFind();
        }
        #endregion

        #region Events and Functions for GUI
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (Vertex v1 in vertices)
                    foreach (Vertex v2 in v1.GetEdges())
                        if (v2.GetNumberIndex() > v1.GetNumberIndex())
                        {
                            if (edgeFocused[v1.GetNumberIndex(), v2.GetNumberIndex()])
                                g.DrawLine(new Pen(Color.Red, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                            else
                                g.DrawLine(new Pen(Color.Black, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
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
        /// <summary>
        /// Represents a directed edge.
        /// </summary>
        private struct Edge
        {
            /// <summary>
            /// The starting vertex.
            /// </summary>
            public int vStart;
            /// <summary>
            /// The finishing vertex.
            /// </summary>
            public int vFinish;
            /// <summary>
            /// The weight of the edge.
            /// </summary>
            public double weight;
        }

        // Recursive algorithm (Group A) is implemented here
        // O(nlogn) sort (Group A) is implemented here.
        /// <summary>
        /// Sorts the edges in ascending order of weights.
        /// </summary>
        private void QuickSort(List<Edge> A, int left, int right)
        {
            int i, j;
            double x;
            Edge temp;
            i = left; j = right; x = A[(left + right) / 2].weight;
            do
            {
                while (i <= right && A[i].weight < x) i++;
                while (j >= left && A[j].weight > x) j--;
                if (i <= j)
                {
                    temp = A[i]; A[i] = A[j]; A[j] = temp;
                    i++; j--;
                }
            } while (i <= j);
            if (left < j) QuickSort(A, left, j);
            if (i < right) QuickSort(A, i, right);
        }

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Copies and initialises all the vertices into the Union-Find structural list.
        /// </summary>
        private void InitialiseUnionFind()
        {
            for (int vertex = 0; vertex < mapMatrix.GetSize(); vertex++)
                if (mapMatrix.IsVertexExisting(vertex))
                {
                    unionFindVertices.Add(new UnionFind());
                    unionFindVertices[unionFindVertices.Count() - 1].SetVertex(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetLeader(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetPrev(-1);
                    unionFindVertices[unionFindVertices.Count() - 1].SetHead(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetTail(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetCount(1);
                }
        }

        /// <summary>
        /// Finds a vertex in the Union-Find set.
        /// </summary>
        /// <param name="vertex">The desired vertex.</param>
        /// <returns>
        /// Returns the desired vertex, if found in the Union-Find set.
        /// If such vertex is not found, returns a default Union-Find structural vertex.
        /// </returns>
        private UnionFind Find(int vertex)
        {
            foreach (UnionFind v in unionFindVertices)
                if (v.GetVertex() == vertex)
                    return v;
            return new UnionFind();
        }

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Absorbs the elements of set X into set Y in the Union-Find structure.
        /// </summary>
        private void Update(int setX, int setY)
        {
            int index = unionFindVertices[setX].GetTail();
            do
            {
                unionFindVertices[index].SetLeader(setY);
                index = unionFindVertices[index].GetPrev();
            } while (index != -1);
            unionFindVertices[unionFindVertices[setY].GetHead()].SetPrev(unionFindVertices[setX].GetTail());
            unionFindVertices[setY].SetHead(unionFindVertices[setX].GetHead());
            unionFindVertices[setY].SetCount(unionFindVertices[setY].GetCount() + unionFindVertices[setX].GetCount());
        }

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Unites two sets in the union-find structure.
        /// </summary>
        private void Union(int setX, int setY)
        {
            if (unionFindVertices[setX].GetCount() < unionFindVertices[setY].GetCount())
                Update(setX, setY);
            else Update(setY, setX);
        }

        // Graph/Tree Traversal (Group A) is implemented here.
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (buttonNext.Text == "Close")
            {
                this.Close();
            }
            else
            {
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

                    // Show the headers of the list of all edges
                    labelList.Visible = true;
                    labelEdgeLeft.Visible = true;
                    labelWeightLeft.Visible = true;
                    labelEdgeRight.Visible = true;
                    labelWeightRight.Visible = true;

                    // Initialise and sort the list of all edges
                    int edgeCount = 0;
                    for (int v1 = 0; v1 < mapMatrix.GetSize() - 1; v1++)
                        for (int v2 = v1 + 1; v2 < mapMatrix.GetSize(); v2++)
                            if (mapMatrix.ContainsEdge(v1, v2))
                            {
                                edgeCount++;
                                edgeList.Add(new Edge
                                {
                                    vStart = v1,
                                    vFinish = v2,
                                    weight = mapMatrix.GetEdge(v1, v2)
                                });
                            }
                    edgeCount /= 2;
                    QuickSort(edgeList, 0, edgeList.Count - 1);

                    // Show the list of all edges
                    Point[] originalLocations = new Point[2];
                    originalLocations[0] = new Point(24, 332);
                    originalLocations[1] = new Point(originalLocations[0].X + 228, originalLocations[0].Y);
                    for (int i = 0; i < edgeList.Count; i++)
                    {
                        Point location = new Point(originalLocations[i / edgeCount].X, originalLocations[i / edgeCount].Y + 44 * (i % edgeCount));
                        labelEdges.Add(new Label()
                        {
                            AutoSize = true,
                            Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))),
                            Location = location,
                            MinimumSize = new Size(100, 44),
                            Name = "labelEdge" + i.ToString(),
                            Size = new Size(100, 44),
                            Text = Convert.ToChar(edgeList[i].vStart + 'A').ToString() + Convert.ToChar(edgeList[i].vFinish + 'A').ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        });
                        labelEdges[i].Click += new EventHandler(LabelEdge_Click);
                        labelWeights.Add(new Label()
                        {
                            AutoSize = true,
                            Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))),
                            Location = new Point(location.X + 100, location.Y),
                            MinimumSize = new Size(100, 44),
                            Name = "labelWeight" + i.ToString(),
                            Size = new Size(100, 44),
                            Text = edgeList[i].weight.ToString(),
                            TextAlign = ContentAlignment.TopCenter
                        });
                        labelWeights[i].Click += new EventHandler(LabelEdge_Click);
                        labelEdgeUsed.Add(new Label()
                        {
                            AutoSize = true,
                            Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))),
                            Location = new Point(location.X + 200, location.Y),
                            MinimumSize = new Size(0, 22),
                            Name = "labelEdgeUsed" + i.ToString(),
                            Size = new Size(22, 22),
                            Text = "×",
                            TextAlign = ContentAlignment.TopCenter,
                            Visible = false
                        });
                        this.Controls.Add(labelEdges[i]);
                        this.Controls.Add(labelWeights[i]);
                        this.Controls.Add(labelEdgeUsed[i]);
                    }
                    currentEdgeIndex = 0;
                    currentWeight = edgeList[0].weight;
                    currentStep = 2;
                }

                // Step 2 operations
                else if (currentStep == 2)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = Color.Red;
                    labelStep2.ForeColor = Color.Red;
                    label3.ForeColor = SystemColors.ControlText;
                    labelStep3.ForeColor = SystemColors.ControlText;
                    foreach (Label label in labelEdges)
                        label.ForeColor = SystemColors.ControlText;
                    foreach (Label label in labelWeights)
                        label.ForeColor = SystemColors.ControlText;
                    labelEdges[currentEdgeIndex].ForeColor = Color.Red;
                    labelWeights[currentEdgeIndex].ForeColor = Color.Red;

                    // Initialise text explanation label
                    labelInformation.Text = "";
                    labelInformation.Visible = true;

                    // Perform Kruskal's algorithm
                    if (Find(edgeList[currentEdgeIndex].vStart).GetLeader() == Find(edgeList[currentEdgeIndex].vFinish).GetLeader()) // Reject edges forming a cycle
                    {
                        labelInformation.Text = "Adding edge " + labelEdges[currentEdgeIndex].Text + " will form a cycle, therefore edge " + labelEdges[currentEdgeIndex].Text + " should not be chosen.";
                        labelEdgeUsed[currentEdgeIndex].Text = "×";
                        labelEdgeUsed[currentEdgeIndex].ForeColor = Color.Red;
                        labelEdgeUsed[currentEdgeIndex].Visible = true;
                        labelEdges[currentEdgeIndex].Font = new Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        labelWeights[currentEdgeIndex].Font = new Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        do
                        {
                            currentEdgeIndex++;
                        } while (labelEdgeUsed[currentEdgeIndex].Visible);
                        currentWeight = edgeList[currentEdgeIndex].weight;
                        currentStep = 2;
                    }
                    else
                    {
                        int i = currentEdgeIndex + 1;
                        List<Edge> tempEdgeList = new List<Edge>
                    {
                        edgeList[currentEdgeIndex]
                    };
                        while (edgeList[i].weight == currentWeight && !labelEdgeUsed[i].Visible)
                        {
                            if (Find(edgeList[i].vStart).GetLeader() != Find(edgeList[i].vFinish).GetLeader()) // Highlight feasible candidate edges
                            {
                                labelEdges[i].ForeColor = Color.Red;
                                labelWeights[i].ForeColor = Color.Red;
                                tempEdgeList.Add(edgeList[i]);
                            }
                            else // Reject edges forming a cycle
                            {
                                labelInformation.Text += "Adding edge " + labelEdges[i].Text + " will form a cycle, therefore edge " + labelEdges[i].Text + " should not be chosen.\n";
                                labelEdgeUsed[i].Text = "×";
                                labelEdgeUsed[i].ForeColor = Color.Red;
                                labelEdgeUsed[i].Visible = true;
                                labelEdges[i].Font = new Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                labelWeights[i].Font = new Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            }
                            i++;
                        }
                        if (tempEdgeList.Count >= 2) // More than two candidate edges - user operation required
                        {
                            labelInformation.Text += "Edges ";
                            foreach (Edge edge in tempEdgeList)
                                labelInformation.Text += Convert.ToChar(edge.vStart + 'A').ToString() + Convert.ToChar(edge.vFinish + 'A').ToString() + ", ";
                            labelInformation.Text = labelInformation.Text.TrimEnd(", ".ToCharArray());
                            labelInformation.Text += " have the same weight. Please pick one of your choice.\n"
                                + "Please click on the edge in the list (NOT on the graph).";
                            currentStep = 2;
                            buttonNext.Enabled = false;
                        }
                        else // One candidate edge only
                        {
                            labelInformation.Text += "Edge " + labelEdges[currentEdgeIndex].Text + " has been added to the Minimum Spanning Tree.";
                            labelEdgeUsed[currentEdgeIndex].Text = "√";
                            labelEdgeUsed[currentEdgeIndex].ForeColor = Color.Green;
                            labelEdgeUsed[currentEdgeIndex].Visible = true;
                            EdgeFocusOn(edgeList[currentEdgeIndex].vStart, edgeList[currentEdgeIndex].vFinish);
                            exampleGraph.LabelFocusOn(edgeList[currentEdgeIndex].vStart, edgeList[currentEdgeIndex].vFinish);
                            treeEdgeCount++;
                            weightMST += currentWeight;
                            Union(Find(edgeList[currentEdgeIndex].vStart).GetLeader(), Find(edgeList[currentEdgeIndex].vFinish).GetLeader());
                            currentEdgeIndex = i;
                            while (labelEdgeUsed[currentEdgeIndex].Visible)
                                currentEdgeIndex++;
                            currentWeight = edgeList[currentEdgeIndex].weight;
                            currentStep = 3;
                        }
                    }
                }

                // Step 3 operation
                else // if (currentStep == 3)
                {
                    // Highlight current step
                    label1.ForeColor = SystemColors.ControlText;
                    labelStep1.ForeColor = SystemColors.ControlText;
                    label2.ForeColor = SystemColors.ControlText;
                    labelStep2.ForeColor = SystemColors.ControlText;
                    label3.ForeColor = Color.Red;
                    labelStep3.ForeColor = Color.Red;
                    foreach (Label label in labelEdges)
                        label.ForeColor = SystemColors.ControlText;
                    foreach (Label label in labelWeights)
                        label.ForeColor = SystemColors.ControlText;

                    // Initialise text explanation label
                    labelInformation.Text = "";
                    labelInformation.Visible = true;

                    // Check if the algorithm is finished
                    if (treeEdgeCount < mapMatrix.Count() - 1)
                    {
                        labelInformation.Text = "We have not yet formed a Minimum Spanning Tree, so go back to STEP 2.";
                        currentStep = 2;
                    }
                    else
                    {
                        labelInformation.Text = "Now we have picked " + (mapMatrix.Count() - 1).ToString() + " edges and has formed a Minimum Spanning Tree.\nTherefore Kruskal's algorithm has finished.";
                        for (int i = 0; i < edgeList.Count; i++)
                            if (labelEdgeUsed[i].Text == "√")
                                labelTotalWeight.Text += labelWeights[i].Text + " + ";
                        labelTotalWeight.Text = labelTotalWeight.Text.TrimEnd(" + ".ToCharArray());
                        labelTotalWeight.Text += " = " + weightMST.ToString();
                        labelTotalWeight.Visible = true;
                        buttonNext.Text = "Close";
                    }
                }
            }
        }

        private void LabelEdge_Click(object sender, EventArgs e)
        {
            // Resolve user operation on graph
            int edgeIndex = Convert.ToInt32((sender as Label).Name.Trim("label".ToCharArray()).Trim("Edge".ToCharArray()).Trim("Weight".ToCharArray()));
            if (edgeList[edgeIndex].weight == currentWeight && !buttonNext.Enabled && !labelTotalWeight.Visible)
            {
                labelInformation.Text = "Edge " + labelEdges[edgeIndex].Text + " has been added to the Minimum Spanning Tree.";
                labelEdgeUsed[edgeIndex].Text = "√";
                labelEdgeUsed[edgeIndex].ForeColor = Color.Green;
                labelEdgeUsed[edgeIndex].Visible = true;
                foreach (Label label in labelEdges)
                    label.ForeColor = SystemColors.ControlText;
                foreach (Label label in labelWeights)
                    label.ForeColor = SystemColors.ControlText;
                labelEdges[edgeIndex].ForeColor = Color.Red;
                labelWeights[edgeIndex].ForeColor = Color.Red;
                EdgeFocusOn(edgeList[edgeIndex].vStart, edgeList[edgeIndex].vFinish);
                exampleGraph.LabelFocusOn(edgeList[edgeIndex].vStart, edgeList[edgeIndex].vFinish);
                treeEdgeCount++;
                weightMST += currentWeight;
                Union(Find(edgeList[edgeIndex].vStart).GetLeader(), Find(edgeList[edgeIndex].vFinish).GetLeader());
                int i = 0;
                while (labelEdgeUsed[i].Visible)
                    i++;
                currentEdgeIndex = i;
                currentStep = 3;
                buttonNext.Enabled = true;
            }
        }
        #endregion
    }
}
