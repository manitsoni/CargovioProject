using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CommonEntities
{
    public class OfficeDetailsEntities
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OfficeLocation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
