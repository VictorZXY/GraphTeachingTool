namespace GraphTeachingTool
{
    partial class FormViewTask
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
            this.dataGridViewGraph = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGraph
            // 
            this.dataGridViewGraph.AllowUserToAddRows = false;
            this.dataGridViewGraph.AllowUserToDeleteRows = false;
            this.dataGridViewGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraph.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewGraph.Name = "dataGridViewGraph";
            this.dataGridViewGraph.ReadOnly = true;
            this.dataGridViewGraph.RowHeadersVisible = false;
            this.dataGridViewGraph.RowTemplate.Height = 30;
            this.dataGridViewGraph.Size = new System.Drawing.Size(596, 461);
            this.dataGridViewGraph.TabIndex = 0;
            // 
            // FormViewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 483);
            this.Controls.Add(this.dataGridViewGraph);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormViewTask";
            this.Text = "View Task";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewGraph;
    }
}