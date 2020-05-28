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
    public partial class DijkstraVertexLabel : UserControl
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Constructors
        /// <summary>
        /// Represents a vertex label for Dijkstra's algorithm demonstration.
        /// </summary>
        public DijkstraVertexLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Represents a vertex label for Dijkstra's algorithm demonstration.
        /// </summary>
        /// <param name="vertexName">The name of the vertex.</param>
        public DijkstraVertexLabel(char vertexName)
        {
            InitializeComponent();
            this.labelVertexName.Text = vertexName.ToString();
        }

        /// <summary>
        /// Represents a vertex label for Dijkstra's algorithm demonstration.
        /// </summary>
        /// <param name="location">The location of the label.</param>
        public DijkstraVertexLabel(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }

        /// <summary>
        /// Represents a vertex label for Dijkstra's algorithm demonstration.
        /// </summary>
        /// <param name="vertexName">The name of the vertex.</param>
        /// <param name="location">The location of the label.</param>
        public DijkstraVertexLabel(char vertexName, Point location)
        {
            InitializeComponent();
            this.labelVertexName.Text = vertexName.ToString();
            this.Location = location;
        }
        #endregion

        #region "Get" Function
        /// <summary>
        /// Gets the name of the vertex.
        /// </summary>
        /// <returns>The name of the vertex.</returns>
        public char GetVertexName()
        {
            return Convert.ToChar(this.labelVertexName.Text);
        }

        /// <summary>
        /// Gets the order of labelling in performing Dijkstra's algorithm.
        /// </summary>
        /// <returns>The order of labelling.</returns>
        public int GetLabellingOrder()
        {
            if (this.textBoxOrder.Text == "")
                return -1;
            else return Convert.ToInt32(this.textBoxOrder.Text);
        }

        /// <summary>
        /// Gets the value of the permanent label in performing Dijkstra's algrithm.
        /// </summary>
        /// <returns>The value of the permanent label.</returns>
        public double GetFinalLabel()
        {
            if (this.textBoxFinalLabel.Text == "")
                return -1;
            else return Convert.ToDouble(this.textBoxFinalLabel.Text);
        }

        /// <summary>
        /// Gets the values in the temporary label in performing Dijkstra's algorithm.
        /// </summary>
        /// <returns>Values in the temporary label.</returns>
        public string GetWorkingValues()
        {
            return this.textBoxWorkingValues.Text;
        }

        /// <summary>
        /// Gets the centre location of the label.
        /// </summary>
        /// <returns>The centre location of the label.</returns>
        public Point GetCentreLocation()
        {
            return new Point(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
        }

        /// <summary>
        /// Gets the distance between this label and another vertex label.
        /// </summary>
        /// <param name="v">The other vertex label.</param>
        /// <returns>The distance between the two labels.</returns>
        public double GetDistance(DijkstraVertexLabel v)
        {
            return Math.Sqrt((v.GetCentreLocation().X - this.GetCentreLocation().X) * (v.GetCentreLocation().X - this.GetCentreLocation().X)
                + (v.GetCentreLocation().Y - this.GetCentreLocation().Y) * (v.GetCentreLocation().Y - this.GetCentreLocation().Y));
        }

        /// <summary>
        /// Gets the number index of the name of the vertex.
        /// </summary>
        /// <returns>The number index of the vertex.</returns>
        public int GetNumberIndex()
        {
            return Convert.ToInt32(this.GetVertexName() - 'A');
        }
        #endregion

        #region "Set" Functions
        /// <summary>
        /// Sets the readonly status of the vertex label.
        /// </summary>
        /// <param name="status">The readonly status.</param>
        public void SetReadOnly(bool status)
        {
            textBoxFinalLabel.BackColor = SystemColors.Window;
            textBoxWorkingValues.BackColor = SystemColors.Window;
            textBoxOrder.BackColor = SystemColors.Window;
            textBoxFinalLabel.ReadOnly = status;
            textBoxWorkingValues.ReadOnly = status;
            textBoxOrder.ReadOnly = status;
        }

        /// <summary>
        /// Sets the name of the vertex.
        /// </summary>
        /// <param name="vertexName">The name of the vertex.</param>
        public void SetVertexName(char vertexName)
        {
            this.labelVertexName.Text = vertexName.ToString();
        }

        /// <summary>
        /// Sets the labelling order of the vertex.
        /// </summary>
        /// <param name="order">The labelling order of the vertex.</param>
        public void SetLabellingOrder(int order)
        {
            this.textBoxOrder.Text = order.ToString();
        }

        /// <summary>
        /// Sets the permanent label of the vertex.
        /// </summary>
        /// <param name="distance">The final shortest distance between this vertex and the starting vertex.</param>
        public void SetFinalLabel(double distance)
        {
            this.textBoxFinalLabel.Text = distance.ToString();
        }

        /// <summary>
        /// Sets the working values in the temporary label.
        /// </summary>
        /// <param name="workingValues">A string of the working values.</param>
        public void SetWorkingValues(string workingValues)
        {
            this.textBoxWorkingValues.Text = workingValues;
        }

        /// <summary>
        /// Add a new working value to the temporary label.
        /// </summary>
        /// <param name="workingValue">The new working value.</param>
        public void UpdateWorkingValues(double workingValue)
        {
            this.textBoxWorkingValues.Text += workingValue.ToString() + " ";
        }

        /// <summary>
        /// Finalise the vertex label by setting permanent label and order of labelling.
        /// </summary>
        /// <param name="distance">The final shortest distance between this vertex and the starting vertex.</param>
        /// <param name="order">The order of labelling.</param>
        public void Finalise(double distance, int order)
        {
            SetLabellingOrder(order);
            SetFinalLabel(distance);
        }
        #endregion

        #region GUI Operation Functions
        /// <summary>
        /// Highlight the vertex label.
        /// </summary>
        public void FocusOn()
        {
            this.labelVertexName.Font = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVertexName.ForeColor = Color.Red;
            this.textBoxOrder.ForeColor = Color.Red;
            this.textBoxFinalLabel.ForeColor = Color.Red;
            this.textBoxWorkingValues.ForeColor = Color.Red;
        }

        /// <summary>
        /// Unhighlight the vertex label.
        /// </summary>
        public void FocusOff()
        {
            this.labelVertexName.Font = new Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVertexName.ForeColor = SystemColors.ControlText;
            this.textBoxOrder.ForeColor = SystemColors.ControlText;
            this.textBoxFinalLabel.ForeColor = SystemColors.ControlText;
            this.textBoxWorkingValues.ForeColor = SystemColors.ControlText;
        }
        #endregion
    }
}
