namespace GraphTeachingTool
{
    partial class FormQuestionBank
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
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            this.ColumnQuestionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuestionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDoQuestion = new System.Windows.Forms.Button();
            this.buttonEditQuestion = new System.Windows.Forms.Button();
            this.buttonDeleteQuestion = new System.Windows.Forms.Button();
            this.buttonAddQuestion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            this.SuspendLayout();
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
            this.accountMenu.TabIndex = 0;
            // 
            // dataGridViewQuestions
            // 
            this.dataGridViewQuestions.AllowUserToAddRows = false;
            this.dataGridViewQuestions.AllowUserToDeleteRows = false;
            this.dataGridViewQuestions.AllowUserToOrderColumns = true;
            this.dataGridViewQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnQuestionID,
            this.ColumnDateModified,
            this.ColumnQuestionName});
            this.dataGridViewQuestions.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewQuestions.Name = "dataGridViewQuestions";
            this.dataGridViewQuestions.ReadOnly = true;
            this.dataGridViewQuestions.RowHeadersVisible = false;
            this.dataGridViewQuestions.RowTemplate.Height = 30;
            this.dataGridViewQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewQuestions.Size = new System.Drawing.Size(1230, 796);
            this.dataGridViewQuestions.TabIndex = 1;
            this.dataGridViewQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewQuestions_CellDoubleClick);
            // 
            // ColumnQuestionID
            // 
            this.ColumnQuestionID.HeaderText = "Question ID";
            this.ColumnQuestionID.Name = "ColumnQuestionID";
            this.ColumnQuestionID.ReadOnly = true;
            this.ColumnQuestionID.Visible = false;
            // 
            // ColumnDateModified
            // 
            this.ColumnDateModified.HeaderText = "Date Modified";
            this.ColumnDateModified.Name = "ColumnDateModified";
            this.ColumnDateModified.ReadOnly = true;
            this.ColumnDateModified.Width = 200;
            // 
            // ColumnQuestionName
            // 
            this.ColumnQuestionName.HeaderText = "Question Name";
            this.ColumnQuestionName.Name = "ColumnQuestionName";
            this.ColumnQuestionName.ReadOnly = true;
            this.ColumnQuestionName.Width = 1027;
            // 
            // buttonDoQuestion
            // 
            this.buttonDoQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDoQuestion.Location = new System.Drawing.Point(1121, 814);
            this.buttonDoQuestion.Name = "buttonDoQuestion";
            this.buttonDoQuestion.Size = new System.Drawing.Size(121, 75);
            this.buttonDoQuestion.TabIndex = 2;
            this.buttonDoQuestion.Text = "Do Question";
            this.buttonDoQuestion.UseVisualStyleBackColor = true;
            this.buttonDoQuestion.Click += new System.EventHandler(this.ButtonDoQuestion_Click);
            // 
            // buttonEditQuestion
            // 
            this.buttonEditQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditQuestion.Location = new System.Drawing.Point(994, 814);
            this.buttonEditQuestion.Name = "buttonEditQuestion";
            this.buttonEditQuestion.Size = new System.Drawing.Size(121, 75);
            this.buttonEditQuestion.TabIndex = 3;
            this.buttonEditQuestion.Text = "Edit Question";
            this.buttonEditQuestion.UseVisualStyleBackColor = true;
            this.buttonEditQuestion.Click += new System.EventHandler(this.ButtonEditQuestion_Click);
            // 
            // buttonDeleteQuestion
            // 
            this.buttonDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteQuestion.Location = new System.Drawing.Point(867, 814);
            this.buttonDeleteQuestion.Name = "buttonDeleteQuestion";
            this.buttonDeleteQuestion.Size = new System.Drawing.Size(121, 75);
            this.buttonDeleteQuestion.TabIndex = 4;
            this.buttonDeleteQuestion.Text = "Delete Question";
            this.buttonDeleteQuestion.UseVisualStyleBackColor = true;
            this.buttonDeleteQuestion.Click += new System.EventHandler(this.ButtonDeleteQuestion_Click);
            // 
            // buttonAddQuestion
            // 
            this.buttonAddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddQuestion.Location = new System.Drawing.Point(740, 814);
            this.buttonAddQuestion.Name = "buttonAddQuestion";
            this.buttonAddQuestion.Size = new System.Drawing.Size(121, 75);
            this.buttonAddQuestion.TabIndex = 5;
            this.buttonAddQuestion.Text = "Add Question";
            this.buttonAddQuestion.UseVisualStyleBackColor = true;
            this.buttonAddQuestion.Click += new System.EventHandler(this.ButtonAddQuestion_Click);
            // 
            // FormQuestionBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 904);
            this.Controls.Add(this.buttonAddQuestion);
            this.Controls.Add(this.buttonDeleteQuestion);
            this.Controls.Add(this.buttonEditQuestion);
            this.Controls.Add(this.buttonDoQuestion);
            this.Controls.Add(this.dataGridViewQuestions);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormQuestionBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question Bank";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;
        private System.Windows.Forms.Button buttonDoQuestion;
        private System.Windows.Forms.Button buttonEditQuestion;
        private System.Windows.Forms.Button buttonDeleteQuestion;
        private System.Windows.Forms.Button buttonAddQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuestionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuestionName;
    }
}