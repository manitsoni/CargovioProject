using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Customer;
using Business.CustomerAdmin.Manager.Interface;
using Data.Model;
namespace Cargovio.Areas.CustomerAdmin.Controllers
{
    public class CustomerAdminManageController : ApiController
    {
        public ICustomerAdminManager customer;
        public CustomerAdminManageController(ICustomerAdminManager cust)
        {
            customer = cust;
        }
        [HttpGet]
        [Route("CustomerAdmin/Api/GetMyShipments/{Userid}")]
        public IHttpActionResult GetMyShipments(string Userid)
        {
            try
            {
                CargovioDbEntities db = new CargovioDbEntities();
                int id = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == id).FirstOrDefault();
                int OfficeId = Convert.ToInt32(data.OfficeId);
                return Ok(customer.GetMyShipments(OfficeId));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
