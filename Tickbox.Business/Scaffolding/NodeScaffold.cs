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
    public class NodeScaffold : ScaffoldDefinition<Node>
    {
        public override void CreateScaffold(IAmbientDbContextLocator contextLocator, Node newItem)
        {
            var cxt = contextLocator.Get<TickboxDatabaseEntities>();
            var referenceSpecialism = cxt.Specialism.Single(t => t.IsScaffold);
            var referenceTemplate = cxt.Template.Single(t => t.IsMaster);
            var referenceTaxonomy = referenceTemplate.Taxonomy.OrderBy(t=>t.TaxonomyId).First(t => t.IsScaffold);
            var referenceParentTreeNode = referenceTaxonomy.TreeNode.Single(n => n.ParentTreeNodeId == null);
            var sequenceOrder  =
                referenceTaxonomy.TreeNode.Count(tn => tn.ParentTreeNodeId == referenceParentTreeNode.TreeNodeId) +1;

            var scaffoldTreeNode = new TreeNode
                       {
                           IsScaffold = true,
                           NodeId = newItem.NodeId,
                           Node = newItem,
                           ParentTreeNodeId = referenceParentTreeNode.ParentTreeNodeId,
                           Taxonomy = referenceParentTreeNode.Taxonomy,
                           TaxonomyId = referenceParentTreeNode.TaxonomyId};

            var scaffoldNodeSpecialism = referenceSpecialism.NodeSpecialism.Select(ns => new NodeSpecialism
            {
                IsScaffold = true,
                DocumentLink = string.Empty,
                Guidelines =
                    "This is the default ordering of nodes for new taxonomies.",
                Node = newItem,
                NodeId = newItem.NodeId,
                SequenceOrder = sequenceOrder,
                Specialism = referenceSpecialism,
                SpecialismId =
                    referenceSpecialism.SpecialismId
            }).ToList();

            newItem.NodeSpecialism = scaffoldNodeSpecialism.ToList();
            newItem.TreeNode.Add(scaffoldTreeNode);
        }
    }
}
 