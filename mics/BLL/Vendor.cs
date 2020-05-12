using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class Vendor{
        private LogWriter log = new LogWriter();
        
        private System.Int32 _VendorID;
        private System.Int32 _AddressID;
        private System.String _AccountNumber;
        private System.String _Name;
        private System.String _ContactName;
        private System.Byte _CreditRating;
        private System.Boolean _PreferredVendorStatus;
        private System.String _Phone;
        private System.String _Fax;
        private System.String _Email;
        private System.Boolean _ActiveFlag;
        private System.DateTime _ModifiedDate;
        private System.String _AltPhone;
        private System.String _Terms;
        public Vendor(){}
        public Vendor(
                    System.Int32 vendorid,
                    System.Int32 addressID,
                    System.String accountnumber,
                    System.String name,
                    System.String contactname,
                    System.Byte creditrating,
                    System.Boolean preferredvendorstatus,
                    System.String phone,
                    System.String fax,
                    System.String email,
                    System.Boolean activeflag,
                    System.DateTime modifieddate,
                    System.String altphone,
                    System.String terms)
        {
            this._VendorID = vendorid;
            this._AddressID = addressID;
            this._AccountNumber = accountnumber;
            this._Name = name;
            this._ContactName = contactname;
            this._CreditRating = creditrating;
            this._PreferredVendorStatus = preferredvendorstatus;
            this._Phone = phone;
            this._Fax = fax;
            this._Email = email;
            this._ActiveFlag = activeflag;
            this._ModifiedDate = modifieddate;
            this._AltPhone = altphone;
            this._Terms = terms;
        }
		
		public System.Int32 VendorID{
			get{return _VendorID;}
			set{ _VendorID=value;}
		}
        public System.Int32 AddressID
        {
            get { return _AddressID; }
            set { _AddressID = value; }
        }
		public System.String AccountNumber{
			get{return _AccountNumber;}
			set{ _AccountNumber=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public System.String ContactName{
			get{return _ContactName;}
			set{ _ContactName=value;}
		}
		public System.Byte CreditRating{
			get{return _CreditRating;}
			set{ _CreditRating=value;}
		}
		public System.Boolean PreferredVendorStatus{
			get{return _PreferredVendorStatus;}
			set{ _PreferredVendorStatus=value;}
		}
		public System.String Phone{
			get{return _Phone;}
			set{ _Phone=value;}
		}
		public System.String Fax{
			get{return _Fax;}
			set{ _Fax=value;}
		}
		public System.String Email{
			get{return _Email;}
			set{ _Email=value;}
		}
		public System.Boolean ActiveFlag{
			get{return _ActiveFlag;}
			set{ _ActiveFlag=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        public System.String AltPhone
        {
            get { return _AltPhone; }
            set { _AltPhone = value; }
        }
        public System.String Terms
        {
            get { return _Terms; }
            set { _Terms = value; }
        }
		public int AddVendor(Vendor vendor)
        {
            VendorData data = new VendorData();
            int id=0;
            try
            {
                id = data.AddVendor(vendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveVendor(Vendor vendor)
        {
            VendorData data = new VendorData();
            bool ret = false;
            try
            {
                ret = data.DeleteVendor(vendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveVendor(int vendorID)
        {
            VendorData data = new VendorData();
            bool ret = false;
            try
            {
                ret = data.DeleteVendor(vendorID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateVendor(Vendor vendor)
        {
            VendorData data = new VendorData();
            bool ret = false;
            try
            {
                ret = data.UpdateVendor(vendor);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateVendor");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public int Exists(string name)
        {
            VendorData data = new VendorData();
            try
            {
                return data.Exists(name);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message,"Exists");
                throw(ex);
            }
            finally
            {
                data = null;
            }
        }
		public Vendor GetVendor(int venderID)
        {
            VendorData data = new VendorData();
            Vendor v = new Vendor();
            try
            {
                v = data.GetVendor(venderID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetVendors");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return v;
        }
        public DataSet GetAllVendorsDataSet()
        {
            VendorData data = new VendorData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllVendorsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public VendorCollection GetAllVendorsCollection()
        {
            VendorData data = new VendorData();
            VendorCollection col = new VendorCollection();
            try
            {
                col = data.GetAllVendorsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetVendorsDataSet(string where, string orderBy)
        {
            VendorData data = new VendorData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllVendorsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetVendorsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public VendorCollection GetVendorsCollection(string where, string orderBy)
        {
            VendorData data = new VendorData();
            VendorCollection col = new VendorCollection();
            try
            {
                col = data.GetAllVendorsDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetVendorsCollection");
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
