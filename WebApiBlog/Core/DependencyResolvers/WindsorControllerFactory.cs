using System.Web.Mvc;
using Castle.Windsor;

namespace WebApiBlog.Core.DependencyResolvers
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return _container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}