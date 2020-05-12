using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class User{
        private LogWriter log = new LogWriter();
       
		public User(){}
        public User(
                    System.Int32 id,
                    System.Int32 employeeid,
                    System.String username,
                    System.String password)
        {
            this._ID = id;
            this._EmployeeID = employeeid;
            this._UserName = username;
            this._Password = password;
        }
			private System.Int32 _ID;
			private System.Int32 _EmployeeID;
			private System.String _UserName;
			private System.String _Password;
		public System.Int32 ID{
			get{return _ID;}
			set{ _ID=value;}
		}
		public System.Int32 EmployeeID{
			get{return _EmployeeID;}
			set{ _EmployeeID=value;}
		}
		public System.String UserName{
			get{return _UserName;}
			set{ _UserName=value;}
		}
		public System.String Password{
			get{return _Password;}
			set{ _Password=value;}
		}
		public int AddUser(User user)
        {
            UserData data = new UserData();
            int id = 0;
            try
            {
                id = data.AddUser(user);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddUser");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveUser(User user)
        {
            UserData data = new UserData();
            bool ret = false;
            try
            {
                ret = data.DeleteUser(user);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveUser");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveUser(int userID)
        {
            UserData data = new UserData();
            bool ret = false;
            try
            {
                ret = data.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveUser");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateUser(User user)
        {
            UserData data = new UserData();
            bool ret = false;
            try
            {
                ret = data.UpdateUser(user);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateUser");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public User GetUser(int userID)
        {
            UserData data = new UserData();
            User user = new User();
            try
            {
                user = data.GetUser(userID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetUser");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return user;
        }
        public DataSet GetAllUsersDataSet()
        {
            UserData data = new UserData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllUsersDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public UserCollection GetAllUsersCollection()
        {
            UserData data = new UserData();
            UserCollection col = new UserCollection();
            try
            {
                col = data.GetAllUsersCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetAllUsersDataSet(string where, string orderBy)
        {
            UserData data = new UserData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllUsersDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public UserCollection GetAllUsersCollection(string where, string orderBy)
        {
            UserData data = new UserData();
            UserCollection col = new UserCollection();
            try
            {
                col = data.GetAllUsersDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllUsersCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

	}
}
