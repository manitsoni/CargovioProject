using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
   public  class DestinationAddressEntities
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public int? UserId { get; set; }
        public string DestinationAddress1 { get; set; }
        public string DestinationAddress2 { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationPincode { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCountry { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
