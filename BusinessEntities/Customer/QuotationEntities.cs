using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class QuotationEntities
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string SourceAddress1 { get; set; }
        public string SourceAddress2 { get; set; }
        public string SourceCity { get; set; }
        public string SourcePincode { get; set; }
        public string SourceState { get; set; }
        public string SourceCountry { get; set; }
        public int? OfficeId { get; set; }
        public string DestinationAddress1 { get; set; }
        public string  DestinationAddress2 { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationPincode { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCountry { get; set; }
        public int? PackageDeatilsId { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
