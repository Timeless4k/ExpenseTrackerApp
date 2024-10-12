using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class EditIncomeForm : Form
    {
        private int _incomeId;  // Income ID to load the details
        private IncomeRepository _incomeRepository;

        public EditIncomeForm(int incomeId)
        {
            InitializeComponent();
            _incomeId = incomeId;
            _incomeRepository = new IncomeRepository(new ExpenseContext());
            LoadIncomeDetails();
        }

        // Load income details based on income ID
        private void LoadIncomeDetails()
        {
            var income = _incomeRepository.GetIncomeById(_incomeId);
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
            if (decimal.TryParse(txtIncomeAmount.Text, out decimal amount) && amount > 0)
            {
                var updatedIncome = new Income
                {
                    Id = _incomeId,
                    Source = txtIncomeSource.Text,
                    Amount = amount,
                    Date = dtpIncomeDate.Value
                };

                bool result = _incomeRepository.UpdateIncome(updatedIncome);

                if (result)
                {
                    MessageBox.Show("Income updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Close the form after saving
                }
                else
                {
                    MessageBox.Show("Failed to update income.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid income amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  // Close the form without saving
        }
    }
}
