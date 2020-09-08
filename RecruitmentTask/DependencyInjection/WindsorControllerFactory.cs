using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace RecruitmentTask.DependencyInjection
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Properties

        private readonly IKernel _kernel;

        #endregion Properties

        #region Constructors

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        #endregion

        #region Overrides

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                    $"The controller for path '{requestContext.HttpContext.Request.Path}' could not be found.");
            }

            return (IController)_kernel.Resolve(controllerType);
        }

        #endregion Overrides
    }
}