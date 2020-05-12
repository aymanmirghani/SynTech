using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;
namespace MICS.DAL
{
    class CustomerData
    {
        
        LogWriter log = new LogWriter();
        public CustomerData()
        {
            
        }
        public bool UpdateCustomer(Customer customer)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(16);
                dbm.AddParameters(0, "@TerritoryID", customer.TerritoryID);
                dbm.AddParameters(1, "@AddressID", customer.AddressID);
                dbm.AddParameters(2, "@AccountNumber", customer.AccountNumber);
                dbm.AddParameters(3, "@CreditLimit", customer.CreditLimit);
                dbm.AddParameters(4, "@DeliveryDay", customer.DeliveryDay);
                dbm.AddParameters(5, "@CustomerType", customer.CustomerType);
                dbm.AddParameters(6, "@Name", customer.Name);
                dbm.AddParameters(7, "@ContactName", customer.ContactName);
                dbm.AddParameters(8, "@Email", customer.Email);
                dbm.AddParameters(9, "@Phone", customer.Phone);
                dbm.AddParameters(10, "@SecondPhone", customer.SecondPhone);
                dbm.AddParameters(11, "@Fax", customer.Fax);
                dbm.AddParameters(12, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(13, "@CustomerID", customer.CustomerID);
                dbm.AddParameters(14, "@BillingAddressID", customer.BillingAddressID);
                dbm.AddParameters(15, "@ActiveFlag", customer.ActiveFlag);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateCustomer");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateCustomer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteCustomer(int customerID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@CustomerID", customerID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteCustomer");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteCustomer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteCustomer(Customer customer)
        {
            return(DeleteCustomer(customer.CustomerID));
        }
        public int AddCustomer(Customer customer)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(16);

                dbm.AddParameters(0, "@TerritoryID", customer.TerritoryID);
                dbm.AddParameters(1, "@AddressID", customer.AddressID);
                dbm.AddParameters(2, "@AccountNumber", customer.AccountNumber);
                dbm.AddParameters(3, "@CreditLimit", customer.CreditLimit);
                dbm.AddParameters(4, "@DeliveryDay", customer.DeliveryDay);
                dbm.AddParameters(5, "@CustomerType", customer.CustomerType);
                dbm.AddParameters(6, "@Name", customer.Name);
                dbm.AddParameters(7, "@ContactName", customer.ContactName);
                dbm.AddParameters(8, "@Email", customer.Email);
                dbm.AddParameters(9, "@Phone", customer.Phone);
                dbm.AddParameters(10, "@SecondPhone", customer.SecondPhone);
                dbm.AddParameters(11, "@Fax", customer.Fax);
                dbm.AddParameters(12, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(13, "@BillingAddressId", customer.BillingAddressID);
                dbm.AddParameters(14, "@CustomerID", customer.CustomerID);
                dbm.AddParameters(15, "@ActiveFlag", customer.ActiveFlag);
                dbm.Parameters[14].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertCustomer");
                customer.CustomerID= Int32.Parse(dbm.Parameters[14].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddCustomer");
                return -1;
            }
            finally
            {
                dbm.Dispose();
            }
            return customer.CustomerID;
        }
        public DataSet GetAllCustomersDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectCustomersAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomersDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public CustomerCollection GetAllCustomersCollection()
        {
            IDBManager dbm = new DBManager();
            CustomerCollection cols = new CustomerCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectCustomersAll");
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    customer.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    customer.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    customer.AccountNumber = reader["AccountNumber"].ToString();
                    customer.CreditLimit = Decimal.Parse(reader["CreditLimit"].ToString());
                    customer.DeliveryDay = Int16.Parse(reader["DeliveryDay"].ToString());
                    customer.CustomerType = reader["CustomerType"].ToString();
                    customer.Name = reader["Name"].ToString();
                    customer.ContactName = reader["ContactName"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.SecondPhone = reader["SecondPhone"].ToString();
                    customer.Fax = reader["Fax"].ToString();
                    customer.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    customer.BillingAddressID = Int32.Parse(reader["BillingAddressID"].ToString());
                    customer.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                    cols.Add(customer);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomersCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public int Exists(string name)
        {
            IDBManager dbm = new DBManager();
            
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@Name", name);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectCustomerExists");
                if (reader.Read())
                {
                    return Int32.Parse(reader["CustomerID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exists");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
  
        }
        public Customer GetCustomer(int customerID)
        {
            IDBManager dbm = new DBManager();
            Customer customer= new Customer();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@CustomerID", customerID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectCustomer");
                while (reader.Read())
                {
                    customer.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    customer.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    customer.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    customer.AccountNumber = reader["AccountNumber"].ToString();
                    customer.CustomerType = reader["CustomerType"].ToString();
                    customer.CreditLimit = Decimal.Parse(reader["CreditLimit"].ToString());
                    customer.DeliveryDay = Int16.Parse(reader["DeliveryDay"].ToString());
                    customer.Name = reader["Name"].ToString();
                    customer.ContactName = reader["ContactName"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.SecondPhone = reader["SecondPhone"].ToString();
                    customer.Fax = reader["Fax"].ToString();
                    customer.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    customer.BillingAddressID = Int32.Parse(reader["BillingAddressID"].ToString());
                    customer.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetCustomer");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return customer;
        }
        public DataSet GetAllCustomersDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectCustomersDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomersDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public CustomerCollection GetAllCustomersDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            CustomerCollection cols = new CustomerCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectCustomersDynamic");
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Int32.Parse(reader["CustomerID"].ToString());
                    customer.TerritoryID = Int32.Parse(reader["TerritoryID"].ToString());
                    customer.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    customer.AccountNumber = reader["AccountNumber"].ToString();
                    customer.CreditLimit = Decimal.Parse(reader["CreditLimit"].ToString());
                    customer.DeliveryDay = Int16.Parse(reader["DeliveryDay"].ToString());
                    customer.CustomerType = reader["CustomerType"].ToString();
                    customer.Name = reader["Name"].ToString();
                    customer.ContactName = reader["ContactName"].ToString();
                    customer.Email = reader["Email"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.SecondPhone = reader["SecondPhone"].ToString();
                    customer.Fax = reader["Fax"].ToString();
                    customer.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    customer.BillingAddressID = Int32.Parse(reader["BillingAddressID"].ToString());
                    customer.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                    cols.Add(customer);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllCustomersDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
    }
}
