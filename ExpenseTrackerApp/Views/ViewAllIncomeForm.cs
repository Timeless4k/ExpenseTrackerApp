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
    public partial class ViewAllIncomeForm : Form
    {
        private readonly DbContextOptions<ExpenseContext> _options;
        private readonly int _userId;

        public ViewAllIncomeForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            lblUserName.Text = SessionManager.IsLoggedIn()
                ? $"Hi, {SessionManager.CurrentUser.FirstName}!"
                : "Hi, Guest!";

            LoadIncomeData(); // Load the initial income data
        }

        private void LoadIncomeData()
        {
            using var context = new ExpenseContext(_options);
            var incomes = context.Income
                .Where(i => i.UserId == _userId)
                .ToList();

            dgvAllIncome.DataSource = incomes;

            var totalIncome = incomes.Sum(i => i.Amount) ?? 0;
            lblTotalIncome.Text = $"Total Income: ${totalIncome:F2}";

            if (dgvAllIncome.Columns["Date"] != null)
            {
                dgvAllIncome.Columns["Date"].DefaultCellStyle.Format = "d";
            }

            HideUnnecessaryColumns(dgvAllIncome, "Id", "UserId");
            AddEditDeleteButtons(); // Add buttons for editing and deleting
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

        private void AddEditDeleteButtons()
        {
            if (!dgvAllIncome.Columns.Contains("Edit"))
            {
                var editButton = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Action"
                };
                dgvAllIncome.Columns.Add(editButton);
            }

            if (!dgvAllIncome.Columns.Contains("Delete"))
            {
                var deleteButton = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dgvAllIncome.Columns.Add(deleteButton);
            }

            dgvAllIncome.CellContentClick -= DgvAllIncome_CellContentClick;
            dgvAllIncome.CellContentClick += DgvAllIncome_CellContentClick;
        }

        private void DgvAllIncome_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var incomeId = (int)dgvAllIncome.Rows[e.RowIndex].Cells["Id"].Value;

                if (dgvAllIncome.Columns[e.ColumnIndex].Name == "Edit")
                {
                    OpenEditIncomeForm(incomeId);
                }
                else if (dgvAllIncome.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DeleteIncome(incomeId);
                }
            }
        }

        private void OpenEditIncomeForm(int incomeId)
        {
            var editForm = new EditIncomeForm(incomeId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadIncomeData(); // Refresh the data after editing
            }
        }

        private void DeleteIncome(int incomeId)
        {
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this income?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                using var context = new ExpenseContext(_options);
                var income = context.Income.Find(incomeId);
                if (income != null)
                {
                    context.Income.Remove(income);
                    context.SaveChanges();
                    LoadIncomeData(); // Refresh the data after deletion
                }
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            using var context = new ExpenseContext(_options);
            var searchQuery = txtSearch.Text.ToLower();

            // Retrieve all income records for the user
            var allIncome = context.Income
                .Where(i => i.UserId == _userId)
                .ToList(); // Fetch data before filtering in-memory

            // Apply search filter in-memory to avoid EF restrictions on null-propagation
            var filteredIncome = allIncome
                .Where(i =>
                    (i.Source != null && i.Source.ToLower().Contains(searchQuery)) ||
                    (i.Amount != null && i.Amount.Value.ToString().Contains(searchQuery)) ||
                    i.Date.ToString("d").Contains(searchQuery))
                .ToList();

            // Bind the filtered data to the DataGridView
            dgvAllIncome.DataSource = filteredIncome;

            // Calculate the total income for the filtered results
            var totalIncome = filteredIncome.Sum(i => i.Amount) ?? 0;
            lblTotalIncome.Text = $"Total Income: ${totalIncome:F2}";
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            var addIncomeForm = new AddIncomeForm(_userId);
            if (addIncomeForm.ShowDialog() == DialogResult.OK)
            {
                LoadIncomeData(); // Refresh after adding new income
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashboardForm();
            dashboardForm.Show();
            Close();
        }

        private void btnViewAllExpenses_Click(object sender, EventArgs e)
        {
            var viewAllExpensesForm = new ViewAllExpensesForm(_userId);
            viewAllExpensesForm.Show();
            Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings not implemented yet.");
        }
    }
}
