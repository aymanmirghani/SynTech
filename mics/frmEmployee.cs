using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
using System.Data.SqlClient;
namespace MICS
{
    public partial class frmEmployee : frmParent
    {
        public frmEmployee()
        {
            InitializeComponent();
           
        }
        private void PopulateEmployee(bool ShowAll)
        {
            Employee employee = new Employee();
            DataSet empDs = new DataSet();
            StringBuilder sb = new StringBuilder();
            string orderBy = "[LastName]";
            if (!ShowAll)
            {
                if (txtFirstName.Text.Trim() != String.Empty)
                {
                    sb.Append("[FirstName]='" + txtFirstName.Text.Trim() + "'");
                }
                if (txtLastName.Text.Trim() != String.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND [LastName]='" + txtLastName.Text.Trim() + "'");
                    }
                    else
                    {
                        sb.Append("[LastName]='" + txtLastName.Text.Trim() + "'");
                    }
                }
                if (txtUserName.Text.Trim() != String.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND [Login]='" + txtUserName.Text.Trim() + "'");
                    }
                    else
                    {
                        sb.Append("[Login]='" + txtUserName.Text.Trim() + "'");
                    }

                }
            }
           
            try
            {
                if (sb.Length > 0)
                {
                    empDs = employee.GetEmployeesDataSet(sb.ToString(), orderBy);
                }
                else
                {
                    empDs = employee.GetAllEmployeesDataSet();
                }
                
                DataTable dt = new DataTable();
                dt = empDs.Tables[0];
                if (sb.Length == 0)
                {
                    dt.Columns.Remove("FullName");
                }
                EmployeeGrid.DataSource = dt;
                EmployeeGrid.Columns["EmployeeID"].Visible = false;
                EmployeeGrid.Columns["AddressID"].Visible = false;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            PopulateEmployee(true);
        }
        private bool ValidateFields()
        {
            ValidateEmpty(txtFirstName);
            ValidateEmpty(txtLastName);
            ValidateEmpty(txtAddressLine1);
            ValidateEmpty(txtCity);
            ValidateEmpty(txtState);
            ValidateEmpty(txtZipcode);
            if (ValidateEmpty(txtFirstName) == false) return false;
            if (ValidateEmpty(txtLastName) == false) return false;
            if (ValidateEmpty(txtFirstName) == false) return false;
            if (ValidateEmpty(txtAddressLine1) == false) return false;
            if (ValidateEmpty(txtCity) == false) return false;
            if (ValidateEmpty(txtState) == false) return false;
            if (ValidateEmpty(txtZipcode) == false) return false;
            
            return true;
        }
        private void EmployeeGrid_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            Employee employee = new Employee();
            Address address = new Address();
           
