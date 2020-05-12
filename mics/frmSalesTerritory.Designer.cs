namespace MICS
{
    partial class frmSalesTerritory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.groupSalesPerson = new System.Windows.Forms.GroupBox();
            this.btnSaveSalePerson = new System.Windows.Forms.Button();
            this.btnDeleteSalesPerson = new System.Windows.Forms.Button();
            this.btnSearchSalesPerson = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgSalesPerson = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBounus = new System.Windows.Forms.TextBox();
            this.txtCommissionPct = new System.Windows.Forms.TextBox();
            this.txtSalesQuota = new System.Windows.Forms.TextBox();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.groupTerritory = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgTerritoryList = new System.Windows.Forms.DataGridView();
            this.txtTerritoryID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSalesPerson = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupInput.SuspendLayout();
            this.groupSalesPerson.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesPerson)).BeginInit();
            this.groupTerritory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTerritoryList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupInput
            // 
            this.groupInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInput.Controls.Add(this.groupSalesPerson);
            this.groupInput.Controls.Add(this.groupTerritory);
            this.groupInput.Location = new System.Drawing.Point(12, 16);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(1004, 617);
            this.groupInput.TabIndex = 0;
            this.groupInput.TabStop = false;
            this.groupInput.Enter += new System.EventHandler(this.groupInput_Enter);
            // 
            // groupSalesPerson
            // 
            this.groupSalesPerson.Controls.Add(this.btnSaveSalePerson);
            this.groupSalesPerson.Controls.Add(this.btnDeleteSalesPerson);
            this.groupSalesPerson.Controls.Add(this.btnSearchSalesPerson);
            this.groupSalesPerson.Controls.Add(this.label11);
            this.groupSalesPerson.Controls.Add(this.txtEmployeeID);
            this.groupSalesPerson.Controls.Add(this.groupBox3);
            this.groupSalesPerson.Controls.Add(this.label10);
            this.groupSalesPerson.Controls.Add(this.label9);
            this.groupSalesPerson.Controls.Add(this.label8);
            this.groupSalesPerson.Controls.Add(this.label7);
            this.groupSalesPerson.Controls.Add(this.txtBounus);
            this.groupSalesPerson.Controls.Add(this.txtCommissionPct);
            this.groupSalesPerson.Controls.Add(this.txtSalesQuota);
            this.groupSalesPerson.Controls.Add(this.cmbEmployeeName);
            this.groupSalesPerson.Location = new System.Drawing.Point(528, 19);
            this.groupSalesPerson.Name = "groupSalesPerson";
            this.groupSalesPerson.Size = new System.Drawing.Size(458, 592);
            this.groupSalesPerson.TabIndex = 11;
            this.groupSalesPerson.TabStop = false;
            this.groupSalesPerson.Text = "Sales Person";
            // 
            // btnSaveSalePerson
            // 
            this.btnSaveSalePerson.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveSalePerson.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSaveSalePerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSaveSalePerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveSalePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSalePerson.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSalePerson.Location = new System.Drawing.Point(55, 200);
            this.btnSaveSalePerson.Name = "btnSaveSalePerson";
            this.btnSaveSalePerson.Size = new System.Drawing.Size(90, 26);
            this.btnSaveSalePerson.TabIndex = 22;
            this.btnSaveSalePerson.Text = "Save";
            this.btnSaveSalePerson.UseVisualStyleBackColor = true;
            this.btnSaveSalePerson.Click += new System.EventHandler(this.btnSaveSalePerson_Click);
            // 
            // btnDeleteSalesPerson
            // 
            this.btnDeleteSalesPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDeleteSalesPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDeleteSalesPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSalesPerson.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSalesPerson.Location = new System.Drawing.Point(247, 199);
            this.btnDeleteSalesPerson.Name = "btnDeleteSalesPerson";
            this.btnDeleteSalesPerson.Size = new System.Drawing.Size(90, 26);
            this.btnDeleteSalesPerson.TabIndex = 24;
            this.btnDeleteSalesPerson.Text = "Delete";
            this.btnDeleteSalesPerson.UseVisualStyleBackColor = true;
            this.btnDeleteSalesPerson.Click += new System.EventHandler(this.btnDeleteSalesPerson_Click);
            // 
            // btnSearchSalesPerson
            // 
            this.btnSearchSalesPerson.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSearchSalesPerson.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSearchSalesPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearchSalesPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchSalesPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSalesPerson.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSalesPerson.Location = new System.Drawing.Point(151, 199);
            this.btnSearchSalesPerson.Name = "btnSearchSalesPerson";
            this.btnSearchSalesPerson.Size = new System.Drawing.Size(90, 26);
            this.btnSearchSalesPerson.TabIndex = 23;
            this.btnSearchSalesPerson.Text = "Clear";
            this.btnSearchSalesPerson.UseVisualStyleBackColor = true;
            this.btnSearchSalesPerson.Click += new System.EventHandler(this.btnSearchSalesPerson_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(84, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "ID";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.ForeColor = System.Drawing.Color.Red;
            this.txtEmployeeID.Location = new System.Drawing.Point(116, 23);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(104, 20);
            this.txtEmployeeID.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgSalesPerson);
            this.groupBox3.Location = new System.Drawing.Point(15, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 344);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales Person List";
            // 
            // dgSalesPerson
            // 
            this.dgSalesPerson.AllowUserToAddRows = false;
            this.dgSalesPerson.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgSalesPerson.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSalesPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgSalesPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalesPerson.Location = new System.Drawing.Point(6, 19);
            this.dgSalesPerson.Name = "dgSalesPerson";
            this.dgSalesPerson.ReadOnly = true;
            this.dgSalesPerson.RowHeadersVisible = false;
            this.dgSalesPerson.Size = new System.Drawing.Size(424, 302);
            this.dgSalesPerson.TabIndex = 0;
            this.dgSalesPerson.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgSalesPerson_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Commission %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Bounus";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Sales Quota";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Employee Name";
            // 
            // txtBounus
            // 
            this.txtBounus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBounus.Location = new System.Drawing.Point(116, 105);
            this.txtBounus.Name = "txtBounus";
            this.txtBounus.Size = new System.Drawing.Size(104, 20);
            this.txtBounus.TabIndex = 14;
            this.txtBounus.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtCommissionPct
            // 
            this.txtCommissionPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommissionPct.Location = new System.Drawing.Point(116, 131);
            this.txtCommissionPct.Name = "txtCommissionPct";
            this.txtCommissionPct.Size = new System.Drawing.Size(104, 20);
            this.txtCommissionPct.TabIndex = 13;
            // 
            // txtSalesQuota
            // 
            this.txtSalesQuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesQuota.Location = new System.Drawing.Point(116, 79);
            this.txtSalesQuota.Name = "txtSalesQuota";
            this.txtSalesQuota.Size = new System.Drawing.Size(104, 20);
            this.txtSalesQuota.TabIndex = 12;
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(116, 52);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(309, 21);
            this.cmbEmployeeName.TabIndex = 11;
            // 
            // groupTerritory
            // 
            this.groupTerritory.Controls.Add(this.label3);
            this.groupTerritory.Controls.Add(this.groupBox1);
            this.groupTerritory.Controls.Add(this.txtTerritoryID);
            this.groupTerritory.Controls.Add(this.label2);
            this.groupTerritory.Controls.Add(this.btnSave);
            this.groupTerritory.Controls.Add(this.label1);
            this.groupTerritory.Controls.Add(this.txtCounty);
            this.groupTerritory.Controls.Add(this.txtName);
            this.groupTerritory.Controls.Add(this.btnSearch);
            this.groupTerritory.Controls.Add(this.groupBox2);
            this.groupTerritory.Location = new System.Drawing.Point(16, 19);
            this.groupTerritory.Name = "groupTerritory";
            this.groupTerritory.Size = new System.Drawing.Size(506, 592);
            this.groupTerritory.TabIndex = 10;
            this.groupTerritory.TabStop = false;
            this.groupTerritory.Text = "Sales Territory";
            this.groupTerritory.Enter += new System.EventHandler(this.groupTerritory_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgTerritoryList);
            this.groupBox1.Location = new System.Drawing.Point(18, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 344);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Territory List";
            // 
            // dgTerritoryList
            // 
            this.dgTerritoryList.AllowUserToAddRows = false;
            this.dgTerritoryList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgTerritoryList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTerritoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTerritoryList.Location = new System.Drawing.Point(17, 19);
            this.dgTerritoryList.Name = "dgTerritoryList";
            this.dgTerritoryList.ReadOnly = true;
            this.dgTerritoryList.RowHeadersVisible = false;
            this.dgTerritoryList.Size = new System.Drawing.Size(437, 302);
            this.dgTerritoryList.TabIndex = 0;
            this.dgTerritoryList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgTerritoryList_MouseClick);
            this.dgTerritoryList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTerritoryList_CellContentClick);
            // 
            // txtTerritoryID
            // 
            this.txtTerritoryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTerritoryID.Enabled = false;
            this.txtTerritoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerritoryID.ForeColor = System.Drawing.Color.Red;
            this.txtTerritoryID.Location = new System.Drawing.Point(112, 23);
            this.txtTerritoryID.Name = "txtTerritoryID";
            this.txtTerritoryID.ReadOnly = true;
            this.txtTerritoryID.Size = new System.Drawing.Size(117, 20);
            this.txtTerritoryID.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Territory County";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(125, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Territory Name";
            // 
            // txtCounty
            // 
            this.txtCounty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCounty.Location = new System.Drawing.Point(112, 74);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(158, 20);
            this.txtCounty.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(112, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(221, 199);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Clear";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtStartDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbSalesPerson);
            this.groupBox2.Location = new System.Drawing.Point(18, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 83);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Person Territory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Start Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(127, 47);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(123, 20);
            this.dtStartDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sales Person Name";
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(127, 14);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(261, 21);
            this.cmbSalesPerson.TabIndex = 10;
            this.cmbSalesPerson.SelectedIndexChanged += new System.EventHandler(this.cmbSalesPerson_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSalesTerritory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1028, 645);
            this.Controls.Add(this.groupInput);
            this.Name = "frmSalesTerritory";
            this.Text = "Sales Territory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesTerritory_Load);
            this.groupInput.ResumeLayout(false);
            this.groupSalesPerson.ResumeLayout(false);
            this.groupSalesPerson.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesPerson)).EndInit();
            this.groupTerritory.ResumeLayout(false);
            this.groupTerritory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTerritoryList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTerritoryID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgTerritoryList;
        private System.Windows.Forms.GroupBox groupTerritory;
        private System.Windows.Forms.GroupBox groupSalesPerson;
        private System.Windows.Forms.ComboBox cmbSalesPerson;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBounus;
        private System.Windows.Forms.TextBox txtCommissionPct;
        private System.Windows.Forms.TextBox txtSalesQuota;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgSalesPerson;
        private System.Windows.Forms.Button btnSaveSalePerson;
        private System.Windows.Forms.Button btnDeleteSalesPerson;
        private System.Windows.Forms.Button btnSearchSalesPerson;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}