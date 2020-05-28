namespace GraphTeachingTool
{
    partial class FormKruskal
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
            this.labelKruskal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.labelStep3 = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelEdgeLeft = new System.Windows.Forms.Label();
            this.labelWeightLeft = new System.Windows.Forms.Label();
            this.labelWeightRight = new System.Windows.Forms.Label();
            this.labelEdgeRight = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.labelList = new System.Windows.Forms.Label();
            this.labelTotalWeight = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.SuspendLayout();
            // 
            // labelKruskal
            // 
            this.labelKruskal.AutoSize = true;
            this.labelKruskal.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelKruskal.Location = new System.Drawing.Point(24, 24);
            this.labelKruskal.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelKruskal.Name = "labelKruskal";
            this.labelKruskal.Size = new System.Drawing.Size(386, 44);
            this.labelKruskal.TabIndex = 10;
            this.labelKruskal.Text = "Kruskal\'s Minimum Spanning Tree Algorithm: \n\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 68);
            this.label1.MaximumSize = new System.Drawing.Size(570, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "STEP 1    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 112);
            this.label2.MaximumSize = new System.Drawing.Size(570, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "STEP 2    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 178);
            this.label3.MaximumSize = new System.Drawing.Size(570, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "STEP 3    ";
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep1.Location = new System.Drawing.Point(115, 68);
            this.labelStep1.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(368, 44);
            this.labelStep1.TabIndex = 11;
            this.labelStep1.Text = "List the edges in increasing order of weight.\r\n\r\n";
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep2.Location = new System.Drawing.Point(115, 112);
            this.labelStep2.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(395, 66);
            this.labelStep2.TabIndex = 14;
            this.labelStep2.Text = "Add an edge of the graph of minimum weight, \r\nin such a way that no cycles are cr" +
    "eated.\r\n\r\n";
            // 
            // labelStep3
            // 
            this.labelStep3.AutoSize = true;
            this.labelStep3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep3.Location = new System.Drawing.Point(115, 178);
            this.labelStep3.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelStep3.Name = "labelStep3";
            this.labelStep3.Size = new System.Drawing.Size(347, 66);
            this.labelStep3.TabIndex = 16;
            this.labelStep3.Text = "If a spanning tree is obtained then STOP; \r\notherwise return to STEP 2. \r\n\r\n";
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
            this.buttonNext.TabIndex = 18;
            this.buttonNext.Text = "  Next 》";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // labelEdgeLeft
            // 
            this.labelEdgeLeft.AutoSize = true;
            this.labelEdgeLeft.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEdgeLeft.Location = new System.Drawing.Point(24, 288);
            this.labelEdgeLeft.MinimumSize = new System.Drawing.Size(100, 44);
            this.labelEdgeLeft.Name = "labelEdgeLeft";
            this.labelEdgeLeft.Size = new System.Drawing.Size(100, 44);
            this.labelEdgeLeft.TabIndex = 19;
            this.labelEdgeLeft.Text = "Edge\r\n\r\n";
            this.labelEdgeLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelEdgeLeft.Visible = false;
            // 
            // labelWeightLeft
            // 
            this.labelWeightLeft.AutoSize = true;
            this.labelWeightLeft.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWeightLeft.Location = new System.Drawing.Point(124, 288);
            this.labelWeightLeft.MinimumSize = new System.Drawing.Size(100, 44);
            this.labelWeightLeft.Name = "labelWeightLeft";
            this.labelWeightLeft.Size = new System.Drawing.Size(100, 44);
            this.labelWeightLeft.TabIndex = 20;
            this.labelWeightLeft.Text = "Weight\r\n\r\n";
            this.labelWeightLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWeightLeft.Visible = false;
            // 
            // labelWeightRight
            // 
            this.labelWeightRight.AutoSize = true;
            this.labelWeightRight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWeightRight.Location = new System.Drawing.Point(352, 288);
            this.labelWeightRight.MinimumSize = new System.Drawing.Size(100, 44);
            this.labelWeightRight.Name = "labelWeightRight";
            this.labelWeightRight.Size = new System.Drawing.Size(100, 44);
            this.labelWeightRight.TabIndex = 22;
            this.labelWeightRight.Text = "Weight\r\n\r\n";
            this.labelWeightRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWeightRight.Visible = false;
            // 
            // labelEdgeRight
            // 
            this.labelEdgeRight.AutoSize = true;
            this.labelEdgeRight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEdgeRight.Location = new System.Drawing.Point(252, 288);
            this.labelEdgeRight.MinimumSize = new System.Drawing.Size(100, 44);
            this.labelEdgeRight.Name = "labelEdgeRight";
            this.labelEdgeRight.Size = new System.Drawing.Size(100, 44);
            this.labelEdgeRight.TabIndex = 21;
            this.labelEdgeRight.Text = "Edge\r\n\r\n";
            this.labelEdgeRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelEdgeRight.Visible = false;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Location = new System.Drawing.Point(516, 244);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(725, 440);
            this.panelGraph.TabIndex = 43;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGraph_Paint);
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelList.Location = new System.Drawing.Point(24, 244);
            this.labelList.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(207, 44);
            this.labelList.TabIndex = 45;
            this.labelList.Text = "The sorted list of edges:\r\n\r\n";
            this.labelList.Visible = false;
            // 
            // labelTotalWeight
            // 
            this.labelTotalWeight.AutoSize = true;
            this.labelTotalWeight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalWeight.Location = new System.Drawing.Point(512, 709);
            this.labelTotalWeight.MaximumSize = new System.Drawing.Size(725, 0);
            this.labelTotalWeight.Name = "labelTotalWeight";
            this.labelTotalWeight.Size = new System.Drawing.Size(62, 22);
            this.labelTotalWeight.TabIndex = 46;
            this.labelTotalWeight.Text = "Total: ";
            this.labelTotalWeight.Visible = false;
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInformation.ForeColor = System.Drawing.Color.Red;
            this.labelInformation.Location = new System.Drawing.Point(24, 709);
            this.labelInformation.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(0, 22);
            this.labelInformation.TabIndex = 47;
            this.labelInformation.Visible = false;
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
            this.accountMenu.TabIndex = 4;
            // 
            // FormKruskal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelTotalWeight);
            this.Controls.Add(this.labelList);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.labelWeightRight);
            this.Controls.Add(this.labelEdgeRight);
            this.Controls.Add(this.labelWeightLeft);
            this.Controls.Add(this.labelEdgeLeft);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelStep3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStep2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStep1);
            this.Controls.Add(this.labelKruskal);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormKruskal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kruskal\'s Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Label labelKruskal;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStep3;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelEdgeLeft;
        private System.Windows.Forms.Label labelWeightLeft;
        private System.Windows.Forms.Label labelWeightRight;
        private System.Windows.Forms.Label labelEdgeRight;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.Label labelTotalWeight;
        private System.Windows.Forms.Label labelInformation;
    }
}