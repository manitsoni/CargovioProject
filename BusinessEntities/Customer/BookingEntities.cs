﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class BookingEntities
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public int? PackageId { get; set; }
        public int? Amount { get; set; }
        public string PaymentType { get; set; }
        public int? TransactionId { get; set; }
        public int? OfficeId { get; set; }
        public int? ShipmentId { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}