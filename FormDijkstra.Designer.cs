namespace GraphTeachingTool
{
    partial class FormDijkstra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDijkstra));
            this.labelFinalResult = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.labelInformation = new System.Windows.Forms.Label();
            this.labelStep3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.labelDijkstra = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStep4 = new System.Windows.Forms.Label();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.SuspendLayout();
            // 
            // labelFinalResult
            // 
            this.labelFinalResult.AutoSize = true;
            this.labelFinalResult.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFinalResult.Location = new System.Drawing.Point(607, 682);
            this.labelFinalResult.MaximumSize = new System.Drawing.Size(725, 0);
            this.labelFinalResult.Name = "labelFinalResult";
            this.labelFinalResult.Size = new System.Drawing.Size(138, 22);
            this.labelFinalResult.TabIndex = 61;
            this.labelFinalResult.Text = "Shortest route: ";
            this.labelFinalResult.Visible = false;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Location = new System.Drawing.Point(611, 217);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(630, 440);
            this.panelGraph.TabIndex = 60;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGraph_Paint);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInformation.ForeColor = System.Drawing.Color.Red;
            this.labelInformation.Location = new System.Drawing.Point(24, 694);
            this.labelInformation.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(0, 22);
            this.labelInformation.TabIndex = 59;
            this.labelInformation.Visible = false;
            // 
            // labelStep3
            // 
            this.labelStep3.AutoSize = true;
            this.labelStep3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep3.Location = new System.Drawing.Point(115, 447);
            this.labelStep3.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelStep3.Name = "labelStep3";
            this.labelStep3.Size = new System.Drawing.Size(488, 132);
            this.labelStep3.TabIndex = 58;
            this.labelStep3.Text = resources.GetString("labelStep3.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 447);
            this.label3.MaximumSize = new System.Drawing.Size(570, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 22);
            this.label3.TabIndex = 57;
            this.label3.Text = "STEP 3    ";
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep2.Location = new System.Drawing.Point(115, 315);
            this.labelStep2.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(497, 132);
            this.labelStep2.TabIndex = 56;
            this.labelStep2.Text = resources.GetString("labelStep2.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 315);
            this.label2.MaximumSize = new System.Drawing.Size(570, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 55;
            this.label2.Text = "STEP 2    ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 249);
            this.label1.MaximumSize = new System.Drawing.Size(570, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "STEP 1    ";
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep1.Location = new System.Drawing.Point(115, 249);
            this.labelStep1.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(428, 66);
            this.labelStep1.TabIndex = 53;
            this.labelStep1.Text = "Make the given start vertex permanent by giving it permanent label 0 and order la" +
    "bel 1. \r\n\r\n";
            // 
            // labelDijkstra
            // 
            this.labelDijkstra.AutoSize = true;
            this.labelDijkstra.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDijkstra.Location = new System.Drawing.Point(24, 205);
            this.labelDijkstra.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelDijkstra.Name = "labelDijkstra";
            this.labelDijkstra.Size = new System.Drawing.Size(297, 44);
            this.labelDijkstra.TabIndex = 52;
            this.labelDijkstra.Text = "Dijkstra\'s Shortest Path Algorithm:\r\n\r\n";
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
            this.buttonNext.TabIndex = 51;
            this.buttonNext.Text = "  Next 》";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 584);
            this.label4.MaximumSize = new System.Drawing.Size(570, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 22);
            this.label4.TabIndex = 62;
            this.label4.Text = "STEP 4    ";
            // 
            // labelStep4
            // 
            this.labelStep4.AutoSize = true;
            this.labelStep4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep4.Location = new System.Drawing.Point(115, 584);
            this.labelStep4.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelStep4.Name = "labelStep4";
            this.labelStep4.Size = new System.Drawing.Size(483, 110);
            this.labelStep4.TabIndex = 63;
            this.labelStep4.Text = "If every vertex is now permanent, or if the target vertex is permanent, use \'trac" +
    "e back\' to find the routes or route,   then STOP; \r\notherwise return to STEP 2. " +
    "\r\n\r\n";
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
            this.accountMenu.TabIndex = 6;
            // 
            // FormDijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelStep4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFinalResult);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelStep3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStep2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStep1);
            this.Controls.Add(this.labelDijkstra);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormDijkstra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dijkstra\'s Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Label labelFinalResult;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Label labelStep3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label labelDijkstra;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelStep4;
    }
}