using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.Customer;
using BusinessEntities.CommonEntities;
namespace Data.CustomerAdmin.Repoitory.Interface
{
    public interface ICustomerRepository
    {
        IList<CommonCustomerEntities> GetAllCustomer(int Officeid);

        IList<CommonBookingEntities> GetMyShipments(int OfficeId);

        IQueryable<CargoStatusType> GetCargoStatus();
        IQueryable<Office> GetAllOffice();

        IList<CommonBookingEntities> GetOldShipments(int OfficeId);
        IList<CommonBookingEntities> GetDeliveredShipments(int OfficeId);

        bool UpdateTracking(int Statusid, int BookingId, int OfficeId, int Userid);
        bool DeliveredTracking(int Statusid, int BookingId, int OfficeId, int Userid);
        IList<GetQuotationEntities> GetQuotation(int OfficeId);
    }
}
