
using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class Address{
        LogWriter log = new LogWriter();
		public Address(){}
		public Address(
					System.Int32 addressid,
					System.String addressline1,
					System.String addressline2,
					System.String city,
					System.String stateprovince,
					System.String postalcode,
					System.DateTime modifieddate
		){
		this._AddressID = addressid;
		this._AddressLine1 = addressline1;
		this._AddressLine2 = addressline2;
		this._City = city;
		this._StateProvince = stateprovince;
		this._PostalCode = postalcode;
		this._ModifiedDate = modifieddate;
		}
			private System.Int32 _AddressID;
			private System.String _AddressLine1;
			private System.String _AddressLine2;
			private System.String _City;
			private System.String _StateProvince;
			private System.String _PostalCode;
			private System.DateTime _ModifiedDate;
		public System.Int32 AddressID{
			get{return _AddressID;}
			set{ _AddressID=value;}
		}
		public System.String AddressLine1{
			get{return _AddressLine1;}
			set{ _AddressLine1=value;}
		}
		public System.String AddressLine2{
			get{return _AddressLine2;}
			set{ _AddressLine2=value;}
		}
		public System.String City{
			get{return _City;}
			set{ _City=value;}
		}
		public System.String StateProvince{
			get{return _StateProvince;}
			set{ _StateProvince=value;}
		}
		public System.String PostalCode{
			get{return _PostalCode;}
			set{ _PostalCode=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddAddress(Address address)
        {
            AddressData data = new AddressData();
            try
            {
                data.AddAddress(address);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddAddress");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return address.AddressID;
        }
		public bool RemoveAddress(Address address)
        {
            AddressData data = new AddressData();
            try
            {
                data.DeleteAddress(address);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveAddress");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return true;
        }
        public bool RemoveAddress(int addressID)
        {
            AddressData data = new AddressData();
            try
            {
                data.DeleteAddress(addressID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveAddress");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return true;
        }
        public int Update(Address address)
        {
            AddressData data = new AddressData();
            try
            {
                data.Update(address);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Update Address");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return address.AddressID;
        }
		public int UpdateAddress(Address address)
        {
            AddressData data = new AddressData();
            try
            {
                data.UpdateAddress(address);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateAddress");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return address.AddressID;
        }
        public Address GetAddresss(int addressID)
        {
            Address address = new Address();
            AddressData data = new AddressData();
            try
            {
                address = data.GetAddress(addressID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddresssCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return address;
        }
        public DataSet GetAllAddresssDataSet() 
        {
            DataSet ds = new DataSet();
            AddressData data = new AddressData();
            try
            {
                ds = data.GetAllAddressesDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllAddresss()");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public AddressCollection GetAllAddresssCollection() 
        {
            AddressCollection cols = new AddressCollection();
            AddressData data = new AddressData();
            try
            {
                cols = data.GetAllAddressesCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllAddresss()");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return cols;
        }
        public DataSet GetAddressDataSet(string whereExpression, string orderByExpression)
        {
            AddressData data = new AddressData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAddressesDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressDataSet");
                throw(ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public AddressCollection GetAddressCollection(string whereExpression, string orderByExpression)
        {

            AddressData data = new AddressData();
            AddressCollection col = new AddressCollection();
            try
            {
                col = data.GetAddressesDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressCollection");
                throw(ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
	}
}
