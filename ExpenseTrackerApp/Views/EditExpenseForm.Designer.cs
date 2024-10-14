namespace ExpenseTrackerApp.Views
{
    partial class EditExpenseForm
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblExpenseName
            // 
            lblExpenseName.AutoSize = true;
            lblExpenseName.Location = new Point(26, 28);
            lblExpenseName.Name = "lblExpenseName";
            lblExpenseName.Size = new Size(88, 15);
            lblExpenseName.TabIndex = 0;
            lblExpenseName.Text = "Expense Name:";
            // 
            // txtExpenseName
            // 
            txtExpenseName.Location = new Point(136, 28);
            txtExpenseName.Name = "txtExpenseName";
            txtExpenseName.Size = new Size(176, 23);
            txtExpenseName.TabIndex = 1;
            // 
            // lblExpenseAmount
            // 
            lblExpenseAmount.AutoSize = true;
            lblExpenseAmount.Location = new Point(26, 66);
            lblExpenseAmount.Name = "lblExpenseAmount";
            lblExpenseAmount.Size = new Size(100, 15);
            lblExpenseAmount.TabIndex = 2;
            lblExpenseAmount.Text = "Expense Amount:";
            // 
            // txtExpenseAmount
            // 
            txtExpenseAmount.Location = new Point(136, 66);
            txtExpenseAmount.Name = "txtExpenseAmount";
            txtExpenseAmount.Size = new Size(176, 23);
            txtExpenseAmount.TabIndex = 3;
            // 
            // lblExpenseCategory
            // 
            lblExpenseCategory.AutoSize = true;
            lblExpenseCategory.Location = new Point(26, 103);
            lblExpenseCategory.Name = "lblExpenseCategory";
            lblExpenseCategory.Size = new Size(104, 15);
            lblExpenseCategory.TabIndex = 4;
            lblExpenseCategory.Text = "Expense Category:";
            // 
            // txtExpenseCategory
            // 
            txtExpenseCategory.Location = new Point(136, 103);
            txtExpenseCategory.Name = "txtExpenseCategory";
            txtExpenseCategory.Size = new Size(176, 23);
            txtExpenseCategory.TabIndex = 5;
            // 
            // lblExpenseDate
            // 
            lblExpenseDate.AutoSize = true;
            lblExpenseDate.Location = new Point(26, 141);
            lblExpenseDate.Name = "lblExpenseDate";
            lblExpenseDate.Size = new Size(80, 15);
            lblExpenseDate.TabIndex = 6;
            lblExpenseDate.Text = "Expense Date:";
            // 
            // dtpExpenseDate
            // 
            dtpExpenseDate.Location = new Point(136, 141);
            dtpExpenseDate.Name = "dtpExpenseDate";
            dtpExpenseDate.Size = new Size(176, 23);
            dtpExpenseDate.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(136, 188);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 33);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Location = new Point(233, 188);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 33);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // EditExpenseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 253);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpExpenseDate);
            Controls.Add(lblExpenseDate);
            Controls.Add(txtExpenseCategory);
            Controls.Add(lblExpenseCategory);
            Controls.Add(txtExpenseAmount);
            Controls.Add(lblExpenseAmount);
            Controls.Add(txtExpenseName);
            Controls.Add(lblExpenseName);
            Name = "EditExpenseForm";
            Text = "Edit Expense";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
