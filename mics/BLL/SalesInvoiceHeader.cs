using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SalesInvoiceHeader{

        private LogWriter log = new LogWriter();
        
		public SalesInvoiceHeader(){}
        public SalesInvoiceHeader(
                    System.Int32 invoiceid,
                    System.String invoicenumber,
                    System.DateTime invoicedate,
                    System.DateTime duedate,
                    System.Byte status,
                    System.String accountnumber,
                    System.Int32 saleorderid,
                    System.Int32 salespersonid,
                    System.Int32 territoryid,
                    System.Int32 billtoaddressid,
                    System.Int32 shiptoaddressid,
                    System.Int32 paymentmethodid,
                    System.Decimal subtotal,
                    System.Decimal taxamt,
                    System.Decimal freight,
                    System.Decimal totaldue,
                    System.String comment,
                    System.DateTime modifieddate)
        {
            this._InvoiceID = invoiceid;
            this._InvoiceNumber = invoicenumber;
            this._InvoiceDate = invoicedate;
            this._DueDate = duedate;
            this._Status = status;
            this._AccountNumber = accountnumber;
            this._SaleOrderID = saleorderid;
            this._SalesPersonID = salespersonid;
            this._TerritoryID = territoryid;
            this._BillToAddressID = billtoaddressid;
            this._ShipToAddressID = shiptoaddressid;
            this._PaymentMethodID = paymentmethodid;
            this._SubTotal = subtotal;
            this._TaxAmt = taxamt;
            this._Freight = freight;
            this._TotalDue = totaldue;
            this._Comment = comment;
            this._ModifiedDate = modifieddate;
        }
			private System.Int32 _InvoiceID;
			private System.String _InvoiceNumber;
			private System.DateTime _InvoiceDate;
			private System.DateTime _DueDate;
			private System.Byte _Status;
			private System.String _AccountNumber;
			private System.Int32 _SaleOrderID;
			private System.Int32 _SalesPersonID;
			private System.Int32 _TerritoryID;
			private System.Int32 _BillToAddressID;
			private System.Int32 _ShipToAddressID;
			private System.Int32 _PaymentMethodID;
			private System.Decimal _SubTotal;
			private System.Decimal _TaxAmt;
			private System.Decimal _Freight;
			private System.Decimal _TotalDue;
			private System.String _Comment;
			private System.DateTime _ModifiedDate;
		public System.Int32 InvoiceID{
			get{return _InvoiceID;}
			set{ _InvoiceID=value;}
		}
		public System.String InvoiceNumber{
			get{return _InvoiceNumber;}
			set{ _InvoiceNumber=value;}
		}
		public System.DateTime InvoiceDate{
			get{return _InvoiceDate;}
			set{ _InvoiceDate=value;}
		}
		public System.DateTime DueDate{
			get{return _DueDate;}
			set{ _DueDate=value;}
		}
		public System.Byte Status{
			get{return _Status;}
			set{ _Status=value;}
		}
		public System.String AccountNumber{
			get{return _AccountNumber;}
			set{ _AccountNumber=value;}
		}
		public System.Int32 SaleOrderID{
			get{return _SaleOrderID;}
			set{ _SaleOrderID=value;}
		}
		public System.Int32 SalesPersonID{
			get{return _SalesPersonID;}
			set{ _SalesPersonID=value;}
		}
		public System.Int32 TerritoryID{
			get{return _TerritoryID;}
			set{ _TerritoryID=value;}
		}
		public System.Int32 BillToAddressID{
			get{return _BillToAddressID;}
			set{ _BillToAddressID=value;}
		}
		public System.Int32 ShipToAddressID{
			get{return _ShipToAddressID;}
			set{ _ShipToAddressID=value;}
		}
		public System.Int32 PaymentMethodID{
			get{return _PaymentMethodID;}
			set{ _PaymentMethodID=value;}
		}
		public System.Decimal SubTotal{
			get{return _SubTotal;}
			set{ _SubTotal=value;}
		}
		public System.Decimal TaxAmt{
			get{return _TaxAmt;}
			set{ _TaxAmt=value;}
		}
		public System.Decimal Freight{
			get{return _Freight;}
			set{ _Freight=value;}
		}
		public System.Decimal TotalDue{
			get{return _TotalDue;}
			set{ _TotalDue=value;}
		}
		public System.String Comment{
			get{return _Comment;}
			set{ _Comment=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
        }
        public string CreateInvoiceNumber(int OrderID,DateTime InvoiceDate)
        {
            string inv_nbr = "";
            try
            {
                decimal nbr = decimal.Parse(OrderID.ToString()) / 10000;
                string strNbr = nbr.ToString();
                if (strNbr == "1")
                    strNbr = ".1";
                while (strNbr.Length < 6)
                {
                    strNbr += "0";
                }

                int index = nbr.ToString().IndexOf('.');
                if (index == -1)
                    index = strNbr.IndexOf('.');
                strNbr = strNbr.Substring(index + 1);
                if (strNbr.Length == 3)
                    strNbr += "0";
                string four_digits = strNbr;

                string Day = InvoiceDate.Day.ToString();
                if (Day.Length == 1)
                    Day = "0" + Day;
                string Month = InvoiceDate.Month.ToString();
                if (Month.Length == 1)
                    Month = "0" + Month;
                string Year = InvoiceDate.Year.ToString();
                if (Year.Length == 4)
                    Year = Year.Substring(2, 2);
                if (Year.Length == 1)
                {
                    Year = "0" + Year;
                }

               // inv_nbr = Year + Month + Day + four_digits;
                inv_nbr = Year + Month + Day + "-" + OrderID.ToString(); ;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return (inv_nbr);
        }
        public bool InvoiceExist(int SalesOrderId)
        {
            bool ret = false;
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            try
            {
                ret = data.InvoiceExist(SalesOrderId);
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
		public int AddSalesInvoiceHeader(SalesInvoiceHeader salesinvoiceheader)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            int id = 0;
            try
            {
                if(!InvoiceExist(salesinvoiceheader.SaleOrderID))
                {
                    id = data.AddSalesInvoiceHeader(salesinvoiceheader);
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveSalesInvoiceHeader(SalesInvoiceHeader salesinvoiceheader)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesInvoiceHeader(salesinvoiceheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSalesInvoiceHeader(int invoiceID)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.DeleteSalesInvoiceHeader(invoiceID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSalesInvoiceHeader(SalesInvoiceHeader salesinvoiceheader)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            bool ret = false;
            try
            {
                ret = data.UpdateSalesInvoiceHeader(salesinvoiceheader);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSalesInvoiceHeader");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SalesInvoiceHeader GetSalesInvoiceHeaders(int invoiceID)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            SalesInvoiceHeader sih = new SalesInvoiceHeader();
            try
            {
                sih = data.GetSalesInvoiceHeader(invoiceID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceHeaders");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sih;
        }
        public DataSet GetAllSaleInvoiceHeadersDataSet()
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesInvoiceHeadersDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSaleInvoiceHeadersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesInvoiceHeaderCollection GetAllSalesInvoiceHeadersCollection()
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            SalesInvoiceHeaderCollection col = new SalesInvoiceHeaderCollection();
            try
            {
                col = data.GetAllSalesInvoiceHeadersCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSalesInvoiceHeadersCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSalesInvoiceHeadersDataSet(string where, string orderBy)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSalesInvoiceHeadersDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceHeadersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SalesInvoiceHeaderCollection GetSalesInvoiceHeadersCollection(string where, string orderBy)
        {
            SalesInvoiceHeaderData data = new SalesInvoiceHeaderData();
            SalesInvoiceHeaderCollection col = new SalesInvoiceHeaderCollection();
            try
            {
                col = data.GetAllSalesInvoiceHeadersDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSalesInvoiceHeadersCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }

        public Customer GetCustomerByOrderID(int OrderID)
        {
            int cust_id = 0;
            Customer cust = new Customer();
            string where = "SalesOrderID=" + OrderID.ToString();
            string orderby = "SalesOrderID";
            SalesOrderHeaderCollection col = new SalesOrderHeaderCollection();
            SalesOrderHeader soh = new SalesOrderHeader();
            col = soh.GetSalesOrderHeaderCollection(where, orderby);
            for (int i = 0; i < col.Count; i++)
            {
                if (col[i].SalesOrderID == OrderID)
                {
                    cust_id = col[i].CustomerID;
                    cust = cust.GetCustomer(cust_id);
                    break;
                }
            }
            return (cust);

        }

        public decimal GetTotalInvoicesByCustomerId(int CustomerId,DateTime ShipDate)
        {
            GenericQuery query = new GenericQuery();
            string tot = "0";
            string sql = "select sum(totaldue) from salesorderheader h";
           // sql += " join salesorderdetail d on h.salesorderid=d.salesorderid";
            sql += " where h.customerid=" + CustomerId.ToString() + " and status != 6 and ShipDate <='" + ShipDate.ToShortDateString() + "'";
            try
            {
                DataSet ds = query.GetDataSet(false, sql);
                tot = ds.Tables[0].Rows[0][0].ToString();
                ds = null;
                if (tot == String.Empty || tot == null)
                    tot = "0";

            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetTotalPaymentsByCustomerId");
                throw (ex);
            }
            return (decimal.Parse(tot));
        }
        public DataSet GetInvoicesBalance()
        {
            DataSet ds = new DataSet();
            SalesInvoiceHeaderData sihd = new SalesInvoiceHeaderData();
            try
            {
                ds = sihd.GetInovoicesBalanceDataSet();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                sihd = null;
            }
            return ds;
        }
	}
}
