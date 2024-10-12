using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class DashboardForm : Form
    {
        private System.Windows.Forms.Timer _refreshTimer;

        public DashboardForm()
        {
            InitializeComponent();
            StartAutoRefresh();
            LoadDashboardData();
        }

        // Initialize and start the auto-refresh timer
        private void StartAutoRefresh()
        {
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000;  // Set interval to 1 second (1000 ms)
            _refreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
            _refreshTimer.Start();
        }

        // Timer Tick event handler that triggers data reload every second
        private void RefreshTimer_Tick(object sender, EventArgs e)
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

            using (var context = new ExpenseContext())
            {
                var budgetRepository = new BudgetRepository(context);
                var expenseRepository = new ExpenseRepository(context);
                var incomeRepository = new IncomeRepository(context);

                // Get the current user's ID from SessionManager
                var userId = SessionManager.CurrentUser.Id;

                // Load and display recent expenses in DataGridView
                var expenses = expenseRepository.GetRecentExpensesByUserId(userId);
                dgvExpenses.DataSource = expenses;

                // Load and display recent incomes in DataGridView
                var incomes = incomeRepository.GetRecentIncomesByUserId(userId);
                dgvIncome.DataSource = incomes;

                // Prevent adding the "Action" column multiple times
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

                // Hide columns you don't want to show
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

                // Set column widths to show full date
                dgvIncome.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            var userId = SessionManager.CurrentUser.Id;
            AddIncomeForm addIncomeForm = new AddIncomeForm(userId);
            addIncomeForm.Show();
        }

        private void dgvIncome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle Edit button click in the DataGridView
            if (e.ColumnIndex == dgvIncome.Columns["ActionEdit"].Index && e.RowIndex >= 0)
            {
                int incomeId = (int)dgvIncome.Rows[e.RowIndex].Cells["Id"].Value;  // Assuming 'Id' is the Income ID column
                EditIncomeForm editIncomeForm = new EditIncomeForm(incomeId);
                editIncomeForm.ShowDialog();  // Open Edit Income form for editing
            }

            // Handle Delete button click in the DataGridView
            if (e.ColumnIndex == dgvIncome.Columns["ActionDelete"].Index && e.RowIndex >= 0)
            {
                int incomeId = (int)dgvIncome.Rows[e.RowIndex].Cells["Id"].Value;
                var confirmResult = MessageBox.Show("Are you sure to delete this income?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (var context = new ExpenseContext())
                    {
                        var incomeRepository = new IncomeRepository(context);
                        bool success = incomeRepository.DeleteIncome(incomeId);

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
