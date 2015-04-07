using System.Linq;
using Mehdime.Entity;
using Tickbox.Data.Repository;
using Tickbox.DatabaseApi;

namespace Tickbox.Core.Scaffold
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
