using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;
using Tickbox.Core.Scaffold;
using Tickbox.Data.Repository;
using Tickbox.DatabaseApi;

namespace Tickbox.Business.Scaffolding
{
    class TaxonomyScaffold : ScaffoldDefinition<Taxonomy>
    {
        private readonly ITreeNodeRepo _treeNodeRepo;

        public TaxonomyScaffold(ITreeNodeRepo treeNodeRepo)
        {
            _treeNodeRepo = treeNodeRepo;
        }

        public override void CreateScaffold(IAmbientDbContextLocator contextLocator, Taxonomy newItem)
        {

        
                var referenceTemplate = contextLocator.Get<TickboxDatabaseEntities>().Template.Single(t => t.TemplateId == 1);
                var referenceTaxonomy = referenceTemplate.Taxonomy.First(t => t.IsScaffold);
                var referneceSpecialisms = referenceTaxonomy.Specialism.Where(ts => ts.IsScaffold).ToList();
                var referenceTreeNodes = referenceTaxonomy.TreeNode.Where(ts => ts.IsScaffold).ToList();
                var scaffoldTreenodes = referenceTreeNodes.Select(tn => new TreeNode
                                                                           {
                                                                               IsScaffold = true,
                                                                               NodeId = tn.NodeId,
                                                                               Node = tn.Node,
                                                                               ParentTreeNodeId = tn.ParentTreeNodeId,
                                                                               Taxonomy = newItem,
                                                                               TaxonomyId = newItem.TaxonomyId
                                                                           }).ToList();
                newItem.Specialism = referneceSpecialisms;
                _treeNodeRepo.Add(scaffoldTreenodes);

            
        }
    }
}
