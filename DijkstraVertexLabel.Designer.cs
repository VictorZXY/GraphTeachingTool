namespace GraphTeachingTool
{
    partial class DijkstraVertexLabel
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
            this.panelVertexName = new System.Windows.Forms.Panel();
            this.labelVertexName = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.panelFinalLabel = new System.Windows.Forms.Panel();
            this.textBoxFinalLabel = new System.Windows.Forms.TextBox();
            this.panelWorkingValues = new System.Windows.Forms.Panel();
            this.textBoxWorkingValues = new System.Windows.Forms.TextBox();
            this.textBoxOrder = new System.Windows.Forms.TextBox();
            this.panelVertexName.SuspendLayout();
            this.panelOrder.SuspendLayout();
            this.panelFinalLabel.SuspendLayout();
            this.panelWorkingValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVertexName
            // 
            this.panelVertexName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVertexName.Controls.Add(this.labelVertexName);
            this.panelVertexName.Location = new System.Drawing.Point(0, 0);
            this.panelVertexName.Name = "panelVertexName";
            this.panelVertexName.Size = new System.Drawing.Size(27, 27);
            this.panelVertexName.TabIndex = 1;
            // 
            // labelVertexName
            // 
            this.labelVertexName.AutoSize = true;
            this.labelVertexName.Location = new System.Drawing.Point(4, 4);
            this.labelVertexName.Name = "labelVertexName";
            this.labelVertexName.Size = new System.Drawing.Size(0, 17);
            this.labelVertexName.TabIndex = 0;
            // 
            // panelOrder
            // 
            this.panelOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrder.Controls.Add(this.textBoxOrder);
            this.panelOrder.Location = new System.Drawing.Point(26, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(35, 27);
            this.panelOrder.TabIndex = 2;
            // 
            // panelFinalLabel
            // 
            this.panelFinalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFinalLabel.Controls.Add(this.textBoxFinalLabel);
            this.panelFinalLabel.Location = new System.Drawing.Point(60, 0);
            this.panelFinalLabel.Name = "panelFinalLabel";
            this.panelFinalLabel.Size = new System.Drawing.Size(50, 27);
            this.panelFinalLabel.TabIndex = 3;
            // 
            // textBoxFinalLabel
            // 
            this.textBoxFinalLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFinalLabel.Location = new System.Drawing.Point(2, 5);
            this.textBoxFinalLabel.Name = "textBoxFinalLabel";
            this.textBoxFinalLabel.Size = new System.Drawing.Size(48, 16);
            this.textBoxFinalLabel.TabIndex = 4;
            // 
            // panelWorkingValues
            // 
            this.panelWorkingValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkingValues.Controls.Add(this.textBoxWorkingValues);
            this.panelWorkingValues.Location = new System.Drawing.Point(0, 26);
            this.panelWorkingValues.Name = "panelWorkingValues";
            this.panelWorkingValues.Size = new System.Drawing.Size(110, 27);
            this.panelWorkingValues.TabIndex = 4;
            // 
            // textBoxWorkingValues
            // 
            this.textBoxWorkingValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWorkingValues.Location = new System.Drawing.Point(2, 5);
            this.textBoxWorkingValues.Name = "textBoxWorkingValues";
            this.textBoxWorkingValues.Size = new System.Drawing.Size(108, 16);
            this.textBoxWorkingValues.TabIndex = 5;
            // 
            // textBoxOrder
            // 
            this.textBoxOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOrder.Location = new System.Drawing.Point(2, 5);
            this.textBoxOrder.Multiline = true;
            this.textBoxOrder.Name = "textBoxOrder";
            this.textBoxOrder.Size = new System.Drawing.Size(33, 16);
            this.textBoxOrder.TabIndex = 0;
            // 
            // DijkstraVertexLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelWorkingValues);
            this.Controls.Add(this.panelFinalLabel);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.panelVertexName);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DijkstraVertexLabel";
            this.Size = new System.Drawing.Size(110, 53);
            this.panelVertexName.ResumeLayout(false);
            this.panelVertexName.PerformLayout();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.panelFinalLabel.ResumeLayout(false);
            this.panelFinalLabel.PerformLayout();
            this.panelWorkingValues.ResumeLayout(false);
            this.panelWorkingValues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelVertexName;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel panelFinalLabel;
        private System.Windows.Forms.TextBox textBoxFinalLabel;
        private System.Windows.Forms.Panel panelWorkingValues;
        private System.Windows.Forms.TextBox textBoxWorkingValues;
        public System.Windows.Forms.Label labelVertexName;
        private System.Windows.Forms.TextBox textBoxOrder;
    }
}
