﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
namespace Business.Customer.Manager.Interface
{
    public interface IBookingManager
    {
        int AddPackage(PackageEntities pe);
        int AddSourceAddress(SourceAddressEntities se);
        int AddDestinationAddress(DestinationAddressEntities de);
        int AddBooking(BookingEntities be);
        int AddTracking(TrackingEntities te);
    }
}
