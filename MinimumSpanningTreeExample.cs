using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    class MinimumSpanningTreeExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// A list of all vertex controls.
        /// </summary>
        public List<Vertex> vertices = new List<Vertex>();

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
        public MinimumSpanningTreeExample(Panel panel)
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
        public List<Vertex> GetVertices()
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
        public void CreateVertex(string name, int x, int y)
        {
            Vertex v = new Vertex(name, new Point(x, y));
            v.SetSelectable(false);
            v.SetDraggable(false);
            v.BackColor = Color.White;
            this.vertices.Add(v);
            this.panel.Controls.Add(v);
            mapMatrix.EnableVertex(v.GetNumberIndex());
        }

        /// <summary>
        /// Creates a new undirected edge between two vertices.
        /// </summary>
        /// <param name="v1">One of the two vertices.</param>
        /// <param name="v2">The other vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void CreateEdge(Vertex v1, Vertex v2, double weight)
        {
            v1.SetEdge(v2, weight);
            v2.SetEdge(v1, weight);
            mapMatrix.SetUndirectedEdge(v1.GetNumberIndex(), v2.GetNumberIndex(), weight);
        }

        /// <summary>
        /// Creates a new undirected edge between two vertices.
        /// </summary>
        /// <param name="v1">Index of one of the two vertices.</param>
        /// <param name="v2">Index of the other vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void CreateEdge(int v1, int v2, double weight)
        {
            for (int i = 0; i < vertices.Count; i++)
                for (int j = 0; j < vertices.Count; j++)
                    if (vertices[i].GetNumberIndex() == v1 && vertices[j].GetNumberIndex() == v2)
                    {
                        vertices[i].SetEdge(vertices[j], weight);
                        vertices[j].SetEdge(vertices[i], weight);
                    }
            mapMatrix.SetUndirectedEdge(v1, v2, weight);
        }
        #endregion

        #region GUI Operation Functions
        /// <summary>
        /// Shows the edge weight on the label.
        /// </summary>
        public void DrawLabelWeights()
        {
            for (int v1 = 0; v1 < mapMatrix.GetSize() - 1; v1++)
                for (int v2 = v1 + 1; v2 < mapMatrix.GetSize(); v2++)
                {
                    labelWeights[v1, v2].Enabled = mapMatrix.ContainsEdge(v1, v2);
                    labelWeights[v1, v2].Visible = mapMatrix.ContainsEdge(v1, v2);
                }
            foreach (Vertex v1 in vertices)
                foreach (Vertex v2 in v1.GetEdges())
                    if (v2.GetNumberIndex() > v1.GetNumberIndex())
                    {
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
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Highlights an edge weight label.
        /// </summary>
        /// <param name="v1">One of the two vertices.</param>
        /// <param name="v2">The other vertex.</param>
        public void LabelFocusOn(Vertex v1, Vertex v2)
        {
            labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].ForeColor = Color.Red;
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Highlights an edge weight label.
        /// </summary>
        /// <param name="v1">Index of one of the two vertices.</param>
        /// <param name="v2">Index of the other vertex.</param>
        public void LabelFocusOn(int v1, int v2)
        {
            labelWeights[v1, v2].ForeColor = Color.Red;
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Unhighlights an edge weight label.
        /// </summary>
        /// <param name="v1">One of the two vertices.</param>
        /// <param name="v2">The other vertex.</param>
        public void LabelFocusOff(Vertex v1, Vertex v2)
        {
            labelWeights[v1.GetNumberIndex(), v2.GetNumberIndex()].ForeColor = SystemColors.ControlText;
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Unhighlights an edge weight label.
        /// </summary>
        /// <param name="v1">Index of one of the two vertices.</param>
        /// <param name="v2">Index of the other vertex.</param>
        public void LabelFocusOff(int v1, int v2)
        {
            labelWeights[v1, v2].ForeColor = SystemColors.ControlText;
        }
        #endregion
    }
}
