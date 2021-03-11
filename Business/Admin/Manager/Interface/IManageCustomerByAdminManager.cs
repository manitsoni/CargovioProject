using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CommonEntities;
namespace Business.Admin.Manager.Interface
{
    public interface IManageCustomerByAdminManager
    {
        IList<CommonCustomerEntities> getCustomer(int OfficeId);
        bool VerifyCustomer(int id);
    }
}
