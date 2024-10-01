using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Event handler for the Login button click
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Both fields are required!";
                return;
            }

            using (var context = new ExpenseContext())
            {
                var userRepository = new UserRepository(context);
                var user = userRepository.GetUserByEmailAndPassword(email, password);

                if (user != null)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Login successful!";
                    SessionManager.SetCurrentUser(user);

                    // Redirect to the DashboardForm after successful login
                    DashboardForm dashboardForm = new DashboardForm();
                    dashboardForm.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid email or password!";
                }
            }
        }

        // Event handler for switching to the sign-up form
        private void BtnSwitchToSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }
}
