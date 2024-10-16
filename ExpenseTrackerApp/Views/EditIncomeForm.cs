using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExpenseTrackerApp.Views
{
    public partial class EditIncomeForm : Form
    {
        private readonly int _incomeId;
        private readonly ExpenseContext _context;
        private readonly IncomeRepository _incomeRepository;

        public EditIncomeForm(int incomeId)
        {
            InitializeComponent();
            _incomeId = incomeId;

            // Properly initialize DbContext with options
            var options = new DbContextOptionsBuilder<ExpenseContext>()
                .UseMySQL(ConfigurationManager.ConnectionStrings["ExpenseTrackerDB"].ConnectionString)
                .Options;

            _context = new ExpenseContext(options); // Create a single context instance
            _incomeRepository = new IncomeRepository(_context);
            LoadIncomeDetails();
        }

        private void LoadIncomeDetails()
        {
            // Fetch the income from the database
            var income = _incomeRepository.GetById(_incomeId);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIncomeSource.Text))
            {
                MessageBox.Show("Please enter a valid income source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.TryParse(txtIncomeAmount.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    // Attach the existing entity to the context
                    var existingIncome = _incomeRepository.GetById(_incomeId);
                    if (existingIncome == null)
                    {
                        MessageBox.Show("Income not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update the income properties
                    existingIncome.Source = txtIncomeSource.Text;
                    existingIncome.Amount = amount;
                    existingIncome.Date = dtpIncomeDate.Value;

                    // Mark the entity as modified
                    _context.Entry(existingIncome).State = EntityState.Modified;
                    bool result = _context.SaveChanges() > 0;

                    if (result)
                    {
                        MessageBox.Show("Income updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
