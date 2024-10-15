// Views/EditIncomeForm.cs
using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class EditIncomeForm : Form
    {
        private readonly int _incomeId;  // Income ID to load the details
        private readonly IncomeRepository _incomeRepository; // Set as readonly and initialized directly

        public EditIncomeForm(int incomeId)
        {
            InitializeComponent();
            _incomeId = incomeId;
            _incomeRepository = new IncomeRepository(new ExpenseContext()); // Ensure it's initialized
            LoadIncomeDetails();
        }

        // Load income details based on income ID
        private void LoadIncomeDetails()
        {
            var income = _incomeRepository.GetById(_incomeId); // Fixed method name
            if (income != null)
            {
                txtIncomeSource.Text = income.Source;
                txtIncomeAmount.Text = income.Amount.ToString();
                dtpIncomeDate.Value = income.Date;
            }
            else
            {
                MessageBox.Show("Income not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Save the updated income details
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the income source
            if (string.IsNullOrWhiteSpace(txtIncomeSource.Text))
            {
                MessageBox.Show("Please enter a valid income source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the amount
            if (decimal.TryParse(txtIncomeAmount.Text, out decimal amount) && amount > 0)
            {
                var updatedIncome = new Income
                {
                    Id = _incomeId,
                    Source = txtIncomeSource.Text,
                    Amount = amount,
                    Date = dtpIncomeDate.Value
                };

                try
                {
                    bool result = _incomeRepository.Update(updatedIncome); // Fixed method name

                    if (result)
                    {
                        MessageBox.Show("Income updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;  // Set result to OK for external handling
                        this.Close();  // Close the form after saving
                    }
                    else
                    {
                        MessageBox.Show("Failed to update income. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving income: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid income amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  // Set result to Cancel for external handling
            this.Close();  // Close the form without saving
        }
    }
}
