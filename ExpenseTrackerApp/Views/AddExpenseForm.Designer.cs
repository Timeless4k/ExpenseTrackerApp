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
            lblExpenseName = new Label();
            txtExpenseName = new TextBox();
            lblExpenseAmount = new Label();
            txtExpenseAmount = new TextBox();
            lblExpenseCategory = new Label();
            txtExpenseCategory = new TextBox();
            lblExpenseDate = new Label();
            dtpExpenseDate = new DateTimePicker();
            btnAddExpense = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblExpenseName
            // 
            lblExpenseName.AutoSize = true;
            lblExpenseName.Font = new Font("Segoe UI", 10F);
            lblExpenseName.Location = new Point(14, 17);
            lblExpenseName.Margin = new Padding(4, 0, 4, 0);
            lblExpenseName.Name = "lblExpenseName";
            lblExpenseName.Size = new Size(101, 19);
            lblExpenseName.TabIndex = 0;
            lblExpenseName.Text = "Expense Name:";
            // 
            // txtExpenseName
            // 
            txtExpenseName.BackColor = Color.WhiteSmoke;
            txtExpenseName.Font = new Font("Segoe UI", 10F);
            txtExpenseName.ForeColor = Color.Black;
            txtExpenseName.Location = new Point(175, 14);
            txtExpenseName.Margin = new Padding(4, 3, 4, 3);
            txtExpenseName.Name = "txtExpenseName";
            txtExpenseName.Size = new Size(256, 25);
            txtExpenseName.TabIndex = 1;
            // 
            // lblExpenseAmount
            // 
            lblExpenseAmount.AutoSize = true;
            lblExpenseAmount.Font = new Font("Segoe UI", 10F);
            lblExpenseAmount.Location = new Point(14, 63);
            lblExpenseAmount.Margin = new Padding(4, 0, 4, 0);
            lblExpenseAmount.Name = "lblExpenseAmount";
            lblExpenseAmount.Size = new Size(115, 19);
            lblExpenseAmount.TabIndex = 2;
            lblExpenseAmount.Text = "Expense Amount:";
            // 
            // txtExpenseAmount
            // 
            txtExpenseAmount.BackColor = Color.WhiteSmoke;
            txtExpenseAmount.Font = new Font("Segoe UI", 10F);
            txtExpenseAmount.ForeColor = Color.Black;
            txtExpenseAmount.Location = new Point(175, 60);
            txtExpenseAmount.Margin = new Padding(4, 3, 4, 3);
            txtExpenseAmount.Name = "txtExpenseAmount";
            txtExpenseAmount.Size = new Size(256, 25);
            txtExpenseAmount.TabIndex = 3;
            // 
            // lblExpenseCategory
            // 
            lblExpenseCategory.AutoSize = true;
            lblExpenseCategory.Font = new Font("Segoe UI", 10F);
            lblExpenseCategory.Location = new Point(14, 110);
            lblExpenseCategory.Margin = new Padding(4, 0, 4, 0);
            lblExpenseCategory.Name = "lblExpenseCategory";
            lblExpenseCategory.Size = new Size(121, 19);
            lblExpenseCategory.TabIndex = 4;
            lblExpenseCategory.Text = "Expense Category:";
            // 
            // txtExpenseCategory
            // 
            txtExpenseCategory.BackColor = Color.WhiteSmoke;
            txtExpenseCategory.Font = new Font("Segoe UI", 10F);
            txtExpenseCategory.ForeColor = Color.Black;
            txtExpenseCategory.Location = new Point(175, 106);
            txtExpenseCategory.Margin = new Padding(4, 3, 4, 3);
            txtExpenseCategory.Name = "txtExpenseCategory";
            txtExpenseCategory.Size = new Size(256, 25);
            txtExpenseCategory.TabIndex = 5;
            // 
            // lblExpenseDate
            // 
            lblExpenseDate.AutoSize = true;
            lblExpenseDate.Font = new Font("Segoe UI", 10F);
            lblExpenseDate.Location = new Point(14, 156);
            lblExpenseDate.Margin = new Padding(4, 0, 4, 0);
            lblExpenseDate.Name = "lblExpenseDate";
            lblExpenseDate.Size = new Size(94, 19);
            lblExpenseDate.TabIndex = 6;
            lblExpenseDate.Text = "Expense Date:";
            // 
            // dtpExpenseDate
            // 
            dtpExpenseDate.BackColor = Color.WhiteSmoke;
            dtpExpenseDate.Font = new Font("Segoe UI", 10F);
            dtpExpenseDate.ForeColor = Color.Black;
            dtpExpenseDate.Location = new Point(175, 152);
            dtpExpenseDate.Margin = new Padding(4, 3, 4, 3);
            dtpExpenseDate.Name = "dtpExpenseDate";
            dtpExpenseDate.Size = new Size(256, 25);
            dtpExpenseDate.TabIndex = 7;
            // 
            // btnAddExpense
            // 
            btnAddExpense.BackColor = Color.SteelBlue;
            btnAddExpense.FlatAppearance.BorderSize = 0;
            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddExpense.ForeColor = Color.White;
            btnAddExpense.Location = new Point(175, 196);
            btnAddExpense.Margin = new Padding(4, 3, 4, 3);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(117, 40);
            btnAddExpense.TabIndex = 8;
            btnAddExpense.Text = "Add Expense";
            btnAddExpense.UseVisualStyleBackColor = false;
            btnAddExpense.Click += BtnAddExpense_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(315, 196);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 40);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // AddExpenseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 254);
            Controls.Add(btnCancel);
            Controls.Add(btnAddExpense);
            Controls.Add(dtpExpenseDate);
            Controls.Add(lblExpenseDate);
            Controls.Add(txtExpenseCategory);
            Controls.Add(lblExpenseCategory);
            Controls.Add(txtExpenseAmount);
            Controls.Add(lblExpenseAmount);
            Controls.Add(txtExpenseName);
            Controls.Add(lblExpenseName);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddExpenseForm";
            Text = "Add Expense";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
