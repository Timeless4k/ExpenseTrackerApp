using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ExpenseTrackerApp.Controllers;

namespace ExpenseTrackerApp.Views
{
    public partial class ViewAllIncomeForm : Form
    {
        private readonly DbContextOptions<ExpenseContext> _options;
        private readonly int _userId;

        public ViewAllIncomeForm(int userId)
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

            LoadIncomeData(); // Load income data when the form loads
        }

        // Method to load income data
        private void LoadIncomeData()
        {
            using (var context = new ExpenseContext(_options))
            {
                var incomeRepository = new IncomeRepository(context);
                var incomes = incomeRepository.GetById(_userId); // Fetch income data for the user
                dgvAllIncome.DataSource = incomes;

                // Format date to show only the date
                if (dgvAllIncome.Columns["Date"] != null)
                {
                    dgvAllIncome.Columns["Date"].DefaultCellStyle.Format = "d"; // Displays only the date
                }

                // Hide unnecessary columns
                HideUnnecessaryColumns(dgvAllIncome, "Id", "UserId");
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

        // Event handler for the View All Expenses button click
        private void btnViewAllExpenses_Click(object sender, EventArgs e)
        {
            var viewAllExpensesForm = new ViewAllExpensesForm(_userId);
            viewAllExpensesForm.Show();
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
