namespace ExpenseTrackerApp.Views
{
    partial class AddIncomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtSource
            this.txtSource.Location = new System.Drawing.Point(150, 30);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(200, 20);

            // txtAmount
            this.txtAmount.Location = new System.Drawing.Point(150, 70);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 20);

            // dtpDate
            this.dtpDate.Location = new System.Drawing.Point(150, 110);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);

            // btnAddIncome
            this.btnAddIncome.Location = new System.Drawing.Point(150, 150);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(100, 30);
            this.btnAddIncome.Text = "Add Income";
            this.btnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);

            // lblSource
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(50, 30);
            this.lblSource.Name = "lblSource";
            this.lblSource.Text = "Source:";

            // lblAmount
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(50, 70);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Text = "Amount:";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "Date:";

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(50, 200);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);

            // AddIncomeForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnAddIncome);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMessage);
            this.Text = "Add Income";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
