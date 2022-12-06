namespace QualityTasksApp
{
    partial class addNewTankType
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
            this.linesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tankTypeDisplay = new System.Windows.Forms.DataGridView();
            this.viewTankTypesBtn = new System.Windows.Forms.Button();
            this.newTankTypeInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tankTypeDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // linesComboBox
            // 
            this.linesComboBox.FormattingEnabled = true;
            this.linesComboBox.Location = new System.Drawing.Point(147, 181);
            this.linesComboBox.Name = "linesComboBox";
            this.linesComboBox.Size = new System.Drawing.Size(182, 33);
            this.linesComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line";
            // 
            // tankTypeDisplay
            // 
            this.tankTypeDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tankTypeDisplay.Location = new System.Drawing.Point(707, 117);
            this.tankTypeDisplay.Name = "tankTypeDisplay";
            this.tankTypeDisplay.RowHeadersWidth = 62;
            this.tankTypeDisplay.RowTemplate.Height = 33;
            this.tankTypeDisplay.Size = new System.Drawing.Size(579, 664);
            this.tankTypeDisplay.TabIndex = 2;
            // 
            // viewTankTypesBtn
            // 
            this.viewTankTypesBtn.Location = new System.Drawing.Point(369, 181);
            this.viewTankTypesBtn.Name = "viewTankTypesBtn";
            this.viewTankTypesBtn.Size = new System.Drawing.Size(208, 67);
            this.viewTankTypesBtn.TabIndex = 3;
            this.viewTankTypesBtn.Text = "View Tank Types For This Line";
            this.viewTankTypesBtn.UseVisualStyleBackColor = true;
            this.viewTankTypesBtn.Click += new System.EventHandler(this.viewTankTypesBtn_Click);
            // 
            // newTankTypeInput
            // 
            this.newTankTypeInput.Location = new System.Drawing.Point(148, 285);
            this.newTankTypeInput.Name = "newTankTypeInput";
            this.newTankTypeInput.PlaceholderText = "Enter Part Number";
            this.newTankTypeInput.Size = new System.Drawing.Size(165, 31);
            this.newTankTypeInput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add Tank Type";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 65);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add Tank Type To Selected Line";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 747);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addNewTankType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 979);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newTankTypeInput);
            this.Controls.Add(this.viewTankTypesBtn);
            this.Controls.Add(this.tankTypeDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linesComboBox);
            this.Name = "addNewTankType";
            this.Text = "addNewTankType";
            this.Load += new System.EventHandler(this.addNewTankType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tankTypeDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox linesComboBox;
        private Label label1;
        private DataGridView tankTypeDisplay;
        private Button viewTankTypesBtn;
        private TextBox newTankTypeInput;
        private Label label2;
        private Button button2;
        private Button button1;
    }
}