using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.Utilities;
using MICS.BLL;
namespace MICS.DAL
{
    class PaymentMethodData
    {
         LogWriter log = new LogWriter();
        public PaymentMethodData()
        {
        }
        public bool UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@PaymentMethodID", paymentMethod.PaymentMethodID);
                dbm.AddParameters(1, "@Name", paymentMethod.Name);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePaymentMethod");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePaymentMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeletePaymentMethod(int paymentMethodID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@PaymentMethodID", paymentMethodID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePaymentMethod");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeletePaymentMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeletePaymentMethod(PaymentMethod paymentMethod)
        {
            return(DeletePaymentMethod(paymentMethod.PaymentMethodID));
        }
        public int AddPaymentMethod(PaymentMethod paymentMethod)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@Name", paymentMethod.Name);
                dbm.AddParameters(1, "@PaymentMethodID", paymentMethod.PaymentMethodID);
                dbm.Parameters[1].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertPaymentMethod");
                paymentMethod.PaymentMethodID = Int32.Parse(dbm.Parameters[1].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPaymentMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return paymentMethod.PaymentMethodID;
        }
        public DataSet GetAllPaymentMethodDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPaymentMethodsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentMethodDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public PaymentMethodCollection GetAllPaymentMethodsCollection()
        {
            IDBManager dbm = new DBManager();
            PaymentMethodCollection cols = new PaymentMethodCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPaymentMethodsAll");
                while (reader.Read())
                {
                    PaymentMethod paymenyMethod = new PaymentMethod();
                    paymenyMethod.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    paymenyMethod.Name = reader["Name"].ToString();
                    cols.Add(paymenyMethod );
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentMethodsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public PaymentMethod GetPaymentMethod(int paymentMethodID)
        {
            IDBManager dbm = new DBManager();
            PaymentMethod paymentMethod= new PaymentMethod();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "Location_GetByLocationID");
                while (reader.Read())
                {
                    paymentMethod.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    paymentMethod.Name = reader["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPaymentMethod");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return paymentMethod;
        }
        public DataSet GetPaymentMethodDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectPaymentMethodsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPaymentMethodDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public PaymentMethodCollection GetAllPaymentMethodsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            PaymentMethodCollection cols = new PaymentMethodCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectPaymentMethodsDynamic");
                while (reader.Read())
                {
                    PaymentMethod paymentMethod = new PaymentMethod();
                    paymentMethod.PaymentMethodID = Int32.Parse(reader["PaymentMethodID"].ToString());
                    paymentMethod.Name = reader["Name"].ToString();
                    cols.Add(paymentMethod);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentMethodsDynamicCollection");
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
