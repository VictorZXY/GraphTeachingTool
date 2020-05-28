namespace GraphTeachingTool
{
    partial class FormPrimaryMenu
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
            this.buttonTeaching = new System.Windows.Forms.Button();
            this.buttonTaskSetting = new System.Windows.Forms.Button();
            this.buttonQuestionBank = new System.Windows.Forms.Button();
            this.accountMenu = new GraphTeachingTool.AccountMenu();
            this.SuspendLayout();
            // 
            // buttonTeaching
            // 
            this.buttonTeaching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTeaching.Location = new System.Drawing.Point(490, 321);
            this.buttonTeaching.Name = "buttonTeaching";
            this.buttonTeaching.Size = new System.Drawing.Size(300, 75);
            this.buttonTeaching.TabIndex = 0;
            this.buttonTeaching.Text = "Teaching Section";
            this.buttonTeaching.UseVisualStyleBackColor = true;
            this.buttonTeaching.Click += new System.EventHandler(this.ButtonTeaching_Click);
            // 
            // buttonTaskSetting
            // 
            this.buttonTaskSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaskSetting.Location = new System.Drawing.Point(490, 402);
            this.buttonTaskSetting.Name = "buttonTaskSetting";
            this.buttonTaskSetting.Size = new System.Drawing.Size(300, 75);
            this.buttonTaskSetting.TabIndex = 1;
            this.buttonTaskSetting.Text = "Set Tasks";
            this.buttonTaskSetting.UseVisualStyleBackColor = true;
            this.buttonTaskSetting.Click += new System.EventHandler(this.ButtonTaskSetting_Click);
            // 
            // buttonQuestionBank
            // 
            this.buttonQuestionBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuestionBank.Location = new System.Drawing.Point(490, 483);
            this.buttonQuestionBank.Name = "buttonQuestionBank";
            this.buttonQuestionBank.Size = new System.Drawing.Size(300, 75);
            this.buttonQuestionBank.TabIndex = 2;
            this.buttonQuestionBank.Text = "Question Bank";
            this.buttonQuestionBank.UseVisualStyleBackColor = true;
            this.buttonQuestionBank.Click += new System.EventHandler(this.ButtonQuestionBank_Click);
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
            this.accountMenu.TabIndex = 3;
            // 
            // FormPrimaryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 900);
            this.Controls.Add(this.accountMenu);
            this.Controls.Add(this.buttonQuestionBank);
            this.Controls.Add(this.buttonTaskSetting);
            this.Controls.Add(this.buttonTeaching);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormPrimaryMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A Classroom Teaching Tool for Graph Theory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTeaching;
        private System.Windows.Forms.Button buttonTaskSetting;
        private System.Windows.Forms.Button buttonQuestionBank;
        private AccountMenu accountMenu;
    }
}