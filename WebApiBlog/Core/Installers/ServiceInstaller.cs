using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebApiBlog.Core.Services;

namespace WebApiBlog.Core.Installers
{
    public class ServiceInstaller : IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuthenticationService>().ImplementedBy<AuthenticationService>());
        }
    }
}