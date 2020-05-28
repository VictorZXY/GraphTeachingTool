using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    public class TaskSettingControls
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Controls & variables
        // User controls
        private System.Windows.Forms.Label labelTaskIndex;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.Button buttonRemoveTask;
        private System.Windows.Forms.Label labelStartingVertex;
        private System.Windows.Forms.ComboBox comboBoxStartingVertex;
        private System.Windows.Forms.Label labelFinishingVertex;
        private System.Windows.Forms.ComboBox comboBoxFinishingVertex;

        /// <summary>
        /// Store the current text of the subtask
        /// </summary>
        private string currentTaskText;

        /// <summary>
        /// Stores the current names of starting/finishing vertices of the subtask, if exists.
        /// </summary>
        private string[] currentVertexText = new string[2];

        /// <summary>
        /// A readonly dictionary for all the possible contents of the tasks.
        /// </summary>
        public readonly Dictionary<string, string> tasks = new Dictionary<string, string>();
        #endregion

        #region Constructor
        public TaskSettingControls(int index)
        {
            this.labelTaskIndex = new System.Windows.Forms.Label();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.buttonRemoveTask = new System.Windows.Forms.Button();
            this.labelStartingVertex = new System.Windows.Forms.Label();
            this.comboBoxStartingVertex = new System.Windows.Forms.ComboBox();
            this.labelFinishingVertex = new System.Windows.Forms.Label();
            this.comboBoxFinishingVertex = new System.Windows.Forms.ComboBox();
            this.currentTaskText = "";
            System.Drawing.Point originalLocation = new System.Drawing.Point(6, 62);
            System.Drawing.Point location = new System.Drawing.Point(originalLocation.X, originalLocation.Y + (index - 1) * 63);
            // 
            // labelTaskIndex
            // 
            this.labelTaskIndex.AutoSize = true;
            this.labelTaskIndex.Location = location;
            this.labelTaskIndex.Name = "labelTask" + index.ToString();
            this.labelTaskIndex.Size = new System.Drawing.Size(64, 24);
            this.labelTaskIndex.Text = "Task " + index.ToString();
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Items.AddRange(new object[] {
            "Find the Minimum Spanning Tree of the graph using Prim's Algorithm",
            "Find the Minimum Spanning Tree of the graph using Kruskal's Algorithm",
            "Find the Shortest Path using Dijkstra's Algorithm",
            "Draw the graph corresponding to the adjacency list/matrix representation",
            "Write the graph in adjacency matrix representation",
            "Write the graph in adjacency list representation"});
            this.comboBoxTask.Location = new System.Drawing.Point(location.X + 55, location.Y - 5);
            this.comboBoxTask.Name = "comboBoxTask" + index.ToString();
            this.comboBoxTask.Size = new System.Drawing.Size(514, 32);
            this.comboBoxTask.TextChanged += new System.EventHandler(this.ComboBoxTask_TextChanged);
            // 
            // buttonRemoveTask
            // 
            this.buttonRemoveTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveTask.Font = new System.Drawing.Font("SimSun", 9F);
            this.buttonRemoveTask.Location = new System.Drawing.Point(location.X + 575, location.Y - 5);
            this.buttonRemoveTask.Name = "buttonRemoveTask" + index.ToString();
            this.buttonRemoveTask.Size = new System.Drawing.Size(25, 25);
            this.buttonRemoveTask.Text = "—";
            this.buttonRemoveTask.UseVisualStyleBackColor = true;
            // 
            // labelStartingVertex
            // 
            this.labelStartingVertex.Visible = false;
            this.labelStartingVertex.Enabled = false;
            this.labelStartingVertex.AutoSize = true;
            this.labelStartingVertex.Location = new System.Drawing.Point(location.X + 66, location.Y + 28);
            this.labelStartingVertex.Name = "labelStartingVertex" + index.ToString();
            this.labelStartingVertex.Size = new System.Drawing.Size(140, 24);
            this.labelStartingVertex.Text = "Starting vertex:";
            // 
            // comboBoxStartingVertex
            // 
            this.comboBoxStartingVertex.Visible = false;
            this.comboBoxStartingVertex.Enabled = false;
            this.comboBoxStartingVertex.FormattingEnabled = true;
            this.comboBoxStartingVertex.Items.AddRange(new object[] {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"});
            this.comboBoxStartingVertex.Location = new System.Drawing.Point(location.X + 164, location.Y + 25);
            this.comboBoxStartingVertex.Name = "comboBoxStartingVertex" + index.ToString();
            this.comboBoxStartingVertex.Size = new System.Drawing.Size(32, 32);
            this.comboBoxStartingVertex.Text = "";
            this.comboBoxStartingVertex.TextChanged += new System.EventHandler(this.ComboBoxVertex_TextChanged);
            // 
            // labelFinishingVertex
            // 
            this.labelFinishingVertex.Visible = false;
            this.labelFinishingVertex.Enabled = false;
            this.labelFinishingVertex.AutoSize = true;
            this.labelFinishingVertex.Location = new System.Drawing.Point(location.X + 202, location.Y + 28);
            this.labelFinishingVertex.Name = "labelFinishingVertex" + index.ToString();
            this.labelFinishingVertex.Size = new System.Drawing.Size(140, 24);
            this.labelFinishingVertex.Text = "Finishing vertex:";
            // 
            // comboBoxFinishingVertex
            // 
            this.comboBoxFinishingVertex.Visible = false;
            this.comboBoxFinishingVertex.Enabled = false;
            this.comboBoxFinishingVertex.FormattingEnabled = true;
            this.comboBoxFinishingVertex.Items.AddRange(new object[] {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"});
            this.comboBoxFinishingVertex.Location = new System.Drawing.Point(location.X + 306, location.Y + 25);
            this.comboBoxFinishingVertex.Name = "comboBoxFinishingVertex" + index.ToString();
            this.comboBoxFinishingVertex.Size = new System.Drawing.Size(32, 32);
            this.comboBoxFinishingVertex.Text = "";
            this.comboBoxFinishingVertex.TextChanged += new System.EventHandler(this.ComboBoxVertex_TextChanged);
            //
            // Dictionary tasks
            //
            tasks.Add("Prim", "Find the Minimum Spanning Tree of the graph using Prim's Algorithm");
            tasks.Add("Kruskal", "Find the Minimum Spanning Tree of the graph using Kruskal's Algorithm");
            tasks.Add("Dijkstra", "Find the Shortest Path using Dijkstra's Algorithm");
            tasks.Add("Graph", "Draw the graph corresponding to the adjacency list/matrix representation");
            tasks.Add("Matrix", "Write the graph in adjacency matrix representation");
            tasks.Add("List", "Write the graph in adjacency list representation");
        }
        #endregion

        #region "Get" Functions
        public System.Windows.Forms.Label GetLabelTaskIndex()
        {
            return this.labelTaskIndex;
        }

        public System.Windows.Forms.ComboBox GetComboBoxTask()
        {
            return this.comboBoxTask;
        }

        public System.Windows.Forms.Button GetButtonRemoveTask()
        {
            return this.buttonRemoveTask;
        }

        public System.Windows.Forms.Label GetLabelStartingVertex()
        {
            return this.labelStartingVertex;
        }

        public System.Windows.Forms.ComboBox GetComboBoxStartingVertex()
        {
            return this.comboBoxStartingVertex;
        }

        public System.Windows.Forms.Label GetLabelFinishingVertex()
        {
            return this.labelFinishingVertex;
        }

        public System.Windows.Forms.ComboBox GetComboBoxFinishingVertex()
        {
            return this.comboBoxFinishingVertex;
        }

        public string GetCurrentTaskText()
        {
            return this.currentTaskText;
        }
        #endregion

        #region "Set" Functions
        public void SetLabelTaskIndex(System.Windows.Forms.Label newLabelTaskIndex)
        {
            this.labelTaskIndex = newLabelTaskIndex;
        }

        public void SetComboBoxTask(System.Windows.Forms.ComboBox newComboBoxTask)
        {
            this.comboBoxTask = newComboBoxTask;
        }

        public void SetButtonRemoveTask(System.Windows.Forms.Button newButtonRemoveTask)
        {
            this.buttonRemoveTask = newButtonRemoveTask;
        }
        
        public void SetLabelStartingVertex(System.Windows.Forms.Label newLabelStartingVertex)
        {
            this.labelStartingVertex = newLabelStartingVertex;
        }

        public void SetComboBoxStartingVertex(System.Windows.Forms.ComboBox newComboBoxStartingVertex)
        {
            this.comboBoxStartingVertex = newComboBoxStartingVertex;
        }

        public void EnableStartingVertex()
        {
            this.labelStartingVertex.Enabled = true;
            this.labelStartingVertex.Visible = true;
            this.comboBoxStartingVertex.Enabled = true;
            this.comboBoxStartingVertex.Visible = true;
        }

        public void DisableStartingVertex()
        {
            this.labelStartingVertex.Visible = false;
            this.labelStartingVertex.Enabled = false;
            this.comboBoxStartingVertex.Visible = false;
            this.comboBoxStartingVertex.Enabled = false;
        }

        public void SetLabelFinishingVertex(System.Windows.Forms.Label newLabelFinishingVertex)
        {
            this.labelFinishingVertex = newLabelFinishingVertex;
        }

        public void SetComboBoxFinishingVertex(System.Windows.Forms.ComboBox newComboBoxFinishingVertex)
        {
            this.comboBoxFinishingVertex = newComboBoxFinishingVertex;
        }

        public void EnableFinishingVertex()
        {
            this.labelFinishingVertex.Enabled = true;
            this.labelFinishingVertex.Visible = true;
            this.comboBoxFinishingVertex.Enabled = true;
            this.comboBoxFinishingVertex.Visible = true;
        }

        public void DisableFinishingVertex()
        {
            this.labelFinishingVertex.Visible = false;
            this.labelFinishingVertex.Enabled = false;
            this.comboBoxFinishingVertex.Visible = false;
            this.comboBoxFinishingVertex.Enabled = false;
        }

        public void SetCurrentTaskText(string newCurrentTaskText)
        {
            this.currentTaskText = newCurrentTaskText;
        }
        #endregion

        #region Events
        private void ComboBoxTask_TextChanged(object sender, EventArgs e)
        {
            // Show input boxes for starting/finishing vertices when necessary
            string newTaskText = (sender as System.Windows.Forms.ComboBox).Text;
            if (newTaskText == "" || newTaskText == tasks["Kruskal"] || newTaskText == tasks["Graph"] || newTaskText == tasks["Matrix"] || newTaskText == tasks["List"])
            {
                this.SetCurrentTaskText(newTaskText);
                DisableStartingVertex();
                DisableFinishingVertex();
            }
            else if (newTaskText == tasks["Prim"])
            {
                this.SetCurrentTaskText(newTaskText);
                EnableStartingVertex();
                DisableFinishingVertex();
            }
            else if (newTaskText == tasks["Dijkstra"])
            {
                this.SetCurrentTaskText(newTaskText);
                EnableStartingVertex();
                EnableFinishingVertex();
            }
            else
            {
                this.GetComboBoxTask().Text = this.GetCurrentTaskText();
            }
        }

        private void ComboBoxVertex_TextChanged(object sender, EventArgs e)
        {
            string newVertexText = (sender as System.Windows.Forms.ComboBox).Text;
            string vertexType = (sender as System.Windows.Forms.ComboBox).Name.Substring(8, 1); // "S" represents starting vertex, and "F" represents finishing vertex
            int vertexTypeIndex = (vertexType == "S") ? 0 : 1;
            if (newVertexText == ""
                || (newVertexText.Length == 1 && (sender as System.Windows.Forms.ComboBox).Items.Contains(newVertexText)))
            {
                this.currentVertexText[vertexTypeIndex] = newVertexText;
            }
            else
            {
                (sender as System.Windows.Forms.ComboBox).Text = currentVertexText[vertexTypeIndex];
            }
        }
        #endregion
    }
}
