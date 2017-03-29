using ITN.Felicity.Domain.Repositories;
using ITN.Felicity.EntityFramework;
using ITN.Felicity.EntityFramework.Repositories;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ITN.Felicity.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType<FelicityContext>(new ContainerControlledLifetimeManager());
                    
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}