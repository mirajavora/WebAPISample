using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Core.Installers
{
    public class DataAccessInstaller : IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IContactRepository>().ImplementedBy<ContactRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IAccessTokenRepository>().ImplementedBy<AccessTokenRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifeStyle.Singleton);
        }
    }
}