            row = EmployeeGrid.CurrentRow;
            if (row == null) return;
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.OwningColumn.Name)
                {
                    case "EmployeeID":
                        lblEmployeeID.Text = cell.Value.ToString().Trim();
                        break;
                    case "FirstName":
                        txtFirstName.Text = cell.Value.ToString().Trim();
                        break;
                    case "MiddleName":
                        txtMiddleName.Text = cell.Value.ToString().Trim();
                        break;
                    case "LastName":
                        txtLastName.Text = cell.Value.ToString().Trim();
                        break;
                    case "Login":
                        txtUserName.Text = cell.Value.ToString().Trim();
                        break;
                    case "WorkPhone":
                        txtWorkPhone.Text = cell.Value.ToString().Trim();
                        break;
                    case "HomePhone":
                        txtHomePhone.Text = cell.Value.ToString().Trim();
                        break;
                    case "CellPhone":
                        txtCellPhone.Text = cell.Value.ToString().Trim();
                        break;
                    case "AddressID":
                        int addressid = Int32.Parse(cell.Value.ToString());
                        address = address.GetAddresss(addressid);
                        if (address != null)
                        {
                            txtAddressLine1.Text = address.AddressLine1;
                            txtAddressLine2.Text = address.AddressLine2;
                            txtCity.Text = address.City;
                            txtState.Text = address.StateProvince;
                            txtZipcode.Text = address.PostalCode;

                        }
                        break;
                }
            }
        }

       
        public void ClearFields()
        {
            txtAddressLine2.Text = String.Empty;
            txtAddressLine1.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtState.Text = String.Empty;
            txtZipcode.Text = String.Empty;

            txtFirstName.Text = String.Empty;
            txtMiddleName.Text = String.Empty;
            txtLastName.Text = String.Empty;

            
            txtUserName.Text = String.Empty;
            txtCellPhone.Text = String.Empty;
            txtWorkPhone.Text = String.Empty;
            txtHomePhone.Text = String.Empty;
            
            lblEmployeeID.Text = String.Empty;
        }

       

        private void Save()
        {
            if (ValidateFields() == false) return;
            if (lblEmployeeID.Text.Length > 0)
            {
                UpdateEmployeeAddress();
            }
            else
            {
                AddEmployeeAddress();
            }
            PopulateEmployee(true);
        }
        private void AddEmployeeAddress()
        {
            Cursor.Current = Cursors.WaitCursor;
            Employee employee = new Employee();
            Address address = new Address();
            try
            {
                address.AddressLine1 = txtAddressLine1.Text.Trim();
                address.AddressLine2 = txtAddressLine2.Text.Trim();
                address.City = txtCity.Text.Trim();
                address.StateProvince = txtState.Text.Trim();
                address.PostalCode = txtZipcode.Text.Trim();

                int addressid = address.AddAddress(address);

                employee.FirstName = txtFirstName.Text.Trim();
                employee.MiddleName = txtMiddleName.Text.Trim();
                employee.LastName = txtLastName.Text.Trim();
                employee.Login = txtUserName.Text.Trim();
                employee.AddressID = addressid;
                employee.WorkPhone = txtWorkPhone.Text.Trim();
                employee.HomePhone = txtHomePhone.Text.Trim();
                employee.CellPhone = txtCellPhone.Text.Trim();

                employee.AddEmployee(employee);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Employee/Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                address = null;
                employee = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateEmployeeAddress()
        {
            int employeeID = Int32.Parse(lblEmployeeID.Text);
            if (employeeID < 1) return;
            Cursor.Current = Cursors.WaitCursor;
            Employee employee = new Employee();
            Address address = new Address();
            int cur_row = EmployeeGrid.CurrentRow.Index;
            int address_id = 0;
            try
            {
                address_id = Int32.Parse(EmployeeGrid.Rows[cur_row].Cells["AddressID"].Value.ToString());
                employee.AddressID = address_id;
                employee.FirstName = txtFirstName.Text.Trim();
                employee.MiddleName = txtMiddleName.Text.Trim();
                employee.LastName = txtLastName.Text.Trim();
                employee.Login = txtUserName.Text.Trim();
                employee.WorkPhone = txtWorkPhone.Text.Trim();
                employee.HomePhone = txtHomePhone.Text.Trim();
                employee.CellPhone = txtCellPhone.Text.Trim();
                //employee.AddressID = addressid;
                employee.EmployeeID =Int32.Parse(lblEmployeeID.Text );
                //employee = employee.GetEmployee(employee.EmployeeID);
                employee.UpdateEmployee(employee);

                address.AddressLine1 = txtAddressLine1.Text.Trim();
                address.AddressLine2 = txtAddressLine2.Text.Trim();
                address.City = txtCity.Text.Trim();
                address.StateProvince = txtState.Text.Trim();
                address.PostalCode = txtZipcode.Text.Trim();
                address.AddressID = employee.AddressID;
                if (address.AddressID < 1)
                {
                    employee.AddressID = address.AddAddress(address);
                    employee.UpdateEmployee(employee);
                }
                else
                {
                    address.UpdateAddress(address);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee/Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                address = null;
                employee = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void DeleteEmployeeAddress()
        {
            int employeeID = 0;
            try
            {
                employeeID = Int32.Parse(lblEmployeeID.Text);
            }
            catch
            {
                employeeID = 0;
            }
            if (employeeID < 1) return;
            Cursor.Current = Cursors.WaitCursor;
            Employee employee = new Employee();
            Address address = new Address();
            try
            {
                employee = employee.GetEmployee(employeeID);
                employee.RemoveEmployee(employee);
                address.RemoveAddress(employee.AddressID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee/Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                address = null;
                employee = null;
            }
            Cursor.Current = Cursors.Default;
        }

       
        private void Delete()
        {
            DeleteEmployeeAddress();
            PopulateEmployee(true);
        }

        

        private void txtState_Leave(object sender, EventArgs e)
        {
            txtState.Text = txtState.Text.ToUpper();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
           ValidateEmpty(txtFirstName) ;
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmpty(txtLastName);
        }

        private void txtAddressLine1_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmpty(txtAddressLine1);
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmpty(txtCity);
        }

        private void txtState_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmpty(txtState);
        }

        private void txtZipcode_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmpty(txtZipcode);
            
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PopulateEmployee(true);
        }

        private void btnFNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnFSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnFDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnFSearch_Click(object sender, EventArgs e)
        {
            PopulateEmployee(false);
        }

        private void btnFExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}