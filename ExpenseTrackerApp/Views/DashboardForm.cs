using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboardData();
        }

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

            using (var context = new ExpenseContext())
            {
                var budgetRepository = new BudgetRepository(context);
                var expenseRepository = new ExpenseRepository(context);
                var incomeRepository = new IncomeRepository(context);

                // Get the current user's ID from SessionManager
                var userId = SessionManager.CurrentUser.Id;

                // Load and display budget information
                var budget = budgetRepository.GetBudgetByUserId(userId);
                lblTotalBudget.Text = budget != null
                    ? $"Total Budget: {budget.TotalBudget:C}"
                    : "Total Budget: Not Set";
                lblRemainingBudget.Text = budget != null
                    ? $"Remaining Budget: {budget.RemainingBudget:C}"
                    : "Remaining Budget: Not Set";

                // Load and display recent expenses
                var expenses = expenseRepository.GetRecentExpensesByUserId(userId);
                lstExpenses.Items.Clear();  // Clear the list before adding new items
                foreach (var expense in expenses)
                {
                    lstExpenses.Items.Add($"{expense.Name}: {expense.Amount:C} on {expense.Date.ToShortDateString()}");
                }

                // Load and display recent incomes
                var incomes = incomeRepository.GetRecentIncomesByUserId(userId);
                lstIncome.Items.Clear();  // Clear the income list before adding new items
                if (incomes != null && incomes.Count > 0)
                {
                    foreach (var income in incomes)
                    {
                        lstIncome.Items.Add($"{income.Source}: {income.Amount:C} on {income.Date.ToShortDateString()}");
                    }
                }
            }
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm();
            addExpenseForm.Show();
        }

        private void btnManageBudgets_Click(object sender, EventArgs e)
        {
            ManageBudgetsForm manageBudgetsForm = new ManageBudgetsForm();
            manageBudgetsForm.Show();
        }

        private void btnAddIncome_Click(object sender, EventArgs e)  // Added button for adding income
        {
            AddIncomeForm addIncomeForm = new AddIncomeForm();  // Assuming you have an AddIncomeForm
            addIncomeForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out the user and clear session
            SessionManager.Logout();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
