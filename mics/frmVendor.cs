using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
namespace MICS
{
    public partial class frmVendor : Form
    {
        private int m_AddressID;
        DataSet dsVendors = null;
        public frmVendor()
        {
            InitializeComponent();
            lblVendorID.Visible = false;
          //  PopulateGrid(0);
        }
        private void PopulateGrid(int SelectedID)
        {
            try
            {
                SetupVendorGrid();
                DataSet ds = new DataSet();
                Vendor vendor = new Vendor();
                ds = vendor.GetAllVendorsDataSet();
                if (ds == null)
                    return;
                //vendorGrid.DataSource = ds.Tables[0];
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow dRow = dsVendors.Tables[0].NewRow();
                    foreach (DataColumn vCol in dsVendors.Tables[0].Columns)
                    {
                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            if (col.ColumnName == vCol.ColumnName)
                            {
                                dRow[vCol.ColumnName] = dr[col.ColumnName];
                                if (col.ColumnName == "AddressID")
                                {
                                    Address ad = new Address();
                                    int id = Int32.Parse(dr["AddressID"].ToString());
                                    ad = ad.GetAddresss(id);
                                    dRow["Address"] = ad.AddressLine1 + "," + ad.City + "," + ad.StateProvince + " " + ad.PostalCode;
                                }
                                break;
                            }
                        }
                    }
                    dsVendors.Tables[0].Rows.Add(dRow);
                }

