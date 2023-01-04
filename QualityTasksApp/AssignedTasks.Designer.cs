namespace QualityTasksApp
{
    partial class AssignedTasks
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
            this.taskDisplay = new System.Windows.Forms.DataGridView();
            this.employeesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.completeRadioBtn = new System.Windows.Forms.RadioButton();
            this.incompleteRadioBtn = new System.Windows.Forms.RadioButton();
            this.versionComboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.taskDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // taskDisplay
            // 
            this.taskDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskDisplay.Location = new System.Drawing.Point(69, 171);
            this.taskDisplay.Name = "taskDisplay";
            this.taskDisplay.RowHeadersWidth = 62;
            this.taskDisplay.RowTemplate.Height = 33;
            this.taskDisplay.Size = new System.Drawing.Size(1120, 534);
            this.taskDisplay.TabIndex = 0;
            // 
            // employeesComboBox
            // 
            this.employeesComboBox.FormattingEnabled = true;
            this.employeesComboBox.Location = new System.Drawing.Point(115, 50);
            this.employeesComboBox.Name = "employeesComboBox";
            this.employeesComboBox.Size = new System.Drawing.Size(182, 33);
            this.employeesComboBox.TabIndex = 1;
            this.employeesComboBox.SelectedIndexChanged += new System.EventHandler(this.employeesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Line";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(689, 44);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(300, 31);
            this.fromDate.TabIndex = 3;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(689, 110);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(300, 31);
            this.toDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(689, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1022, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(556, 724);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(117, 112);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(182, 33);
            this.typeComboBox.TabIndex = 10;
            // 
            // completeRadioBtn
            // 
            this.completeRadioBtn.AutoSize = true;
            this.completeRadioBtn.Location = new System.Drawing.Point(527, 41);
            this.completeRadioBtn.Name = "completeRadioBtn";
            this.completeRadioBtn.Size = new System.Drawing.Size(114, 29);
            this.completeRadioBtn.TabIndex = 12;
            this.completeRadioBtn.TabStop = true;
            this.completeRadioBtn.Text = "Complete";
            this.completeRadioBtn.UseVisualStyleBackColor = true;
            // 
            // incompleteRadioBtn
            // 
            this.incompleteRadioBtn.AutoSize = true;
            this.incompleteRadioBtn.Location = new System.Drawing.Point(527, 113);
            this.incompleteRadioBtn.Name = "incompleteRadioBtn";
            this.incompleteRadioBtn.Size = new System.Drawing.Size(126, 29);
            this.incompleteRadioBtn.TabIndex = 13;
            this.incompleteRadioBtn.TabStop = true;
            this.incompleteRadioBtn.Text = "Incomplete";
            this.incompleteRadioBtn.UseVisualStyleBackColor = true;
            // 
            // versionComboBox1
            // 
            this.versionComboBox1.FormattingEnabled = true;
            this.versionComboBox1.Location = new System.Drawing.Point(303, 50);
            this.versionComboBox1.Name = "versionComboBox1";
            this.versionComboBox1.Size = new System.Drawing.Size(182, 33);
            this.versionComboBox1.TabIndex = 14;
            this.versionComboBox1.SelectedIndexChanged += new System.EventHandler(this.versionComboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Version:";
            // 
            // AssignedTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 784);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.versionComboBox1);
            this.Controls.Add(this.incompleteRadioBtn);
            this.Controls.Add(this.completeRadioBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.employeesComboBox);
            this.Controls.Add(this.taskDisplay);
            this.Name = "AssignedTasks";
            this.Text = "AssignedTasks";
            this.Load += new System.EventHandler(this.AssignedTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView taskDisplay;
        private ComboBox employeesComboBox;
        private Label label1;
        private DateTimePicker fromDate;
        private DateTimePicker toDate;
        private Label label2;
        private Label label3;
        private Button button2;
        private Button button3;
        private Label label4;
        private ComboBox typeComboBox;
        private RadioButton completeRadioBtn;
        private RadioButton incompleteRadioBtn;
        private ComboBox versionComboBox1;
        private Label label5;
    }
}