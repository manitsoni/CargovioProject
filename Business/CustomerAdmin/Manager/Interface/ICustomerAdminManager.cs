using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
using BusinessEntities.CustomerAdmin;
namespace Business.CustomerAdmin.Manager.Interface
{
    public interface ICustomerAdminManager
    {
        IList<CommonBookingEntities> GetMyShipments(int OfficeId);
        IList<CargoStatus> GetCargoStatus();
        IList<OfficeList> GetOffice();
    }
}
