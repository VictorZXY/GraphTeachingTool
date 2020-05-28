namespace GraphTeachingTool
{
    partial class FormEditAdjacencyMatrix
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.dataGridViewAdjacencyMatrix = new System.Windows.Forms.DataGridView();
            this.RowHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjacencyMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(12, 9);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(642, 48);
            this.labelInstructions.TabIndex = 1;
            this.labelInstructions.Text = "Edit your adjacency matrix here.\r\nIf you don\'t want to add edge between two verti" +
    "ces, simply leave it blank.";
            // 
            // dataGridViewAdjacencyMatrix
            // 
            this.dataGridViewAdjacencyMatrix.AllowUserToAddRows = false;
            this.dataGridViewAdjacencyMatrix.AllowUserToDeleteRows = false;
            this.dataGridViewAdjacencyMatrix.AllowUserToResizeRows = false;
            this.dataGridViewAdjacencyMatrix.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewAdjacencyMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdjacencyMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowHeader,
            this.ColumnA,
            this.ColumnB,
            this.ColumnC,
            this.ColumnD,
            this.ColumnE,
            this.ColumnF,
            this.ColumnG,
            this.ColumnH,
            this.ColumnI,
            this.ColumnJ,
            this.ColumnK,
            this.ColumnL,
            this.ColumnM,
            this.ColumnN,
            this.ColumnO,
            this.ColumnP,
            this.ColumnQ,
            this.ColumnR,
            this.ColumnS,
            this.ColumnT,
            this.ColumnU,
            this.ColumnV,
            this.ColumnW,
            this.ColumnX,
            this.ColumnY,
            this.ColumnZ});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdjacencyMatrix.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAdjacencyMatrix.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewAdjacencyMatrix.Location = new System.Drawing.Point(12, 60);
            this.dataGridViewAdjacencyMatrix.Name = "dataGridViewAdjacencyMatrix";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdjacencyMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAdjacencyMatrix.RowHeadersVisible = false;
            this.dataGridViewAdjacencyMatrix.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAdjacencyMatrix.RowTemplate.Height = 30;
            this.dataGridViewAdjacencyMatrix.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdjacencyMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewAdjacencyMatrix.Size = new System.Drawing.Size(1231, 829);
            this.dataGridViewAdjacencyMatrix.TabIndex = 2;
            this.dataGridViewAdjacencyMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAdjacencyMatrix_CellValueChanged);
            // 
            // RowHeader
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.RowHeader.DefaultCellStyle = dataGridViewCellStyle1;
            this.RowHeader.HeaderText = "";
            this.RowHeader.Name = "RowHeader";
            this.RowHeader.ReadOnly = true;
            this.RowHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowHeader.Width = 41;
            // 
            // ColumnA
            // 
            this.ColumnA.HeaderText = "A";
            this.ColumnA.Name = "ColumnA";
            this.ColumnA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnB
            // 
            this.ColumnB.HeaderText = "B";
            this.ColumnB.Name = "ColumnB";
            this.ColumnB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnC
            // 
            this.ColumnC.HeaderText = "C";
            this.ColumnC.Name = "ColumnC";
            this.ColumnC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnD
            // 
            this.ColumnD.HeaderText = "D";
            this.ColumnD.Name = "ColumnD";
            this.ColumnD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnE
            // 
            this.ColumnE.HeaderText = "E";
            this.ColumnE.Name = "ColumnE";
            this.ColumnE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnF
            // 
            this.ColumnF.HeaderText = "F";
            this.ColumnF.Name = "ColumnF";
            this.ColumnF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnG
            // 
            this.ColumnG.HeaderText = "G";
            this.ColumnG.Name = "ColumnG";
            this.ColumnG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnH
            // 
            this.ColumnH.HeaderText = "H";
            this.ColumnH.Name = "ColumnH";
            this.ColumnH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnI
            // 
            this.ColumnI.HeaderText = "I";
            this.ColumnI.Name = "ColumnI";
            this.ColumnI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnJ
            // 
            this.ColumnJ.HeaderText = "J";
            this.ColumnJ.Name = "ColumnJ";
            this.ColumnJ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnK
            // 
            this.ColumnK.HeaderText = "K";
            this.ColumnK.Name = "ColumnK";
            this.ColumnK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnL
            // 
            this.ColumnL.HeaderText = "L";
            this.ColumnL.Name = "ColumnL";
            this.ColumnL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnM
            // 
            this.ColumnM.HeaderText = "M";
            this.ColumnM.Name = "ColumnM";
            this.ColumnM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnN
            // 
            this.ColumnN.HeaderText = "N";
            this.ColumnN.Name = "ColumnN";
            this.ColumnN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnO
            // 
            this.ColumnO.HeaderText = "O";
            this.ColumnO.Name = "ColumnO";
            this.ColumnO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnP
            // 
            this.ColumnP.HeaderText = "P";
            this.ColumnP.Name = "ColumnP";
            this.ColumnP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnQ
            // 
            this.ColumnQ.HeaderText = "Q";
            this.ColumnQ.Name = "ColumnQ";
            this.ColumnQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnR
            // 
            this.ColumnR.HeaderText = "R";
            this.ColumnR.Name = "ColumnR";
            this.ColumnR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnS
            // 
            this.ColumnS.HeaderText = "S";
            this.ColumnS.Name = "ColumnS";
            this.ColumnS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnT
            // 
            this.ColumnT.HeaderText = "T";
            this.ColumnT.Name = "ColumnT";
            this.ColumnT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnU
            // 
            this.ColumnU.HeaderText = "U";
            this.ColumnU.Name = "ColumnU";
            this.ColumnU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnV
            // 
            this.ColumnV.HeaderText = "V";
            this.ColumnV.Name = "ColumnV";
            this.ColumnV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnW
            // 
            this.ColumnW.HeaderText = "W";
            this.ColumnW.Name = "ColumnW";
            this.ColumnW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnZ
            // 
            this.ColumnZ.HeaderText = "Z";
            this.ColumnZ.Name = "ColumnZ";
            this.ColumnZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Location = new System.Drawing.Point(1133, 9);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(110, 45);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // accountMenu
            // 
            this.accountMenu.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountMenu.Location = new System.Drawing.Point(1249, 13);
            this.accountMenu.Margin = new System.Windows.Forms.Padding(4);
            this.accountMenu.Name = "accountMenu";
            this.accountMenu.Size = new System.Drawing.Size(210, 876);
            this.accountMenu.TabIndex = 0;
            // 
            // FormEditAdjacencyMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.dataGridViewAdjacencyMatrix);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormEditAdjacencyMatrix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Adjacency Matrix";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjacencyMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        public System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZ;
        public System.Windows.Forms.DataGridView dataGridViewAdjacencyMatrix;
        public System.Windows.Forms.Label labelInstructions;
    }
}