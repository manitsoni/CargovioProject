using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class TrackingEntities
    {
        public int Id { get; set; }

        public int? BookingId { get; set; }

        public int? CargoStatusTypeId { get; set; }

        public string CurrentLocation { get; set; }

        public bool? IsDelivered { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsCurrent { get; set; }
        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
