using Castle.Windsor;
using Castle.Windsor.Installer;
using RecruitmentTask.DependencyInjection;
using System.Web.Mvc;
using System.Web.Routing;
using DependencyResolver = RecruitmentTask.DependencyInjection.DependencyResolver;

namespace RecruitmentTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new WindsorContainer();
            container.Install(new ControllersInstaller(),
                Configuration.FromAppConfig());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            DependencyResolver.SetResolver(container);

        }
    }
}
