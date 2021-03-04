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
        private int PackageId=0;
        public QuotationController(IQuotationManager quotation)
        {
            quotationManager = quotation;
        }
        [HttpPost]
        [Route("Customer/Api/BookPackage")]
        public IHttpActionResult BookPackage(PackageEntities objPackage)
        {
            try
            {
                PackageId = quotationManager.AddPackage(objPackage);
                return Ok(PackageId);
            }
            catch (Exception)
            {
                return NotFound();   
            }
        }
        [HttpPost]
        [Route("Customer/Api/BookQuotation")]
        public IHttpActionResult BookQuotation(QuotationEntities objQuotation)
        {
            try
            {
                return Ok(quotationManager.AddQuotation(objQuotation));
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
