namespace GraphTeachingTool
{
    partial class AccountMenu
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
            this.labelAccountName = new System.Windows.Forms.Label();
            this.panelAccountOptions = new System.Windows.Forms.Panel();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAccountSettings = new System.Windows.Forms.Button();
            this.pictureBoxAccountOptions = new System.Windows.Forms.PictureBox();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.panelAccountOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccountName
            // 
            this.labelAccountName.Location = new System.Drawing.Point(3, 0);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(150, 45);
            this.labelAccountName.TabIndex = 0;
            this.labelAccountName.Text = "(Account Name)";
            this.labelAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAccountOptions
            // 
            this.panelAccountOptions.Controls.Add(this.buttonQuit);
            this.panelAccountOptions.Controls.Add(this.buttonAccountSettings);
            this.panelAccountOptions.Location = new System.Drawing.Point(5, 51);
            this.panelAccountOptions.Name = "panelAccountOptions";
            this.panelAccountOptions.Size = new System.Drawing.Size(200, 101);
            this.panelAccountOptions.TabIndex = 1;
            this.panelAccountOptions.Visible = false;
            // 
            // buttonQuit
            // 
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Location = new System.Drawing.Point(3, 52);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(194, 46);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // buttonAccountSettings
            // 
            this.buttonAccountSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountSettings.Location = new System.Drawing.Point(3, 3);
            this.buttonAccountSettings.Name = "buttonAccountSettings";
            this.buttonAccountSettings.Size = new System.Drawing.Size(194, 46);
            this.buttonAccountSettings.TabIndex = 2;
            this.buttonAccountSettings.Text = "Settings";
            this.buttonAccountSettings.UseVisualStyleBackColor = true;
            this.buttonAccountSettings.Click += new System.EventHandler(this.ButtonAccountSettings_Click);
            // 
            // pictureBoxAccountOptions
            // 
            this.pictureBoxAccountOptions.Image = global::GraphTeachingTool.Properties.Resources.menu;
            this.pictureBoxAccountOptions.InitialImage = null;
            this.pictureBoxAccountOptions.Location = new System.Drawing.Point(159, -1);
            this.pictureBoxAccountOptions.Name = "pictureBoxAccountOptions";
            this.pictureBoxAccountOptions.Size = new System.Drawing.Size(46, 46);
            this.pictureBoxAccountOptions.TabIndex = 3;
            this.pictureBoxAccountOptions.TabStop = false;
            this.pictureBoxAccountOptions.Click += new System.EventHandler(this.PictureBoxAccountOptions_Click);
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Location = new System.Drawing.Point(5, 825);
            this.labelInstruction.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(200, 96);
            this.labelInstruction.TabIndex = 4;
            this.labelInstruction.Text = "You can always close the current window to go back to the upper-level window.";
            // 
            // AccountMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.pictureBoxAccountOptions);
            this.Controls.Add(this.panelAccountOptions);
            this.Controls.Add(this.labelAccountName);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountMenu";
            this.Size = new System.Drawing.Size(210, 876);
            this.panelAccountOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelAccountName;
        public System.Windows.Forms.Panel panelAccountOptions;
        public System.Windows.Forms.Button buttonAccountSettings;
        public System.Windows.Forms.PictureBox pictureBoxAccountOptions;
        public System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelInstruction;
    }
}
