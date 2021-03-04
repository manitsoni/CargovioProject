using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Customer
{
    public class PackageEntities
    {
        public int Id { get; set; }
        public string Packagename { get; set; }
        public int? UserId { get; set; }
        public int? Quantity { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Lenght { get; set; }
        public int? Weight { get; set; }
        public int? CreatedBy { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

    }
}
