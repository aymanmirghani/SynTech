using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
    public class SalesTerritory
    {
        private LogWriter log = new LogWriter();

        private System.Int32 _TerritoryID;
        private System.String _Name;
        private System.String _CountryRegionCode;
        private System.DateTime _ModifiedDate;

        public SalesTerritory() { }
        public SalesTerritory(
                    System.Int32 territoryid,
                    System.String name,
                    System.String countryregioncode,
                    System.DateTime modifieddate)
        {
            this._TerritoryID = territoryid;
            this._Name = name;
            this._CountryRegionCode = countryregioncode;
            this._ModifiedDate = modifieddate;
        }

        public System.Int32 TerritoryID
        {
            get { return _TerritoryID; }
            set { _TerritoryID = value; }
        }
        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public System.String CountryRegionCode
        {
            get { return _CountryRegionCode; }
            set { _CountryRegionCode = value; }
        }
        public System.DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        public int AddSalesTerritory(SalesTerritory salesterritory)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            int ret = 0;
            try
            {
                ret = data.AddSalesTerritory(salesterritory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesTerritory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesTerritory(SalesTerritory salesterritory)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesTerritory(salesterritory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesTerritory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesTerritory(int territoryID)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesTerritory(territoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesTerritory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool UpdateSalesTerritory(SalesTerritory salesterritory)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            bool ret = false;
            try
            {
                ret = data.UpdateSalesTerritory(salesterritory);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTerritory");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public SalesTerritory GetSalesTerritorys(int territoryID)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            SalesTerritory st = new SalesTerritory();
            try
            {
                st = data.GetSalesTerritory(territoryID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritorys");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return st;
        }
        public DataSet GetAllSalesTerritoryDataSet()
        {
            SalesTerritoryData data = new SalesTerritoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesTerritorysDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesTerritoryCollection GetAllSalesTerritoryCollection()
        {
            SalesTerritoryData data = new SalesTerritoryData();
            SalesTerritoryCollection col = new SalesTerritoryCollection();
            try
            {
                col = data.GetAllSalesTerritorysCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTerritoryCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesTerritoryDataSet(string where, string orderBy)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesTerritorysDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesTerritoryCollection GetSalesTerritoryCollection(string where, string orderBy)
        {
            SalesTerritoryData data = new SalesTerritoryData();
            SalesTerritoryCollection col = new SalesTerritoryCollection();
            try
            {
                col = data.GetAllSalesTerritorysDynamicCollection(where, orderBy);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTerritoryCollection");
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
