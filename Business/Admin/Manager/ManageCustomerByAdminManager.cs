using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Admin.Repository.Interface;
using BusinessEntities.CommonEntities;
using Business.Admin.Manager.Interface;

namespace Business.Admin.Manager
{
    
    public class ManageCustomerByAdminManager : IManageCustomerByAdminManager
    {
        IManageCustomerRepositoryByAdmin manageCRepository;
        public ManageCustomerByAdminManager(IManageCustomerRepositoryByAdmin cust)
        {
            manageCRepository = cust;
        }
        public IList<CommonCustomerEntities> getCustomer()
        {
            return manageCRepository.getCostomers();
        }

        public bool VerifyCustomer(int id)
        {
            return manageCRepository.VerifyCustomer(id);
        }
    }
}
