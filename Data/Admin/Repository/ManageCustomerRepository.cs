using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
using Data.Admin.Repository.Interface;
using Data.Model;
using BusinessEntities.CommonEntities;
namespace Data.Admin.Repository
{
    public class ManageCustomerRepository : IManageCustomerRepositoryByAdmin

    {
        CargovioDbEntities db = new CargovioDbEntities();
        public IList<CommonCustomerEntities> getCostomers()
        {
            var Data = (from ur in db.UserRegistrations
                        join cd in db.CompanyDetails on ur.Id equals cd.UserId
                        where ur.IsVerify == false
                        
                        select new CommonCustomerEntities
                        {
                            Addressline1 = ur.Addressline1,
                            Addressline2 = ur.Addressline2,
                            City = ur.City,
                            CompanyName = cd.CompanyName,
                            CompanySize = cd.CompanySize,
                            ContactNo = ur.ContactNo,
                            Country = ur.Country,
                            CreatedDate = ur.CreatedDate,
                            C_City = cd.City,
                            C_Country = cd.Country,
                            C_State = cd.State,
                            Email = ur.Email,
                            State = ur.State,
                            Id = ur.Id,
                            IsActive = ur.IsActive,
                            IsVerify= ur.IsVerify,
                          
                            PinCode = ur.PinCode,
                            UpdatedDate = ur.UpdatedDate,
                            Username = ur.Username,
                            UserTypeId = ur.UserTypeId,
                            WebSiteLink = cd.WebSiteLink
                        }).ToList();

            return Data;
        }

        public bool VerifyCustomer(int id)
        {
            UserRegistration ur = db.UserRegistrations.Find(id);
            ur.IsVerify = true;
            ur.UpdatedDate = DateTime.Now;
            return db.SaveChanges() >0;
        }
    }
}
