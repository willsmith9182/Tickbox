using Tickbox.Web.Models.Request;

namespace Tickbox.Business.Services
{
    public interface INodeService
    {
        void Create(CreateNode req);
    }
}