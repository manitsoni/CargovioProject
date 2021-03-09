using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CommonEntities
{
    public class UserRegistrationEntities
    {
        public int Id { get; set; }
        public int? OfficeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public string Addressline1 { get; set; }
        public string AddressLine2 { get; set; }    
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsVerify { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
