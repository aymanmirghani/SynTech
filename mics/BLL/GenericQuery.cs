using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;

namespace MICS.BLL
{
    public class GenericQuery
    {
        
        LogWriter log = new LogWriter();
        public GenericQuery(){}
        public DataSet GetDataSet(bool IsStoredProcedure,string sql)
        {
            GenericQueryData data = new GenericQueryData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetDataSet(IsStoredProcedure, sql);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
    }
}
