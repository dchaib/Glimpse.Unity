using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Glimpse.Unity;
using Microsoft.Practices.Unity;

namespace Glimpse.Unity.Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetupUnity();
        }

        private void SetupUnity()
        {
            var container = new UnityContainer();
            container.RegisterType<IFoo, Foo>();
            container.RegisterType<IBar, Bar>(new ContainerControlledLifetimeManager());

            container.RegisterInGlimpse();
        }
    }

    internal class Bar : IBar
    {
    }

    internal interface IBar
    {
    }

    internal class Foo : IFoo
    {
    }

    internal interface IFoo
    {
    }
}
