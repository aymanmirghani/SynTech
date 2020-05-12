using System;
using System.Collections.Generic;
using System.Text;
using MICS.BLL;
using MICS.Utilities;
using System.Data;
namespace MICS.DAL
{
    class EmployeeData
    {
        LogWriter log = new LogWriter();
        public EmployeeData()
        {
        }
        public bool UpdateEmployee(Employee employee)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(9);
                dbm.AddParameters(0, "@EmployeeID", employee.EmployeeID);
                dbm.AddParameters(1, "@FirstName", employee.FirstName);
                dbm.AddParameters(2, "@MiddleName", employee.MiddleName);
                dbm.AddParameters(3, "@LastName", employee.LastName);
                dbm.AddParameters(4, "@Login", employee.Login);
                dbm.AddParameters(5, "@AddressID", employee.AddressID);

                dbm.AddParameters(6, "@WorkPhone", employee.WorkPhone);
                dbm.AddParameters(7, "@HomePhone", employee.HomePhone);
                dbm.AddParameters(8, "@CellPhone", employee.CellPhone);

                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateEmployee");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateEmployee");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;
        }
        public bool DeleteEmployee(int employeeID)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@EmployeeID", employeeID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteEmployee");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteEmployee");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public bool DeleteEmployee(Employee employee)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "@EmployeeID", employee.EmployeeID);
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteEmployee");

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "DeleteEmployee");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return true;

        }
        public int AddEmployee(Employee employee)
        {
            IDBManager dbm = new DBManager();
            try
            {
                dbm.CreateParameters(9);
                
                dbm.AddParameters(0, "@FirstName", employee.FirstName);
                dbm.AddParameters(1, "@MiddleName", employee.MiddleName);
                dbm.AddParameters(2, "@LastName", employee.LastName);
                dbm.AddParameters(3, "@Login", employee.Login);
                dbm.AddParameters(4, "@AddressID", employee.AddressID);
                dbm.AddParameters(5, "@WorkPhone", employee.WorkPhone);
                dbm.AddParameters(6, "@HomePhone", employee.HomePhone);
                dbm.AddParameters(7, "@CellPhone", employee.CellPhone);
                dbm.AddParameters(8, "@EmployeeID", employee.EmployeeID);
                dbm.Parameters[8].Direction = ParameterDirection.Output;
                dbm.ExecuteNonQuery(CommandType.StoredProcedure, "InsertEmployee");
                employee.EmployeeID = Int32.Parse(dbm.Parameters[8].Value.ToString());


            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddEmployee");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return employee.EmployeeID;
        }
        public DataSet GetAllEmployeesDataSet()
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectEmployeesAll");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllEmployeeDataSet()");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public EmployeeCollection GetAllEmployeesCollection()
        {
            IDBManager dbm = new DBManager();
            EmployeeCollection cols = new EmployeeCollection();

            try
            {
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectEmployeesAll");
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    employee.FirstName= reader["FirstName"].ToString().Trim();
                    employee.MiddleName = reader["MiddleName"].ToString().Trim();
                    employee.LastName = reader["LastName"].ToString().Trim();
                    employee.Login = reader["Login"].ToString().Trim();
                    employee.AddressID= Int32.Parse(reader["AddressID"].ToString());
                    employee.FullName = reader["FullName"].ToString().Trim();
                    employee.WorkPhone = reader["WorkPhone"].ToString();
                    employee.HomePhone = reader["HomePhone"].ToString();
                    employee.CellPhone = reader["CellPhone"].ToString();
                    
                    cols.Add(employee);
                    employee = null;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllEmployeesCollection");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return cols;
        }
        public Employee GetEmployee(int employeeID)
        {
            IDBManager dbm = new DBManager();
            Employee employee = new Employee();

            try
            {
                dbm.CreateParameters(1);
                dbm.AddParameters(0, "EmployeeID", employeeID);
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectEmployee");
                while (reader.Read())
                {
                    employee.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.MiddleName = reader["MiddleName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.Login = reader["Login"].ToString();
                    employee.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    employee.WorkPhone = reader["WorkPhone"].ToString();
                    employee.HomePhone = reader["HomePhone"].ToString();
                    employee.CellPhone = reader["CellPhone"].ToString();
                   // employee.FullName = reader["FullName"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAddressByID");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return employee;
        }
        public DataSet GetEmployeeDynamicDataSet(string whereExpression, string orderBy)
        {
            IDBManager dbm = new DBManager();
            DataSet ds = new DataSet();
            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                ds = dbm.GetDataSet(CommandType.StoredProcedure, "SelectEmployeesDynamic");
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetEmployeeDynamicDataSet");
                throw (ex);
            }
            finally
            {
                dbm.Dispose();
            }
            return ds;
        }
        public EmployeeCollection GetEmployeeDynamicCollection(string whereExpression,string orderBy)
        {
            IDBManager dbm = new DBManager();
            EmployeeCollection cols = new EmployeeCollection();

            try
            {
                dbm.CreateParameters(2);
                dbm.AddParameters(0, "@WhereCondition", whereExpression);
                dbm.AddParameters(1, "@OrderByExpression", orderBy);
                
                IDataReader reader = dbm.ExecuteReader(CommandType.StoredProcedure, "SelectEmployeesDynamic");
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Int32.Parse(reader["EmployeeID"].ToString());
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.MiddleName = reader["MiddleName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.Login = reader["Login"].ToString();
                    employee.AddressID = Int32.Parse(reader["AddressID"].ToString());
                    employee.WorkPhone = reader["WorkPhone"].ToString();
                    employee.HomePhone = reader["HomePhone"].ToString();
                    employee.CellPhone = reader["CellPhone"].ToString();
                    //employee.FullName = reader["FullName"].ToString();
                    cols.Add(employee);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetEmployeeDynamicCollection");
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
