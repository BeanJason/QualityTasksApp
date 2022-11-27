namespace QualityTasksApp
{
    partial class Signup
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
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.password2 = new System.Windows.Forms.TextBox();
            this.Signup_SubmitBtn = new System.Windows.Forms.Button();
            this.Signup_BackBtn = new System.Windows.Forms.Button();
            this.Error_label = new System.Windows.Forms.Label();
            this.isManager = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(320, 108);
            this.firstName.Name = "firstName";
            this.firstName.PlaceholderText = "First Name";
            this.firstName.Size = new System.Drawing.Size(658, 31);
            this.firstName.TabIndex = 0;
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(320, 200);
            this.lastName.Name = "lastName";
            this.lastName.PlaceholderText = "Last Name";
            this.lastName.Size = new System.Drawing.Size(658, 31);
            this.lastName.TabIndex = 1;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(320, 278);
            this.email.Name = "email";
            this.email.PlaceholderText = "Email";
            this.email.Size = new System.Drawing.Size(658, 31);
            this.email.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(320, 365);
            this.password.Name = "password";
            this.password.PlaceholderText = "Password";
            this.password.Size = new System.Drawing.Size(658, 31);
            this.password.TabIndex = 3;
            // 
            // password2
            // 
            this.password2.Location = new System.Drawing.Point(320, 450);
            this.password2.Name = "password2";
            this.password2.PlaceholderText = "Re-enter Password";
            this.password2.Size = new System.Drawing.Size(658, 31);
            this.password2.TabIndex = 4;
            // 
            // Signup_SubmitBtn
            // 
            this.Signup_SubmitBtn.Location = new System.Drawing.Point(760, 591);
            this.Signup_SubmitBtn.Name = "Signup_SubmitBtn";
            this.Signup_SubmitBtn.Size = new System.Drawing.Size(209, 87);
            this.Signup_SubmitBtn.TabIndex = 5;
            this.Signup_SubmitBtn.Text = "Submit";
            this.Signup_SubmitBtn.UseVisualStyleBackColor = true;
            this.Signup_SubmitBtn.Click += new System.EventHandler(this.Signup_SubmitBtn_Click);
            // 
            // Signup_BackBtn
            // 
            this.Signup_BackBtn.Location = new System.Drawing.Point(320, 591);
            this.Signup_BackBtn.Name = "Signup_BackBtn";
            this.Signup_BackBtn.Size = new System.Drawing.Size(209, 87);
            this.Signup_BackBtn.TabIndex = 6;
            this.Signup_BackBtn.Text = "Back";
            this.Signup_BackBtn.UseVisualStyleBackColor = true;
            this.Signup_BackBtn.Click += new System.EventHandler(this.Signup_BackBtn_Click);
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.Location = new System.Drawing.Point(624, 498);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(0, 25);
            this.Error_label.TabIndex = 7;
            // 
            // isManager
            // 
            this.isManager.AutoSize = true;
            this.isManager.Location = new System.Drawing.Point(320, 517);
            this.isManager.Name = "isManager";
            this.isManager.Size = new System.Drawing.Size(108, 29);
            this.isManager.TabIndex = 8;
            this.isManager.Text = "Manager";
            this.isManager.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "*Will create new user with all manager functions only select if intended*";
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 889);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isManager);
            this.Controls.Add(this.Error_label);
            this.Controls.Add(this.Signup_BackBtn);
            this.Controls.Add(this.Signup_SubmitBtn);
            this.Controls.Add(this.password2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Name = "Signup";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox firstName;
        private TextBox lastName;
        private TextBox email;
        private TextBox password;
        private TextBox password2;
        private Button Signup_SubmitBtn;
        private Button Signup_BackBtn;
        private Label Error_label;
        private CheckBox isManager;
        private Label label1;
    }
}