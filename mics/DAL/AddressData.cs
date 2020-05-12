using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using MICS.BLL;
using MICS.Utilities;
namespace MICS.DAL
{
    class AddressData
    {
        LogWriter log = new LogWriter();
        public AddressData()
        {
        }
        public int Update(Address address)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(7);
                dbm.AddParameters(0, "@AddressID", address.AddressID);
                dbm.AddParameters(1, "@AddressLine1", address.AddressLine1);
                if (address.AddressLine2 == null)
                    address.AddressLine2 = "";
                dbm.AddParameters(2, "@AddressLine2", address.AddressLine2);
                dbm.AddParameters(3, "@City", address.City);
                dbm.AddParameters(4, "@StateProvince", address.StateProvince);
                dbm.AddParameters(5, "@PostalCode", address.PostalCode);
                dbm.AddParameters(6, "@ModifiedDate", DateTime.Now);
                
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateAddress");
                //address.AddressID = Int32.Parse(dbm.Parameters[0].Value.ToString());


            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateAddress");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return address.AddressID;

        }
        public int UpdateAddress(Address address)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(7);
                dbm.AddParameters(0, "@AddressID", address.AddressID);
                dbm.AddParameters(1, "@AddressLine1", address.AddressLine1);
                if (address.AddressLine2 == null)
                    address.AddressLine2 = "";
                dbm.AddParameters(2, "@AddressLine2", address.AddressLine2);
                dbm.AddParameters(3, "@City", address.City);
                dbm.AddParameters(4, "@StateProvince", address.StateProvince);
                dbm.AddParameters(5, "@PostalCode", address.PostalCode);
                dbm.AddParameters(6, "@ModifiedDate", DateTime.Now);
                dbm.Parameters[0].Direction = ParameterDirection.Output;
                       
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertUpdateAddress");
                address.AddressID = Int32.Parse(dbm.Parameters[0].Value.ToString());
              

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateAddress");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return address.AddressID;
        }
        public bool DeleteAddress(int addressId)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@AddressID", addressId);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteAddress");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteAddress");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteAddress(Address address)
        {
            return(DeleteAddress(address.AddressID));
        }
        public int AddAddress(Address address)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(7);
                
                dbm.AddParameters(0, "@AddressLine1", address.AddressLine1);
                if (address.AddressLine2 == null)
                    address.AddressLine2 = "";
                dbm.AddParameters(1, "@AddressLine2", address.AddressLine2);
                dbm.AddParameters(2, "@City", address.City);
                dbm.AddParameters(3, "@StateProvince", address.StateProvince);
                dbm.AddParameters(4, "@PostalCode", address.PostalCode);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(6, "@AddressID", address.AddressID);
                dbm.Parameters[6].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAddress");
                address.AddressID = Int32.Parse(dbm.Parameters[6].Value.ToString());

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddAddress");
                return -1;
            }
            finally
            {
                dbm.Dispose();
            }
            return address.AddressID;
        }
        public DataSet GetAllAddressesDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectAddressesAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllAddressDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public DataSet GetAddressesDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectAddressesDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressesDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public AddressCollection GetAllAddressesCollection()
        {
            IDBManager dbm = new DBManager();
            AddressCollection cols = new AddressCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectAddressesAll");
                while (reader.Read())
                {
                    Address address = new Address();
                    address.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    address.AddressLine1 = reader["AddressLine1"].ToString();
                    address.AddressLine2 = reader["AddressLine2"].ToString();
                    address.City = reader["City"].ToString();
                    address.StateProvince = reader["StateProvince"].ToString();
                    address.PostalCode = reader["PostalCode"].ToString();
                    address.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(address);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllAddressesCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public AddressCollection GetAddressesDynamicCollection(string whereExpression,string orderBy)
        {
            IDBManager dbm = new DBManager();
            AddressCollection cols = new AddressCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectAddressesDynamic");
                while (reader.Read())
                {
                    Address address = new Address();
                    address.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    address.AddressLine1 = reader["AddressLine1"].ToString();
                    address.AddressLine2 = reader["AddressLine2"].ToString();
                    address.City = reader["City"].ToString();
                    address.StateProvince = reader["StateProvince"].ToString();
                    address.PostalCode = reader["PostalCode"].ToString();
                    address.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(address);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressesDynamicCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
    
        public Address GetAddress(int addressID)
        {
            IDBManager dbm = new DBManager();
            Address address = new Address();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@AddressID", addressID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectAddress");
                while (reader.Read())
                {
                   
                    address.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    address.AddressLine1 = reader["AddressLine1"].ToString();
                    address.AddressLine2 = reader["AddressLine2"].ToString();
                    address.City = reader["City"].ToString();
                    address.StateProvince = reader["StateProvince"].ToString();
                    address.PostalCode = reader["PostalCode"].ToString();
                    address.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressByID");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return address;
        }
    }
    
}
