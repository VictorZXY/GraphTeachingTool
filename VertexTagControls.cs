using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    public class VertexTagControls
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        // User controls
        private System.Windows.Forms.Label labelFinishingVertex;
        private System.Windows.Forms.CheckBox checkBoxContainsEdge;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        #endregion

        #region Constructors
        public VertexTagControls(int index, int vertex)
        {
            this.labelFinishingVertex = new System.Windows.Forms.Label();
            this.checkBoxContainsEdge = new System.Windows.Forms.CheckBox();
            this.labelWeight = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            System.Drawing.Point originalLocation = new System.Drawing.Point(12, 61);
            System.Drawing.Point location = new System.Drawing.Point(originalLocation.X, originalLocation.Y + index * 29);
            // 
            // labelFinishingVertex
            // 
            this.labelFinishingVertex.AutoSize = true;
            this.labelFinishingVertex.Location = location;
            this.labelFinishingVertex.Name = "label" + Convert.ToChar('A' + vertex).ToString();
            this.labelFinishingVertex.Size = new System.Drawing.Size(85, 17);
            this.labelFinishingVertex.Text = "To Vertex " + Convert.ToChar('A' + vertex).ToString() + ": ";
            // 
            // checkBoxContainsEdge
            // 
            this.checkBoxContainsEdge.AutoSize = true;
            this.checkBoxContainsEdge.Location = new System.Drawing.Point(location.X + 91, location.Y - 1);
            this.checkBoxContainsEdge.Name = "checkBox" + Convert.ToChar('A' + vertex).ToString();
            this.checkBoxContainsEdge.Size = new System.Drawing.Size(83, 21);
            this.checkBoxContainsEdge.Text = "Has edge";
            this.checkBoxContainsEdge.UseVisualStyleBackColor = true;
            this.checkBoxContainsEdge.CheckedChanged += new System.EventHandler(CheckBoxContainsEdge_CheckChanged);
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Enabled = false;
            this.labelWeight.Location = new System.Drawing.Point(location.X + 180, location.Y);
            this.labelWeight.Name = "labelWeight" + Convert.ToChar('A' + vertex).ToString();
            this.labelWeight.Size = new System.Drawing.Size(52, 17);
            this.labelWeight.Text = "Weight:";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Enabled = false;
            this.textBoxWeight.Location = new System.Drawing.Point(location.X + 238, location.Y - 3);
            this.textBoxWeight.Name = "textBoxWeight" + Convert.ToChar('A' + vertex).ToString();
            this.textBoxWeight.Size = new System.Drawing.Size(129, 23);
        }
        #endregion

        #region "Get" Functions
        public System.Windows.Forms.Label GetLabelFinishingVertex()
        {
            return this.labelFinishingVertex;
        }

        public System.Windows.Forms.CheckBox GetCheckBoxContainsEdge()
        {
            return this.checkBoxContainsEdge;
        }

        public System.Windows.Forms.Label GetLabelWeight()
        {
            return this.labelWeight;
        }

        public System.Windows.Forms.TextBox GetTextBoxWeight()
        {
            return this.textBoxWeight;
        }
        #endregion

        #region "Set" Functions
        public void SetLabelFinishingVertex(System.Windows.Forms.Label newLabelFinishingVertex)
        {
            this.labelFinishingVertex = newLabelFinishingVertex;
        }

        public void SetCheckBoxContainsEdge(System.Windows.Forms.CheckBox newCheckBoxContainsEdge)
        {
            this.checkBoxContainsEdge = newCheckBoxContainsEdge;
        }

        public void SetLabelWeight(System.Windows.Forms.Label newLabelWeight)
        {
            this.labelWeight = newLabelWeight;
        }

        public void SetTextBoxWeight(System.Windows.Forms.TextBox newTextBoxWeight)
        {
            this.textBoxWeight = newTextBoxWeight;
        }
        #endregion

        #region Events
        private void CheckBoxContainsEdge_CheckChanged(object sender, EventArgs e)
        {
            if ((sender as System.Windows.Forms.CheckBox).Checked)
            {
                this.labelWeight.Enabled = true;
                this.textBoxWeight.Enabled = true;
            }
            else
            {
                this.labelWeight.Enabled = false;
                this.textBoxWeight.Text = "";
                this.textBoxWeight.Enabled = false;
            }
        }
        #endregion
    }
}
