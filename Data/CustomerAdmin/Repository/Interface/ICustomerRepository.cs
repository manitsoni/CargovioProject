using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.CustomerAdmin.Repoitory.Interface
{
    interface ICustomerRepository
    {
        IQueryable<UserRegistration> GetAllCustomer(int Officeid);
    }
}
