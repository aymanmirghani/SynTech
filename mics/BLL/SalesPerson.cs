using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesPerson{
        private LogWriter log = new LogWriter();
       

        private System.Int32 _SalesPersonID;
        private System.Int32 _TerritoryID;
        private System.Decimal _SalesQuota;
        private System.Decimal _Bonus;
        private System.Decimal _CommissionPct;
        private System.DateTime _ModifiedDate;
        private System.String _FirstName;
        private System.String _MiddleName;
        private System.String _LastName;
        private System.String _FullName;

        public SalesPerson(){}
        public SalesPerson(
                    System.Int32 salespersonid,
                    System.Int32 territoryid,
                    System.Decimal salesquota,
                    System.Decimal bonus,
                    System.Decimal commissionpct,
                    System.DateTime modifieddate)
        {
            this._SalesPersonID = salespersonid;
            this._TerritoryID = territoryid;
            this._SalesQuota = salesquota;
            this._Bonus = bonus;
            this._CommissionPct = commissionpct;
            this._ModifiedDate = modifieddate;
        }
		
		public System.Int32 SalesPersonID{
			get{return _SalesPersonID;}
			set{ _SalesPersonID=value;}
		}
		public System.Int32 TerritoryID{
			get{return _TerritoryID;}
			set{ _TerritoryID=value;}
		}
		public System.Decimal SalesQuota{
			get{return _SalesQuota;}
			set{ _SalesQuota=value;}
		}
		public System.Decimal Bonus{
			get{return _Bonus;}
			set{ _Bonus=value;}
		}
		public System.Decimal CommissionPct{
			get{return _CommissionPct;}
			set{ _CommissionPct=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}

        public System.String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public System.String MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }
        public System.String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public System.String FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        public int AddSalesPerson(SalesPerson salesperson)
        {
            SalesPersonData data = new SalesPersonData();
            int ret = 0;
            try
            {
                ret = data.AddUpdateSalesPerson(salesperson);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesPerson");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveSalesPerson(SalesPerson salesperson)
        {
            SalesPersonData data = new SalesPersonData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesPerson(salesperson);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesPerson");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesPerson(SalesPerson salesperson)
        {
            SalesPersonData data = new SalesPersonData();
            bool ret = false;
            try
            {
                ret = data.UpdateSalesPerson(salesperson);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesPerson");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SalesPerson GetSalesPersons(int salesPersonID)
        {
            SalesPersonData data = new SalesPersonData();
            SalesPerson sp = new SalesPerson();
            try
            {
                sp = data.GetSalesPerson(salesPersonID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersons");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sp;
        }
        public DataSet GetAllSalesPersonDataSet()
        {
            SalesPersonData data = new SalesPersonData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesPersonsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesPersonCollection GetAllSalesPersonsCollection()
        {
            SalesPersonData data = new SalesPersonData();
            SalesPersonCollection col = new SalesPersonCollection();
            try
            {
                col = data.GetAllSalesPersonsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesPersonsDataSet(string where, string orderBy)
        {
            SalesPersonData data = new SalesPersonData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesPersonsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesPersonCollection GetSalesPersonCollection(string where, string orderBy)
        {
            SalesPersonData data = new SalesPersonData();
            SalesPersonCollection col = new SalesPersonCollection();
            try
            {
                col = data.GetAllSalesPersonsDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

        public DataSet GetAllSalesPersonViewDataSet()
        {
            SalesPersonData data = new SalesPersonData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesPersonsViewDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonViewDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesPersonCollection GetAllSalesPersonViewCollection()
        {
            SalesPersonData data = new SalesPersonData();
            SalesPersonCollection col = new SalesPersonCollection();
           // DataSet ds = new DataSet();
            try
            {
                col = data.GetAllSalesPersonsViewCollection();
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonViewCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
    }
}
