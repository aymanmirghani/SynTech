using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Collections;


namespace MICS.DAL
{
	/// <summary>
	/// Summary description for DBManager.
	/// </summary>
	public sealed class DBManager:IDBManager,IDisposable
	{
		private IDbConnection idbConnection;
		private IDataReader idataReader;
		private IDbCommand idbCommand;
		private IDbTransaction idbTransaction =null;
		private IDbDataParameter[] idbParameters=null;
		private string connectionString;

		        //public delegate CollectionBase GenerateCollectionFromReader(object returnData);
		public DBManager()
		{
			try
			{
                
                //this.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connectionstring"].ToString();
                this.connectionString = Properties.Settings.Default.mics_serverConnectionString;
			}
			catch
			{
				throw new ArgumentException("Configuration file error"); 
			}
			DBManagerSingletonConnection.ConnectionString =this.connectionString;
			idbConnection = DBManagerSingletonConnection.GetConnection();
			//this(this.providerType,this.connectionString);
		}
 
		public DBManager(string	connectionString)
		{
			
			this.connectionString = connectionString;

			DBManagerSingletonConnection.ConnectionString = this.connectionString;
			
			idbConnection = DBManagerSingletonConnection.GetConnection();
		}
 
		public IDbConnection Connection
		{
			get
			{
				return idbConnection;
			}
		}
 
		public IDataReader DataReader
		{
			get	{return idataReader;}
			set	{idataReader = value;}
		}
 
		
 
		public string ConnectionString
		{
			get	{return connectionString;}
			set	{connectionString = value;}
		}
 
		public IDbCommand Command
		{
			get	{return idbCommand;}
		}
 
		public IDbTransaction Transaction
		{
			get	{return idbTransaction;}
		}
 
		public IDbDataParameter[]Parameters
		{
			get	{return idbParameters;}
		}
 
		
 
		public void Close()
		{
			if (idbConnection.State !=ConnectionState.Closed)
				idbConnection.Close();
		}
 
		public void Dispose()
		{
			GC.SuppressFinalize(this);
           
			this.Close();
			this.idbCommand = null;
			this.idbTransaction = null;
			this.idbConnection = null;
			//DBManagerSingletonConnection.DisposeConnection();
		}
 
		public void CreateParameters(int paramsCount)
		{
			idbParameters = new IDbDataParameter[paramsCount];
			idbParameters =DBManagerSingletonConnection.GetParameters(paramsCount);
		}
 
		public void AddParameters(int index, string paramName, object objValue)
		{
			if (index < idbParameters.Length)
			{
				idbParameters[index].ParameterName =paramName;
				idbParameters[index].Value = objValue;
			}
		}
 
		public void BeginTransaction()
		{
			if (this.idbTransaction == null)
				idbTransaction =
					DBManagerSingletonConnection.GetTransaction();
			this.idbCommand.Transaction =idbTransaction;
		}
 
		public void CommitTransaction()
		{
			if (this.idbTransaction != null)
				this.idbTransaction.Commit();
			idbTransaction = null;
		}
		public void RollBackTransaction()
		{
			if (this.idbTransaction != null)
				this.idbTransaction.Rollback();
			idbTransaction = null;
		} 
		
		public IDataReader ExecuteReader(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerSingletonConnection.GetCommand();
			idbCommand.Connection = this.Connection;
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			this.DataReader =idbCommand.ExecuteReader();
			idbCommand.Parameters.Clear();
			return this.DataReader;
		}
 
		public void CloseReader()
		{
			if (this.DataReader != null)
				this.DataReader.Close();
		}
 
		private void AttachParameters(IDbCommand command,  IDbDataParameter[]commandParameters)
		{
			foreach (IDbDataParameter idbParameter in commandParameters)
			{
				if ((idbParameter.Direction == ParameterDirection.InputOutput)
					&&
					(idbParameter.Value == null))
				{
					idbParameter.Value = DBNull.Value;
				}
				command.Parameters.Add(idbParameter);
			}
		}
 
		private void PrepareCommand(IDbCommand command, IDbConnection
			connection,
			IDbTransaction transaction, CommandType commandType, string
			commandText,
			IDbDataParameter[]commandParameters)
		{
			command.Connection = connection;
			command.CommandText = commandText;
			command.CommandType = commandType;
 
			if (transaction != null)
			{
				command.Transaction = transaction;
			}
 
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}
		}
 
		public int ExecuteNonQuery(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerSingletonConnection.GetCommand();
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType, commandText,this.Parameters);
			int returnValue =idbCommand.ExecuteNonQuery();
           
			idbCommand.Parameters.Clear();
			return returnValue;
		}
 
		public object ExecuteScalar(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerSingletonConnection.GetCommand();
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			object returnValue = idbCommand.ExecuteScalar();
			idbCommand.Parameters.Clear();
			return returnValue;
		}
 
		public DataSet GetDataSet(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerSingletonConnection.GetCommand();
			PrepareCommand(idbCommand,this.Connection, this.Transaction, commandType,
				commandText, this.Parameters);
			IDbDataAdapter dataAdapter =DBManagerSingletonConnection.GetDataAdapter();
			dataAdapter.SelectCommand = idbCommand;
			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet);
			idbCommand.Parameters.Clear();
			return dataSet;
		}
	}

}

