using System.Web.Http;
using System.Web.Http.Results;
using UmbracoCMS.Core.CleanApi.Fabric.Models;

namespace UmbracoCms.Core.CleanApi.Fabric.Controller
{
    public abstract class CleanApiController : ApiController
    {
        protected OkNegotiatedContentResult<CleanResponse<TModel>> Ok<TModel>(TModel content, CleanLinks relatedLinks = null) where TModel : class
        {
            var response = new CleanResponse<TModel>(content, relatedLinks);
            
            return base.Ok(response);
        }
    }
}