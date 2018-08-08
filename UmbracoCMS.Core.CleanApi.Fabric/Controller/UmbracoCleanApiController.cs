using System.Configuration;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoCms.Core.CleanApi.Fabric.Controller
{
    public class UmbracoCleanApiController : UmbracoController
    {
        [HttpGet]
        public ActionResult RedirectToApi()
        {
            var urlRedirect = ConfigurationManager.AppSettings["UmbracoApiPath"];

            if (string.IsNullOrEmpty(urlRedirect))
                return HttpNotFound();
            
            return Redirect(urlRedirect);  
        }
    }
}