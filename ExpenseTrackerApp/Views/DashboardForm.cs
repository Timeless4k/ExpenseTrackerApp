using System;
using System.Linq;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExpenseTrackerApp.Views
{
    public partial class DashboardForm : Form
    {
        private System.Windows.Forms.Timer _refreshTimer = new System.Windows.Forms.Timer();
        private readonly DbContextOptions<ExpenseContext> _options;

        public DashboardForm()
        {
            InitializeComponent();

            // Create the DbContextOptions for ExpenseContext once, at class level
            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            StartAutoRefresh();
            LoadDashboardData();
        }

        // Initialize and start the auto-refresh timer
        private void StartAutoRefresh()
        {
            _refreshTimer.Interval = 1000;  // Set interval to 1 second (1000 ms)
            _refreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
            _refreshTimer.Start();
        }

        // Timer Tick event handler that triggers data reload every second
        private void RefreshTimer_Tick(object? sender, EventArgs e)
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
                var budgetRepository = new BudgetRepository(context);
                var expenseRepository = new ExpenseRepository(context);
                var incomeRepository = new IncomeRepository(context);

                // Get the current user's ID from SessionManager
                var userId = SessionManager.CurrentUser.Id;

                // Load and display recent expenses in DataGridView
                var expenses = expenseRepository.GetRecentExpensesByUserId(userId);
                dgvExpenses.DataSource = expenses;

                // Add Edit and Delete buttons to the Expenses DataGridView (if not already added)
                if (dgvExpenses.Columns["ActionEdit"] == null)
                {
                    var btnEditExpense = new DataGridViewButtonColumn
                    {
                        HeaderText = "Action",
                        Name = "ActionEdit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    dgvExpenses.Columns.Insert(0, btnEditExpense);
                }

                if (dgvExpenses.Columns["ActionDelete"] == null)
                {
                    var btnDeleteExpense = new DataGridViewButtonColumn
                    {
                        HeaderText = "Action",
                        Name = "ActionDelete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dgvExpenses.Columns.Insert(1, btnDeleteExpense);
                }

                // Hide columns you don't want to show in the Expenses table
                if (dgvExpenses.Columns["Id"] != null)
                {
                    dgvExpenses.Columns["Id"].Visible = false;
                }
                if (dgvExpenses.Columns["UserId"] != null)
                {
                    dgvExpenses.Columns["UserId"].Visible = false;
                }
                if (dgvExpenses.Columns["User"] != null)
                {
                    dgvExpenses.Columns["User"].Visible = false;
                }

                // Set column widths to show full date for Expenses
                dgvExpenses.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Load and display recent incomes in DataGridView
                var incomes = incomeRepository.GetRecentIncomesByUserId(userId);
                dgvIncome.DataSource = incomes;

                // Prevent adding the "Action" column multiple times for Income
                if (dgvIncome.Columns["ActionEdit"] == null)
                {
                    var btnEditIncome = new DataGridViewButtonColumn
                    {
                        HeaderText = "Action",
                        Name = "ActionEdit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    dgvIncome.Columns.Insert(0, btnEditIncome);
                }

                if (dgvIncome.Columns["ActionDelete"] == null)
                {
                    var btnDeleteIncome = new DataGridViewButtonColumn
                    {
                        HeaderText = "Action",
                        Name = "ActionDelete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dgvIncome.Columns.Insert(1, btnDeleteIncome);
                }

                // Hide columns you don't want to show in the Income table
                if (dgvIncome.Columns["Id"] != null)
                {
                    dgvIncome.Columns["Id"].Visible = false;
                }
                if (dgvIncome.Columns["UserId"] != null)
                {
                    dgvIncome.Columns["UserId"].Visible = false;
                }
                if (dgvIncome.Columns["User"] != null)
                {
                    dgvIncome.Columns["User"].Visible = false;
                }

                // Set column widths to show full date for Income
                dgvIncome.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        // Handle the AddExpense button click
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            var userId = SessionManager.CurrentUser.Id;
            AddExpenseForm addExpenseForm = new AddExpenseForm(userId);
            addExpenseForm.Show();
        }

        // Handle the AddIncome button click
        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            var userId = SessionManager.CurrentUser.Id;
            AddIncomeForm addIncomeForm = new AddIncomeForm(userId);
            addIncomeForm.Show();
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
            // Handle Edit button click in the DataGridView for Expenses
            if (e.ColumnIndex == dgvExpenses.Columns["ActionEdit"].Index && e.RowIndex >= 0)
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
            if (e.ColumnIndex == dgvExpenses.Columns["ActionDelete"].Index && e.RowIndex >= 0)
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
            // Handle Edit button click in the DataGridView for Income
            if (e.ColumnIndex == dgvIncome.Columns["ActionEdit"].Index && e.RowIndex >= 0)
            {
                int incomeId = (int)dgvIncome.Rows[e.RowIndex].Cells["Id"].Value;
                EditIncomeForm editIncomeForm = new EditIncomeForm(incomeId);
                editIncomeForm.ShowDialog();
            }

            // Handle Delete button click in the DataGridView for Income
            if (e.ColumnIndex == dgvIncome.Columns["ActionDelete"].Index && e.RowIndex >= 0)
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
