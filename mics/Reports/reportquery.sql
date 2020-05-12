select ter.name TerritoryName,cus.name CustomerName,prd.name Product,cat.name ProductCategory,sub.name SubCategory,
sum(LineTotal) total,sum(Quantity) quantity, sum(UnitPriceDiscount) Discount
from salesinvoicedetail sid
join product prd on sid.productid=prd.productid
join productsubcategory sub on prd.productsubcategoryid=sub.productsubcategoryid
join productcategory cat on sub.productcategoryid=cat.productcategoryid
join salesinvoiceheader sih on sid.invoiceid=sih.invoiceid
join customer cus on sih.accountnumber=cus.customerid
join salesterritory ter on cus.territoryid=ter.territoryid
group by prd.name,cat.name,sub.name,cus.name,ter.name
