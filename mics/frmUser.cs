using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Authentication;
using MICS.BLL;
namespace MICS
{
    public partial class frmUser : frmParent
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void PopulateEmployee()
        {
            Employee emp = new Employee();
            Employee selectNew = new Employee();
            Cursor.Current = Cursors.WaitCursor;
            EmployeeCollection col = new EmployeeCollection();
            try
            {
               
                selectNew.EmployeeID = 0;
                selectNew.FullName = "[Select One]";
                col = emp.GetAllEmployeesCollection();
                col.Insert(0, selectNew);
                cmbEmployee.DataSource = col;
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "EmployeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                emp = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            PopulateEmployee();
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            User usr = new User();
            UserCollection usrCol = new UserCollection ();
            string where =String.Empty;
            string orderBy=String.Empty;
            int employeeID = 0;
            try
            {
                employeeID = Int32.Parse(cmbEmployee.SelectedValue.ToString());
                where= "[EmployeeID]=" + employeeID;
                orderBy = "[LastName]";
                usrCol = usr.GetAllUsersCollection(where, orderBy);
                if (usrCol.Count > 1)
                {
                    MessageBox.Show("Dublicate users\n EmployeeID=" + employeeID, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (usrCol.Count == 1)
                {
                    usr =(User)usrCol[0];
                    MessageBox.Show(usr.EmployeeID.ToString());
        

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                usr = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields() == false) return;
            int userid = 0;
            try
            {
                userid = Int32.Parse(lblUserID.Text);
            }
            catch
            {
                userid = 0;
            }
            if (userid > 1)
            {
                UpdateUser();
            }
            else
            {
                AddUser();
            }
        }
        private void AddUser()
        {
           
            User usr = new User();
            int employeeID = 0;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                employeeID = Int32.Parse(cmbEmployee.SelectedValue.ToString());
            }
            catch
            {
                employeeID = 0;
            }
            if (employeeID == 0) return;
            try
            {
                usr.EmployeeID = employeeID;
                usr.UserName = txtUserName.Text.Trim();
                usr.Password = txtPassword.Text;
                usr.AddUser(usr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                usr = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void UpdateUser()
        {
            User usr = new User();
            int usrID = 0;
            int employeeID = 0;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                usrID = Int32.Parse(lblUserID.Text);
                employeeID = Int32.Parse(cmbEmployee.SelectedValue.ToString());
            }
            catch
            {
                usrID = 0;
                employeeID = 0;
            }
            if (usrID == 0) return;
            try
            {
                usr.EmployeeID = employeeID;
                usr.ID = usrID;
                usr.UserName = txtUserName.Text.Trim();
                usr.Password = txtPassword.Text;
                usr.UpdateUser(usr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                usr = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private void DeleteUser()
        {
            User usr = new User();
            int usrID = 0;
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                usrID = Int32.Parse(lblUserID.Text);
            }
            catch
            {
                usrID = 0;
            }
            try
            {
                if (usrID == 0) return;
                usr.ID = usrID;
                usr.RemoveUser(usrID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                usr = null;
            }
            Cursor.Current = Cursors.Default;
        }
        private bool ValidateFields()
        {
            ValidateEmpty(txtUserName);
            ValidateEmpty(txtPassword);
            ValidateComoBox(cmbEmployee);
            ValidateEmpty(txtAddressLine1);
            ValidateEmpty(txtCity);
            ValidateEmpty(txtState);
            ValidateEmpty(txtZipcode);

            if(!ValidateEmpty(txtUserName)) return false;
            if(!ValidateEmpty(txtPassword)) return false;
            if (!ValidateComoBox(cmbEmployee)) return false;
            if (!ValidateEmpty(txtAddressLine1)) return false;
            if (!ValidateEmpty(txtCity)) return false;
            if (!ValidateEmpty(txtState)) return false;
            if (!ValidateEmpty(txtZipcode)) return false;
            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}