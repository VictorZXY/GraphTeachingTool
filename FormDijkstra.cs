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
    public partial class FormDijkstra : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Represents the current step of the algorithm demonstration.
        /// </summary>
        int currentStep = 1;

        /// <summary>
        /// Temporary variable for finding the minimum value.
        /// </summary>
        double min;

        /// <summary>
        /// Represents a vertex maintaining necessary properties for Dijkstra's algorithm.
        /// </summary>
        private struct DijkstraVertex
        {
            /// <summary>
            /// The current shortest distance between this vertex and the starting vertex.
            /// </summary>
            public double distance;
            /// <summary>
            /// The predecessor vertex of this vertex.
            /// </summary>
            public int prev;
        }

        /// <summary>
        /// A list of all the vertices maintaining necessary properties for Dijkstra's algorithm.
        /// </summary>
        private DijkstraVertex[] dijkstraMap = new DijkstraVertex[26];

        /// <summary>
        /// The number index of the vertex in the current iteration.
        /// </summary>
        int currentVertex;

        /// <summary>
        /// A list of vertices that have been labelled permanent.
        /// </summary>
        List<int> permanentVertices = new List<int>();

        /// <summary>
        /// A list of vertices that have not yet been labelled permanent.
        /// </summary>
        List<int> temporaryVertices = new List<int>();

        /// <summary>
        /// A list of candidate vertices that are not yet permanent which have the smallest best temporary label.
        /// </summary>
        List<int> candidateVertices = new List<int>();

        /// <summary>
        /// A list of vertices that has been relaxed in the current iteration.
        /// </summary>
        List<string> relaxedVertices = new List<string>();

        /// <summary>
        /// The example number.
        /// </summary>
        readonly int example;

        /// <summary>
        /// The example graph.
        /// </summary>
        ShortestPathExample exampleGraph;

        /// <summary>
        /// A list of all the vertex labels for Dijkstra's algorithm demonstration.
        /// </summary>
        List<DijkstraVertexLabel> vertices;

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
        public FormDijkstra(int accountID, string username, string accountName, string accountType, int example)
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
                exampleGraph = new ShortestPathExample1(this.panelGraph);
            else
                exampleGraph = new ShortestPathExample2(this.panelGraph);

            // Initialise the example graph.
            vertices = exampleGraph.GetVertices();
            mapMatrix = exampleGraph.GetMatrix();
            foreach (DijkstraVertexLabel vertex in vertices)
                vertex.labelVertexName.Click += new EventHandler(LabelVertexName_Click);
        }
        #endregion

        #region Events and Functions for GUI
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            Dictionary<bool, Color> colorFocusEdge = new Dictionary<bool, Color>
            {
                { true, Color.Red },
                { false, Color.Black }
            };
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (DijkstraVertexLabel v1 in vertices)
                    foreach (DijkstraVertexLabel v2 in vertices)
                    {
                        int vStart = v1.GetNumberIndex();
                        int vFinish = v2.GetNumberIndex();
                        if (mapMatrix.ContainsEdge(vStart, vFinish))
                        {
                            int shiftX = Convert.ToInt32(Math.Round(Math.Min(v2.Width / 2, Math.Abs(v2.Height / 2 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y + 1e-10)))));
                            int shiftY = Convert.ToInt32(Math.Round(Math.Min(v2.Height / 2, Math.Abs(v2.Width / 2 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / (v2.GetCentreLocation().X - v1.GetCentreLocation().X + 1e-10)))));
                            int directionX = v2.GetCentreLocation().X > v1.GetCentreLocation().X ? 1 : -1;
                            int directionY = v2.GetCentreLocation().Y > v1.GetCentreLocation().Y ? 1 : -1;
                            if (!mapMatrix.ContainsEdge(vFinish, vStart))
                            {
                                g.DrawLine(new Pen(colorFocusEdge[edgeFocused[vStart, vFinish]], 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                                Point point1 = new Point
                                (
                                    v2.GetCentreLocation().X - directionX * shiftX,
                                    v2.GetCentreLocation().Y - directionY * shiftY
                                );
                                Point pointBase = new Point
                                (
                                    Convert.ToInt32(Math.Round(point1.X - 40 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(point1.Y - 40 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
                                );
                                Point point2 = new Point
                                (
                                    Convert.ToInt32(Math.Round(pointBase.X + 7.5 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(pointBase.Y - 7.5 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                );
                                Point point3 = new Point
                                (
                                    Convert.ToInt32(Math.Round(pointBase.X - 7.5 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(pointBase.Y + 7.5 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                );
                                Point[] arrow = { point1, point2, point3 };
                                g.FillPolygon(new SolidBrush(colorFocusEdge[edgeFocused[vStart, vFinish]]), arrow);
                            }
                            else if (mapMatrix.GetEdge(vStart, vFinish) != mapMatrix.GetEdge(vFinish, vStart))
                            {
                                if (vFinish > vStart)
                                {
                                    Point point1 = new Point
                                    (
                                        v1.GetCentreLocation().X + directionX * shiftX,
                                        v1.GetCentreLocation().Y + directionY * shiftY
                                    );
                                    Point point2 = new Point
                                    (
                                        v2.GetCentreLocation().X - directionX * shiftX,
                                        v2.GetCentreLocation().Y - directionY * shiftY
                                    );
                                    Point midPoint = new Point
                                    (
                                        (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                        (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                                    );
                                    Point point3 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(midPoint.X + 42 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                        Convert.ToInt32(Math.Round(midPoint.Y - 42 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                    );
                                    Point point4 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(midPoint.X - 42 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                        Convert.ToInt32(Math.Round(midPoint.Y + 42 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                    );
                                    Point point5 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point2.X - 40 * (point2.X - point3.X) / Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X) + (point2.Y - point3.Y) * (point2.Y - point3.Y)))),
                                        Convert.ToInt32(Math.Round(point2.Y - 40 * (point2.Y - point3.Y) / Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X) + (point2.Y - point3.Y) * (point2.Y - point3.Y))))
                                    );
                                    Point point6Reflect = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point2.X - 40 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                        Convert.ToInt32(Math.Round(point2.Y - 40 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
                                    );
                                    Point point6 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point5.X + 11 * (point5.X - point6Reflect.X) / Math.Sqrt((point5.X - point6Reflect.X) * (point5.X - point6Reflect.X) + (point5.Y - point6Reflect.Y) * (point5.Y - point6Reflect.Y)))),
                                        Convert.ToInt32(Math.Round(point5.Y + 11 * (point5.Y - point6Reflect.Y) / Math.Sqrt((point5.X - point6Reflect.X) * (point5.X - point6Reflect.X) + (point5.Y - point6Reflect.Y) * (point5.Y - point6Reflect.Y))))
                                    );
                                    Point point7 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point1.X - 40 * (point1.X - point4.X) / Math.Sqrt((point1.X - point4.X) * (point1.X - point4.X) + (point1.Y - point4.Y) * (point1.Y - point4.Y)))),
                                        Convert.ToInt32(Math.Round(point1.Y - 40 * (point1.Y - point4.Y) / Math.Sqrt((point1.X - point4.X) * (point1.X - point4.X) + (point1.Y - point4.Y) * (point1.Y - point4.Y))))
                                    );
                                    Point point8Reflect = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point1.X + 40 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                        Convert.ToInt32(Math.Round(point1.Y + 40 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
                                    );
                                    Point point8 = new Point
                                    (
                                        Convert.ToInt32(Math.Round(point7.X + 11 * (point7.X - point8Reflect.X) / Math.Sqrt((point7.X - point8Reflect.X) * (point7.X - point8Reflect.X) + (point7.Y - point8Reflect.Y) * (point7.Y - point8Reflect.Y)))),
                                        Convert.ToInt32(Math.Round(point7.Y + 11 * (point7.Y - point8Reflect.Y) / Math.Sqrt((point7.X - point8Reflect.X) * (point7.X - point8Reflect.X) + (point7.Y - point8Reflect.Y) * (point7.Y - point8Reflect.Y))))
                                    );
                                    Point[] curve1 = { point1, point3, point2 };
                                    Point[] curve2 = { point2, point4, point1 };
                                    g.DrawCurve(new Pen(colorFocusEdge[edgeFocused[vStart, vFinish]], 5), curve1);
                                    g.DrawCurve(new Pen(colorFocusEdge[edgeFocused[vFinish, vStart]], 5), curve2);
                                    Point[] arrow1 = { point2, point5, point6 };
                                    Point[] arrow2 = { point1, point7, point8 };
                                    g.FillPolygon(new SolidBrush(colorFocusEdge[edgeFocused[vStart, vFinish]]), arrow1);
                                    g.FillPolygon(new SolidBrush(colorFocusEdge[edgeFocused[vFinish, vStart]]), arrow2);
                                }
                            }
                            else
                            {
                                if (vFinish > vStart)
                                    g.DrawLine(new Pen(colorFocusEdge[edgeFocused[vStart, vFinish]], 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                            }
                        }
                    }
            }
        }

        private void UndirectedEdgeFocusOn(int v1, int v2)
        {
            edgeFocused[v1, v2] = true;
            edgeFocused[v2, v1] = true;
            this.panelGraph.Refresh();
        }

        private void DirectedEdgeFocusOn(int v1, int v2)
        {
            edgeFocused[v1, v2] = true;
            this.panelGraph.Refresh();
        }

        private void UndirectedEdgeFocusOff(int v1, int v2)
        {
            edgeFocused[v1, v2] = false;
            edgeFocused[v2, v1] = false;
            this.panelGraph.Refresh();
        }

        private void DirectedEdgeFocusOff(int v1, int v2)
        {
            edgeFocused[v1, v2] = false;
            this.panelGraph.Refresh();
        }
        #endregion

        #region Events and Functions for Algorithms
        /// <summary>
        /// Initialises the shortest-path estimates and predecessors.
        /// </summary>
        /// <param name="vStart">The source vertex.</param>
        private void InitialiseSingleSource(int vStart)
        {
            for (int i = 0; i < 26; i++)
            {
                dijkstraMap[i].distance = Double.MaxValue;
                dijkstraMap[i].prev = -1;
            }
            dijkstraMap[vStart].distance = 0;
        }

        /// <summary>
        /// Improves the shortest path between two vertices, if possible.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        private void RelaxEdge(int vStart, int vFinish)
        {
            if (mapMatrix.ContainsEdge(vStart, vFinish) &&
                dijkstraMap[vFinish].distance > dijkstraMap[vStart].distance + mapMatrix.GetEdge(vStart, vFinish))
            {
                dijkstraMap[vFinish].distance = dijkstraMap[vStart].distance + mapMatrix.GetEdge(vStart, vFinish);
                dijkstraMap[vFinish].prev = vStart;
                foreach (DijkstraVertexLabel vertex in vertices)
                    if (vertex.GetNumberIndex() == vFinish)
                    {
                        relaxedVertices.Add(vertex.labelVertexName.Text);
                        vertex.UpdateWorkingValues(dijkstraMap[vFinish].distance);
                        break;
                    }
            }
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
                    label4.ForeColor = SystemColors.ControlText;
                    labelStep4.ForeColor = SystemColors.ControlText;

                    // Show instruction and indicate graph operation
                    labelInformation.Text = "Please pick a vertex to start Dijkstra's algorithm.\nPlease click on the vertex name in each box.";
                    currentStep = 1;
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

                    // Initialise example graph
                    for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                        for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                            if (mapMatrix.ContainsEdge(v1, v2))
                            {
                                DirectedEdgeFocusOff(v1, v2);
                                exampleGraph.LabelFocusOff(v1, v2);
                            }
                    foreach (DijkstraVertexLabel vertex in vertices)
                        vertex.FocusOff();

                    // Highlight current vertex
                    currentVertex = permanentVertices[permanentVertices.Count - 1];
                    foreach (DijkstraVertexLabel vertex in vertices)
                        if (vertex.GetNumberIndex() == currentVertex
                            || (temporaryVertices.Contains(vertex.GetNumberIndex()) && mapMatrix.ContainsEdge(currentVertex, vertex.GetNumberIndex())))
                            vertex.FocusOn();

                    // Relax other edges from current vertex
                    relaxedVertices.Clear();
                    foreach (int vertex in temporaryVertices)
                    {
                        RelaxEdge(currentVertex, vertex);
                        if (mapMatrix.ContainsEdge(currentVertex, vertex))
                        {
                            if (mapMatrix.ContainsEdge(vertex, currentVertex) && mapMatrix.GetEdge(currentVertex, vertex) == mapMatrix.GetEdge(vertex, currentVertex))
                            {
                                UndirectedEdgeFocusOn(currentVertex, vertex);
                                exampleGraph.LabelFocusOn(currentVertex, vertex);
                                exampleGraph.LabelFocusOn(vertex, currentVertex);
                            }
                            else
                            {
                                DirectedEdgeFocusOn(currentVertex, vertex);
                                exampleGraph.LabelFocusOn(currentVertex, vertex);
                            }
                        }
                    }

                    // Show explanation
                    if (relaxedVertices.Count == 0)
                        labelInformation.Text = "No vertex has been given a new temporary label.";
                    else if (relaxedVertices.Count == 1)
                        labelInformation.Text = "Vertex " + relaxedVertices[0] + " has been given a new temporary label.";
                    else
                    {
                        labelInformation.Text = "Vertices ";
                        foreach (string vertexName in relaxedVertices)
                            labelInformation.Text += vertexName + ", ";
                        labelInformation.Text = labelInformation.Text.TrimEnd(", ".ToCharArray());
                        labelInformation.Text += " have been given a new temporary label.";
                    }
                    currentStep = 3;
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

                    // Initialise example graph
                    for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                        for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                            if (mapMatrix.ContainsEdge(v1, v2))
                            {
                                DirectedEdgeFocusOff(v1, v2);
                                exampleGraph.LabelFocusOff(v1, v2);
                            }
                    foreach (DijkstraVertexLabel vertex in vertices)
                        vertex.FocusOff();

                    // Find candidate vertices
                    min = Double.MaxValue;
                    foreach (int i in temporaryVertices)
                        if (dijkstraMap[i].distance < min)
                            min = dijkstraMap[i].distance;
                    candidateVertices.Clear();
                    foreach (int i in temporaryVertices)
                        if (dijkstraMap[i].distance == min)
                            candidateVertices.Add(i);

                    // Show explanations and indicate graph operations if necessary
                    foreach (DijkstraVertexLabel vertex in vertices)
                        if (candidateVertices.Contains(vertex.GetNumberIndex()))
                            vertex.FocusOn();
                    if (candidateVertices.Count >= 2) // There is more than one candidate vertices so graph operations is required
                    {
                        labelInformation.Text = "Vertices ";
                        foreach (int vertex in candidateVertices)
                            labelInformation.Text += Convert.ToChar(vertex + 'A').ToString() + ", ";
                        labelInformation.Text = labelInformation.Text.TrimEnd(", ".ToCharArray());
                        labelInformation.Text += " now all have the same smallest best temporary label (" + min.ToString() + "). Please choose any one of them.\n"
                            + "Please click on the vertex name in each box.";
                        currentStep = 3;
                        buttonNext.Enabled = false;
                    }
                    else // There is only one candidate vertex so no graph operation is needed
                    {
                        temporaryVertices.Remove(candidateVertices[0]);
                        permanentVertices.Add(candidateVertices[0]);
                        labelInformation.Text = "Vertex " + Convert.ToChar(candidateVertices[0] + 'A').ToString()
                            + " now has the smallest best temporary label (" + min.ToString() + ").\n"
                            + "Therefore it has been made permanent with order " + permanentVertices.Count.ToString() + ".";
                        foreach (DijkstraVertexLabel vertex in vertices)
                            if (vertex.GetNumberIndex() == candidateVertices[0])
                            {
                                vertex.Finalise(min, permanentVertices.Count);
                                break;
                            }
                        currentStep = 4;
                    }
                }

                // Step 4 operation
                else // if (currentStep == 4)
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

                    // Initialise example graph
                    for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                        for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                            if (mapMatrix.ContainsEdge(v1, v2))
                            {
                                DirectedEdgeFocusOff(v1, v2);
                                exampleGraph.LabelFocusOff(v1, v2);
                            }
                    foreach (DijkstraVertexLabel vertex in vertices)
                        vertex.FocusOff();

                    // Check if the algorithm is finished and show explanations
                    if (temporaryVertices.Any())
                    {
                        foreach (DijkstraVertexLabel vertex in vertices)
                            if (vertex.GetNumberIndex() == permanentVertices[permanentVertices.Count - 1])
                            {
                                vertex.FocusOn();
                                break;
                            }
                        labelInformation.Text = "We still have at least one temporary vertex, so we should return to STEP 2.";
                        currentStep = 2;
                    }
                    else
                    {
                        labelInformation.Text = "Now that every vertex is permanent, "
                            + "we have found the shortest distance from the starting vertex ("
                            + Convert.ToChar(permanentVertices[0] + 'A').ToString()
                            + ") to all the other vertices.\n"
                            + "Please click on a vertex to see the shortest route.\n"
                            + "Please click on the vertex name in each box.";
                        currentStep = 4;
                        buttonNext.Text = "Close";
                    }
                }
            }
        }

        private void LabelVertexName_Click(object sender, EventArgs e)
        {
            // Step 1 operation on graph - Choose starting vertex
            if (currentStep == 1 && !buttonNext.Enabled)
            {
                int vStart = Convert.ToInt32(Convert.ToChar((sender as Label).Text) - 'A');
                InitialiseSingleSource(vStart);
                permanentVertices.Add(vStart);
                for (int v = 0; v < mapMatrix.GetSize(); v++)
                    if (mapMatrix.IsVertexExisting(v) && v != vStart)
                        temporaryVertices.Add(v);
                labelInformation.Text = "You have chosen vertex " + (sender as Label).Text + ".\n"
                    + "It has been made permanent by being given permanent label 0 and order label 1.";
                foreach (DijkstraVertexLabel vertex in vertices)
                    if (vertex.labelVertexName.Equals(sender as Label))
                    {
                        vertex.Finalise(0, 1);
                        vertex.FocusOn();
                        break;
                    }
                currentStep = 2;
                buttonNext.Enabled = true;
            }

            // Step 3 operation on graph - Choose one of the candidate vertices
            else if (currentStep == 3 && !buttonNext.Enabled)
            {
                int newVertex = Convert.ToInt32(Convert.ToChar((sender as Label).Text) - 'A');
                if (candidateVertices.Contains(newVertex))
                {
                    temporaryVertices.Remove(newVertex);
                    permanentVertices.Add(newVertex);
                    labelInformation.Text = "You have chosen vertex " + (sender as Label).Text + ".\n"
                        + "Therefore it has been made permanent with order " + permanentVertices.Count.ToString() + ".";
                    foreach (DijkstraVertexLabel vertex in vertices)
                    {
                        if (vertex.GetNumberIndex() == newVertex)
                            vertex.Finalise(min, permanentVertices.Count);
                        else
                            vertex.FocusOff();
                    }
                    currentStep = 4;
                    buttonNext.Enabled = true;
                }
            }

            // Step 4 operation on graph - Choose one finishing vertex and show the shortest path
            // Graph/Tree Traversal (Group A) is implemented here.
            else if (currentStep == 4 && buttonNext.Text == "Close")
            {
                int vFinish = Convert.ToInt32(Convert.ToChar((sender as Label).Text) - 'A');
                if (vFinish != permanentVertices[0])
                {
                    labelInformation.Text = "You have chosen vertex " + (sender as Label).Text + ".\n"
                        + "The shortest route from vertex " + Convert.ToChar(permanentVertices[0] + 'A').ToString()
                        + " to " + (sender as Label).Text + " has been found using 'trace back' method.\n"
                        + "You can click on other vertices to see their shortest routes and distances.";
                    labelFinalResult.Text = "Shortest route: ";

                    List<int> shortestPath = new List<int>
                    {
                        vFinish
                    };
                    int i = vFinish;
                    while (dijkstraMap[i].prev != -1)
                    {
                        labelFinalResult.Text += Convert.ToChar(i + 'A').ToString() + "←";
                        shortestPath.Add(dijkstraMap[i].prev);
                        i = dijkstraMap[i].prev;
                    }
                    shortestPath.Reverse();
                    labelFinalResult.Text += Convert.ToChar(permanentVertices[0] + 'A').ToString() + " (";
                    foreach (int vertex in shortestPath)
                        labelFinalResult.Text += Convert.ToChar(vertex + 'A').ToString();
                    labelFinalResult.Text += ")\nShortest distance = ";
                    foreach (DijkstraVertexLabel vertex in vertices)
                        if (vertex.labelVertexName.Equals(sender as Label))
                        {
                            labelFinalResult.Text += vertex.GetFinalLabel().ToString();
                            break;
                        }
                    labelFinalResult.Visible = true;

                    foreach (DijkstraVertexLabel vertex in vertices)
                    {
                        if (shortestPath.Contains(vertex.GetNumberIndex()))
                            vertex.FocusOn();
                        else
                            vertex.FocusOff();
                    }
                    for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                        for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                            if (mapMatrix.ContainsEdge(v1, v2))
                            {
                                DirectedEdgeFocusOff(v1, v2);
                                exampleGraph.LabelFocusOff(v1, v2);
                            }
                    for (int vertexIndex = 1; vertexIndex < shortestPath.Count; vertexIndex++)
                    {
                        int v1 = shortestPath[vertexIndex - 1];
                        int v2 = shortestPath[vertexIndex];
                        if (mapMatrix.ContainsEdge(v2, v1) && mapMatrix.GetEdge(v1, v2) == mapMatrix.GetEdge(v2, v1))
                        {
                            UndirectedEdgeFocusOn(v1, v2);
                            exampleGraph.LabelFocusOn(v1, v2);
                            exampleGraph.LabelFocusOn(v2, v1);
                        }
                        else
                        {
                            DirectedEdgeFocusOn(v1, v2);
                            exampleGraph.LabelFocusOn(v1, v2);
                        }
                    }

                    currentStep = 4;
                }
            }
        }
        #endregion
    }
}
