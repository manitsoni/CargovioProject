using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Business.CustomerAdmin.Manager.Interface;
using BusinessEntities.Customer;
using Data.CustomerAdmin.Repoitory.Interface;
namespace Business.CustomerAdmin.Manager
{
    public class CustomerAdminManager : ICustomerAdminManager
    {
        ICustomerRepository customer;
        public CustomerAdminManager(ICustomerRepository cust)
        {
            customer = cust;
        }
        public IList<CommonBookingEntities> GetMyShipments(int OfficeId)
        {
            return customer.GetMyShipments(OfficeId).ToList();
        }
    }
}
