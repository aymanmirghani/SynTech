using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;

namespace MICS.BLL
{
	public class PaymentMethod{
        LogWriter log = new LogWriter();
       

        private System.Int32 _PaymentMethodID;
        private System.String _Name;

		public PaymentMethod(){}
        public PaymentMethod(
                    System.Int32 paymentmethodid,
                    System.String name)
        {
            this._PaymentMethodID = paymentmethodid;
            this._Name = name;
        }
			
		public System.Int32 PaymentMethodID{
			get{return _PaymentMethodID;}
			set{ _PaymentMethodID=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public int AddPaymentMethod(PaymentMethod paymentmethod)
        {
            PaymentMethodData data = new PaymentMethodData();
            int paymentMethodID = 0;
            try
            {
                paymentMethodID = data.AddPaymentMethod(paymentmethod);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPaymentMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return paymentMethodID;
        }
		public bool RemovePaymentMethod(PaymentMethod paymentmethod)
        {
            PaymentMethodData data = new PaymentMethodData();
            bool ret = false;
            try
            {
                data.DeletePaymentMethod(paymentmethod);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePaymentMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdatePaymentMethod(PaymentMethod paymentmethod)
        {
            PaymentMethodData data = new PaymentMethodData();
            bool ret = false;
            try
            {
                data.UpdatePaymentMethod(paymentmethod);
                ret = true;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePaymentMethod");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public PaymentMethod GetPaymentMethods(int paymentMethodID)
        {
            PaymentMethodData data = new PaymentMethodData();
            PaymentMethod paymentMethod = new PaymentMethod();
            try
            {
                paymentMethod = data.GetPaymentMethod(paymentMethodID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPaymentMethods");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return paymentMethod;
        }
        public DataSet GetAllPaymentMethodDataSet()
        {
            PaymentMethodData data = new PaymentMethodData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPaymentMethodDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentMethodDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PaymentMethodCollection GetAllPaymentMethodCollection()
        {
            PaymentMethodData data = new PaymentMethodData();
            PaymentMethodCollection col = new PaymentMethodCollection();
            try
            {
                col = data.GetAllPaymentMethodsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentMethodCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetPaymentsMethodDataSet(string whereExpression, string orderByExpression)
        {
            PaymentMethodData data = new PaymentMethodData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPaymentMethodDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPaymentsMethodDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PaymentMethodCollection GetPaymentsCollection(string whereExpression, string orderByExpression)
        {
            PaymentMethodData data = new PaymentMethodData();
            PaymentMethodCollection col = new PaymentMethodCollection();
            try
            {
                col = data.GetAllPaymentMethodsDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPaymentsCollection");
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
