namespace GraphTeachingTool
{
    partial class FormSketchBoard
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
            this.components = new System.ComponentModel.Container();
            this.buttonVertex = new System.Windows.Forms.Button();
            this.buttonEdge = new System.Windows.Forms.Button();
            this.buttonTag = new System.Windows.Forms.Button();
            this.panelSketchBoard = new System.Windows.Forms.Panel();
            this.panelEdgeProperties = new System.Windows.Forms.Panel();
            this.buttonUndirected = new System.Windows.Forms.Button();
            this.buttonDirected = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.timerShowEdgeProperties = new System.Windows.Forms.Timer(this.components);
            this.buttonClearPanel = new System.Windows.Forms.Button();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.buttonViewTask = new System.Windows.Forms.Button();
            this.panelSketchBoard.SuspendLayout();
            this.panelEdgeProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVertex
            // 
            this.buttonVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVertex.Location = new System.Drawing.Point(13, 12);
            this.buttonVertex.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVertex.Name = "buttonVertex";
            this.buttonVertex.Size = new System.Drawing.Size(75, 75);
            this.buttonVertex.TabIndex = 0;
            this.buttonVertex.Text = "vertex";
            this.buttonVertex.UseVisualStyleBackColor = true;
            this.buttonVertex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonVertex_MouseUp);
            // 
            // buttonEdge
            // 
            this.buttonEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdge.Location = new System.Drawing.Point(13, 96);
            this.buttonEdge.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdge.Name = "buttonEdge";
            this.buttonEdge.Size = new System.Drawing.Size(75, 75);
            this.buttonEdge.TabIndex = 1;
            this.buttonEdge.Text = "edge";
            this.buttonEdge.UseVisualStyleBackColor = true;
            this.buttonEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonEdge_MouseDown);
            this.buttonEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonEdge_MouseUp);
            // 
            // buttonTag
            // 
            this.buttonTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTag.Location = new System.Drawing.Point(13, 179);
            this.buttonTag.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTag.Name = "buttonTag";
            this.buttonTag.Size = new System.Drawing.Size(75, 75);
            this.buttonTag.TabIndex = 2;
            this.buttonTag.Text = "tag";
            this.buttonTag.UseVisualStyleBackColor = true;
            this.buttonTag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonTag_MouseUp);
            // 
            // panelSketchBoard
            // 
            this.panelSketchBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSketchBoard.AutoScroll = true;
            this.panelSketchBoard.AutoSize = true;
            this.panelSketchBoard.BackColor = System.Drawing.Color.White;
            this.panelSketchBoard.Controls.Add(this.panelEdgeProperties);
            this.panelSketchBoard.Location = new System.Drawing.Point(95, 12);
            this.panelSketchBoard.Name = "panelSketchBoard";
            this.panelSketchBoard.Size = new System.Drawing.Size(1147, 876);
            this.panelSketchBoard.TabIndex = 3;
            this.panelSketchBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelSketchBoard_MouseDown);
            this.panelSketchBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelSketchBoard_MouseMove);
            // 
            // panelEdgeProperties
            // 
            this.panelEdgeProperties.BackColor = System.Drawing.SystemColors.Control;
            this.panelEdgeProperties.Controls.Add(this.buttonUndirected);
            this.panelEdgeProperties.Controls.Add(this.buttonDirected);
            this.panelEdgeProperties.Location = new System.Drawing.Point(0, 84);
            this.panelEdgeProperties.Name = "panelEdgeProperties";
            this.panelEdgeProperties.Size = new System.Drawing.Size(158, 75);
            this.panelEdgeProperties.TabIndex = 0;
            this.panelEdgeProperties.Visible = false;
            // 
            // buttonUndirected
            // 
            this.buttonUndirected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndirected.Font = new System.Drawing.Font("Microsoft YaHei", 20F);
            this.buttonUndirected.Location = new System.Drawing.Point(83, 0);
            this.buttonUndirected.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUndirected.Name = "buttonUndirected";
            this.buttonUndirected.Size = new System.Drawing.Size(75, 75);
            this.buttonUndirected.TabIndex = 7;
            this.buttonUndirected.Text = "╱";
            this.buttonUndirected.UseVisualStyleBackColor = true;
            this.buttonUndirected.Click += new System.EventHandler(this.ButtonUndirected_Click);
            // 
            // buttonDirected
            // 
            this.buttonDirected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDirected.Font = new System.Drawing.Font("Microsoft YaHei", 20F);
            this.buttonDirected.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDirected.Location = new System.Drawing.Point(0, 0);
            this.buttonDirected.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDirected.Name = "buttonDirected";
            this.buttonDirected.Size = new System.Drawing.Size(75, 75);
            this.buttonDirected.TabIndex = 6;
            this.buttonDirected.Text = "↗";
            this.buttonDirected.UseVisualStyleBackColor = true;
            this.buttonDirected.Click += new System.EventHandler(this.ButtonDirected_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSubmit.Location = new System.Drawing.Point(13, 812);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 75);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // timerShowEdgeProperties
            // 
            this.timerShowEdgeProperties.Interval = 250;
            this.timerShowEdgeProperties.Tick += new System.EventHandler(this.TimerShowEdgeProperties_Tick);
            // 
            // buttonClearPanel
            // 
            this.buttonClearPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearPanel.Location = new System.Drawing.Point(13, 262);
            this.buttonClearPanel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearPanel.Name = "buttonClearPanel";
            this.buttonClearPanel.Size = new System.Drawing.Size(75, 75);
            this.buttonClearPanel.TabIndex = 6;
            this.buttonClearPanel.Text = "clear";
            this.buttonClearPanel.UseVisualStyleBackColor = true;
            this.buttonClearPanel.Click += new System.EventHandler(this.ButtonClearPanel_Click);
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
            // buttonViewTask
            // 
            this.buttonViewTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonViewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewTask.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonViewTask.Location = new System.Drawing.Point(13, 729);
            this.buttonViewTask.Margin = new System.Windows.Forms.Padding(4);
            this.buttonViewTask.Name = "buttonViewTask";
            this.buttonViewTask.Size = new System.Drawing.Size(75, 75);
            this.buttonViewTask.TabIndex = 8;
            this.buttonViewTask.Text = "view task";
            this.buttonViewTask.UseVisualStyleBackColor = true;
            this.buttonViewTask.Visible = false;
            // 
            // FormSketchBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.buttonViewTask);
            this.Controls.Add(this.accountMenu);
            this.Controls.Add(this.buttonClearPanel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.panelSketchBoard);
            this.Controls.Add(this.buttonTag);
            this.Controls.Add(this.buttonEdge);
            this.Controls.Add(this.buttonVertex);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormSketchBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sketch Board";
            this.panelSketchBoard.ResumeLayout(false);
            this.panelEdgeProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVertex;
        private System.Windows.Forms.Button buttonEdge;
        private System.Windows.Forms.Button buttonTag;
        private System.Windows.Forms.Panel panelEdgeProperties;
        private System.Windows.Forms.Button buttonUndirected;
        private System.Windows.Forms.Button buttonDirected;
        private System.Windows.Forms.Timer timerShowEdgeProperties;
        private System.Windows.Forms.Button buttonClearPanel;
        public System.Windows.Forms.Button buttonSubmit;
        private AccountMenu accountMenu;
        private System.Windows.Forms.Panel panelSketchBoard;
        public System.Windows.Forms.Button buttonViewTask;
    }
}

