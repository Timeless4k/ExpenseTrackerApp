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
        // Initialize the timer inline to ensure it's non-null
        private readonly System.Windows.Forms.Timer dashboardTimer = new System.Windows.Forms.Timer();
        private readonly DbContextOptions<ExpenseContext> _options;
        private decimal remainingBudget;

        public DashboardForm()
        {
            InitializeComponent();

            // Initialize DbContext options
            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            InitializeDashboardTimer(); // Set up the timer
            LoadDashboardData(); // Load data initially
        }

        private void InitializeDashboardTimer()
        {
            dashboardTimer.Interval = 1000; // Set the interval to  seconds
            dashboardTimer.Tick += OnDashboardTimerTick; // Attach the Tick event
            dashboardTimer.Start(); // Start the timer
        }

        private void OnDashboardTimerTick(object? sender, EventArgs e)
        {
            if (this.ContainsFocus) // Refresh only if the dashboard is active
                LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            if (!SessionManager.IsLoggedIn())
            {
                PromptLogin();
                return;
            }

            using (var context = new ExpenseContext(_options))
            {
                var expenseRepository = new ExpenseRepository(context);
                var incomeRepository = new IncomeRepository(context);
                var userId = SessionManager.CurrentUser.Id;

                lblUserName.Text = $"Hi, {SessionManager.CurrentUser.FirstName}!";
                LoadRecentTransactions(expenseRepository, incomeRepository, userId);
                UpdateBudgetInfo(incomeRepository, expenseRepository, userId);
            }
        }

        private void PromptLogin()
        {
            MessageBox.Show("You need to log in first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            new LoginForm().Show();
            this.Hide();
        }

        private void LoadRecentTransactions(ExpenseRepository expenseRepo, IncomeRepository incomeRepo, int userId)
        {
            dgvExpenses.DataSource = expenseRepo.GetRecentExpensesByUserId(userId);
            dgvIncome.DataSource = incomeRepo.GetRecentIncomesByUserId(userId);

            FormatDateColumns(dgvExpenses, "Date");
            FormatDateColumns(dgvIncome, "Date");

            HideUnnecessaryColumns(dgvExpenses, "Id", "UserId");
            HideUnnecessaryColumns(dgvIncome, "Id", "UserId");

            AddEditAndDeleteColumns(dgvExpenses);
            AddEditAndDeleteColumns(dgvIncome);
        }

        private void FormatDateColumns(DataGridView gridView, string columnName)
        {
            if (gridView.Columns[columnName] != null)
                gridView.Columns[columnName].DefaultCellStyle.Format = "d";
        }

        private void UpdateBudgetInfo(IncomeRepository incomeRepo, ExpenseRepository expenseRepo, int userId)
        {
            var incomes = incomeRepo.GetRecentIncomesByUserId(userId);
            var expenses = expenseRepo.GetRecentExpensesByUserId(userId);

            // Use GetValueOrDefault() to handle nullable decimals
            decimal totalIncome = incomes.Sum(i => i.Amount.GetValueOrDefault());
            decimal totalExpense = expenses.Sum(e => e.Amount.GetValueOrDefault());

            remainingBudget = totalIncome - totalExpense;
            int budgetPercentage = CalculateBudgetPercentage(totalIncome, remainingBudget);

            lblTotalBudget.Text = $"Total Budget: ${totalIncome:F2}";
            lblRemainingBudget.Text = $"Remaining Budget: ${remainingBudget:F2}";
            pbRemainingBudget.Value = budgetPercentage;
            UpdateProgressBarColor(budgetPercentage);
        }


        private int CalculateBudgetPercentage(decimal totalIncome, decimal remaining)
        {
            if (totalIncome == 0) return 0;
            return Math.Max(0, Math.Min(100, (int)((remaining / totalIncome) * 100)));
        }

        private void UpdateProgressBarColor(int percentage)
        {
            if (percentage < 30)
                pbRemainingBudget.ForeColor = System.Drawing.Color.Green;
            else if (percentage < 60)
                pbRemainingBudget.ForeColor = System.Drawing.Color.Yellow;
            else
                pbRemainingBudget.ForeColor = System.Drawing.Color.Red;
        }

        private void HideUnnecessaryColumns(DataGridView gridView, params string[] columns)
        {
            foreach (var column in columns)
            {
                if (gridView.Columns[column] != null)
                    gridView.Columns[column].Visible = false;
            }
        }

        private void AddEditAndDeleteColumns(DataGridView gridView)
        {
            if (!gridView.Columns.Contains("ActionEdit"))
                gridView.Columns.Insert(0, CreateButtonColumn("ActionEdit", "Edit"));

            if (!gridView.Columns.Contains("ActionDelete"))
                gridView.Columns.Insert(1, CreateButtonColumn("ActionDelete", "Delete"));
        }

        private DataGridViewButtonColumn CreateButtonColumn(string name, string text)
        {
            return new DataGridViewButtonColumn
            {
                HeaderText = text,
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true
            };
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            PauseTimerWhileEditing();
            new AddExpenseForm(SessionManager.CurrentUser.Id).ShowDialog();
            ResumeTimer();
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            PauseTimerWhileEditing();
            new AddIncomeForm(SessionManager.CurrentUser.Id).ShowDialog();
            ResumeTimer();
        }

        private void btnViewAllIncome_Click(object sender, EventArgs e)
        {
            PauseTimerWhileEditing();
            new ViewAllIncomeForm(SessionManager.CurrentUser.Id).Show();
            this.Close();
        }

        private void btnViewAllExpenses_Click(object sender, EventArgs e)
        {
            PauseTimerWhileEditing();
            new ViewAllExpensesForm(SessionManager.CurrentUser.Id).Show();
            this.Close();
        }

        private void PauseTimerWhileEditing() => dashboardTimer.Stop();
        private void ResumeTimer() => dashboardTimer.Start();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (confirmLogout == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Hide();
                new LoginForm().Show();
            }
        }

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleGridViewButtonClick(e, dgvExpenses, "expense");
        }

        private void dgvIncome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleGridViewButtonClick(e, dgvIncome, "income");
        }

        private void HandleGridViewButtonClick(DataGridViewCellEventArgs e, DataGridView gridView, string type)
        {
            if (e.RowIndex < 0) return;

            var id = (int)gridView.Rows[e.RowIndex].Cells["Id"].Value;

            if (e.ColumnIndex == gridView.Columns["ActionEdit"].Index)
            {
                ShowEditForm(id, type);
            }
            else if (e.ColumnIndex == gridView.Columns["ActionDelete"].Index)
            {
                ConfirmAndDeleteRecord(id, type);
            }
        }

        private void ShowEditForm(int id, string type)
        {
            Form editForm = type == "expense"
                ? new EditExpenseForm(id)
                : new EditIncomeForm(id);

            PauseTimerWhileEditing();
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadDashboardData();
            ResumeTimer();
        }

        private void ConfirmAndDeleteRecord(int id, string type)
        {
            var confirmResult = MessageBox.Show($"Are you sure you want to delete this {type}?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (var context = new ExpenseContext(_options))
                {
                    bool success = type == "expense"
                        ? new ExpenseRepository(context).Delete(id)
                        : new IncomeRepository(context).Delete(id);

                    if (success)
                    {
                        MessageBox.Show($"{type} deleted successfully.", "Success");
                        LoadDashboardData();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete {type}.", "Error");
                    }
                }
            }
        }
    }
}
