using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using Data.CommonEntities.Repository;
using Data.CommonEntities.Repository.Interface;

namespace Business.RepositoryHelper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
