using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.CommonEntities.Repository.Interface
{
    public interface IUserRepository
    {
        int AddNewUser(UserRegistration objUser);

        int CheckLogin(string Email, string password);

        bool AddCompanyDetails(CompanyDetail objCompanyDetails);

        int AddOfficeDetails(Office objOffice);

        bool CheckUser(string Email, string password);
        bool CheckCompany(int id, string CompanyName);
        bool CheckOffice(int Userid, string OfficeLocation);
        IQueryable<UserRegistration> GetUser(int id);
        int GetOfficeId(int Userid);
    }
}
