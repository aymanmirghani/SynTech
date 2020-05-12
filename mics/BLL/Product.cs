
using System;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class Product{
        LogWriter log = new LogWriter();
        

        private System.Int32 _ProductID;
        private System.String _Name;
        private System.String _Description;
        private System.String _ProductNumber;
        private System.Boolean _MakeFlag;
        private System.Boolean _FinishedGoodsFlag;
        private System.String _Color;
        private System.Int16 _SafetyStockLevel;
        private System.Int16 _ReorderPoint;
        private System.Decimal _StandardCost;
        private System.Decimal _ListPrice;
        private System.String _Size;
        private System.String _SizeUnitMeasureCode;
        private System.String _WeightUnitMeasureCode;
        private System.Decimal _Weight;
        private System.Int32 _DaysToManufacture;
        private System.String _ProductLine;
        private System.String _Class;
        private System.String _Style;
        private System.Int32 _ProductSubcategoryID;
        private System.Int32 _ProductModelID;
        private System.DateTime _SellStartDate;
        private System.DateTime _SellEndDate;
        private System.DateTime _DiscontinuedDate;
        private System.DateTime _ModifiedDate;
        private System.Int32 _PrimaryVendorId;
        private System.Int32 _SecondaryVendorId;
        private System.Boolean _ActiveFlag;
        private System.String _Comments;
        private ProductInventory _productInventory;
		public Product(){}
        public Product(
                    System.Int32 productid,
                    System.String name,
                    System.String description,
                    System.String productnumber,
                    System.Boolean makeflag,
                    System.Boolean finishedgoodsflag,
                    System.String color,
                    System.Int16 safetystocklevel,
                    System.Int16 reorderpoint,
                    System.Decimal standardcost,
                    System.Decimal listprice,
                    System.String size,
                    System.String sizeunitmeasurecode,
                    System.String weightunitmeasurecode,
                    System.Decimal weight,
                    System.Int32 daystomanufacture,
                    System.String productline,
                    System.String ProductClass,
                    System.String style,
                    System.Int32 productsubcategoryid,
                    System.Int32 productmodelid,
                    System.DateTime sellstartdate,
                    System.DateTime sellenddate,
                    System.DateTime discontinueddate,
                    System.DateTime modifieddate,
                    System.Int32 primaryvendorid,
                    System.Int32 secondaryvendorid,
                    System.Boolean activeflag,
                    System.String comments)
        {
            this._ProductID = productid;
            this._Name = name;
            this._Description = description;
            this._ProductNumber = productnumber;
            this._MakeFlag = makeflag;
            this._FinishedGoodsFlag = finishedgoodsflag;
            this._Color = color;
            this._SafetyStockLevel = safetystocklevel;
            this._ReorderPoint = reorderpoint;
            this._StandardCost = standardcost;
            this._ListPrice = listprice;
            this._Size = size;
            this._SizeUnitMeasureCode = sizeunitmeasurecode;
            this._WeightUnitMeasureCode = weightunitmeasurecode;
            this._Weight = weight;
            this._DaysToManufacture = daystomanufacture;
            this._ProductLine = productline;
            this._Class = ProductClass;
            this._Style = style;
            this._ProductSubcategoryID = productsubcategoryid;
            this._ProductModelID = productmodelid;
            this._SellStartDate = sellstartdate;
            this._SellEndDate = sellenddate;
            this._DiscontinuedDate = discontinueddate;
            this._ModifiedDate = modifieddate;
            this._PrimaryVendorId = primaryvendorid;
            this._SecondaryVendorId = secondaryvendorid;
            this._ActiveFlag = activeflag;
            this._Comments = comments;
        }
		
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.String Name{
			get{return _Name;}
			set{ _Name=value;}
		}
		public System.String Description{
			get{return _Description;}
			set{ _Description=value;}
		}
		public System.String ProductNumber{
			get{return _ProductNumber;}
			set{ _ProductNumber=value;}
		}
		public System.Boolean MakeFlag{
			get{return _MakeFlag;}
			set{ _MakeFlag=value;}
		}
		public System.Boolean FinishedGoodsFlag{
			get{return _FinishedGoodsFlag;}
			set{ _FinishedGoodsFlag=value;}
		}
		public System.String Color{
			get{return _Color;}
			set{ _Color=value;}
		}
		public System.Int16 SafetyStockLevel{
			get{return _SafetyStockLevel;}
			set{ _SafetyStockLevel=value;}
		}
		public System.Int16 ReorderPoint{
			get{return _ReorderPoint;}
			set{ _ReorderPoint=value;}
		}
		public System.Decimal StandardCost{
			get{return _StandardCost;}
			set{ _StandardCost=value;}
		}
		public System.Decimal ListPrice{
			get{return _ListPrice;}
			set{ _ListPrice=value;}
		}
		public System.String Size{
			get{return _Size;}
			set{ _Size=value;}
		}
		public System.String SizeUnitMeasureCode{
			get{return _SizeUnitMeasureCode;}
			set{ _SizeUnitMeasureCode=value;}
		}
		public System.String WeightUnitMeasureCode{
			get{return _WeightUnitMeasureCode;}
			set{ _WeightUnitMeasureCode=value;}
		}
		public System.Decimal Weight{
			get{return _Weight;}
			set{ _Weight=value;}
		}
		public System.Int32 DaysToManufacture{
			get{return _DaysToManufacture;}
			set{ _DaysToManufacture=value;}
		}
		public System.String ProductLine{
			get{return _ProductLine;}
			set{ _ProductLine=value;}
		}
		public System.String Class{
			get{return _Class;}
			set{ _Class=value;}
		}
		public System.String Style{
			get{return _Style;}
			set{ _Style=value;}
		}
		public System.Int32 ProductSubcategoryID{
			get{return _ProductSubcategoryID;}
			set{ _ProductSubcategoryID=value;}
		}
		public System.Int32 ProductModelID{
			get{return _ProductModelID;}
			set{ _ProductModelID=value;}
		}
		public System.DateTime SellStartDate{
			get{return _SellStartDate;}
			set{ _SellStartDate=value;}
		}
		public System.DateTime SellEndDate{
			get{return _SellEndDate;}
			set{ _SellEndDate=value;}
		}
		public System.DateTime DiscontinuedDate{
			get{return _DiscontinuedDate;}
			set{ _DiscontinuedDate=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
        public System.Int32 PrimaryVendorId{
            get{return _PrimaryVendorId;}
            set { _PrimaryVendorId = value; }
        }
        public System.Int32 SecondaryVendorId{
            get{return _SecondaryVendorId;}
            set{_SecondaryVendorId=value;}
        }
        public System.Boolean ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }
        public System.String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        public ProductInventory ProductInventory
        {
            get { return _productInventory; }
            set { _productInventory = value; }
        }
		public int AddProduct(Product product)
        {
            productData data = new productData();
            int productID = 0;
            try
            {
                productID = data.AddProduct(product);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return productID;
        }
		public bool RemoveProduct(Product product)
        {
            productData data = new productData();
            bool ret = false;
            try
            {
                ret = data.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;

        }
        public bool RemoveProduct(int productID)
        {
            productData data = new productData();
            bool ret = false;
            try
            {
                ret = data.DeleteProduct(productID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;

        }
		public bool UpdateProduct(Product product)
        {
            productData data = new productData();
            bool ret = false;
            try
            {
                ret = data.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public int Exists(string name,string description)
        {
            productData data = new productData();
            try
            {
                return data.Exists(name,description);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exists");
                throw (ex);
            }
            finally
            {
                data = null;
            }
        }
		public Product GetProduct(int productid)
        {
            productData data = new productData();
            Product product = new Product();
            if (data == null)
                data = new productData();
            try
            {
                product = data.GetProduct(productid);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return product;
        }
        public DataSet GetAllProductsDataSet()
        {
            productData data = new productData();
            DataSet ds = new DataSet();
            try
            {
                //ds = data.GetAllProductsDataSet();
                ds = data.GetProductsWithVendorsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProducts");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCollection GetAllProductsCollection()
        {
            productData data = new productData();
            ProductCollection col = new ProductCollection();
            try
            {
                col = data.GetAllProductsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllProductsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetProductsDataSet(string whereExpression, string orderByExpression)
        {
            productData data = new productData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetProductDynamicDataSet(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public ProductCollection GetProductsCollection(string whereExpression, string orderByExpression)
        {
            productData data = new productData();
            ProductCollection col = new ProductCollection();
            try
            {
                col = data.GetProductDynamicCollection(whereExpression, orderByExpression);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetProductsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public bool Exsists(string productName)
        {
            ProductCollection col = new ProductCollection();
            string where = "[name]='" + productName + "'";
            try
            {
                col = GetProductsCollection(where, String.Empty);
                if (col.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "Exsists");
                throw (ex);
            }
            finally
            {
                col = null;
            }
        }
	}
}
