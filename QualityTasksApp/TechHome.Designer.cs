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
            this.signOutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lineComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startUpRadioBtn = new System.Windows.Forms.RadioButton();
            this.dailyRadioBtn = new System.Windows.Forms.RadioButton();
            this.weeklyBtn = new System.Windows.Forms.RadioButton();
            this.viewBtn = new System.Windows.Forms.Button();
            this.completeBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.incompleteTasks = new System.Windows.Forms.ComboBox();
            this.versionComboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signOutBtn
            // 
            this.signOutBtn.Location = new System.Drawing.Point(539, 822);
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
            this.label1.Location = new System.Drawing.Point(618, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lineComboBox
            // 
            this.lineComboBox.FormattingEnabled = true;
            this.lineComboBox.Location = new System.Drawing.Point(649, 251);
            this.lineComboBox.Name = "lineComboBox";
            this.lineComboBox.Size = new System.Drawing.Size(182, 33);
            this.lineComboBox.TabIndex = 4;
            this.lineComboBox.SelectedIndexChanged += new System.EventHandler(this.lineComboBox_SelectedIndexChanged);
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(649, 413);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(182, 33);
            this.typeComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Line";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type";
            // 
            // startUpRadioBtn
            // 
            this.startUpRadioBtn.AutoSize = true;
            this.startUpRadioBtn.Location = new System.Drawing.Point(618, 150);
            this.startUpRadioBtn.Name = "startUpRadioBtn";
            this.startUpRadioBtn.Size = new System.Drawing.Size(101, 29);
            this.startUpRadioBtn.TabIndex = 9;
            this.startUpRadioBtn.TabStop = true;
            this.startUpRadioBtn.Text = "Start Up";
            this.startUpRadioBtn.UseVisualStyleBackColor = true;
            // 
            // dailyRadioBtn
            // 
            this.dailyRadioBtn.AutoSize = true;
            this.dailyRadioBtn.Location = new System.Drawing.Point(724, 150);
            this.dailyRadioBtn.Name = "dailyRadioBtn";
            this.dailyRadioBtn.Size = new System.Drawing.Size(76, 29);
            this.dailyRadioBtn.TabIndex = 10;
            this.dailyRadioBtn.TabStop = true;
            this.dailyRadioBtn.Text = "Daily";
            this.dailyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // weeklyBtn
            // 
            this.weeklyBtn.AutoSize = true;
            this.weeklyBtn.Location = new System.Drawing.Point(806, 150);
            this.weeklyBtn.Name = "weeklyBtn";
            this.weeklyBtn.Size = new System.Drawing.Size(93, 29);
            this.weeklyBtn.TabIndex = 11;
            this.weeklyBtn.TabStop = true;
            this.weeklyBtn.Text = "Weekly";
            this.weeklyBtn.UseVisualStyleBackColor = true;
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(631, 475);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(221, 34);
            this.viewBtn.TabIndex = 12;
            this.viewBtn.Text = "View Incomplete Tasks";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // completeBtn
            // 
            this.completeBtn.Location = new System.Drawing.Point(618, 616);
            this.completeBtn.Name = "completeBtn";
            this.completeBtn.Size = new System.Drawing.Size(281, 69);
            this.completeBtn.TabIndex = 14;
            this.completeBtn.Text = "Mark as complete";
            this.completeBtn.UseVisualStyleBackColor = true;
            this.completeBtn.Click += new System.EventHandler(this.completeBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Incomplete tasks:";
            // 
            // incompleteTasks
            // 
            this.incompleteTasks.FormattingEnabled = true;
            this.incompleteTasks.Location = new System.Drawing.Point(618, 563);
            this.incompleteTasks.Name = "incompleteTasks";
            this.incompleteTasks.Size = new System.Drawing.Size(281, 33);
            this.incompleteTasks.TabIndex = 16;
            // 
            // versionComboBox1
            // 
            this.versionComboBox1.FormattingEnabled = true;
            this.versionComboBox1.Location = new System.Drawing.Point(649, 330);
            this.versionComboBox1.Name = "versionComboBox1";
            this.versionComboBox1.Size = new System.Drawing.Size(182, 33);
            this.versionComboBox1.TabIndex = 17;
            this.versionComboBox1.SelectedIndexChanged += new System.EventHandler(this.versionComboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Version";
            // 
            // TechHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 994);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.versionComboBox1);
            this.Controls.Add(this.incompleteTasks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.completeBtn);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.weeklyBtn);
            this.Controls.Add(this.dailyRadioBtn);
            this.Controls.Add(this.startUpRadioBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.lineComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signOutBtn);
            this.Name = "TechHome";
            this.Text = "TechHome";
            this.Load += new System.EventHandler(this.TechHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button signOutBtn;
        private Label label1;
        private ComboBox lineComboBox;
        private ComboBox typeComboBox;
        private Label label2;
        private Label label3;
        private RadioButton startUpRadioBtn;
        private RadioButton dailyRadioBtn;
        private RadioButton weeklyBtn;
        private Button viewBtn;
        private Button completeBtn;
        private Label label4;
        private ComboBox incompleteTasks;
        private ComboBox versionComboBox1;
        private Label label5;
    }
}