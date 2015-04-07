using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;
using Tickbox.Core.Scaffold;
using Tickbox.DatabaseApi;

namespace Tickbox.Business.Scaffolding
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
