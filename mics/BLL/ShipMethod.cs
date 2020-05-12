using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
    public class ShipMethod
    {
        private LogWriter log = new LogWriter();

        public ShipMethod() { }
        public ShipMethod(
                    System.Int32 shipmethodid,
                    System.String name,
                    System.Decimal shipbase,
                    System.Decimal shiprate,
                    System.DateTime modifieddate)
        {
            this._ShipMethodID = shipmethodid;
            this._Name = name;
            this._ShipBase = shipbase;
            this._ShipRate = shiprate;
            this._ModifiedDate = modifieddate;
        }
        private System.Int32 _ShipMethodID;
        private System.String _Name;
        private System.Decimal _ShipBase;
        private System.Decimal _ShipRate;
        private System.DateTime _ModifiedDate;
        public System.Int32 ShipMethodID
        {
            get { return _ShipMethodID; }
            set { _ShipMethodID = value; }
        }
        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public System.Decimal ShipBase
        {
            get { return _ShipBase; }
            set { _ShipBase = value; }
        }
        public System.Decimal ShipRate
        {
            get { return _ShipRate; }
            set { _ShipRate = value; }
        }
        public System.DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        public int AddShipMethod(ShipMethod shipmethod)
        {
            ShipMethodData data = new ShipMethodData();
            int id = 0;
            try
            {
                id = data.AddShipMethod(shipmethod);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddShipMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
        public bool RemoveShipMethod(ShipMethod shipmethod)
        {
            ShipMethodData data = new ShipMethodData();
            bool ret = false;
            try
            {
                ret = data.DeleteShipMethod(shipmethod);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveShipMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveShipMethod(int shipmethodID)
        {
            ShipMethodData data = new ShipMethodData();
            bool ret = false;
            try
            {
                ret = data.DeleteShipMethod(shipmethodID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveShipMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool UpdateShipMethod(ShipMethod shipmethod)
        {
            ShipMethodData data = new ShipMethodData();
            bool ret = false;
            try
            {
                ret = data.UpdateShipMethod(shipmethod);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateShipMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public ShipMethod GetShipMethods(int shipMethodID)
        {
            ShipMethodData data = new ShipMethodData();
            ShipMethod sm = new ShipMethod();
            try
            {
                sm = data.GetShipMethod(shipMethodID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetShipMethods");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sm;
        }
        public DataSet GetAllShipMethodsDataSet()
        {
            ShipMethodData data = new ShipMethodData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllShipMethodsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ShipMethodCollection GetAllShipMethodsCollection()
        {
            ShipMethodData data = new ShipMethodData();
            ShipMethodCollection col = new ShipMethodCollection();
            try
            {
                col = data.GetAllShipMethodsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllShipMethodsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetShipMethodsDataSet(string where, string orderBy)
        {
            ShipMethodData data = new ShipMethodData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllShipMethodsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetShipMethodsDataSet");
                throw (ex);
            }
            return (ds);
        }
    }
}