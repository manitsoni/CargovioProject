using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
using BusinessEntities.Customer;
using BusinessEntities.Admin;
namespace Business.Admin.Manager.Interface
{
    public interface IManageCustomerByAdminManager
    {
        IList<CommonCustomerEntities> getCustomer(int OfficeId);
        bool VerifyCustomer(int id);

        IList<CommonCustomerEntities> getAllCustomers();
        IList<CommonCustomerEntities> getCustomerAdmins();
        IList<CommonBookingEntities> getBookings();
        IList<CommonBookingEntities> getBookingDetails(string ShipmentId);
        IList<GetQuotationEntities> getQuotations();
        IList<CommonBookingEntities> getDeliveredShipments();
        bool AddRates(RatesModel rates);
        IList<RatesModel> GetRates();
        bool DeleteRates(int id);
        
    }
}
