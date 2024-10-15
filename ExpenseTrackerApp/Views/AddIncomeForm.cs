// Views/AddIncomeForm.cs
using System;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;
using ExpenseTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExpenseTrackerApp.Views
{
    public partial class AddIncomeForm : Form
    {
        private readonly IncomeController _incomeController;
        private readonly int _userId;

        public AddIncomeForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Create the DbContextOptions for ExpenseContext
            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            _incomeController = new IncomeController(new IncomeRepository(new ExpenseContext(options)));
            CustomizeUI();
        }

        // Button click event handler to add income
        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user inputs
                string source = txtIncomeSource.Text.Trim();
                decimal amount = decimal.Parse(txtIncomeAmount.Text.Trim());
                DateTime date = dtpIncomeDate.Value;

                // Call the IncomeController to add the income
                bool success = _incomeController.AddIncome(_userId, amount, source, date);

                if (success)
                {
                    MessageBox.Show("Income added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // Reset fields after successful submission
                }
                else
                {
                    MessageBox.Show("Failed to add income. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtIncomeSource.Clear();
            txtIncomeAmount.Clear();
            dtpIncomeDate.Value = DateTime.Now; // Reset date picker to current date
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
            btnAddIncome.FlatStyle = FlatStyle.Flat;
            btnAddIncome.BackColor = System.Drawing.Color.SteelBlue;
            btnAddIncome.ForeColor = System.Drawing.Color.White;
            btnAddIncome.FlatAppearance.BorderSize = 0;
            btnAddIncome.Font = new Font("Segoe UI", 10, FontStyle.Bold);

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
