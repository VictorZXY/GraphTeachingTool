using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    class ShortestPathExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        // Lists (Group A) are implemented here.
        /// <summary>
        /// A list of all Dijkstra vertex controls.
        /// </summary>
        public List<DijkstraVertexLabel> vertices = new List<DijkstraVertexLabel>();

        /// <summary>
        /// The adjacency matrix representation of the graph.
        /// </summary>
        AdjacencyMatrix mapMatrix = new AdjacencyMatrix();

        /// <summary>
        /// Array of labels showing the weights of the edges.
        /// </summary>
        public Label[,] labelWeights = new Label[26, 26];

        /// <summary>
        /// The panel on which the graph is to be drawn.
        /// </summary>
        Panel panel;
        #endregion

        #region Constructor
        public ShortestPathExample(Panel panel)
        {
            this.panel = panel;
            // Initialise edge weight labels
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
                    this.panel.Controls.Add(this.labelWeights[v1, v2]);
                }
        }
        #endregion

        #region "Get" Functions
        public List<DijkstraVertexLabel> GetVertices()
        {
            return this.vertices;
        }

        public AdjacencyMatrix GetMatrix()
        {
            return this.mapMatrix;
        }

        public Panel GetPanel()
        {
            return this.panel;
        }
        #endregion

        #region "Set" Functions
        public void SetPanel(Panel newPanel)
        {
            this.panel = newPanel;
        }

        /// <summary>
        /// Creates a new vertex.
        /// </summary>
        /// <param name="name">The name of the vertex.</param>
        /// <param name="x">The X-location of the vertex.</param>
        /// <param name="y">The Y-location of the vertex.</param>
        public void CreateVertex(char name, int x, int y)
        {
            DijkstraVertexLabel v = new DijkstraVertexLabel(name, new Point(x, y));
            v.SetReadOnly(true);
            v.BackColor = Color.White;
            this.vertices.Add(v);
            this.panel.Controls.Add(v);
            mapMatrix.EnableVertex(v.GetNumberIndex());
        }

        /// <summary>
        /// Creates a new undirected edge between two vertices.
        /// </summary>
        /// <param name="v1">Index of one of the two vertices.</param>
        /// <param name="v2">Index of the other vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void CreateUndirectedEdge(int v1, int v2, double weight)
        {
            mapMatrix.SetUndirectedEdge(v1, v2, weight);
        }

        /// <summary>
        /// Creates a new directed edge between two vertices.
        /// </summary>
        /// <param name="v1">Index of the starting vertex.</param>
        /// <param name="v2">Index of the finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void CreateDirectedEdge(int v1, int v2, double weight)
        {
            mapMatrix.SetDirectedEdge(v1, v2, weight);
        }
        #endregion

        #region GUI Operation Functions
        /// <summary>
        /// Shows the edge weight on the label.
        /// </summary>
        public void DrawLabelWeights()
        {
            for (int v1 = 0; v1 < mapMatrix.GetSize(); v1++)
                for (int v2 = 0; v2 < mapMatrix.GetSize(); v2++)
                {
                    labelWeights[v1, v2].Enabled = mapMatrix.ContainsEdge(v1, v2);
                    labelWeights[v1, v2].Visible = mapMatrix.ContainsEdge(v1, v2);
                }
            foreach (DijkstraVertexLabel v1 in vertices)
                foreach (DijkstraVertexLabel v2 in vertices)
                {
                    int vStart = v1.GetNumberIndex();
                    int vFinish = v2.GetNumberIndex();
                    if (mapMatrix.ContainsEdge(vStart, vFinish))
                    {
                        if (mapMatrix.ContainsEdge(vFinish, vStart) && mapMatrix.GetEdge(vStart, vFinish) != mapMatrix.GetEdge(vFinish, vStart))
                        {
                            if (vFinish > vStart)
                            {
                                Point midPoint = new Point
                                (
                                    (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                    (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                                );
                                Point pointForward = new Point
                                (
                                    Convert.ToInt32(Math.Round(midPoint.X + 42 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(midPoint.Y - 42 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                );
                                Point pointBackward = new Point
                                (
                                    Convert.ToInt32(Math.Round(midPoint.X - 42 * (v2.GetCentreLocation().Y - v1.GetCentreLocation().Y) / v1.GetDistance(v2))),
                                    Convert.ToInt32(Math.Round(midPoint.Y + 42 * (v2.GetCentreLocation().X - v1.GetCentreLocation().X) / v1.GetDistance(v2)))
                                );
                                labelWeights[vStart, vFinish].Location = new Point
                                (
                                    pointForward.X - labelWeights[vStart, vFinish].Width,
                                    pointForward.Y - labelWeights[vStart, vFinish].Height
                                );
                                labelWeights[vStart, vFinish].Text = mapMatrix.GetEdge(vStart, vFinish).ToString();
                                labelWeights[vFinish, vStart].Location = new Point
                                (
                                    pointBackward.X - labelWeights[vFinish, vStart].Width,
                                    pointBackward.Y - labelWeights[vFinish, vStart].Height
                                );
                                labelWeights[vFinish, vStart].Text = mapMatrix.GetEdge(vFinish, vStart).ToString();
                            }
                        }
                        else if (labelWeights[vStart, vFinish].Enabled)
                        {
                            Point midPoint = new Point
                            (
                                (v1.GetCentreLocation().X + v2.GetCentreLocation().X) / 2,
                                (v1.GetCentreLocation().Y + v2.GetCentreLocation().Y) / 2
                            );
                            labelWeights[vStart, vFinish].Location = new Point
                            (
                                midPoint.X - labelWeights[vStart, vFinish].Width,
                                midPoint.Y - labelWeights[vStart, vFinish].Height
                            );
                            labelWeights[vStart, vFinish].Text = mapMatrix.GetEdge(vStart, vFinish).ToString();
                            labelWeights[vFinish, vStart].Enabled = false;
                            labelWeights[vFinish, vStart].Visible = false;
                        }
                    }
                }
        }

        /// <summary>
        /// Highlights an edge weight label.
        /// </summary>
        /// <param name="v1">Index of the starting vertex.</param>
        /// <param name="v2">Index of the finishing vertex.</param>
        public void LabelFocusOn(int v1, int v2)
        {
            labelWeights[v1, v2].ForeColor = Color.Red;
        }

        /// <summary>
        /// Highlights an edge weight label.
        /// </summary>
        /// <param name="v1">Index of the starting vertex.</param>
        /// <param name="v2">Index of the finishing vertex.</param>
        public void LabelFocusOff(int v1, int v2)
        {
            labelWeights[v1, v2].ForeColor = SystemColors.ControlText;
        }
        #endregion
    }
}
