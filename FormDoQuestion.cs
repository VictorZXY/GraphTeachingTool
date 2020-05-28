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
    public partial class FormDoQuestion : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// The matrix representation of the problem graph.
        /// </summary>
        public AdjacencyMatrix taskMatrix;

        // Lists (Group A) are implemented here.
        /// <summary>
        /// A list of user controls for all the tasks
        /// </summary>
        public List<DoTaskControls> taskControls = new List<DoTaskControls>();

        // External forms
        FormEditAdjacencyMatrix formEditAdjacencyMatrix;
        FormEditAdjacencyList formEditAdjacencyList;
        FormSketchBoard formSketchBoard;
        FormViewTask formViewTask;
        #endregion

        #region Constructor
        public FormDoQuestion(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();
            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;
        }
        #endregion

        #region Events and Functions for Task Controls
        /// <summary>
        /// Adds a new conbination of user controls for a subtask.
        /// </summary>
        public void AddTaskControls()
        {
            int index = taskControls.Count;
            taskControls.Add(new DoTaskControls(index + 1));
            taskControls[index].GetTextBoxInputAnswer().TextChanged += new System.EventHandler(TextBoxInputAnswer_TextChanged);
            taskControls[index].GetButtonInputGraph().Click += new System.EventHandler(ButtonInputGraph_Click);
            taskControls[index].GetButtonShowAnswer().Click += new System.EventHandler(ButtonShowAnswer_Click);
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelTaskIndex());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelTask());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetTextBoxInputAnswer());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetButtonInputGraph());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelCorrectWrong());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelAnswer());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetButtonShowAnswer());
        }

        private void ButtonInputGraph_Click(object sender, EventArgs e)
        {
            buttonSubmit.Enabled = true;

            int taskIndex = -1;
            for (int i = 0; i < taskControls.Count; i++)
                if (taskControls[i].GetButtonInputGraph().Equals(sender as Button))
                    taskIndex = i;
            // Case of proceeding to EditAdjacencyMatrix
            if ((sender as Button).Text == "Adjacency Matrix")
            {
                formEditAdjacencyMatrix = new FormEditAdjacencyMatrix(accountMenu.accountID, accountMenu.username, accountMenu.labelAccountName.Text, accountMenu.accountType)
                {
                    Text = "Task " + (taskIndex + 1).ToString()
                };
                if (taskControls[taskIndex].GetInputMatrix() != null)
                    for (int col = 1; col <= taskControls[taskIndex].GetInputMatrix().GetSize(); col++)
                        for (int row = 0; row < taskControls[taskIndex].GetInputMatrix().GetSize(); row++)
                            if (taskControls[taskIndex].GetInputMatrix().ContainsEdge(col - 1, row))
                                formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix[col, row].Value = taskControls[taskIndex].GetInputMatrix().GetEdge(col - 1, row);
                formEditAdjacencyMatrix.labelInstructions.Text += "\nIf you want to go back to look at the graph of the question, you can save and close this and come back later. Your working progress will be saved.";
                formEditAdjacencyMatrix.buttonSubmit.Text = "Save";
                formEditAdjacencyMatrix.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
                formEditAdjacencyMatrix.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
                formEditAdjacencyMatrix.Show();
                this.Enabled = false;
                this.Hide();
            }
            // Case of proceeding to EditAdjacencyList
            else if ((sender as Button).Text == "Adjacency List")
            {
                formEditAdjacencyList = new FormEditAdjacencyList(accountMenu.accountID, accountMenu.username, accountMenu.labelAccountName.Text, accountMenu.accountType)
                {
                    Text = "Task " + (taskIndex + 1).ToString()
                };
                if (taskControls[taskIndex].GetInputMatrix() != null)
                    for (int vStart = 0; vStart < taskControls[taskIndex].GetInputMatrix().GetSize(); vStart++)
                    {
                        for (int vFinish = 0; vFinish < taskControls[taskIndex].GetInputMatrix().GetSize(); vFinish++)
                            if (taskControls[taskIndex].GetInputMatrix().ContainsEdge(vStart, vFinish))
                            {
                                if (formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value == null)
                                    formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value = Convert.ToChar('A' + vFinish).ToString() + ","
                                        + taskControls[taskIndex].GetInputMatrix().GetEdge(vStart, vFinish);
                                else
                                    formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value = formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value.ToString() + ","
                                        + Convert.ToChar('A' + vFinish).ToString() + ","
                                        + taskControls[taskIndex].GetInputMatrix().GetEdge(vStart, vFinish);
                            }
                    }
                formEditAdjacencyList.labelInstructions.Text += "\nIf you want to go back to look at the graph of the question, you can save and close this and come back later. Your working progress will be saved.";
                formEditAdjacencyList.buttonSubmit.Text = "Save";
                formEditAdjacencyList.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
                formEditAdjacencyList.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
                formEditAdjacencyList.Show();
                this.Enabled = false;
                this.Hide();
            }
            // Case of proceeding to SketchBoard
            else // if ((sender as Button).Text == "Sketch Board")
            {
                formSketchBoard = new FormSketchBoard(accountMenu.accountID, accountMenu.username, accountMenu.labelAccountName.Text, accountMenu.accountType)
                {
                    Text = "Task " + (taskIndex + 1).ToString()
                };
                formSketchBoard.buttonViewTask.Visible = true;
                formSketchBoard.buttonViewTask.Click += new System.EventHandler(this.FormSketchBoard_ButtonViewTask_Click);
                formSketchBoard.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
                formSketchBoard.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSketchBoard_FormClosed_CloseFormViewTask);
                formSketchBoard.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
                formSketchBoard.Show();
                this.Enabled = false;
                this.Hide();
            }
        }

        private void ButtonShowAnswer_Click(object sender, EventArgs e)
        {
            int taskIndex = -1;
            for (int i = 0; i < taskControls.Count; i++)
                if (taskControls[i].GetButtonShowAnswer().Equals(sender as Button))
                    taskIndex = i;
            
            // Show/hide numeric answer
            if (taskControls[taskIndex].GetTextBoxInputAnswer().Visible)
            {
                if ((sender as Button).Text == "Answer")
                {
                    taskControls[taskIndex].GetLabelAnswer().Visible = true;
                    (sender as Button).Text = "Hide";
                }
                else // if (buttonShowAnswer.Text == "Answer")
                {
                    taskControls[taskIndex].GetLabelAnswer().Visible = false;
                    (sender as Button).Text = "Answer";
                }
            }
            // Show/hide graphical answer
            else
            {
                // Adjacency matrix representation
                if (taskControls[taskIndex].GetButtonInputGraph().Text == "Adjacency Matrix")
                {
                    formEditAdjacencyMatrix = new FormEditAdjacencyMatrix(accountMenu.accountID, accountMenu.username, accountMenu.labelAccountName.Text, accountMenu.accountType)
                    {
                        Text = "Task " + (taskIndex + 1).ToString()
                    };
                    for (int col = 1; col <= taskControls[taskIndex].GetAnswerMatrix().GetSize(); col++)
                        for (int row = 0; row < taskControls[taskIndex].GetAnswerMatrix().GetSize(); row++)
                            if (taskControls[taskIndex].GetAnswerMatrix().ContainsEdge(col - 1, row))
                                formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix[col, row].Value = taskControls[taskIndex].GetAnswerMatrix().GetEdge(col - 1, row);
                    formEditAdjacencyMatrix.labelInstructions.Text = "This is the answer adjacecy matrix.\n"
                        + "Close this window to return to the question.";
                    formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix.ReadOnly = true;
                    formEditAdjacencyMatrix.buttonSubmit.Enabled = false;
                    formEditAdjacencyMatrix.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphicAnswerForms_FormClosed);
                    formEditAdjacencyMatrix.Show();
                    this.Enabled = false;
                    this.Hide();
                }
                // Adjacency list representation
                else if (taskControls[taskIndex].GetButtonInputGraph().Text == "Adjacency List")
                {
                    formEditAdjacencyList = new FormEditAdjacencyList(accountMenu.accountID, accountMenu.username, accountMenu.labelAccountName.Text, accountMenu.accountType)
                    {
                        Text = "Task " + (taskIndex + 1).ToString()
                    };
                    for (int vStart = 0; vStart < taskControls[taskIndex].GetAnswerMatrix().GetSize(); vStart++)
                    {
                        for (int vFinish = 0; vFinish < taskControls[taskIndex].GetAnswerMatrix().GetSize(); vFinish++)
                            if (taskControls[taskIndex].GetAnswerMatrix().ContainsEdge(vStart, vFinish))
                            {
                                if (formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value == null)
                                    formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value = Convert.ToChar('A' + vFinish).ToString() + ","
                                        + taskControls[taskIndex].GetAnswerMatrix().GetEdge(vStart, vFinish);
                                else
                                    formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value = formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value.ToString() + ","
                                        + Convert.ToChar('A' + vFinish).ToString() + ","
                                        + taskControls[taskIndex].GetAnswerMatrix().GetEdge(vStart, vFinish);
                            }
                    }
                    formEditAdjacencyList.labelInstructions.Text = "This is the answer adjacency list.\n"
                        + "Close this window to return to the question.";
                    formEditAdjacencyList.dataGridViewAdjacencyList.ReadOnly = true;
                    formEditAdjacencyList.buttonSubmit.Enabled = false;
                    formEditAdjacencyList.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphicAnswerForms_FormClosed);
                    formEditAdjacencyList.Show();
                    this.Enabled = false;
                    this.Hide();
                }
            }
        }
        #endregion

        #region Events for External Forms
        private void GraphEditingForms_buttonSubmit_Click(object sender, EventArgs e)
        {
            bool graphSubmitSuccessful = false;

            if (((Form)(sender as Button).TopLevelControl).Name == "FormSketchBoard")
                graphSubmitSuccessful = ((FormSketchBoard)(sender as Button).TopLevelControl).submitSuccessful;
            else if (((Form)(sender as Button).TopLevelControl).Name == "FormEditAdjacencyMatrix")
                graphSubmitSuccessful = ((FormEditAdjacencyMatrix)(sender as Button).TopLevelControl).submitSuccessful;
            else if (((Form)(sender as Button).TopLevelControl).Name == "FormEditAdjacencyList")
                graphSubmitSuccessful = ((FormEditAdjacencyList)(sender as Button).TopLevelControl).submitSuccessful;

            if (graphSubmitSuccessful)
            {
                ((Form)(sender as Button).TopLevelControl).Close();
            }
        }

        private void GraphEditingForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool graphSubmitSuccessful = false;

            if ((sender as Form).Name == "FormSketchBoard")
                graphSubmitSuccessful = ((FormSketchBoard)(sender as Form)).submitSuccessful;
            else if ((sender as Form).Name == "FormEditAdjacencyMatrix")
                graphSubmitSuccessful = ((FormEditAdjacencyMatrix)(sender as Form)).submitSuccessful;
            else if ((sender as Form).Name == "FormEditAdjacencyList")
                graphSubmitSuccessful = ((FormEditAdjacencyList)(sender as Form)).submitSuccessful;

            if (graphSubmitSuccessful)
            {
                int taskIndex = Convert.ToInt32((sender as Form).Text.TrimStart("Task ".ToCharArray())) - 1;

                if ((sender as Form).Name == "FormSketchBoard")
                    taskControls[taskIndex].SetInputMatrix(((FormSketchBoard)(sender as Form)).GetMatrix());
                else if ((sender as Form).Name == "FormEditAdjacencyMatrix")
                    taskControls[taskIndex].SetInputMatrix(((FormEditAdjacencyMatrix)(sender as Form)).GetMatrix());
                else if ((sender as Form).Name == "FormEditAdjacencyList")
                    taskControls[taskIndex].SetInputMatrix(((FormEditAdjacencyList)(sender as Form)).GetMatrix());
            }
            this.Enabled = true;
            this.Show();
        }

        private void GraphicAnswerForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }
        #endregion

        #region Events for view task graph in the Sketch Board
        private void FormSketchBoard_ButtonViewTask_Click(object sender, EventArgs e)
        {
            formViewTask = new FormViewTask();
            formViewTask.dataGridViewGraph.ColumnCount = this.dataGridViewGraph.ColumnCount;
            formViewTask.dataGridViewGraph.RowCount = this.dataGridViewGraph.RowCount;
            for (int col = 0; col < this.dataGridViewGraph.ColumnCount; col++)
            {
                formViewTask.dataGridViewGraph.Columns[col].Width = this.dataGridViewGraph.Columns[col].Width;
                formViewTask.dataGridViewGraph.Columns[col].HeaderText = this.dataGridViewGraph.Columns[col].HeaderText;
                for (int row = 0; row < this.dataGridViewGraph.RowCount; row++)
                    formViewTask.dataGridViewGraph[col, row].Value = this.dataGridViewGraph[col, row].Value;
            }
            formViewTask.dataGridViewGraph.ReadOnly = true;
            formViewTask.FormClosed += new FormClosedEventHandler(this.FormViewTask_FormClosed);
            formViewTask.Show();
            formSketchBoard.buttonViewTask.Enabled = false;
        }

        private void FormViewTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            formSketchBoard.buttonViewTask.Enabled = true;
        }

        private void FormSketchBoard_FormClosed_CloseFormViewTask(object sender, FormClosedEventArgs e)
        {
            if (!formSketchBoard.buttonViewTask.Enabled)
            {
                formViewTask.Close();
            }
        }
        #endregion

        #region Events for Marking
        private void TextBoxInputAnswer_TextChanged(object sender, EventArgs e)
        {
            // Detect any text change and then enable submission
            buttonSubmit.Enabled = true;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Mark the question
            int score = 0;
            for (int i = 0; i < taskControls.Count; i++)
            {
                if(taskControls[i].GetTextBoxInputAnswer().Visible)
                {
                    if (taskControls[i].GetTextBoxInputAnswer().Text.Trim() == taskControls[i].GetAnswerValue())
                    {
                        score++;
                        taskControls[i].GetLabelCorrectWrong().ForeColor = Color.Green;
                        taskControls[i].GetLabelCorrectWrong().Text = "√";
                        taskControls[i].GetLabelCorrectWrong().Visible = true;
                        taskControls[i].GetLabelAnswer().ForeColor = Color.Green;
                    }
                    else
                    {
                        taskControls[i].GetLabelCorrectWrong().ForeColor = Color.Red;
                        taskControls[i].GetLabelCorrectWrong().Text = "×";
                        taskControls[i].GetLabelCorrectWrong().Visible = true;
                        taskControls[i].GetLabelAnswer().ForeColor = Color.Red;
                    }
                    taskControls[i].GetButtonShowAnswer().Enabled = true;
                }
                else
                {
                    if (taskControls[i].GetAnswerMatrix().CompareTo(taskControls[i].GetInputMatrix()) == null)
                    {
                        score++;
                        taskControls[i].GetLabelCorrectWrong().ForeColor = Color.Green;
                        taskControls[i].GetLabelCorrectWrong().Text = "√";
                        taskControls[i].GetLabelCorrectWrong().Visible = true;
                    }
                    else
                    {
                        taskControls[i].GetLabelCorrectWrong().ForeColor = Color.Red;
                        taskControls[i].GetLabelCorrectWrong().Text = "×";
                        taskControls[i].GetLabelCorrectWrong().Visible = true;
                    }

                    if (taskControls[i].GetButtonInputGraph().Text == "Sketch Board")
                        taskControls[i].GetButtonShowAnswer().Enabled = false;
                    else
                        taskControls[i].GetButtonShowAnswer().Enabled = true;
                }
                taskControls[i].GetButtonShowAnswer().Visible = true;
            }
            if (score == taskControls.Count)
                labelScore.ForeColor = Color.Green;
            else
                labelScore.ForeColor = Color.Red;
            labelScore.Text = "Your score: " + score.ToString() + "/" + taskControls.Count.ToString();
            labelScore.Visible = true;
        }
        #endregion
    }
}
