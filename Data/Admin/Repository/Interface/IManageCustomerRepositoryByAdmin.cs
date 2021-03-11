using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
namespace Data.Admin.Repository.Interface
{
    public interface IManageCustomerRepositoryByAdmin
    {
        IList<CommonCustomerEntities> getCostomers(int OfficeId);

        bool VerifyCustomer(int id);
    }
}
