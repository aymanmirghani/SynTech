
using System;
using System.Data;
using MICS.Utilities;
using MICS.DAL;
namespace MICS.BLL
{
	public class Customer{
        LogWriter log = new LogWriter();
		public Customer()
        {
            _AccountNumber = "";
			_CustomerType = "";
			_Name = "";
			_ContactName = "";
			_Email = "";
			_Phone = "";
			_SecondPhone = "";
			_Fax = "";
			_ActiveFlag = true;
        }
        public Customer(
                    System.Int32 customerid,
                    System.Int32 territoryid,
                    System.Int32 addressid,
                    System.String accountnumber,
                    System.Decimal creditlimit,
                    System.Int16 deliveryday,
                    System.String customertype,
                    System.String name,
                    System.String contactname,
                    System.String email,
                    System.String phone,
                    System.String secondphone,
                    System.String fax,
                    System.DateTime modifieddate,
                    System.Int32 billingaddressid,
                    System.Boolean activeflag
            )
        {
            this._CustomerID = customerid;
            this._TerritoryID = territoryid;
            this._AddressID = addressid;
            this._AccountNumber = accountnumber;
            this._CreditLimit = creditlimit;
            this._DeliveryDay = deliveryday;
            this._CustomerType = customertype;
            this._Name = name;
            this._ContactName = contactname;
            this._Email = email;
            this._Phone = phone;
            this._SecondPhone = secondphone;
            this._Fax = fax;
            this._ModifiedDate = modifieddate;
            this._BillingAddressID = billingaddressid;
            this._ActiveFlag = activeflag;
        }
			private System.Int32 _CustomerID;
			private System.Int32 _TerritoryID;
			private System.Int32 _AddressID;
			private System.String _AccountNumber;
			private System.Decimal _CreditLimit;
			private System.Int16 _DeliveryDay;
			private System.String _CustomerType;
			private System.String _Name;
			private System.String _ContactName;
			private System.String _Email;
			private System.String _Phone;
			private System.String _SecondPhone;
			private System.String _Fax;
			private System.DateTime _ModifiedDate;
            private System.Int32 _BillingAddressID;
            private System.Boolean _ActiveFlag;
		public System.Int32 CustomerID{
			get{return _CustomerID;}
			set{ _CustomerID=value;}
		}
		public System.Int32 TerritoryID{
			get{return _TerritoryID;}
			set{ _TerritoryID=value;}
		}
		public System.Int32 AddressID{
			get{return _AddressID;}
			set{ _AddressID=value;}
		}
		public System.String AccountNumber{
			get{return _AccountNumber;}
			set{ _AccountNumber=value;}
		}
		public System.Decimal CreditLimit{
			get{return _CreditLimit;}
			set{ _CreditLimit=value;}
		}
		public System.Int16 DeliveryDay{
			get{return _DeliveryDay;}
			set{ _DeliveryDay=value;}
		}
		public System.String CustomerType{
			get{return _CustomerType;}
			set{ _CustomerType=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public System.String ContactName{
			get{return _ContactName;}
			set{ _ContactName=value;}
		}
		public System.String Email{
			get{return _Email;}
			set{ _Email=value;}
		}
		public System.String Phone{
			get{return _Phone;}
			set{ _Phone=value;}
		}
		public System.String SecondPhone{
			get{return _SecondPhone;}
			set{ _SecondPhone=value;}
		}
		public System.String Fax{
			get{return _Fax;}
			set{ _Fax=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        public System.Int32 BillingAddressID
        {
            get { return _BillingAddressID; }
            set { _BillingAddressID = value; }
        }
        public System.Boolean ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }
		public int AddCustomer(Customer customer)
        {
            CustomerData data = new CustomerData();
            int customerid = 0;
            try
            {
                customerid = data.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddCustomer");
                throw (ex);
            }
            finally
            {
                data = null;
                
            }
            return customerid;
        }
		public bool RemoveCustomer(Customer customer)
        {
            CustomerData data = new CustomerData();
            
            try
            {
               data.DeleteCustomer(customer);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveCustomer");
                throw (ex);
            }
            finally
            {
                data = null;

            }
            return true;
        }
		public bool UpdateCustomer(Customer customer)
        {
            CustomerData data = new CustomerData();
            try
            {
                 data.UpdateCustomer(customer);
            }
            catch(Exception ex)
            {
                log.Write(ex.Message, "UpdateCustomer");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return true;
        }
        public int Exists(string name)
        {
            CustomerData data = new CustomerData();
            try
            {
                return data.Exists(name);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exists");
                throw (ex);
            }
            finally
            {
                data = null;
            }
        }
        public Customer GetCustomer(int customerID)
        {
            Customer customer = new Customer();
            CustomerData data = new CustomerData();
            try
            {
                customer = data.GetCustomer(customerID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetCustomer");
                throw(ex);
            }
            finally
            {
                data = null;
            }
            return customer;
        }
		public DataSet GetAllCustomersDataSet()
        {
            CustomerData data = new CustomerData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllCustomersDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public CustomerCollection GetAllCustomerCollection()
        {
            CustomerData data = new CustomerData();
            CustomerCollection col = new CustomerCollection();
            try
            {
                col = data.GetAllCustomersCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomerCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetCustomersDataSet(string whereExpression, string orderByExpression)
        {
            CustomerData data = new CustomerData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllCustomersDynamicDataSet(whereExpression, orderByExpression);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetCustomersDataSet");
                throw(ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public CustomerCollection GetCustomersCollection(string whereExpression, string orderByExpression)
        {
            CustomerData data = new CustomerData();
            CustomerCollection col = new CustomerCollection();
            try
            {
                col = data.GetAllCustomersDynamicCollection(whereExpression, orderByExpression);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetCustomersCollection");
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
