using System;
using System.Data;

using System.Data.SqlClient;

namespace MICS.DAL
{
	/// <summary>
	/// Summary description for DBManagerSingletonConnection.
	/// </summary>
	public class DBManagerSingletonConnection
	{
		
        private static SqlConnection sqlConnection = null;

		private static object synRoot = new object();
		private static string mConnectionString;
		public DBManagerSingletonConnection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static string ConnectionString
		{
			get
			{
				return mConnectionString;
			}
			set
			{
				mConnectionString=value;
			}
		}
		public static bool IsOpen()
		{
			bool isOpen=false;
            isOpen = (sqlConnection.State == ConnectionState.Open);
			return isOpen;

		}
		public static void DisposeConnection()
		{
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Dispose();
		}
		
		public static IDbConnection GetConnection()
		{
			IDbConnection conn=null;
            conn = GetSQLConnection;
			
			return conn;
		}

        private static SqlConnection GetSQLConnection
		{
			get
			{
				if(sqlConnection==null)
				{
					lock(synRoot)
					{

						sqlConnection = new SqlConnection(ConnectionString);
						try
						{
							sqlConnection.Open();
						}
						catch
						{
							//connection=null;
							return null;
						}
					}
				}
				else
				{
					
					if(sqlConnection.State !=ConnectionState.Open)
					{
						sqlConnection.ConnectionString = ConnectionString;
						sqlConnection.Open();
					}
					
				}
				return sqlConnection;
			}
		}

		public static IDbCommand GetCommand()
		{
            return new SqlCommand();
			
		}
 
		public static IDbDataAdapter GetDataAdapter()
		{
            return new SqlDataAdapter();
		}
 
		public static IDbTransaction GetTransaction()
		{
            IDbConnection iDbConnection = GetSQLConnection;
			IDbTransaction iDbTransaction =iDbConnection.BeginTransaction();
			return iDbTransaction;
		}
 
		public static IDataParameter GetParameter()
		{
			IDataParameter iDataParameter = null;
            iDataParameter = new SqlParameter();
			return iDataParameter;
		}
 
		public static IDbDataParameter[]GetParameters(int paramsCount)
		{
			IDbDataParameter[]idbParams = new IDbDataParameter[paramsCount];
            for (int i = 0; i < paramsCount; ++i)
            {
                idbParams[i] = new SqlParameter();
            }
			return idbParams;
		}
	}
}
