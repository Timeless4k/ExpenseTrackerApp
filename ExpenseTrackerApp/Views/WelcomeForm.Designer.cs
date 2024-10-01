namespace ExpenseTrackerApp.Views
{
    partial class WelcomeForm
    {
        private System.ComponentModel.IContainer components = null;

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
            btnLogin = new Button();
            btnSignUp = new Button();
            labelWelcome = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 204, 113);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(71, 104);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(52, 152, 219);
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Location = new Point(71, 150);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(200, 40);
            btnSignUp.TabIndex = 1;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += BtnSignUp_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelWelcome.Location = new Point(37, 50);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(280, 22);
            labelWelcome.TabIndex = 2;
            labelWelcome.Text = "Welcome to Expense Tracker";
            // 
            // WelcomeForm
            // 
            ClientSize = new Size(350, 250);
            Controls.Add(btnLogin);
            Controls.Add(btnSignUp);
            Controls.Add(labelWelcome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label labelWelcome;
    }
}
