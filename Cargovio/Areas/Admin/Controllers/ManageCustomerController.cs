using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.CommonEntities;
using Data.Model;
using Business.Admin.Manager.Interface;
namespace Cargovio.Areas.Admin.Controllers
{
    public class ManageCustomerController : ApiController
    {
        IManageCustomerByAdminManager cManager;
        CargovioDbEntities db = new CargovioDbEntities();
        public ManageCustomerController(IManageCustomerByAdminManager mg)
        {
            cManager = mg;
        }
        [HttpGet]
        [Route("Admin/Api/GetCustomer/{Userid}")]
        public IHttpActionResult GetCustomers(string Userid)
        {
            try
            {
                int id = Convert.ToInt32(Userid);
                var data = db.UserRegistrations.Where(m => m.Id == id).FirstOrDefault();
                int OfficeId = Convert.ToInt32(data.OfficeId);
                return Ok(cManager.getCustomer(OfficeId));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("Admin/Api/VerifyCustomer/{Userid}")]
        public IHttpActionResult VerifyCustomer(string Userid)
        {
            try
            {
                
                return Ok(cManager.VerifyCustomer(Convert.ToInt32(Userid)));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
