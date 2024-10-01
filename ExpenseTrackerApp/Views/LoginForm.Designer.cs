namespace ExpenseTrackerApp.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblMessage;
        private Button btnLogin;
        private Button btnSwitchToSignUp;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            lblEmail = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            lblMessage = new Label();
            btnSwitchToSignUp = new Button();
            lblLogo = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 130);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 130);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(160, 180);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(120, 230);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 6;
            // 
            // btnSwitchToSignUp
            // 
            btnSwitchToSignUp.Location = new Point(131, 257);
            btnSwitchToSignUp.Name = "btnSwitchToSignUp";
            btnSwitchToSignUp.Size = new Size(150, 25);
            btnSwitchToSignUp.TabIndex = 7;
            btnSwitchToSignUp.Text = "Don't have an account? Sign Up";
            btnSwitchToSignUp.Click += BtnSwitchToSignUp_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblLogo.Location = new Point(66, 21);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(273, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Expense Tracker";
            // 
            // LoginForm
            // 
            ClientSize = new Size(376, 350);
            Controls.Add(lblLogo);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(btnLogin);
            Controls.Add(lblMessage);
            Controls.Add(btnSwitchToSignUp);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
