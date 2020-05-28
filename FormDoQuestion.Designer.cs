namespace GraphTeachingTool
{
    partial class FormDoQuestion
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.groupBoxProblemDescription = new System.Windows.Forms.GroupBox();
            this.labelQuestionName = new System.Windows.Forms.Label();
            this.labelProblemDescription = new System.Windows.Forms.Label();
            this.dataGridViewGraph = new System.Windows.Forms.DataGridView();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.groupBoxProblemDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Location = new System.Drawing.Point(1121, 812);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(121, 75);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.Text = "Mark it!";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxTasks.Location = new System.Drawing.Point(630, 12);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxTasks.Size = new System.Drawing.Size(612, 793);
            this.groupBoxTasks.TabIndex = 5;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Text = "Tasks";
            // 
            // groupBoxProblemDescription
            // 
            this.groupBoxProblemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxProblemDescription.Controls.Add(this.labelQuestionName);
            this.groupBoxProblemDescription.Controls.Add(this.labelProblemDescription);
            this.groupBoxProblemDescription.Controls.Add(this.dataGridViewGraph);
            this.groupBoxProblemDescription.Controls.Add(this.pictureBoxGraph);
            this.groupBoxProblemDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProblemDescription.Name = "groupBoxProblemDescription";
            this.groupBoxProblemDescription.Size = new System.Drawing.Size(612, 793);
            this.groupBoxProblemDescription.TabIndex = 4;
            this.groupBoxProblemDescription.TabStop = false;
            this.groupBoxProblemDescription.Text = "Problem Description";
            // 
            // labelQuestionName
            // 
            this.labelQuestionName.AutoSize = true;
            this.labelQuestionName.Location = new System.Drawing.Point(6, 33);
            this.labelQuestionName.Name = "labelQuestionName";
            this.labelQuestionName.Size = new System.Drawing.Size(157, 24);
            this.labelQuestionName.TabIndex = 10;
            this.labelQuestionName.Text = "(Question Name)";
            // 
            // labelProblemDescription
            // 
            this.labelProblemDescription.AutoSize = true;
            this.labelProblemDescription.Location = new System.Drawing.Point(6, 64);
            this.labelProblemDescription.MaximumSize = new System.Drawing.Size(596, 0);
            this.labelProblemDescription.Name = "labelProblemDescription";
            this.labelProblemDescription.Size = new System.Drawing.Size(121, 24);
            this.labelProblemDescription.TabIndex = 1;
            this.labelProblemDescription.Text = "(Description)";
            // 
            // dataGridViewGraph
            // 
            this.dataGridViewGraph.AllowUserToAddRows = false;
            this.dataGridViewGraph.AllowUserToDeleteRows = false;
            this.dataGridViewGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraph.Location = new System.Drawing.Point(10, 326);
            this.dataGridViewGraph.Name = "dataGridViewGraph";
            this.dataGridViewGraph.ReadOnly = true;
            this.dataGridViewGraph.RowHeadersVisible = false;
            this.dataGridViewGraph.RowTemplate.Height = 30;
            this.dataGridViewGraph.Size = new System.Drawing.Size(596, 461);
            this.dataGridViewGraph.TabIndex = 8;
            this.dataGridViewGraph.Visible = false;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Location = new System.Drawing.Point(10, 326);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(596, 461);
            this.pictureBoxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGraph.TabIndex = 7;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Visible = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScore.Location = new System.Drawing.Point(958, 837);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(159, 31);
            this.labelScore.TabIndex = 8;
            this.labelScore.Text = "Your Score: ";
            this.labelScore.Visible = false;
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
            this.accountMenu.TabIndex = 7;
            // 
            // FormDoQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.accountMenu);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBoxTasks);
            this.Controls.Add(this.groupBoxProblemDescription);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormDoQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Do Question";
            this.groupBoxProblemDescription.ResumeLayout(false);
            this.groupBoxProblemDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.GroupBox groupBoxProblemDescription;
        public System.Windows.Forms.DataGridView dataGridViewGraph;
        public System.Windows.Forms.PictureBox pictureBoxGraph;
        public System.Windows.Forms.Label labelQuestionName;
        public System.Windows.Forms.Label labelProblemDescription;
        private System.Windows.Forms.Label labelScore;
    }
}