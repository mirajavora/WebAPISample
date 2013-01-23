using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WebApiBlog.Core
{
    public abstract class ContainerApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected IWindsorContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        protected ContainerApplication()
        {

        }


        protected void Application_Start(object sender, EventArgs e)
        {
            Initialise();
        }

        protected virtual void Initialise()
        {
            Container = CreateContainer();
            RunInstallers();
            AppStart();
        }

        protected abstract void AppStart();

        protected virtual void RunInstallers()
        {
            Container.Install(FromAssembly.This());
        }

        protected virtual IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }
    }
}