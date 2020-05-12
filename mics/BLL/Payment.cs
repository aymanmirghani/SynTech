using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class Payment{
        private LogWriter log = new LogWriter();
		public Payment(){}
        public Payment(
                    System.Int32 paymentid,
                    System.Int32 invoiceid,
                    System.String paymenttype,
                    System.DateTime paymentdate,
                    System.Decimal amount,
                    System.String comments,
                    System.String checknumber,
                    System.DateTime modifieddate)
        {
            this._PaymentID = paymentid;
            this._InvoiceID = invoiceid;
            this._PaymentType = paymenttype;
            this._PaymentDate = paymentdate;
            this._Amount = amount;
            this._Comments = comments;
            this._ModifiedDate = modifieddate;
            this._CheckNumber = checknumber;
        }
			private System.Int32 _PaymentID;
			private System.Int32 _InvoiceID;
			private System.String _PaymentType;
			private System.DateTime _PaymentDate;
			private System.Decimal _Amount;
			private System.String _Comments;
			private System.DateTime _ModifiedDate;
            private System.String _CheckNumber;
        private System.String[,] _PaymentCode =
            {
              {"S", "SALE"},
              {"P", "PURCHASE"},
              {"R", "RET. CHECK"},
              {"A", "ADJUSTMENT"},
            };
		public System.Int32 PaymentID{
			get{return _PaymentID;}
			set{ _PaymentID=value;}
		}
		public System.Int32 InvoiceID{
			get{return _InvoiceID;}
			set{ _InvoiceID=value;}
		}
		public System.String PaymentType{
			get{return _PaymentType;}
			set{ _PaymentType=value;}
		}
		public System.DateTime PaymentDate{
			get{return _PaymentDate;}
			set{ _PaymentDate=value;}
		}
		public System.Decimal Amount{
			get{return _Amount;}
			set{ _Amount=value;}
		}
		public System.String Comments{
			get{return _Comments;}
			set{ _Comments=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        public System.String CheckNumber
        {
            get { return _CheckNumber; }
            set { _CheckNumber = value; }
        }
        public System.String[,] PaymentCode
        {
            get { return _PaymentCode; }
        }
		public int AddPayment(Payment payment)
        {
            PaymentData data = new PaymentData();
            int id = 0;
            try
            {
                id = data.AddPayment(payment);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddPayment");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemovePayment(int PaymentID)
        {
            PaymentData data = new PaymentData();
            bool ret = false;
            try
            {
                ret = data.DeletePayment(PaymentID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemovePayment");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdatePayment(Payment payment)
        {
            PaymentData data = new PaymentData();
            bool ret = false;
            try
            {
                ret = data.UpdatePayment(payment);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdatePayment");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public Payment GetPayment(int PaymentID)
        {
            PaymentData data = new PaymentData();
            Payment pay = new Payment();
            try
            {
                pay = data.GetPayment(PaymentID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetPayment");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return pay;
        }
        public DataSet GetAllPaymentsDataSet()
        {
            PaymentData data = new PaymentData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPaymentDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public DataSet GetAllPaymentsDataSet(int PaymentID)
        {
            PaymentData data = new PaymentData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllPaymentDataSet(PaymentID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PaymentCollection GetAllPaymentsCollection()
        {
            PaymentData data = new PaymentData();
            PaymentCollection col = new PaymentCollection();
            try
            {
                col = data.GetAllPaymentCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetPaymentsDataSet(string where, string orderBy)
        {
            PaymentData data = new PaymentData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetPaymentDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllPaymentsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public PaymentCollection GetPaymentsCollection(string where,string orderby)
        {
            PaymentData data = new PaymentData();
            PaymentCollection col = new PaymentCollection();
            try
            {
                col = data.GetAllPaymentDynamicCollection(where, orderby);
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
        public string GetPaymentCode(string strDesc)
        {
            string ret = "";
            for (int i = 0; i < _PaymentCode.Length / 2; i++)
            {
                if (_PaymentCode[i,1] == strDesc)
                {
                    ret = _PaymentCode[i, 0];
                    break;
                }
            }
            return (ret);
        }
        public string GetPaymentCodeDescription(string code)
        {
            string ret = "";
            for (int i = 0; i < _PaymentCode.Length / 2; i++)
            {
                if (_PaymentCode[i,0] == code)
                {
                    ret = _PaymentCode[i,1];
                    break;
                }
            }
            return (ret);
        }

        public decimal GetTotalPaymentsByInvoiceId(int InvoiceID)
        {
            PaymentData data = new PaymentData();
            decimal tot = 0;
            try
            {
                tot = data.GetTotalPaymentsByInvoice(InvoiceID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalPaymentsByInvoiceId");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return tot;


        }
        public decimal GetTotalPaymentsByCustomerId(int CustomerId,DateTime InvoiceDate)
        {
            GenericQuery query = new GenericQuery();
            string tot = "0";
            try
            {
                string sql = "select sum(p.amount)as TotPayments from payment p";
                sql += " join salesinvoiceheader s on p.invoiceid=s.invoiceid";
                sql += " where s.accountnumber = '" + CustomerId.ToString() + "'";
                sql += " and s.invoicedate <='" + InvoiceDate.ToShortDateString() + "'";
                DataSet ds = query.GetDataSet(false, sql);
                tot = ds.Tables[0].Rows[0][0].ToString();
                ds = null;
                if (tot == String.Empty || tot == null)
                    tot = "0";
                
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalPaymentsByCustomerId");
                throw(ex);
            }
            return (decimal.Parse(tot));

        }
    }
}
