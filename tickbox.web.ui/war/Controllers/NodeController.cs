using System.Web.Http;
using Tickbox.Business.Services;
using Tickbox.Web.Models.Request;

namespace Tickbox.Web.Controllers
{
    public class NodeController : ApiController
    {

        private readonly INodeService _nodeService;

        [HttpPost]
        public void CreateNode(CreateNodeRequest req)
        {
            _nodeService.Create(req);
        }

    }
}
