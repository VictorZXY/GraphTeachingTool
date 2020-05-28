using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class Vertex : UserControl
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Represents a directed edge starting from the vertex.
        /// </summary>
        private struct AdjacentEdge
        {
            /// <summary>
            /// The vertex that this edge is directed to.
            /// </summary>
            public Vertex vertex;
            /// <summary>
            /// The weight of this edge.
            /// </summary>
            public double weight;
        }

        /// <summary>
        /// List of all the directed edges starting from the vertex.
        /// </summary>
        private List<AdjacentEdge> adjacentEdges = new List<AdjacentEdge>();

        /// <summary>
        /// bool status indicating whether the vertex is being operated.
        /// </summary>
        private bool selected = false;

        /// <summary>
        /// bool status indicating whether the vertex is being clicked.
        /// </summary>
        private bool clicked = false;

        /// <summary>
        /// bool status indicating whether the vertex is allowed to be selected at the present state.
        /// </summary>
        private bool selectable = true;

        /// <summary>
        /// bool status indicating whether the vertex is allowed to be dragged at the present state.
        /// </summary>
        private bool draggable = true;

        /// <summary>
        /// bool status indicating whether the name of the vertex is being edited.
        /// </summary>
        private bool tagBeingEdited = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Represents an adjacency matrix, with the name and the centre location specified.
        /// </summary>
        /// <param name="name">The name of the vertex.</param>
        /// <param name="point">The centre location of the vertex.</param>
        public Vertex(String name, Point point)
        {
            InitializeComponent();
            this.Name = "vertex" + name;
            this.Location = new Point(point.X - this.Width / 2, point.Y - this.Height / 2);
            this.labelName.Text = name;
        }

        /// <summary>
        /// Represents an adjacency matrix, with the name and the centre location specified.
        /// </summary>
        /// <param name="name">The name of the vertex.</param>
        /// <param name="X">The X-coordinate of the centre location of the vertex.</param>
        /// <param name="Y">The Y-coordinate of the centre location of the vertex.</param>
        public Vertex(String name, int X, int Y)
        {
            InitializeComponent();
            this.Name = "vertex" + name;
            this.Location = new Point(X - this.Width / 2, Y - this.Height / 2);
            this.labelName.Text = name;
        }
        #endregion

        #region "Get" Functions
        /// <summary>
        /// Gets the name of the vertex.
        /// </summary>
        /// <returns>The name of the vertex.</returns>
        public char GetName()
        {
            return Convert.ToChar(this.Name.Trim("vertex".ToCharArray()));
        }

        /// <summary>
        /// Gets the centre location of the vertex.
        /// </summary>
        /// <returns>The centre location of the vertex.</returns>
        public Point GetCentreLocation()
        {
            return new Point(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
        }

        /// <summary>
        /// Determines whether the vertex is being operated.
        /// </summary>
        /// <returns>The status whether the vertex is being operated.</returns>
        public bool IsSelected()
        {
            return this.selected;
        }

        /// <summary>
        /// Determines whether the vertex is being clicked.
        /// </summary>
        /// <returns>The status whether the vertex is being clicked.</returns>
        public bool IsClicked()
        {
            return this.clicked;
        }

        /// <summary>
        /// Determines whether the vertex is allowed to be selected at the present state.
        /// </summary>
        /// <returns>The status whether the vertex is allowed to be selected at the present state.</returns>
        public bool IsSelectable()
        {
            return this.selectable;
        }

        /// <summary>
        /// Determines whether the vertex is allowed to be dragged at the present state.
        /// </summary>
        /// <returns>The status whether the vertex is allowed to be dragged at the present state.</returns>
        public bool IsDraggable()
        {
            return this.draggable;
        }

        /// <summary>
        /// Determines whether the name of the vertex is being edited.
        /// </summary>
        /// <returns>The status whether the name of the vertex is being edited.</returns>
        public bool IsTagBeingEdited()
        {
            return this.tagBeingEdited;
        }

        /// <summary>
        /// Gets the distance between this vertex and another vertex.
        /// </summary>
        /// <param name="v">The destination vertex.</param>
        /// <returns>The distance between the two vertices.</returns>
        public double GetDistance(Vertex v)
        {
            return Math.Sqrt((v.GetCentreLocation().X - this.GetCentreLocation().X) * (v.GetCentreLocation().X - this.GetCentreLocation().X)
                + (v.GetCentreLocation().Y - this.GetCentreLocation().Y) * (v.GetCentreLocation().Y - this.GetCentreLocation().Y));
        }

        /// <summary>
        /// Determines whether the vertex contains an directed edge to a selected vertex.
        /// </summary>
        /// <param name="v">The selected vertex</param>
        /// <returns>Returns TRUE if the vertex contains an directed edge to v.</returns>
        public bool ContainsEdge(Vertex v)
        {
            foreach (AdjacentEdge edge in adjacentEdges)
                if (edge.vertex.Equals(v))
                    return true;
            return false;
        }

        /// <summary>
        /// Returns the weight of the edge between this vertex and another vertex.
        /// </summary>
        /// <param name="v">The destination vertex.</param>
        /// <returns>The weight of the edge from this vertex to the destination vertex.</returns>
        public double GetEdge(Vertex v)
        {
            foreach (AdjacentEdge edge in adjacentEdges)
                if (edge.vertex.Equals(v))
                    return edge.weight;
            return 0;
        }

        /// <summary>
        /// Gets all the directed edges starting from the vertex.
        /// </summary>
        /// <returns>List<Vertex> that contains all the vertices connected to the vertex.</returns>
        public List<Vertex> GetEdges()
        {
            List<Vertex> output = new List<Vertex>();
            foreach (AdjacentEdge edge in adjacentEdges)
                output.Add(edge.vertex);
            return output;
        }

        /// <summary>
        /// Gets the vertex's index in the adjacency matrix from its name.
        /// </summary>
        /// <returns>The vertex's index in the adjacency matrix.</returns>
        public int GetNumberIndex()
        {
            return Convert.ToInt32(this.GetName() - 'A');
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        override public string ToString()
        {
            return this.Name;
        }
        #endregion

        #region "Set" Functions
        /// <summary>
        /// Sets name to the vertex.
        /// </summary>
        /// <param name="name">The new name of the vertex.</param>
        public void SetName(char name)
        {
            this.Name = "vertex" + name.ToString();
            this.labelName.Text = name.ToString();
        }

        /// <summary>
        /// Sets the status of whether the vertex is being operated.
        /// </summary>
        /// <param name="status">The status to be set on the vertex.</param>
        public void SetSelected(bool status)
        {
            this.selected = status;
        }

        /// <summary>
        /// Sets the status of whether the vertex is being clicked.
        /// </summary>
        /// <param name="status">The status to be set on the vertex.</param>
        public void SetClicked(bool status)
        {
            this.clicked = status;
        }

        /// <summary>
        /// Sets the status of whether the vertex is allowed to be selected at the present state.
        /// </summary>
        /// <param name="status">The status to be set on the vertex.</param>
        public void SetSelectable(bool status)
        {
            this.selectable = status;
        }

        /// <summary>
        /// Sets the status of whether the vertex is allowed to be dragged at the present state.
        /// </summary>
        /// <param name="status">The status to be set on the vertex.</param>
        public void SetDraggable(bool status)
        {
            this.draggable = status;
        }

        /// <summary>
        /// Sets the status of whether the name of the vertex is being edited.
        /// </summary>
        /// <param name="status">The status to be set on the vertex.</param>
        public void SetTagState(bool status)
        {
            this.tagBeingEdited = status;
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets a default weight (1) of the edge from this vertex to another vertex.
        /// </summary>
        /// <param name="v">The destination vertex.</param>
        public void SetEdge(Vertex v)
        {
            AdjacentEdge tempEdge = new AdjacentEdge
            {
                vertex = v,
                weight = 1
            };
            AdjacentEdge edgeToDelete = new AdjacentEdge();
            for (int i = 0; i < adjacentEdges.Count; i++)
                if (adjacentEdges[i].vertex.Equals(v))
                    edgeToDelete = adjacentEdges[i];
            this.adjacentEdges.Remove(edgeToDelete);
            this.adjacentEdges.Add(tempEdge);
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets a specified weight of the edge from this vertex to another vertex.
        /// </summary>
        /// <param name="v">The destination vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void SetEdge(Vertex v, double weight)
        {
            AdjacentEdge tempEdge = new AdjacentEdge
            {
                vertex = v,
                weight = weight
            };
            AdjacentEdge edgeToDelete = new AdjacentEdge();
            for (int i = 0; i < adjacentEdges.Count; i++)
                if (adjacentEdges[i].vertex.Equals(v))
                    edgeToDelete = adjacentEdges[i];
            this.adjacentEdges.Remove(edgeToDelete);
            this.adjacentEdges.Add(tempEdge);
        }

        /// <summary>
        /// Removes a directed edge from the vertex to a selected vertex.
        /// </summary>
        /// <param name="v">The selected finishing vertex.</param>
        public void RemoveEdge(Vertex v)
        {
            foreach (AdjacentEdge edge in adjacentEdges)
            {
                if (edge.vertex == v)
                {
                    adjacentEdges.Remove(edge);
                    return;
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the control is redrawn.
        /// </summary>
        private void Vertex_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (this.IsSelected())
                    g.DrawEllipse(new Pen(Color.Black, 2),
                        new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));
                else
                    g.DrawEllipse(new Pen(Color.Black),
                        new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over labelName and a mouse button is pressed.
        /// </summary>
        private void LabelName_MouseDown(object sender, MouseEventArgs e)
        {
            int distanceX = e.X - this.Width / 2;
            int distanceY = e.Y - this.Height / 2;
            if (distanceX * distanceX + distanceY * distanceY <= this.Width * this.Height / 4)
            {
                // Calls the event Vertex_MouseDown of the vertex.
                this.OnMouseDown(e);
            }
            else
                return;
        }

        /// <summary>
        /// Occurs when the mouse pointer is moved over labelName.
        /// </summary>
        private void LabelName_MouseMove(object sender, MouseEventArgs e)
        {
            // Calls the event Vertex_MouseMove of the vertex.
            this.OnMouseMove(e);
        }

        /// <summary>
        /// Occurs when the mouse pointer is over labelName and a mouse button is released.
        /// </summary>
        private void LabelName_MouseUp(object sender, MouseEventArgs e)
        {
            // Calls the event Vertex_MouseUp of the vertex.
            this.OnMouseUp(e);
        }

        /// <summary>
        /// Occurs when labelName is double clicked by the mouse.
        /// </summary>
        private void LabelName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Calls the event Vertex_MouseDoubleClick of the vertex.
            this.OnMouseDoubleClick(e);
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// This is a general event and is overrided in implementation.
        /// </summary>
        private void Vertex_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(this.IsTagBeingEdited() && this.IsSelected()) && this.IsSelectable())
            {
                this.SetSelected(!this.IsSelected());
            }
            this.Refresh();
            this.SetClicked(true);
        }

        /// <summary>
        /// Occurs when the mouse pointer is moved over the control.
        /// This is a general event and is overrided in implementation.
        /// </summary>
        private void Vertex_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.IsClicked() && this.IsDraggable())
            {
                this.SetSelected(true && this.IsSelectable());
                this.Location = new Point(this.Location.X + e.X - this.Width / 2,
                    this.Location.Y + e.Y - this.Height / 2);
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// This is a general event and is overrided in implementation.
        /// </summary>
        private void Vertex_MouseUp(object sender, MouseEventArgs e)
        {
            this.SetClicked(false);
        }

        /// <summary>
        /// Occurs when a character, space or backspace key is pressed while the control has focus.
        /// This is a general event and is overrided in implementation.
        /// </summary>
        private void Vertex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)(Keys.Delete) || e.KeyChar == (char)(Keys.Back))
            {
                this.Dispose();
            }
        }
        #endregion
    }
}
