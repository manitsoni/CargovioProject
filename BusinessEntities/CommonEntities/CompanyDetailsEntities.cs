using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CommonEntities
{
    public class CompanyDetailsEntities
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string WebSiteLink { get; set; }
        public string Addressline1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public Boolean IsActibe { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
