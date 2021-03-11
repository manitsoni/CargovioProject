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
namespace Business.CustomerAdmin.Manager
{
    public class CustomerAdminManager : ICustomerAdminManager
    {
        ICustomerRepository customer;
        public CustomerAdminManager(ICustomerRepository cust)
        {
            customer = cust;
        }

        public IList<CargoStatus> GetCargoStatus()
        {
            var config = new Mapp
        }

        public IList<CommonBookingEntities> GetMyShipments(int OfficeId)
        {
            return customer.GetMyShipments(OfficeId).ToList();
        }

        public IList<OfficeList> GetOffice()
        {
            throw new NotImplementedException();
        }
    }
}
