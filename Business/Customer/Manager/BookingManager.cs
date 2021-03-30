using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Data.Model;
using Data.Customer.Repository;
using Data.Customer.Repository.Interface;
using Business.Customer.Manager.Interface;
using BusinessEntities.Customer;
using BusinessEntities.CustomerAdmin;

namespace Business.Customer.Manager
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository bookingRepository;
       
        public BookingManager(IBookingRepository booking)
        {
            bookingRepository = booking;
        }
        public int AddBooking(BookingEntities be)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingEntities, tblBooking>());
            IMapper mapper = config.CreateMapper();
           
                tblBooking ba = mapper.Map<BookingEntities, tblBooking>(be);
                int BookingId = bookingRepository.AddBooking(ba);
                return BookingId;
          
        }

        public int AddDestinationAddress(DestinationAddressEntities de)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DestinationAddressEntities, tblDestination>());
            IMapper mapper = config.CreateMapper();
         
                tblDestination da = mapper.Map<DestinationAddressEntities, tblDestination>(de);
                int DestinationId = bookingRepository.AddDestinationAddress(da);
                return DestinationId;
            
        }

        public int AddPackage(PackageEntities pe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageEntities, tblPackageDetail>());
            IMapper mapper = config.CreateMapper();
          
                tblPackageDetail pa = mapper.Map<PackageEntities, tblPackageDetail>(pe);
                int PackageId = bookingRepository.AddPackage(pa);
                return PackageId;
           
        }

        public int AddSourceAddress(SourceAddressEntities se)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SourceAddressEntities, tblSource>());
            IMapper mapper = config.CreateMapper();
            tblSource sa = mapper.Map<SourceAddressEntities, tblSource>(se);
                int SourceId = bookingRepository.AddSourceAddress(sa);
                return SourceId;
            
        }

        public int AddTracking(TrackingEntities te)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TrackingEntities, Tracking>());
            IMapper mapper = config.CreateMapper();
            
                Tracking ta = mapper.Map<TrackingEntities, Tracking>(te);
                int TrackingId = bookingRepository.AddTracking(ta);
                return TrackingId;
            
        }

        public IList<CommonBookingEntities> GetBooking(int id)
        {
            return bookingRepository.GetBooking(id);
        }

        public IList<CommonBookingEntities> GetBookingDetails(string ShipmentId,int Userid)
        {
            return bookingRepository.GetBookingDetails(ShipmentId,Userid);
        }

        public double getRate(string City1, string City2)
        {
            return bookingRepository.getRate(City1, City2);
        }

        public IList<OfficeList> GetMyoffice(int Userid)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Office, OfficeList>());
            IMapper mapper = config.CreateMapper();
            var office = bookingRepository.GetMyOffice(Userid).ToList();
            List<OfficeList> officelist = office.Select(x => mapper.Map<Office, OfficeList>(x)).ToList();
            return officelist;
        }

        public IList<CommonBookingEntities> GetOldBooking(int id)
        {
            return bookingRepository.GetOldBooking(id);
        }

        public PackageEntities GetPackageById(int packageId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblPackageDetail, PackageEntities>());
            IMapper mapper = config.CreateMapper();
            tblPackageDetail package = bookingRepository.GetPackageById(packageId);
            //tblPackageDetail pd = new tblPackageDetail();
            PackageEntities packagedata = new PackageEntities();
            packagedata.CreatedBy = package.CreatedBy;
            packagedata.Height = package.Height;
            packagedata.Id = package.Id;
            packagedata.IsActive = package.IsActive;
            packagedata.Lenght = package.Lenght;
            packagedata.Packagename = package.Packagename;
            packagedata.Quantity = package.Quantity;
            packagedata.UserId = package.UserId;
            packagedata.Weight = package.Weight;
            packagedata.Width = package.Width;
           
            return packagedata;
        }

        public bool UpdatePackage(PackageEntities pe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageEntities, tblPackageDetail>());
            IMapper mapper = config.CreateMapper();
            tblPackageDetail package = mapper.Map<PackageEntities,tblPackageDetail>(pe);
            return bookingRepository.UpdatePackage(package);
        }
    }
}
