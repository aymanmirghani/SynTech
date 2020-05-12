using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;


namespace MICS.DAL
{
    class PaymentData
    {
        LogWriter log = new LogWriter();
        public PaymentData()
		{
			
		}
		public bool UpdatePayment(Payment PAY)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(7);
                dbm.AddParameters(0, "@PaymentID", PAY.PaymentID);
				dbm.AddParameters(1, "@InvoiceID", PAY.InvoiceID);
                dbm.AddParameters(2, "@PaymentType", PAY.PaymentType);
                dbm.AddParameters(3, "@PaymentDate", PAY.PaymentDate);
                dbm.AddParameters(4, "@Amount", PAY.Amount);
                dbm.AddParameters(5, "@Comments ", PAY.Comments );
                dbm.AddParameters(6, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePayment");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "UpdatePayment");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;
		}
		public bool DeletePayment(int PaymentID)
		{
			IDBManager dbm = new DBManager();
			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PaymentID", PaymentID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePayment");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "DeletePayment");
				throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return true;

		}
		public bool DeletePayment(Payment productInventory)
		{
			return(DeletePayment(productInventory.PaymentID));
		}
        public bool DeletePayment(PaymentCollection col)
        {
            try
            {

                foreach (Payment PAY in col)
                {
                    DeletePayment(PAY.PaymentID);
                }
               
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeletePayment");
                throw (ex);
            }
           
            return true;
        }
        public int AddPayment(Payment PAY)
		{
			IDBManager dbm = new DBManager();
			try
			{
                dbm.CreateParameters(8);
                
                dbm.AddParameters(0, "@InvoiceID", PAY.InvoiceID);
                dbm.AddParameters(1, "@PaymentType", PAY.PaymentType);
                dbm.AddParameters(2, "@PaymentDate", PAY.PaymentDate);
                dbm.AddParameters(3, "@Amount", PAY.Amount);
                dbm.AddParameters(4, "@Comments ", PAY.Comments);
                dbm.AddParameters(5, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(6, "@CheckNumber", PAY.CheckNumber);
                dbm.AddParameters(7, "@PaymentID", PAY.PaymentID);
                
                dbm.Parameters[7].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPayment");
                PAY.PaymentID = Int32.Parse(dbm.Parameters[7].Value.ToString());
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "AddPayment");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PAY.PaymentID;
		}
		public DataSet GetAllPaymentDataSet()
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPaymentsAll");
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetAllPaymentDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
        public DataSet GetAllPaymentDataSet(int PaymentID)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PaymentID", PaymentID);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPaymentByOrderID");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public PaymentCollection GetAllPaymentCollection(int PaymentID)
        {
            IDBManager dbm = new DBManager();
            PaymentCollection cols = new PaymentCollection();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PaymentID", PaymentID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPaymentByOrderID");
                while (reader.Read())
                {
                    Payment PAY = new Payment();
                    PAY.PaymentID = Int32.Parse(reader["PaymentID"].ToString());
                    PAY.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PAY.PaymentType = reader["PaymentType"].ToString();
                    PAY.PaymentDate = DateTime.Parse(reader["PaymentDate"].ToString());
                    PAY.Amount = decimal.Parse(reader["Amount"].ToString());
                    PAY.Comments  = reader["Comments "].ToString();
                    PAY.CheckNumber = reader["CheckNumber"].ToString();
                    PAY.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PAY);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "PaymentCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
		public PaymentCollection GetAllPaymentCollection()
		{
			IDBManager dbm = new DBManager();
			PaymentCollection cols = new PaymentCollection();

			try
			{
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPaymentsAll");
				while (reader.Read())
				{
                    Payment PAY = new Payment();
                    PAY.PaymentID = Int32.Parse(reader["PaymentID"].ToString());
                    PAY.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PAY.PaymentType = reader["PaymentType"].ToString();
                    PAY.PaymentDate = DateTime.Parse(reader["PaymentDate"].ToString());
                    PAY.Amount = decimal.Parse(reader["Amount"].ToString());
                    PAY.Comments  = reader["Comments "].ToString();
                    PAY.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    PAY.CheckNumber = reader["CheckNumber"].ToString();
                    cols.Add(PAY);
				}
			}

			catch (Exception ex)
			{
				log.Write(ex.Message, "PaymentCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}
		public Payment GetPayment(int PAYID)
		{
			IDBManager dbm = new DBManager();
            Payment PAY = new Payment();

			try
			{
				dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PaymentID", PAYID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPayment");
				while (reader.Read())
				{
                    PAY.PaymentID = Int32.Parse(reader["PaymentID"].ToString());
                    PAY.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PAY.PaymentType = reader["PaymentType"].ToString();
                    PAY.PaymentDate = DateTime.Parse(reader["PaymentDate"].ToString());
                    PAY.Amount = decimal.Parse(reader["Amount"].ToString());
                    PAY.Comments  = reader["Comments "].ToString();
                    PAY.CheckNumber = reader["CheckNumber"].ToString();
                    PAY.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
				}
			}
			catch (Exception ex)
			{
				log.Write(ex.Message, "GetPayment");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
            return PAY;
		}
		public DataSet GetPaymentDynamicDataSet(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			DataSet ds = new DataSet();
			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPaymentsDynamic");
			}
			catch (Exception ex)
			{
                log.Write(ex.Message, "GetPaymentDynamicDataSet()");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return ds;
		}
		public PaymentCollection GetAllPaymentDynamicCollection(string whereExpression, string orderBy)
		{
			IDBManager dbm = new DBManager();
			PaymentCollection cols = new PaymentCollection();

			try
			{
				dbm.CreateParameters(2);
				dbm.AddParameters(0, "@WhereCondition", whereExpression);
				dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPaymentsDynamic");
				while (reader.Read())
				{
                    Payment PAY = new Payment();

                    PAY.PaymentID = Int32.Parse(reader["PaymentID"].ToString());
                    PAY.InvoiceID = Int32.Parse(reader["InvoiceID"].ToString());
                    PAY.PaymentType = reader["PaymentType"].ToString();
                    PAY.PaymentDate = DateTime.Parse(reader["PaymentDate"].ToString());
                    PAY.Amount = decimal.Parse(reader["Amount"].ToString());
                    PAY.Comments  = reader["Comments "].ToString();
                    PAY.CheckNumber = reader["CheckNumber"].ToString();
                    PAY.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(PAY);
				}
			}

			catch (Exception ex)
			{
                log.Write(ex.Message, "GetAllPaymentDynamicCollection");
                throw (ex);
			}
			finally
			{
				dbm.Dispose();
			}
			return cols;
		}

        public decimal GetTotalPaymentsByInvoice(int InvoiceID)
        {
            decimal tot = 0;
            GenericQuery gen = new GenericQuery();
            try
            {
                string sql = "select sum(amount) as tot from payment where invoiceid=" + InvoiceID.ToString();

                DataSet ds = new DataSet();
                ds = gen.GetDataSet(false, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if(dr["tot"] != DBNull.Value)
                      tot += decimal.Parse(dr["tot"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalPaymentsByInvoice");
                throw (ex);
            }
            finally
            {
                gen = null;
            }
            return tot;



        }
        public decimal GetTotalPaymentsByCustomer(int CustomerID)
        {
            decimal tot = 0;
            GenericQuery gen = new GenericQuery();
            try
            {
                string sql = "select sum(amount) as tot from payment where orderid in(select orderid from salesorderheader where status=6 and customerid=)" + CustomerID.ToString();

                DataSet ds = new DataSet();
                ds = gen.GetDataSet(false, sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["tot"] != DBNull.Value)
                        tot += decimal.Parse(dr["tot"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalPaymentsByCustomer");
                throw (ex);
            }
            finally
            {
                gen = null;
            }
            return tot;



        }
    }
}
