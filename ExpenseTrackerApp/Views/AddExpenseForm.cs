using System;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
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

            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            _expenseController = new ExpenseController(new ExpenseRepository(new ExpenseContext(options)));
            CustomizeUI();
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtExpenseName.Text.Trim();
                decimal amount = decimal.Parse(txtExpenseAmount.Text.Trim());
                string category = txtExpenseCategory.Text.Trim();
                DateTime date = dtpExpenseDate.Value;

                bool success = _expenseController.AddExpense(_userId, name, amount, category, date);

                if (success)
                {
                    MessageBox.Show("Expense added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
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

        private void ClearFields()
        {
            txtExpenseName.Clear();
            txtExpenseAmount.Clear();
            txtExpenseCategory.Clear();
            dtpExpenseDate.Value = DateTime.Now;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomizeUI()
        {
            this.BackColor = System.Drawing.Color.White;
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
