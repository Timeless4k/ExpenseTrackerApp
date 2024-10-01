using System;
using System.Windows.Forms;
using ExpenseTrackerApp.Controllers;
using ExpenseTrackerApp.Data;

namespace ExpenseTrackerApp.Views
{
    public partial class AddIncomeForm : Form
    {
        public AddIncomeForm()
        {
            InitializeComponent();
        }

        // Event handler for adding income
        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            decimal amount;
            bool isAmountValid = decimal.TryParse(txtAmount.Text, out amount);
            DateTime date = dtpDate.Value;

            if (string.IsNullOrEmpty(source) || !isAmountValid || amount <= 0)
            {
                lblMessage.Text = "Please provide valid income details!";
                return;
            }

            using (var context = new ExpenseContext())
            {
                var incomeRepository = new IncomeRepository(context);
                bool result = incomeRepository.AddIncome(SessionManager.CurrentUser.Id, amount, source, date);

                if (result)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Income added successfully!";
                    ClearFields();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Failed to add income!";
                }
            }
        }

        private void ClearFields()
        {
            txtSource.Clear();
            txtAmount.Clear();
            dtpDate.Value = DateTime.Today;
        }
    }
}
