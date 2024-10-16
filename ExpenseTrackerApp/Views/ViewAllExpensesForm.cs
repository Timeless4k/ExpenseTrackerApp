using System;
using System.Linq;
using System.Collections.Generic; // Needed for List<T>
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

            // Set user name in the label
            if (SessionManager.IsLoggedIn())
            {
                lblUserName.Text = $"Hi, {SessionManager.CurrentUser.FirstName}!";
            }
            else
            {
                lblUserName.Text = "Hi, Guest!";
            }

            LoadExpenses(); // Load expenses data
        }

        // Load all expenses into the DataGridView
        private void LoadExpenses()
        {
            using (var context = new ExpenseContext(_options))
            {
                var expenseRepository = new ExpenseRepository(context);

                // Fetch all expenses for the user
                var expenses = expenseRepository.GetRecentExpensesByUserId(_userId);

                dgvAllExpenses.DataSource = expenses;

                // Calculate the total expenses, handling potential null values
                var totalAmount = expenses.Sum(e => e.Amount ?? 0);
                lblTotalExpenses.Text = $"Total Expenses: ${totalAmount:F2}";

                // Safely format the 'Date' column to display only the date
                var dateColumn = dgvAllExpenses.Columns["Date"];
                if (dateColumn != null && dateColumn.DefaultCellStyle != null)
                {
                    dateColumn.DefaultCellStyle.Format = "d";
                }
                else
                {
                    MessageBox.Show("Date column or DefaultCellStyle is missing.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Search expenses by criteria (name, category, or amount)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var context = new ExpenseContext(_options))
            {
                var searchQuery = txtSearch.Text.ToLower();

                var filteredExpenses = context.Expenses
                    .Where(e => e.UserId == _userId &&
                                (
                                    (e.Name != null && e.Name.ToLower().Contains(searchQuery)) ||
                                    (e.Category != null && e.Category.ToLower().Contains(searchQuery)) ||
                                    (e.Amount.HasValue && e.Amount.Value.ToString().Contains(searchQuery))
                                ))
                    .ToList();

                dgvAllExpenses.DataSource = filteredExpenses;
            }
        }

        // Event handler for Dashboard button click
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close();
        }

        // Event handler for View All Income button click
        private void btnViewAllIncome_Click(object sender, EventArgs e)
        {
            var incomeForm = new ViewAllIncomeForm(_userId);
            incomeForm.Show();
            this.Close();
        }

        // Event handler for Settings button click
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings are under development.");
        }
        // Event handler for Add Expense button click
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            var addExpenseForm = new AddExpenseForm(_userId);
            addExpenseForm.ShowDialog();
            LoadExpenses(); // Refresh the expenses after adding
        }


        // Event handler for Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
