using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.CustomerAdmin.Repoitory.Interface;
using Common;
using BusinessEntities.Customer;
namespace Data.CustomerAdmin.Repoitory
{
    public class CustomerRepository : ICustomerRepository
    {
        public IQueryable<UserRegistration> GetAllCustomer(int Officeid)
        {
            throw new NotImplementedException();
        }
    }
}
