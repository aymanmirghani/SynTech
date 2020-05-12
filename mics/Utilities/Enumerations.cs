using System;
using System.Collections.Generic;
using System.Text;

namespace MICS.Utilities
{
   public enum OrderStatus { Pending = 1, Received, Rejected, Shipped, Paid, Cancelled, Closed,PastDue,Imported };
    public enum OrderType { PurchaseOrder =1, SaleOrder, PurchaseInvoice, SaleInvoice };
    // public enum InvoiceType { Sale = 1, Purchase = 2, ShippingList };
    public enum DataProvider { Oracle = 1, SqlServer, OleDb, Odbc };
   // public enum OrderStatus { Pending = 1, Received, Rejected, Shipped, Paid, Cancelled, Closed };
   public enum PaymentType { Cash = 1, Check, Credit };
}
