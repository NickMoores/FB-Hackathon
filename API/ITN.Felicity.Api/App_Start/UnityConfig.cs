using ITN.Felicity.Domain.Repositories;
using ITN.Felicity.EntityFramework;
using ITN.Felicity.EntityFramework.Repositories;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using System.Data.Entity;
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
            container.RegisterType<FelicityContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, FelicityContext>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
            container.RegisterType<IFeedbackRepository, FeedbackRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
        }
    }
}