using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace UmbracoCms.Core.CleanApi.Fabric
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteTable.Routes.Clear();
        }

        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteTable.Routes.Clear();
        }
        
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteTable.Routes.Clear();

            RouteTable.Routes.MapRoute(
                "UmbracoCMS.Core.CleaApi.Default",
                "",
                new { controller = "UmbracoCleanApi", action = "RedirectToApi", id = UrlParameter.Optional }
            );
            
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("umbraco");
            RouteTable.Routes.IgnoreRoute("umbraco/{*pathInfo}");
        }
    }
}