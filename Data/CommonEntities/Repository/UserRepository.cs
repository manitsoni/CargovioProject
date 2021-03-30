using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.CommonEntities.Repository.Interface;
using BusinessEntities.CommonEntities;
using System.IO;

namespace Data.CommonEntities.Repository
{
    public class UserRepository : IUserRepository
    {
        CargovioDbEntities db = new CargovioDbEntities();
        public bool AddCompanyDetails(CompanyDetail objCompanyDetails)
        {
            db.CompanyDetails.Add(objCompanyDetails);
            return db.SaveChanges() > 0;
        }

        public bool AddLatLong(string Lat, string Long, string City)
        {
            tblLatLong LatiLong = new tblLatLong();
            LatiLong.LatAddress = Lat;
            LatiLong.LongAddress = Long;
            LatiLong.CityName = City;
            LatiLong.IsActive = true;
            db.tblLatLongs.Add(LatiLong);
            return db.SaveChanges() > 0;
        }

        public int AddNewUser(UserRegistration objUser)
        {
            db.UserRegistrations.Add(objUser);
            db.SaveChanges();
           
            return (objUser.Id);
        }

        public int AddOfficeDetails(Office objOffice)
        {
            try
            {
                

                db.Offices.Add(objOffice);
                db.SaveChanges();
                return (objOffice.Id);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public bool CheckCompany(int id, string CompanyName)
        {
            var CompanyList = db.CompanyDetails.ToList();
            bool IsCompanyAvailable = false;
            foreach (var item in CompanyList)
            {
                if (item.UserId == id && item.CompanyName == CompanyName)
                {
                    IsCompanyAvailable = true;
                    break;
                }
            }
            return IsCompanyAvailable;
        }

        public int CheckLogin(string Email, string password)
        {
            var UserList = db.UserRegistrations.Where(m => m.IsActive == true && m.IsVerify == true).ToList();
            int getUserid = 0;
            foreach (var item in UserList)
            {
                if (item.Email == Email && item.Password == password)
                {
                    getUserid = item.Id;
                    break;
                }
            }
            return getUserid;
        }

        public bool CheckOffice(int Userid, string OfficeLocation)
        {
            var OfficeList = db.Offices.ToList();
            bool IsOfficeAvailable = false;
            foreach (var item in OfficeList)
            {
                if (item.BranchLocation == OfficeLocation)
                {
                    IsOfficeAvailable = true;
                    break;
                }
            }
            return IsOfficeAvailable;
        }

        public bool CheckUser(string Email, string password)
        {
            var UserList = db.UserRegistrations.ToList();
            bool IsAvailable = false;
            foreach (var item in UserList)
            {
                if (item.Email == Email && item.Password == password)
                {
                    IsAvailable = true;
                    break;
                }
            }
            return IsAvailable;
        }

        public IQueryable<UserRegistration> getMyInfo(int Userid)
        {
            try
            {
                var Data = db.UserRegistrations.Where(m => m.Id == Userid);

                return Data;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public int GetOfficeId(int Userid)
        {
            int id = db.Offices.Where(m => m.UserId == Userid).Select(m => m.Id).First();
            return id;
        }

        public IQueryable<UserRegistration> GetUser(int id)
        {
            return db.UserRegistrations.Where(m => m.Id == id);
        }
    }
}
