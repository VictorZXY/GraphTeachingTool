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
    public partial class FormVertexTag : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        // Lists (Group A) are implemented here.
        /// <summary>
        /// A list of user controls for adjacent edge information.
        /// </summary>
        public List<VertexTagControls> edgeControls = new List<VertexTagControls>();

        /// <summary>
        /// Indicator for successful submission.
        /// </summary>
        public bool submitSuccessful;

        public FormVertexTag()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a new combination of user controls for an adjacent edge
        /// </summary>
        /// <param name="vertex">The name of the finishing vertex.</param>
        public void AddVertexTagControl(int vertex)
        {
            int index = edgeControls.Count;
            edgeControls.Add(new VertexTagControls(index, vertex));
            edgeControls[index].GetTextBoxWeight().TextChanged += new System.EventHandler(TextBox_TextChanged);
            this.Controls.Add(edgeControls[index].GetLabelFinishingVertex());
            this.Controls.Add(edgeControls[index].GetCheckBoxContainsEdge());
            this.Controls.Add(edgeControls[index].GetLabelWeight());
            this.Controls.Add(edgeControls[index].GetTextBoxWeight());
            this.buttonSave.Location = new Point(this.buttonSave.Location.X, edgeControls[index].GetTextBoxWeight().Location.Y + 29);
            this.buttonCancel.Location = new Point(this.buttonCancel.Location.X, edgeControls[index].GetTextBoxWeight().Location.Y + 29);
            this.Height = this.buttonSave.Location.Y + 82;
        }

        /// <summary>
        /// Absorbs all spaces and line breaks.
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.Trim();
            (sender as TextBox).Text = (sender as TextBox).Text.Trim('\n');
        }

        private void ButtonSave_Click_ValidateWeights(object sender, EventArgs e)
        {
            submitSuccessful = true;
            for (int i = 0; i < edgeControls.Count; i++)
                if (edgeControls[i].GetTextBoxWeight().Enabled)
                {
                    try
                    {
                        double weight = Convert.ToDouble(edgeControls[i].GetTextBoxWeight().Text);
                        if (weight <= 0) // Non-positive weight exception
                        {
                            submitSuccessful = false;
                            MessageBox.Show("Invalid input for weight "
                                + this.Text.Trim("Vertex ".ToCharArray())
                                + edgeControls[i].GetLabelFinishingVertex().Name.Trim("label".ToCharArray())
                                + ":\nPlease input a positive real number!");
                            edgeControls[i].GetLabelWeight().ForeColor = Color.Red;
                        }
                        else // Correct input
                            edgeControls[i].GetLabelWeight().ForeColor = SystemColors.ControlText;
                    }
                    catch // Invalid input exception
                    {
                        submitSuccessful = false;
                        MessageBox.Show("Invalid input for weight "
                                        + this.Text.Trim("Vertex ".ToCharArray())
                                        + edgeControls[i].GetLabelFinishingVertex().Name.Trim("label".ToCharArray())
                                        + ":\nPlease input a positive real number!");
                        edgeControls[i].GetLabelWeight().ForeColor = Color.Red;
                    }
                }
        }
    }
}
