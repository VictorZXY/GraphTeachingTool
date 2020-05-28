namespace GraphTeachingTool
{
    partial class Vertex
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Margin = new System.Windows.Forms.Padding(0);
            this.labelName.MaximumSize = new System.Drawing.Size(27, 27);
            this.labelName.MinimumSize = new System.Drawing.Size(27, 27);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(27, 27);
            this.labelName.TabIndex = 0;
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelName_MouseDoubleClick);
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelName_MouseDown);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelName_MouseMove);
            this.labelName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LabelName_MouseUp);
            // 
            // Vertex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Vertex";
            this.Size = new System.Drawing.Size(27, 27);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Vertex_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vertex_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Vertex_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelName;
    }
}
