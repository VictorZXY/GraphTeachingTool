using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormQuestionBank : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// The SQLite commands.
        /// </summary>
        string sql;

        // External windows to be opened when requested
        FormTaskSetting formTaskSetting;
        FormDoQuestion formDoQuestion;
        #endregion

        #region Constructor
        public FormQuestionBank(int accountID, string username, string accountName, string accountType)
        {
            InitializeComponent();

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;

            // Decide account access authority.
            if (accountType == "STUDENT")
            {
                this.buttonAddQuestion.Enabled = false;
                this.buttonDeleteQuestion.Enabled = false;
                this.buttonEditQuestion.Enabled = false;
            }
            else if (accountType == "TEACHER")
            {
                this.buttonAddQuestion.Enabled = true;
                this.buttonDeleteQuestion.Enabled = true;
                this.buttonEditQuestion.Enabled = true;
            }

            // Read from the database and display the questions.
            ResetDataGridViewQuestions();
        }
        #endregion

        #region Operation Functions
        private void ResetDataGridViewQuestions()
        {
            dataGridViewQuestions.Rows.Clear();
            // Show all the questions in the database
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();
                sql = "SELECT QuestionID, DateModified, QuestionName FROM QUESTIONBANK;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            dataGridViewQuestions.Rows.Add();
                            dataGridViewQuestions["ColumnQuestionID", count].Value = reader["QuestionID"].ToString();
                            dataGridViewQuestions["ColumnDateModified", count].Value = reader["DateModified"].ToString();
                            dataGridViewQuestions["ColumnQuestionName", count].Value = reader["QuestionName"].ToString();
                            count++;
                        }
                    }
                }
            }
        }

        private void EditQuestion(string questionID)
        {
            int accountID = this.accountMenu.accountID;
            string userName = this.accountMenu.username;
            string accountName = this.accountMenu.labelAccountName.Text;
            formTaskSetting = new FormTaskSetting(accountID, userName, accountName, false);
            formTaskSetting.labelQuestionID.Text = questionID;
            formTaskSetting.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);

            // Cross-table parameterised SQL (Group A) is implemented here.
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();

                int graphID;
                string graphFormat;

                // Query and show general information and the graph of the question
                sql = "SELECT QuestionName, ProblemDescription, GraphID FROM QUESTIONBANK "
                    + "WHERE QuestionID = @questionID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        formTaskSetting.textBoxQuestionName.Text = reader["QuestionName"].ToString();
                        formTaskSetting.textBoxProblemDescription.Text = reader["ProblemDescription"].ToString();
                        graphID = Convert.ToInt32(reader["GraphID"]);
                        formTaskSetting.labelGraphID.Text = graphID.ToString();
                    }
                }

                // Query the correct representation for the graph
                sql = "SELECT GraphFormat FROM GRAPHS "
                    + "WHERE GraphID = @GraphID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        graphFormat = reader["GraphFormat"].ToString();
                    }
                }

                // Query the graph in the form of an adjacency matrix
                sql = "SELECT * FROM ADJACENCYMATRICES "
                    + "WHERE GraphID = @GraphID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        formTaskSetting.taskMatrix = new AdjacencyMatrix();
                        for (int v1 = 0; v1 < formTaskSetting.taskMatrix.GetSize(); v1++)
                            for (int v2 = 0; v2 < formTaskSetting.taskMatrix.GetSize(); v2++)
                            {
                                string fieldName = "Edge"
                                    + formTaskSetting.taskMatrix.GetVertexName(v1).Trim("vertex".ToCharArray())
                                    + formTaskSetting.taskMatrix.GetVertexName(v2).Trim("vertex".ToCharArray());
                                formTaskSetting.taskMatrix.SetDirectedEdge(v1, v2, Convert.ToDouble(reader[fieldName]));
                            }
                    }
                }

                // Show the graph on the window
                if (graphFormat == "AdjacencyMatrix")
                {
                    formTaskSetting.pictureBoxGraph.Visible = false;
                    formTaskSetting.dataGridViewGraph.Visible = true;

                    formTaskSetting.dataGridViewGraph.Columns.Clear();
                    DataGridViewColumn newColumn = new DataGridViewColumn
                    {
                        CellTemplate = new DataGridViewTextBoxCell(),
                        SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                        Width = 41
                    };
                    formTaskSetting.dataGridViewGraph.Columns.Add(newColumn);

                    int count = 1;
                    for (int i = 0; i < formTaskSetting.taskMatrix.GetSize(); i++)
                        if (formTaskSetting.taskMatrix.IsVertexExisting(i))
                        {
                            newColumn = new DataGridViewColumn
                            {
                                CellTemplate = new DataGridViewTextBoxCell(),
                                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                            };
                            formTaskSetting.dataGridViewGraph.Columns.Add(newColumn);
                            formTaskSetting.dataGridViewGraph.Columns[count].HeaderText = Convert.ToChar('A' + i).ToString();
                            formTaskSetting.dataGridViewGraph.Columns[count].Name = "Column" + formTaskSetting.dataGridViewGraph.Columns[count].HeaderText;
                            count++;
                        }

                    count = 0;
                    formTaskSetting.dataGridViewGraph.RowCount = formTaskSetting.taskMatrix.Count();
                    for (int i = 0; i < formTaskSetting.taskMatrix.GetSize(); i++)
                        if (formTaskSetting.taskMatrix.IsVertexExisting(i))
                            formTaskSetting.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                    for (int col = 1; col <= formTaskSetting.taskMatrix.Count(); col++)
                        for (int row = 0; row < formTaskSetting.taskMatrix.Count(); row++)
                        {
                            int vStartIndex = formTaskSetting.taskMatrix.GetVertexIndex(formTaskSetting.dataGridViewGraph.Columns[col].HeaderText);
                            int vFinishIndex = formTaskSetting.taskMatrix.GetVertexIndex(formTaskSetting.dataGridViewGraph[0, row].Value.ToString());
                            formTaskSetting.dataGridViewGraph[col, row].Value = formTaskSetting.taskMatrix.GetEdge(vStartIndex, vFinishIndex);
                        }

                }
                else if (graphFormat == "AdjacencyList")
                {
                    formTaskSetting.pictureBoxGraph.Visible = false;
                    formTaskSetting.dataGridViewGraph.Visible = true;

                    formTaskSetting.dataGridViewGraph.ColumnCount = 2;
                    formTaskSetting.dataGridViewGraph.Columns[0].HeaderText = "Vertex";
                    formTaskSetting.dataGridViewGraph.Columns[0].Name = "ColumnVertex";
                    formTaskSetting.dataGridViewGraph.Columns[0].Width = 100;
                    formTaskSetting.dataGridViewGraph.Columns[1].HeaderText = "Adjacent Edges";
                    formTaskSetting.dataGridViewGraph.Columns[1].Name = "ColumnAdjacentEdges";
                    formTaskSetting.dataGridViewGraph.Columns[1].Width = formTaskSetting.dataGridViewGraph.Width - 103;

                    int count = 0;
                    formTaskSetting.dataGridViewGraph.RowCount = formTaskSetting.taskMatrix.Count();
                    for (int i = 0; i < formTaskSetting.taskMatrix.GetSize(); i++)
                        if (formTaskSetting.taskMatrix.IsVertexExisting(i))
                            formTaskSetting.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                    for (int vStart = 0; vStart < formTaskSetting.taskMatrix.Count(); vStart++)
                    {
                        formTaskSetting.dataGridViewGraph[1, vStart].Value = "";
                        for (int vFinish = 0; vFinish < formTaskSetting.taskMatrix.Count(); vFinish++)
                        {
                            int vStartIndex = formTaskSetting.taskMatrix.GetVertexIndex(formTaskSetting.dataGridViewGraph[0, vStart].Value.ToString());
                            int vFinishIndex = formTaskSetting.taskMatrix.GetVertexIndex(formTaskSetting.dataGridViewGraph[0, vFinish].Value.ToString());
                            if (formTaskSetting.taskMatrix.ContainsEdge(vStartIndex, vFinishIndex))
                            {
                                formTaskSetting.dataGridViewGraph[1, vStart].Value = formTaskSetting.dataGridViewGraph[1, vStart].Value.ToString() + ","
                                    + Convert.ToChar('A' + vFinishIndex).ToString() + ","
                                    + formTaskSetting.taskMatrix.GetEdge(vStartIndex, vFinishIndex);
                            }
                        }
                        if (formTaskSetting.dataGridViewGraph[1, vStart].Value.ToString() != "")
                            formTaskSetting.dataGridViewGraph[1, vStart].Value = formTaskSetting.dataGridViewGraph[1, vStart].Value.ToString().Remove(0, 1);
                    }
                }
                else // if (graphFormat == "SketchBoard")
                {
                    formTaskSetting.pictureBoxGraph.Visible = true;
                    formTaskSetting.dataGridViewGraph.Visible = false;

                    sql = "SELECT ImageFileName FROM GRAPHIMAGES "
                        + "WHERE GraphID = @GraphID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            string imageFileName = reader["ImageFileName"].ToString();
                            try
                            {
                                Bitmap image;
                                using (Image imageFile = Image.FromFile(imageFileName, true))
                                {
                                    image = new Bitmap(imageFile);
                                    formTaskSetting.pictureBoxGraph.Image = image;
                                }
                            }
                            catch (System.IO.FileNotFoundException)
                            {
                                MessageBox.Show("Error opening the image!\n");
                            }
                        }
                    }
                }

                // Query and show the subtasks
                sql = "SELECT TaskDescription, StartingVertex, FinishingVertex FROM TASKS "
                    + "WHERE QuestionID = @QuestionID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        while(reader.Read())
                        {
                            if (count != 0)
                                formTaskSetting.AddTaskControls();
                            int index = count;
                            formTaskSetting.taskControls[index].GetComboBoxTask().Text = reader["TaskDescription"].ToString();
                            formTaskSetting.taskControls[index].GetComboBoxStartingVertex().Text = reader["StartingVertex"].ToString();
                            formTaskSetting.taskControls[index].GetComboBoxFinishingVertex().Text = reader["FinishingVertex"].ToString();
                            count++;
                        }
                    }
                }
            }
            formTaskSetting.edited = false;
            formTaskSetting.saved = false;
            formTaskSetting.Show();
            this.Enabled = false;
            this.Hide();
        }

        private void DoQuestion(string questionID)
        {
            int accountID = this.accountMenu.accountID;
            string userName = this.accountMenu.username;
            string accountName = this.accountMenu.labelAccountName.Text;
            string accountType = this.accountMenu.accountType;
            formDoQuestion = new FormDoQuestion(accountID, userName, accountName, accountType);
            formDoQuestion.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);

            // Cross-table parameterised SQL (Group A) is implemented here.
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();

                int graphID;
                string graphFormat;

                // Query and show general information and the graph of the question
                sql = "SELECT QuestionName, ProblemDescription, GraphID FROM QUESTIONBANK "
                    + "WHERE QuestionID = @QuestionID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        formDoQuestion.labelQuestionName.Text = reader["QuestionName"].ToString();
                        formDoQuestion.labelProblemDescription.Text = reader["ProblemDescription"].ToString();
                        graphID = Convert.ToInt32(reader["GraphID"]);
                    }
                }

                // Query the correct representation for the graph
                sql = "SELECT graphFormat FROM GRAPHS "
                    + "WHERE GraphID = @GraphID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        graphFormat = reader["GraphFormat"].ToString();
                    }
                }

                // Query the graph in the form of an adjacency matrix
                sql = "SELECT * FROM ADJACENCYMATRICES "
                    + "WHERE GraphID = @GraphID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        formDoQuestion.taskMatrix = new AdjacencyMatrix();
                        for (int v1 = 0; v1 < formDoQuestion.taskMatrix.GetSize(); v1++)
                            for (int v2 = 0; v2 < formDoQuestion.taskMatrix.GetSize(); v2++)
                            {
                                string fieldName = "Edge"
                                    + formDoQuestion.taskMatrix.GetVertexName(v1).Trim("vertex".ToCharArray())
                                    + formDoQuestion.taskMatrix.GetVertexName(v2).Trim("vertex".ToCharArray());
                                formDoQuestion.taskMatrix.SetDirectedEdge(v1, v2, Convert.ToDouble(reader[fieldName]));
                            }
                    }
                }

                // Show the graph on the window
                if (graphFormat == "AdjacencyMatrix")
                {
                    formDoQuestion.pictureBoxGraph.Visible = false;
                    formDoQuestion.dataGridViewGraph.Visible = true;

                    formDoQuestion.dataGridViewGraph.Columns.Clear();
                    DataGridViewColumn newColumn = new DataGridViewColumn
                    {
                        CellTemplate = new DataGridViewTextBoxCell(),
                        SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                        Width = 41
                    };
                    formDoQuestion.dataGridViewGraph.Columns.Add(newColumn);

                    int count = 1;
                    for (int i = 0; i < formDoQuestion.taskMatrix.GetSize(); i++)
                        if (formDoQuestion.taskMatrix.IsVertexExisting(i))
                        {
                            newColumn = new DataGridViewColumn
                            {
                                CellTemplate = new DataGridViewTextBoxCell(),
                                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                            };
                            formDoQuestion.dataGridViewGraph.Columns.Add(newColumn);
                            formDoQuestion.dataGridViewGraph.Columns[count].HeaderText = Convert.ToChar('A' + i).ToString();
                            formDoQuestion.dataGridViewGraph.Columns[count].Name = "Column" + formDoQuestion.dataGridViewGraph.Columns[count].HeaderText;
                            count++;
                        }

                    count = 0;
                    formDoQuestion.dataGridViewGraph.RowCount = formDoQuestion.taskMatrix.Count();
                    for (int i = 0; i < formDoQuestion.taskMatrix.GetSize(); i++)
                        if (formDoQuestion.taskMatrix.IsVertexExisting(i))
                            formDoQuestion.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                    for (int col = 1; col <= formDoQuestion.taskMatrix.Count(); col++)
                        for (int row = 0; row < formDoQuestion.taskMatrix.Count(); row++)
                        {
                            int vStartIndex = formDoQuestion.taskMatrix.GetVertexIndex(formDoQuestion.dataGridViewGraph.Columns[col].HeaderText);
                            int vFinishIndex = formDoQuestion.taskMatrix.GetVertexIndex(formDoQuestion.dataGridViewGraph[0, row].Value.ToString());
                            formDoQuestion.dataGridViewGraph[col, row].Value = formDoQuestion.taskMatrix.GetEdge(vStartIndex, vFinishIndex);
                        }

                }
                else if (graphFormat == "AdjacencyList")
                {
                    formDoQuestion.pictureBoxGraph.Visible = false;
                    formDoQuestion.dataGridViewGraph.Visible = true;

                    formDoQuestion.dataGridViewGraph.ColumnCount = 2;
                    formDoQuestion.dataGridViewGraph.Columns[0].HeaderText = "Vertex";
                    formDoQuestion.dataGridViewGraph.Columns[0].Name = "ColumnVertex";
                    formDoQuestion.dataGridViewGraph.Columns[0].Width = 100;
                    formDoQuestion.dataGridViewGraph.Columns[1].HeaderText = "Adjacent Edges";
                    formDoQuestion.dataGridViewGraph.Columns[1].Name = "ColumnAdjacentEdges";
                    formDoQuestion.dataGridViewGraph.Columns[1].Width = formDoQuestion.dataGridViewGraph.Width - 103;

                    int count = 0;
                    formDoQuestion.dataGridViewGraph.RowCount = formDoQuestion.taskMatrix.Count();
                    for (int i = 0; i < formDoQuestion.taskMatrix.GetSize(); i++)
                        if (formDoQuestion.taskMatrix.IsVertexExisting(i))
                            formDoQuestion.dataGridViewGraph[0, count++].Value = (Convert.ToChar('A' + i)).ToString();

                    for (int vStart = 0; vStart < formDoQuestion.taskMatrix.Count(); vStart++)
                    {
                        formDoQuestion.dataGridViewGraph[1, vStart].Value = "";
                        for (int vFinish = 0; vFinish < formDoQuestion.taskMatrix.Count(); vFinish++)
                        {
                            int vStartIndex = formDoQuestion.taskMatrix.GetVertexIndex(formDoQuestion.dataGridViewGraph[0, vStart].Value.ToString());
                            int vFinishIndex = formDoQuestion.taskMatrix.GetVertexIndex(formDoQuestion.dataGridViewGraph[0, vFinish].Value.ToString());
                            if (formDoQuestion.taskMatrix.ContainsEdge(vStartIndex, vFinishIndex))
                            {
                                formDoQuestion.dataGridViewGraph[1, vStart].Value = formDoQuestion.dataGridViewGraph[1, vStart].Value.ToString() + ","
                                    + Convert.ToChar('A' + vFinishIndex).ToString() + ","
                                    + formDoQuestion.taskMatrix.GetEdge(vStartIndex, vFinishIndex);
                            }
                        }
                        if (formDoQuestion.dataGridViewGraph[1, vStart].Value.ToString() != "")
                            formDoQuestion.dataGridViewGraph[1, vStart].Value = formDoQuestion.dataGridViewGraph[1, vStart].Value.ToString().Remove(0, 1);
                    }
                }
                else // if (graphFormat == "SketchBoard")
                {
                    formDoQuestion.pictureBoxGraph.Visible = true;
                    formDoQuestion.dataGridViewGraph.Visible = false;

                    sql = "SELECT ImageFileName FROM GRAPHIMAGES "
                        + "WHERE GraphID = @GraphID;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, database))
                    {
                        command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            string imageFileName = reader["ImageFileName"].ToString();
                            try
                            {
                                Bitmap image;
                                using (Image imageFile = Image.FromFile(imageFileName, true))
                                {
                                    image = new Bitmap(imageFile);
                                    formDoQuestion.pictureBoxGraph.Image = image;
                                }
                            }
                            catch (System.IO.FileNotFoundException)
                            {
                                MessageBox.Show("Error opening the image!\n");
                            }
                        }
                    }
                }

                // Query and show the subtasks
                sql = "SELECT TaskDescription, StartingVertex, FinishingVertex, AnswerValue FROM TASKS "
                    + "WHERE QuestionID = @QuestionID;";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            formDoQuestion.AddTaskControls();
                            int index = count;
                            formDoQuestion.taskControls[index].GetLabelTask().Text = reader["TaskDescription"].ToString();
                            if (reader["TaskDescription"].ToString().Contains("Prim"))
                                formDoQuestion.taskControls[index].GetLabelTask().Text += ", starting from " + reader["StartingVertex"].ToString();
                            else if (reader["TaskDescription"].ToString().Contains("Dijkstra"))
                                formDoQuestion.taskControls[index].GetLabelTask().Text += ", from " + reader["StartingVertex"].ToString() + " to " + reader["FinishingVertex"].ToString();
                            formDoQuestion.taskControls[index].GetLabelTask().Text += ":";
                            
                            if (reader["TaskDescription"].ToString().Contains(" adjacency matrix "))
                            {
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Enabled = false;
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Visible = false;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Enabled = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Visible = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Text = "Adjacency Matrix";
                                formDoQuestion.taskControls[index].SetAnswerMatrix(formDoQuestion.taskMatrix);
                            }
                            else if (reader["TaskDescription"].ToString().Contains(" adjacency list "))
                            {
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Enabled = false;
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Visible = false;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Enabled = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Visible = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Text = "Adjacency List";
                                formDoQuestion.taskControls[index].SetAnswerMatrix(formDoQuestion.taskMatrix);
                            }
                            else if (reader["TaskDescription"].ToString().Contains("Draw"))
                            {
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Enabled = false;
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Visible = false;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Enabled = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Visible = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Text = "Sketch Board";
                                formDoQuestion.taskControls[index].SetAnswerMatrix(formDoQuestion.taskMatrix);
                            }
                            else
                            {
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Enabled = true;
                                formDoQuestion.taskControls[index].GetTextBoxInputAnswer().Visible = true;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Enabled = false;
                                formDoQuestion.taskControls[index].GetButtonInputGraph().Visible = false;
                                formDoQuestion.taskControls[index].SetAnswerValue(reader["AnswerValue"].ToString());
                                formDoQuestion.taskControls[index].GetLabelAnswer().Text += formDoQuestion.taskControls[index].GetAnswerValue();
                            }

                            count++;
                        }
                    }
                }
            }
            formDoQuestion.Show();
            this.Enabled = false;
            this.Hide();
        }
        #endregion

        #region Events
        private void DataGridViewQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string questionID = dataGridViewQuestions["ColumnQuestionID", e.RowIndex].Value.ToString();

            if (this.accountMenu.accountType == "TEACHER")
            {
                EditQuestion(questionID); // Double click on a question to edit that question on a teacher account
            }
            else // if (this.accountMenu.accountType == "STUDENT")
            {
                DoQuestion(questionID); // Double click on a question to do that question on a student account
            }
        }

        private void OtherForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetDataGridViewQuestions();
            this.Enabled = true;
            this.Show();
        }

        private void ButtonEditQuestion_Click(object sender, EventArgs e)
        {
            string questionID = "";
            for (int i = 0; i < dataGridViewQuestions.RowCount; i++)
                if (dataGridViewQuestions["ColumnQuestionID", i].Selected)
                {
                    questionID = dataGridViewQuestions["ColumnQuestionID", i].Value.ToString();
                    break;
                }
            if (questionID != "")
                EditQuestion(questionID);
        }

        private void ButtonAddQuestion_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            formTaskSetting = new FormTaskSetting(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, true);
            formTaskSetting.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherForms_FormClosed);
            formTaskSetting.Show();
        }

        private void ButtonDeleteQuestion_Click(object sender, EventArgs e)
        {
            string questionID = "";
            for (int i = 0; i < dataGridViewQuestions.RowCount; i++)
                if (dataGridViewQuestions["ColumnQuestionID", i].Selected)
                {
                    questionID = dataGridViewQuestions["ColumnQuestionID", i].Value.ToString();
                    break;
                }
            if (questionID != "")
            {
                DialogResult saveGraphResult = MessageBox.Show("Delete?", "", MessageBoxButtons.YesNo);
                if (saveGraphResult == DialogResult.Yes)
                {
                    string graphID;
                    // Cross-table parameterised SQL (Group A) is implemented here.
                    using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
                    {
                        database.Open();

                        // Query graph ID
                        sql = "SELECT GraphID FROM QUESTIONBANK "
                            + "WHERE QuestionID = @QuestionID;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, database))
                        {
                            command.Parameters.Add(new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID });
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                graphID = reader["GraphID"].ToString();
                            }
                        }

                        // Query the format of the graph to decide which deletion process to be followed
                        string graphFormat;
                        sql = "SELECT GraphFormat FROM GRAPHS "
                            + "WHERE GraphID = @GraphID;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, database))
                        {
                            command.Parameters.Add(new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID });
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                graphFormat = reader["GraphFormat"].ToString();
                            }
                        }

                        if (graphFormat == "SketchBoard") // Delete the image if graph is in Sketch Board format
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
                                        File.Delete(imageToDelete);
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

                        // Delete question information, subtasks and the graph
                        sql = "DELETE FROM QUESTIONBANK "
                            + "WHERE QuestionID = @QuestionID; "
                            + "DELETE FROM TASKS "
                            + "WHERE QuestionID = @QuestionID; "
                            + "DELETE FROM GRAPHS "
                            + "WHERE GraphID = @GraphID;"
                            + "DELETE FROM ADJACENCYMATRICES "
                            + "WHERE GraphID = @GraphID;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, database))
                        {
                            command.Parameters.AddRange(new SQLiteParameter[]
                            {
                            new SQLiteParameter("@QuestionID", DbType.Int32) { Value = questionID },
                            new SQLiteParameter("@GraphID", DbType.Int32) { Value = graphID }
                            });
                            command.ExecuteNonQuery();
                        }
                    }

                    ResetDataGridViewQuestions();
                }
            }
        }

        private void ButtonDoQuestion_Click(object sender, EventArgs e)
        {
            string questionID = "";
            for (int i = 0; i < dataGridViewQuestions.RowCount; i++)
                if (dataGridViewQuestions["ColumnQuestionID", i].Selected)
                {
                    questionID = dataGridViewQuestions["ColumnQuestionID", i].Value.ToString();
                    break;
                }
            if (questionID != "")
                DoQuestion(questionID);
        }
        #endregion
    }
}
