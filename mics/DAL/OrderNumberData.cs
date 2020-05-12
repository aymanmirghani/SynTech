using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    public class OrderNumberData
    {
        LogWriter log = new LogWriter();
        public OrderNumberData() { }
        public bool UpdateOrderNumber(OrderNumber orderNumber )
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@ID", orderNumber.Id);
                dbm.AddParameters(1, "@today", orderNumber.TodaysDate.ToShortDateString());
                dbm.AddParameters(2, "@SeqNumber", orderNumber.SequenceNumber);
                dbm.AddParameters(3, "@OrderType", orderNumber.Ordertype);
                //dbm.Parameters[0].Direction = ParameterDirection.Output;

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateOrderNumber");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateOrderNumber");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteOrderNumber(int id)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", id);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteOrderNumber");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteOrderNumber");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public int AddOrderNumber(OrderNumber orderNumber)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@ID", orderNumber.Id);
                dbm.AddParameters(1, "@today", orderNumber.TodaysDate.ToShortDateString());
                dbm.AddParameters(2, "@SeqNumber", orderNumber.SequenceNumber);
                dbm.AddParameters(3, "@OrderType", orderNumber.Ordertype);
                dbm.Parameters[0].Direction = ParameterDirection.Output;

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertOrderNumber");
                orderNumber.Id = Int32.Parse(dbm.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddOrderNumber");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return orderNumber.Id;
        }
        public List<OrderNumber> GetOrderNumber(string where)
        {
            IDBManager dbm = new DBManager();
            OrderNumber orderNumber = new OrderNumber();
            List<OrderNumber> list = new List<OrderNumber>();
           
           
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", where);
                dbm.AddParameters(1, "@OrderByExpression", String.Empty);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectOrderNumbersDynamic");
                while (reader.Read())
                {
                    orderNumber.Id = Int32.Parse(reader["id"].ToString());
                    orderNumber.Ordertype = Int32.Parse(reader["OrderType"].ToString());
                    orderNumber.SequenceNumber = Int32.Parse(reader["SeqNumber"].ToString());
                    orderNumber.TodaysDate = DateTime.Parse(reader["today"].ToString());
                    list.Add(orderNumber);
                }

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetOrderNumber()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return list;
        }
        public OrderNumber GetOrderNumber(int id)
        {
            IDBManager dbm = new DBManager();
            OrderNumber orderNumber = new OrderNumber();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", id);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectOrderNumber");
                while (reader.Read())
                {
                    orderNumber.Id = Int32.Parse(reader["id"].ToString());
                    orderNumber.Ordertype = Int32.Parse(reader["OrderType"].ToString());
                    orderNumber.SequenceNumber = Int32.Parse(reader["SeqNumber"].ToString());
                    orderNumber.TodaysDate = DateTime.Parse(reader["today"].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetOrderNumber");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return orderNumber;
        }
    }
}
