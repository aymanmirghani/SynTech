using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
    public class SalesTaxRate
    {
        private LogWriter log = new LogWriter();
        private System.Int32 _SalesTaxRateID;
        private System.String _StateProvinceID;
        private System.Byte _TaxType;
        private System.Decimal _TaxRate;
        private System.String _Name;
        private System.DateTime _ModifiedDate;

        public SalesTaxRate() { }
        public SalesTaxRate(
                    System.Int32 salestaxrateid,
                    System.String stateprovinceid,
                    System.Byte taxtype,
                    System.Decimal taxrate,
                    System.String name,
                    System.DateTime modifieddate)
        {
            this._SalesTaxRateID = salestaxrateid;
            this._StateProvinceID = stateprovinceid;
            this._TaxType = taxtype;
            this._TaxRate = taxrate;
            this._Name = name;
            this._ModifiedDate = modifieddate;
        }

        public System.Int32 SalesTaxRateID
        {
            get { return _SalesTaxRateID; }
            set { _SalesTaxRateID = value; }
        }
        public System.String StateProvinceID
        {
            get { return _StateProvinceID; }
            set { _StateProvinceID = value; }
        }
        public System.Byte TaxType
        {
            get { return _TaxType; }
            set { _TaxType = value; }
        }
        public System.Decimal TaxRate
        {
            get { return _TaxRate; }
            set { _TaxRate = value; }
        }
        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public System.DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        public int AddSalesTaxRate(SalesTaxRate salestaxrate)
        {
            SalesTaxRateData data = new SalesTaxRateData();
            int ret = 0;
            try
            {
                ret = data.AddSalesTaxRate(salestaxrate);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesTaxRate");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesTaxRate(SalesTaxRate salestaxrate)
        {
            SalesTaxRateData data = new SalesTaxRateData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesTaxRate(salestaxrate);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesTaxRate");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool UpdateSalesTaxRate(SalesTaxRate salestaxrate)
        {
            SalesTaxRateData data = new SalesTaxRateData();
            bool ret = false;
            try
            {
                ret = data.UpdateSalesTaxRate(salestaxrate);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesTaxRate");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public SalesTaxRate GetSalesTaxRates(int salesTaxRatesID)
        {
            SalesTaxRateData data = new SalesTaxRateData();
            SalesTaxRate str = new SalesTaxRate();
            try
            {
                str = data.GetSalesTaxRate(salesTaxRatesID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTaxRates");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return str;
        }
        public DataSet GetAllSalesTaxRatesDataSet()
        {
            SalesTaxRateData data = new SalesTaxRateData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesTaxRatesDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesTaxRateCollection GetAllSalesTaxRatesCollection()
        {
            SalesTaxRateData data = new SalesTaxRateData();
            SalesTaxRateCollection col = new SalesTaxRateCollection();
            try
            {
                col = data.GetAllSalesTaxRatesCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesTaxRatesCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesTaxRatesDataSet(string where, string orderBy)
        {
            SalesTaxRateData data = new SalesTaxRateData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesTaxRatesDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesTaxRatesDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return(ds);
        }
    }
}