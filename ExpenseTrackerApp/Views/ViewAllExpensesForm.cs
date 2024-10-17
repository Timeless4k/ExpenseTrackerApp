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
    public partial class ViewAllExpensesForm : Form
    {
        private readonly DbContextOptions<ExpenseContext> _options;
        private readonly int _userId;

        public ViewAllExpensesForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            if (SessionManager.IsLoggedIn())
            {
                lblUserName.Text = $"Hi, {SessionManager.CurrentUser.FirstName}!";
            }
            else
            {
                lblUserName.Text = "Hi, Guest!";
            }

            LoadExpenses(); // Load expenses on form load
        }

        private void LoadExpenses()
        {
            using (var context = new ExpenseContext(_options))
            {
                var expenses = context.Expenses
                    .Where(e => e.UserId == _userId)
                    .ToList();

                dgvAllExpenses.DataSource = expenses;

                var totalAmount = expenses.Sum(e => e.Amount ?? 0);
                lblTotalExpenses.Text = $"Total Expenses: ${totalAmount:F2}";

                if (dgvAllExpenses.Columns["Date"] != null)
                {
                    dgvAllExpenses.Columns["Date"].DefaultCellStyle.Format = "d";
                }

                HideUnnecessaryColumns(dgvAllExpenses, "Id", "UserId");
                AddEditDeleteButtons();
            }
        }

        private void AddEditDeleteButtons()
        {
            if (!dgvAllExpenses.Columns.Contains("Edit"))
            {
                var editButton = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dgvAllExpenses.Columns.Add(editButton);
            }

            if (!dgvAllExpenses.Columns.Contains("Delete"))
            {
                var deleteButton = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dgvAllExpenses.Columns.Add(deleteButton);
            }

            dgvAllExpenses.CellContentClick -= DgvAllExpenses_CellContentClick;
            dgvAllExpenses.CellContentClick += DgvAllExpenses_CellContentClick;
        }

        private void DgvAllExpenses_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var expenseId = (int)dgvAllExpenses.Rows[e.RowIndex].Cells["Id"].Value;

                if (dgvAllExpenses.Columns[e.ColumnIndex].Name == "Edit")
                {
                    OpenEditExpenseForm(expenseId);
                }
                else if (dgvAllExpenses.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DeleteExpense(expenseId);
                }
            }
        }

        private void OpenEditExpenseForm(int expenseId)
        {
            var editForm = new EditExpenseForm(expenseId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadExpenses();
            }
        }

        private void DeleteExpense(int expenseId)
        {
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this expense?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                using (var context = new ExpenseContext(_options))
                {
                    var expense = context.Expenses.Find(expenseId);
                    if (expense != null)
                    {
                        context.Expenses.Remove(expense);
                        context.SaveChanges();
                        LoadExpenses();
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            using (var context = new ExpenseContext(_options))
            {
                var searchQuery = txtSearch.Text.ToLower();
                var filteredExpenses = context.Expenses
                    .Where(e => e.UserId == _userId &&
                        (
                            (e.Name != null && e.Name.ToLower().Contains(searchQuery)) ||
                            (e.Category != null && e.Category.ToLower().Contains(searchQuery)) ||
                            (e.Amount.HasValue && e.Amount.Value.ToString().Contains(searchQuery)) ||
                            e.Date.ToString("d").Contains(searchQuery)
                        ))
                    .ToList();

                dgvAllExpenses.DataSource = filteredExpenses;

                var totalFilteredAmount = filteredExpenses.Sum(e => e.Amount ?? 0);
                lblTotalExpenses.Text = $"Total Expenses: ${totalFilteredAmount:F2}";
            }
        }

        private void HideUnnecessaryColumns(DataGridView gridView, params string[] columnsToHide)
        {
            foreach (var column in columnsToHide)
            {
                if (gridView.Columns[column] != null)
                {
                    gridView.Columns[column].Visible = false;
                }
            }
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            var addExpenseForm = new AddExpenseForm(_userId);
            if (addExpenseForm.ShowDialog() == DialogResult.OK)
            {
                LoadExpenses();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Close();
        }

        private void btnViewAllIncome_Click(object sender, EventArgs e)
        {
            var incomeForm = new ViewAllIncomeForm(_userId);
            incomeForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings are under development.");
        }
    }
}
