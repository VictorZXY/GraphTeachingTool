using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormTaskSetting : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        // Lists (Group A) are implemented here.
        /// <summary>
        /// A list of user controls for users to edit subtasks.
        /// </summary>
        public List<TaskSettingControls> taskControls = new List<TaskSettingControls>();

        // External graph-editing windows to be opened when requested.
        FormSketchBoard formSketchBoard;
        FormEditAdjacencyMatrix formEditAdjacencyMatrix;
        FormEditAdjacencyList formEditAdjacencyList;

        /// <summary>
        /// The adjacency matrix representation of the problem graph.
        /// </summary>
        public AdjacencyMatrix taskMatrix;

        /// <summary>
        /// The name of the graph-editing window.
        /// </summary>
        string graphEditingFormName;
        
        /// <summary>
        /// The SQLite command.
        /// </summary>
        string sql;

        /// <summary>
        /// Indicator of whether this is a new problem or a previous problem being edited.
        /// </summary>
        public bool isNewTask = true;

        /// <summary>
        /// Indicator of whether the contents of this problem have been edited.
        /// </summary>
        public bool edited;

        /// <summary>
        /// Indicator of whether this problem has been saved.
        /// </summary>
        public bool saved;

        /// <summary>
        /// The ID of the problem graph in the database.
        /// </summary>
        int graphID = -1;

        /// <summary>
        /// The ID of the question in the database.
        /// </summary>
        int questionID = -1;

        // Key points for screenshooting of the Sketch Board.
        Point sketchBoardTopLeft;
        Point sketchBoardBottomRight;
        Point sketchBoardFormLocation;
        #endregion

        #region Constructor
        public FormTaskSetting(int accountID, string username, string accountName, bool isNewTask)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = "TEACHER";

            // Create task controls for Task 1
            taskControls.Add(new TaskSettingControls(1));
            taskControls[0].GetButtonRemoveTask().Enabled = false;
            taskControls[0].GetButtonRemoveTask().Click += new System.EventHandler(ButtonRemoveTask_Click);
            taskControls[0].GetComboBoxTask().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            taskControls[0].GetComboBoxStartingVertex().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            taskControls[0].GetComboBoxFinishingVertex().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            this.groupBoxTasks.Controls.Add(taskControls[0].GetLabelTaskIndex());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetComboBoxTask());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetButtonRemoveTask());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetLabelStartingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetComboBoxStartingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetLabelFinishingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[0].GetComboBoxFinishingVertex());

            // Initialise indicators.
            edited = false;
            saved = false;
            this.isNewTask = isNewTask;
        }
        #endregion

        #region Operation Functions
        /// <summary>
        /// Adds a new combination of user controls for editing a subtask.
        /// </summary>
        public void AddTaskControls()
        {
            edited = true;
            buttonSave.Enabled = true;
            int index = taskControls.Count;
            taskControls.Add(new TaskSettingControls(index + 1));
            taskControls[index].GetButtonRemoveTask().Click += new System.EventHandler(ButtonRemoveTask_Click);
            taskControls[index].GetComboBoxTask().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            taskControls[index].GetComboBoxStartingVertex().Items.Clear();
            foreach (string vertexName in taskControls[0].GetComboBoxStartingVertex().Items)
                taskControls[index].GetComboBoxStartingVertex().Items.Add(vertexName);
            taskControls[index].GetComboBoxStartingVertex().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            taskControls[index].GetComboBoxFinishingVertex().Items.Clear();
            foreach (string vertexName in taskControls[0].GetComboBoxFinishingVertex().Items)
                taskControls[index].GetComboBoxFinishingVertex().Items.Add(vertexName);
            taskControls[index].GetComboBoxFinishingVertex().TextChanged += new System.EventHandler(TaskControlsComboBoxes_TextChanged);
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelTaskIndex());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetComboBoxTask());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetButtonRemoveTask());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelStartingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetComboBoxStartingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetLabelFinishingVertex());
            this.groupBoxTasks.Controls.Add(taskControls[index].GetComboBoxFinishingVertex());
            taskControls[0].GetButtonRemoveTask().Enabled = true;
        }

        private void ResetDataGridViewGraph(int columnCount)
        {
            dataGridViewGraph.Columns.Clear();
            for (int i = 0; i <= columnCount; i++)
            {
                DataGridViewColumn newColumn = new DataGridViewColumn
                {
                    CellTemplate = new DataGridViewTextBoxCell(),
                    SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
                };
                if (i == 0)
                    newColumn.Width = 41;
                dataGridViewGraph.Columns.Add(newColumn);
            }
        }

        // Files organised for direc access (Group A) is implemented here.
        /// <summary>
        /// Save the graph from the graph-editing form.
        /// </summary>
        /// <param name="mapMatrix">The adjacency matrix representation of the graph.</param>
        /// <param name="graphForm">The name of the graph-editing form used.</param>
        private void SaveGraph(AdjacencyMatrix mapMatrix, string graphForm)
        {
            foreach (TaskSettingControls taskControl in taskControls)
            {
                taskControl.GetComboBoxStartingVertex().Items.Clear();
                taskControl.GetComboBoxFinishingVertex().Items.Clear();
                for (int i = 0; i < mapMatrix.GetSize(); i++)
                    if (mapMatrix.IsVertexExisting(i))
                    {
                        taskControl.GetComboBoxStartingVertex().Items.Add(Convert.ToChar('A' + i).ToString());
                        taskControl.GetComboBoxFinishingVertex().Items.Add(Convert.ToChar('A' + i).ToString());
                    }
            }

            if (graphForm == "AdjacencyMatrix")
            {
                pictureBoxGraph.Visible = false;
                dataGridViewGraph.Visible = true;

                ResetDataGridViewGraph(mapMatrix.Count());

                int count = 1;
                for (int i = 0; i < mapMatrix.GetSize(); i++)
                    if (mapMatrix.IsVertexExisting(i))
                    {
                        dataGridViewGraph.Columns[count].HeaderText = Convert.ToChar('A' + i).ToString();
                        dataGridViewGraph.Columns[count].Name = "Column" + dataGridViewGraph.Columns[count].HeaderText;
                        count++;
                    }

                count = 0;
                this.dataGridViewGraph.RowCount = mapMatrix.Count();
                for (int i = 0; i < mapMatrix.GetSize(); i++)
                    if (mapMatrix.IsVertexExisting(i))
                        this.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                for (int col = 1; col <= mapMatrix.Count(); col++)
                    for (int row = 0; row < mapMatrix.Count(); row++)
                    {
                        int vStartIndex = mapMatrix.GetVertexIndex(dataGridViewGraph.Columns[col].HeaderText);
                        int vFinishIndex = mapMatrix.GetVertexIndex(this.dataGridViewGraph[0, row].Value.ToString());
                        this.dataGridViewGraph[col, row].Value = mapMatrix.GetEdge(vStartIndex, vFinishIndex);
                    }
            }
            else if (graphForm == "AdjacencyList")
            {
                pictureBoxGraph.Visible = false;
                dataGridViewGraph.Visible = true;

                ResetDataGridViewGraph(1);

                dataGridViewGraph.Columns[0].HeaderText = "Vertex";
                dataGridViewGraph.Columns[0].Name = "ColumnVertex";
                dataGridViewGraph.Columns[0].Width = 100;
                dataGridViewGraph.Columns[1].HeaderText = "Adjacent Edges";
                dataGridViewGraph.Columns[1].Name = "ColumnAdjacentEdges";
                dataGridViewGraph.Columns[1].Width = dataGridViewGraph.Width - 103;

                int count = 0;
                this.dataGridViewGraph.RowCount = mapMatrix.Count();
                for (int i = 0; i < mapMatrix.GetSize(); i++)
                    if (mapMatrix.IsVertexExisting(i))
                        this.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                for (int vStart = 0; vStart < mapMatrix.Count(); vStart++)
                {
                    this.dataGridViewGraph[1, vStart].Value = "";
                    for (int vFinish = 0; vFinish < mapMatrix.Count(); vFinish++)
                    {
                        int vStartIndex = mapMatrix.GetVertexIndex(this.dataGridViewGraph[0, vStart].Value.ToString());
                        int vFinishIndex = mapMatrix.GetVertexIndex(this.dataGridViewGraph[0, vFinish].Value.ToString());
                        if (mapMatrix.ContainsEdge(vStartIndex, vFinishIndex))
                        {
                            this.dataGridViewGraph[1, vStart].Value = this.dataGridViewGraph[1, vStart].Value.ToString() + ","
                                + Convert.ToChar('A' + vFinishIndex).ToString() + ","
                                + mapMatrix.GetEdge(vStartIndex, vFinishIndex);
                        }
                    }
                    if (this.dataGridViewGraph[1, vStart].Value.ToString() != "")
                        this.dataGridViewGraph[1, vStart].Value = this.dataGridViewGraph[1, vStart].Value.ToString().Remove(0, 1);
                }
            }
            else // if (graphForm == "SketchBoard")
            {
                pictureBoxGraph.Visible = true;
                dataGridViewGraph.Visible = false;

                Bitmap screenCapture = new Bitmap(sketchBoardBottomRight.X - sketchBoardTopLeft.X + 120, sketchBoardBottomRight.Y - sketchBoardTopLeft.Y + 120);
                using (Graphics g = Graphics.FromImage(screenCapture))
                {
                    Point screenCaptureTopLeft = new Point
                    (
                        sketchBoardFormLocation.X + sketchBoardTopLeft.X - 30,
                        sketchBoardFormLocation.Y + sketchBoardTopLeft.Y - 30
                    );
                    g.CopyFromScreen(screenCaptureTopLeft, new Point(0, 0), screenCapture.Size);
                    pictureBoxGraph.Image = screenCapture;
                }
            }
        }

        /// <summary>
        /// Save the graph in the database.
        /// </summary>
        /// <param name="mapMatrix">The adjacency matrix representation of the graph.</param>
        /// <param name="graphForm">The graph editing form used.</param>
        private void SaveGraphToDatabase(AdjacencyMatrix mapMatrix, string graphForm)
        {
            string fields = "(";
            for (int i = 0; i < 26; i++)
                for (int j = 0; j < 26; j++)
                    fields += "Edge" + Convert.ToChar('A' + i).ToString() + Convert.ToChar('A' + j).ToString() + ", ";
            for (int i = 0; i < 26; i++)
                fields += "Vertex" + Convert.ToChar('A' + i).ToString() + ", ";
            fields += "GraphID)";

            // Cross-table parameterised SQL (Group A) is implemented here.
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();

                // Update table GRAPHS
                if (isNewTask)
                    sql = "INSERT INTO GRAPHS (GraphFormat) VALUES (@GraphFormat);";
                else
                    sql = "UPDATE GRAPHS "
                        + "SET GraphFormat = @GraphFormat "
                        + "WHERE GraphID = @graphID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.AddRange(new SQLiteParameter[]
                    {
                        new SQLiteParameter("@GraphFormat",DbType.String) { Value = graphForm },
                        new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID }
                    });
                    command.ExecuteNonQuery();
                }

                // Get the GraphID of the graph if a new task is saved
                if (isNewTask)
                {
                    // Aggregate SQL function (Group A) implemented here
                    sql = "SELECT GraphID FROM GRAPHS "
                        + "WHERE rowid = last_insert_rowid();";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            graphID = Convert.ToInt32(reader["GraphID"]);
                        }
                    }
                }

                // Update table ADJACENCYMATRICES
                if (isNewTask)
                {
                    sql = "INSERT INTO ADJACENCYMATRICES " + fields + " VALUES (";
                    for (int i = 0; i < 26; i++)
                        for (int j = 0; j < 26; j++)
                            sql += mapMatrix.GetEdge(i, j).ToString() + ", ";
                    for (int i = 0; i < 26; i++)
                        sql += (mapMatrix.IsVertexExisting(i) ? "1, " : "0, ");
                    sql += graphID.ToString() + ");";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    sql = "UPDATE ADJACENCYMATRICES SET ";
                    for (int i = 0; i < 26; i++)
                        for (int j = 0; j < 26; j++)
                            sql += "Edge" + Convert.ToChar('A' + i).ToString() + Convert.ToChar('A' + j).ToString() + " = "
                                + mapMatrix.GetEdge(i, j).ToString() + ", ";
                    for (int i = 0; i < 26; i++)
                        sql += "Vertex" + Convert.ToChar('A' + i).ToString() + " = "
                            + (mapMatrix.IsVertexExisting(i) ? "1, " : "0, ");
                    sql = sql.TrimEnd(", ".ToCharArray());
                    sql += " WHERE GraphID = @GraphID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                        command.ExecuteNonQuery();
                    }
                }

                // Save the image if Sketch Board is used to create the graph
                string imageFileName = textBoxQuestionName.Text + ".png";
                if (graphForm == "SketchBoard")
                {
                    using (Image image = pictureBoxGraph.Image)
                    {
                        image.Save(imageFileName, ImageFormat.Png);
                    }
                }

                // Delete the previous image file (if any), if a existing task is edited
                if (!isNewTask)
                {
                    sql = "SELECT ImageFileName FROM GRAPHIMAGES "
                        + "WHERE GraphID = @GraphID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string imageToDelete = reader["ImageFileName"].ToString();
                                if (imageToDelete != imageFileName)
                                {
                                    File.Delete(imageToDelete);
                                }
                            }
                        }
                    }

                    sql = "DELETE FROM GRAPHIMAGES "
                        + "WHERE GraphID = @GraphID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                        command.ExecuteNonQuery();
                    }
                }

                // Update table GRAPHIMAGES if Sketch Board is used to create the graph
                if (graphForm == "SketchBoard")
                {
                    sql = "INSERT INTO GRAPHIMAGES (ImageFileName, GraphID) "
                    + "VALUES (@ImageFileName, @GraphID);";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.AddRange(new SQLiteParameter[]
                        {
                            new SQLiteParameter("@ImageFileName", DbType.String) { Value = imageFileName },
                            new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID }
                        });
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Saves the question in the database.
        /// </summary>
        private void SaveQuestionToDatabase()
        {
            // Cross-table parameterised SQL (Group A) is implemented here.
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();

                // Save the question information
                // Aggregate SQL function (Group A) implemented here
                if (isNewTask)
                    sql = "INSERT INTO QUESTIONBANK (QuestionName, DateModified, ProblemDescription, GraphID) "
                        + "VALUES (@QuestionName, datetime(), @ProblemDescription, @GraphID);";
                else
                    sql = "UPDATE QUESTIONBANK "
                        + "SET QuestionName = @QuestionName, "
                        + "    DateModified = datetime(), "
                        + "    ProblemDescription = @ProblemDescription "
                        + "WHERE QuestionID = @QuestionID;"; 
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.AddRange(new SQLiteParameter[]
                    {
                        new SQLiteParameter("@QuestionName", DbType.String) { Value = textBoxQuestionName.Text },
                        new SQLiteParameter("@ProblemDescription", DbType.String) { Value = textBoxProblemDescription.Text },
                        new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID },
                        new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID }
                    });
                    command.ExecuteNonQuery();
                }

                // Retrieve the question ID if a new task is added to the database
                if (isNewTask)
                {
                    // Aggregate SQL function (Group A) implemented here
                    sql = "SELECT QuestionID FROM QUESTIONBANK "
                        + "WHERE rowid = last_insert_rowid();";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            questionID = Convert.ToInt32(reader["QuestionID"]);
                        }
                    }
                }
            }
        }

        private bool ValidateTasks(AdjacencyMatrix mapMatrix)
        {
            bool validation = true;

            // Validation for graph
            if (dataGridViewGraph.Visible == false && pictureBoxGraph.Visible == false)
            {
                MessageBox.Show("Please enter a graph!");
                validation = false;
                return validation;
            }

            for (int i = 0; i < taskControls.Count; i++)
            {
                // Validation for empty tasks
                if (taskControls[i].GetCurrentTaskText() == "")
                {
                    for (int j = i; j < taskControls.Count - 1; j++)
                    {
                        taskControls[j].GetComboBoxTask().Text = taskControls[j + 1].GetComboBoxTask().Text;
                        taskControls[j].GetLabelStartingVertex().Visible = taskControls[j + 1].GetComboBoxStartingVertex().Visible;
                        taskControls[j].GetComboBoxStartingVertex().Visible = taskControls[j + 1].GetComboBoxStartingVertex().Visible;
                        taskControls[j].GetLabelFinishingVertex().Visible = taskControls[j + 1].GetComboBoxFinishingVertex().Visible;
                        taskControls[j].GetComboBoxFinishingVertex().Visible = taskControls[j + 1].GetComboBoxFinishingVertex().Visible;
                        if (taskControls[j + 1].GetComboBoxStartingVertex().Visible)
                            taskControls[j].GetComboBoxStartingVertex().Text = taskControls[j + 1].GetComboBoxStartingVertex().Text;
                        if (taskControls[j + 1].GetComboBoxFinishingVertex().Visible)
                            taskControls[j].GetComboBoxFinishingVertex().Text = taskControls[j + 1].GetComboBoxFinishingVertex().Text;
                    }
                    taskControls[taskControls.Count - 1].GetLabelTaskIndex().Dispose();
                    taskControls[taskControls.Count - 1].GetComboBoxTask().Dispose();
                    taskControls[taskControls.Count - 1].GetButtonRemoveTask().Dispose();
                    taskControls[taskControls.Count - 1].GetLabelStartingVertex().Dispose();
                    taskControls[taskControls.Count - 1].GetComboBoxStartingVertex().Dispose();
                    taskControls[taskControls.Count - 1].GetLabelFinishingVertex().Dispose();
                    taskControls[taskControls.Count - 1].GetComboBoxFinishingVertex().Dispose();
                    taskControls.RemoveAt(taskControls.Count - 1);
                    if (taskControls.Count == 0)
                    {
                        MessageBox.Show("Please enter at least a task!");
                        validation = false;
                        AddTaskControls();
                        return validation;
                    }
                    else
                    {
                        if (taskControls.Count == 1)
                            taskControls[0].GetButtonRemoveTask().Enabled = false;
                        i--;
                        continue;
                    }
                }
            }

            for (int i = 0; i < taskControls.Count; i++)
            {
                // Validation for repeated tasks
                for (int j = 0; j < i; j++)
                    if (taskControls[i].GetCurrentTaskText() == taskControls[j].GetCurrentTaskText())
                    {
                        if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"]
                            && (taskControls[i].GetComboBoxStartingVertex().Text != taskControls[j].GetComboBoxStartingVertex().Text
                                || taskControls[i].GetComboBoxFinishingVertex().Text != taskControls[j].GetComboBoxFinishingVertex().Text))
                            continue;
                        else if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"]
                            && taskControls[i].GetComboBoxStartingVertex().Text == taskControls[j].GetComboBoxStartingVertex().Text
                            && taskControls[i].GetComboBoxFinishingVertex().Text == taskControls[j].GetComboBoxFinishingVertex().Text)
                        {
                            MessageBox.Show("Repeated task content at Task " + (i + 1).ToString() + "!");
                            taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                            validation = false;
                            break;
                        }
                        else if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Prim"]
                            && taskControls[i].GetComboBoxStartingVertex().Text == taskControls[j].GetComboBoxStartingVertex().Text)
                        {
                            MessageBox.Show("Repeated task content at Task " + (i + 1).ToString() + "!");
                            taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                            validation = false;
                            break;
                        }
                        else if (taskControls[i].GetCurrentTaskText() != taskControls[i].tasks["Prim"]
                            && taskControls[i].GetCurrentTaskText() != taskControls[i].tasks["Dijkstra"])
                        {
                            MessageBox.Show("Repeated task content at Task " + (i + 1).ToString() + "!");
                            taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                            validation = false;
                            break;
                        }
                    }

                // Validation for improper task: Finding Minimum Spanning Tree for a directed graph
                if (!mapMatrix.CheckUndirectedGraph()
                    && (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Prim"] || taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Kruskal"]))
                {
                    MessageBox.Show("Task " + (i + 1).ToString() + " is improper:\nCannot find a Minimum Spanning Tree for a directed graph!");
                    taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                    validation = false;
                }

                // Validation for improper task the input vertex is empty
                if ((taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Prim"] || taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"])
                    && taskControls[i].GetComboBoxStartingVertex().Text == "")
                {
                    MessageBox.Show("Task " + (i + 1).ToString() + " is improper:\nStarting vertex is empty!");
                    taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                    taskControls[i].GetLabelStartingVertex().ForeColor = Color.Red;
                    validation = false;
                }

                if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"] && taskControls[i].GetComboBoxFinishingVertex().Text == "")
                {
                    MessageBox.Show("Task " + (i + 1).ToString() + " is improper:\nFinishing vertex is empty!");
                    taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                    taskControls[i].GetLabelFinishingVertex().ForeColor = Color.Red;
                    validation = false;
                }

                // Validation for improper task: the vertex does not exist in the graph
                if ((taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Prim"] || taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"])
                    && taskControls[i].GetComboBoxStartingVertex().Text != ""
                    && !mapMatrix.IsVertexExisting(mapMatrix.GetVertexIndex(taskControls[i].GetComboBoxStartingVertex().Text)))
                {
                    MessageBox.Show("Task " + (i + 1).ToString() + " is improper:\nStarting vertex does not exist in the graph!");
                    taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                    taskControls[i].GetLabelStartingVertex().ForeColor = Color.Red;
                    validation = false;
                }

                if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"]
                    && taskControls[i].GetComboBoxFinishingVertex().Text != ""
                    && !mapMatrix.IsVertexExisting(mapMatrix.GetVertexIndex(taskControls[i].GetComboBoxFinishingVertex().Text)))
                {
                    MessageBox.Show("Task " + (i + 1).ToString() + " is improper:\nFinishing vertex does not exist in the graph!");
                    taskControls[i].GetLabelTaskIndex().ForeColor = Color.Red;
                    taskControls[i].GetLabelFinishingVertex().ForeColor = Color.Red;
                    validation = false;
                }
            }

            return validation;
        }

        /// <summary>
        /// Saves the subtasks in the database.
        /// </summary>
        /// <param name="mapMatrix">The adjacency matrix representation of the graph.</param>
        private void SaveTasksToDatabase(AdjacencyMatrix mapMatrix)
        {
            if (ValidateTasks(mapMatrix))
            {
                // If this is a previous problem edited
                if (!isNewTask)
                {
                    using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                    {
                        // Delete all previous subtasks
                        database.Open();
                        sql = "DELETE FROM TASKS "
                        + "WHERE QuestionID = @QuestionID;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, database))
                        {
                            command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                            command.ExecuteNonQuery();
                        }
                    }
                }

                for (int i = 0; i < taskControls.Count; i++)
                {
                    taskControls[i].GetLabelTaskIndex().ForeColor = SystemColors.ControlText;
                    taskControls[i].GetLabelStartingVertex().ForeColor = SystemColors.ControlText;
                    taskControls[i].GetLabelFinishingVertex().ForeColor = SystemColors.ControlText;

                    // Cross-table parameterised SQL (Group A) is implemented here.
                    using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                    {
                        database.Open();

                        if (taskControls[i].GetCurrentTaskText() != "")
                        {
                            // Save the subtask information in the database
                            if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Dijkstra"])
                            {                                
                                sql = "INSERT INTO TASKS (TaskDescription, StartingVertex, FinishingVertex, QuestionID, AnswerValue) "
                                    + "VALUES (@TaskDescription, @StartingVertex, @FinishingVertex, @QuestionID, @AnswerValue);";
                                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                                {
                                    command.Parameters.AddRange(new SQLiteParameter[]
                                    {
                                        new SQLiteParameter("@TaskDescription", DbType.String) { Value = taskControls[i].GetCurrentTaskText() },
                                        new SQLiteParameter("@StartingVertex", DbType.String) { Value = taskControls[i].GetComboBoxStartingVertex().Text },
                                        new SQLiteParameter("@FinishingVertex", DbType.String) { Value = taskControls[i].GetComboBoxFinishingVertex().Text },
                                        new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID },
                                        new SQLiteParameter("@AnswerValue", DbType.String) { Value = mapMatrix.Dijkstra(mapMatrix.GetVertexIndex(taskControls[i].GetComboBoxStartingVertex().Text), mapMatrix.GetVertexIndex(taskControls[i].GetComboBoxFinishingVertex().Text)).ToString() }
                                    });
                                    command.ExecuteNonQuery();
                                }
                            }
                            else if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Prim"])
                            {
                                sql = "INSERT INTO TASKS (TaskDescription, StartingVertex, QuestionID, AnswerValue) "
                                    + "VALUES (@TaskDescription, @StartingVertex, @QuestionID, @AnswerValue);";
                                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                                {
                                    command.Parameters.AddRange(new SQLiteParameter[]
                                    {
                                        new SQLiteParameter("@TaskDescription", DbType.String) { Value = taskControls[i].GetCurrentTaskText() },
                                        new SQLiteParameter("@StartingVertex", DbType.String) { Value = taskControls[i].GetComboBoxStartingVertex().Text },
                                        new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID },
                                        new SQLiteParameter("@AnswerValue", DbType.String) { Value = mapMatrix.Prim(mapMatrix.GetVertexIndex(taskControls[i].GetComboBoxStartingVertex().Text)).ToString()}
                                    });
                                    command.ExecuteNonQuery();
                                }
                            }
                            else if (taskControls[i].GetCurrentTaskText() == taskControls[i].tasks["Kruskal"])
                            {
                                sql = "INSERT INTO TASKS (TaskDescription, QuestionID, AnswerValue) "
                                    + "VALUES (@TaskDescription, @QuestionID, @AnswerValue);";
                                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                                {
                                    command.Parameters.AddRange(new SQLiteParameter[]
                                    {
                                        new SQLiteParameter("@TaskDescription", DbType.String) { Value = taskControls[i].GetCurrentTaskText() },
                                        new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID },
                                        new SQLiteParameter("@AnswerValue", DbType.String) { Value = mapMatrix.Kruskal().ToString() }
                                    });
                                    command.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                sql = "INSERT INTO TASKS (TaskDescription, QuestionID, GraphID)"
                                    + "VALUES (@TaskDescription, @QuestionID, @GraphID);";
                                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                                {
                                    command.Parameters.AddRange(new SQLiteParameter[]
                                    {
                                        new SQLiteParameter("@TaskDescription", DbType.String) { Value = taskControls[i].GetCurrentTaskText() },
                                        new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID },
                                        new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID }
                                    });
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Events for graph editing forms
        private void ButtonMatrix_Click(object sender, EventArgs e)
        {
            formEditAdjacencyMatrix = new FormEditAdjacencyMatrix(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType);
            if (this.dataGridViewGraph.Visible)
            {
                if (this.dataGridViewGraph.Columns[1].Name == "ColumnAdjacentEdges")
                {
                    for (int row = 0; row < this.dataGridViewGraph.RowCount; row++)
                    {
                        int rowIndex = Convert.ToChar(this.dataGridViewGraph[0, row].Value) - 'A';
                        if (this.dataGridViewGraph[1, row].Value != null)
                        {
                            string adjacentEdges = this.dataGridViewGraph[1, row].Value.ToString();
                            byte[] adjacentEdgesBytes = Encoding.ASCII.GetBytes(adjacentEdges.Replace(",", "\n"));
                            MemoryStream adjacentEdgesStream = new MemoryStream(adjacentEdgesBytes);
                            using (StreamReader reader = new StreamReader(adjacentEdgesStream))
                            {
                                string newValue;
                                string columnName;
                                while ((newValue = reader.ReadLine()) != null)
                                {
                                    columnName = "Column" + newValue;
                                    newValue = reader.ReadLine();
                                    formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix[columnName, rowIndex].Value = newValue;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int col = 1; col < this.dataGridViewGraph.ColumnCount; col++)
                        for (int row = 0; row < this.dataGridViewGraph.RowCount; row++)
                        {
                            string columnName = this.dataGridViewGraph.Columns[col].Name;
                            int rowIndex = Convert.ToChar(this.dataGridViewGraph[0, row].Value) - 'A';
                            if (this.dataGridViewGraph[col, row].Value.ToString() != "0")
                                formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix[columnName, rowIndex].Value = this.dataGridViewGraph[columnName, row].Value.ToString();
                        }
                }
            }
            else if (this.pictureBoxGraph.Visible)
            {
                for (int vStart = 0; vStart < taskMatrix.GetSize(); vStart++)
                    for (int vFinish = 0; vFinish < taskMatrix.GetSize(); vFinish++)
                        if (taskMatrix.ContainsEdge(vStart, vFinish))
                            formEditAdjacencyMatrix.dataGridViewAdjacencyMatrix[vFinish + 1, vStart].Value = taskMatrix.GetEdge(vStart, vFinish);
            }
            formEditAdjacencyMatrix.submitSuccessful = false;
            formEditAdjacencyMatrix.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
            formEditAdjacencyMatrix.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
            formEditAdjacencyMatrix.Show();
            this.Enabled = false;
            this.Hide();
        }

        private void ButtonList_Click(object sender, EventArgs e)
        {
            formEditAdjacencyList = new FormEditAdjacencyList(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType);
            if (this.dataGridViewGraph.Visible)
            {
                if (this.dataGridViewGraph.Columns[1].Name == "ColumnAdjacentEdges")
                {
                    for (int row = 0; row < this.dataGridViewGraph.RowCount; row++)
                    {
                        int rowIndex = Convert.ToChar(this.dataGridViewGraph[0, row].Value) - 'A';
                        formEditAdjacencyList.dataGridViewAdjacencyList[1, rowIndex].Value = this.dataGridViewGraph[1, row].Value.ToString();
                    }
                }
                else
                {
                    for (int row = 0; row < this.dataGridViewGraph.RowCount; row++)
                    {
                        string adjacentEdges = "";
                        int rowIndex = Convert.ToChar(this.dataGridViewGraph[0, row].Value) - 'A';
                        for (int col = 1; col < this.dataGridViewGraph.ColumnCount; col++)
                            if (this.dataGridViewGraph[col, row].Value.ToString() != "0")
                                adjacentEdges += this.dataGridViewGraph.Columns[col].HeaderText + "," + this.dataGridViewGraph[col, row].Value.ToString() + ",";
                        adjacentEdges = adjacentEdges.TrimEnd(',');
                        formEditAdjacencyList.dataGridViewAdjacencyList[1, rowIndex].Value = adjacentEdges;
                    }
                }
            }
            else if (this.pictureBoxGraph.Visible)
            {
                for (int vStart = 0; vStart < taskMatrix.GetSize(); vStart++)
                {
                    string adjacentEdges = "";
                    for (int vFinish = 0; vFinish < taskMatrix.GetSize(); vFinish++)
                        if (taskMatrix.ContainsEdge(vStart, vFinish))
                            adjacentEdges += taskMatrix.GetVertexName(vFinish).Substring(6) + "," + taskMatrix.GetEdge(vStart, vFinish) + ",";
                    adjacentEdges = adjacentEdges.TrimEnd(',');
                    formEditAdjacencyList.dataGridViewAdjacencyList[1, vStart].Value = adjacentEdges;
                }
            }
            formEditAdjacencyList.submitSuccessful = false;
            formEditAdjacencyList.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
            formEditAdjacencyList.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
            formEditAdjacencyList.Show();
            this.Enabled = false;
            this.Hide();
        }

        private void ButtonSketchBoard_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formSketchBoard = new FormSketchBoard(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType);
            formSketchBoard.buttonSubmit.Click += new System.EventHandler(this.GraphEditingForms_buttonSubmit_Click);
            formSketchBoard.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphEditingForms_FormClosed);
            formSketchBoard.Show();
        }

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
                edited = true;
                buttonSave.Enabled = true;
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
                edited = true;
                buttonSave.Enabled = true;
                if ((sender as Form).Name == "FormSketchBoard")
                {
                    taskMatrix = ((FormSketchBoard)(sender as Form)).GetMatrix();
                    sketchBoardTopLeft = ((FormSketchBoard)(sender as Form)).topLeft;
                    sketchBoardBottomRight = ((FormSketchBoard)(sender as Form)).bottomRight;
                    sketchBoardFormLocation = ((FormSketchBoard)(sender as Form)).Location;
                    graphEditingFormName = "SketchBoard";
                }
                else if ((sender as Form).Name == "FormEditAdjacencyMatrix")
                {
                    taskMatrix = ((FormEditAdjacencyMatrix)(sender as Form)).GetMatrix();
                    graphEditingFormName = "AdjacencyMatrix";
                }
                else if ((sender as Form).Name == "FormEditAdjacencyList")
                {
                    taskMatrix = ((FormEditAdjacencyList)(sender as Form)).GetMatrix();
                    graphEditingFormName = "AdjacencyList";
                }

                SaveGraph(taskMatrix, graphEditingFormName);
            }
            this.Enabled = true;
            this.Show();
        }
        #endregion

        #region Events for editing tasks
        private void ButtonAddTask_Click(object sender, EventArgs e)
        {
            AddTaskControls();
        }

        private void ButtonRemoveTask_Click(object sender, EventArgs e)
        {
            edited = true;
            buttonSave.Enabled = true;
            string buttonName = (sender as Button).Name;
            int index = Convert.ToInt32(buttonName.Trim("buttonRemoveTask".ToCharArray()));
            for (int i = index - 1; i < taskControls.Count - 1; i++)
            {
                taskControls[i].GetComboBoxTask().Text = taskControls[i + 1].GetComboBoxTask().Text;
                if (taskControls[i + 1].GetComboBoxStartingVertex().Visible)
                {
                    taskControls[i].GetLabelStartingVertex().Visible = true;
                    taskControls[i].GetComboBoxStartingVertex().Visible = true;
                    taskControls[i].GetComboBoxStartingVertex().Text = taskControls[i + 1].GetComboBoxStartingVertex().Text;
                }
                if (taskControls[i + 1].GetComboBoxFinishingVertex().Visible)
                {
                    taskControls[i].GetLabelFinishingVertex().Visible = true;
                    taskControls[i].GetComboBoxFinishingVertex().Visible = true;
                    taskControls[i].GetComboBoxFinishingVertex().Text = taskControls[i + 1].GetComboBoxFinishingVertex().Text;
                }
            }
            taskControls[taskControls.Count - 1].GetLabelTaskIndex().Dispose();
            taskControls[taskControls.Count - 1].GetComboBoxTask().Dispose();
            taskControls[taskControls.Count - 1].GetButtonRemoveTask().Dispose();
            taskControls[taskControls.Count - 1].GetLabelStartingVertex().Dispose();
            taskControls[taskControls.Count - 1].GetComboBoxStartingVertex().Dispose();
            taskControls[taskControls.Count - 1].GetLabelFinishingVertex().Dispose();
            taskControls[taskControls.Count - 1].GetComboBoxFinishingVertex().Dispose();
            taskControls.RemoveAt(taskControls.Count - 1);
            if (taskControls.Count == 1)
                taskControls[0].GetButtonRemoveTask().Enabled = false;
        }

        private void TextBoxQuestionName_TextChanged(object sender, EventArgs e)
        {
            edited = true;
            buttonSave.Enabled = true;
        }

        private void TextBoxProblemDescription_TextChanged(object sender, EventArgs e)
        {
            edited = true;
            buttonSave.Enabled = true;
        }

        private void TaskControlsComboBoxes_TextChanged(object sender, EventArgs e)
        {
            edited = true;
            buttonSave.Enabled = true;
        }
        #endregion

        #region Events for editing tasks from Question Bank
        private void LabelGraphID_TextChanged(object sender, EventArgs e)
        {
            if (!isNewTask)
                graphID = Convert.ToInt32(labelGraphID.Text);
        }

        private void LabelQuestionID_TextChanged(object sender, EventArgs e)
        {
            if (!isNewTask)
                questionID = Convert.ToInt32(labelQuestionID.Text);
        }
        #endregion

        #region Events for submission
        private void FormTaskSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (edited && !saved)
            {
                using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                {
                    database.Open();

                    DialogResult saveGraphResult = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo);
                    if (saveGraphResult == DialogResult.Yes)
                    {
                        if (ValidateTasks(taskMatrix))
                        {
                            if (textBoxQuestionName.Text == "") // Add default problem name if user did not enter a name
                                textBoxQuestionName.Text = "New Question " + DateTime.Now.ToString("dd-MM-yyyy HH.mm");
                            if (graphEditingFormName == null && !isNewTask)
                            {
                                if (pictureBoxGraph.Visible)
                                    graphEditingFormName = "SketchBoard";
                                else if(dataGridViewGraph.Columns[0].HeaderText == "Vertex")
                                    graphEditingFormName = "AdjacencyList";
                                else
                                    graphEditingFormName = "AdjacencyMatrix";
                            }
                            SaveGraphToDatabase(taskMatrix, graphEditingFormName);
                            SaveQuestionToDatabase();
                            SaveTasksToDatabase(taskMatrix);
                            saved = true;
                        }
                    }
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                {
                    database.Open();

                    DialogResult saveGraphResult = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo);
                    if (saveGraphResult == DialogResult.Yes)
                    {
                        if (ValidateTasks(taskMatrix))
                        {
                            if (textBoxQuestionName.Text == "") // Add default problem name if user did not enter a name
                                textBoxQuestionName.Text = "New Question " + DateTime.Now.ToString("dd-MM-yyyy HH.mm");
                            if (graphEditingFormName == null && !isNewTask)
                            {
                                if (pictureBoxGraph.Visible)
                                    graphEditingFormName = "SketchBoard";
                                else if (dataGridViewGraph.Columns[0].HeaderText == "Vertex")
                                    graphEditingFormName = "AdjacencyList";
                                else
                                    graphEditingFormName = "AdjacencyMatrix";
                            }
                            SaveGraphToDatabase(taskMatrix, graphEditingFormName);
                            SaveQuestionToDatabase();
                            SaveTasksToDatabase(taskMatrix);
                            saved = true;
                            this.Close();
                        }
                    }
                }
            }
            else if (!isNewTask)
            {
                this.Close();
            }
        }
        #endregion

    }
}
