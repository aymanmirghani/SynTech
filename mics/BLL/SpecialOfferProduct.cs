using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SpecialOfferProduct{
        private LogWriter log = new LogWriter();

        private System.Int32 _SpecialOfferID;
        private System.Int32 _ProductID;
        private System.DateTime _ModifiedDate;

        public SpecialOfferProduct() { }
        public SpecialOfferProduct(
                    System.Int32 specialofferid,
                    System.Int32 productid,
                    System.DateTime modifieddate)
        {
            this._SpecialOfferID = specialofferid;
            this._ProductID = productid;
            this._ModifiedDate = modifieddate;
        }
		
		public System.Int32 SpecialOfferID{
			get{return _SpecialOfferID;}
			set{ _SpecialOfferID=value;}
		}
		public System.Int32 ProductID{
			get{return _ProductID;}
			set{ _ProductID=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public bool AddSpecialOfferProduct(SpecialOfferProduct specialofferproduct)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            bool ret = false;
            if (data == null)
                data = new SpecialOfferProductData();
            try
            {
                ret = data.AddSpecialOfferProduct(specialofferproduct);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool RemoveSpecialOfferProduct(SpecialOfferProduct specialofferproduct)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            bool ret=false;
            try
            {
                ret = data.DeleteSpecialOfferProduct(specialofferproduct);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSpecialOfferProduct(int specialofferproductID)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            bool ret = false;
            try
            {
                ret = data.DeleteSpecialOfferProduct(specialofferproductID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSpecialOfferProduct(SpecialOfferProduct specialofferproduct)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            bool ret = false;
            try
            {
                ret = data.UpdateSpecialOfferProduct(specialofferproduct);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSpecialOfferProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SpecialOfferProduct GetSpecialOfferProducts(int specialOfferProductID)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            SpecialOfferProduct sop = new SpecialOfferProduct();
            try
            {
                sop = data.GetSpecialOfferProduct(specialOfferProductID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOfferProducts");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return sop;
        }
        public DataSet GetAllSpecialOfferProductsDataSet()
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSpecialOfferProductsDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SpecialOfferProductCollection GetAllSpecialOfferProductCollection()
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            SpecialOfferProductCollection col = new SpecialOfferProductCollection();
            try
            {
                col = data.GetAllSpecialOfferProductsCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOfferProductCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSpecialOfferProductsDataSet(string where, string orderBy)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSpecialOfferProductsDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOfferProductsDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SpecialOfferProductCollection GetSpecialOfferProductsCollection(string where, string orderBy)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            SpecialOfferProductCollection col = new SpecialOfferProductCollection();
            try
            {
                col = data.GetAllSpecialOfferProductsDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOfferProductsCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetDiscountByProduct(int productid, int quantity)
        {
            SpecialOfferProductData data = new SpecialOfferProductData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetDiscountByProduct(productid, quantity);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetDiscountByProduct");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }

	}
}
