using System.Data;
using Mehdime.Entity;
using Tickbox.Core.Service;
using Tickbox.Data.Repository;
using Tickbox.Web.Models.Request;

namespace Tickbox.Business.Services
{
    public class NodeService : ServiceBase, INodeService
    {
        private readonly INodeRepo _nodeRepo;
        private readonly ISpecialismRepo _specialismRepo;

        public NodeService(IDbContextScopeFactory scopeFactory, INodeRepo nodeRepo, ISpecialismRepo specialismRepo)
            : base(scopeFactory)
        {
            _nodeRepo = nodeRepo;
            _specialismRepo = specialismRepo;
        }

        public void Create(CreateNode req)
        {
            using (var scope = ScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                scope.SaveChanges();
            }
        }
    }
}