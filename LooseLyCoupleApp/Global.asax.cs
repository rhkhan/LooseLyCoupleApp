using LooselyCouple.Data;
using LooseLyCoupleApp.App_Start;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace LooseLyCoupleApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<LooselyCoupleEntities>(null);//// To avoid migration in code-first if table changes or initial database can be seeded with create, update and drop

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
