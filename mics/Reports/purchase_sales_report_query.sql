select sum(TotalDue)TotalSale,sum(quantity) as Quantity,(LTrim(Str(Month(InvoiceDate))) + '/' + Ltrim(Str(Year(InvoiceDate)))) as Period,(cat.Name) as Item
from salesinvoiceheader sih
join salesInvoiceDetail sid on sih.InvoiceId=sid.Invoiceid
join product prd on sid.productid = sid.productid
join productsubcategory sub on prd.productsubcategoryid=sub.productsubcategoryid
join productcategory cat on sub.productcategoryid=cat.productcategoryid
where status not in (3,6)
group by (LTrim(Str(Month(InvoiceDate)))+ '/' + Ltrim(Str(Year(InvoiceDate)))),cat.Name
order by cat.name