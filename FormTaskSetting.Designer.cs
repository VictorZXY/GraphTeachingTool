namespace GraphTeachingTool
{
    partial class FormTaskSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxProblemDescription = new System.Windows.Forms.GroupBox();
            this.labelQuestionID = new System.Windows.Forms.Label();
            this.labelGraphID = new System.Windows.Forms.Label();
            this.labelQuestionName = new System.Windows.Forms.Label();
            this.textBoxQuestionName = new System.Windows.Forms.TextBox();
            this.dataGridViewGraph = new System.Windows.Forms.DataGridView();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.labelGraphOption = new System.Windows.Forms.Label();
            this.buttonSketchBoard = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonMatrix = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxProblemDescription = new System.Windows.Forms.TextBox();
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.groupBoxProblemDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.groupBoxTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProblemDescription
            // 
            this.groupBoxProblemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxProblemDescription.Controls.Add(this.labelQuestionID);
            this.groupBoxProblemDescription.Controls.Add(this.labelGraphID);
            this.groupBoxProblemDescription.Controls.Add(this.labelQuestionName);
            this.groupBoxProblemDescription.Controls.Add(this.textBoxQuestionName);
            this.groupBoxProblemDescription.Controls.Add(this.dataGridViewGraph);
            this.groupBoxProblemDescription.Controls.Add(this.pictureBoxGraph);
            this.groupBoxProblemDescription.Controls.Add(this.labelGraphOption);
            this.groupBoxProblemDescription.Controls.Add(this.buttonSketchBoard);
            this.groupBoxProblemDescription.Controls.Add(this.buttonList);
            this.groupBoxProblemDescription.Controls.Add(this.buttonMatrix);
            this.groupBoxProblemDescription.Controls.Add(this.labelDescription);
            this.groupBoxProblemDescription.Controls.Add(this.textBoxProblemDescription);
            this.groupBoxProblemDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProblemDescription.Name = "groupBoxProblemDescription";
            this.groupBoxProblemDescription.Size = new System.Drawing.Size(612, 793);
            this.groupBoxProblemDescription.TabIndex = 0;
            this.groupBoxProblemDescription.TabStop = false;
            this.groupBoxProblemDescription.Text = "Problem Description";
            // 
            // labelQuestionID
            // 
            this.labelQuestionID.AutoSize = true;
            this.labelQuestionID.Location = new System.Drawing.Point(96, 64);
            this.labelQuestionID.Name = "labelQuestionID";
            this.labelQuestionID.Size = new System.Drawing.Size(0, 24);
            this.labelQuestionID.TabIndex = 12;
            this.labelQuestionID.Visible = false;
            this.labelQuestionID.TextChanged += new System.EventHandler(this.LabelQuestionID_TextChanged);
            // 
            // labelGraphID
            // 
            this.labelGraphID.AutoSize = true;
            this.labelGraphID.Location = new System.Drawing.Point(90, 64);
            this.labelGraphID.Name = "labelGraphID";
            this.labelGraphID.Size = new System.Drawing.Size(0, 24);
            this.labelGraphID.TabIndex = 11;
            this.labelGraphID.Visible = false;
            this.labelGraphID.TextChanged += new System.EventHandler(this.LabelGraphID_TextChanged);
            // 
            // labelQuestionName
            // 
            this.labelQuestionName.AutoSize = true;
            this.labelQuestionName.Location = new System.Drawing.Point(6, 33);
            this.labelQuestionName.Name = "labelQuestionName";
            this.labelQuestionName.Size = new System.Drawing.Size(149, 24);
            this.labelQuestionName.TabIndex = 10;
            this.labelQuestionName.Text = "Question Name:";
            // 
            // textBoxQuestionName
            // 
            this.textBoxQuestionName.Location = new System.Drawing.Point(161, 30);
            this.textBoxQuestionName.MaxLength = 140;
            this.textBoxQuestionName.Name = "textBoxQuestionName";
            this.textBoxQuestionName.Size = new System.Drawing.Size(445, 31);
            this.textBoxQuestionName.TabIndex = 9;
            this.textBoxQuestionName.TextChanged += new System.EventHandler(this.TextBoxQuestionName_TextChanged);
            // 
            // dataGridViewGraph
            // 
            this.dataGridViewGraph.AllowUserToAddRows = false;
            this.dataGridViewGraph.AllowUserToDeleteRows = false;
            this.dataGridViewGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraph.Location = new System.Drawing.Point(10, 393);
            this.dataGridViewGraph.Name = "dataGridViewGraph";
            this.dataGridViewGraph.ReadOnly = true;
            this.dataGridViewGraph.RowHeadersVisible = false;
            this.dataGridViewGraph.RowTemplate.Height = 30;
            this.dataGridViewGraph.Size = new System.Drawing.Size(596, 394);
            this.dataGridViewGraph.TabIndex = 8;
            this.dataGridViewGraph.Visible = false;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Location = new System.Drawing.Point(10, 393);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(596, 394);
            this.pictureBoxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGraph.TabIndex = 7;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Visible = false;
            // 
            // labelGraphOption
            // 
            this.labelGraphOption.AutoSize = true;
            this.labelGraphOption.Location = new System.Drawing.Point(6, 300);
            this.labelGraphOption.Name = "labelGraphOption";
            this.labelGraphOption.Size = new System.Drawing.Size(370, 24);
            this.labelGraphOption.TabIndex = 6;
            this.labelGraphOption.Text = "How would you like to create your graph?";
            // 
            // buttonSketchBoard
            // 
            this.buttonSketchBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSketchBoard.Location = new System.Drawing.Point(411, 326);
            this.buttonSketchBoard.Name = "buttonSketchBoard";
            this.buttonSketchBoard.Size = new System.Drawing.Size(195, 61);
            this.buttonSketchBoard.TabIndex = 5;
            this.buttonSketchBoard.Text = "Sketch Board";
            this.buttonSketchBoard.UseVisualStyleBackColor = true;
            this.buttonSketchBoard.Click += new System.EventHandler(this.ButtonSketchBoard_Click);
            // 
            // buttonList
            // 
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Location = new System.Drawing.Point(211, 326);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(194, 61);
            this.buttonList.TabIndex = 4;
            this.buttonList.Text = "Adjacency List";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.ButtonList_Click);
            // 
            // buttonMatrix
            // 
            this.buttonMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMatrix.Location = new System.Drawing.Point(10, 326);
            this.buttonMatrix.Name = "buttonMatrix";
            this.buttonMatrix.Size = new System.Drawing.Size(195, 61);
            this.buttonMatrix.TabIndex = 3;
            this.buttonMatrix.Text = "Adjacency Matrix";
            this.buttonMatrix.UseVisualStyleBackColor = true;
            this.buttonMatrix.Click += new System.EventHandler(this.ButtonMatrix_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(6, 64);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(113, 24);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxProblemDescription
            // 
            this.textBoxProblemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProblemDescription.Location = new System.Drawing.Point(10, 91);
            this.textBoxProblemDescription.MaxLength = 1500;
            this.textBoxProblemDescription.Multiline = true;
            this.textBoxProblemDescription.Name = "textBoxProblemDescription";
            this.textBoxProblemDescription.Size = new System.Drawing.Size(596, 206);
            this.textBoxProblemDescription.TabIndex = 0;
            this.textBoxProblemDescription.TextChanged += new System.EventHandler(this.TextBoxProblemDescription_TextChanged);
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxTasks.Controls.Add(this.buttonAddTask);
            this.groupBoxTasks.Location = new System.Drawing.Point(630, 12);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxTasks.Size = new System.Drawing.Size(612, 793);
            this.groupBoxTasks.TabIndex = 1;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Text = "Tasks";
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddTask.Font = new System.Drawing.Font("SimSun", 9F);
            this.buttonAddTask.Location = new System.Drawing.Point(581, 26);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(25, 25);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "＋";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.ButtonAddTask_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(1121, 812);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 75);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save task";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // accountMenu
            // 
            this.accountMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountMenu.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountMenu.Location = new System.Drawing.Point(1249, 13);
            this.accountMenu.Margin = new System.Windows.Forms.Padding(4);
            this.accountMenu.Name = "accountMenu";
            this.accountMenu.Size = new System.Drawing.Size(210, 876);
            this.accountMenu.TabIndex = 3;
            // 
            // FormTaskSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.accountMenu);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxTasks);
            this.Controls.Add(this.groupBoxProblemDescription);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormTaskSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTaskSetting_FormClosed);
            this.groupBoxProblemDescription.ResumeLayout(false);
            this.groupBoxProblemDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.groupBoxTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelGraphOption;
        private System.Windows.Forms.Button buttonSketchBoard;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonMatrix;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Label labelQuestionName;
        private System.Windows.Forms.GroupBox groupBoxProblemDescription;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        public System.Windows.Forms.TextBox textBoxProblemDescription;
        public System.Windows.Forms.PictureBox pictureBoxGraph;
        private AccountMenu accountMenu;
        public System.Windows.Forms.DataGridView dataGridViewGraph;
        public System.Windows.Forms.TextBox textBoxQuestionName;
        public System.Windows.Forms.Label labelQuestionID;
        public System.Windows.Forms.Label labelGraphID;
    }
}