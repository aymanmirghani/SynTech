using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class PurchaseInvoiceHeaderData
    {
        LogWriter log = new LogWriter();
        public PurchaseInvoiceHeaderData()
		{
			
		}
        public bool UpdatePurchaseInvoiceHeader(PurchaseInvoiceHeader PIH)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(12);
                dbm.AddParameters(0, "@InvoiceID", PIH.InvoiceID);
                dbm.AddParameters(1, "@InvoiceNumber", PIH.InvoiceNumber);
                dbm.AddParameters(2, "@Status", PIH.Status);
                dbm.AddParameters(3, "@EmployeeID", PIH.EmployeeID);
                dbm.AddParameters(4, "@VendorID", PIH.VendorID);
                dbm.AddParameters(5, "@InvoiceDate", PIH.InvoiceDate);
                dbm.AddParameters(6, "@SubTotal", PIH.SubTotal);
                dbm.AddParameters(7, "@TaxAmt", PIH.TaxAmt);
                dbm.AddParameters(8, "@Freight", PIH.Freight);
                dbm.AddParameters(9, "@TotalDue", PIH.TotalDue);
                dbm.AddParameters(10, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(11, "@PurchaseOrderID", PIH.PurchaseOrderID);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePurchaseInvoiceHeader");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdatePurchaseInvoiceHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeletePurchaseInvoiceHeader(int purchaseOrderID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", purchaseOrderID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePurchaseInvoiceHeader");
                //find the purchaseorderdetailid to delete all the line associated with orderid
                PurchaseOrderDetailData pod = new PurchaseOrderDetailData();
                PurchaseOrderDetailCollection col = new PurchaseOrderDetailCollection();
                col = pod.GetAllPurchaseOrderDetailCollection(purchaseOrderID);
                if (!pod.DeletePurchaseOrderDetail(col))
                    return false;
                
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeletePurchaseInvoiceHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
        public bool DeletePurchaseInvoiceHeader(PurchaseInvoiceHeader PIH)
		{
            return (DeletePurchaseInvoiceHeader(PIH.InvoiceID));
		}
        public int AddPurchaseInvoiceHeader(PurchaseInvoiceHeader PIH)
		{
			IDBManager dbm = new DBManager();
			try
			{
                dbm.CreateParameters(12);
                
                dbm.AddParameters(0, "@InvoiceNumber", PIH.InvoiceNumber);
                dbm.AddParameters(1, "@Status", PIH.Status);
                dbm.AddParameters(2, "@EmployeeID", PIH.EmployeeID);
                dbm.AddParameters(3, "@VendorID", PIH.VendorID);
                dbm.AddParameters(4, "@InvoiceDate", PIH.InvoiceDate);
                dbm.AddParameters(5, "@SubTotal", PIH.SubTotal);
                dbm.AddParameters(6, "@TaxAmt", PIH.TaxAmt);
                dbm.AddParameters(7, "@Freight", PIH.Freight);
                dbm.AddParameters(8, "@TotalDue", PIH.TotalDue);
                dbm.AddParameters(9, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(10, "@InvoiceID", PIH.InvoiceID);
                dbm.AddParameters(11, "@PurchaseOrderID", PIH.PurchaseOrderID);
                dbm.Parameters[10].Direction = ParameterDirection.Output;
                
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPurchaseInvoiceHeader");
                PIH.InvoiceID = Int32.Parse(dbm.Parameters[10].Value.ToString());
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddPurchaseInvoiceHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PIH.InvoiceID;
		}
		public DataSet GetAllPurchaseInvoiceHeaderDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceHeadersAll");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseInvoiceHeaderDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PurchaseInvoiceHeaderCollection GetAllPurchaseInvoiceHeaderCollection()
		{
			IDBManager dbm = new DBManager();
			PurchaseInvoiceHeaderCollection cols = new PurchaseInvoiceHeaderCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceHeadersAll");
				while (reader.Read())
				{
                    PurchaseInvoiceHeader PIH = new PurchaseInvoiceHeader();
                    PIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    PIH.Status = Byte.Parse(reader["status"].ToString());
                    PIH.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    PIH.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    PIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    PIH.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    PIH.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    PIH.Freight = Decimal.Parse(reader["Freight"].ToString());
                    PIH.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    PIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    PIH.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    cols.Add(PIH);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "PurchaseInvoiceHeaderCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public PurchaseInvoiceHeader GetPurchaseInvoiceHeader(int purchaseOrderID)
		{
			IDBManager dbm = new DBManager();
            PurchaseInvoiceHeader PIH = new PurchaseInvoiceHeader();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@InvoiceID", purchaseOrderID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceHeader");
				while (reader.Read())
				{
                    PIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    PIH.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    PIH.Status = Byte.Parse(reader["status"].ToString());
                    PIH.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    PIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    PIH.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    PIH.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    PIH.Freight = Decimal.Parse(reader["Freight"].ToString());
                    PIH.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    PIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    PIH.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetPurchaseInvoiceHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PIH;
		}
		public DataSet GetPurchaseInvoiceHeaderDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseInvoiceHeadersDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetPurchaseInvoiceHeaderDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PurchaseInvoiceHeaderCollection GetAllPurchaseInvoiceHeaderDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			PurchaseInvoiceHeaderCollection cols = new PurchaseInvoiceHeaderCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseInvoiceHeadersDynamic");
				while (reader.Read())
				{
                    PurchaseInvoiceHeader PIH = new PurchaseInvoiceHeader();

                    PIH.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PIH.InvoiceNumber = reader["InvoiceNumber"].ToString();
                    PIH.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    PIH.Status = Byte.Parse(reader["status"].ToString());
                    PIH.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    PIH.InvoiceDate = DateTime.Parse(reader["InvoiceDate"].ToString());
                    PIH.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    PIH.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    PIH.Freight = Decimal.Parse(reader["Freight"].ToString());
                    PIH.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    PIH.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    PIH.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    cols.Add(PIH);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseInvoiceHeaderDynamicCollection");
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
