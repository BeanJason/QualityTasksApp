namespace QualityTasksApp
{
    partial class ManagerHome
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
            this.AddNewTechBtn = new System.Windows.Forms.Button();
            this.SignOutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNewTechBtn
            // 
            this.AddNewTechBtn.Location = new System.Drawing.Point(588, 224);
            this.AddNewTechBtn.Name = "AddNewTechBtn";
            this.AddNewTechBtn.Size = new System.Drawing.Size(293, 77);
            this.AddNewTechBtn.TabIndex = 0;
            this.AddNewTechBtn.Text = "Add New Tech";
            this.AddNewTechBtn.UseVisualStyleBackColor = true;
            this.AddNewTechBtn.Click += new System.EventHandler(this.AddNewTechBtn_Click);
            // 
            // SignOutBtn
            // 
            this.SignOutBtn.Location = new System.Drawing.Point(588, 593);
            this.SignOutBtn.Name = "SignOutBtn";
            this.SignOutBtn.Size = new System.Drawing.Size(293, 77);
            this.SignOutBtn.TabIndex = 1;
            this.SignOutBtn.Text = "Sign Out";
            this.SignOutBtn.UseVisualStyleBackColor = true;
            this.SignOutBtn.Click += new System.EventHandler(this.SignOutBtn_Click);
            // 
            // ManagerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 875);
            this.Controls.Add(this.SignOutBtn);
            this.Controls.Add(this.AddNewTechBtn);
            this.Name = "ManagerHome";
            this.Text = "ManagerHome";
            this.ResumeLayout(false);

        }

        #endregion

        private Button AddNewTechBtn;
        private Button SignOutBtn;
    }
}