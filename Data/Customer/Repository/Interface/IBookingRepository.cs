﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.Customer.Repository.Interface
{
    public interface IBookingRepository
    {
        int AddSourceAddress(tblSource objSAddress);
        int AddDestinationAddress(tblDestination objDAddress);
        int AddPackage(tblPackageDetail objPackage);
        int AddBooking(tblBooking objBooking);
        int AddTracking(Tracking objTracking);
    }
}