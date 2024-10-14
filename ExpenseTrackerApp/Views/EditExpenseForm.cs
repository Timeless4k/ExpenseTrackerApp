using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;

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
            _expenseController = new ExpenseController(new ExpenseRepository(new ExpenseContext()));
            LoadExpenseDetails();
        }

        // Load the existing expense details to populate the form fields
        private void LoadExpenseDetails()
        {
            using (var context = new ExpenseContext())
            {
                var expenseRepository = new ExpenseRepository(context);
                var expense = expenseRepository.GetRecentExpensesByUserId(_expenseId).FirstOrDefault();  // Assuming that the method will fetch by ID

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
                    this.Close();  // Close the form if the expense isn't found
                }
            }
        }

        // Save button click event to update the expense
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Get updated user inputs
                string name = txtExpenseName.Text.Trim();
                decimal amount = decimal.Parse(txtExpenseAmount.Text.Trim());
                string category = txtExpenseCategory.Text.Trim();
                DateTime date = dtpExpenseDate.Value;

                // Update the expense using the controller
                bool success = _expenseController.UpdateExpense(_expenseId, name, amount, category, date);

                if (success)
                {
                    MessageBox.Show("Expense updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Close the form after successful update
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

        // Cancel button click event to close the form without saving
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
