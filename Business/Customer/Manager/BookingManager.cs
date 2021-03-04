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
namespace Business.Customer.Manager
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository bookingRepository;
        IsLogin UserLogin = new IsLogin();
        public BookingManager(IBookingRepository booking)
        {
            bookingRepository = booking;
        }
        public int AddBooking(BookingEntities be)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingEntities, tblBooking>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblBooking ba = mapper.Map<BookingEntities, tblBooking>(be);
                int BookingId = bookingRepository.AddSourceAddress(ba);
                return BookingId;
            }
            else
            {
                return 0;
            }
        }

        public int AddDestinationAddress(DestinationAddressEntities de)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DestinationAddressEntities, tblDestination>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblDestination da = mapper.Map<DestinationAddressEntities, tblDestination>(de);
                int DestinationId = bookingRepository.AddDestinationAddress(da);
                return DestinationId;
            }
            else
            {
                return 0;
            }
        }

        public int AddPackage(PackageEntities pe)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageEntities, tblPackageDetail>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblPackageDetail pa = mapper.Map<PackageEntities, tblPackageDetail>(pe);
                int PackageId = bookingRepository.AddPackage(pa);
                return PackageId;
            }
            else
            {
                return 0;
            }
        }

        public int AddSourceAddress(SourceAddressEntities se)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SourceAddressEntities, tblSource>());
            IMapper mapper = config.CreateMapper();
            if (UserLogin.IsUserLogin())
            {
                tblSource sa = mapper.Map<SourceAddressEntities, tblSource>(se);
                int SourceId = bookingRepository.AddSourceAddress(sa);
                return SourceId;
            }
            else
            {
                return 0;
            }
        }
    }
}
