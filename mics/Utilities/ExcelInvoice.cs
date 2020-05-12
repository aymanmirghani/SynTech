using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using MICS.BLL;
using MICS.DAL;
using Excel;

namespace MICS.Utilities
{
    class ExcelInvoice
    {
        public enum InvoiceType {Sale=1,Purchase=2,ShippingList};
        private int m_iInvoiceType = 0;
        private string m_TemplatePath = "";
        Excel.Application InvoiceTemplate = null;
        Excel.Workbook excelWorkbook = null;
        Excel.Sheets InvoiceSheets = null;
        Excel.Worksheet excelWorksheet = null;

        private string m_CompanyName;
        private string m_ShippingStreet;
        private string m_ShippingCity;
        private string m_ShippingState;
        private string m_ShippingZip;
        private string m_BillingStreet;
        private string m_BillingCity;
        private string m_BillingState;
        private string m_BillingZip;
        private DateTime  m_InvoiceDate;
        private string m_InvoiceNumber;
        private int m_CustomerID;
        private string m_PaymentsTerms;
        private DateTime m_DeliveryDate;
        private decimal m_PreviousBalance;
        private string m_SalePerson;
        private DateTime m_DueDate;
        private decimal m_TotalDue;
        private decimal m_InvoiceTotal;
        private decimal m_TotalDiscount;
        private int m_Copies;
        private string m_Comments;
        public ExcelInvoice()
        {
        }
        public ExcelInvoice(InvoiceType type)
        {
            m_iInvoiceType = (int)type;
            m_Copies = 1;
            m_TotalDiscount = 0;
            m_TotalDue = 0;
            m_PreviousBalance = 0;
            m_InvoiceTotal = 0;
            
        }
        public void SetupInvoiceDataTable(System.Data.DataTable dt)
        {
            if(dt == null)
                dt = new System.Data.DataTable();
            dt.Columns.Add(new DataColumn("Nbr", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Product", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt.Columns.Add(new DataColumn("Total", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Grand Total", typeof(decimal)));
        }
        private void FillInvoiceDataTable(DataSet ds, System.Data.DataTable dt)
        {
           // int i = 1;
            Product product = new Product();
            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    //dr["Nbr"] = i++;
                    dr["ID"] = row["InvoiceID"];
                    int prod_id = Int32.Parse(row["ProductID"].ToString());
                    dr["Product"] = product.GetProduct(prod_id).Name;
                    dr["Price"] = row["UnitPrice"];
                    dr["Quantity"] = row["Quantity"];
                    dr["Total"] = row["LineTotal"];
                    dr["Discount"] = row["UnitPriceDiscount"];
                    dr["Grand Total"] = row["LineTotal"];
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        //public void Print(int InvoiceId, int OrderId)
        //{
        //    m_iInvoiceType = (int)InvoiceType.Sale;
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        SalesInvoiceHeader sih = new SalesInvoiceHeader();
        //        sih = sih.GetSalesInvoiceHeaders(InvoiceId);
        //        this.InvoiceDate = sih.InvoiceDate;
        //        this.DueDate = sih.DueDate;
        //        this.DeliveryDate = sih.DueDate;
        //        this.InvoiceNumber = sih.InvoiceNumber;
        //        this.CusotmerID = Int32.Parse(sih.AccountNumber);
        //        int shipping_address_id = sih.ShipToAddressID;
        //        int billing_address_id = sih.BillToAddressID;
        //        Address address = new Address();
        //        address = address.GetAddresss(shipping_address_id);
        //        this.ShippingStreet = address.AddressLine1;
        //        this.ShippingCity = address.City;
        //        this.ShippingState = address.StateProvince;
        //        this.ShippingZip = address.PostalCode;
        //        Address BillingAdd = new Address();
        //        BillingAdd = BillingAdd.GetAddresss(billing_address_id);
        //        this.BillingStreet = BillingAdd.AddressLine1;
        //        this.BillingCity = BillingAdd.City;
        //        this.BillingState = BillingAdd.StateProvince;
        //        this.BillingZip = BillingAdd.PostalCode;
        //        this.TotalDue = sih.TotalDue;

        //        Customer cus = new Customer();
        //        cus = cus.GetCustomer(this.CusotmerID);
        //        this.CompanyName = cus.Name;
        //        decimal credit_limit = cus.CreditLimit;
        //        int territory_id = cus.TerritoryID;
        //        string terms = "Cash/Check";
        //        if (credit_limit > 0)
        //            terms = "One Week";
        //       this.PaymentTerms = terms;
        //       //sale person data
        //       SalesTerritoryHistory territory = new SalesTerritoryHistory();
        //       DataSet dsTerritory = territory.GetSalesTerritoryHistory(territory_id);
        //       string salepersonphone = "";
        //       string salepersonname = "";
        //       if (dsTerritory.Tables[0].Rows.Count > 0)
        //       {
        //           int saleperson_id = Int32.Parse(dsTerritory.Tables[0].Rows[0]["SalesPersonID"].ToString());
        //           Employee emp = new Employee();
        //           emp = emp.GetEmployee(saleperson_id);
        //           salepersonname = emp.FirstName.Trim() + " " + emp.LastName.Trim();
        //           if (emp.CellPhone != String.Empty)
        //               salepersonphone = emp.CellPhone.Trim();
        //           else if (emp.WorkPhone != String.Empty)
        //               salepersonphone = emp.WorkPhone;
        //           else if (emp.HomePhone != String.Empty)
        //               salepersonphone = emp.HomePhone;
        //       }
        //       this.SalePerson = salepersonname + " " + salepersonphone;
        //        //Previous balance
        //       Payment p = new Payment();
        //       decimal tot_payments = p.GetTotalPaymentsByCustomerId(this.CusotmerID);
        //       decimal tot_invoices = sih.GetTotalInvoicesByCustomerId(this.CusotmerID);
        //       this.PreviousBalance = tot_invoices - tot_payments;
        //     //  SetupInvoiceDataTable(dt);
        //       SalesOrderDetail sod = new SalesOrderDetail();
        //       DataSet ds = sod.GetOrderDetailsGroupedByName(OrderId);
        //      // DataSet ds = sid.GetSalesInvoiceDetailDataSet("InvoiceId=" + InvoiceId, "InvoiceId");
        //     //  FillInvoiceDataTable(ds, dt);
        //       Print(ds.Tables[0]);

                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void Print(System.Data.DataTable dt)
        {
            try
            {
                switch (m_iInvoiceType)
                {

                    case (int)InvoiceType.Sale:
                        //m_TemplatePath = @"c:\dev\mics\Templates\sale.xls";
                        m_TemplatePath = System.Configuration.ConfigurationManager.AppSettings["TemplatesDir"];
                        PrintSaleInvoice(dt);
                        break;
                    case (int)InvoiceType.Purchase:
                        m_TemplatePath = @"c:\dev\mics\Templates\purchase.xls";
                        PrintPurchaseInvoice(dt);
                        break;
                    case (int)InvoiceType.ShippingList:
                        //m_TemplatePath = @"c:\dev\mics\Templates\sale.xls";
                        m_TemplatePath = System.Configuration.ConfigurationManager.AppSettings["TemplatesDir"];
                        PrintShippingList(dt);
                        break;
                }
            }
            catch (Exception ex)
            {
               throw(ex);
            }
        }
        private void FillCellsWithData(System.Data.DataTable dt,int pos,int row)
        {
            Product p = new Product();
            int counter = row;
            int itemsTotal = dt.Rows.Count;
            string Quant = "B" + pos.ToString();
            string ID = "A" + pos.ToString();
            string Name = "C" + pos.ToString();
            string Name2 = "D" + pos.ToString();
            string Price = "E" + pos.ToString();
            string Discount = "F" + pos.ToString();
            string Total = "G" + pos.ToString();

            Excel.Range QuantCell = (Excel.Range)excelWorksheet.get_Range(Quant, Quant);
            
            QuantCell.Value2 = dt.Rows[counter]["Quantity"].ToString();

            //Excel.Range IDCell = (Excel.Range)excelWorksheet.get_Range(ID, ID);
            //int item = counter + 1;
            //IDCell.Value2 = item.ToString();

            
            Excel.Range PriceCell = (Excel.Range)excelWorksheet.get_Range(Price, Price);
            PriceCell.Value2 = dt.Rows[counter]["Price"].ToString();

            if (m_iInvoiceType == (int)InvoiceType.Sale)
            {
                Excel.Range DiscountCell = (Excel.Range)excelWorksheet.get_Range(Discount, Discount);
                DiscountCell.Value2 = dt.Rows[counter]["Discount"].ToString();
                m_TotalDiscount += decimal.Parse(dt.Rows[counter]["Discount"].ToString());

                Excel.Range TotalCell = (Excel.Range)excelWorksheet.get_Range(Total, Total);
                TotalCell.Value2 = dt.Rows[counter]["Grand Total"].ToString();
                //m_TotalDue += decimal.Parse(dt.Rows[counter]["Grand Total"].ToString());
            }
            Excel.Range NameCell = (Excel.Range)excelWorksheet.get_Range(Name, Name2);
            //p = p.GetProduct(Int32.Parse(dt.Rows[counter]["ID"].ToString()));
            if (m_iInvoiceType == (int)InvoiceType.Sale)
            {
                NameCell.Value2 = dt.Rows[counter]["Name"].ToString();
                                  
                if (NameCell.Value2.ToString().Contains("<< "))
                {
                    QuantCell.Value2 = "";
                    PriceCell.Value2 = "";
                    
                    
                }
            }
            else
            {
                NameCell.Value2 = dt.Rows[counter]["Product"].ToString();
            }

            p = null;
        }
        private void PrintSaleInvoice(System.Data.DataTable dt)
        {
            try
            {
                int PageSize = 25;
                int TotalPages = dt.Rows.Count / 25;
                int remainder = dt.Rows.Count % 25;
                if (remainder > 0)
                    TotalPages++;
                //FillInvoiceHeader(TotalPages);                
                int iStart = 14;
                int pos = 0;
                int row = 0;
                m_TotalDiscount = 0;
                for (int page = 0; page < TotalPages ; page++)
                {
                    if (page > 0)
                        iStart = 51;
                    OpenTemplate();
                    FillInvoiceHeader(page+1,TotalPages);
                    for (int index = 0; index <  PageSize; index++)
                    {
                        if (row >= dt.Rows.Count)
                            break;
                        pos = iStart + index;
                        FillCellsWithData(dt,pos,row);
                        row++;

                    }
                    if (page == TotalPages - 1) //Last page
                    {
                        if (TotalPages == 1)
                            pos = 39;
                        else 
                            pos = 76;
                      
                        string TotDiscountValue = "F" + pos.ToString();
                        Excel.Range TotDiscountValueCell = (Excel.Range)excelWorksheet.get_Range(TotDiscountValue, TotDiscountValue);
                        TotDiscountValueCell.Value2 = m_TotalDiscount.ToString();
                      
                        pos++;
                        string TotalValue = "G" + pos.ToString();
                        Excel.Range TotalValueCell = (Excel.Range)excelWorksheet.get_Range(TotalValue, TotalValue);
                        TotalValueCell.Value2 = m_InvoiceTotal.ToString();

                       
                    }
                    //excelWorkbook.SaveCopyAs("C:\\DEV\\MICS\\TEMPLATES\\inv" + page + ".xls");
                    if (page == 0)
                        excelWorksheet.PrintOut(1, 1, m_Copies, false, "", false, false, "");
                    else
                        excelWorksheet.PrintOut(2, 2, m_Copies, false, "", false, false, "");
                    
                    excelWorkbook.Close(false, m_TemplatePath, true);
                }

            }
            catch (Exception ex)
            {
                excelWorkbook.Close(false, m_TemplatePath, true);
                throw(ex);
            }
        }
        private void FillInvoiceHeader(int page, int TotalPages)
        {

            int Xpos = 3;
            string YPos = "G";
            string PageOf = "F2";
            if (page > 1)
            {
                if (m_iInvoiceType == (int)InvoiceType.Sale)
                {
                    Xpos = 43;
                    PageOf = "F42";
                }
                else
                {
                    Xpos = 38;
                    PageOf = "F37";
                }
            }
            string pos = YPos + Xpos.ToString(); ;    
            //if (m_iInvoiceType == (int)InvoiceType.Sale)
            //{
                Excel.Range PageOfCell = (Excel.Range)excelWorksheet.get_Range(PageOf, PageOf);
                PageOfCell.Value2 = "Page " + page.ToString() +" Of " + TotalPages.ToString();
            //}
                        
            string InvDate = pos;
            Excel.Range InvDateCell = (Excel.Range)excelWorksheet.get_Range(InvDate, InvDate);
            if (m_iInvoiceType == (int)InvoiceType.Sale)
                InvDateCell.Value2 = m_DeliveryDate.ToShortDateString();
            else
                InvDateCell.Value2 = m_DueDate.ToShortDateString();

            Xpos++;
            pos = YPos + Xpos.ToString();
            string InvNbr = pos;
            Excel.Range InvNbrCell = (Excel.Range)excelWorksheet.get_Range(InvNbr, InvNbr);
            InvNbrCell.Value2 = m_InvoiceNumber;

            Xpos++;
            pos = YPos + Xpos.ToString();
            string CustID = pos;
            Excel.Range CustIDCell = (Excel.Range)excelWorksheet.get_Range(CustID, CustID);
            CustIDCell.Value2 = m_CustomerID.ToString();

            Xpos++;
            string BillName = "C" + Xpos.ToString();
            string BillName2 = "D" + Xpos.ToString();
            Excel.Range BillNameCell = (Excel.Range)excelWorksheet.get_Range(BillName, BillName2);
            BillNameCell.Value2 = m_CompanyName;
            //if (m_iInvoiceType == (int)InvoiceType.Sale)
            //{
            //    string ShipName = "E" + Xpos.ToString();
            //    string ShipName2 = "F" + Xpos.ToString();
            //    Excel.Range ShipNameCell = (Excel.Range)excelWorksheet.get_Range(ShipName, ShipName2);
            //    ShipNameCell.Value2 = m_CompanyName;
            //}

            Xpos++;
            string BillAdd = "C" + Xpos.ToString();
            string BillAdd2 = "D" + Xpos.ToString();
            Excel.Range BillAddCell = (Excel.Range)excelWorksheet.get_Range(BillAdd, BillAdd2);
            BillAddCell.Value2 = m_BillingStreet;
            //if (m_iInvoiceType == (int)InvoiceType.Sale)
            //{
            //    string ShipAdd = "E" + Xpos.ToString();
            //    string ShipAdd2 = "F" + Xpos.ToString();
            //    Excel.Range ShipAddCell = (Excel.Range)excelWorksheet.get_Range(ShipAdd, ShipAdd2);
            //    ShipAddCell.Value2 = m_ShippingStreet;
            //}

            Xpos++;
            string BillCityState = "C" + Xpos.ToString();
            string BillCityState2 = "D" + Xpos.ToString();
            Excel.Range BillCityStateCell = (Excel.Range)excelWorksheet.get_Range(BillCityState, BillCityState2);
            BillCityStateCell.Value2 = m_BillingCity + " " + m_BillingState + " " + m_BillingZip;
            //if (m_iInvoiceType == (int)InvoiceType.Sale)
            //{
            //    string ShipCityState = "E" + Xpos.ToString(); ;
            //    string ShipCityState2 = "F" + Xpos.ToString(); ;
            //    Excel.Range ShipCityStateCell = (Excel.Range)excelWorksheet.get_Range(ShipCityState, ShipCityState2);
            //    ShipCityStateCell.Value2 = m_ShippingCity + " " + m_ShippingState + " " + m_ShippingZip;
            //}
                             

                if (m_iInvoiceType == (int)InvoiceType.Sale)
                {
                    if (page == 1)
                    {
                        //Comments
                        //string comments = "C9";
                        //string comments2 = "F9";
                        //Excel.Range CommentCell = (Excel.Range)excelWorksheet.get_Range(comments, comments2);
                        //CommentCell.Value2 = m_Comments;

                        //Sale person
                        string saleperson = "D11";
                        Excel.Range salepersonCell = (Excel.Range)excelWorksheet.get_Range(saleperson, saleperson);
                        salepersonCell.Value2 = m_SalePerson;

                        //Previous Balance
                        string prevBal = "E11";
                        string prevBal2 = "F11";
                        Excel.Range prevBalCell = (Excel.Range)excelWorksheet.get_Range(prevBal, prevBal2);
                        prevBalCell.Value2 = m_PreviousBalance.ToString();

                        string TotalDue = "G11";
                        Excel.Range TotalDueCell = (Excel.Range)excelWorksheet.get_Range(TotalDue, TotalDue);
                        m_InvoiceTotal = m_TotalDue;
                        if (m_PreviousBalance >= m_InvoiceTotal)
                        {
                            m_TotalDue = m_PreviousBalance - m_InvoiceTotal;
                        }
                        else
                        {
                            m_TotalDue = 0;
                        }
                        TotalDueCell.Value2 = m_TotalDue.ToString();

                        string terms1 = "A11";
                        string terms2 = "B11";
                        Excel.Range TermsCell = (Excel.Range)excelWorksheet.get_Range(terms1, terms2);
                        TermsCell.Value2 = m_PaymentsTerms.ToString();
                    }
                    //string ShipName = "E6";
                    //string ShipName2 = "F6";
                    //Excel.Range ShipNameCell = (Excel.Range)excelWorksheet.get_Range(ShipName, ShipName2);
                    //ShipNameCell.Value2 = m_CompanyName;

                    //string ShipAdd = "E7";
                    //string ShipAdd2 = "F7";
                    //Excel.Range ShipAddCell = (Excel.Range)excelWorksheet.get_Range(ShipAdd, ShipAdd2);
                    //ShipAddCell.Value2 = m_ShippingStreet;

                    //string ShipCityState = "E8";
                    //string ShipCityState2 = "F8";
                    //Excel.Range ShipCityStateCell = (Excel.Range)excelWorksheet.get_Range(ShipCityState, ShipCityState2);
                    //ShipCityStateCell.Value2 = m_ShippingCity + " " + m_ShippingState + " " + m_ShippingZip;

                    string DelDate = "C11";
                    Excel.Range DelDateCell = (Excel.Range)excelWorksheet.get_Range(DelDate, DelDate);
                    DelDateCell.Value2 = m_DeliveryDate.ToShortDateString();
                }
                
                                

                

                
            

            

        }
        private void PrintPurchaseInvoice(System.Data.DataTable dt)
        {
        }
        private void PrintShippingList(System.Data.DataTable dt)
        {
            try
            {
                int PageSize = 25;
                int TotalPages = dt.Rows.Count / 25;
                int remainder = dt.Rows.Count % 25;
                if (remainder > 0)
                    TotalPages++;
                //FillInvoiceHeader(TotalPages);                
                int iStart = 11;
                int pos = 0;
                int row = 0;
                m_TotalDiscount = 0;
                for (int page = 0; page < TotalPages; page++)
                {
                    if (page > 0)
                        iStart = 46;
                    OpenTemplate();
                    FillInvoiceHeader(page + 1, TotalPages);
                    for (int index = 0; index < PageSize; index++)
                    {
                        if (row >= dt.Rows.Count)
                            break;
                        pos = iStart + index;
                        FillCellsWithData(dt, pos, row);
                        row++;

                    }
                   // excelWorkbook.SaveCopyAs("F:\\list" + page + ".xls");

                    if (page == 0)
                        excelWorksheet.PrintOut(1, 1, m_Copies, false, "", false, false, "");
                    else
                        excelWorksheet.PrintOut(2, 2, m_Copies, false, "", false, false, "");

                    excelWorkbook.Close(false, m_TemplatePath, true);
                }

            }
            catch (Exception ex)
            {
                excelWorkbook.Close(false, m_TemplatePath, true);
                throw (ex);
            }
            
            
        }
        private void OpenTemplate()
        {
            try
            {
                InvoiceTemplate = new Excel.ApplicationClass();
                InvoiceTemplate.Visible = false;
                //string workbookPath = m_TemplatePath;
                excelWorkbook = InvoiceTemplate.Workbooks.Open(m_TemplatePath,
                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);

                InvoiceSheets = InvoiceTemplate.Worksheets;
                string currentSheet = "Page1";
                if (m_iInvoiceType == (int)InvoiceType.ShippingList)
                    currentSheet = "Page2";
                excelWorksheet = (Excel.Worksheet)InvoiceSheets.get_Item(currentSheet);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }
        public string ShippingStreet
        {
            get { return m_ShippingStreet; }
            set { m_ShippingStreet = value; }
        }
        public string ShippingCity
        {
            get { return m_ShippingCity; }
            set { m_ShippingCity = value; }
        }
        public string ShippingState
        {
            get { return m_ShippingState; }
            set { m_ShippingState = value; }
        }
        public string ShippingZip
        {
            get { return m_ShippingZip; }
            set { m_ShippingZip = value; }
        }

        public string BillingStreet
        {
            get { return m_BillingStreet; }
            set { m_BillingStreet = value; }
        }
        public string BillingCity
        {
            get { return m_BillingCity; }
            set { m_BillingCity = value; }
        }
        public string BillingState
        {
            get { return m_BillingState; }
            set { m_BillingState = value; }
        }
        public string BillingZip
        {
            get { return m_BillingZip; }
            set { m_BillingZip = value; }
        }
        public string InvoiceNumber
        {
            get { return m_InvoiceNumber; }
            set { m_InvoiceNumber = value; }
        }
        public DateTime InvoiceDate
        {
            get { return m_InvoiceDate; }
            set { m_InvoiceDate = value; }
        }
        public int CusotmerID
        {
            get { return m_CustomerID; }
            set { m_CustomerID = value; }
        }
        public string PaymentTerms
        {
            get { return m_PaymentsTerms; }
            set { m_PaymentsTerms = value; }
        }
        public DateTime DeliveryDate
        {
            get { return m_DeliveryDate; }
            set { m_DeliveryDate = value; }
        }
        public decimal PreviousBalance
        {
            get { return m_PreviousBalance; }
            set { m_PreviousBalance = value; }
        }
        public decimal TotalDue
        {
            get { return m_TotalDue; }
            set { m_TotalDue = value; }
        }
        public decimal InvoiceTotal
        {
            get { return m_InvoiceTotal; }
            set { m_InvoiceTotal = value; }
        }
        public decimal TotalDiscount
        {
            get { return m_TotalDiscount; }
            set { m_TotalDiscount = value; }
        }
        public DateTime DueDate
        {
            get { return m_DueDate; }
            set { m_DueDate = value; }
        }
        public int PrintCopies
        {
            set { m_Copies = value; }
        }
        public string SalePerson
        {
            set { m_SalePerson = value; }
            get { return m_SalePerson; }
        }
        public string Comments
        {
            set { m_Comments = value; }
            get { return m_Comments; }

        }
       
    }
}
