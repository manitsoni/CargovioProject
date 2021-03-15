using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
using BusinessEntities.CustomerAdmin;
using BusinessEntities.CommonEntities;
namespace Business.CustomerAdmin.Manager.Interface
{
    public interface ICustomerAdminManager
    {
        IList<CommonBookingEntities> GetMyShipments(int OfficeId);
        IList<CargoStatus> GetCargoStatus();
        IList<OfficeList> GetOffice();
        IList<CommonCustomerEntities> GetCustomer(int Officeid);
        IList<CommonBookingEntities> GetOldShipments(int OfficeId);
        IList<CommonBookingEntities> GetDeliveredShipments(int OfficeId);

        bool UpdateTracking(int Statusid, int BookingId, int OfficeId, int Userid);
        bool DeliveredShipment(int Statusid, int BookingId, int OfficeId, int Userid);
        IList<GetQuotationEntities> GetQuotationlist(int OfficeId);
    }
}
