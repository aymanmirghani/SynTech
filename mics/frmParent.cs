using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS
{
    public partial class frmParent : Form
    {
          

       
        public frmParent()
        {
            InitializeComponent();
            
            
            
        }
        #region VALIDATION
        protected bool ValidateDataGridViewEmpty(DataGridView obj)
        {
            if (obj.Rows.Count < 1)
            {
                errProvider.SetError(obj, "Grid can not be empty");
                return false;
            }
            else
            {
                errProvider.SetError(obj, "");
                return true;
            }
        }
        protected bool ValidateEmpty(TextBox obj)
        {
            if (obj.Text.Trim() == String.Empty)
            {
                errProvider.SetError(obj, "Field can not be empty");
                return false;
            }
            else
            {
                errProvider.SetError(obj, "");
                return true;
            }
        }
        protected bool ValidateComoBox(ComboBox obj)
        {
            if (obj.SelectedIndex == 0)
            {
                errProvider.SetError(obj, "Select a value");
                return false;
            }
            else
            {
                errProvider.SetError(obj, "");
                return true;
            }
        }
        protected bool ValidateNumbers(TextBox obj)
        {
            try
            {
                int x = Int32.Parse(obj.Text);
                return true;
            }
            catch 
            {
                errProvider.SetError(obj, "Not a number");
                return false;
            }

        }
        protected bool ValidateDecimal(TextBox obj)
        {
            try
            {
                decimal x = decimal.Parse(obj.Text,System.Globalization.NumberStyles.Currency);
                return true;
            }
            catch
            {
                errProvider.SetError(obj, "Not a number");
                return false;
            }

        }
        #endregion
        #region GRID METHODS
        protected decimal CalcualteTotal(DataGridView dgv)
        {

            Cursor.Current = Cursors.WaitCursor;
            decimal price = 0.00m;
            decimal total = 0.00m;
            decimal tot = 0.00m;
            int quantity = 0;
            int count = dgv.Rows.Count;
            if (count < 1) return 0.00m;
            for (int i = 0; i < count; i++)
            {
                quantity = Int32.Parse(dgv.Rows[i].Cells["Quantity"].Value.ToString());
                price = Decimal.Parse(dgv.Rows[i].Cells["Price"].Value.ToString());
                tot =(decimal)(quantity * price);
                dgv.Rows[i].Cells["Total"].Value =  tot;
                total += tot;

            }
            return total;
        }
        protected decimal CleanMoney(string amount)
        {
            //decimal ret = 0.00m;
            char[] moneytrain= amount.ToCharArray();
            char[] temp = {};
            for (int i = 0; i < moneytrain.Length; i++)
            {
                if (moneytrain[i] == '$' || moneytrain[i]==',')
                {
                    amount = amount.Remove(i, 1);
                }
            }
            

            return Decimal.Parse(amount); 
        }
        protected string FormatMoney(decimal value)
        {
            return String.Format("{0:c}", value);
        }
        protected decimal GetTotal(DataGridView dgv)
        {
            decimal total = 0.00m;
            string amount = String.Empty;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                amount = dgv.Rows[i].Cells["Total"].Value.ToString();
                total += CleanMoney(amount);
            }
            return total;
        }
        #endregion
    }
}