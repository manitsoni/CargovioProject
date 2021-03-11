using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
namespace Business.CustomerAdmin.Manager.Interface
{
    public interface ICustomerAdminManager
    {
        IList<CommonBookingEntities> GetMyShipments(int OfficeId);
    }
}
