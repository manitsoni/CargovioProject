using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cardbanao.Models;
namespace Cardbanao.Helpers
{
    public class DropDownBinding
    {
        
        CardbanaoEntities2 db = new CardbanaoEntities2();
        #region Country
        public class CountryList
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }
        public List<CountryList> AllCountry()
        {
            var list = db.tblCountries.Select(m => new { m.CountryId, m.CountryName }).ToList();

            List<CountryList> lst = new List<CountryList>();

            foreach (var item in list)
            {
                lst.Add(new CountryList { CountryId = item.CountryId, CountryName = item.CountryName });
            }

            return lst;
        }
        public List<CountryList> GetCountryById(int id)
        {
            var list = db.tblCountries.Where(m => m.CountryId == id).Select(m => new { m.CountryId, m.CountryName }).ToList();

            List<CountryList> lst = new List<CountryList>();

            foreach (var item in list)
            {
                lst.Add(new CountryList { CountryId = item.CountryId, CountryName = item.CountryName });
            }

            return lst;
        }
        #endregion
        #region State
        public class StateList
        {
            public int StateId { get; set; }
            public string StateName { get; set; }
        }
        public List<StateList> AllStateList()
        {
            var list = db.tblStates.Select(m => new { m.StateId, m.StateName }).ToList();

            List<StateList> lst = new List<StateList>();

            foreach (var item in list)
            {
                lst.Add(new StateList { StateId = item.StateId, StateName = item.StateName });
            }

            return lst;
        }
        public List<StateList> GetStateyById(int id)
        {
            var list = db.tblStates.Where(m => m.CountryId == id).Select(m => new { m.StateId, m.StateName }).ToList();

            List<StateList> lst = new List<StateList>();

            foreach (var item in list)
            {
                lst.Add(new StateList { StateId = item.StateId, StateName = item.StateName });
            }

            return lst;
        }
        #endregion
        #region City
        public class CityList
        {
            public int CityId { get; set; }
            public string CityName { get; set; }
        }
        public List<CityList> AllCity()
        {
            var list = db.tblCities.Select(m => new { m.CityId, m.CityName }).ToList();

            List<CityList> lst = new List<CityList>();

            foreach (var item in list)
            {
                lst.Add(new CityList { CityId = item.CityId, CityName = item.CityName });
            }

            return lst;
        }
        public List<CityList> GetCityById(int id)
        {
            var list = db.tblCities.Where(m => m.StateId == id).Select(m => new { m.CityId, m.CityName }).ToList();

            List<CityList> lst = new List<CityList>();

            foreach (var item in list)
            {
                lst.Add(new CityList { CityId = item.CityId, CityName = item.CityName });
            }

            return lst;
        }
        #endregion

        #region ProductQuality
        public class QualityList
        {
            public int ProductQualityId { get; set; }
            public string ProductQuality { get; set; }
        }
        public List<QualityList> AllQuality()
        {
            var list = db.tblProductqualities.Where(m=>m.IsActive == true).Select(m => new { m.ProductQualityID, m.ProductQuality }).ToList();

            List<QualityList> lst = new List<QualityList>();

            foreach (var item in list)
            {
                lst.Add(new QualityList { ProductQualityId = item.ProductQualityID, ProductQuality = item.ProductQuality });
            }

            return lst;
        }
        public List<QualityList> GetQualityById(int id)
        {
            var list = db.tblProductqualities.Where(m => m.ProductQualityID == id && m.IsActive == true).Select(m => new { m.ProductQualityID, m.ProductQuality }).ToList();

            List<QualityList> lst = new List<QualityList>();

            foreach (var item in list)
            {
                lst.Add(new QualityList { ProductQualityId = item.ProductQualityID, ProductQuality = item.ProductQuality });
            }

            return lst;
        }
        #endregion
        #region ProductCategory
      
        public class CategoryList
        {
            public int ProductCategoryId { get; set; }
            public string ProductCategory { get; set; }
        }
        public List<CategoryList> AllCategoryList()
        {
           
            var list = db.tblProductcategories.Where(v=>v.IsActive == true).Select(m => new { m.ProductCategoryID, m.ProductCategory }).ToList();

            List<CategoryList> lst = new List<CategoryList>();

            foreach (var item in list)
            {
                lst.Add(new CategoryList { ProductCategoryId = item.ProductCategoryID,  ProductCategory = item.ProductCategory });
            }

            return lst;
        }
        public List<CategoryList> GetCategoryById(int id)
        {
            var list = db.tblProductcategories.Where(m => m.ProductQualityID == id && m.IsActive == true).Select(m => new { m.ProductCategoryID, m.ProductCategory }).ToList();

            List<CategoryList> lst = new List<CategoryList>();

            foreach (var item in list)
            {
                lst.Add(new CategoryList { ProductCategoryId = item.ProductCategoryID, ProductCategory = item.ProductCategory });
            }

            return lst;
        }
       
        #endregion
    }
}