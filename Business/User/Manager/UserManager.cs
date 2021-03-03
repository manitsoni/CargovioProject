using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
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

        public IList<UserRegistrationEntities> BindToSession(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegistration, UserRegistrationEntities>());
            IMapper mapper = config.CreateMapper();
            var User = userRepository.GetUser(id).ToList();
            List<UserRegistrationEntities> _User = User.Select(x => mapper.Map<UserRegistration, UserRegistrationEntities>(x)).ToList();
            foreach (var item in _User)
            {
                SessionProxyUser.IsUserLogin = true;
                SessionProxyUser.UserID = item.Id;
                SessionProxyUser.UserEmail = item.Email;
                SessionProxyUser.Name = item.UserName;
                SessionProxyUser.Address1 = item.Addressline1;
                SessionProxyUser.Address2 = item.AddressLine2;
                SessionProxyUser.City = item.City;
                SessionProxyUser.State = item.State;
                SessionProxyUser.Country = item.Country;
                SessionProxyUser.Pincode = item.Pincode.ToString();
                SessionProxyUser.Phone = item.ContactNo;
                break;
            }
            return _User;
        }

        public bool CompanyDetails(CompanyDetailsEntities objCompany)
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

        public int Login(string Email, string Password)
        {
            int UserId = userRepository.CheckLogin(Email, Password);
            return UserId;
        }

        public bool LogOut(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool OfficeDetails(OfficeDetailsEntities objOffice)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegistrationEntities, UserRegistration>());
            IMapper mapper = config.CreateMapper();
            bool IsAvailable = userRepository.CheckOffice(objOffice.UserId, objOffice.OfficeLocation);
            if (IsAvailable == false)
            {
                Office office = mapper.Map<OfficeDetailsEntities, Office>(objOffice);
                return userRepository.AddOfficeDetails(office);
            }
            else
            {
                return false;
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
