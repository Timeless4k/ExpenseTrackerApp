namespace ExpenseTrackerApp.Views
{
    partial class EditIncomeForm
    {
        private System.Windows.Forms.Label lblIncomeSource;
        private System.Windows.Forms.TextBox txtIncomeSource;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.TextBox txtIncomeAmount;
        private System.Windows.Forms.Label lblIncomeDate;
        private System.Windows.Forms.DateTimePicker dtpIncomeDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblIncomeSource = new System.Windows.Forms.Label();
            this.txtIncomeSource = new System.Windows.Forms.TextBox();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.txtIncomeAmount = new System.Windows.Forms.TextBox();
            this.lblIncomeDate = new System.Windows.Forms.Label();
            this.dtpIncomeDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblIncomeSource
            this.lblIncomeSource.AutoSize = true;
            this.lblIncomeSource.Location = new System.Drawing.Point(12, 9);
            this.lblIncomeSource.Name = "lblIncomeSource";
            this.lblIncomeSource.Size = new System.Drawing.Size(90, 15);
            this.lblIncomeSource.TabIndex = 0;
            this.lblIncomeSource.Text = "Income Source:";

            // txtIncomeSource
            this.txtIncomeSource.Location = new System.Drawing.Point(12, 27);
            this.txtIncomeSource.Name = "txtIncomeSource";
            this.txtIncomeSource.Size = new System.Drawing.Size(200, 23);
            this.txtIncomeSource.TabIndex = 1;

            // lblIncomeAmount
            this.lblIncomeAmount.AutoSize = true;
            this.lblIncomeAmount.Location = new System.Drawing.Point(12, 53);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(96, 15);
            this.lblIncomeAmount.TabIndex = 2;
            this.lblIncomeAmount.Text = "Income Amount:";

            // txtIncomeAmount
            this.txtIncomeAmount.Location = new System.Drawing.Point(12, 71);
            this.txtIncomeAmount.Name = "txtIncomeAmount";
            this.txtIncomeAmount.Size = new System.Drawing.Size(200, 23);
            this.txtIncomeAmount.TabIndex = 3;

            // lblIncomeDate
            this.lblIncomeDate.AutoSize = true;
            this.lblIncomeDate.Location = new System.Drawing.Point(12, 97);
            this.lblIncomeDate.Name = "lblIncomeDate";
            this.lblIncomeDate.Size = new System.Drawing.Size(78, 15);
            this.lblIncomeDate.TabIndex = 4;
            this.lblIncomeDate.Text = "Income Date:";

            // dtpIncomeDate
            this.dtpIncomeDate.Location = new System.Drawing.Point(12, 115);
            this.dtpIncomeDate.Name = "dtpIncomeDate";
            this.dtpIncomeDate.Size = new System.Drawing.Size(200, 23);
            this.dtpIncomeDate.TabIndex = 5;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(137, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EditIncomeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 179);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpIncomeDate);
            this.Controls.Add(this.lblIncomeDate);
            this.Controls.Add(this.txtIncomeAmount);
            this.Controls.Add(this.lblIncomeAmount);
            this.Controls.Add(this.txtIncomeSource);
            this.Controls.Add(this.lblIncomeSource);
            this.Name = "EditIncomeForm";
            this.Text = "Edit Income";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
