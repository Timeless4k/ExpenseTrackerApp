namespace ExpenseTrackerApp.Views
{
    partial class DashboardForm
    {
        private System.Windows.Forms.Label lblTotalBudget;
        private System.Windows.Forms.Label lblRemainingBudget;
        private System.Windows.Forms.ListBox lstExpenses;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.Button btnManageBudgets;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRecentExpenses;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Button btnAddIncome;   // Button for adding income
        private System.Windows.Forms.ListBox lstIncome;   // Listbox for displaying recent incomes
        private System.Windows.Forms.Label lblRecentIncome;  // Label for income section

        private void InitializeComponent()
        {
            this.lblTotalBudget = new System.Windows.Forms.Label();
            this.lblRemainingBudget = new System.Windows.Forms.Label();
            this.lstExpenses = new System.Windows.Forms.ListBox();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.btnManageBudgets = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblRecentExpenses = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.btnAddIncome = new System.Windows.Forms.Button();  // AddIncome button
            this.lstIncome = new System.Windows.Forms.ListBox();    // List for income
            this.lblRecentIncome = new System.Windows.Forms.Label();  // Label for income
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // Header Panel
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlHeader.Controls.Add(this.lblDashboardTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;

            // Dashboard Title
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.White;
            this.lblDashboardTitle.Location = new System.Drawing.Point(12, 9);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(776, 42);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "Dashboard";
            this.lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Total Budget Label
            this.lblTotalBudget.AutoSize = true;
            this.lblTotalBudget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalBudget.Location = new System.Drawing.Point(50, 80);
            this.lblTotalBudget.Name = "lblTotalBudget";
            this.lblTotalBudget.Size = new System.Drawing.Size(112, 21);
            this.lblTotalBudget.TabIndex = 1;
            this.lblTotalBudget.Text = "Total Budget: ";

            // Remaining Budget Label
            this.lblRemainingBudget.AutoSize = true;
            this.lblRemainingBudget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRemainingBudget.Location = new System.Drawing.Point(50, 120);
            this.lblRemainingBudget.Name = "lblRemainingBudget";
            this.lblRemainingBudget.Size = new System.Drawing.Size(158, 21);
            this.lblRemainingBudget.TabIndex = 2;
            this.lblRemainingBudget.Text = "Remaining Budget: ";

            // Recent Expenses Label
            this.lblRecentExpenses.AutoSize = true;
            this.lblRecentExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRecentExpenses.Location = new System.Drawing.Point(50, 160);
            this.lblRecentExpenses.Name = "lblRecentExpenses";
            this.lblRecentExpenses.Size = new System.Drawing.Size(136, 21);
            this.lblRecentExpenses.TabIndex = 3;
            this.lblRecentExpenses.Text = "Recent Expenses:";

            // Expenses List
            this.lstExpenses.BackColor = System.Drawing.Color.White;
            this.lstExpenses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstExpenses.FormattingEnabled = true;
            this.lstExpenses.ItemHeight = 17;
            this.lstExpenses.Location = new System.Drawing.Point(50, 190);
            this.lstExpenses.Name = "lstExpenses";
            this.lstExpenses.Size = new System.Drawing.Size(500, 140);
            this.lstExpenses.TabIndex = 4;

            // Recent Income Label 
            this.lblRecentIncome.AutoSize = true;
            this.lblRecentIncome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRecentIncome.Location = new System.Drawing.Point(50, 340);
            this.lblRecentIncome.Name = "lblRecentIncome";
            this.lblRecentIncome.Size = new System.Drawing.Size(122, 21);
            this.lblRecentIncome.TabIndex = 5;
            this.lblRecentIncome.Text = "Recent Income:";

            // Income List 
            this.lstIncome.BackColor = System.Drawing.Color.White;
            this.lstIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstIncome.FormattingEnabled = true;
            this.lstIncome.ItemHeight = 17;
            this.lstIncome.Location = new System.Drawing.Point(50, 370);
            this.lstIncome.Name = "lstIncome";
            this.lstIncome.Size = new System.Drawing.Size(500, 140);
            this.lstIncome.TabIndex = 6;

            // Add Expense Button
            this.btnAddExpense.BackColor = System.Drawing.Color.FromArgb(72, 202, 228);
            this.btnAddExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExpense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddExpense.ForeColor = System.Drawing.Color.White;
            this.btnAddExpense.Location = new System.Drawing.Point(50, 530);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(150, 40);
            this.btnAddExpense.TabIndex = 7;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = false;

            // Add Income Button 
            this.btnAddIncome.BackColor = System.Drawing.Color.FromArgb(72, 202, 228);
            this.btnAddIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddIncome.ForeColor = System.Drawing.Color.White;
            this.btnAddIncome.Location = new System.Drawing.Point(230, 530);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(150, 40);
            this.btnAddIncome.TabIndex = 8;
            this.btnAddIncome.Text = "Add Income";
            this.btnAddIncome.UseVisualStyleBackColor = false;

            // Manage Budgets Button
            this.btnManageBudgets.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnManageBudgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBudgets.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnManageBudgets.ForeColor = System.Drawing.Color.White;
            this.btnManageBudgets.Location = new System.Drawing.Point(410, 530);
            this.btnManageBudgets.Name = "btnManageBudgets";
            this.btnManageBudgets.Size = new System.Drawing.Size(150, 40);
            this.btnManageBudgets.TabIndex = 9;
            this.btnManageBudgets.Text = "Manage Budgets";
            this.btnManageBudgets.UseVisualStyleBackColor = false;

            // Logout Button
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(255, 87, 34);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(590, 530);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;

            // DashboardForm Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblRecentIncome);
            this.Controls.Add(this.lstIncome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageBudgets);
            this.Controls.Add(this.btnAddIncome);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.lstExpenses);
            this.Controls.Add(this.lblRecentExpenses);
            this.Controls.Add(this.lblRemainingBudget);
            this.Controls.Add(this.lblTotalBudget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
