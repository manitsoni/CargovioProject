using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class CommonBookingEntities
    {

        public int ID { get; set; }
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
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }

        public string DestinationCustomerName { get; set; }
        public string DestinationEmailId { get; set; }
        public string DestinationPhone { get; set; }
        public string DestinationCompanyName { get; set; }
       
        public string DestinationAddress1 { get; set; }
        public string DestinationAddress2 { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationPincode { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationDocumentName { get; set; }
        public string DestinationDocumentNumber { get; set; }

        
        public string Packagename { get; set; }
        public int? PUserId { get; set; }
        public int? Quantity { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Lenght { get; set; }
        public int? Weight { get; set; }
        public int? PackageCreatedBy { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

        public string UpdatedDate { get; set; }

        public string CreatedDate { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentType { get; set; }
        
        //Optional
        public string ShipmentId { get; set; }
        public string CargoStatus { get; set; }
        public string CargoLocation { get; set; }

        public bool? isActive { get; set; }
        public bool? isDelivered { get; set; }
        public bool? isPickup { get; set; }
    }
}
