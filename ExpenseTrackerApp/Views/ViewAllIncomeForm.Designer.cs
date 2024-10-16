namespace ExpenseTrackerApp.Views
{
    partial class ViewAllIncomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvAllIncome;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pbUserProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnViewAllIncome;
        private System.Windows.Forms.Button btnViewAllExpenses;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;

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
            pnlSidebar = new Panel();
            pbUserProfile = new PictureBox();
            lblUserName = new Label();
            btnDashboard = new Button();
            btnViewAllIncome = new Button();
            btnViewAllExpenses = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            lblTitle = new Label();
            dgvAllIncome = new DataGridView();
            pnlHeader = new Panel();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllIncome).BeginInit();
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
            pnlSidebar.Size = new Size(200, 491);
            pnlSidebar.TabIndex = 0;
            // 
            // pbUserProfile
            // 
            pbUserProfile.Image = Properties.Resources.user;
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
            btnDashboard.Click += btnDashboard_Click;
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
            btnSettings.Click += btnSettings_Click;
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
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(220, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(560, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "View All Income";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvAllIncome
            // 
            dgvAllIncome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllIncome.Location = new Point(220, 80);
            dgvAllIncome.Name = "dgvAllIncome";
            dgvAllIncome.ReadOnly = true;
            dgvAllIncome.Size = new Size(550, 300);
            dgvAllIncome.TabIndex = 1;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(937, 60);
            pnlHeader.TabIndex = 1;
            // 
            // ViewAllIncomeForm
            // 
            ClientSize = new Size(937, 551);
            Controls.Add(dgvAllIncome);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ViewAllIncomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View All Income";
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllIncome).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
