using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.CommonEntities.Repository.Interface;
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

        public int AddNewUser(UserRegistration objUser)
        {
            db.UserRegistrations.Add(objUser);
            db.SaveChanges();
           
            return (objUser.Id);
        }

        public bool AddOfficeDetails(Office objOffice)
        {
            db.Offices.Add(objOffice);
            return db.SaveChanges() > 0;
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
            var UserList = db.UserRegistrations.ToList();
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
                if (item.UserId == Userid && item.BranchLocation == OfficeLocation)
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

        public IQueryable<UserRegistration> GetUser(int id)
        {
            return db.UserRegistrations.Where(m => m.Id == id);
        }
    }
}
