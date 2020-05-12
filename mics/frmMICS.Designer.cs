namespace MICS
{
    partial class frmMICS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMICS));
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.m = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPurchaseOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaleOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVendor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesTerritoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventoryAdjustment = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importMobileDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToMobileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPleaseWait = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainMenu.SuspendLayout();
            this.pnlPleaseWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainImageList
            // 
            this.mainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.mainImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m,
            this.maintenanceToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolsToolStripMenuItem1});
            this.mainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1072, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // m
            // 
            this.m.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPurchaseOrder,
            this.mnuSaleOrder,
            this.toolStripMenuItem1,
            this.mnuPrint,
            this.toolStripMenuItem2,
            this.mnuExit});
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(65, 24);
            this.m.Text = "Orders";
            // 
            // mnuPurchaseOrder
            // 
            this.mnuPurchaseOrder.Name = "mnuPurchaseOrder";
            this.mnuPurchaseOrder.Size = new System.Drawing.Size(178, 24);
            this.mnuPurchaseOrder.Text = "Purchase Order";
            this.mnuPurchaseOrder.Click += new System.EventHandler(this.mnuPurchaseOrder_Click);
            // 
            // mnuSaleOrder
            // 
            this.mnuSaleOrder.Name = "mnuSaleOrder";
            this.mnuSaleOrder.Size = new System.Drawing.Size(178, 24);
            this.mnuSaleOrder.Text = "Sale Order";
            this.mnuSaleOrder.Click += new System.EventHandler(this.mnuSaleOrder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(178, 24);
            this.mnuPrint.Text = "Print";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::MICS.Properties.Resources.door_out;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(178, 24);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVendor,
            this.mnuCustomer,
            this.productToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.userSetupToolStripMenuItem,
            this.mnuInventoryAdjustment});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // mnuVendor
            // 
            this.mnuVendor.Image = ((System.Drawing.Image)(resources.GetObject("mnuVendor.Image")));
            this.mnuVendor.Name = "mnuVendor";
            this.mnuVendor.Size = new System.Drawing.Size(219, 24);
            this.mnuVendor.Text = "Vendor";
            this.mnuVendor.Click += new System.EventHandler(this.mnuVendor_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Image = global::MICS.Properties.Resources.user_go;
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(219, 24);
            this.mnuCustomer.Text = "Customer";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Image = global::MICS.Properties.Resources.package;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesTerritoryToolStripMenuItem,
            this.salesTaxToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // salesTerritoryToolStripMenuItem
            // 
            this.salesTerritoryToolStripMenuItem.Name = "salesTerritoryToolStripMenuItem";
            this.salesTerritoryToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.salesTerritoryToolStripMenuItem.Text = "Sales Territory";
            this.salesTerritoryToolStripMenuItem.Click += new System.EventHandler(this.salesTerritoryToolStripMenuItem_Click_1);
            // 
            // salesTaxToolStripMenuItem
            // 
            this.salesTaxToolStripMenuItem.Name = "salesTaxToolStripMenuItem";
            this.salesTaxToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.salesTaxToolStripMenuItem.Text = "Special Offers";
            this.salesTaxToolStripMenuItem.Click += new System.EventHandler(this.salesTaxToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // userSetupToolStripMenuItem
            // 
            this.userSetupToolStripMenuItem.Image = global::MICS.Properties.Resources.wrench_orange;
            this.userSetupToolStripMenuItem.Name = "userSetupToolStripMenuItem";
            this.userSetupToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.userSetupToolStripMenuItem.Text = "User Setup";
            this.userSetupToolStripMenuItem.Visible = false;
            this.userSetupToolStripMenuItem.Click += new System.EventHandler(this.userSetupToolStripMenuItem_Click);
            // 
            // mnuInventoryAdjustment
            // 
            this.mnuInventoryAdjustment.Name = "mnuInventoryAdjustment";
            this.mnuInventoryAdjustment.Size = new System.Drawing.Size(219, 24);
            this.mnuInventoryAdjustment.Text = "Inventory Adjustment";
            this.mnuInventoryAdjustment.Click += new System.EventHandler(this.mnuInventoryAdjustment_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // showReportsToolStripMenuItem
            // 
            this.showReportsToolStripMenuItem.Name = "showReportsToolStripMenuItem";
            this.showReportsToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.showReportsToolStripMenuItem.Text = "Show Reports";
            this.showReportsToolStripMenuItem.Click += new System.EventHandler(this.showReportsToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMobileDataToolStripMenuItem,
            this.exportToMobileToolStripMenuItem,
            this.backupDataToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem1.Text = "Tools";
            // 
            // importMobileDataToolStripMenuItem
            // 
            this.importMobileDataToolStripMenuItem.Name = "importMobileDataToolStripMenuItem";
            this.importMobileDataToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.importMobileDataToolStripMenuItem.Text = "Import Mobile Data";
            this.importMobileDataToolStripMenuItem.Click += new System.EventHandler(this.importMobileDataToolStripMenuItem_Click);
            // 
            // exportToMobileToolStripMenuItem
            // 
            this.exportToMobileToolStripMenuItem.Name = "exportToMobileToolStripMenuItem";
            this.exportToMobileToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.exportToMobileToolStripMenuItem.Text = "Export To Mobile";
            this.exportToMobileToolStripMenuItem.Click += new System.EventHandler(this.exportToMobileToolStripMenuItem_Click);
            // 
            // backupDataToolStripMenuItem
            // 
            this.backupDataToolStripMenuItem.Name = "backupDataToolStripMenuItem";
            this.backupDataToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.backupDataToolStripMenuItem.Text = "Backup Data";
            this.backupDataToolStripMenuItem.Click += new System.EventHandler(this.backupDataToolStripMenuItem_Click);
            // 
            // pnlPleaseWait
            // 
            this.pnlPleaseWait.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlPleaseWait.Controls.Add(this.label1);
            this.pnlPleaseWait.Controls.Add(this.pictureBox1);
            this.pnlPleaseWait.Location = new System.Drawing.Point(0, 33);
            this.pnlPleaseWait.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPleaseWait.Name = "pnlPleaseWait";
            this.pnlPleaseWait.Size = new System.Drawing.Size(395, 162);
            this.pnlPleaseWait.TabIndex = 3;
            this.pnlPleaseWait.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(143, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Wait";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MICS.Properties.Resources.pleasewait;
            this.pictureBox1.Location = new System.Drawing.Point(176, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarMessage,
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1072, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarMessage
            // 
            this.statusBarMessage.AccessibleName = "statusBarMessage";
            this.statusBarMessage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.statusBarMessage.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusBarMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarMessage.ForeColor = System.Drawing.Color.Red;
            this.statusBarMessage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusBarMessage.Name = "statusBarMessage";
            this.statusBarMessage.Size = new System.Drawing.Size(1052, 17);
            this.statusBarMessage.Spring = true;
            this.statusBarMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(200, 20);
            this.statusBar.Visible = false;
            // 
            // frmMICS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1072, 631);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlPleaseWait);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMICS";
            this.Text = "MICS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMICS_FormClosing);
            this.Load += new System.EventHandler(this.frmMICS_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.pnlPleaseWait.ResumeLayout(false);
            this.pnlPleaseWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList mainImageList;
        public System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuSaleOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVendor;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesTerritoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPleaseWait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarMessage;
        private System.Windows.Forms.ToolStripProgressBar statusBar;
        private System.Windows.Forms.ToolStripMenuItem mnuInventoryAdjustment;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importMobileDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToMobileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDataToolStripMenuItem;
        
        


    }
}

