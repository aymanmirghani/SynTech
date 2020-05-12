using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    class UserData
    {
        LogWriter log = new LogWriter();
        public UserData() { }
       
        public bool UpdateUser(User user)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@ID", user.ID);
                dbm.AddParameters(1, "@EmployeeID", user.EmployeeID);
                dbm.AddParameters(2, "@UserName", user.UserName);
                dbm.AddParameters(3, "@Password", user.Password);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateUser");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteUser(User user)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", user.ID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteUser");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteUser");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteUser(int userID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", userID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteUser");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteUser");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public int AddUser(User user)
        {
            IDBManager dbm = new DBManager();
            
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@EmployeeID", user.EmployeeID);
                dbm.AddParameters(1, "@UserName", user.UserName);
                dbm.AddParameters(2, "@Password", user.Password);
                dbm.AddParameters(3, "@ID", user.ID);
                dbm.Parameters[3].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertUser");
                user.ID = Int32.Parse(dbm.Parameters[3].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddUser");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return user.ID;
        }
        public DataSet GetAllUsersDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectUsersAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public UserCollection GetAllUsersCollection()
        {
            IDBManager dbm = new DBManager();
            UserCollection col = new UserCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectUsersAll");
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = Int32.Parse(reader["ID"].ToString());
                    user.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    col.Add(user);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return col;
        }
        public User GetUser(int userID)
        {
            IDBManager dbm = new DBManager();
            User user = new User();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@ID", userID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectUser");
                while (reader.Read())
                {
                    user.ID = Int32.Parse(reader["ID"].ToString());
                    user.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetUser");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return user;
        }
        public DataSet GetAllUsersDynamicDataSet(string where, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", where);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectUsersDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersDynamicDataSet");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public UserCollection GetAllUsersDynamicCollection(string where, string orderBy)
        {
            IDBManager dbm = new DBManager();
            UserCollection col = new UserCollection();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", where);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectUsersDynamic");
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = Int32.Parse(reader["ID"].ToString());
                    user.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    col.Add(user);
                }

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersDynamicCollection");
            }
            finally
            {
                dbm.Dispose();
            }
            return col;
        }

    }
}
