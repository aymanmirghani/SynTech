using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.BLL;
using MICS.Utilities;
namespace MICS.DAL
{
    class LocationData
    {
        LogWriter log = new LogWriter();
        public LocationData()
        {
        }
        public bool UpdateLocation(Location location)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                dbm.AddParameters(0, "@LocationID", location.LocationID);
                dbm.AddParameters(1, "@AddressID", location.AddressID);
                dbm.AddParameters(2, "@Name", location.Name);
                dbm.AddParameters(3, "@ModifiedDate", DateTime.Now);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateLocation");


            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateLocation");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteLocation(int locationID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@LocationID", locationID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteLocation");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteLocation");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteLocation(Location location)
        {
            return(DeleteLocation(location.LocationID));
        }
        public int AddLocation(Location location)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(4);
                
                dbm.AddParameters(0, "@AddressID", location.AddressID);
                dbm.AddParameters(1, "@Name", location.Name);
                dbm.AddParameters(2, "@ModifiedDate", DateTime.Now);
                dbm.AddParameters(3, "@LocationID", location.LocationID);
                dbm.Parameters[3].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertLocation");
                location.LocationID = Int32.Parse(dbm.Parameters[3].Value.ToString());
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddLocation");
                throw(ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return location.LocationID;
        }
        public DataSet GetAllLocationDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectLocationsAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllLocationDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public LocationCollection GetAllLocationsCollection()
        {
            IDBManager dbm = new DBManager();
            LocationCollection cols = new LocationCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectLocationsAll");
                while (reader.Read())
                {
                    Location location = new Location();
                    location.LocationID = Int32.Parse(reader["LocationID"].ToString());
                    location.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    location.Name = reader["Name"].ToString();
                    location.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(location);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllLocationsCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public Location GetLocation(int locationID)
        {
            IDBManager dbm = new DBManager();
            Location location= new Location();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@LoctationID", locationID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectLocation");
                while (reader.Read())
                {
                    location.LocationID = Int32.Parse(reader["LocationID"].ToString());
                    location.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    location.Name = reader["Name"].ToString();
                    location.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetLocation");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return location;
        }
        public DataSet GetLocationDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectLocationsDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetLocationDynamicDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public LocationCollection GetAllLocationsDynamicCollection(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            LocationCollection cols = new LocationCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectLocationsDynamic");
                while (reader.Read())
                {
                    Location location = new Location();
                    location.LocationID = Int32.Parse(reader["LocationID"].ToString());
                    location.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    location.Name = reader["Name"].ToString();
                    location.ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    cols.Add(location);
                }
            }

            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllLocationsDynamicCollection");
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
