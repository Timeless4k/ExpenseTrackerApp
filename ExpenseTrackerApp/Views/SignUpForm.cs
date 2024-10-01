using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers; // Assuming UserRepository is in Controllers
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        // Event handler for the Sign Up button click
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "All fields are required!";
                return;
            }

            using (var context = new ExpenseContext())
            {
                var userRepository = new UserRepository(context);

                bool result = userRepository.CreateUser(firstName, lastName, email, password);

                if (result)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "User registered successfully!";
                    ClearFields();

                    // Redirect to LoginForm after successful registration
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide(); // Hide the sign-up form after registration
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Email already exists!";
                }
            }
        }

        // Clear input fields after success
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // Event handler for switching back to login form
        private void BtnSwitchToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
