using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MICS.Reports.PurchasedProductsTableAdapters
{
    public partial class YTDSalesByTerritoryTableAdapter : System.ComponentModel.Component 
    {
        public int SetTimeOut
        {
            set { this.CommandCollection[0].CommandTimeout = value; }
        }
        public SqlCommand[] SelectCommand
        {
            get
            {
                if (this._commandCollection == null)
                    this.InitCommandCollection();
                return this._commandCollection;
            }
            set
            {
                this._commandCollection = value;
            }
        }
        public int FillByWhere(PurchasedProducts.YTDSalesByTerritoryDataTable dataTable, string where,string groupBy)
        {
            try
            {
                this._commandCollection[0].CommandText = @"select convert(char(10),soh.OrderDate,110)as OrderDate ,sum(sod.lineTotal)GroupByTotal,sum(sod.OrderQty)as TotalQuantity,sum(unitpricediscount) as Discount";
                if (groupBy.Length > 0)
                    this._commandCollection[0].CommandText += "," + groupBy + " as GroupByItem";
                else
                    this._commandCollection[0].CommandText += ",'1' as GroupByItem";
                this._commandCollection[0].CommandText+= @" from salesorderheader soh
                                                        join salesorderdetail sod on soh.salesorderid=sod.salesorderid";
                if(where.Contains("territoryid") || groupBy.Contains("ter.name"))
                    this._commandCollection[0].CommandText+= @" join customer cus on cus.customerid=soh.customerid
                                                        join salesterritory ter on ter.territoryid=cus.territoryid";
                if(where.Contains("productcategoryid") || groupBy.Contains("cat.name"))
                this._commandCollection[0].CommandText+= @" join product prd on prd.productid=sod.productid
                                                        join productsubcategory sub on sub.productsubcategoryid=prd.productsubcategoryid
                                                        join productcategory cat on cat.productcategoryid=sub.productcategoryid";
                                                        
                if (where.Length > 0)
                {
                   this._commandCollection[0].CommandText += " where soh.status not in (1,6) and " + where;
                }
                this._commandCollection[0].CommandText += " group by convert(char(10),soh.OrderDate,110)";
                if (groupBy.Length > 0)
                    this._commandCollection[0].CommandText += "," + groupBy;
                
                this._commandCollection[0].CommandTimeout = 240;
                return this.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }
        }
    }

    public partial class SalesDetailsTableAdapter : System.ComponentModel.Component
    {
        public int SetTimeOut
        {
            set
            {
                if (this._commandCollection == null)
                    this.InitCommandCollection();
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    this.CommandCollection[0].CommandTimeout = value;
                }
            }
        }
        public int FillByWhere(PurchasedProducts.SalesDetailDataTable dataTable, string where)
        {
            try 
	        {
                if (this._commandCollection == null)
                    this.InitCommandCollection();
		        this._commandCollection[0].CommandText = @"select sih.invoicenumber,cus.name as CustomerName,soh.OrderDate as InvoiceDate,
                                                    prd.Description as  ProductName,sod.OrderQty as Quantity,sod.UnitPrice,
                                                    sum(sod.unitpricediscount) as Discount,
                                                    sum(sod.linetotal)as LineTotal
                                                    from SalesOrderHeader soh
                                                    join salesorderdetail sod on sod.salesorderid=soh.salesorderid
                                                    join product prd on prd.productid=sod.productid
                                                    join Customer cus on cus.customerid=soh.customerid
                                                    join salesterritory ter on cus.territoryid=ter.territoryid
                                                    join salesinvoiceheader sih on soh.salesorderid=sih.saleorderid
                                                    join productsubcategory sub on sub.productsubcategoryid=prd.productsubcategoryid
                                                    join productcategory cat on cat.productcategoryid=sub.productcategoryid";
                this._commandCollection[0].CommandText += " where soh.status not in(1,6) and " + where;
                //where soh.OrderDate>='07/01/2008' and soh.orderdate <='07/31/2008'
                this._commandCollection[0].CommandText += @" group by sih.invoicenumber,cus.name,soh.OrderDate,prd.description,sod.OrderQty,sod.UnitPrice
                                                         order by cus.name desc";
                this._commandCollection[0].CommandTimeout = 120;
                return(this.Fill(dataTable));
	        }
	        catch (Exception ex)
	        {
		        throw(ex);
	        }
        }
    }

    public partial class OverDueInvoicesTableAdapter : System.ComponentModel.Component
    {
        public int FillByWhere(PurchasedProducts.OverDueInvoicesDataTable dataTable, string where)
        {
            if (this._commandCollection == null)
            {
                this.InitCommandCollection();
            }
            this._commandCollection[0].CommandText = @"select cus.name as CustomerName,ter.name as TerrName,iv.invoicenumber,iv.invoicedate,invoicetotal,totalpayments,balance
                                                    from invoicesbalance_view iv
                                                    join customer cus on iv.customerid=cus.customerid
                                                    join salesterritory ter on cus.territoryid=ter.territoryid
                                                    where balance > 0 and invoicedate <= dateadd(Day,-30,getdate())";
            if(where.Length > 0)
                this._commandCollection[0].CommandText += where;

            this._commandCollection[0].CommandText +=" order by cus.name";
            this._commandCollection[0].CommandTimeout = 120;
            return (this.Fill(dataTable));

        }
    }

    public partial class ProductListTableAdapter : System.ComponentModel.Component
    {
        public int FillByWhere(PurchasedProducts.ProductListDataTable dataTable, string where)
        {
            if (this._commandCollection == null)
            {
                this.InitCommandCollection();
            }
            this._commandCollection[0].CommandText = @"select p.* 
                                                        from product p 
                                                        join productsubcategory sub on sub.productsubcategoryid=p.productsubcategoryid 
                                                        join productcategory cat on cat.productcategoryid=sub.productcategoryid 
                                                        where activeflag=1 and description not like 'ZZ%'";
            if(where.Length > 0)
                this._commandCollection[0].CommandText += " and " + where;

            this._commandCollection[0].CommandText += " order by description";
            this._commandCollection[0].CommandTimeout = 120;
            return (this.Fill(dataTable));
        }
    }

        


}
