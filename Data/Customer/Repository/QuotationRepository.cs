using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Customer.Repository.Interface;
using Common;
using BusinessEntities.Customer;
namespace Data.Customer.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        CargovioDbEntities db = new CargovioDbEntities();

        public int BookPackage(tblPackageDetail objPackage)
        {
            db.tblPackageDetails.Add(objPackage);
            db.SaveChanges();
            return (objPackage.Id);
        }

        public bool BookQuotation(tblQuotation objQuotation)
        {
            db.tblQuotations.Add(objQuotation);
            return db.SaveChanges() > 0;
        }

        public IList<GetQuotationEntities> GetQuotation(int id)
        {
            var Data = (from qe in db.tblQuotations
                        join pe in db.tblPackageDetails on qe.PackageDeatilsId equals pe.Id
                        join ur in db.UserRegistrations on qe.UserId equals ur.Id
                        where ur.Id == id && qe.PackageDeatilsId == pe.Id
                        select new GetQuotationEntities
                        {
                            CreatedBy = qe.CreateBy,
                            CreatedDate = (qe.CreatedDate).ToString(),
                            DestinationAddress1 = qe.DestinationAddress1,
                            DestinationAddress2 = qe.DestinationAddress2,
                            DestinationCity = qe.DestinationCity,
                            DestinationCountry = qe.DestinationCountry,
                            DestinationPincode = qe.DestinationPincode,
                            DestinationState = qe.DestinationState,
                            Height = pe.Height,
                            IsActive = qe.IsActive,
                            Length = pe.Length,
                            PackageDetailsId = pe.Id,
                            PackageId = pe.Id,
                            Packagename = pe.PackageType,
                            Quantity = pe.Quantity,
                            QuotationId = qe.Id,
                            SourceAddress1 = qe.SourceAddress1,
                            SourceAddress2 = qe.SourceAddress2,
                            SourceCity = qe.SourceCity,
                            SourceCountry = qe.SourceCountry,
                            SourcePincode = qe.SourcePincode,
                            SourceState = qe.SourceState,
                            UpdatedBy = qe.UpdatedBy,
                            UpdatedDate =qe.UpdatedDate.ToString(), 
                            UserId = qe.UserId,
                            Weight =pe.Weight,
                            Width = pe.Width
                        }).ToList();
            return Data;
        }
    }
}
