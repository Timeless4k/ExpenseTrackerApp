using System;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

namespace ExpenseTrackerApp.Views
{
    public partial class AddExpenseForm : Form
    {
        private readonly ExpenseController _expenseController;
        private readonly int _userId;

        public AddExpenseForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            _expenseController = new ExpenseController(new ExpenseRepository(new ExpenseContext(options)));
            CustomizeUI();
        }

        // Add Expense button click event handler
        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtExpenseName.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a valid expense name.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtExpenseAmount.Text.Trim(), out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid positive amount.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string category = txtExpenseCategory.Text.Trim();
                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Please enter a valid expense category.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime date = dtpExpenseDate.Value;

                bool success = _expenseController.AddExpense(_userId, name, amount, category, date);

                if (success)
                {
                    MessageBox.Show("Expense added successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Set DialogResult to OK and close the form
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Close the form immediately
                }
                else
                {
                    MessageBox.Show("Failed to add expense. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid amount.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancel button click event handler
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Customize UI appearance
        private void CustomizeUI()
        {
            this.BackColor = Color.White;

            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.BackColor = Color.SteelBlue;
            btnAddExpense.ForeColor = Color.White;
            btnAddExpense.FlatAppearance.BorderSize = 0;
            btnAddExpense.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.LightGray;
            btnCancel.ForeColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10);

            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Font = new Font("Segoe UI", 10);
                }

                if (control is TextBox || control is DateTimePicker)
                {
                    control.Font = new Font("Segoe UI", 10);
                    control.BackColor = Color.WhiteSmoke;
                    control.ForeColor = Color.Black;
                }
            }
        }
    }
}
