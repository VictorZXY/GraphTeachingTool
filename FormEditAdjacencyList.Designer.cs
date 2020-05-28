namespace GraphTeachingTool
{
    partial class FormEditAdjacencyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditAdjacencyList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.dataGridViewAdjacencyList = new System.Windows.Forms.DataGridView();
            this.ColumnVertex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdjacentEdges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjacencyList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(12, 9);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(970, 72);
            this.labelInstructions.TabIndex = 1;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            // 
            // dataGridViewAdjacencyList
            // 
            this.dataGridViewAdjacencyList.AllowUserToAddRows = false;
            this.dataGridViewAdjacencyList.AllowUserToDeleteRows = false;
            this.dataGridViewAdjacencyList.AllowUserToResizeRows = false;
            this.dataGridViewAdjacencyList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewAdjacencyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdjacencyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnVertex,
            this.ColumnAdjacentEdges});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdjacencyList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAdjacencyList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewAdjacencyList.Location = new System.Drawing.Point(12, 87);
            this.dataGridViewAdjacencyList.Name = "dataGridViewAdjacencyList";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdjacencyList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAdjacencyList.RowHeadersVisible = false;
            this.dataGridViewAdjacencyList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAdjacencyList.RowTemplate.Height = 29;
            this.dataGridViewAdjacencyList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdjacencyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewAdjacencyList.Size = new System.Drawing.Size(1231, 802);
            this.dataGridViewAdjacencyList.TabIndex = 2;
            this.dataGridViewAdjacencyList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAdjacencyList_CellValueChanged);
            // 
            // ColumnVertex
            // 
            this.ColumnVertex.HeaderText = "Vertex";
            this.ColumnVertex.Name = "ColumnVertex";
            this.ColumnVertex.ReadOnly = true;
            this.ColumnVertex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnAdjacentEdges
            // 
            this.ColumnAdjacentEdges.HeaderText = "Adjacent Edges";
            this.ColumnAdjacentEdges.Name = "ColumnAdjacentEdges";
            this.ColumnAdjacentEdges.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnAdjacentEdges.Width = 1128;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Location = new System.Drawing.Point(1133, 9);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(110, 72);
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
            // FormEditAdjacencyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.dataGridViewAdjacencyList);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormEditAdjacencyList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Adjacency List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjacencyList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        public System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVertex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdjacentEdges;
        public System.Windows.Forms.DataGridView dataGridViewAdjacencyList;
        public System.Windows.Forms.Label labelInstructions;
    }
}