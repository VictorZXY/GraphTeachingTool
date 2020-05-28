namespace GraphTeachingTool
{
    partial class FormPrimOnGraph
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelStep3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.labelPrim = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.labelTotalWeight = new System.Windows.Forms.Label();
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
            this.accountMenu.TabIndex = 5;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Location = new System.Drawing.Point(1120, 814);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(121, 75);
            this.buttonNext.TabIndex = 19;
            this.buttonNext.Text = "  Next 》";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // labelStep3
            // 
            this.labelStep3.AutoSize = true;
            this.labelStep3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep3.Location = new System.Drawing.Point(115, 493);
            this.labelStep3.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelStep3.Name = "labelStep3";
            this.labelStep3.Size = new System.Drawing.Size(347, 66);
            this.labelStep3.TabIndex = 26;
            this.labelStep3.Text = "If a spanning tree is obtained then STOP; \r\notherwise return to STEP 2. \r\n\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 493);
            this.label3.MaximumSize = new System.Drawing.Size(570, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 22);
            this.label3.TabIndex = 25;
            this.label3.Text = "STEP 3    ";
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep2.Location = new System.Drawing.Point(115, 427);
            this.labelStep2.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(416, 66);
            this.labelStep2.TabIndex = 24;
            this.labelStep2.Text = "Add an edge of minimum weight joining a vertex already included to a vertex not a" +
    "lready included. \r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 427);
            this.label2.MaximumSize = new System.Drawing.Size(570, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "STEP 2    ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 383);
            this.label1.MaximumSize = new System.Drawing.Size(570, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "STEP 1    ";
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep1.Location = new System.Drawing.Point(115, 383);
            this.labelStep1.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(336, 44);
            this.labelStep1.TabIndex = 21;
            this.labelStep1.Text = "Choose an arbitrary vertex of the graph.\r\n\r\n";
            // 
            // labelPrim
            // 
            this.labelPrim.AutoSize = true;
            this.labelPrim.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPrim.Location = new System.Drawing.Point(24, 339);
            this.labelPrim.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelPrim.Name = "labelPrim";
            this.labelPrim.Size = new System.Drawing.Size(517, 44);
            this.labelPrim.TabIndex = 20;
            this.labelPrim.Text = "Prim\'s Minimum Spanning Tree Algorithm: (Graphical version)\r\n\r\n";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInformation.ForeColor = System.Drawing.Color.Red;
            this.labelInformation.Location = new System.Drawing.Point(24, 559);
            this.labelInformation.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(0, 22);
            this.labelInformation.TabIndex = 48;
            this.labelInformation.Visible = false;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Location = new System.Drawing.Point(547, 251);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(694, 440);
            this.panelGraph.TabIndex = 49;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGraph_Paint);
            // 
            // labelTotalWeight
            // 
            this.labelTotalWeight.AutoSize = true;
            this.labelTotalWeight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalWeight.Location = new System.Drawing.Point(543, 716);
            this.labelTotalWeight.MaximumSize = new System.Drawing.Size(725, 0);
            this.labelTotalWeight.Name = "labelTotalWeight";
            this.labelTotalWeight.Size = new System.Drawing.Size(62, 22);
            this.labelTotalWeight.TabIndex = 50;
            this.labelTotalWeight.Text = "Total: ";
            this.labelTotalWeight.Visible = false;
            // 
            // FormPrimOnGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelTotalWeight);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelStep3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStep2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStep1);
            this.Controls.Add(this.labelPrim);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormPrimOnGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prim\'s Algorithm (Graphical Version)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelStep3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label labelPrim;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelTotalWeight;
    }
}