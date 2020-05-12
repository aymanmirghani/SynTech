using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class PurchaseInvoiceDetailData
    {
        LogWriter log = new LogWriter();
        public PurchaseInvoiceDetailData()
		{
			
		}
		public bool UpdatePurchaseInvoiceDetail(PurchaseInvoiceDetail PID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(6);
                dbm.AddParameters(0, "@InvoiceID", PID.InvoiceID);
				dbm.AddParameters(1, "@InvoiceDetailID", PID.InvoiceDetailID);
                dbm.AddParameters(2, "@ProductID", PID.ProductID);
                dbm.AddParameters(3, "@UnitPrice", PID.UnitPrice);
                dbm.AddParameters(4, "@Quantity", PID.Quantity);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePurchaseInvoiceDetail");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdatePurchaseInvoiceDetail");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeletePurchaseInvoiceDetail(int pruchaseOrderDetailID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceDetailID", pruchaseOrderDetailID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePurchaseInvoiceDetail");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeletePurchaseInvoiceDetail");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
		public bool DeletePurchaseInvoiceDetail(PurchaseInvoiceDetail productInventory)
		{
			return(DeletePurchaseInvoiceDetail(productInventory.InvoiceDetailID));
		}
        public bool DeletePurchaseInvoiceDetail(PurchaseInvoiceDetailCollection col)
        {
            try
            {

                foreach (PurchaseInvoiceDetail PID in col)
                {
                    DeletePurchaseInvoiceDetail(PID.InvoiceDetailID);
                }
               
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeletePurchaseInvoiceDetail");
                throw (ex);
            }
           
            return true;
        }
        public int AddPurchaseInvoiceDetail(PurchaseInvoiceDetail PID)
		{
			IDBManager dbm = new DBManager();
			try
			{
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@InvoiceID", PID.InvoiceID);
                
                dbm.AddParameters(1, "@ProductID", PID.ProductID);
                dbm.AddParameters(2, "@UnitPrice", PID.UnitPrice);
                dbm.AddParameters(3, "@Quantity", PID.Quantity);
                dbm.AddParameters(4, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(5, "@InvoiceDetailID", PID.InvoiceDetailID);
                dbm.Parameters[5].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPurchaseInvoiceDetail");
                PID.InvoiceDetailID = Int32.Parse(dbm.Parameters[5].Value.ToString());

			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddPurchaseInvoiceDetail");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PID.InvoiceDetailID;
		}
        public void AddUpdatePurchaseInvoiceDetail(PurchaseInvoiceDetail PID)
        {
            IDBManager dbm = new DBManager();
            try
            {
               
                dbm.CreateParameters(6);
                dbm.AddParameters(0, "@InvoiceID", PID.InvoiceID);
                dbm.AddParameters(1, "@InvoiceDetailID", PID.InvoiceDetailID);
                dbm.AddParameters(2, "@ProductID", PID.ProductID);
                dbm.AddParameters(3, "@UnitPrice", PID.UnitPrice);
                dbm.AddParameters(4, "@Quantity", PID.Quantity);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertUpdatePurchaseInvoiceDetail");
               
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddUpdatePurchaseInvoiceDetail");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
           
        }
		public DataSet GetAllPurchaseInvoiceDetailDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailsAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllPurchaseInvoiceDetailDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public DataSet GetAllPurchaseInvoiceDetailDataSet(int InvoiceID)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", InvoiceID);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailByOrderID");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public PurchaseInvoiceDetailCollection GetAllPurchaseInvoiceDetailCollection(int InvoiceID)
        {
            IDBManager dbm = new DBManager();
            PurchaseInvoiceDetailCollection cols = new PurchaseInvoiceDetailCollection();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", InvoiceID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailByOrderID");
                while (reader.Read())
                {
                    PurchaseInvoiceDetail PID = new PurchaseInvoiceDetail();
                    PID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PID.InvoiceDetailID = Int32.Parse(reader["InvoiceDetailID"].ToString());
                    PID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PID.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    PID.Quantity = Int64.Parse(reader["Quantity"].ToString());
                    PID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PID);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "PurchaseInvoiceDetailCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
		public PurchaseInvoiceDetailCollection GetAllPurchaseInvoiceDetailCollection()
		{
			IDBManager dbm = new DBManager();
			PurchaseInvoiceDetailCollection cols = new PurchaseInvoiceDetailCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailsAll");
				while (reader.Read())
				{
                    PurchaseInvoiceDetail PID = new PurchaseInvoiceDetail();
                    PID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PID.InvoiceDetailID = Int32.Parse(reader["InvoiceDetailID"].ToString());
                    PID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PID.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    PID.Quantity = Int64.Parse(reader["Quantity"].ToString());
                    PID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PID);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "PurchaseInvoiceDetailCollection");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public PurchaseInvoiceDetail GetPurchaseInvoiceDetail(int PIDID)
		{
			IDBManager dbm = new DBManager();
            PurchaseInvoiceDetail PID = new PurchaseInvoiceDetail();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceDetailID", PIDID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetail");
				while (reader.Read())
				{
                    PID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PID.InvoiceDetailID = Int32.Parse(reader["InvoiceDetailID"].ToString());
                    PID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PID.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    PID.Quantity = Int64.Parse(reader["Quantity"].ToString());
                    PID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetPurchaseInvoiceDetail");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PID;
		}
		public DataSet GetPurchaseInvoiceDetailDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailsDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetPurchaseInvoiceDetailDynamicDataSet()");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public DataSet GetPurchaseInvoiceDetailGridDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailsGrid");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPurchaseInvoiceDetailGridDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
		public PurchaseInvoiceDetailCollection GetAllPurchaseInvoiceDetailDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			PurchaseInvoiceDetailCollection cols = new PurchaseInvoiceDetailCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceDetailsDynamic");
				while (reader.Read())
				{
                    PurchaseInvoiceDetail PID = new PurchaseInvoiceDetail();

                    PID.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PID.InvoiceDetailID = Int32.Parse(reader["InvoiceDetailID"].ToString());
                    PID.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    PID.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    PID.Quantity = Int64.Parse(reader["Quantity"].ToString());
                    PID.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PID);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseInvoiceDetailDynamicCollection");
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
