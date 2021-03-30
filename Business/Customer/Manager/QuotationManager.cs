using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Data.Model;
using Data.Customer.Repository;
using Data.Customer.Repository.Interface;
using Business.Customer.Manager.Interface;
using BusinessEntities.Customer;

namespace Business.Customer.Manager
{
    public class QuotationManager : IQuotationManager
    {
        public IQuotationRepository quotationRepository;
        public QuotationManager(IQuotationRepository quotation)
        {
            quotationRepository = quotation;
        }
      
        public int AddPackage(PackageEntities pe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageEntities, tblPackageDetail>());
            IMapper mapper = config.CreateMapper();
            tblPackageDetail package = mapper.Map<PackageEntities, tblPackageDetail>(pe);
            int PackageId = quotationRepository.BookPackage(package);
            return PackageId;
            //if (UserLogin.IsUserLogin())
            //{
                
            //}
            //else
            //{
            //    return 0;
            //}

        }

        public bool AddQuotation(QuotationEntities qe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuotationEntities, tblQuotation>());
            IMapper mapper = config.CreateMapper();
            tblQuotation quot = mapper.Map<QuotationEntities, tblQuotation>(qe);
            return quotationRepository.BookQuotation(quot); 
            //if (UserLogin.IsUserLogin())
            //{
            //}
            //else
            //{
            //    return false;
            //}
        }

        public IList<GetQuotationEntities> GetQuotation(int id)
        {
            return quotationRepository.GetQuotation(id).ToList();
        }

        public int GetQuotationRate(string latitude1, string longitude1, string latitude2, string longitude2)
        {
            return quotationRepository.GetQuotationRate(latitude1, longitude1, latitude2, longitude2);
        }
    }
}
