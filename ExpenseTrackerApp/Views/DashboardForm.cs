using System;
using System.Linq;
using System.Windows.Forms;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ExpenseTrackerApp.Controllers;

namespace ExpenseTrackerApp.Views
{
    public partial class DashboardForm : Form
    {
        private readonly DbContextOptions<ExpenseContext> _options;
        private decimal remainingBudget;
        private System.Windows.Forms.Timer dashboardTimer; // Use System.Windows.Forms.Timer for UI updates

        public DashboardForm()
        {
            InitializeComponent();

            // Create the DbContextOptions for ExpenseContext once, at class level
            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            // Initialize the Timer to refresh dashboard data every second
            dashboardTimer = new System.Windows.Forms.Timer();  // Use Windows Forms Timer
            dashboardTimer.Interval = 1000;  // 1000 ms = 1 second
            dashboardTimer.Tick += OnDashboardTimerTick;  // Use Tick instead of Elapsed for Windows Forms Timer
            dashboardTimer.Start();

            // Load dashboard data initially
            LoadDashboardData();
        }

        // Method to refresh dashboard data every second
        private void OnDashboardTimerTick(object? sender, EventArgs e)
        {
            LoadDashboardData();
        }


        // Load and refresh data on the dashboard
        private void LoadDashboardData()
        {
            if (!SessionManager.IsLoggedIn())
            {
                MessageBox.Show("You need to log in first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
                return;
            }

            using (var context = new ExpenseContext(_options))
            {
                var expenseRepository = new ExpenseRepository(context);
                var incomeRepository = new IncomeRepository(context);

                // Get the current user's ID and Name from SessionManager
                var userId = SessionManager.CurrentUser.Id;
                lblUserName.Text = $"Hi, {SessionManager.CurrentUser.FirstName}!";

                // Load recent expenses
                var expenses = expenseRepository.GetRecentExpensesByUserId(userId);
                dgvExpenses.DataSource = expenses;

                // Load recent incomes
                var incomes = incomeRepository.GetRecentIncomesByUserId(userId);
                dgvIncome.DataSource = incomes;

                // Set the date format for the 'Date' columns (assuming the column name is 'Date')
                if (dgvExpenses.Columns["Date"] != null)
                {
                    dgvExpenses.Columns["Date"].DefaultCellStyle.Format = "d"; // Displays date only
                }

                if (dgvIncome.Columns["Date"] != null)
                {
                    dgvIncome.Columns["Date"].DefaultCellStyle.Format = "d"; // Displays date only
                }

                // Calculate total budget by summing up all income
                decimal totalBudget = incomes.Sum(i => i.Amount);

                // Calculate remaining budget (Total Income - Total Expense)
                decimal totalIncome = incomes.Sum(i => i.Amount);
                decimal totalExpense = expenses.Sum(e => e.Amount);
                remainingBudget = totalIncome - totalExpense;

                // Calculate the percentage for the ProgressBar
                int budgetPercentage = (int)((remainingBudget / totalBudget) * 100);

                // Clamp the value to be within 0 and 100 to avoid out-of-range exceptions
                budgetPercentage = Math.Max(0, Math.Min(100, budgetPercentage));

                // Update labels and ProgressBar
                lblTotalBudget.Text = $"Total Budget: ${totalBudget}";
                lblRemainingBudget.Text = $"Remaining Budget: ${remainingBudget}";
                pbRemainingBudget.Value = budgetPercentage;

                // Customize table display by hiding unnecessary columns
                HideUnnecessaryColumns(dgvExpenses, "Id", "UserId");
                HideUnnecessaryColumns(dgvIncome, "Id", "UserId");

                // Add Edit/Delete columns after loading data
                AddEditAndDeleteColumns(dgvExpenses);
                AddEditAndDeleteColumns(dgvIncome);
            }
        }

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

        // Add Edit and Delete buttons to DataGridView
        private void AddEditAndDeleteColumns(DataGridView dataGridView)
        {
            if (dataGridView.Columns["ActionEdit"] == null)
            {
                var btnEdit = new DataGridViewButtonColumn
                {
                    HeaderText = "Edit",
                    Name = "ActionEdit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView.Columns.Insert(0, btnEdit);
            }

            if (dataGridView.Columns["ActionDelete"] == null)
            {
                var btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "ActionDelete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridView.Columns.Insert(1, btnDelete);
            }
        }

        // Handle the AddExpense button click
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm(SessionManager.CurrentUser.Id);
            addExpenseForm.ShowDialog();  // Open the form modally, dashboard stays open
        }

        // Handle the AddIncome button click
        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            AddIncomeForm addIncomeForm = new AddIncomeForm(SessionManager.CurrentUser.Id);
            addIncomeForm.ShowDialog();  // Open the form modally, dashboard stays open
        }

