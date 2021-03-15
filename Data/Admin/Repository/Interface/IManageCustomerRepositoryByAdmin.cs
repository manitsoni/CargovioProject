using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
using BusinessEntities.Customer;
using Data.Model;
namespace Data.Admin.Repository.Interface
{
    public interface IManageCustomerRepositoryByAdmin
    {
        IList<CommonCustomerEntities> getCostomers(int OfficeId);
        IList<CommonCustomerEntities> getCustomerAdmin();

        IList<CommonCustomerEntities> getCustomer();
        bool VerifyCustomer(int id);
        IList<CommonBookingEntities> getBookings();
        IList<CommonBookingEntities> getBookingDetails(string ShipmentId);

        IList<GetQuotationEntities> getQuotations();

        IList<CommonBookingEntities> getDeliveredShipments();
        bool AddRates(RateData rate);
        IQueryable<RateData> GetRate();
        bool DeleteRate(int id);

        IQueryable<RateData> GetRateById(int id);

    }
}
