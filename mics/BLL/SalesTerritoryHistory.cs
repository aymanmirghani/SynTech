using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesTerritoryHistory{
        private LogWriter log = new LogWriter();

		public SalesTerritoryHistory(){}
		public SalesTerritoryHistory(
                    System.Int32 id,
					System.Int32 salespersonid,
					System.Int32 territoryid,
					System.DateTime startdate,
					System.DateTime enddate,
					System.DateTime modifieddate
		){
        this._ID = id;
		this._SalesPersonID = salespersonid;
		this._TerritoryID = territoryid;
		this._StartDate = startdate;
		this._EndDate = enddate;
		this._ModifiedDate = modifieddate;
		}
            private System.Int32 _ID;
			private System.Int32 _SalesPersonID;
			private System.Int32 _TerritoryID;
			private System.DateTime _StartDate;
			private System.DateTime _EndDate;
			private System.DateTime _ModifiedDate;
        public System.Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
		public System.Int32 SalesPersonID{
			get{return _SalesPersonID;}
			set{ _SalesPersonID=value;}
		}
		public System.Int32 TerritoryID{
			get{return _TerritoryID;}
			set{ _TerritoryID=value;}
		}
		public System.DateTime StartDate{
			get{return _StartDate;}
			set{ _StartDate=value;}
		}
		public System.DateTime EndDate{
			get{return _EndDate;}
			set{ _EndDate=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public bool AddSalesTerritoryHistory(SalesTerritoryHistory salesterritoryhistory)
        {
            SalesTerritoryHistoryData data = new SalesTerritoryHistoryData();
            bool ret = true;
            try
            {
                ret = data.AddSalesTerritoryHistory(salesterritoryhistory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public DataSet GetSalesTerritoryHistoryViewDataSet()
        {
            SalesTerritoryHistoryData data = new SalesTerritoryHistoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesTerritoryHistorysViewDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryHistoryViewDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public DataSet GetSalesTerritoryBySalesPerson()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select ter.territoryid,ter.name [Territory],(select distinct(salespersonid) from salesterritoryhistory his where his.territoryid=ter.territoryid and startdate <= getdate() and (enddate >= getdate() or enddate is null)) as SalesPersonID,";
                sql += "(select distinct(ID) from salesterritoryhistory his where his.territoryid=ter.territoryid and startdate <= getdate() and (enddate >= getdate() or enddate is null)) as ID,";
                sql += "(select (rtrim(emp.firstName) + ' ' + rtrim(emp.middleName) + ' ' + rtrim(emp.lastName)) from salesterritoryhistory his,employee emp where his.salespersonid=emp.employeeid and his.territoryid=ter.territoryid and startdate <= getdate() and (enddate >= getdate() or enddate is null)) as [Sales Person],";
                sql += "(select distinct(startdate) from salesterritoryhistory his where his.territoryid=ter.territoryid and startdate <= getdate() and (enddate >= getdate() or enddate is null)) as [Start Date],";
                sql += "(select distinct(enddate) from salesterritoryhistory his where his.territoryid=ter.territoryid and startdate <= getdate() and (enddate >= getdate() or enddate is null)) as [End Date] ";
                sql += " from salesterritory ter";
                GenericQuery q = new GenericQuery();
                ds = q.GetDataSet(false, sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryBySalesPerson");
                throw(ex);
            }

            return ds;

        }
        public void RemoveSalesTerritoryHistory(SalesTerritoryHistory salesterritoryhistory)
        {
            SalesTerritoryHistoryData data = new SalesTerritoryHistoryData();
            try
            {
                data.DeleteSalesTerritoryHistory(salesterritoryhistory.SalesPersonID);
               
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
        }
		public void UpdateSalesTerritoryHistory(SalesTerritoryHistory salesterritoryhistory)
        {
            SalesTerritoryHistoryData data = new SalesTerritoryHistoryData();
            try
            {
                SalesTerritoryHistory hist = data.GetSalesTerritoryHistory(salesterritoryhistory.ID);
                if (hist.SalesPersonID == salesterritoryhistory.SalesPersonID &&
                    hist.StartDate == salesterritoryhistory.StartDate)
                {
                    return;
                }
                hist.EndDate = salesterritoryhistory.StartDate;
                data.UpdateSalesTerritoryHistory(hist);
                data.AddSalesTerritoryHistory(salesterritoryhistory);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTerritoryHistory");
                throw (ex);
            }
            finally
            {
                data = null;
            }

            
           
        }
        public DataSet GetSalesTerritoryHistory(int TerritoryId)
        {
            string sql = "select * from salesterritoryhistory where territoryid=" + TerritoryId.ToString();
            sql += " and enddate is null";
            GenericQuery query = new GenericQuery();
            DataSet ds = null;
            try
            {
                ds = query.GetDataSet(false, sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryHistory");
                throw (ex);
            }
            return ds;
        }
	}
}
