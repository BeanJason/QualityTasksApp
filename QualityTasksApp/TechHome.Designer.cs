namespace QualityTasksApp
{
    partial class TechHome
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
            this.startUpBtn = new System.Windows.Forms.Button();
            this.weeklyBtn = new System.Windows.Forms.Button();
            this.signOutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dailyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startUpBtn
            // 
            this.startUpBtn.Location = new System.Drawing.Point(549, 195);
            this.startUpBtn.Name = "startUpBtn";
            this.startUpBtn.Size = new System.Drawing.Size(433, 144);
            this.startUpBtn.TabIndex = 0;
            this.startUpBtn.Text = "Start Up";
            this.startUpBtn.UseVisualStyleBackColor = true;
            // 
            // weeklyBtn
            // 
            this.weeklyBtn.Location = new System.Drawing.Point(549, 579);
            this.weeklyBtn.Name = "weeklyBtn";
            this.weeklyBtn.Size = new System.Drawing.Size(433, 144);
            this.weeklyBtn.TabIndex = 1;
            this.weeklyBtn.Text = "Weekly";
            this.weeklyBtn.UseVisualStyleBackColor = true;
            // 
            // signOutBtn
            // 
            this.signOutBtn.Location = new System.Drawing.Point(549, 771);
            this.signOutBtn.Name = "signOutBtn";
            this.signOutBtn.Size = new System.Drawing.Size(433, 144);
            this.signOutBtn.TabIndex = 2;
            this.signOutBtn.Text = "Sign Out";
            this.signOutBtn.UseVisualStyleBackColor = true;
            this.signOutBtn.Click += new System.EventHandler(this.signOutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dailyBtn
            // 
            this.dailyBtn.Location = new System.Drawing.Point(549, 386);
            this.dailyBtn.Name = "dailyBtn";
            this.dailyBtn.Size = new System.Drawing.Size(433, 144);
            this.dailyBtn.TabIndex = 4;
            this.dailyBtn.Text = "Daily";
            this.dailyBtn.UseVisualStyleBackColor = true;
            // 
            // TechHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 994);
            this.Controls.Add(this.dailyBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signOutBtn);
            this.Controls.Add(this.weeklyBtn);
            this.Controls.Add(this.startUpBtn);
            this.Name = "TechHome";
            this.Text = "TechHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startUpBtn;
        private Button weeklyBtn;
        private Button signOutBtn;
        private Label label1;
        private Button dailyBtn;
    }
}