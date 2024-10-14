using System;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using System.Windows.Forms;

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
            _expenseController = new ExpenseController(new ExpenseRepository(new ExpenseContext()));
            CustomizeUI();
        }

        // Button click event handler to add expense
        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user inputs
                string name = txtExpenseName.Text.Trim();
                decimal amount = decimal.Parse(txtExpenseAmount.Text.Trim());
                string category = txtExpenseCategory.Text.Trim();
                DateTime date = dtpExpenseDate.Value;

                // Call the ExpenseController to add the expense
                bool success = _expenseController.AddExpense(_userId, name, amount, category, date);

                if (success)
                {
                    MessageBox.Show("Expense added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // Reset fields after successful submission
                }
                else
                {
                    MessageBox.Show("Failed to add expense. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Clears all fields in the form
        private void ClearFields()
        {
            txtExpenseName.Clear();
            txtExpenseAmount.Clear();
            txtExpenseCategory.Clear();
            dtpExpenseDate.Value = DateTime.Now; // Reset date picker to current date
        }

        // Button click event handler to close the form
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when user cancels
        }

        // Customize UI to make it more modern
        private void CustomizeUI()
        {
            // Set background color
            this.BackColor = System.Drawing.Color.White;

            // Customize buttons
            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.BackColor = System.Drawing.Color.SteelBlue;
            btnAddExpense.ForeColor = System.Drawing.Color.White;
            btnAddExpense.FlatAppearance.BorderSize = 0;
            btnAddExpense.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = System.Drawing.Color.LightGray;
            btnCancel.ForeColor = System.Drawing.Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10);

            // Set label and input font
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Font = new Font("Segoe UI", 10);
                }
                if (control is TextBox || control is DateTimePicker)
                {
                    control.Font = new Font("Segoe UI", 10);
                    control.BackColor = System.Drawing.Color.WhiteSmoke;
                    control.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
}
