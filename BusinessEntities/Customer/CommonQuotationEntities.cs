using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class CommonQuotationEntities
    {
       
        public string SourceAddress1 { get; set; }
        public string SourceAddress2 { get; set; }
        public string SourceCity { get; set; }
        public string SourcePincode { get; set; }
        public string SourceState { get; set; }
        public string SourceCountry { get; set; }
        public string DestinationAddress1 { get; set; }
        public string DestinationAddress2 { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationPincode { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCountry { get; set; }
        public int? PackageDetailsId { get; set; }
        public string Packagename { get; set; }
        public int? Quantity { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Lenght { get; set; }
        public int? Weight { get; set; }
    
    }
}
