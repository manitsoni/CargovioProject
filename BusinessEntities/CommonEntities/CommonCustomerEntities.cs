using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CommonEntities
{
    public class CommonCustomerEntities
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public int UserTypeId { get; set; }

        public int? OfficeId { get; set; }
        public string OfficeLocation { get; set; }

        public string Addressline1 { get; set; }

        public string Addressline2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool? IsVerify { get; set; }
        public string CompanyName { get; set; }

        public string WebSiteLink { get; set; }

        public int? CompanySize { get; set; }

        public string C_City { get; set; }

        public string C_State { get; set; }
        public string C_Country { get; set; }

    }
}
