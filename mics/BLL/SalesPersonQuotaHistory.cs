using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesPersonQuotaHistory{
        private LogWriter log = new LogWriter();
        private System.Int32 _SalesPersonID;
        private System.DateTime _QuotaDate;
        private System.Decimal _SalesQuota;
        private System.DateTime _ModifiedDate;

        public SalesPersonQuotaHistory(){}
        public SalesPersonQuotaHistory(
                    System.Int32 salespersonid,
                    System.DateTime quotadate,
                    System.Decimal salesquota,
                    System.DateTime modifieddate)
        {
            this._SalesPersonID = salespersonid;
            this._QuotaDate = quotadate;
            this._SalesQuota = salesquota;
            this._ModifiedDate = modifieddate;
        }
		public System.Int32 SalesPersonID{
			get{return _SalesPersonID;}
			set{ _SalesPersonID=value;}
		}
		public System.DateTime QuotaDate{
			get{return _QuotaDate;}
			set{ _QuotaDate=value;}
		}
		public System.Decimal SalesQuota{
			get{return _SalesQuota;}
			set{ _SalesQuota=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public bool AddSalesPersonQuotaHistory(SalesPersonQuotaHistory salespersonquotahistory)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            bool ret = false;
            try
            {
                ret = data.AddSalesPersonQuotaHistory(salespersonquotahistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveSalesPersonQuotaHistory(SalesPersonQuotaHistory salespersonquotahistory)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesPersonQuotaHistory(salespersonquotahistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesPersonQuotaHistory(SalesPersonQuotaHistory salespersonquotahistory)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData(); 
            bool ret = false;
            try
            {
                ret = data.UpdateSalesPersonQuotaHistory(salespersonquotahistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SalesPersonQuotaHistory GetSalesPersonQuotaHistory(int salesPersonID)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            SalesPersonQuotaHistory spqh = new SalesPersonQuotaHistory();
            try
            {
                spqh = data.GetSalesPersonQuotaHistory(salesPersonID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonQuotaHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return spqh;
        }
        public DataSet GetAllSalesPersonQuotaHistoryDataSet()
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesPersonQuotaHistorysDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesPersonQuotaHistoryCollection GetAllSalesPersonQuotaHistoryCollection()
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            SalesPersonQuotaHistoryCollection col = new SalesPersonQuotaHistoryCollection();
            try
            {
                col = data.GetAllSalesPersonQuotaHistorysCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesPersonQuotaHistoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesPersonQuotaHistoryDataSet(string where, string orderBy)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesPersonQuotaHistorysDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonQuotaHistoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesPersonQuotaHistoryCollection GetSalesPersonQuotaHistoryCollection(string where, string orderBy)
        {
            SalesPersonQuotaHistoryData data = new SalesPersonQuotaHistoryData();
            SalesPersonQuotaHistoryCollection col = new SalesPersonQuotaHistoryCollection();
            try
            {
                col = data.GetAllSalesPersonQuotaHistorysDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesPersonQuotaHistoryCollection");
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
