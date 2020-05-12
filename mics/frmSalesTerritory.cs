using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MICS.BLL;

namespace MICS
{
    public partial class frmSalesTerritory : Form
    {
        private int[] TerritoryHistId = { 0 };
        private int m_currentHistoryId = 0;
        DataTable  dtTerritoryList = null;
        public frmSalesTerritory()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSalesTerritory_Load(object sender, EventArgs e)
        {
            RefreshForm();

        }
        private void RefreshForm()
        {
            ClearSalePersonData();
            ClearTerritoryData();
            PopulateComboBoxes();
            PopulateGrids();
        }
        private void PopulateComboBoxes()
        {

            Employee emp = new Employee();
            EmployeeCollection empCol = new EmployeeCollection();
            SalesPerson sp = new SalesPerson();
           // DataSet ds = null;
            try
            {
                //Employee combo box.
                //ds = emp.GetAllEmployeesDataSet();
                empCol = emp.GetAllEmployeesCollection();
                emp.EmployeeID = 0;
                emp.FullName = "<Select One>";
                emp.FirstName = "";
                emp.LastName = "";
                empCol.Insert(0, emp);
                cmbEmployeeName.DataSource = empCol;
                cmbEmployeeName.DisplayMember = "FullName";
                cmbEmployeeName.ValueMember = "EmployeeID";
                
                //DataTable dt = ds.Tables[0];
                //DataRow dr = dt.NewRow();
                //dr["EmployeeID"] = "0";
                //dr["FullName"] = "<Select One>";
                //dt.Rows.InsertAt(dr, 0);
                //cmbEmployeeName.DataSource = dt;
                //cmbEmployeeName.DisplayMember = "FullName";
                //cmbEmployeeName.ValueMember = "EmployeeID";

                //sale person comb box
                DataSet dsSalePerson = sp.GetAllSalesPersonViewDataSet();
                DataTable dtSalePerson = dsSalePerson.Tables[0];
                DataRow drSalePerson = dtSalePerson.NewRow();
                drSalePerson["SalesPersonID"] = "0";
                drSalePerson["FullName"] = "<Select One>";
                dtSalePerson.Rows.InsertAt(drSalePerson, 0);
                cmbSalesPerson.DataSource = dtSalePerson;
                cmbSalesPerson.DisplayMember = "FullName";
                cmbSalesPerson.ValueMember = "SalesPersonID";
                foreach (DataRow drow in dtSalePerson.Rows)
                {
                    string item = drow["SalesPersonID"].ToString();
                    string name = drow["FullName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }
            finally
            {
                //ds = null;
            }

        }
        private void PopulateGrids()
        {
            SalesPerson sp = new SalesPerson();
            SalesTerritoryHistory hist = new SalesTerritoryHistory();
            DataSet ds = null;
            try
            {
                //sale person grid
                ds = sp.GetAllSalesPersonViewDataSet();
                DataTable dt = ds.Tables[0];
                dt.Columns.Remove("FirstName");
                dt.Columns.Remove("LastName");
                dt.Columns.Remove("MiddleName");
                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Name";
                dt.Columns[2].ColumnName = "Quota";
                dt.Columns[3].ColumnName = "Bonus";
                dt.Columns[4].ColumnName = "Commission";
                dgSalesPerson.DataSource = dt;

                //sale territory grid
                ds = hist.GetSalesTerritoryBySalesPerson();
                dtTerritoryList = ds.Tables[0];
                dgTerritoryList.DataSource = dtTerritoryList;
                dgTerritoryList.Columns["ID"].Visible = false;
                dgTerritoryList.Columns["territoryid"].Visible = false;
                dgTerritoryList.Columns["SalesPersonID"].Visible = false;
                //ds = hist.GetSalesTerritoryHistoryViewDataSet();
                //dt = ds.Tables[0];
               //int i = 0;
                //TerritoryHistId = new int[dT.Rows.Count];
                //foreach (DataRow dr in dt.Rows	
                //{
                //    TerritoryHistId[i+] = Int32.Parse(dr["ID"].ToString());                   
               //}
                //dt.Columns.Remove("SalesPersonID");
                //dt.Columns.Remove("ID");
                //dt.Columns[0].ColumnName = "ID";
                //dt.Columns[1].ColumnName = "Territory";
                //dt.Columns[2].ColumnName = "Sale Person";
                //dt.Columns[3].ColumnName = "Start Date";
                //dt.Columns[4].ColumnName = "End Date";
                //dgTerritoryList.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }
        }
        private void btnSaveSalePerson_Click(object sender, EventArgs e)
        {
            if (cmbEmployeeName.Items.Count == 0)
                btnSaveSalePerson.Enabled = false;
            else
                btnSaveSalePerson.Enabled = true;
            if (cmbEmployeeName.SelectedIndex == 0)
            {
                MessageBox.Show("Pleae select an employee", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SalesPerson sp = new SalesPerson();
            try
            {
                if (cmbEmployeeName.Items.Count > 0 && cmbEmployeeName.SelectedValue != null)
                {
                    sp.SalesPersonID = Int32.Parse(cmbEmployeeName.SelectedValue.ToString());
                
                }
                int index = cmbEmployeeName.SelectedIndex;
                
                if (txtSalesQuota.Text.Trim() != String.Empty)
                {
                    sp.SalesQuota = decimal.Parse(txtSalesQuota.Text);
                }
                if (txtCommissionPct.Text.Trim() != String.Empty)
                {
                    sp.CommissionPct = decimal.Parse(txtCommissionPct.Text);
                }
                if (txtBounus.Text.Trim() != string.Empty)
                {
                    sp.Bonus = decimal.Parse(txtBounus.Text);
                }
                sp.AddSalesPerson(sp);
                MessageBox.Show("Record Saved Successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sp = null;
            }

        }

        private void groupInput_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SalesTerritory st = new SalesTerritory();
            SalesTerritoryHistory hist = new SalesTerritoryHistory();
            try
            {
                if (txtName.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter territory name", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (cmbSalesPerson.Items.Count == 0)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;
                if (cmbSalesPerson.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a sale person", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                st.Name = txtName.Text;
                st.CountryRegionCode = txtCounty.Text;
                
                if (txtTerritoryID.Text.Trim() == String.Empty)
                {
                    //new record
                    hist.TerritoryID = st.AddSalesTerritory(st);
                    hist.SalesPersonID = Int32.Parse(cmbSalesPerson.SelectedValue.ToString());
                    hist.StartDate = dtStartDate.Value;
                    //hist.EndDate = null;
                    hist.AddSalesTerritoryHistory(hist);
                    MessageBox.Show("Record saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //existing record, update territory and territory history
                    st.TerritoryID = Int32.Parse(txtTerritoryID.Text);
                    st.UpdateSalesTerritory(st);

                    hist.ID = m_currentHistoryId;
                    
                    hist.SalesPersonID = Int32.Parse(cmbSalesPerson.SelectedValue.ToString());
                    hist.TerritoryID = st.TerritoryID;
                    hist.StartDate = dtStartDate.Value;
                    //hist.EndDate = dtEndDate.Value;
                    hist.UpdateSalesTerritoryHistory(hist);
                    //hist.AddSalesTerritoryHistory(hist);
                    MessageBox.Show("Record saved successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                st = null;
            }

        }

        private void groupTerritory_Enter(object sender, EventArgs e)
        {

        }

        private void dgSalesPerson_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgSalesPerson.CurrentRow;
            if (row == null) return;
            ClearSalePersonData();
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.OwningColumn.Name)
                {
                    case "ID":
                        txtEmployeeID.Text = cell.Value.ToString();
                        break;
                    case "Name":
                        int index = cmbEmployeeName.FindStringExact(cell.Value.ToString());
                        cmbEmployeeName.SelectedIndex = cmbEmployeeName.FindStringExact(cell.Value.ToString());
                        break;
                    case "Quota":
                        txtSalesQuota.Text = cell.Value.ToString();
                        break;
                    case "Bonus":
                        txtBounus.Text = cell.Value.ToString();
                        break;
                    case "Commission":
                        txtCommissionPct.Text = cell.Value.ToString();
                        break;
                    default:
                        break;

                }
            }
        }
        private void ClearSalePersonData()
        {
            txtEmployeeID.Text = "";
            txtBounus.Text = "";
            txtCommissionPct.Text = "";
            txtSalesQuota.Text = "";
            if (cmbEmployeeName.Items.Count > 0)
            {
                cmbEmployeeName.SelectedIndex = 0;
            }
        }
        private void ClearTerritoryData()
        {
            txtName.Text = "";
            txtTerritoryID.Text = "";
            txtCounty.Text = "";
            if (cmbSalesPerson.Items.Count > 0)
            {
                cmbSalesPerson.SelectedIndex = 0;
            }
           
        }

        private void dgTerritoryList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgTerritoryList.CurrentRow;
                int selected_row = dgTerritoryList.CurrentRow.Index;
                // m_currentHistoryId = TerritoryHistId[selected_row];
                if (dtTerritoryList.Rows[selected_row]["ID"] != DBNull.Value)
                {
                    m_currentHistoryId = Int32.Parse(dtTerritoryList.Rows[selected_row]["ID"].ToString());
                }
                else
                {
                    m_currentHistoryId = 0;
                }
                if (row == null) return;
                ClearTerritoryData();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    switch (cell.OwningColumn.Name)
                    {
                        case "territoryid":
                            txtTerritoryID.Text = cell.Value.ToString();
                            break;
                        case "Territory":
                            txtName.Text = cell.Value.ToString();
                            break;
                        case "Sales Person":
                            cmbSalesPerson.SelectedIndex = cmbSalesPerson.FindStringExact(cell.Value.ToString());
                            break;
                        case "Start Date":
                            if (cell.Value != DBNull.Value)
                            {
                                dtStartDate.Value = DateTime.Parse(cell.Value.ToString());
                            }
                            else
                            {
                                dtStartDate.Value = DateTime.Today;
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearTerritoryData();
        }

        private void btnSearchSalesPerson_Click(object sender, EventArgs e)
        {
            ClearSalePersonData();
        }

        private void btnDeleteSalesPerson_Click(object sender, EventArgs e)
        {
            if(txtEmployeeID.Text == "")
            {
                MessageBox.Show("Can't delete. No sales person selected. Please select a sale person from the grid below.","MICS",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            string msg = "Are you sure you want to delete " + cmbEmployeeName.Text + " from the sales person list.?";
            if (MessageBox.Show(msg, "MICS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SalesPerson sp = new SalesPerson();
                SalesTerritoryHistory hist = new SalesTerritoryHistory();
                try
                {
                    sp.SalesPersonID = Int32.Parse(txtEmployeeID.Text);
                    hist.SalesPersonID = sp.SalesPersonID;
                    sp.RemoveSalesPerson(sp);
                    hist.RemoveSalesTerritoryHistory(hist);
                    MessageBox.Show("Record deleted successfully", "MICS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sp = null;
                }
            }

        }

        private void dgTerritoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}