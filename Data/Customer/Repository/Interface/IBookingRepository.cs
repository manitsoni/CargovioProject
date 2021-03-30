﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using BusinessEntities.Customer;
namespace Data.Customer.Repository.Interface
{
    public interface IBookingRepository
    {
        int AddSourceAddress(tblSource objSAddress);
        int AddDestinationAddress(tblDestination objDAddress);
        int AddPackage(tblPackageDetail objPackage);
        int AddBooking(tblBooking objBooking);
        int AddTracking(Tracking objTracking);
        IList<CommonBookingEntities> GetBooking(int id);
        IList<CommonBookingEntities> GetOldBooking(int id);
        IList<CommonBookingEntities> GetBookingDetails(string ShipmentId,int Userid);
        tblPackageDetail GetPackageById(int packageId);
        bool UpdatePackage(tblPackageDetail pd);
        IQueryable<Office> GetMyOffice(int Userid);
        double getRate(string City1, string City2);
    }
}
