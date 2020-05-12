using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class PurchaseOrderHeaderData
    {
        LogWriter log = new LogWriter();
        public PurchaseOrderHeaderData()
		{
			
		}
        public bool UpdatePurchaseOrderHeader(PurchaseOrderHeader purchaseOrderHeader)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(13);
                dbm.AddParameters(0, "@PurchaseOrderID", purchaseOrderHeader.PurchaseOrderID);
                dbm.AddParameters(1, "@RevisionNumber", purchaseOrderHeader.RevisionNumber);
                dbm.AddParameters(2, "@Status", purchaseOrderHeader.Status);
                dbm.AddParameters(3, "@EmployeeID", purchaseOrderHeader.EmployeeID);
                dbm.AddParameters(4, "@VendorID", purchaseOrderHeader.VendorID);
                dbm.AddParameters(5, "@ShipMethodID", purchaseOrderHeader.ShipMethodID);
                dbm.AddParameters(6, "@OrderDate", purchaseOrderHeader.OrderDate);
                dbm.AddParameters(7, "@ShipDate", purchaseOrderHeader.ShipDate);
                dbm.AddParameters(8, "@SubTotal", purchaseOrderHeader.SubTotal);
                dbm.AddParameters(9, "@TaxAmt", purchaseOrderHeader.TaxAmt);
                dbm.AddParameters(10, "@Freight", purchaseOrderHeader.Freight);
                dbm.AddParameters(11, "@TotalDue", purchaseOrderHeader.TotalDue);
                dbm.AddParameters(12, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePurchaseOrderHeader");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdatePurchaseOrderHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeletePurchaseOrderHeader(int purchaseOrderID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderID", purchaseOrderID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePurchaseOrderHeader");
                //find the purchaseorderdetailid to delete all the line associated with orderid
                PurchaseOrderDetailData pod = new PurchaseOrderDetailData();
                PurchaseOrderDetailCollection col = new PurchaseOrderDetailCollection();
                col = pod.GetAllPurchaseOrderDetailCollection(purchaseOrderID);
                if (!pod.DeletePurchaseOrderDetail(col))
                    return false;
                
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeletePurchaseOrderHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
        public bool DeletePurchaseOrderHeader(PurchaseOrderHeader purchaseOrderHeader)
		{
            return (DeletePurchaseOrderHeader(purchaseOrderHeader.PurchaseOrderID));
		}
        public int AddPurchaseOrderHeader(PurchaseOrderHeader purchaseOrderHeader)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(13);
                dbm.AddParameters(0, "@RevisionNumber", purchaseOrderHeader.RevisionNumber);
                dbm.AddParameters(1, "@Status", purchaseOrderHeader.Status);
                dbm.AddParameters(2, "@EmployeeID", purchaseOrderHeader.EmployeeID);
                dbm.AddParameters(3, "@VendorID", purchaseOrderHeader.VendorID);
                dbm.AddParameters(4, "@ShipMethodID", purchaseOrderHeader.ShipMethodID);
                dbm.AddParameters(5, "@OrderDate", purchaseOrderHeader.OrderDate);
                dbm.AddParameters(6, "@ShipDate", purchaseOrderHeader.ShipDate);
                dbm.AddParameters(7, "@SubTotal", purchaseOrderHeader.SubTotal);
                dbm.AddParameters(8, "@TaxAmt", purchaseOrderHeader.TaxAmt);
                dbm.AddParameters(9, "@Freight", purchaseOrderHeader.Freight);
                dbm.AddParameters(10, "@TotalDue", purchaseOrderHeader.TotalDue);
                dbm.AddParameters(11, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(12, "@PurchaseOrderID", purchaseOrderHeader.PurchaseOrderID);

                dbm.Parameters[12].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPurchaseOrderHeader");
                purchaseOrderHeader.PurchaseOrderID = Int32.Parse(dbm.Parameters[12].Value.ToString());

			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddPurchaseOrderHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return purchaseOrderHeader.PurchaseOrderID;
		}
		public DataSet GetAllPurchaseOrderHeaderDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderHeadersAll");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseOrderHeaderDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PurchaseOrderHeaderCollection GetAllPurchaseOrderHeaderCollection()
		{
			IDBManager dbm = new DBManager();
			PurchaseOrderHeaderCollection cols = new PurchaseOrderHeaderCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderHeadersAll");
				while (reader.Read())
				{
                    PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();
                    purchaseOrderHeader.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderHeader.RevisionNumber = reader["RevisionNumber"].ToString();
                    purchaseOrderHeader.Status = Byte.Parse(reader["Status"].ToString());
                    purchaseOrderHeader.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    purchaseOrderHeader.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    purchaseOrderHeader.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    purchaseOrderHeader.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    purchaseOrderHeader.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    purchaseOrderHeader.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    purchaseOrderHeader.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    purchaseOrderHeader.Freight = Decimal.Parse(reader["Freight"].ToString());
                    purchaseOrderHeader.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    purchaseOrderHeader.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(purchaseOrderHeader);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "PurchaseOrderHeaderCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public PurchaseOrderHeader GetPurchaseOrderHeader(int purchaseOrderID)
		{
			IDBManager dbm = new DBManager();
            PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderID", purchaseOrderID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderHeader");
				while (reader.Read())
				{
                    purchaseOrderHeader.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderHeader.RevisionNumber = reader["RevisionNumber"].ToString();
                    purchaseOrderHeader.Status = Byte.Parse(reader["Status"].ToString());
                    purchaseOrderHeader.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    purchaseOrderHeader.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    purchaseOrderHeader.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    purchaseOrderHeader.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    purchaseOrderHeader.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    purchaseOrderHeader.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    purchaseOrderHeader.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    purchaseOrderHeader.Freight = Decimal.Parse(reader["Freight"].ToString());
                    purchaseOrderHeader.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    purchaseOrderHeader.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetPurchaseOrderHeader");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return purchaseOrderHeader;
		}
		public DataSet GetPurchaseOrderHeaderDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderHeadersDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetPurchaseOrderHeaderDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PurchaseOrderHeaderCollection GetAllPurchaseOrderHeaderDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			PurchaseOrderHeaderCollection cols = new PurchaseOrderHeaderCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderHeadersDynamic");
				while (reader.Read())
				{
                    PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();

                    purchaseOrderHeader.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderHeader.RevisionNumber = reader["RevisionNumber"].ToString();
                    purchaseOrderHeader.Status = Byte.Parse(reader["Status"].ToString());
                    purchaseOrderHeader.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    purchaseOrderHeader.VendorID = Int32.Parse(reader["VendorID"].ToString());
                    purchaseOrderHeader.ShipMethodID = Int32.Parse(reader["ShipMethodID"].ToString());
                    purchaseOrderHeader.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                    purchaseOrderHeader.ShipDate = DateTime.Parse(reader["ShipDate"].ToString());
                    purchaseOrderHeader.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                    purchaseOrderHeader.TaxAmt = Decimal.Parse(reader["TaxAmt"].ToString());
                    purchaseOrderHeader.Freight = Decimal.Parse(reader["Freight"].ToString());
                    purchaseOrderHeader.TotalDue = Decimal.Parse(reader["TotalDue"].ToString());
                    purchaseOrderHeader.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(purchaseOrderHeader);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseOrderHeaderDynamicCollection");
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
