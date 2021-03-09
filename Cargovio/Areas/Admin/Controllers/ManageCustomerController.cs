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
        public ManageCustomerController(IManageCustomerByAdminManager mg)
        {
            cManager = mg;
        }
        [HttpGet]
        [Route("Admin/Api/GetCustomer")]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                var data = cManager.getCustomer();
                return Ok(cManager.getCustomer());
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
