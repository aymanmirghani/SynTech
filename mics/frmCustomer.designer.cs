namespace MICS
{
    partial class frmCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.groupCustInfo = new System.Windows.Forms.GroupBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtSecondaryTelephone = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupCustOtherInfo = new System.Windows.Forms.GroupBox();
            this.cmbOrderFrequency = new System.Windows.Forms.ComboBox();
            this.cmbDeliveryDay = new System.Windows.Forms.ComboBox();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdCustomers = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.chkActiveFlag = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBillingAddress = new System.Windows.Forms.GroupBox();
            this.chkCopyShippingAddress = new System.Windows.Forms.CheckBox();
            this.txtBillingState = new System.Windows.Forms.TextBox();
            this.txtBillingZip = new System.Windows.Forms.TextBox();
            this.txtBillingCity = new System.Windows.Forms.TextBox();
            this.txtBillingStreetAddress = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupNamePhone = new System.Windows.Forms.GroupBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.groupCustInfo.SuspendLayout();
            this.groupCustOtherInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBillingAddress.SuspendLayout();
            this.groupNamePhone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(97, 18);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(90, 21);
            this.txtCustomerID.TabIndex = 100;
            // 
            // groupCustInfo
            // 
            this.groupCustInfo.Controls.Add(this.txtState);
            this.groupCustInfo.Controls.Add(this.txtZip);
            this.groupCustInfo.Controls.Add(this.txtCity);
            this.groupCustInfo.Controls.Add(this.txtStreetAddress);
            this.groupCustInfo.Controls.Add(this.label7);
            this.groupCustInfo.Controls.Add(this.label6);
            this.groupCustInfo.Controls.Add(this.label5);
            this.groupCustInfo.Controls.Add(this.label4);
            this.groupCustInfo.Location = new System.Drawing.Point(6, 204);
            this.groupCustInfo.Name = "groupCustInfo";
            this.groupCustInfo.Size = new System.Drawing.Size(392, 116);
            this.groupCustInfo.TabIndex = 8;
            this.groupCustInfo.TabStop = false;
            this.groupCustInfo.Text = "Shipping Address";
            // 
            // txtState
            // 
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(101, 71);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(62, 21);
            this.txtState.TabIndex = 11;
            this.txtState.Leave += new System.EventHandler(this.txtState_Leave);
            // 
            // txtZip
            // 
            this.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZip.Location = new System.Drawing.Point(210, 71);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(106, 21);
            this.txtZip.TabIndex = 12;
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(101, 45);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(170, 21);
            this.txtCity.TabIndex = 10;
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreetAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetAddress.Location = new System.Drawing.Point(101, 19);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(219, 21);
            this.txtStreetAddress.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(180, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Zip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Street Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(119, 91);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(252, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // txtFax
            // 
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(119, 66);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(147, 21);
            this.txtFax.TabIndex = 4;
            // 
            // txtSecondaryTelephone
            // 
            this.txtSecondaryTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondaryTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondaryTelephone.Location = new System.Drawing.Point(119, 116);
            this.txtSecondaryTelephone.Name = "txtSecondaryTelephone";
            this.txtSecondaryTelephone.Size = new System.Drawing.Size(127, 21);
            this.txtSecondaryTelephone.TabIndex = 6;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(119, 41);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(170, 21);
            this.txtTelephone.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(74, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Second Telephone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Telephone";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(307, 115);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(128, 23);
            this.cmbTerritory.Sorted = true;
            this.cmbTerritory.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(253, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Territory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Linen;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(119, 16);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(242, 21);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtCustomerName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustomerName_Validating);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(317, 17);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(147, 21);
            this.txtAccountNumber.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(213, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Account Number";
            // 
            // groupCustOtherInfo
            // 
            this.groupCustOtherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCustOtherInfo.Controls.Add(this.cmbOrderFrequency);
            this.groupCustOtherInfo.Controls.Add(this.cmbDeliveryDay);
            this.groupCustOtherInfo.Controls.Add(this.txtCreditLimit);
            this.groupCustOtherInfo.Controls.Add(this.txtContactName);
            this.groupCustOtherInfo.Controls.Add(this.label17);
            this.groupCustOtherInfo.Controls.Add(this.label16);
            this.groupCustOtherInfo.Controls.Add(this.label14);
            this.groupCustOtherInfo.Controls.Add(this.label13);
            this.groupCustOtherInfo.Location = new System.Drawing.Point(470, 51);
            this.groupCustOtherInfo.Name = "groupCustOtherInfo";
            this.groupCustOtherInfo.Size = new System.Drawing.Size(321, 147);
            this.groupCustOtherInfo.TabIndex = 20;
            this.groupCustOtherInfo.TabStop = false;
            this.groupCustOtherInfo.Text = "Other Information";
            // 
            // cmbOrderFrequency
            // 
            this.cmbOrderFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderFrequency.FormattingEnabled = true;
            this.cmbOrderFrequency.Location = new System.Drawing.Point(110, 91);
            this.cmbOrderFrequency.Name = "cmbOrderFrequency";
            this.cmbOrderFrequency.Size = new System.Drawing.Size(160, 23);
            this.cmbOrderFrequency.TabIndex = 23;
            // 
            // cmbDeliveryDay
            // 
            this.cmbDeliveryDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeliveryDay.FormattingEnabled = true;
            this.cmbDeliveryDay.Location = new System.Drawing.Point(110, 63);
            this.cmbDeliveryDay.Name = "cmbDeliveryDay";
            this.cmbDeliveryDay.Size = new System.Drawing.Size(168, 23);
            this.cmbDeliveryDay.TabIndex = 22;
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditLimit.Location = new System.Drawing.Point(110, 119);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(154, 21);
            this.txtCreditLimit.TabIndex = 24;
            // 
            // txtContactName
            // 
            this.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactName.Location = new System.Drawing.Point(110, 36);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(188, 21);
            this.txtContactName.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 15);
            this.label17.TabIndex = 9;
            this.label17.Text = "Order Frequency";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(30, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Delivery Day";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(34, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Credit Limit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Contact Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.grdCustomers);
            this.groupBox3.Location = new System.Drawing.Point(6, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(782, 264);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customers List";
            // 
            // grdCustomers
            // 
            this.grdCustomers.AllowUserToAddRows = false;
            this.grdCustomers.AllowUserToDeleteRows = false;
            this.grdCustomers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCustomers.Location = new System.Drawing.Point(6, 30);
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.ReadOnly = true;
            this.grdCustomers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdCustomers.RowHeadersVisible = false;
            this.grdCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCustomers.Size = new System.Drawing.Size(965, 220);
            this.grdCustomers.TabIndex = 32;
            this.grdCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCustomers_CellContentClick);
            this.grdCustomers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCustomers_CellMouseClick);
            this.grdCustomers.SelectionChanged += new System.EventHandler(this.grdCustomers_SelectionChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupInput
            // 
            this.groupInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInput.Controls.Add(this.chkActiveFlag);
            this.groupInput.Controls.Add(this.groupBox1);
            this.groupInput.Controls.Add(this.groupBillingAddress);
            this.groupInput.Controls.Add(this.groupCustOtherInfo);
            this.groupInput.Controls.Add(this.groupNamePhone);
            this.groupInput.Controls.Add(this.groupBox3);
            this.groupInput.Controls.Add(this.groupCustInfo);
            this.groupInput.Controls.Add(this.label12);
            this.groupInput.Controls.Add(this.txtAccountNumber);
            this.groupInput.Controls.Add(this.txtCustomerID);
            this.groupInput.Controls.Add(this.label1);
            this.groupInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInput.Location = new System.Drawing.Point(12, 13);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(797, 653);
            this.groupInput.TabIndex = 33;
            this.groupInput.TabStop = false;
            this.groupInput.Enter += new System.EventHandler(this.groupInput_Enter);
            // 
            // chkActiveFlag
            // 
            this.chkActiveFlag.AutoSize = true;
            this.chkActiveFlag.Checked = true;
            this.chkActiveFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActiveFlag.Location = new System.Drawing.Point(484, 20);
            this.chkActiveFlag.Name = "chkActiveFlag";
            this.chkActiveFlag.Size = new System.Drawing.Size(57, 19);
            this.chkActiveFlag.TabIndex = 1;
            this.chkActiveFlag.Text = "Active";
            this.chkActiveFlag.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 53);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 33);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(142, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(89, 26);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "Clear";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(442, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 26);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(242, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(342, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 26);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(542, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 26);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBillingAddress
            // 
            this.groupBillingAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBillingAddress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBillingAddress.Controls.Add(this.chkCopyShippingAddress);
            this.groupBillingAddress.Controls.Add(this.txtBillingState);
            this.groupBillingAddress.Controls.Add(this.txtBillingZip);
            this.groupBillingAddress.Controls.Add(this.txtBillingCity);
            this.groupBillingAddress.Controls.Add(this.txtBillingStreetAddress);
            this.groupBillingAddress.Controls.Add(this.label18);
            this.groupBillingAddress.Controls.Add(this.label19);
            this.groupBillingAddress.Controls.Add(this.label20);
            this.groupBillingAddress.Controls.Add(this.label21);
            this.groupBillingAddress.Location = new System.Drawing.Point(401, 204);
            this.groupBillingAddress.Name = "groupBillingAddress";
            this.groupBillingAddress.Size = new System.Drawing.Size(390, 116);
            this.groupBillingAddress.TabIndex = 13;
            this.groupBillingAddress.TabStop = false;
            this.groupBillingAddress.Text = "Billing Address";
            // 
            // chkCopyShippingAddress
            // 
            this.chkCopyShippingAddress.AutoSize = true;
            this.chkCopyShippingAddress.Location = new System.Drawing.Point(101, 13);
            this.chkCopyShippingAddress.Name = "chkCopyShippingAddress";
            this.chkCopyShippingAddress.Size = new System.Drawing.Size(152, 19);
            this.chkCopyShippingAddress.TabIndex = 14;
            this.chkCopyShippingAddress.Text = "Copy Shipping Address";
            this.chkCopyShippingAddress.UseVisualStyleBackColor = true;
            this.chkCopyShippingAddress.CheckedChanged += new System.EventHandler(this.chkCopyShippingAddress_CheckedChanged);
            // 
            // txtBillingState
            // 
            this.txtBillingState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingState.Location = new System.Drawing.Point(102, 85);
            this.txtBillingState.MaxLength = 2;
            this.txtBillingState.Name = "txtBillingState";
            this.txtBillingState.Size = new System.Drawing.Size(62, 21);
            this.txtBillingState.TabIndex = 18;
            // 
            // txtBillingZip
            // 
            this.txtBillingZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingZip.Location = new System.Drawing.Point(210, 85);
            this.txtBillingZip.Name = "txtBillingZip";
            this.txtBillingZip.Size = new System.Drawing.Size(106, 21);
            this.txtBillingZip.TabIndex = 19;
            // 
            // txtBillingCity
            // 
            this.txtBillingCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingCity.Location = new System.Drawing.Point(101, 60);
            this.txtBillingCity.Name = "txtBillingCity";
            this.txtBillingCity.Size = new System.Drawing.Size(170, 21);
            this.txtBillingCity.TabIndex = 17;
            // 
            // txtBillingStreetAddress
            // 
            this.txtBillingStreetAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingStreetAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingStreetAddress.Location = new System.Drawing.Point(101, 34);
            this.txtBillingStreetAddress.Name = "txtBillingStreetAddress";
            this.txtBillingStreetAddress.Size = new System.Drawing.Size(250, 21);
            this.txtBillingStreetAddress.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(175, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 15);
            this.label18.TabIndex = 9;
            this.label18.Text = "Zip";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(56, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 15);
            this.label19.TabIndex = 8;
            this.label19.Text = "State";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(56, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 15);
            this.label20.TabIndex = 7;
            this.label20.Text = "City";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(7, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 15);
            this.label21.TabIndex = 6;
            this.label21.Text = "Street Address";
            // 
            // groupNamePhone
            // 
            this.groupNamePhone.Controls.Add(this.picAdd);
            this.groupNamePhone.Controls.Add(this.txtFax);
            this.groupNamePhone.Controls.Add(this.txtEmail);
            this.groupNamePhone.Controls.Add(this.txtCustomerName);
            this.groupNamePhone.Controls.Add(this.label2);
            this.groupNamePhone.Controls.Add(this.label10);
            this.groupNamePhone.Controls.Add(this.txtSecondaryTelephone);
            this.groupNamePhone.Controls.Add(this.cmbTerritory);
            this.groupNamePhone.Controls.Add(this.label11);
            this.groupNamePhone.Controls.Add(this.txtTelephone);
            this.groupNamePhone.Controls.Add(this.label3);
            this.groupNamePhone.Controls.Add(this.label8);
            this.groupNamePhone.Controls.Add(this.label9);
            this.groupNamePhone.Location = new System.Drawing.Point(6, 51);
            this.groupNamePhone.Name = "groupNamePhone";
            this.groupNamePhone.Size = new System.Drawing.Size(458, 147);
            this.groupNamePhone.TabIndex = 1;
            this.groupNamePhone.TabStop = false;
            this.groupNamePhone.Text = "Customer Name and Phones";
            // 
            // picAdd
            // 
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = global::MICS.Properties.Resources.add;
            this.picAdd.Location = new System.Drawing.Point(437, 119);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(16, 16);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAdd.TabIndex = 14;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // frmCustomer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(821, 576);
            this.Controls.Add(this.groupInput);
            this.Name = "frmCustomer";
            this.Text = "Customers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.groupCustInfo.ResumeLayout(false);
            this.groupCustInfo.PerformLayout();
            this.groupCustOtherInfo.ResumeLayout(false);
            this.groupCustOtherInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBillingAddress.ResumeLayout(false);
            this.groupBillingAddress.PerformLayout();
            this.groupNamePhone.ResumeLayout(false);
            this.groupNamePhone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.GroupBox groupCustInfo;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtSecondaryTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupCustOtherInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdCustomers;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbOrderFrequency;
        private System.Windows.Forms.ComboBox cmbDeliveryDay;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.GroupBox groupNamePhone;
        private System.Windows.Forms.GroupBox groupBillingAddress;
        private System.Windows.Forms.TextBox txtBillingState;
        private System.Windows.Forms.TextBox txtBillingZip;
        private System.Windows.Forms.TextBox txtBillingCity;
        private System.Windows.Forms.TextBox txtBillingStreetAddress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chkCopyShippingAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkActiveFlag;
        private System.Windows.Forms.PictureBox picAdd;
    }
}