namespace ExpenseTrackerApp.Views
{
    partial class ViewAllExpensesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pbUserProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnViewAllIncome;
        private System.Windows.Forms.Button btnViewAllExpenses;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.DataGridView dgvAllExpenses;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddExpense;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnLogout = new Button();
            btnSettings = new Button();
            btnViewAllExpenses = new Button();
            btnViewAllIncome = new Button();
            btnDashboard = new Button();
            pbUserProfile = new PictureBox();
            lblUserName = new Label();
            lblTitle = new Label();
            lblTotalExpenses = new Label();
            dgvAllExpenses = new DataGridView();
            pnlHeader = new Panel();
            txtSearch = new TextBox();
            btnAddExpense = new Button();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllExpenses).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnViewAllExpenses);
            pnlSidebar.Controls.Add(btnViewAllIncome);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pbUserProfile);
            pnlSidebar.Controls.Add(lblUserName);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 541);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(25, 374);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(25, 324);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 40);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnViewAllExpenses
            // 
            btnViewAllExpenses.BackColor = Color.DodgerBlue;
            btnViewAllExpenses.FlatStyle = FlatStyle.Flat;
            btnViewAllExpenses.ForeColor = Color.White;
            btnViewAllExpenses.Location = new Point(25, 274);
            btnViewAllExpenses.Name = "btnViewAllExpenses";
            btnViewAllExpenses.Size = new Size(150, 40);
            btnViewAllExpenses.TabIndex = 4;
            btnViewAllExpenses.Text = "View All Expenses";
            btnViewAllExpenses.UseVisualStyleBackColor = false;
            // 
            // btnViewAllIncome
            // 
            btnViewAllIncome.FlatStyle = FlatStyle.Flat;
            btnViewAllIncome.ForeColor = Color.White;
            btnViewAllIncome.Location = new Point(25, 224);
            btnViewAllIncome.Name = "btnViewAllIncome";
            btnViewAllIncome.Size = new Size(150, 40);
            btnViewAllIncome.TabIndex = 3;
            btnViewAllIncome.Text = "View All Income";
            btnViewAllIncome.UseVisualStyleBackColor = true;
            btnViewAllIncome.Click += btnViewAllIncome_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(25, 174);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(150, 40);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pbUserProfile
            // 
            pbUserProfile.Image = Properties.Resources.user;
            pbUserProfile.Location = new Point(50, 30);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(100, 100);
            pbUserProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUserProfile.TabIndex = 1;
            pbUserProfile.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(25, 130);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(150, 30);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Hi, [User's Name]";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(220, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "View All Expenses";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalExpenses.Location = new Point(850, 90);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(300, 30);
            lblTotalExpenses.TabIndex = 3;
            // 
            // dgvAllExpenses
            // 
            dgvAllExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllExpenses.Location = new Point(220, 80);
            dgvAllExpenses.Name = "dgvAllExpenses";
            dgvAllExpenses.ReadOnly = true;
            dgvAllExpenses.Size = new Size(550, 300);
            dgvAllExpenses.TabIndex = 1;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1055, 60);
            pnlHeader.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(700, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search expenses...";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAddExpense
            // 
            btnAddExpense.BackColor = Color.DodgerBlue;
            btnAddExpense.Location = new Point(850, 150);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(150, 40);
            btnAddExpense.TabIndex = 4;
            btnAddExpense.Text = "Add Expense";
            btnAddExpense.UseVisualStyleBackColor = false;
            btnAddExpense.Click += btnAddExpense_Click;
            // 
            // ViewAllExpensesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 601);
            Controls.Add(btnAddExpense);
            Controls.Add(dgvAllExpenses);
            Controls.Add(lblTotalExpenses);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ViewAllExpensesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View All Expenses";
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAllExpenses).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
