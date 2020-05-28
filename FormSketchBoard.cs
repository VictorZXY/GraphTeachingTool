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
    public partial class FormSketchBoard : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// A counter that records the first unused name of the vertex in a sorted order.
        /// </summary>
        char defaultVertexNameCounter = 'A';

        /// <summary>
        /// The name of button that is currently being selected.
        /// </summary>
        string selectedTool;

        /// <summary>
        /// Array of bool status indicating whether each of the names has been used by a vertex.
        /// </summary>
        bool[] vertexNameUsed = new bool[26];

        /// <summary>
        /// bool status indicating whether the property (directed / undirected) of the edges to be drawn.
        /// This equals TRUE if a directed edge is to be drawn, and FALSE if an undirected edge is to be drawn.
        /// </summary>
        bool isDirected;

        /// <summary>
        /// Constant array of Button containing the three tool buttons: buttonVertex, buttonEdge, buttonTag.
        /// </summary>
        readonly Button[] tools = new Button[3];

        /// <summary>
        /// A Tag that records the starting vertex of an edge being drawn.
        /// Its value is kept NULL when no edge is being drawn.
        /// </summary>
        Vertex vStart;

        /// <summary>
        /// A Tag that records the finishing vertex of an edge being drawn.
        /// Its value is kept NULL when no edge is being drawn.
        /// </summary>
        Vertex vFinish;
        
        /// <summary>
        /// A Tag that records the vertex whose name is being edited.
        /// </summary>
        Vertex vTagChanged;

        // Lists (Group A) are implemented here.
        /// <summary>
        /// List of all vertices on the Sketch Board.
        /// </summary>
        List<Vertex> vertices = new List<Vertex>();

        Label[,] labelWeights = new Label[26, 26];

        /// <summary>
        /// The Windows Form to be opened when the name of a vertex is being edited.
        /// </summary>
        FormVertexTag formVertexTag;

        /// <summary>
        /// The adjacency matrix representing the real-time graph on the Sketch Board.
        /// </summary>
        AdjacencyMatrix mapMatrix = new AdjacencyMatrix();

        /// <summary>
        /// The adjacency list representing the real-time graph on the Sketch Board.
        /// </summary>
        AdjacencyList mapList = new AdjacencyList();

        /// <summary>
        /// The location of the top-left corner of the screenshot
        /// </summary>
        public Point topLeft;

        /// <summary>
        /// The location of the bottom-right corner of the screenshot
        /// </summary>
        public Point bottomRight;

        /// <summary>
        /// Indicator for a successful submission.
        /// </summary>
        public bool submitSuccessful;
        #endregion

        #region Constructor
        public FormSketchBoard(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;

            // Initialise array tools: assign Button values.
            tools[0] = this.buttonVertex;
            tools[1] = this.buttonEdge;
            tools[2] = this.buttonTag;

            // Initialise screen capture range.
            topLeft = new Point(this.panelSketchBoard.Width, this.panelSketchBoard.Height);
            bottomRight = new Point(0, 0);

            // Initialise edge weight labels.
            for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                {
                    this.labelWeights[v1, v2] = new Label
                    {
                        AutoSize = true,
                        Enabled = false,
                        Location = new System.Drawing.Point(0, 0),
                        Name = "label" + Convert.ToChar(v1 + 'A').ToString() + Convert.ToChar(v2 + 'A').ToString(),
                        Text = "",
                        Visible = false
                    };
                    this.panelSketchBoard.Controls.Add(this.labelWeights[v1, v2]);
                }
        }
        #endregion

        #region "Get" Functions
        /// <summary>
        /// Gets the adjacency matrix representation of the graph on the Sketch Board.
        /// </summary>
        public AdjacencyMatrix GetMatrix()
        {
            return mapMatrix;
        }

        /// <summary>
        /// Gets the adjacency list representation of the graph on the Sketch Board.
        /// </summary>
        public AdjacencyList GetList()
        {
            return mapList;
        }
        #endregion

        #region Operation Functions
        /// <summary>
        /// Sets the current graph editing tool.
        /// </summary>
        /// <param name="button">The tool button.</param>
        private void SetCurrentTool(Button button)
        {
            selectedTool = button.Name;
            if(tools.Contains(button))
                button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            foreach (Button b in tools)
            {
                if (b != button)
                    b.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        /// <summary>
        /// Creates a new vertex control on the panel.
        /// </summary>
        /// <param name="name">The name of the vertex.</param>
        /// <param name="x">The X location of the vertex.</param>
        /// <param name="y">The Y location of the vertex.</param>
        /// <returns></returns>
        private Vertex CreateVertex(string name, int x, int y)
        {
            Vertex v = new Vertex(name, new Point(x, y));
            v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseDown_TagState);
            v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseDown_Disselect);
            v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseDown_DrawEdge);
            v.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseDoubleClick);
            v.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseMove_ResetBoard);
            v.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vertex_KeyPress_Delete);
            this.panelSketchBoard.Controls.Add(v);
            mapMatrix.EnableVertex(v.GetNumberIndex());
            mapList.EnableVertex(v.GetNumberIndex());
            return v;
        }

        /// <summary>
        /// Refreshes the board.
        /// </summary>
        private void ResetBoard()
        {
            for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                {
                    labelWeights[v1, v2].Enabled = mapMatrix.ContainsEdge(v1, v2);
                    labelWeights[v1, v2].Visible = mapMatrix.ContainsEdge(v1, v2);
                }
            using (Graphics g = this.panelSketchBoard.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                foreach (Vertex v1 in vertices)
                    foreach (Vertex v2 in v1.GetEdges())
                    {
                        if (!v2.ContainsEdge(v1)) // One directed edge between two vertices - draw a straight line with an arrow
                        {
                            g.DrawLine(new Pen(Color.Black, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                            Point point1 = new Point
                            (
                                Convert.ToInt32(Math.Round(v2.GetCentreLocation().X - 13.5 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                Convert.ToInt32(Math.Round(v2.GetCentreLocation().Y - 13.5 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
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
                            g.FillPolygon(new SolidBrush(Color.Black), arrow);
                            Point midPoint = new Point
                            (
                                (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                            );
                            labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Location = new Point
                            (
                                midPoint.X - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Width,
                                midPoint.Y - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Height
                            );
                            labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Text = v1.GetEdge(v2).ToString();
                        }
                        else if (v2.GetEdge(v1) != v1.GetEdge(v2))
                        {
                            if (v2.GetNumberIndex() > v1.GetNumberIndex()) // Two directed edges between two vertices with different weights - draw two curved lines with arrows
                            {
                                Point point1 = new Point
                                (
                                    Convert.ToInt32(Math.Round(v1.GetCentreLocation().X + 13.5 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(v1.GetCentreLocation().Y + 13.5 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
                                );
                                Point point2 = new Point
                                (
                                    Convert.ToInt32(Math.Round(v2.GetCentreLocation().X - 13.5 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(v2.GetCentreLocation().Y - 13.5 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2)))
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
                                g.DrawCurve(new Pen(Color.Black, 5), curve1);
                                g.DrawCurve(new Pen(Color.Black, 5), curve2);
                                Point[] arrow1 = { point2, point5, point6 };
                                Point[] arrow2 = { point1, point7, point8 };
                                g.FillPolygon(new SolidBrush(Color.Black), arrow1);
                                g.FillPolygon(new SolidBrush(Color.Black), arrow2);
                                labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Location = new Point
                                (
                                    point3.X - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Width,
                                    point3.Y - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Height
                                );
                                labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Text = v1.GetEdge(v2).ToString();
                                labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Location = new Point
                                (
                                    point4.X - labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Width,
                                    point4.Y - labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Height
                                );
                                labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Text = v2.GetEdge(v1).ToString();
                            }
                        }
                        else
                        {
                            if (v2.GetNumberIndex() > v1.GetNumberIndex()) // Undirected edge between two vertices - draw an unarrowed straight line
                            {
                                g.DrawLine(new Pen(Color.Black, 5), v1.GetCentreLocation(), v2.GetCentreLocation());
                                Point midPoint = new Point
                                (
                                    (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                    (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                                );
                                labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Location = new Point
                                (
                                    midPoint.X - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Width,
                                    midPoint.Y - labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Height
                                );
                                labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].Text = v1.GetEdge(v2).ToString();
                                labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Enabled = false;
                                labelWeights[v2.GetNumberIndex(), v1.GetNumberIndex()].Visible = false;
                            }
                        }
                    }
            }
        }

        private void DisselectOthers(Vertex vSelected)
        {
            if (vSelected.IsSelected())
            {
                foreach (Vertex v in vertices)
                {
                    if (!v.Equals(vSelected))
                    {
                        v.SetSelected(false);
                        v.SetTagState(false);
                        v.Refresh();
                    }
                }
            }
            if (selectedTool == "buttonVertex")
                vSelected.SetDraggable(true);
        }

        private void DisselectAllVertices()
        {
            foreach (Vertex v in vertices)
            {
                v.SetSelected(false);
                v.SetTagState(false);
                v.Refresh();
            }
        }

        private void UpdateVertexNameCounter()
        {
            vertexNameUsed[defaultVertexNameCounter - 'A'] = true;
            do
            {
                defaultVertexNameCounter++;
                if (defaultVertexNameCounter > 'Z')
                    break;
            } while (vertexNameUsed[defaultVertexNameCounter - 'A']);
        }

        private void UpdateScreenCaptureRange(int X, int Y)
        {
            if (X < topLeft.X) topLeft.X = X;
            if (Y < topLeft.Y) topLeft.Y = Y;
            if (X > bottomRight.X) bottomRight.X = X;
            if (Y > bottomRight.Y) bottomRight.Y = Y;

            if (topLeft.X < 0) topLeft.X = 0;
            if (topLeft.Y < 0) topLeft.Y = 0;
            if (bottomRight.X > this.panelSketchBoard.Width) bottomRight.X = this.panelSketchBoard.Width;
            if (bottomRight.Y > this.panelSketchBoard.Height) bottomRight.Y = this.panelSketchBoard.Height;
        }
        #endregion

        #region Events for Vertex control (Overridden)
        /// <summary>
        /// Set if the tag window is to be shown on a vertex.
        /// </summary>
        private void Vertex_MouseDown_TagState(object sender, MouseEventArgs e)
        {
            if ((sender as Vertex).IsSelected() && selectedTool == "buttonTag")
            {
                (sender as Vertex).SetTagState(true);
            }
            else (sender as Vertex).SetTagState(false);
        }

        /// <summary>
        /// Disselect other vertices.
        /// </summary>
        private void Vertex_MouseDown_Disselect(object sender, MouseEventArgs e)
        {
            DisselectOthers(sender as Vertex);
        }

        /// <summary>
        /// Draw a new edge. 
        /// </summary>
        private void Vertex_MouseDown_DrawEdge(object sender, MouseEventArgs e)
        {
            if (selectedTool == "buttonEdge")
            {
                (sender as Vertex).SetDraggable(false);
                if (vStart == null)
                {
                    vStart = (sender as Vertex);
                }
                else
                {
                    vFinish = (sender as Vertex);
                    if (isDirected)
                    {
                        vStart.SetEdge(vFinish);
                        mapMatrix.SetDirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                        mapList.SetDirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                    }
                    else
                    {
                        vStart.SetEdge(vFinish);
                        vFinish.SetEdge(vStart);
                        mapMatrix.SetUndirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                        mapList.SetUndirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                    }
                    vStart.SetSelected(false);
                    vFinish.SetSelected(false);
                    vStart.Refresh();
                    vFinish.Refresh();
                    ResetBoard();
                    vStart = null;
                    vFinish = null;
                }
            }
        }

        /// <summary>
        /// Show the tag window of the vertex.
        /// </summary>
        private void Vertex_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedTool == "buttonTag") 
            {
                vTagChanged = sender as Vertex;
                vTagChanged.SetSelected(true);
                vertexNameUsed[vTagChanged.GetName() - 'A'] = false;
                formVertexTag = new FormVertexTag();
                formVertexTag.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVertexTag_FormClosed);
                formVertexTag.buttonSave.Click += new System.EventHandler(this.FormVertexTag_buttonSave_Click_ValidateVertexName);
                formVertexTag.buttonSave.Click += new System.EventHandler(this.FormVertexTag_buttonSave_Click_UpdateVertex);
                formVertexTag.buttonCancel.Click += new System.EventHandler(this.FormVertexTag_buttonCancel_Click);
                formVertexTag.Text += vTagChanged.GetName().ToString();
                formVertexTag.textBoxVertexName.Text = vTagChanged.GetName().ToString();
                formVertexTag.Load += new System.EventHandler(FormVertexTag_Load);
                formVertexTag.Show();
                this.Enabled = false;
            }
        }

        /// <summary>
        /// Refresh the panel.
        /// </summary>
        private void Vertex_MouseMove_ResetBoard(object sender, MouseEventArgs e)
        {
            ResetBoard();
        }

        /// <summary>
        /// Delete the vertex, along with all its adjacenct edges.
        /// </summary>
        private void Vertex_KeyPress_Delete(object sender, KeyPressEventArgs e)
        {
            int vertexNameIndex = (sender as Vertex).GetNumberIndex();
            vertexNameUsed[vertexNameIndex] = false;
            if (vertexNameIndex < defaultVertexNameCounter - 'A')
                defaultVertexNameCounter = Convert.ToChar(vertexNameIndex + 'A');
            vertices.Remove(sender as Vertex);
            foreach (Vertex v in vertices)
            {
                if (v.ContainsEdge(sender as Vertex))
                    v.RemoveEdge(sender as Vertex);
            }
            mapMatrix.RemoveVertex(vertexNameIndex);
            mapList.RemoveVertex(vertexNameIndex);
            ResetBoard();
            vStart = null;
            vFinish = null;
        }
        #endregion

        #region Events for panelSketchBoard
        /// <summary>
        /// Create a new vertex on a panel, or draw a new edge on a panel.
        /// </summary>
        private void PanelSketchBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedTool == "buttonVertex")
            {
                if (defaultVertexNameCounter <= 'Z')
                {
                    vertices.Add(CreateVertex(defaultVertexNameCounter.ToString(), e.X, e.Y));
                    UpdateVertexNameCounter();
                }
                else
                    MessageBox.Show("Maximum number of vertices has been reached!\n (You can create up to 26 vertices)");
            }
            else if (selectedTool == "buttonEdge")
            {
                if (vStart == null)
                {
                    if (defaultVertexNameCounter <= 'Z')
                    {
                        vertices.Add(CreateVertex(defaultVertexNameCounter.ToString(), e.X, e.Y));
                        UpdateVertexNameCounter();
                        vertices[vertices.Count - 1].SetSelected(true);
                        DisselectOthers(vertices[vertices.Count - 1]);
                        vertices[vertices.Count - 1].SetDraggable(false);
                        vStart = vertices[vertices.Count - 1];
                    }
                    else
                        MessageBox.Show("Maximum number of vertices has been reached!\n (You can create up to 26 vertices)");
                }
                else
                {
                    if (defaultVertexNameCounter <= 'Z')
                    {
                        vertices.Add(CreateVertex(defaultVertexNameCounter.ToString(), e.X, e.Y));
                        UpdateVertexNameCounter();
                        vertices[vertices.Count - 1].SetSelected(true);
                        DisselectOthers(vertices[vertices.Count - 1]);
                        vertices[vertices.Count - 1].SetDraggable(false);
                        vFinish = vertices[vertices.Count - 1];
                        if (isDirected)
                        {
                            vStart.SetEdge(vFinish);
                            mapMatrix.SetDirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                            mapList.SetDirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                        }
                        else
                        {
                            vStart.SetEdge(vFinish);
                            vFinish.SetEdge(vStart);
                            mapMatrix.SetUndirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                            mapList.SetUndirectedEdge(vStart.GetNumberIndex(), vFinish.GetNumberIndex());
                        }
                        vStart.SetSelected(false);
                        vFinish.SetSelected(false);
                        ResetBoard();
                        vStart = null;
                        vFinish = null;
                    }
                    else
                    {
                        ResetBoard();
                        MessageBox.Show("Maximum number of vertices has been reached!\n (You can create up to 26 vertices)");
                        vStart.SetSelected(false);
                        vStart.Refresh();
                        vStart = null;
                        vFinish = null;
                    }
                }
            }
            else if (selectedTool == "buttonTag")
            {
                DisselectAllVertices();
            }
        }

        /// <summary>
        /// Refresh the new edge being drawn.
        /// </summary>
        private void PanelSketchBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (vStart != null && selectedTool == "buttonEdge")
            {
                using (Graphics g = this.panelSketchBoard.CreateGraphics())
                {
                    ResetBoard();
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(new Pen(Color.Black, 5), vStart.GetCentreLocation(), e.Location);
                }
            }
        }
        #endregion

        #region Events for Vertices
        private void ButtonVertex_MouseUp(object sender, MouseEventArgs e)
        {
            SetCurrentTool(buttonVertex);
        }
        #endregion

        #region Events for Edges
        private void ButtonEdge_MouseUp(object sender, MouseEventArgs e)
        {
            SetCurrentTool(buttonEdge);
            timerShowEdgeProperties.Stop();
        }

        private void ButtonEdge_MouseDown(object sender, MouseEventArgs e)
        {
            timerShowEdgeProperties.Start();
        }

        private void TimerShowEdgeProperties_Tick(object sender, EventArgs e)
        {
            panelEdgeProperties.Visible = true;
        }

        private void ButtonDirected_Click(object sender, EventArgs e)
        {
            isDirected = true;
            buttonDirected.ForeColor = SystemColors.ControlText;
            buttonUndirected.ForeColor = SystemColors.ControlDark;
            panelEdgeProperties.Visible = false;
        }

        private void ButtonUndirected_Click(object sender, EventArgs e)
        {
            isDirected = false;
            buttonUndirected.ForeColor = SystemColors.ControlText;
            buttonDirected.ForeColor = SystemColors.ControlDark;
            panelEdgeProperties.Visible = false;
        }
        #endregion

        #region Events for Tag
        private void ButtonTag_MouseUp(object sender, MouseEventArgs e)
        {
            SetCurrentTool(buttonTag);
        }

        /// <summary>
        /// Show the tag window of the vertex, and all its adjacenct edge information.
        /// </summary>
        private void FormVertexTag_Load(object sender, EventArgs e)
        {
            for (int finishingVertex = 0; finishingVertex < mapMatrix.GetSize(); finishingVertex++)
            {
                int startingVertex = mapMatrix.GetVertexIndex((sender as FormVertexTag).Text.Trim("Vertex ".ToCharArray()));
                if (mapMatrix.IsVertexExisting(finishingVertex) && finishingVertex != startingVertex)
                {
                    (sender as FormVertexTag).AddVertexTagControl(finishingVertex);
                    if (mapMatrix.ContainsEdge(startingVertex, finishingVertex))
                    {
                        (sender as FormVertexTag).edgeControls[(sender as FormVertexTag).edgeControls.Count - 1].GetCheckBoxContainsEdge().Checked = true;
                        (sender as FormVertexTag).edgeControls[(sender as FormVertexTag).edgeControls.Count - 1].GetTextBoxWeight().Text = mapMatrix.GetEdge(startingVertex, finishingVertex).ToString();
                    }
                }
            }
        }

        private void FormVertexTag_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Validate the name of the vertex set in the tag window.
        /// </summary>
        private void FormVertexTag_buttonSave_Click_ValidateVertexName(object sender, EventArgs e)
        {
            string inputVertexNameString = formVertexTag.textBoxVertexName.Text;
            char inputVertexNameChar;
            if (inputVertexNameString.Length > 1)
            {
                formVertexTag.labelErrorMessage.Text = "Invalid name!";
            }
            else
            {
                inputVertexNameChar = Convert.ToChar(inputVertexNameString);
                if (inputVertexNameChar < 'A' || inputVertexNameChar > 'Z')
                {
                    formVertexTag.labelErrorMessage.Text = "Invalid name!";
                    formVertexTag.submitSuccessful = false;
                }
                else if (vertexNameUsed[inputVertexNameChar - 'A'])
                {
                    formVertexTag.labelErrorMessage.Text = "This vertex name has already been taken!";
                    formVertexTag.submitSuccessful = false;
                }
                else
                {
                    formVertexTag.labelErrorMessage.Text = "";
                }
            }
        }

        /// <summary>
        /// Update vertex information from the tag window.
        /// </summary>
        private void FormVertexTag_buttonSave_Click_UpdateVertex(object sender, EventArgs e)
        {
            if(formVertexTag.submitSuccessful)
            {
                char inputVertexNameChar = Convert.ToChar(formVertexTag.textBoxVertexName.Text);
                if (inputVertexNameChar != vTagChanged.GetName())
                {
                    vertexNameUsed[inputVertexNameChar - 'A'] = true;
                    vertexNameUsed[vTagChanged.GetNumberIndex()] = false;
                    if (vTagChanged.GetNumberIndex() < defaultVertexNameCounter - 'A')
                        defaultVertexNameCounter = Convert.ToChar(vTagChanged.GetNumberIndex() + 'A');
                    for (int i = 0; i < mapMatrix.GetSize(); i++)
                    {
                        mapMatrix.SetDirectedEdge((int)(inputVertexNameChar - 'A'), i, mapMatrix.GetEdge(vTagChanged.GetNumberIndex(), i));
                        mapMatrix.SetDirectedEdge(i, (int)(inputVertexNameChar - 'A'), mapMatrix.GetEdge(i, vTagChanged.GetNumberIndex()));
                    }
                    mapMatrix.RemoveVertex(vTagChanged.GetNumberIndex());
                    for (int i = 0; i < mapList.GetSize(); i++)
                    {
                        mapList.SetDirectedEdge((int)(inputVertexNameChar - 'A'), i, mapList.GetEdge(vTagChanged.GetNumberIndex(), i));
                        mapList.SetDirectedEdge(i, (int)(inputVertexNameChar - 'A'), mapList.GetEdge(i, vTagChanged.GetNumberIndex()));
                    }
                    mapList.RemoveVertex(vTagChanged.GetNumberIndex());
                    vTagChanged.SetName(inputVertexNameChar);
                }
                for (int i = 0; i < formVertexTag.edgeControls.Count; i++)
                {
                    if (formVertexTag.edgeControls[i].GetTextBoxWeight().Enabled)
                    {
                        int finishingVertex = Convert.ToChar(formVertexTag.edgeControls[i].GetLabelFinishingVertex().Name.Trim("label".ToCharArray())) - 'A';
                        double weight = Convert.ToDouble(formVertexTag.edgeControls[i].GetTextBoxWeight().Text);
                        foreach (Vertex v in vertices)
                            if (v.GetNumberIndex() == finishingVertex)
                            {
                                vTagChanged.SetEdge(v, weight);
                                break;
                            }
                        mapMatrix.SetDirectedEdge((int)(inputVertexNameChar - 'A'), finishingVertex, weight);
                        mapList.SetDirectedEdge((int)(inputVertexNameChar - 'A'), finishingVertex, weight);
                    }
                    else
                    {
                        int finishingVertex = Convert.ToChar(formVertexTag.edgeControls[i].GetLabelFinishingVertex().Name.Trim("label".ToCharArray())) - 'A';
                        foreach (Vertex v in vertices)
                            if (v.GetNumberIndex() == finishingVertex)
                            {
                                vTagChanged.RemoveEdge(v);
                                break;
                            }
                        mapMatrix.RemoveDirectedEdge((int)(inputVertexNameChar - 'A'), finishingVertex);
                        mapList.RemoveDirectedEdge((int)(inputVertexNameChar - 'A'), finishingVertex);
                    }
                }
                formVertexTag.Close();
                ResetBoard();
            }
        }

        /// <summary>
        /// Close the tag window without saving the changes.
        /// </summary>
        private void FormVertexTag_buttonCancel_Click(object sender, EventArgs e)
        {
            formVertexTag.Close();
            ResetBoard();
        }
        #endregion

        #region Events for buttonClearPanel
        /// <summary>
        /// Clear the panel.
        /// </summary>
        private void ButtonClearPanel_Click(object sender, EventArgs e)
        {
            SetCurrentTool(buttonClearPanel);
            foreach (Vertex v in vertices)
            {
                v.Dispose();
            }
            vertices.Clear();
            mapMatrix.Clear();
            mapList.Clear();
            defaultVertexNameCounter = 'A';
            Array.Clear(vertexNameUsed, 0, vertexNameUsed.Length);
            ResetBoard();
            topLeft = new Point(this.panelSketchBoard.Width, this.panelSketchBoard.Height);
            bottomRight = new Point(0, 0);
        }
        #endregion

        #region Events for Submission
        /// <summary>
        /// Take a screenshot of the graph.
        /// </summary>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            submitSuccessful = true;
            foreach (Vertex v in vertices)
                UpdateScreenCaptureRange(v.Location.X, v.Location.Y);
            topLeft.X += this.panelSketchBoard.Location.X;
            topLeft.Y += this.panelSketchBoard.Location.Y;
            bottomRight.X += this.panelSketchBoard.Location.X;
            bottomRight.Y += this.panelSketchBoard.Location.Y;
        }
        #endregion
    }
}
