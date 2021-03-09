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

        public int? CompanySize { get; set; }

        public string CopmanyAddress1 { get; set; }

        public string CopmanyAddress2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
