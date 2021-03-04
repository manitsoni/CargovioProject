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
        IsLogin UserLogin = new IsLogin();
        public int AddPackage(PackageEntities pe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageEntities, tblPackageDetail>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblPackageDetail package = mapper.Map<PackageEntities, tblPackageDetail>(pe);
                int PackageId = quotationRepository.BookPackage(package);
                return PackageId;
            }
            else
            {
                return 0;
            }

        }

        public bool AddQuotation(QuotationEntities qe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuotationEntities, tblQuotation>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblQuotation quot = mapper.Map<QuotationEntities, tblQuotation>(qe);
                return quotationRepository.BookQuotation(quot); ;
            }
            else
            {
                return false;
            }
        }

        public IList<GetQuotationEntities> GetQuotation()
        {
            return quotationRepository.GetQuotation().ToList();
        }
    }
}