                if (SelectedID > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (SelectedID == Int32.Parse(dr["VendorID"].ToString()))
                        {
                            vendorGrid.Rows[i].Selected = true;
                            vendorGrid.FirstDisplayedScrollingRowIndex = i;
                            GridRowChanged(i);
                            break;
                        }
                        i++;
                    }
                }
                else if (SelectedID == 0 && vendorGrid.Rows.Count > 0)
                {
                    vendorGrid.Rows[0].Selected = true;
                    vendorGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void SetupGridProperties()
        {
            vendorGrid.Columns["VendorID"].Visible = false;
            vendorGrid.Columns["AddressID"].Visible = false;
            vendorGrid.Columns["Email"].Visible = false;
            vendorGrid.Columns["CreditRating"].Visible = false;
            vendorGrid.Columns["ModifiedDate"].Visible = false;
            vendorGrid.Columns["PreferredVendorStatus"].Visible = false;
        }
        private void SetupVendorGrid()
        {
            dsVendors = new DataSet();
            try
            {
                DataTable dt = new DataTable("Vendors");
                dt.Columns.Add(new DataColumn("VendorID", typeof(int)));
                dt.Columns.Add(new DataColumn("Name", typeof(String)));
                dt.Columns.Add(new DataColumn("ContactName", typeof(String)));
                dt.Columns.Add(new DataColumn("Phone", typeof(String)));
                dt.Columns.Add(new DataColumn("AltPhone", typeof(String)));
                dt.Columns.Add(new DataColumn("Fax", typeof(String)));
                dt.Columns.Add(new DataColumn("Address", typeof(String)));
                dt.Columns.Add(new DataColumn("AccountNumber", typeof(String)));
                dt.Columns.Add(new DataColumn("ActiveFlag", typeof(Boolean)));
                dt.Columns.Add(new DataColumn("Terms", typeof(String)));


                dt.Columns.Add(new DataColumn("PreferredVendorStatus", typeof(Boolean)));
                dt.Columns.Add(new DataColumn("AddressID", typeof(int)));
                dt.Columns.Add(new DataColumn("CreditRating", typeof(int)));
                dt.Columns.Add(new DataColumn("Email", typeof(String)));
                dt.Columns.Add(new DataColumn("ModifiedDate", typeof(String)));
                
                dsVendors.Tables.Add(dt);
                vendorGrid.DataSource = dsVendors.Tables[0];
                SetupGridProperties();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //PopulateGrid(0);
            ClearFields();
        }
        private void ClearFields()
        {
            foreach (Control ctr in groupInput.Controls)
            {
                if (ctr.Name.StartsWith("txt"))
                {
                    ctr.Text = "";
                }
            }
            chkActive.Checked = true;
            chkPrefered.Checked = false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Vendor v = new Vendor();
            Vendor vendor = new Vendor();
            
            try
            {
                int vendorID = Int32.Parse(lblVendorID.Text);
                //v = v.GetVendor(vendorID);
                v.VendorID = vendorID;
                v.Name = txtName.Text;
                v.ContactName = txtContactName.Text;
                v.ActiveFlag = chkActive.Checked;
                v.PreferredVendorStatus = chkPrefered.Checked;
                v.Phone = txtPhone.Text;
                v.Fax = txtFax.Text;
                v.Email = txtEmail.Text;
                v.AltPhone = txtAltPhone.Text;
                v.Terms = txtTerms.Text;
                if (txtCreditRating.Text.Trim().Length > 0)
                    v.CreditRating = Byte.Parse(txtCreditRating.Text);
                else
                    v.CreditRating = 0;
                v.ModifiedDate = DateTime.Now;
                v.AccountNumber = txtAccountNumber.Text;
                v.AddressID = m_AddressID;
                UpdateVendorAddress(m_AddressID);
                if(m_AddressID > 0)
                    v.AddressID = m_AddressID;
                if (vendor.UpdateVendor(v))
                {
                    MessageBox.Show("Vendor Updated");
                    PopulateGrid(v.VendorID);
                }
                else
                {
                    MessageBox.Show("Unable to update vendor");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                v = null;
                vendor = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateVendorAddress(int addressid)
        {
            Address add = new Address();
            try
            {
                add.AddressID = addressid;
                add.AddressLine1 = txtStreetAddress.Text;
                add.City = txtCity.Text;
                add.StateProvince = txtState.Text;
                add.PostalCode = txtZip.Text;
                m_AddressID = add.UpdateAddress(add);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsInvalidControl()) return;
            Cursor.Current = Cursors.WaitCursor;
            Vendor v = new Vendor();
            Vendor vendor = new Vendor();
            Address add = new Address();
            try
            {

                v.Name = txtName.Text.Trim();
                
                v.ContactName = txtContactName.Text.Trim();
                v.AccountNumber = txtAccountNumber.Text.Trim();
                if (txtCreditRating.Text.Trim().Length > 0)
                    v.CreditRating = Byte.Parse(txtCreditRating.Text.Trim());
                else
                    v.CreditRating = 0;
                v.ActiveFlag = chkActive.Checked;
                v.Phone = txtPhone.Text.Trim();
                v.AltPhone = txtPhone.Text;
                v.Terms = txtTerms.Text;
                v.Fax = txtFax.Text.Trim();
                v.Email = txtEmail.Text.Trim();
                v.PreferredVendorStatus = chkPrefered.Checked;
                v.ModifiedDate = DateTime.Now;
                add.AddressLine1 = txtStreetAddress.Text;
                add.City = txtCity.Text;
                add.StateProvince = txtState.Text;
                add.PostalCode = txtZip.Text;
                int vendid = v.Exists(v.Name);
                if (vendid > 0)
                {
                    DialogResult result = MessageBox.Show("Vendor: " + v.Name + " already exists\nWould you like to update it?", "MICS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        v.VendorID = vendid;
                        v.UpdateVendor(v);
                        int vendAddressId = v.AddressID;
                        add.UpdateAddress(add);
                        PopulateGrid(v.VendorID);
                        MessageBox.Show("Record updated successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Record is not saved", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
                v.AddressID = add.AddAddress(add);
                vendor.VendorID = vendor.AddVendor(v);
                PopulateGrid(vendor.VendorID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                vendor = null;
                v = null;
            }
            Cursor.Current = Cursors.Default;
        }

        private void vendorGrid_MouseClick(object sender, MouseEventArgs e)
        {
            GridRowChanged(-1);
        }

        private void GridRowChanged(int selectedIndex)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (selectedIndex < 0)
                row = vendorGrid.CurrentRow;
            else
                row = vendorGrid.Rows[selectedIndex];
            if (row == null) return;
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.OwningColumn.Name)
                {
                    case "VendorID":
                        lblVendorID.Text = cell.Value.ToString();
                        break;
                    case "AccountNumber":
                        txtAccountNumber.Text = cell.Value.ToString();
                        break;
                    case "Name":
                        txtName.Text = cell.Value.ToString();
                        break;
                    case "ContactName":
                        txtContactName.Text = cell.Value.ToString();
                        break;
                    case "CreditRating":
                        txtCreditRating.Text = cell.Value.ToString();
                        break;
                    case "PreferredVendorStatus":
                        chkPrefered.Checked = Boolean.Parse(cell.Value.ToString()); ;
                        break;
                    case "Phone":
                        txtPhone.Text = cell.Value.ToString();
                        break;
                    case "AltPhone":
                        txtAltPhone.Text = cell.Value.ToString();
                        break;
                    case "Fax":
                        txtFax.Text = cell.Value.ToString();
                        break;
                    case "Email":
                        txtEmail.Text = cell.Value.ToString();
                        break;
                    case "ActiveFlag":
                        chkActive.Checked = Boolean.Parse(cell.Value.ToString());
                        break;
                    case "Terms":
                        txtTerms.Text = cell.Value.ToString();
                        break;
                    case "AddressID":
                        m_AddressID = Int32.Parse(cell.Value.ToString());
                        Address add = new Address();
                        add = add.GetAddresss(m_AddressID);
                        txtStreetAddress.Text = add.AddressLine1;
                        txtCity.Text = add.City;
                        txtState.Text = add.StateProvince;
                        txtZip.Text = add.PostalCode;
                        break;

                }

            }
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            PopulateGrid(0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int vendorID = 0;
            Vendor v = new Vendor();
            DataGridViewRow row = new DataGridViewRow();
            row = vendorGrid.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("Please select form the vendor's list");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record","Vendor Record",MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                vendorID = Int32.Parse(row.Cells[0].Value.ToString());
                v.RemoveVendor(vendorID);
                PopulateGrid(0);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                v = null;
            }
        }
        private bool IsInvalidControl()
        {
            bool invalid = false;
            foreach (Control ctrl in groupInput.Controls)
            {
                if (errorProvider1.GetError(ctrl) != "")
                {
                    invalid = true;
                    break;
                }
            }
            if (invalid)
            {
                MessageBox.Show("There are some invalid fields","Invalid Input",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            return invalid;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtName, "Field required");
            }
            else
            {
                errorProvider1.SetError(txtName,"");// SetError(txtName, "Field required");
            }
        }

        private void txtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtAccountNumber.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtAccountNumber, "Field required");
            }
            else
            {
                errorProvider1.SetError(txtAccountNumber,"");// SetError(txtName, "Field required");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhone.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtPhone, "Field required");
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtCreditRating_Validating(object sender, CancelEventArgs e)
        {
            if (txtCreditRating.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtCreditRating, "Field required");
            }
            else
            {
                errorProvider1.SetError(txtCreditRating, "");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void vendorGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmVendor_Load_1(object sender, EventArgs e)
        {



        }

        private void vendorGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void vendorGrid_SelectionChanged(object sender, EventArgs e)
        {
            GridRowChanged(-1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupInput_Enter(object sender, EventArgs e)
        {

        }

        
    }
}