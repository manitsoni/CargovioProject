using System.Web.Http;
using Unity;
using Unity.WebApi;
using Business.RepositoryHelper;
using Business.User.Manager;
using Business.User.Manager.Interface;
using Business.Customer.Manager;
using Business.Customer.Manager.Interface;
namespace Cargovio
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserManager,UserManager>();
            container.RegisterType<IQuotationManager, QuotationManager>();
            //container.RegisterType<IBookingManager, BookingManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}