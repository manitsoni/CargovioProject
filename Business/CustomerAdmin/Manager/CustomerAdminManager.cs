using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Business.CustomerAdmin.Manager.Interface;
using BusinessEntities.Customer;
using Data.CustomerAdmin.Repoitory.Interface;
using BusinessEntities.CustomerAdmin;
using AutoMapper;
using BusinessEntities.CommonEntities;

namespace Business.CustomerAdmin.Manager
{
    public class CustomerAdminManager : ICustomerAdminManager
    {
        ICustomerRepository customer;
        public CustomerAdminManager(ICustomerRepository cust)
        {
            customer = cust;
        }

        public bool DeliveredShipment(int Statusid, int BookingId, int OfficeId, int Userid)
        {
            return customer.DeliveredTracking(Statusid, BookingId, OfficeId, Userid);
        }

        public IList<CargoStatus> GetCargoStatus()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoStatusType, CargoStatus>());
            IMapper mapper = config.CreateMapper();
            var cargo = customer.GetCargoStatus().ToList();
            List<CargoStatus> status = cargo.Select(x => mapper.Map<CargoStatusType, CargoStatus>(x)).ToList();
            return status;
        }

        public IList<CommonCustomerEntities> GetCustomer(int Officeid)
        {
            return customer.GetAllCustomer(Officeid).ToList();
        }

        public IList<CommonBookingEntities> GetDeliveredShipments(int OfficeId)
        {
            return customer.GetDeliveredShipments(OfficeId).ToList();
        }

        public IList<CommonBookingEntities> GetMyShipments(int OfficeId)
        {
            return customer.GetMyShipments(OfficeId).ToList();
        }

        public IList<OfficeList> GetOffice()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Office, OfficeList>());
            IMapper mapper = config.CreateMapper();
            var office = customer.GetAllOffice().ToList();
            List<OfficeList> officelist = office.Select(x => mapper.Map<Office, OfficeList>(x)).ToList();
            return officelist;
        }

        public IList<CommonBookingEntities> GetOldShipments(int OfficeId)
        {
            return customer.GetOldShipments(OfficeId).ToList();
        }

        public IList<GetQuotationEntities> GetQuotationlist(int OfficeId)
        {
            return customer.GetQuotation(OfficeId).ToList();
        }

        public bool UpdateTracking(int Statusid, int BookingId, int OfficeId, int Userid)
        {
            return customer.UpdateTracking(Statusid, BookingId, OfficeId, Userid);
        }
    }
}
