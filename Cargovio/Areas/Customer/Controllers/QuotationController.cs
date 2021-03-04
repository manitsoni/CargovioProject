using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using AutoMapper;
using BusinessEntities.Customer;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;
namespace Cargovio.Areas.Customer.Controllers
{
    public class QuotationController : ApiController
    {
        private IQuotationManager quotationManager;
        //private int PackageId=0;
        public QuotationController(IQuotationManager quotation)
        {
            quotationManager = quotation;
        }
     
        [HttpPost]
        [Route("Customer/Api/BookQuotation")]
        public IHttpActionResult BookQuotation(CommonQuotationEntities objCommon)
        {
            try
            {
                //Add package To DB
                PackageEntities pe = new PackageEntities();
             
                pe.CreatedBy = SessionProxyUser.UserID;
                pe.Height = objCommon.Height;
                pe.IsActive = true;
                pe.Lenght = objCommon.Lenght;
                pe.Packagename = objCommon.Packagename;
                pe.Quantity = objCommon.Quantity;
                pe.UserId = SessionProxyUser.UserID;
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
                qe.CreatedBy = SessionProxyUser.UserID;
                qe.CreatedDate = DateTime.Now;
                qe.PackageDetailsId = PackageId;
                qe.UpdatedBy = SessionProxyUser.UserID;
                qe.UpdatedDate = DateTime.Now;
                qe.UserId = SessionProxyUser.UserID;
                return Ok(quotationManager.AddQuotation(qe));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("Customer/Api/GetQuotation")]
        public IHttpActionResult GetQuotation()
        {
            try
            {
                return Ok(quotationManager.GetQuotation());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
