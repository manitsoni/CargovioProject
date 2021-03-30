using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.CommonEntities;
namespace Business.User.Manager.Interface
{
    public interface IUserManager
    {
        int UserRegistration(UserRegistrationEntities objUser);
        int Login(string Email, string Password);
        bool CompanyDetails(CompanyDetailsEntities objCompany);
        int OfficeDetails(OfficeDetailsEntities objOffice);
        bool LogOut(int UserId);
        IQueryable<UserRegistration> getMyInfo(int Userid);
        bool AddLatLong(string Lat, string Long, string City);
        //IList<UserRegistrationEntities> BindToSession(int id);

    }
}
