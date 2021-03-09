using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.Customer;
using Common;
namespace Data.Customer.Repository.Interface
{
    public interface IQuotationRepository
    {
        int BookPackage(tblPackageDetail objPackage);
        bool BookQuotation(tblQuotation objQuotation);
        
        IList<GetQuotationEntities> GetQuotation(int id);
    }
}
