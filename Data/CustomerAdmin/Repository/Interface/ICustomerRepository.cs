using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.Customer;
namespace Data.CustomerAdmin.Repoitory.Interface
{
    public interface ICustomerRepository
    {
        IQueryable<UserRegistration> GetAllCustomer(int Officeid);

        IList<CommonBookingEntities> GetMyShipments(int OfficeId);

        IList<CargoStatusType> GetCargoStatus();
        IList<Office> GetAllOffice();
    }
}
