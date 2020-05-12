
using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;

namespace MICS.BLL
{
	public class Employee{
        LogWriter log = new LogWriter();
		public Employee()
        {
            this._EmployeeID = 0;
            this._FirstName = String.Empty;
            this._LastName = String.Empty;
            this._MiddleName = String.Empty;
            this._Login = String.Empty;
            this._AddressID = 0;
            this._FullName = String.Empty;
            this._WorkPhone = String.Empty;
            this._HomePhone = String.Empty;
            this._CellPhone = String.Empty;
           

        }
		public Employee(
					System.Int32 employeeid,
					System.String firstname,
					System.String lastname,
					System.String middlename,
					System.String login,
					System.Int32 addressid,
                    System.String workphone,
                    System.String homephone,
                    System.String cellphone,
                    System.String fullname
		){
		this._EmployeeID = employeeid;
		this._FirstName = firstname;
		this._LastName = lastname;
		this._MiddleName = middlename;
		this._Login = login;
		this._AddressID = addressid;
        this._FullName = fullname;
        this._HomePhone = homephone;
        this._WorkPhone = workphone;
        this._CellPhone = cellphone;
		}
			private System.Int32 _EmployeeID;
			private System.String _FirstName;
			private System.String _LastName;
			private System.String _MiddleName;
			private System.String _Login;
			private System.Int32 _AddressID;
            private System.String _FullName;
            private System.String _WorkPhone;
            private System.String _HomePhone;
            private System.String _CellPhone;
		public System.Int32 EmployeeID{
			get{return _EmployeeID;}
			set{ _EmployeeID=value;}
		}
		public System.String FirstName{
			get{return _FirstName;}
			set{ _FirstName=value;}
		}
		public System.String LastName{
			get{return _LastName;}
			set{ _LastName=value;}
		}
		public System.String MiddleName{
			get{return _MiddleName;}
			set{ _MiddleName=value;}
		}
		public System.String Login{
			get{return _Login;}
			set{ _Login=value;}
		}
		public System.Int32 AddressID{
			get{return _AddressID;}
			set{ _AddressID=value;}
		}
        public System.String FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        public System.String WorkPhone
        {
            get { return _WorkPhone; }
            set { _WorkPhone = value; }
        }
        public System.String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
        public System.String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
		public int AddEmployee(Employee employee)
        {
            EmployeeData data = new EmployeeData();
            int employeeID = 0;
            try
            {
                employeeID = data.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddEmployee");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return employeeID;
        }
		public bool RemoveEmployee(Employee employee)
        {
            EmployeeData data = new EmployeeData();
            bool ret = false;
            try
            {
                data.DeleteEmployee(employee);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveEmployee");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateEmployee(Employee employee)
        {
            EmployeeData data = new EmployeeData();
            bool ret = false;
            try
            {
                data.UpdateEmployee(employee);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public Employee GetEmployee(int employeeId)
        {
            EmployeeData data = new EmployeeData();
            Employee employee = new Employee();
            try
            {
                employee = data.GetEmployee(employeeId);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetEmployee");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return employee;
        }
        public DataSet GetAllEmployeesDataSet()
        {
            EmployeeData data = new EmployeeData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllEmployeesDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllEmployeesDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public EmployeeCollection GetAllEmployeesCollection()
        {
            EmployeeCollection col = new EmployeeCollection();
            EmployeeData data = new EmployeeData();
            try
            {
                col = data.GetAllEmployeesCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllEmployeesCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetEmployeesDataSet(string whereExpression, string orderByExpression)
        {
            DataSet ds = new DataSet();
            EmployeeData data = new EmployeeData();
            try
            {
                ds = data.GetEmployeeDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetEmployeesDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public EmployeeCollection GetEmployeesCollection(string whereExpression, string orderByExpression)
        {
            EmployeeCollection col = new EmployeeCollection();
            EmployeeData data = new EmployeeData();
            try
            {
                col = data.GetEmployeeDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetEmployeesCollection");
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
