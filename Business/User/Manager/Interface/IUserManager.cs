using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
namespace Business.User.Manager.Interface
{
    public interface IUserManager
    {
        int UserRegistration(UserRegistrationEntities objUser);
        int Login(string Email, string Password);
        bool CompanyDetails(CompanyDetailsEntities objCompany);
        bool OfficeDetails(OfficeDetailsEntities objOffice);
        bool LogOut(int UserId);
        IList<UserRegistrationEntities> BindToSession(int id);
       
    }
}
