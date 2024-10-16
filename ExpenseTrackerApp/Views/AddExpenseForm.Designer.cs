namespace ExpenseTrackerApp.Views
{
    partial class AddExpenseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblExpenseName;
        private System.Windows.Forms.TextBox txtExpenseName;
        private System.Windows.Forms.Label lblExpenseAmount;
        private System.Windows.Forms.TextBox txtExpenseAmount;
        private System.Windows.Forms.Label lblExpenseCategory;
        private System.Windows.Forms.TextBox txtExpenseCategory;
        private System.Windows.Forms.Label lblExpenseDate;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private System.Windows.Forms.Button btnAddExpense;
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
            this.lblExpenseName = new System.Windows.Forms.Label();
            this.txtExpenseName = new System.Windows.Forms.TextBox();
            this.lblExpenseAmount = new System.Windows.Forms.Label();
            this.txtExpenseAmount = new System.Windows.Forms.TextBox();
            this.lblExpenseCategory = new System.Windows.Forms.Label();
            this.txtExpenseCategory = new System.Windows.Forms.TextBox();
            this.lblExpenseDate = new System.Windows.Forms.Label();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblExpenseName
            // 
            this.lblExpenseName.AutoSize = true;
            this.lblExpenseName.Location = new System.Drawing.Point(12, 15);
            this.lblExpenseName.Name = "lblExpenseName";
            this.lblExpenseName.Size = new System.Drawing.Size(95, 19);
            this.lblExpenseName.TabIndex = 0;
            this.lblExpenseName.Text = "Expense Name:";
            this.lblExpenseName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // txtExpenseName
            // 
            this.txtExpenseName.Location = new System.Drawing.Point(150, 12);
            this.txtExpenseName.Name = "txtExpenseName";
            this.txtExpenseName.Size = new System.Drawing.Size(220, 25);
            this.txtExpenseName.TabIndex = 1;
            this.txtExpenseName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtExpenseName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExpenseName.ForeColor = System.Drawing.Color.Black;
            // 
            // lblExpenseAmount
            // 
            this.lblExpenseAmount.AutoSize = true;
            this.lblExpenseAmount.Location = new System.Drawing.Point(12, 55);
            this.lblExpenseAmount.Name = "lblExpenseAmount";
            this.lblExpenseAmount.Size = new System.Drawing.Size(110, 19);
            this.lblExpenseAmount.TabIndex = 2;
            this.lblExpenseAmount.Text = "Expense Amount:";
            this.lblExpenseAmount.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // txtExpenseAmount
            // 
            this.txtExpenseAmount.Location = new System.Drawing.Point(150, 52);
            this.txtExpenseAmount.Name = "txtExpenseAmount";
            this.txtExpenseAmount.Size = new System.Drawing.Size(220, 25);
            this.txtExpenseAmount.TabIndex = 3;
            this.txtExpenseAmount.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtExpenseAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExpenseAmount.ForeColor = System.Drawing.Color.Black;
            // 
            // lblExpenseCategory
            // 
            this.lblExpenseCategory.AutoSize = true;
            this.lblExpenseCategory.Location = new System.Drawing.Point(12, 95);
            this.lblExpenseCategory.Name = "lblExpenseCategory";
            this.lblExpenseCategory.Size = new System.Drawing.Size(116, 19);
            this.lblExpenseCategory.TabIndex = 4;
            this.lblExpenseCategory.Text = "Expense Category:";
            this.lblExpenseCategory.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // txtExpenseCategory
            // 
            this.txtExpenseCategory.Location = new System.Drawing.Point(150, 92);
            this.txtExpenseCategory.Name = "txtExpenseCategory";
            this.txtExpenseCategory.Size = new System.Drawing.Size(220, 25);
            this.txtExpenseCategory.TabIndex = 5;
            this.txtExpenseCategory.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtExpenseCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExpenseCategory.ForeColor = System.Drawing.Color.Black;
            // 
            // lblExpenseDate
            // 
            this.lblExpenseDate.AutoSize = true;
            this.lblExpenseDate.Location = new System.Drawing.Point(12, 135);
            this.lblExpenseDate.Name = "lblExpenseDate";
            this.lblExpenseDate.Size = new System.Drawing.Size(87, 19);
            this.lblExpenseDate.TabIndex = 6;
            this.lblExpenseDate.Text = "Expense Date:";
            this.lblExpenseDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Location = new System.Drawing.Point(150, 132);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(220, 25);
            this.dtpExpenseDate.TabIndex = 7;
            this.dtpExpenseDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.dtpExpenseDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtpExpenseDate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Location = new System.Drawing.Point(150, 170);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(100, 35);
            this.btnAddExpense.TabIndex = 8;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddExpense.ForeColor = System.Drawing.Color.White;
            this.btnAddExpense.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnAddExpense.FlatStyle = FlatStyle.Flat;
            this.btnAddExpense.FlatAppearance.BorderSize = 0;
            this.btnAddExpense.Click += new System.EventHandler(this.BtnAddExpense_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AddExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.dtpExpenseDate);
            this.Controls.Add(this.lblExpenseDate);
            this.Controls.Add(this.txtExpenseCategory);
            this.Controls.Add(this.lblExpenseCategory);
            this.Controls.Add(this.txtExpenseAmount);
            this.Controls.Add(this.lblExpenseAmount);
            this.Controls.Add(this.txtExpenseName);
            this.Controls.Add(this.lblExpenseName);
            this.Name = "AddExpenseForm";
            this.Text = "Add Expense";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
