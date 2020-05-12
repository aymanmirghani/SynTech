using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using MICS.BLL;
using MICS.Utilities;

namespace MICS.DAL
{
    public class GenericQueryData
    {
        LogWriter log = new LogWriter();
        public GenericQueryData() { }
        public DataSet GetDataSet(bool IsStoredProcedure,string sql)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                if (IsStoredProcedure)
                {
                    ds = dbm.GetDataSet(CommandType.StoredProcedure, sql);
                }
                else
                {
                    ds = dbm.GetDataSet(CommandType.Text, sql);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        
    }
}
