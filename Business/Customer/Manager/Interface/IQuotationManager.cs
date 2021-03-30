using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
namespace Business.Customer.Manager.Interface
{
    public interface IQuotationManager
    {
        int AddPackage(PackageEntities pe);
        bool AddQuotation(QuotationEntities qe);
        IList<GetQuotationEntities> GetQuotation(int id);
        int GetQuotationRate(string latitude1, string longitude1,string latitude2,string longitude2);
    }
}
