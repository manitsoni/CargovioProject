using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using Data.CommonEntities.Repository;
using Data.CommonEntities.Repository.Interface;
using Data.Customer.Repository;
using Data.Customer.Repository.Interface;
using Data.Admin.Repository;
using Data.Admin.Repository.Interface;
namespace Business.RepositoryHelper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IQuotationRepository, QuotationRepository>();
            Container.RegisterType<IBookingRepository, BookingRepository>();
            Container.RegisterType<IManageCustomerRepositoryByAdmin, ManageCustomerRepository>();
        }
    }
}
