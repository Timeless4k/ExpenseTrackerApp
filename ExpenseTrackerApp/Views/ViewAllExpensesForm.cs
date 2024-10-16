using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ExpenseTrackerApp.Controllers;

namespace ExpenseTrackerApp.Views
{
    public partial class ViewAllExpensesForm : Form
    {
        private readonly DbContextOptions<ExpenseContext> _options;
        private readonly int _userId;

        public ViewAllExpensesForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Create DbContextOptions for ExpenseContext
            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            // Set the user name in the label
            if (SessionManager.IsLoggedIn())
            {
                lblUserName.Text = $"Hi, {SessionManager.CurrentUser.FirstName}!";  
            }
            else
            {
                lblUserName.Text = "Hi, Guest!";
            }

            LoadExpenses(); // Load expenses data when the form loads
        }

        // Method to load expenses data
        private void LoadExpenses()
        {
            using (var context = new ExpenseContext(_options))
            {
                var expenseRepository = new ExpenseRepository(context);
                var expenses = expenseRepository.GetById(_userId);
                dgvAllExpenses.DataSource = expenses;

                // Format date to show only the date
                if (dgvAllExpenses.Columns["Date"] != null)
                {
                    dgvAllExpenses.Columns["Date"].DefaultCellStyle.Format = "d"; // Displays only the date
                }

                // Hide unnecessary columns
                HideUnnecessaryColumns(dgvAllExpenses, "Id", "UserId");
            }
        }

        // Method to hide unnecessary columns in the DataGridView
        private void HideUnnecessaryColumns(DataGridView dataGridView, params string[] columnsToHide)
        {
            foreach (var column in columnsToHide)
            {
                if (dataGridView.Columns[column] != null)
                {
                    dataGridView.Columns[column].Visible = false;
                }
            }
        }

        // Event handler for the Back to Dashboard button click
        private void BtnBackToDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close(); // Close the current form and return to the Dashboard
        }

        // Event handler for the Dashboard button click
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close(); // Go back to the dashboard
        }

        // Event handler for the View All Income button click
        private void btnViewAllIncome_Click(object sender, EventArgs e)
        {
            var viewAllIncomeForm = new ViewAllIncomeForm(_userId);
            viewAllIncomeForm.Show();
            this.Hide(); // Hide the current form instead of closing it
        }

        // Event handler for the Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close(); // Go back to login form
        }

        // Event handler for the Settings button click (optional)
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings not implemented yet.");
        }
    }
}
