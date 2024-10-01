namespace ExpenseTrackerApp.Views
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnSwitchToLogin;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnSwitchToLogin = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 30);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Expense Tracker";

            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 0;

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 1;

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.PasswordChar = '*';

            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.LightGreen;
            this.btnSignUp.Location = new System.Drawing.Point(150, 200);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(100, 30);
            this.btnSignUp.TabIndex = 3;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.BtnSignUp_Click);

            // 
            // btnSwitchToLogin
            // 
            this.btnSwitchToLogin.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSwitchToLogin.Location = new System.Drawing.Point(150, 250);
            this.btnSwitchToLogin.Name = "btnSwitchToLogin";
            this.btnSwitchToLogin.Size = new System.Drawing.Size(100, 30);
            this.btnSwitchToLogin.TabIndex = 9;
            this.btnSwitchToLogin.Text = "Back to Login";
            this.btnSwitchToLogin.UseVisualStyleBackColor = true;
            this.btnSwitchToLogin.Click += new System.EventHandler(this.BtnSwitchToLogin_Click);

            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(120, 290);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 4;

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";

            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSwitchToLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername);
            this.Name = "SignUpForm";
            this.Text = "Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
