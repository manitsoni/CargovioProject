using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Admin.Repository.Interface;
using BusinessEntities.CommonEntities;
using Business.Admin.Manager.Interface;
using BusinessEntities.Customer;
using BusinessEntities.Admin;
using AutoMapper;
using Data.Model;
namespace Business.Admin.Manager
{
    
    public class ManageCustomerByAdminManager : IManageCustomerByAdminManager
    {
        IManageCustomerRepositoryByAdmin manageCRepository;
        public ManageCustomerByAdminManager(IManageCustomerRepositoryByAdmin cust)
        {
            manageCRepository = cust;
        }
        public IList<CommonCustomerEntities> getCustomer(int OfficeId)
        {
            return manageCRepository.getCostomers(OfficeId);
        }

        public IList<CommonCustomerEntities> getCustomerAdmins()
        {
            return manageCRepository.getCustomerAdmin().ToList();
        }

        public IList<CommonCustomerEntities> getAllCustomers()
        {
            return manageCRepository.getCustomer().ToList();
        }

        public bool VerifyCustomer(int id)
        {
            return manageCRepository.VerifyCustomer(id);
        }

        public IList<CommonBookingEntities> getBookings()
        {
            return manageCRepository.getBookings();
        }

        public IList<CommonBookingEntities> getBookingDetails(string ShipmentId)
        {
            return manageCRepository.getBookingDetails(ShipmentId);
        }

        public IList<GetQuotationEntities> getQuotations()
        {
            return manageCRepository.getQuotations().ToList();
        }

        public IList<CommonBookingEntities> getDeliveredShipments()
        {
            return manageCRepository.getDeliveredShipments();
        }
        public bool AddRates(RatesModel rates)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<RatesModel, RateData>());
            IMapper mapper = config.CreateMapper();
            RateData rate = mapper.Map<RatesModel, RateData>(rates);
            return manageCRepository.AddRates(rate);
        }

        public bool DeleteRates(int id)
        {
            return manageCRepository.DeleteRate(id);
        }

   

        public IList<RatesModel> GetRates()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RateData, RatesModel>());
            IMapper mapper = config.CreateMapper();
            var rates = manageCRepository.GetRate().ToList();
            List<RatesModel> ratesEntities = rates.Select(x => mapper.Map<RateData, RatesModel>(x)).ToList();
            return ratesEntities;
        }
    }
}
