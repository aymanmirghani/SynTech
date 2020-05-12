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
    public partial class frmTerritory : frmParent
    {
        SalesTerritoryCollection colTerritories = new SalesTerritoryCollection();
        public frmTerritory()
        {
            InitializeComponent();
        }
        private bool ValidTerritory()
        {
            return (ValidateEmpty(txtTerritory));
        }
        private void PopulateTerritories(int selectedID)
        {
            SalesTerritory st = new SalesTerritory();
            colTerritories = new SalesTerritoryCollection();
            try
            {
                colTerritories = st.GetAllSalesTerritoryCollection();
                gridTerritory.DataSource = colTerritories;
                gridTerritory.Columns.Remove("ModifiedDate");
                gridTerritory.Columns["TerritoryID"].Visible = false;
                gridTerritory.Columns.Remove("CountryRegionCode");
                int index = 0;
                foreach (SalesTerritory t in colTerritories)
                {
                    if (t.TerritoryID == selectedID)
                    {
                        gridTerritory.Rows[index].Selected = true;
                        gridTerritory.FirstDisplayedScrollingRowIndex = index;
                        break;
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmTerritory_Load(object sender, EventArgs e)
        {
            PopulateTerritories(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTerritory.Text = String.Empty;
            lblTerritoryID.Text = String.Empty;
        }
        private int DeleteTerritory()
        {
            Cursor.Current = Cursors.WaitCursor;
            SalesTerritory st = new SalesTerritory();
            int terrID = 0;
            try
            {
                terrID = Int32.Parse(lblTerritoryID.Text);
            }
            catch
            {
                MessageBox.Show("Select a territory to delete", "Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return 0;
            }
            try
            {
                st.RemoveSalesTerritory(terrID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
                st = null;
                Cursor.Current = Cursors.Default;
            }
            return (terrID);

        }
        private int UpdateTerritory()
        {
            Cursor.Current = Cursors.WaitCursor;
            SalesTerritory st = new SalesTerritory();
            string name = txtTerritory.Text.Trim();
            int terrID = 0;
            try
            {
                terrID = Int32.Parse(lblTerritoryID.Text.ToString());
            }
            catch 
            {
                terrID = 0;
                MessageBox.Show("Select a territory to update","Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            try
            {
                st.Name = name;
                st.TerritoryID = terrID;
                st.CountryRegionCode = string.Empty;
                st.UpdateSalesTerritory(st);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                st = null;
            }
            return terrID;
        }
        private int AddTerritory()
        {
            Cursor.Current = Cursors.WaitCursor;
            SalesTerritory st = new SalesTerritory();
            int id = 0;
            try
            {
                string territory = txtTerritory.Text.Trim();
                st.Name = territory;
                st.ModifiedDate = DateTime.Now;
                st.CountryRegionCode = string.Empty;
                id = st.AddSalesTerritory(st);
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Sales Territory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidTerritory() == false) return;
            int selectedID = 0;
            if (lblTerritoryID.Text.Length > 0)
            {
                selectedID = UpdateTerritory();
            }
            else
            {
                selectedID = AddTerritory();
            }
            PopulateTerritories(selectedID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = gridTerritory.CurrentRow.Index;
            DeleteTerritory();
            PopulateTerritories(0);
            index++;
            if (index >= gridTerritory.Rows.Count)
                index = 0;
            gridTerritory.Rows[index].Selected = true;
            gridTerritory.FirstDisplayedScrollingRowIndex = index;
        }
        private void GridRowChanged()
        {
            DataGridViewRow row = new DataGridViewRow();
            row = gridTerritory.CurrentRow;

            if (row == null) return;
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.OwningColumn.Name)
                {
                    case "TerritoryID":
                        lblTerritoryID.Text = cell.Value.ToString();
                        break;
                    case "Name":
                        txtTerritory.Text = cell.Value.ToString();
                        break;
                }
            }
        }

        private void gridTerritory_SelectionChanged(object sender, EventArgs e)
        {
            GridRowChanged();
        }

        private void gridTerritory_MouseClick(object sender, MouseEventArgs e)
        {
            GridRowChanged();
        }

    }
}