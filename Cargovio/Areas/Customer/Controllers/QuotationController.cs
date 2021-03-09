using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using AutoMapper;
using Data.Model;
using BusinessEntities.Customer;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;
namespace Cargovio.Areas.Customer.Controllers
{
    public class QuotationController : ApiController
    {
        private IQuotationManager quotationManager;
        CargovioDbEntities db = new CargovioDbEntities();
        //private int PackageId=0;
        public QuotationController(IQuotationManager quotation)
        {
            quotationManager = quotation;
        }
     
        [HttpPost]
        [Route("Customer/Api/BookQuotation/{Userid}")]
        public IHttpActionResult BookQuotation(CommonQuotationEntities objCommon,string Userid)
        {
            try
            {
                int _userId = Convert.ToInt32(Userid);
                //Add package To DB
                PackageEntities pe = new PackageEntities();
             
                pe.CreatedBy = _userId;
                pe.Height = objCommon.Height;
                pe.IsActive = true;
                pe.Lenght = objCommon.Lenght;
                pe.Packagename = objCommon.Packagename;
                pe.Quantity = objCommon.Quantity;
                pe.UserId = _userId;
                pe.Weight = objCommon.Weight;
                pe.Width = objCommon.Width;
                int PackageId = quotationManager.AddPackage(pe);

                //Add Quotation To DB
                QuotationEntities qe = new QuotationEntities();
                qe.DestinationAddress1 = objCommon.DestinationAddress1;
                qe.DestinationAddress2 = objCommon.DestinationAddress2;
                qe.DestinationCity = objCommon.DestinationCity;
                qe.DestinationState = objCommon.DestinationState;
                qe.DestinationCountry = objCommon.DestinationCountry;
                qe.DestinationPincode = objCommon.DestinationPincode;
                qe.SourceAddress1 = objCommon.SourceAddress1;
                qe.SourceAddress2 = objCommon.SourceAddress2;
                qe.SourceCity = objCommon.SourceCity;
                qe.SourceState = objCommon.SourceState;
                qe.SourceCountry = objCommon.SourceCountry;
                qe.SourcePincode = objCommon.SourcePincode;
                qe.CreateBy = _userId;
                qe.CreatedDate = DateTime.Now;
                qe.PackageDeatilsId = PackageId;
                qe.UpdatedBy = _userId;
                qe.UpdatedDate = DateTime.Now;
                qe.UserId = _userId;
                string City = "Ahmedabad";
                int OfficeId;
                int oid = db.Offices.Where(m => m.City == City).Select(m => m.Id).First();
                int OfficeUserId = db.Offices.Where(m => m.City == City).Select(m => m.UserId).FirstOrDefault();
                if (oid > 0)
                {
                    OfficeId = oid;
                }
                else
                {
                    OfficeId = 3;
                }
                qe.OfficeId = OfficeId;
                qe.IsActive = true;
                return Ok(quotationManager.AddQuotation(qe));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Customer/Api/GetQuotation/{Userid}")]
        public IHttpActionResult GetQuotation(string Userid)
        {
            try
            {
                int id = Convert.ToInt32(Userid);
                var quotation = quotationManager.GetQuotation(id);
                return Ok(quotationManager.GetQuotation(id));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
