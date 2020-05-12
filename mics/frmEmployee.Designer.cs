namespace MICS
{
    partial class frmEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFExit = new System.Windows.Forms.Button();
            this.btnFSave = new System.Windows.Forms.Button();
            this.btnFNew = new System.Windows.Forms.Button();
            this.btnFDelete = new System.Windows.Forms.Button();
            this.btnFSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EmployeeGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZipcode = new System.Windows.Forms.TextBox();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(14, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 569);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.tableLayoutPanel1);
            this.groupBox6.Location = new System.Drawing.Point(12, 219);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(829, 69);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnFExit, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFNew, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFDelete, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFSearch, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFExit
            // 
            this.btnFExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFExit.Location = new System.Drawing.Point(589, 3);
            this.btnFExit.Name = "btnFExit";
            this.btnFExit.Size = new System.Drawing.Size(104, 30);
            this.btnFExit.TabIndex = 16;
            this.btnFExit.Text = "Exit";
            this.btnFExit.UseVisualStyleBackColor = true;
            this.btnFExit.Click += new System.EventHandler(this.btnFExit_Click);
            // 
            // btnFSave
            // 
            this.btnFSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSave.Location = new System.Drawing.Point(238, 3);
            this.btnFSave.Name = "btnFSave";
            this.btnFSave.Size = new System.Drawing.Size(104, 30);
            this.btnFSave.TabIndex = 18;
            this.btnFSave.Text = "Save";
            this.btnFSave.UseVisualStyleBackColor = true;
            this.btnFSave.Click += new System.EventHandler(this.btnFSave_Click);
            // 
            // btnFNew
            // 
            this.btnFNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFNew.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFNew.Location = new System.Drawing.Point(121, 3);
            this.btnFNew.Name = "btnFNew";
            this.btnFNew.Size = new System.Drawing.Size(104, 30);
            this.btnFNew.TabIndex = 17;
            this.btnFNew.Text = "New";
            this.btnFNew.UseVisualStyleBackColor = true;
            this.btnFNew.Click += new System.EventHandler(this.btnFNew_Click);
            // 
            // btnFDelete
            // 
            this.btnFDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFDelete.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFDelete.Location = new System.Drawing.Point(355, 3);
            this.btnFDelete.Name = "btnFDelete";
            this.btnFDelete.Size = new System.Drawing.Size(104, 30);
            this.btnFDelete.TabIndex = 19;
            this.btnFDelete.Text = "Delete";
            this.btnFDelete.UseVisualStyleBackColor = true;
            this.btnFDelete.Click += new System.EventHandler(this.btnFDelete_Click);
            // 
            // btnFSearch
            // 
            this.btnFSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFSearch.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSearch.Location = new System.Drawing.Point(472, 3);
            this.btnFSearch.Name = "btnFSearch";
            this.btnFSearch.Size = new System.Drawing.Size(104, 30);
            this.btnFSearch.TabIndex = 20;
            this.btnFSearch.Text = "Search";
            this.btnFSearch.UseVisualStyleBackColor = true;
            this.btnFSearch.Click += new System.EventHandler(this.btnFSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.EmployeeGrid);
            this.groupBox3.Location = new System.Drawing.Point(10, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(829, 268);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EmployeeDetails";
            // 
            // EmployeeGrid
            // 
            this.EmployeeGrid.AllowUserToAddRows = false;
            this.EmployeeGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.EmployeeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmployeeGrid.EnableHeadersVisualStyles = false;
            this.EmployeeGrid.Location = new System.Drawing.Point(13, 22);
            this.EmployeeGrid.MultiSelect = false;
            this.EmployeeGrid.Name = "EmployeeGrid";
            this.EmployeeGrid.ReadOnly = true;
            this.EmployeeGrid.RowHeadersVisible = false;
            this.EmployeeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeGrid.Size = new System.Drawing.Size(804, 239);
            this.EmployeeGrid.TabIndex = 0;
            this.EmployeeGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeeGrid_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 201);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtCellPhone);
            this.groupBox5.Controls.Add(this.txtHomePhone);
            this.groupBox5.Controls.Add(this.txtWorkPhone);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtZipcode);
            this.groupBox5.Controls.Add(this.txtAddressLine2);
            this.groupBox5.Controls.Add(this.txtCity);
            this.groupBox5.Controls.Add(this.txtAddressLine1);
            this.groupBox5.Controls.Add(this.txtState);
            this.groupBox5.Location = new System.Drawing.Point(355, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(468, 185);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Address Info";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cell Phone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Home Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Work Phone";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.BackColor = System.Drawing.Color.White;
            this.txtCellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCellPhone.Location = new System.Drawing.Point(103, 154);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(151, 21);
            this.txtCellPhone.TabIndex = 14;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.BackColor = System.Drawing.Color.White;
            this.txtHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHomePhone.Location = new System.Drawing.Point(103, 127);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(151, 21);
            this.txtHomePhone.TabIndex = 13;
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.BackColor = System.Drawing.Color.White;
            this.txtWorkPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkPhone.Location = new System.Drawing.Point(103, 100);
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.Size = new System.Drawing.Size(151, 21);
            this.txtWorkPhone.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "City/State/Zip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Address line 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Address line 1";
            // 
            // txtZipcode
            // 
            this.txtZipcode.BackColor = System.Drawing.Color.Linen;
            this.txtZipcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipcode.Location = new System.Drawing.Point(360, 73);
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.Size = new System.Drawing.Size(75, 21);
            this.txtZipcode.TabIndex = 8;
            this.txtZipcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtZipcode_Validating);
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLine2.Location = new System.Drawing.Point(103, 45);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(333, 21);
            this.txtAddressLine2.TabIndex = 5;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.Linen;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(103, 73);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(151, 21);
            this.txtCity.TabIndex = 6;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtCity_Validating);
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.BackColor = System.Drawing.Color.Linen;
            this.txtAddressLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLine1.Location = new System.Drawing.Point(103, 20);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(333, 21);
            this.txtAddressLine1.TabIndex = 4;
            this.txtAddressLine1.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddressLine1_Validating);
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.Linen;
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Location = new System.Drawing.Point(281, 73);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(56, 21);
            this.txtState.TabIndex = 7;
            this.txtState.Leave += new System.EventHandler(this.txtState_Leave);
            this.txtState.Validating += new System.ComponentModel.CancelEventHandler(this.txtState_Validating);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblEmployeeID);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtFirstName);
            this.groupBox4.Controls.Add(this.txtMiddleName);
            this.groupBox4.Controls.Add(this.txtLastName);
            this.groupBox4.Controls.Add(this.txtUserName);
            this.groupBox4.Location = new System.Drawing.Point(7, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 163);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Employee Info";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(1, 13);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(0, 15);
            this.lblEmployeeID.TabIndex = 14;
            this.lblEmployeeID.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Middle Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Linen;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(134, 20);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(151, 21);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Location = new System.Drawing.Point(134, 45);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(151, 21);
            this.txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Linen;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(134, 73);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(151, 21);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(134, 100);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(151, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 590);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployee";
            this.Text = "Employee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtZipcode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView EmployeeGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Button btnFDelete;
        private System.Windows.Forms.Button btnFSave;
        private System.Windows.Forms.Button btnFExit;
        private System.Windows.Forms.Button btnFNew;
        private System.Windows.Forms.Button btnFSearch;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.TextBox txtWorkPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}