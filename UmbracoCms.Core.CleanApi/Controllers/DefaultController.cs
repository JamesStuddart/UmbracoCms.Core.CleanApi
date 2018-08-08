using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using umbraco;
using UmbracoCms.Core.CleanApi.Fabric.Controller;
using UmbracoCMS.Core.CleanApi.Fabric.Models;

namespace UmbracoCms.Core.CleanApi.Controllers
{
    [RoutePrefix("api")]
    public class DefaultController : CleanApiController
    {
        private const string NodeTypeName = "~yourNodeName~";

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Index()
        {
            var result = uQuery.GetNodesByType(NodeTypeName);

            var content = result.Take(5).Select(x => new {x.CreateDate, x.CreatorName, Url = x.NiceUrl}).ToList();
            
            var relatedLinks = new CleanLinks
            {
                new CleanLink("some.name.Get", "/api/somelink", HttpVerbs.Get),
                new CleanLink("some.name.Post", "/api/", HttpVerbs.Post),
                new CleanLink("some.name.Patch", "/api/", HttpVerbs.Patch),
                new CleanLink("some.name.Delete", "/api/", HttpVerbs.Delete),
                new CleanLink("some.name.Put", "/api/", HttpVerbs.Put),
                new CleanLink("some.PDF", "/api/guide.pdf", "application/pdf"),
            };

            return Ok(content, relatedLinks);
        }
    }
}