namespace ExpenseTrackerApp.Views
{
    partial class AddIncomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblIncomeSource;
        private System.Windows.Forms.TextBox txtIncomeSource;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.TextBox txtIncomeAmount;
        private System.Windows.Forms.Label lblIncomeDate;
        private System.Windows.Forms.DateTimePicker dtpIncomeDate;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.Button btnCancel;

        // Dispose method to clean up resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Method to initialize components and UI elements
        private void InitializeComponent()
        {
            this.lblIncomeSource = new System.Windows.Forms.Label();
            this.txtIncomeSource = new System.Windows.Forms.TextBox();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.txtIncomeAmount = new System.Windows.Forms.TextBox();
            this.lblIncomeDate = new System.Windows.Forms.Label();
            this.dtpIncomeDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIncomeSource
            // 
            this.lblIncomeSource.AutoSize = true;
            this.lblIncomeSource.Location = new System.Drawing.Point(12, 15);
            this.lblIncomeSource.Name = "lblIncomeSource";
            this.lblIncomeSource.Size = new System.Drawing.Size(90, 19);
            this.lblIncomeSource.TabIndex = 0;
            this.lblIncomeSource.Text = "Income Source:";
            this.lblIncomeSource.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // txtIncomeSource
            // 
            this.txtIncomeSource.Location = new System.Drawing.Point(150, 12);
            this.txtIncomeSource.Name = "txtIncomeSource";
            this.txtIncomeSource.Size = new System.Drawing.Size(220, 25);
            this.txtIncomeSource.TabIndex = 1;
            this.txtIncomeSource.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtIncomeSource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIncomeSource.ForeColor = System.Drawing.Color.Black;
            // 
            // lblIncomeAmount
            // 
            this.lblIncomeAmount.AutoSize = true;
            this.lblIncomeAmount.Location = new System.Drawing.Point(12, 55);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(100, 19);
            this.lblIncomeAmount.TabIndex = 2;
            this.lblIncomeAmount.Text = "Income Amount:";
            this.lblIncomeAmount.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // txtIncomeAmount
            // 
            this.txtIncomeAmount.Location = new System.Drawing.Point(150, 52);
            this.txtIncomeAmount.Name = "txtIncomeAmount";
            this.txtIncomeAmount.Size = new System.Drawing.Size(220, 25);
            this.txtIncomeAmount.TabIndex = 3;
            this.txtIncomeAmount.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtIncomeAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIncomeAmount.ForeColor = System.Drawing.Color.Black;
            // 
            // lblIncomeDate
            // 
            this.lblIncomeDate.AutoSize = true;
            this.lblIncomeDate.Location = new System.Drawing.Point(12, 95);
            this.lblIncomeDate.Name = "lblIncomeDate";
            this.lblIncomeDate.Size = new System.Drawing.Size(80, 19);
            this.lblIncomeDate.TabIndex = 4;
            this.lblIncomeDate.Text = "Income Date:";
            this.lblIncomeDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // dtpIncomeDate
            // 
            this.dtpIncomeDate.Location = new System.Drawing.Point(150, 92);
            this.dtpIncomeDate.Name = "dtpIncomeDate";
            this.dtpIncomeDate.Size = new System.Drawing.Size(220, 25);
            this.dtpIncomeDate.TabIndex = 5;
            this.dtpIncomeDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.dtpIncomeDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtpIncomeDate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnAddIncome
            // 
            this.btnAddIncome.Location = new System.Drawing.Point(150, 130);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(100, 35);
            this.btnAddIncome.TabIndex = 6;
            this.btnAddIncome.Text = "Add Income";
            this.btnAddIncome.UseVisualStyleBackColor = true;
            this.btnAddIncome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddIncome.ForeColor = System.Drawing.Color.White;
            this.btnAddIncome.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnAddIncome.FlatStyle = FlatStyle.Flat;
            this.btnAddIncome.FlatAppearance.BorderSize = 0;
            this.btnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AddIncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddIncome);
            this.Controls.Add(this.dtpIncomeDate);
            this.Controls.Add(this.lblIncomeDate);
            this.Controls.Add(this.txtIncomeAmount);
            this.Controls.Add(this.lblIncomeAmount);
            this.Controls.Add(this.txtIncomeSource);
            this.Controls.Add(this.lblIncomeSource);
            this.Name = "AddIncomeForm";
            this.Text = "Add Income";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
