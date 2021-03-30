using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Data.Customer.Repository.Interface;
using Common;
using BusinessEntities.Customer;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
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
                            Lenght = pe.Lenght,
                            Amount = qe.Amount,
                            PackageDetailsId = pe.Id,
                            PackageId = pe.Id,
                            Packagename = pe.Packagename,
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

        public int GetQuotationRate(string latitude1, string longitude1, string latitude2, string longitude2)
        {
            

            double lat1 = Convert.ToDouble(latitude1);
            double long1 = Convert.ToDouble(longitude1);
            double lat2 = Convert.ToDouble(latitude2);
            double long2 = Convert.ToDouble(longitude2);
            double Km = distance(lat1, lat2, long1, long2);
            double rate = Km * 25;
            double value = rate;
            int factor = 100;
            int nearestMultiple = (int)Math.Round((value / (double)factor), MidpointRounding.AwayFromZero) * factor;
            return nearestMultiple;

        }
        static double toRadians(double angleIn10thofaDegree)
        {
            return (angleIn10thofaDegree *
                        Math.PI) / 180;
        }
        static double distance(double lat1, double lat2, double lon1, double lon2)
        {
            lon1 = toRadians(lon1);
            lon2 = toRadians(lon2);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }
    }
}
