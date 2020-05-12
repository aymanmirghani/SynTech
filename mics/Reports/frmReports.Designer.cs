namespace MICS.Reports
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dtMPPToDate = new System.Windows.Forms.DateTimePicker();
            this.dtMPPFrom = new System.Windows.Forms.DateTimePicker();
            this.btnMPPOk = new System.Windows.Forms.Button();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelListParam = new System.Windows.Forms.GroupBox();
            this.chkListReportColumns = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelProductParam = new System.Windows.Forms.GroupBox();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdFromToDate = new System.Windows.Forms.RadioButton();
            this.rdMonthToDate = new System.Windows.Forms.RadioButton();
            this.rdYearToDate = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelListParam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelProductParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtMPPToDate
            // 
            this.dtMPPToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMPPToDate.Location = new System.Drawing.Point(101, 115);
            this.dtMPPToDate.Name = "dtMPPToDate";
            this.dtMPPToDate.Size = new System.Drawing.Size(102, 21);
            this.dtMPPToDate.TabIndex = 2;
            // 
            // dtMPPFrom
            // 
            this.dtMPPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMPPFrom.Location = new System.Drawing.Point(101, 90);
            this.dtMPPFrom.Name = "dtMPPFrom";
            this.dtMPPFrom.Size = new System.Drawing.Size(102, 21);
            this.dtMPPFrom.TabIndex = 1;
            // 
            // btnMPPOk
            // 
            this.btnMPPOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMPPOk.Location = new System.Drawing.Point(194, 472);
            this.btnMPPOk.Name = "btnMPPOk";
            this.btnMPPOk.Size = new System.Drawing.Size(101, 27);
            this.btnMPPOk.TabIndex = 0;
            this.btnMPPOk.Text = "Run Report";
            this.btnMPPOk.UseVisualStyleBackColor = true;
            this.btnMPPOk.Click += new System.EventHandler(this.btnMPPOk_Click);
            // 
            // cmbReports
            // 
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Items.AddRange(new object[] {
            "<Select Report Type>",
            "Purchased Products Report",
            "Purchased Products Chart",
            "Sold Products Report",
            "Sold Products Chart"});
            this.cmbReports.Location = new System.Drawing.Point(32, 30);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(263, 23);
            this.cmbReports.TabIndex = 3;
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelListParam);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnMPPOk);
            this.panel1.Controls.Add(this.cmbReports);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 525);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelListParam
            // 
            this.panelListParam.Controls.Add(this.chkListReportColumns);
            this.panelListParam.Location = new System.Drawing.Point(129, 255);
            this.panelListParam.Name = "panelListParam";
            this.panelListParam.Size = new System.Drawing.Size(337, 186);
            this.panelListParam.TabIndex = 9;
            this.panelListParam.TabStop = false;
            this.panelListParam.Text = "Select Fields";
            this.panelListParam.Visible = false;
            // 
            // chkListReportColumns
            // 
            this.chkListReportColumns.FormattingEnabled = true;
            this.chkListReportColumns.Location = new System.Drawing.Point(17, 20);
            this.chkListReportColumns.Name = "chkListReportColumns";
            this.chkListReportColumns.Size = new System.Drawing.Size(286, 148);
            this.chkListReportColumns.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panelProductParam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdFromToDate);
            this.groupBox1.Controls.Add(this.rdMonthToDate);
            this.groupBox1.Controls.Add(this.rdYearToDate);
            this.groupBox1.Controls.Add(this.dtMPPToDate);
            this.groupBox1.Controls.Add(this.dtMPPFrom);
            this.groupBox1.Location = new System.Drawing.Point(14, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 190);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Perid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // panelProductParam
            // 
            this.panelProductParam.Controls.Add(this.cmbProducts);
            this.panelProductParam.Controls.Add(this.cmbCustomers);
            this.panelProductParam.Location = new System.Drawing.Point(209, 84);
            this.panelProductParam.Name = "panelProductParam";
            this.panelProductParam.Size = new System.Drawing.Size(326, 100);
            this.panelProductParam.TabIndex = 8;
            this.panelProductParam.TabStop = false;
            this.panelProductParam.Text = "Parameters";
            this.panelProductParam.Visible = false;
            // 
            // cmbProducts
            // 
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Items.AddRange(new object[] {
            "<Select Report Type>",
            "Purchased Products Report",
            "Purchased Products Chart",
            "Sold Products Report",
            "Sold Products Chart"});
            this.cmbProducts.Location = new System.Drawing.Point(40, 62);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(263, 23);
            this.cmbProducts.TabIndex = 6;
            this.cmbProducts.Visible = false;
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Items.AddRange(new object[] {
            "<Select Report Type>",
            "Purchased Products Report",
            "Purchased Products Chart",
            "Sold Products Report",
            "Sold Products Chart"});
            this.cmbCustomers.Location = new System.Drawing.Point(40, 33);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(263, 23);
            this.cmbCustomers.TabIndex = 5;
            this.cmbCustomers.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            // 
            // rdFromToDate
            // 
            this.rdFromToDate.AutoSize = true;
            this.rdFromToDate.Location = new System.Drawing.Point(62, 65);
            this.rdFromToDate.Name = "rdFromToDate";
            this.rdFromToDate.Size = new System.Drawing.Size(104, 19);
            this.rdFromToDate.TabIndex = 5;
            this.rdFromToDate.TabStop = true;
            this.rdFromToDate.Text = "Specific Dates";
            this.rdFromToDate.UseVisualStyleBackColor = true;
            // 
            // rdMonthToDate
            // 
            this.rdMonthToDate.AutoSize = true;
            this.rdMonthToDate.Location = new System.Drawing.Point(62, 46);
            this.rdMonthToDate.Name = "rdMonthToDate";
            this.rdMonthToDate.Size = new System.Drawing.Size(104, 19);
            this.rdMonthToDate.TabIndex = 4;
            this.rdMonthToDate.TabStop = true;
            this.rdMonthToDate.Text = "Month To Date";
            this.rdMonthToDate.UseVisualStyleBackColor = true;
            // 
            // rdYearToDate
            // 
            this.rdYearToDate.AutoSize = true;
            this.rdYearToDate.Location = new System.Drawing.Point(62, 21);
            this.rdYearToDate.Name = "rdYearToDate";
            this.rdYearToDate.Size = new System.Drawing.Size(96, 19);
            this.rdYearToDate.TabIndex = 3;
            this.rdYearToDate.TabStop = true;
            this.rdYearToDate.Text = "Year To Date";
            this.rdYearToDate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(301, 472);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 27);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 549);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.panel1.ResumeLayout(false);
            this.panelListParam.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelProductParam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtMPPToDate;
        private System.Windows.Forms.DateTimePicker dtMPPFrom;
        private System.Windows.Forms.Button btnMPPOk;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdFromToDate;
        private System.Windows.Forms.RadioButton rdMonthToDate;
        private System.Windows.Forms.RadioButton rdYearToDate;
        private System.Windows.Forms.GroupBox panelProductParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox panelListParam;
        private System.Windows.Forms.CheckedListBox chkListReportColumns;
    }
}