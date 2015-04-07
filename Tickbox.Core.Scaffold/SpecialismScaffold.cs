using System.Linq;
using Mehdime.Entity;
using Tickbox.DatabaseApi;

namespace Tickbox.Core.Scaffold
{
    public class SpecialismScaffold:ScaffoldDefinition<Specialism>
    {
        public override void CreateScaffold(IAmbientDbContextLocator contextLocator, Specialism newItem)
        {
            var referenceSpecialism = contextLocator.Get<TickboxDatabaseEntities>().Specialism.Single(t => t.IsScaffold);
            var referenceTaxonomies = referenceSpecialism.Taxonomy;
            var referenceNodeSpesh = referenceSpecialism.NodeSpecialism.Where(ns => ns.IsScaffold).ToList();
            var scaffoldNodeSpesh = referenceNodeSpesh.Select(ns => new NodeSpecialism
                {
                    IsScaffold = true,
                    DocumentLink = ns.DocumentLink,
                    Guidelines =
                        "This is the default ordering of nodes for new taxonomies.",
                    Node = ns.Node,
                    NodeId = ns.NodeId,
                    SequenceOrder = ns.SequenceOrder,
                    Specialism = newItem,
                    SpecialismId = newItem.SpecialismId
                }).ToList();

            newItem.Taxonomy = referenceTaxonomies;
            newItem.NodeSpecialism = scaffoldNodeSpesh.ToList();
        }
    }
}
