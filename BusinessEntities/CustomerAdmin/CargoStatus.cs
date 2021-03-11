using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CustomerAdmin
{
    public class CargoStatus
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public bool? IsActive { get; set; }

    }

}
