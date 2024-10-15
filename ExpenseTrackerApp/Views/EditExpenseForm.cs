using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExpenseTrackerApp.Views
{
    public partial class EditExpenseForm : Form
    {
        private readonly ExpenseController _expenseController;
        private readonly int _expenseId;

        public EditExpenseForm(int expenseId)
        {
            InitializeComponent();
            _expenseId = expenseId;

            // DbContextOptions to be used for connecting to the ExpenseContext
            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            _expenseController = new ExpenseController(new ExpenseRepository(new ExpenseContext(options)));
            LoadExpenseDetails();
        }

        // Load the expense details using the expenseId and populate the form fields
        private void LoadExpenseDetails()
        {
            var expense = _expenseController.GetExpenseById(_expenseId);

            if (expense != null)
            {
                txtExpenseName.Text = expense.Name;
                txtExpenseAmount.Text = expense.Amount.ToString();
                txtExpenseCategory.Text = expense.Category;
                dtpExpenseDate.Value = expense.Date;
            }
            else
            {
                MessageBox.Show("Expense not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Save button click event to update the expense details
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input values from the form fields
                string name = txtExpenseName.Text.Trim();
                decimal amount = decimal.Parse(txtExpenseAmount.Text.Trim());
                string category = txtExpenseCategory.Text.Trim();
                DateTime date = dtpExpenseDate.Value;

                // Update the expense using the controller
                bool success = _expenseController.UpdateExpense(_expenseId, name, amount, category, date);

                if (success)
                {
                    MessageBox.Show("Expense updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    MessageBox.Show("Failed to update expense. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancel button to close the form without saving
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
