namespace GraphTeachingTool
{
    partial class FormTopicOverview
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
            this.labelTopicOverview = new System.Windows.Forms.Label();
            this.buttonExample1 = new System.Windows.Forms.Button();
            this.buttonExample2 = new System.Windows.Forms.Button();
            this.buttonAdditionalExample1 = new System.Windows.Forms.Button();
            this.buttonAdditionalExample2 = new System.Windows.Forms.Button();
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
            this.accountMenu.TabIndex = 8;
            // 
            // labelTopicOverview
            // 
            this.labelTopicOverview.AutoSize = true;
            this.labelTopicOverview.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTopicOverview.Location = new System.Drawing.Point(24, 9);
            this.labelTopicOverview.MaximumSize = new System.Drawing.Size(570, 0);
            this.labelTopicOverview.Name = "labelTopicOverview";
            this.labelTopicOverview.Size = new System.Drawing.Size(143, 44);
            this.labelTopicOverview.TabIndex = 9;
            this.labelTopicOverview.Text = "Topic overview: \n\n";
            // 
            // buttonExample1
            // 
            this.buttonExample1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExample1.Location = new System.Drawing.Point(771, 393);
            this.buttonExample1.Name = "buttonExample1";
            this.buttonExample1.Size = new System.Drawing.Size(300, 75);
            this.buttonExample1.TabIndex = 10;
            this.buttonExample1.Text = "Example 1";
            this.buttonExample1.UseVisualStyleBackColor = true;
            // 
            // buttonExample2
            // 
            this.buttonExample2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExample2.Location = new System.Drawing.Point(771, 474);
            this.buttonExample2.Name = "buttonExample2";
            this.buttonExample2.Size = new System.Drawing.Size(300, 75);
            this.buttonExample2.TabIndex = 11;
            this.buttonExample2.Text = "Example 2";
            this.buttonExample2.UseVisualStyleBackColor = true;
            // 
            // buttonAdditionalExample1
            // 
            this.buttonAdditionalExample1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdditionalExample1.Location = new System.Drawing.Point(771, 312);
            this.buttonAdditionalExample1.Name = "buttonAdditionalExample1";
            this.buttonAdditionalExample1.Size = new System.Drawing.Size(300, 75);
            this.buttonAdditionalExample1.TabIndex = 12;
            this.buttonAdditionalExample1.Text = "Example 1 - Graphical version";
            this.buttonAdditionalExample1.UseVisualStyleBackColor = true;
            this.buttonAdditionalExample1.Visible = false;
            this.buttonAdditionalExample1.Click += new System.EventHandler(this.ButtonExample_Click);
            // 
            // buttonAdditionalExample2
            // 
            this.buttonAdditionalExample2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdditionalExample2.Location = new System.Drawing.Point(771, 555);
            this.buttonAdditionalExample2.Name = "buttonAdditionalExample2";
            this.buttonAdditionalExample2.Size = new System.Drawing.Size(300, 75);
            this.buttonAdditionalExample2.TabIndex = 13;
            this.buttonAdditionalExample2.Text = "Example 2 - Tabular version";
            this.buttonAdditionalExample2.UseVisualStyleBackColor = true;
            this.buttonAdditionalExample2.Visible = false;
            this.buttonAdditionalExample2.Click += new System.EventHandler(this.ButtonExample_Click);
            // 
            // FormTopicOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.buttonAdditionalExample2);
            this.Controls.Add(this.buttonAdditionalExample1);
            this.Controls.Add(this.buttonExample2);
            this.Controls.Add(this.buttonExample1);
            this.Controls.Add(this.labelTopicOverview);
            this.Controls.Add(this.accountMenu);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormTopicOverview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Topic Overview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccountMenu accountMenu;
        private System.Windows.Forms.Label labelTopicOverview;
        private System.Windows.Forms.Button buttonExample1;
        private System.Windows.Forms.Button buttonExample2;
        private System.Windows.Forms.Button buttonAdditionalExample1;
        private System.Windows.Forms.Button buttonAdditionalExample2;
    }
}