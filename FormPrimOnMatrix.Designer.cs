namespace GraphTeachingTool
{
    partial class FormPrimOnMatrix
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTotalWeight = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.labelStep3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.labelPrim = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.dataGridViewGraph = new System.Windows.Forms.DataGridView();
            this.labelInformation = new System.Windows.Forms.Label();
            this.labelStep4 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStep5 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotalWeight
            // 
            this.labelTotalWeight.AutoSize = true;
            this.labelTotalWeight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalWeight.Location = new System.Drawing.Point(543, 832);
            this.labelTotalWeight.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelTotalWeight.Name = "labelTotalWeight";
            this.labelTotalWeight.Size = new System.Drawing.Size(62, 22);
            this.labelTotalWeight.TabIndex = 60;
            this.labelTotalWeight.Text = "Total: ";
            this.labelTotalWeight.Visible = false;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.White;
            this.panelGraph.Location = new System.Drawing.Point(547, 412);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(694, 395);
            this.panelGraph.TabIndex = 59;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGraph_Paint);
            // 
            // labelStep3
            // 
            this.labelStep3.AutoSize = true;
            this.labelStep3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep3.Location = new System.Drawing.Point(115, 449);
            this.labelStep3.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep3.Name = "labelStep3";
            this.labelStep3.Size = new System.Drawing.Size(286, 66);
            this.labelStep3.TabIndex = 58;
            this.labelStep3.Text = "If no such entry exists then STOP; \r\notherwise go to STEP 4.\r\n\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 449);
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
            this.labelStep2.Location = new System.Drawing.Point(115, 383);
            this.labelStep2.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(433, 66);
            this.labelStep2.TabIndex = 56;
            this.labelStep2.Text = "Choose a minimum entry from the uncircled entries in the marked column(s).\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 383);
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
            this.label1.Location = new System.Drawing.Point(24, 317);
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
            this.labelStep1.Location = new System.Drawing.Point(115, 317);
            this.labelStep1.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(419, 66);
            this.labelStep1.TabIndex = 53;
            this.labelStep1.Text = "Cross through the entries in an arbitrary row, and mark the corresponding column." +
    " \r\n\r\n";
            // 
            // labelPrim
            // 
            this.labelPrim.AutoSize = true;
            this.labelPrim.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPrim.Location = new System.Drawing.Point(24, 273);
            this.labelPrim.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelPrim.Name = "labelPrim";
            this.labelPrim.Size = new System.Drawing.Size(502, 44);
            this.labelPrim.TabIndex = 52;
            this.labelPrim.Text = "Prim\'s Minimum Spanning Tree Algorithm: (Tabular version)\r\n\r\n";
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
            // dataGridViewGraph
            // 
            this.dataGridViewGraph.AllowUserToAddRows = false;
            this.dataGridViewGraph.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGraph.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGraph.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewGraph.EnableHeadersVisualStyles = false;
            this.dataGridViewGraph.Location = new System.Drawing.Point(547, 13);
            this.dataGridViewGraph.Name = "dataGridViewGraph";
            this.dataGridViewGraph.ReadOnly = true;
            this.dataGridViewGraph.RowHeadersVisible = false;
            this.dataGridViewGraph.RowTemplate.Height = 30;
            this.dataGridViewGraph.Size = new System.Drawing.Size(694, 395);
            this.dataGridViewGraph.TabIndex = 61;
            this.dataGridViewGraph.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGraph_CellContentClick);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInformation.ForeColor = System.Drawing.Color.Red;
            this.labelInformation.Location = new System.Drawing.Point(24, 625);
            this.labelInformation.MaximumSize = new System.Drawing.Size(490, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(0, 22);
            this.labelInformation.TabIndex = 62;
            this.labelInformation.Visible = false;
            // 
            // labelStep4
            // 
            this.labelStep4.AutoSize = true;
            this.labelStep4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep4.Location = new System.Drawing.Point(115, 515);
            this.labelStep4.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep4.Name = "labelStep4";
            this.labelStep4.Size = new System.Drawing.Size(336, 66);
            this.labelStep4.TabIndex = 64;
            this.labelStep4.Text = "Circle the weight w(i, j) found in STEP 2;\r\nmark column j; cross through row i. \r" +
    "\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 515);
            this.label4.MaximumSize = new System.Drawing.Size(570, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 22);
            this.label4.TabIndex = 63;
            this.label4.Text = "STEP 4    ";
            // 
            // labelStep5
            // 
            this.labelStep5.AutoSize = true;
            this.labelStep5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStep5.Location = new System.Drawing.Point(115, 581);
            this.labelStep5.MaximumSize = new System.Drawing.Size(440, 0);
            this.labelStep5.Name = "labelStep5";
            this.labelStep5.Size = new System.Drawing.Size(152, 44);
            this.labelStep5.TabIndex = 66;
            this.labelStep5.Text = "Return to STEP 2.\r\n\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 581);
            this.label5.MaximumSize = new System.Drawing.Size(570, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 22);
            this.label5.TabIndex = 65;
            this.label5.Text = "STEP 5    ";
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
            // FormPrimOnMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.labelStep5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStep4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.dataGridViewGraph);
            this.Controls.Add(this.labelTotalWeight);
            this.Controls.Add(this.panelGraph);
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
            this.Name = "FormPrimOnMatrix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prim\'s Algorithm (Tabular Version)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Label labelTotalWeight;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelStep3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label labelPrim;
        private System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.DataGridView dataGridViewGraph;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Label labelStep4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelStep5;
        private System.Windows.Forms.Label label5;
    }
}