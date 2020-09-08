using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RecruitmentTask.DependencyInjection
{
    public class ControllersInstaller: IWindsorInstaller
    {
        #region Methods

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());
        }

        #endregion Methods
    }
}