        // Handle the View All Income button click
        private void btnViewAllIncome_Click(object sender, EventArgs e)
        {
            // Create the ViewAllIncomeForm and show it
            ViewAllIncomeForm viewAllIncomeForm = new ViewAllIncomeForm(SessionManager.CurrentUser.Id);
            viewAllIncomeForm.Show();

            // Close the current dashboard form to prevent reopening
            this.Close();
        }

        // Handle the View All Expenses button click
        private void btnViewAllExpenses_Click(object sender, EventArgs e)
        {
            // Create the ViewAllExpensesForm and show it
            ViewAllExpensesForm viewAllExpensesForm = new ViewAllExpensesForm(SessionManager.CurrentUser.Id);
            viewAllExpensesForm.Show();

            // Close the current dashboard form to prevent reopening
            this.Close();
        }

        // Handle the Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Handle DataGridView Expenses CellContentClick for editing and deleting
        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // Ignore header clicks

            // Handle Edit button click in the DataGridView for Expenses
            if (e.ColumnIndex == dgvExpenses.Columns["ActionEdit"].Index)
            {
                int expenseId = (int)dgvExpenses.Rows[e.RowIndex].Cells["Id"].Value;
                using (EditExpenseForm editExpenseForm = new EditExpenseForm(expenseId))
                {
                    DialogResult dialogResult = editExpenseForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        LoadDashboardData();  // Refresh the dashboard data after the edit
                    }
                }
            }

            // Handle Delete button click in the DataGridView for Expenses
            if (e.ColumnIndex == dgvExpenses.Columns["ActionDelete"].Index)
            {
                int expenseId = (int)dgvExpenses.Rows[e.RowIndex].Cells["Id"].Value;
                var confirmResult = MessageBox.Show("Are you sure to delete this expense?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (var context = new ExpenseContext(_options))
                    {
                        var expenseRepository = new ExpenseRepository(context);
                        bool success = expenseRepository.Delete(expenseId);

                        if (success)
                        {
                            MessageBox.Show("Expense deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDashboardData(); // Refresh the data after deleting
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete expense.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Handle DataGridView Income CellContentClick for editing and deleting
        private void dgvIncome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // Ignore header clicks

            // Handle Edit button click in the DataGridView for Income
            if (e.ColumnIndex == dgvIncome.Columns["ActionEdit"].Index)
            {
                int incomeId = (int)dgvIncome.Rows[e.RowIndex].Cells["Id"].Value;
                EditIncomeForm editIncomeForm = new EditIncomeForm(incomeId);
                editIncomeForm.ShowDialog();  // Keep dashboard open
            }

            // Handle Delete button click in the DataGridView for Income
            if (e.ColumnIndex == dgvIncome.Columns["ActionDelete"].Index)
            {
                int incomeId = (int)dgvIncome.Rows[e.RowIndex].Cells["Id"].Value;
                var confirmResult = MessageBox.Show("Are you sure to delete this income?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (var context = new ExpenseContext(_options))
                    {
                        var incomeRepository = new IncomeRepository(context);
                        bool success = incomeRepository.Delete(incomeId);

                        if (success)
                        {
                            MessageBox.Show("Income deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDashboardData(); // Refresh the data after deleting
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete income.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
