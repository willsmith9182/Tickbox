using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;
using Tickbox.Core.Service;
using Tickbox.Data.Repository;
using Tickbox.DatabaseApi;
using Tickbox.Web.Models.Request;

namespace Tickbox.Business.Services
{
    public class TaxonomyService : ServiceBase
    {
        private readonly ITaxonomyRepo _taxonomyRepo;
        public TaxonomyService(IDbContextScopeFactory scopeFactory, ITaxonomyRepo taxonomyRepo)
            : base(scopeFactory)
        {
            _taxonomyRepo = taxonomyRepo;
        }




    }

    public interface ITreeNodeService
    {
    }


    public interface INodeService
    {
        void Create(CreateNodeRequest req);
    }

    public class NodeService : ServiceBase, INodeService
    {
        private readonly INodeRepo _nodeRepo;
        private readonly ISpecialismRepo _specialismRepo;


        public void Create(CreateNodeRequest req)
        {
            using (var scope = ScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var specialisms = _specialismRepo.Find(s => req.Sepcialisms.Contains(s.SpecialismId)).ToList();
                var nodeSpeiclaisms = specialisms.Select(s => new NodeSpecialism
                {
                    Specialism = s,
                    SpecialismId = s.SpecialismId
                }).ToList();
                var newNode = new Node
                {
                  NodeSpecialism = nodeSpeiclaisms,
                  ChildrenMultiSelect = req.ChildrenMultiSelect,
                  NodeDesc = req.NodeDesc,
                  NodeTitle = req.NodeTitle
                };
                _nodeRepo.Add(newNode);

                scope.SaveChanges();
            }
        }

        public NodeService(IDbContextScopeFactory scopeFactory, INodeRepo nodeRepo, ISpecialismRepo specialismRepo)
            : base(scopeFactory)
        {
            _nodeRepo = nodeRepo;
            _specialismRepo = specialismRepo;
        }
    }
}
