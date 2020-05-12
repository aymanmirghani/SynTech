using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class Location{
        LogWriter log = new LogWriter();
        private System.Int32 _LocationID;
        private System.Int32 _AddressID;
        private System.String _Name;
        private System.DateTime _ModifiedDate;

		public Location(){}
        public Location(
                    System.Int32 locationid,
                    System.Int32 addressid,
                    System.String name,
                    System.DateTime modifieddate)
        {
            this._LocationID = locationid;
            this._AddressID = addressid;
            this._Name = name;
            this._ModifiedDate = modifieddate;
        }
			
		public System.Int32 LocationID{
			get{return _LocationID;}
			set{ _LocationID=value;}
		}
		public System.Int32 AddressID{
			get{return _AddressID;}
			set{ _AddressID=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddLocation(Location location)
        {
            int locationID = 0;
            LocationData data = new LocationData();
            try
            {
                locationID = data.AddLocation(location);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddLocation");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return locationID;
        }
		public bool RemoveLocation(Location location)
        {
            bool ret = false;
            LocationData data = new LocationData();
            try
            {
                data.DeleteLocation(location);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveLocation");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateLocation(Location location)
        {
            bool ret = false;
            LocationData data = new LocationData();
            try
            {
                data.UpdateLocation(location);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateLocation");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public Location GetLocations(int locationid)
        {
            LocationData data = new LocationData();
            Location location = new Location();
            try
            {
                location = data.GetLocation(locationid);

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetLocations");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return location;
        }
        public DataSet GetAllLocationDataSet()
        {
            LocationData data = new LocationData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllLocationDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllLocationDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public LocationCollection GetAllLocationCollection()
        {
            LocationData data = new LocationData();
            LocationCollection col = new LocationCollection();
            try
            {
                col = data.GetAllLocationsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllLocationCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetLocationDataSet(string whereExpression, string orderByExpression)
        {
            LocationData data = new LocationData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetLocationDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetLocationDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public LocationCollection GetLocationCollection(string whereExpression, string orderByExpression)
        {
            LocationData data = new LocationData();
            LocationCollection col = new LocationCollection();
            try
            {
                col = data.GetAllLocationsDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetLocationCollection");
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
