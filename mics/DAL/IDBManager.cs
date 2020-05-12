using System;
using System.Collections;
using System.Data;

//using System.Data.SqlClient;

namespace MICS.DAL
{
	#region DATA PROVIDER ENUMERATION
	
	#endregion
	public interface IDBManager
	{
       
		#region PROPERTIES 

		
		string ConnectionString
		{
			get;
			set;
		}
 
		IDbConnection Connection
		{
			get;
		}
		IDbTransaction Transaction
		{
			get;
		}
 
		IDataReader DataReader
		{
			get;
		}
		IDbCommand Command
		{
			get;
		}
 
		IDbDataParameter[]Parameters
		{
			get;
		}
		#endregion
		#region METHODS
		//void Open();
		void BeginTransaction();
		void CommitTransaction();
		void CreateParameters(int paramsCount);
		void AddParameters(int index, string paramName, object objValue);
		IDataReader ExecuteReader(CommandType commandType, string commandText);
		DataSet GetDataSet(CommandType commandType, string commandText);

		object ExecuteScalar(CommandType commandType, string commandText);
		int ExecuteNonQuery(CommandType commandType,string commandText);
		void CloseReader();
		void Close();
		void Dispose();

		#endregion
	}
}