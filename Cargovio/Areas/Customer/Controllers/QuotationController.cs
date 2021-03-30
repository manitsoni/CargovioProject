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
using System.IO;
using Newtonsoft.Json.Linq;

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
                qe.Amount = objCommon.Amount;
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

        [HttpGet]
        [Route("Customer/Api/GetQuotationRate")]
        public IHttpActionResult GetQuotationRate(string City1,string City2)
        {
            try
            {
                string latitude1, latitude2, longitude1, longitude2;
                using (var client = new WebClient())
                {
                    string url = "http://api.positionstack.com/v1/forward?access_key=284d4543eb91f4bd81dff5d9d7f52d07&query=" + City1 + " India";
                    Stream stream = client.OpenRead(url);
                    StreamReader reader = new StreamReader(stream);
                    JObject jObject = JObject.Parse(reader.ReadLine());
                    latitude1 = jObject["data"][0]["latitude"].ToString();
                    longitude1 = jObject["data"][0]["longitude"].ToString();


                }
                using (var client = new WebClient())
                {
                    string url = "http://api.positionstack.com/v1/forward?access_key=284d4543eb91f4bd81dff5d9d7f52d07&query=" + City2 + " India";
                    Stream stream = client.OpenRead(url);
                    StreamReader reader = new StreamReader(stream);
                    JObject jObject = JObject.Parse(reader.ReadLine());
                    latitude2 = jObject["data"][0]["latitude"].ToString();
                    longitude2 = jObject["data"][0]["longitude"].ToString();
                }

                return Ok(quotationManager.GetQuotationRate(latitude1,longitude1,latitude2,longitude2));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
