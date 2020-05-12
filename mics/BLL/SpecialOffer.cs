using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MICS.DAL;
using MICS.Utilities;
namespace MICS.BLL
{
	public class SpecialOffer{
        private LogWriter log = new LogWriter();

		public SpecialOffer(){}
        public SpecialOffer(
                    System.Int32 specialofferid,
                    System.String description,
                    System.Decimal discountpct,
                    System.String type,
                    System.String category,
                    System.DateTime startdate,
                    System.DateTime enddate,
                    System.Int32 minqty,
                    System.Int32 maxqty,
                    System.DateTime modifieddate)
        {
            this._SpecialOfferID = specialofferid;
            this._Description = description;
            this._DiscountPct = discountpct;
            this._Type = type;
            this._Category = category;
            this._StartDate = startdate;
            this._EndDate = enddate;
            this._MinQty = minqty;
            this._MaxQty = maxqty;
            this._ModifiedDate = modifieddate;
        }
			private System.Int32 _SpecialOfferID;
			private System.String _Description;
			private System.Decimal _DiscountPct;
			private System.String _Type;
			private System.String _Category;
			private System.DateTime _StartDate;
			private System.DateTime _EndDate;
			private System.Int32 _MinQty;
			private System.Int32 _MaxQty;
			private System.DateTime _ModifiedDate;
		public System.Int32 SpecialOfferID{
			get{return _SpecialOfferID;}
			set{ _SpecialOfferID=value;}
		}
		public System.String Description{
			get{return _Description;}
			set{ _Description=value;}
		}
		public System.Decimal DiscountPct{
			get{return _DiscountPct;}
			set{ _DiscountPct=value;}
		}
		public System.String Type{
			get{return _Type;}
			set{ _Type=value;}
		}
		public System.String Category{
			get{return _Category;}
			set{ _Category=value;}
		}
		public System.DateTime StartDate{
			get{return _StartDate;}
			set{ _StartDate=value;}
		}
		public System.DateTime EndDate{
			get{return _EndDate;}
			set{ _EndDate=value;}
		}
		public System.Int32 MinQty{
			get{return _MinQty;}
			set{ _MinQty=value;}
		}
		public System.Int32 MaxQty{
			get{return _MaxQty;}
			set{ _MaxQty=value;}
		}
		public System.DateTime ModifiedDate{
			get{return _ModifiedDate;}
			set{ _ModifiedDate=value;}
		}
		public int AddSpecialOffer(SpecialOffer specialoffer)
        {
            SpecialOfferData data = new SpecialOfferData();
            int id = 0;
            try
            {
                id = data.AddSpecialOffer(specialoffer);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "AddSpecialOffer");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return id;
        }
		public bool RemoveSpecialOffer(SpecialOffer specialoffer)
        {
            SpecialOfferData data = new SpecialOfferData();
            bool ret = false;
            try
            {
                ret = data.DeleteSpecialOffer(specialoffer);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSpecialOffer");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
        public bool RemoveSpecialOffer(int specialofferID)
        {
            SpecialOfferData data = new SpecialOfferData();
            bool ret = false;
            try
            {
                ret = data.DeleteSpecialOffer(specialofferID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "RemoveSpecialOffer");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public bool UpdateSpecialOffer(SpecialOffer specialoffer)
        {
            SpecialOfferData data = new SpecialOfferData();
            bool ret = false;
            try
            {
                ret = data.UpdateSpecialOffer(specialoffer);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "UpdateSpecialOffer");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ret;
        }
		public SpecialOffer GetSpecialOffers(int specialOfferID)
        {
            SpecialOfferData data = new SpecialOfferData();
            SpecialOffer so = new SpecialOffer();
            try
            {
                so = data.GetSpecialOffer(specialOfferID);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOffers");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return so;
        }
        public DataSet GetAllSpecialOffersDataSet()
        {
            SpecialOfferData data = new SpecialOfferData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSpecialOffersDataSet();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SpecialOfferCollection GetAllSpecialOffersCollection()
        {
            SpecialOfferData data = new SpecialOfferData();
            SpecialOfferCollection col = new SpecialOfferCollection();
            try
            {
                col = data.GetAllSpecialOffersCollection();
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetAllSpecialOffersCollection");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return col;
        }
        public DataSet GetSpecialOffersDataSet(string where, string orderBy)
        {
            SpecialOfferData data = new SpecialOfferData();
            DataSet ds = new DataSet();
            try
            {
                ds = data.GetAllSpecialOffersDynamicDataSet(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOffersDataSet");
                throw (ex);
            }
            finally
            {
                data = null;
            }
            return ds;
        }
        public SpecialOfferCollection GetSpecialOffersCollection(string where, string orderBy)
        {
            SpecialOfferData data = new SpecialOfferData();
            SpecialOfferCollection col = new SpecialOfferCollection();
            try
            {
                col = data.GetAllSpecialOffersDynamicCollection(where, orderBy);
            }
            catch (Exception ex)
            {
                log.Write(ex.Message, "GetSpecialOffersCollection");
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
