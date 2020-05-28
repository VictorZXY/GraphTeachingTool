using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    public class DoTaskControls
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Controls & variables
        // User contols
        private System.Windows.Forms.Label labelTaskIndex;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.TextBox textBoxInputAnswer;
        private System.Windows.Forms.Button buttonInputGraph;
        private System.Windows.Forms.Label labelCorrectWrong;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Button buttonShowAnswer;

        /// <summary>
        /// The value of a numerical answer.
        /// </summary>
        private string answerValue;

        /// <summary>
        /// The adjacency matrix representation of a graphical answer.
        /// </summary>
        private AdjacencyMatrix answerMatrix;

        /// <summary>
        /// The adjacency matrix representation of a user-input answer graph.
        /// </summary>
        private AdjacencyMatrix inputMatrix;
        #endregion

        #region Constructor
        public DoTaskControls(int index)
        {
            this.labelTaskIndex = new System.Windows.Forms.Label();
            this.labelTask = new System.Windows.Forms.Label();
            this.textBoxInputAnswer = new System.Windows.Forms.TextBox();
            this.buttonInputGraph = new System.Windows.Forms.Button();
            this.labelCorrectWrong = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.buttonShowAnswer = new System.Windows.Forms.Button();
            answerValue = "";
            answerMatrix = null;
            System.Drawing.Point originalLocation = new System.Drawing.Point(6, 33);
            System.Drawing.Point location = new System.Drawing.Point(originalLocation.X, originalLocation.Y + (index - 1) * 54);
            // 
            // labelTaskIndex
            // 
            this.labelTaskIndex.AutoSize = true;
            this.labelTaskIndex.Location = location;
            this.labelTaskIndex.Name = "labelTask" + index.ToString();
            this.labelTaskIndex.Size = new System.Drawing.Size(46, 17);
            this.labelTaskIndex.Text = "Task " + index.ToString();
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(location.X + 55, location.Y);
            this.labelTask.Name = "labelTaskDescription" + index.ToString();
            this.labelTask.Size = new System.Drawing.Size(514, 17);
            this.labelTask.Text = "";
            // 
            // textBoxInputAnswer
            // 
            this.textBoxInputAnswer.Location = new System.Drawing.Point(location.X + 58, location.Y + 21);
            this.textBoxInputAnswer.Name = "textBoxInputAnswer" + index.ToString();
            this.textBoxInputAnswer.Size = new System.Drawing.Size(338, 23);
            // 
            // buttonInputGraph
            // 
            this.buttonInputGraph.Enabled = false;
            this.buttonInputGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInputGraph.Location = new System.Drawing.Point(location.X + 58, location.Y + 21);
            this.buttonInputGraph.Name = "buttonInputGraph" + index.ToString();
            this.buttonInputGraph.Size = new System.Drawing.Size(150, 23);
            this.buttonInputGraph.Text = "";
            this.buttonInputGraph.UseVisualStyleBackColor = true;
            this.buttonInputGraph.Visible = false;
            // 
            // labelCorrectWrong
            // 
            this.labelCorrectWrong.AutoSize = true;
            this.labelCorrectWrong.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.labelCorrectWrong.Location = new System.Drawing.Point(location.X + 398, location.Y + 21);
            this.labelCorrectWrong.Name = "labelCorrectWrong" + index.ToString();
            this.labelCorrectWrong.Size = new System.Drawing.Size(22, 22);
            this.labelCorrectWrong.Text = "×";
            this.labelCorrectWrong.Visible = false;
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.ForeColor = System.Drawing.Color.Red;
            this.labelAnswer.Location = new System.Drawing.Point(location.X + 417, location.Y + 24);
            this.labelAnswer.Name = "labelAnswer" + index.ToString();
            this.labelAnswer.Size = new System.Drawing.Size(85, 17);
            this.labelAnswer.Text = "Answer: ";
            this.labelAnswer.Visible = false;
            // 
            // buttonShowAnswer
            // 
            this.buttonShowAnswer.Enabled = false;
            this.buttonShowAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowAnswer.Location = new System.Drawing.Point(location.X + 510, location.Y + 21);
            this.buttonShowAnswer.Name = "buttonShowAnswer" + index.ToString();
            this.buttonShowAnswer.Size = new System.Drawing.Size(90, 23);
            this.buttonShowAnswer.Text = "Answer";
            this.buttonShowAnswer.UseVisualStyleBackColor = true;
            this.buttonShowAnswer.Visible = false;
        }
        #endregion

        #region "Get" Functions
        public System.Windows.Forms.Label GetLabelTaskIndex()
        {
            return this.labelTaskIndex;
        }

        public System.Windows.Forms.Label GetLabelTask()
        {
            return this.labelTask;
        }

        public System.Windows.Forms.TextBox GetTextBoxInputAnswer()
        {
            return this.textBoxInputAnswer;
        }

        public System.Windows.Forms.Button GetButtonInputGraph()
        {
            return this.buttonInputGraph;
        }

        public System.Windows.Forms.Label GetLabelCorrectWrong()
        {
            return this.labelCorrectWrong;
        }

        public System.Windows.Forms.Label GetLabelAnswer()
        {
            return this.labelAnswer;
        }

        public System.Windows.Forms.Button GetButtonShowAnswer()
        {
            return this.buttonShowAnswer;
        }

        public string GetAnswerValue()
        {
            return this.answerValue;
        }

        public AdjacencyMatrix GetAnswerMatrix()
        {
            return this.answerMatrix;
        }

        public AdjacencyMatrix GetInputMatrix()
        {
            return this.inputMatrix;
        }
        #endregion

        #region "Set" Functions
        public void SetLabelTaskIndex(System.Windows.Forms.Label newLabelTaskIndex)
        {
            this.labelTaskIndex = newLabelTaskIndex;
        }

        public void SetLabelTask(System.Windows.Forms.Label newLabelTask)
        {
            this.labelTask = newLabelTask;
        }

        public void SetTextBoxInputAnswer(System.Windows.Forms.TextBox newTextBoxInputAnswer)
        {
            this.textBoxInputAnswer = newTextBoxInputAnswer;
        }

        public void SetButtonInputGraph(System.Windows.Forms.Button newButtonInputGraph)
        {
            this.buttonInputGraph = newButtonInputGraph;
        }

        public void SetLabelCorrectWrong(System.Windows.Forms.Label newLabelCorrectWrong)
        {
            this.labelCorrectWrong = newLabelCorrectWrong;
        }

        public void SetLabelAnswer(System.Windows.Forms.Label newLabelAnswer)
        {
            this.labelAnswer = newLabelAnswer;
        }

        public void SetButtonShowAnswer(System.Windows.Forms.Button newButtonShowAnswer)
        {
            this.buttonShowAnswer = newButtonShowAnswer;
        }

        public void SetAnswerValue(string newAnswerValue)
        {
            this.answerValue = newAnswerValue;
        }

        public void SetAnswerMatrix(AdjacencyMatrix newAnswerMatrix)
        {
            this.answerMatrix = newAnswerMatrix;
        }

        public void SetInputMatrix(AdjacencyMatrix newInputMatrix)
        {
            this.inputMatrix = newInputMatrix;
        }
        #endregion
    }
}
