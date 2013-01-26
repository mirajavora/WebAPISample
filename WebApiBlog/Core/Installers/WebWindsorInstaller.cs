using System.Web.Http;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebApiBlog.Core.Api;

namespace WebApiBlog.Core.Installers
{
    public class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes
                .FromAssembly(typeof(ContainerApplication).Assembly)
                .BasedOn<IRestApiController>()
                .LifestyleScoped());
        }
    }
}