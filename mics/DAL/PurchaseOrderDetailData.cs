using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class PurchaseOrderDetailData
    {
        LogWriter log = new LogWriter();
        public PurchaseOrderDetailData()
		{
			
		}
		public bool UpdatePurchaseOrderDetail(PurchaseOrderDetail pod)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(12);
                dbm.AddParameters(0, "@PurchaseOrderID", pod.PurchaseOrderID);
				dbm.AddParameters(1, "@PurchaseOrderDetailID", pod.PurchaseOrderDetailID);
                dbm.AddParameters(2, "@DueDate", pod.DueDate);
                dbm.AddParameters(3, "@OrderQty", pod.OrderQty);
                dbm.AddParameters(4, "@ProductID", pod.ProductID);
                dbm.AddParameters(5, "@UnitPrice", pod.UnitPrice);
                dbm.AddParameters(6, "@NumberOfCases", pod.NumberOfCases);
                dbm.AddParameters(7, "@UnitPerCase", pod.UnitPerCase);
                dbm.AddParameters(8, "@ReceivedQty", pod.ReceivedQty);
                dbm.AddParameters(9, "@RejectedQty", pod.RejectedQty);
                dbm.AddParameters(10, "@StockedQty", pod.StockedQty);
                dbm.AddParameters(11, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePurchaseOrderDetail");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdatePurchaseOrderDetail");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeletePurchaseOrderDetail(int pruchaseOrderDetailID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderDetailID", pruchaseOrderDetailID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePurchaseOrderDetail");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeletePurchaseOrderDetail");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
		public bool DeletePurchaseOrderDetail(PurchaseOrderDetail productInventory)
		{
			return(DeletePurchaseOrderDetail(productInventory.PurchaseOrderDetailID));
		}
        public bool DeletePurchaseOrderDetail(PurchaseOrderDetailCollection col)
        {
            try
            {

                foreach (PurchaseOrderDetail pod in col)
                {
                    DeletePurchaseOrderDetail(pod.PurchaseOrderDetailID);
                }
               
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeletePurchaseOrderDetail");
                throw (ex);
            }
           
            return true;
        }
        public int AddPurchaseOrderDetail(PurchaseOrderDetail pod)
		{
			IDBManager dbm = new DBManager();
			try
			{
                dbm.CreateParameters(12);
                dbm.AddParameters(0, "@PurchaseOrderID", pod.PurchaseOrderID);
                dbm.AddParameters(1, "@PurchaseOrderDetailID", pod.PurchaseOrderDetailID);
                dbm.AddParameters(2, "@DueDate", pod.DueDate);
                dbm.AddParameters(3, "@OrderQty", pod.OrderQty);
                dbm.AddParameters(4, "@ProductID", pod.ProductID);
                dbm.AddParameters(5, "@UnitPrice", pod.UnitPrice);
                dbm.AddParameters(6, "@NumberOfCases", pod.NumberOfCases);
                dbm.AddParameters(7, "@UnitPerCase", pod.UnitPerCase);
                dbm.AddParameters(8, "@ReceivedQty", pod.ReceivedQty);
                dbm.AddParameters(9, "@RejectedQty", pod.RejectedQty);
                dbm.AddParameters(10, "@StockedQty", pod.StockedQty);
                dbm.AddParameters(11, "@ModifiedDate", DateTime.Now);
                dbm.Parameters[1].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPurchaseOrderDetail");
                pod.PurchaseOrderDetailID = Int32.Parse(dbm.Parameters[1].Value.ToString());


			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddPurchaseOrderDetail");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return pod.PurchaseOrderDetailID;
		}
		public DataSet GetAllPurchaseOrderDetailDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderDetailsAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllPurchaseOrderDetailDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public DataSet GetAllPurchaseOrderDetailDataSet(int purchaseOrderID)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderID", purchaseOrderID);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderDetailByOrderID");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPurchaseOrderDetailDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public PurchaseOrderDetailCollection GetAllPurchaseOrderDetailCollection(int purchaseOrderID)
        {
            IDBManager dbm = new DBManager();
            PurchaseOrderDetailCollection cols = new PurchaseOrderDetailCollection();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderID", purchaseOrderID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderDetailByOrderID");
                while (reader.Read())
                {
                    PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                    purchaseOrderDetail.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderDetail.PurchaseOrderDetailID = Int32.Parse(reader["PurchaseOrderDetailID"].ToString());
                    purchaseOrderDetail.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    purchaseOrderDetail.OrderQty = Int16.Parse(reader["OrderQty"].ToString());
                    purchaseOrderDetail.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    purchaseOrderDetail.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    purchaseOrderDetail.NumberOfCases = Double.Parse(reader["NumberOfCases"].ToString());
                    purchaseOrderDetail.UnitPerCase = Int32.Parse(reader["UnitPerCase"].ToString());
                    purchaseOrderDetail.ReceivedQty = Int64.Parse(reader["ReceivedQty"].ToString());
                    purchaseOrderDetail.RejectedQty = Int64.Parse(reader["RejectedQty"].ToString());
                    purchaseOrderDetail.StockedQty = Int64.Parse(reader["StockedQty"].ToString());
                    purchaseOrderDetail.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(purchaseOrderDetail);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "PurchaseOrderDetailCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
		public PurchaseOrderDetailCollection GetAllPurchaseOrderDetailCollection()
		{
			IDBManager dbm = new DBManager();
			PurchaseOrderDetailCollection cols = new PurchaseOrderDetailCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderDetailsAll");
				while (reader.Read())
				{
                    PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                    purchaseOrderDetail.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderDetail.PurchaseOrderDetailID = Int32.Parse(reader["PurchaseOrderDetailID"].ToString());
                    purchaseOrderDetail.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    purchaseOrderDetail.OrderQty = Int16.Parse(reader["OrderQty"].ToString());
                    purchaseOrderDetail.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    purchaseOrderDetail.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    purchaseOrderDetail.NumberOfCases = Double.Parse(reader["NumberOfCases"].ToString());
                    purchaseOrderDetail.UnitPerCase = Int32.Parse(reader["UnitPerCase"].ToString());

                    purchaseOrderDetail.ReceivedQty = Int64.Parse(reader["ReceivedQty"].ToString());
                    purchaseOrderDetail.RejectedQty = Int64.Parse(reader["RejectedQty"].ToString());
                    purchaseOrderDetail.StockedQty = Int64.Parse(reader["StockedQty"].ToString());
                    purchaseOrderDetail.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(purchaseOrderDetail);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "PurchaseOrderDetailCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public PurchaseOrderDetail GetPurchaseOrderDetail(int purchaseOrderDetailID)
		{
			IDBManager dbm = new DBManager();
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PurchaseOrderDetailID", purchaseOrderDetailID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderDetail");
				while (reader.Read())
				{
                    purchaseOrderDetail.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderDetail.PurchaseOrderDetailID = Int32.Parse(reader["PurchaseOrderDetailID"].ToString());
                    purchaseOrderDetail.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    purchaseOrderDetail.OrderQty = Int16.Parse(reader["OrderQty"].ToString());
                    purchaseOrderDetail.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    purchaseOrderDetail.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    purchaseOrderDetail.NumberOfCases = Double.Parse(reader["NumberOfCases"].ToString());
                    purchaseOrderDetail.UnitPerCase = Int32.Parse(reader["UnitPerCase"].ToString());
                    purchaseOrderDetail.ReceivedQty = Int64.Parse(reader["ReceivedQty"].ToString());
                    purchaseOrderDetail.RejectedQty = Int64.Parse(reader["RejectedQty"].ToString());
                    purchaseOrderDetail.StockedQty = Int64.Parse(reader["StockedQty"].ToString());
                    purchaseOrderDetail.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetPurchaseOrderDetail");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return purchaseOrderDetail;
		}
        //public DataSet GetPurchaseOrderDetailGridDataSet(string whereExpression, string orderBy)
        //{
        //    IDBManager dbm = new DBManager();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        dbm.CreateParameters(2);
        //        dbm.AddParameters(0, "@WhereCondition", whereExpression);
        //        dbm.AddParameters(1, "@OrderByExpression", orderBy);
        //        ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderDetailsDynamic");
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Write(ex.Message, "GetPurchaseOrderDetailDynamicDataSet()");
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        dbm.Dispose();
        //    }
        //    return ds;
        //}
        public DataSet GetPurchaseOrderDetailDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPurchaseOrderDetailsDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetPurchaseOrderDetailDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PurchaseOrderDetailCollection GetAllPurchaseOrderDetailDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			PurchaseOrderDetailCollection cols = new PurchaseOrderDetailCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPurchaseOrderDetailsDynamic");
				while (reader.Read())
				{
                    PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();

                    purchaseOrderDetail.PurchaseOrderID = Int32.Parse(reader["PurchaseOrderID"].ToString());
                    purchaseOrderDetail.PurchaseOrderDetailID = Int32.Parse(reader["PurchaseOrderDetailID"].ToString());
                    purchaseOrderDetail.DueDate = DateTime.Parse(reader["DueDate"].ToString());
                    purchaseOrderDetail.OrderQty = Int16.Parse(reader["OrderQty"].ToString());
                    purchaseOrderDetail.ProductID = Int32.Parse(reader["ProductID"].ToString());
                    purchaseOrderDetail.UnitPrice = Decimal.Parse(reader["UnitPrice"].ToString());
                    purchaseOrderDetail.NumberOfCases = Double.Parse(reader["NumberOfCases"].ToString());
                    purchaseOrderDetail.UnitPerCase = Int32.Parse(reader["UnitPerCase"].ToString());
                    purchaseOrderDetail.ReceivedQty = Int64.Parse(reader["ReceivedQty"].ToString());
                    purchaseOrderDetail.RejectedQty = Int64.Parse(reader["RejectedQty"].ToString());
                    purchaseOrderDetail.StockedQty = Int64.Parse(reader["StockedQty"].ToString());
                    purchaseOrderDetail.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(purchaseOrderDetail);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPurchaseOrderDetailDynamicCollection");
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
