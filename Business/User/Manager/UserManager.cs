using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using Business.User.Manager.Interface;
using BusinessEntities.CommonEntities;
using Data.Model;
using Data.CommonEntities.Repository;
using Data.CommonEntities.Repository.Interface;
namespace Business.User.Manager
{
    public class UserManager : IUserManager
    {

        private IUserRepository userRepository;
        
        public UserManager(IUserRepository user)
        {
            userRepository = user;
        }

        public bool AddLatLong(string Lat, string Long, string City)
        {
            return userRepository.AddLatLong(Lat, Long, City);
        }

        public bool CompanyDetails(CompanyDetailsEntities objCompany)
        {
            try
            {
              
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyDetailsEntities, CompanyDetail>());
                IMapper mapper = config.CreateMapper();
                bool IsAvailable = userRepository.CheckCompany(objCompany.UserId, objCompany.CompanyName);
                if (IsAvailable == false)
                {
                    CompanyDetail company = mapper.Map<CompanyDetailsEntities, CompanyDetail>(objCompany);
                    return userRepository.AddCompanyDetails(company);
                }
                else
                {
                    return false; ;
                }
            }
            catch (DataMisalignedException ex)
            {

                throw;
            }
         
        }

        public IQueryable<UserRegistration> getMyInfo(int Userid)
        {
            return userRepository.getMyInfo(Userid);
        }

        public int Login(string Email, string Password)
        {
            int UserId = userRepository.CheckLogin(Email, Password);
            return UserId;
        }

        public bool LogOut(int UserId)
        {
            throw new NotImplementedException();
        }

        public int OfficeDetails(OfficeDetailsEntities objOffice)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OfficeDetailsEntities, Office>());
            IMapper mapper = config.CreateMapper();
            bool IsAvailable = userRepository.CheckOffice(objOffice.UserId, objOffice.OfficeLocation);
            if (IsAvailable == false)
            {
                Office office = mapper.Map<OfficeDetailsEntities, Office>(objOffice);
                office.BranchLocation = objOffice.OfficeLocation;
                int OfficeId = userRepository.AddOfficeDetails(office);
                return OfficeId;
            }
            else
            {
                return 0;
            }
        }

        public int UserRegistration(UserRegistrationEntities objUser)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegistrationEntities, UserRegistration>());
            IMapper mapper = config.CreateMapper();
            bool IsAvailable = userRepository.CheckUser(objUser.Email,objUser.Password);
            if (IsAvailable == false)
            {
                UserRegistration user = mapper.Map<UserRegistrationEntities, UserRegistration>(objUser);
                int id = userRepository.AddNewUser(user);
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
