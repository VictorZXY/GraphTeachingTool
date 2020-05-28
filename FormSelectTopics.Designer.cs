namespace GraphTeachingTool
{
    partial class FormSelectTopics
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
            this.buttonDijkstra = new System.Windows.Forms.Button();
            this.buttonKruskal = new System.Windows.Forms.Button();
            this.buttonPrim = new System.Windows.Forms.Button();
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
            this.accountMenu.TabIndex = 7;
            // 
            // buttonDijkstra
            // 
            this.buttonDijkstra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDijkstra.Location = new System.Drawing.Point(490, 483);
            this.buttonDijkstra.Name = "buttonDijkstra";
            this.buttonDijkstra.Size = new System.Drawing.Size(300, 75);
            this.buttonDijkstra.TabIndex = 6;
            this.buttonDijkstra.Text = "Dijkstra\'s Algorithm";
            this.buttonDijkstra.UseVisualStyleBackColor = true;
            this.buttonDijkstra.Click += new System.EventHandler(this.ButtonAlgorithms_Click);
            // 
            // buttonKruskal
            // 
            this.buttonKruskal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKruskal.Location = new System.Drawing.Point(490, 402);
            this.buttonKruskal.Name = "buttonKruskal";
            this.buttonKruskal.Size = new System.Drawing.Size(300, 75);
            this.buttonKruskal.TabIndex = 5;
            this.buttonKruskal.Text = "Kruskal\'s Algorithm";
            this.buttonKruskal.UseVisualStyleBackColor = true;
            this.buttonKruskal.Click += new System.EventHandler(this.ButtonAlgorithms_Click);
            // 
            // buttonPrim
            // 
            this.buttonPrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrim.Location = new System.Drawing.Point(490, 321);
            this.buttonPrim.Name = "buttonPrim";
            this.buttonPrim.Size = new System.Drawing.Size(300, 75);
            this.buttonPrim.TabIndex = 4;
            this.buttonPrim.Text = "Prim\'s Algorithm";
            this.buttonPrim.UseVisualStyleBackColor = true;
            this.buttonPrim.Click += new System.EventHandler(this.ButtonAlgorithms_Click);
            // 
            // FormSelectTopics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.accountMenu);
            this.Controls.Add(this.buttonDijkstra);
            this.Controls.Add(this.buttonKruskal);
            this.Controls.Add(this.buttonPrim);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormSelectTopics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Topics";
            this.ResumeLayout(false);

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Button buttonDijkstra;
        private System.Windows.Forms.Button buttonKruskal;
        private System.Windows.Forms.Button buttonPrim;
    }
}