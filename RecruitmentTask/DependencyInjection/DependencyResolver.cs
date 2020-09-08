using Castle.Windsor;

namespace RecruitmentTask.DependencyInjection
{
    public static class DependencyResolver
    {
        static DependencyResolver()
        {
            Current = null;
        }

        public static IWindsorContainer Current { get; private set; }

        public static void SetResolver(IWindsorContainer container)
        {
            Current = container;
        }
    }
}