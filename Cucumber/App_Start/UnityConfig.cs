using Cucumber.BLL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Cucumber
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<INumberToWord, NumberToWord>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}