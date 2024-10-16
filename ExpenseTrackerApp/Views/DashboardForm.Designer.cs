namespace ExpenseTrackerApp.Views
{
    partial class DashboardForm
    {
        private System.Windows.Forms.Label lblTotalBudget;
        private System.Windows.Forms.Label lblRemainingBudget;
        private System.Windows.Forms.ProgressBar pbRemainingBudget;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pbUserProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnViewAllIncome;
        private System.Windows.Forms.Button btnViewAllExpenses;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRecentExpenses;
        private System.Windows.Forms.Label lblRecentIncome;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.Button btnAddIncome;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            pnlSidebar = new Panel();
            pbUserProfile = new PictureBox();
            lblUserName = new Label();
            btnDashboard = new Button();
            btnViewAllIncome = new Button();
            btnViewAllExpenses = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            lblDashboardTitle = new Label();
            lblTotalBudget = new Label();
            lblRemainingBudget = new Label();
            pbRemainingBudget = new ProgressBar();
            lblRecentExpenses = new Label();
            dgvExpenses = new DataGridView();
            lblRecentIncome = new Label();
            dgvIncome = new DataGridView();
            btnAddExpense = new Button();
            btnAddIncome = new Button();
            pnlHeader = new Panel();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIncome).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);
            pnlSidebar.Controls.Add(pbUserProfile);
            pnlSidebar.Controls.Add(lblUserName);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnViewAllIncome);
            pnlSidebar.Controls.Add(btnViewAllExpenses);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 590);
            pnlSidebar.TabIndex = 0;
            // 
            // pbUserProfile
            // 
            pbUserProfile.Image = (Image)resources.GetObject("pbUserProfile.Image");
            pbUserProfile.Location = new Point(50, 30);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(100, 100);
            pbUserProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUserProfile.TabIndex = 0;
            pbUserProfile.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(25, 140);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(150, 30);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Hi, [User's Name]";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(25, 200);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(150, 40);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Dashboard";
            // 
            // btnViewAllIncome
            // 
            btnViewAllIncome.FlatStyle = FlatStyle.Flat;
            btnViewAllIncome.ForeColor = Color.White;
            btnViewAllIncome.Location = new Point(25, 250);
            btnViewAllIncome.Name = "btnViewAllIncome";
            btnViewAllIncome.Size = new Size(150, 40);
            btnViewAllIncome.TabIndex = 3;
            btnViewAllIncome.Text = "View All Income";
            btnViewAllIncome.Click += btnViewAllIncome_Click;
            // 
            // btnViewAllExpenses
            // 
            btnViewAllExpenses.FlatStyle = FlatStyle.Flat;
            btnViewAllExpenses.ForeColor = Color.White;
            btnViewAllExpenses.Location = new Point(25, 300);
            btnViewAllExpenses.Name = "btnViewAllExpenses";
            btnViewAllExpenses.Size = new Size(150, 40);
            btnViewAllExpenses.TabIndex = 4;
            btnViewAllExpenses.Text = "View All Expenses";
            btnViewAllExpenses.Click += btnViewAllExpenses_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(25, 350);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 40);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(25, 400);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.White;
            lblDashboardTitle.Location = new Point(220, 9);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(717, 43);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Your Financial Dashboard";
            lblDashboardTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalBudget
            // 
            lblTotalBudget.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalBudget.Location = new Point(220, 80);
            lblTotalBudget.Name = "lblTotalBudget";
            lblTotalBudget.Size = new Size(300, 30);
            lblTotalBudget.TabIndex = 2;
            lblTotalBudget.Text = "Total Budget: $1000.00";
            // 
            // lblRemainingBudget
            // 
            lblRemainingBudget.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRemainingBudget.Location = new Point(220, 120);
            lblRemainingBudget.Name = "lblRemainingBudget";
            lblRemainingBudget.Size = new Size(300, 30);
            lblRemainingBudget.TabIndex = 3;
            lblRemainingBudget.Text = "Remaining Budget: $456.00";
            // 
            // pbRemainingBudget
            // 
            pbRemainingBudget.Location = new Point(220, 160);
            pbRemainingBudget.Name = "pbRemainingBudget";
            pbRemainingBudget.Size = new Size(300, 20);
            pbRemainingBudget.TabIndex = 4;
            pbRemainingBudget.Value = 75;
            // 
            // lblRecentExpenses
            // 
            lblRecentExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecentExpenses.Location = new Point(220, 200);
            lblRecentExpenses.Name = "lblRecentExpenses";
            lblRecentExpenses.Size = new Size(200, 30);
            lblRecentExpenses.TabIndex = 5;
            lblRecentExpenses.Text = "Recent Expenses:";
            // 
            // dgvExpenses
            // 
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.Location = new Point(220, 240);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.Size = new Size(500, 140);
            dgvExpenses.TabIndex = 6;
            dgvExpenses.CellContentClick += dgvExpenses_CellContentClick;
            // 
            // lblRecentIncome
            // 
            lblRecentIncome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecentIncome.Location = new Point(220, 390);
            lblRecentIncome.Name = "lblRecentIncome";
            lblRecentIncome.Size = new Size(200, 30);
            lblRecentIncome.TabIndex = 7;
            lblRecentIncome.Text = "Recent Income:";
            // 
            // dgvIncome
            // 
            dgvIncome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncome.Location = new Point(220, 430);
            dgvIncome.Name = "dgvIncome";
            dgvIncome.ReadOnly = true;
            dgvIncome.Size = new Size(500, 140);
            dgvIncome.TabIndex = 8;
            dgvIncome.CellContentClick += dgvIncome_CellContentClick;
            // 
            // btnAddExpense
            // 
            btnAddExpense.BackColor = Color.FromArgb(72, 202, 228);
            btnAddExpense.FlatStyle = FlatStyle.Flat;
            btnAddExpense.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddExpense.ForeColor = Color.White;
            btnAddExpense.Location = new Point(220, 580);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(150, 40);
            btnAddExpense.TabIndex = 9;
            btnAddExpense.Text = "Add Expense";
            btnAddExpense.UseVisualStyleBackColor = false;
            btnAddExpense.Click += btnAddExpense_Click;
            // 
            // btnAddIncome
            // 
            btnAddIncome.BackColor = Color.FromArgb(72, 202, 228);
            btnAddIncome.FlatStyle = FlatStyle.Flat;
            btnAddIncome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddIncome.ForeColor = Color.White;
            btnAddIncome.Location = new Point(370, 580);
            btnAddIncome.Name = "btnAddIncome";
            btnAddIncome.Size = new Size(150, 40);
            btnAddIncome.TabIndex = 10;
            btnAddIncome.Text = "Add Income";
            btnAddIncome.UseVisualStyleBackColor = false;
            btnAddIncome.Click += btnAddIncome_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblDashboardTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 60);
            pnlHeader.TabIndex = 1;
            // 
            // DashboardForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Controls.Add(lblTotalBudget);
            Controls.Add(lblRemainingBudget);
            Controls.Add(pbRemainingBudget);
            Controls.Add(lblRecentExpenses);
            Controls.Add(dgvExpenses);
            Controls.Add(lblRecentIncome);
            Controls.Add(dgvIncome);
            Controls.Add(btnAddExpense);
            Controls.Add(btnAddIncome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIncome).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
