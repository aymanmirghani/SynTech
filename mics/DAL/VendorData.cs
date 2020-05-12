using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class VendorData
    {
        LogWriter log = new LogWriter();
        public VendorData()
        {
        }
        public bool UpdateVendor(Vendor vendor)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(14);
                dbm.AddParameters(0, "@VendorID", vendor.VendorID);
                dbm.AddParameters(1, "@AccountNumber", vendor.AccountNumber);
                dbm.AddParameters(2, "@Name", vendor.Name);
                dbm.AddParameters(3, "@ContactName", vendor.ContactName);
                dbm.AddParameters(4, "@CreditRating", vendor.CreditRating);
                dbm.AddParameters(5, "@PreferredVendorStatus", vendor.PreferredVendorStatus);
                dbm.AddParameters(6, "@Phone", vendor.Phone);
                dbm.AddParameters(7, "@Fax", vendor.Fax);
                dbm.AddParameters(8, "@Email", vendor.Email);
                dbm.AddParameters(9, "@ActiveFlag", vendor.ActiveFlag);
                dbm.AddParameters(10, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(11, "@AddressID", vendor.AddressID);
                dbm.AddParameters(12, "@AltPhone", vendor.AltPhone);
                dbm.AddParameters(13, "@Terms", vendor.Terms);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateVendor");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateVendor");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteVendor(int vendorID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@VendorID", vendorID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteVendor");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteVendor");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteVendor(Vendor vendor)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@VendorID", vendor.VendorID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteVendor");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteVendor");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddVendor(Vendor vendor)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(14);
                dbm.AddParameters(0, "@AccountNumber", vendor.AccountNumber);
                dbm.AddParameters(1, "@Name", vendor.Name);
                dbm.AddParameters(2, "@ContactName", vendor.ContactName);
                dbm.AddParameters(3, "@CreditRating", vendor.CreditRating);
                dbm.AddParameters(4, "@PreferredVendorStatus", vendor.PreferredVendorStatus);
                dbm.AddParameters(5, "@Phone", vendor.Phone);
                dbm.AddParameters(6, "@Fax", vendor.Fax);
                dbm.AddParameters(7, "@Email", vendor.Email);
                dbm.AddParameters(8, "@ActiveFlag", vendor.ActiveFlag);
                dbm.AddParameters(9, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(10, "@VendorID", vendor.VendorID);
                dbm.AddParameters(11, "@AddressID", vendor.AddressID);
                dbm.AddParameters(12, "@AltPhone", vendor.AltPhone);
                dbm.AddParameters(13, "@Terms", vendor.Terms);
                dbm.Parameters[10].Direction= ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertVendor");
                vendor.VendorID = Int32.Parse(dbm.Parameters[10].Value.ToString());

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddVendor");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return vendor.VendorID;
        }
        public DataSet GetAllVendorsDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectVendorsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public VendorCollection GetAllVendorsCollection()
        {
            IDBManager dbm = new DBManager();
            VendorCollection cols = new VendorCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectVendorsAll");
                while (reader.Read())
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    vendor.ActiveFlag = Boolean.Parse(reader["ActiveFlag"].ToString());
                    vendor.ContactName = reader["ContactName"].ToString();
                    vendor.AccountNumber = reader["AccountNumber"].ToString();
                    vendor.CreditRating = Byte.Parse(reader["CreditRating"].ToString());
                    vendor.PreferredVendorStatus = Boolean.Parse(reader["PreferredVendorStatus"].ToString());
                    vendor.Name = reader["Name"].ToString();
                    vendor.Email = reader["Email"].ToString();
                    vendor.Phone = reader["Phone"].ToString();
                    vendor.Fax = reader["Fax"].ToString();
                    vendor.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    vendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    vendor.AltPhone = reader["AltPhone"].ToString();
                    vendor.Terms = reader["Terms"].ToString();
                    cols.Add(vendor);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsCollection");
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
            Vendor vendor = new Vendor();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@Name", name);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectVendorExists");
                if (reader.Read())
                {
                    return Int32.Parse(reader["VendorID"].ToString());
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
        public Vendor GetVendor(int vendorID)
        {
            IDBManager dbm = new DBManager();
            Vendor vendor= new Vendor();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@VendorID", vendorID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectVEendor");
                while (reader.Read())
                {
                    vendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    vendor.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    vendor.ActiveFlag = bool.Parse(reader["ActiveFlag"].ToString());
                    vendor.ContactName = reader["ContactName"].ToString();
                    vendor.AccountNumber = reader["AccountNumber"].ToString();
                    vendor.CreditRating = byte.Parse(reader["CreditRating"].ToString());
                    vendor.PreferredVendorStatus = bool.Parse(reader["PreferredVendorStatus"].ToString());
                    vendor.Name = reader["Name"].ToString();
                    vendor.Email = reader["Email"].ToString();
                    vendor.Phone = reader["Phone"].ToString();
                    vendor.Fax = reader["Fax"].ToString();
                    vendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    vendor.AltPhone = reader["AltPhone"].ToString();
                    vendor.Terms = reader["Terms"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetVendor");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return vendor;
        }
        public DataSet GetAllVendorsByNameDataSet(string name)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@Name", name);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectVendorByName");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public DataSet GetAllVendorsDynamicDataSet(string whereCondition, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereCondition);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);


                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectVendorsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public VendorCollection GetAllVendorsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            VendorCollection cols = new VendorCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectVendorsDynamic");
                while (reader.Read())
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    vendor.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    vendor.ActiveFlag = bool.Parse(reader["ActiveFlag"].ToString());
                    vendor.ContactName = reader["ContactName"].ToString();
                    vendor.AccountNumber = reader["AccountNumber"].ToString();
                    vendor.CreditRating = byte.Parse(reader["CreditRating"].ToString());
                    vendor.PreferredVendorStatus = bool.Parse(reader["PreferredVendorStatus"].ToString());
                    vendor.Name = reader["Name"].ToString();
                    vendor.Email = reader["Email"].ToString();
                    vendor.Phone = reader["Phone"].ToString();
                    vendor.Fax = reader["Fax"].ToString();
                    vendor.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    vendor.AltPhone = reader["AltPhone"].ToString();
                    vendor.Terms = reader["Terms"].ToString();
                    cols.Add(vendor);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllVendorsDynamicCollection");
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
