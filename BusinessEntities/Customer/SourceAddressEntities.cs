using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class SourceAddressEntities
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public int? UserId { get; set; }
        public string SourceAddress1 { get; set; }
        public string SourceAddress2 { get; set; }
        public string SourceCity { get; set; }
        public string SourcePincode { get; set; }
        public string SourceState { get; set; }
        public string SourceCountry { get; set; }
    }
}
