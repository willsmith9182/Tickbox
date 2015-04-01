// -----------------------------------------------------------------------
// <copyright file="Scaffolding.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using TickBox.Objects;

namespace TickBox.Business
{
    public static class Scaffolding
    {

        /// <summary>
        /// The create scaffold.
        /// </summary>
        /// <param name="newTemplate">
        /// The new template.
        /// </param>
        public static void CreateScaffold(Template newTemplate, IDataUnitOfWork dataUnitOfWork)
        {
            var referenceTemplate = dataUnitOfWork.GetItem<Template>(t => t.TemplateId == -1);
            var referenceTaxonomy = referenceTemplate.Taxonomies.First(t => t.IsScaffold);
            var referneceSpecialisms = referenceTaxonomy.Specialisms.Where(ts => ts.IsScaffold).ToList();
            var referenceTreenodes = referenceTaxonomy.TreeNodes.Where(ts => ts.IsScaffold).ToList();
            var scaffoldTaxonomy = ScaffoldTaxonomy(newTemplate, dataUnitOfWork);
            var scaffoldTreenodes = ScaffoldTreeNode(referenceTreenodes, scaffoldTaxonomy, dataUnitOfWork);
            scaffoldTaxonomy.Specialisms = referneceSpecialisms;
            scaffoldTaxonomy.TreeNodes = scaffoldTreenodes.ToList();
            dataUnitOfWork.Create(scaffoldTaxonomy);
        }

        /// <summary>
        /// The create scaffold.
        /// </summary>
        /// <param name="newTaxonomy">
        /// The new taxonomy.
        /// </param>
        public static void CreateScaffold(Taxonomy newTaxonomy, IDataUnitOfWork dataUnitOfWork)
        {
            var referenceTaxonomy = dataUnitOfWork.GetItem<Taxonomy>(t => t.TaxonomyId == -1);
            var referneceSpecialisms = referenceTaxonomy.Specialisms.ToList();
            var referenceTreenodes = referenceTaxonomy.TreeNodes.Where(ts => ts.IsScaffold).ToList();
            var scaffoldTreenodes = ScaffoldTreeNode(referenceTreenodes, newTaxonomy, dataUnitOfWork);

            newTaxonomy.Specialisms = referneceSpecialisms;
            newTaxonomy.TreeNodes = scaffoldTreenodes.ToList();
            dataUnitOfWork.Update(newTaxonomy);
        }

        /// <summary>
        /// The create scaffold.
        /// </summary>
        /// <param name="newSpecialism">
        /// The new specialism.
        /// </param>
        public static void CreateScaffold(Specialism newSpecialism, IDataUnitOfWork dataUnitOfWork)
        {
            var referenceSpecialism = dataUnitOfWork.GetItem<Specialism>(t => t.IsScaffold);
            var referenceTaxonomies = referenceSpecialism.Taxonomies;
            var referenceNodeSpesh = referenceSpecialism.NodeSpecialisms.Where(ns => ns.IsScaffold).ToList();
            var scaffoldNoseSpesh = ScaffoldNodeSpecialism(referenceNodeSpesh, newSpecialism, dataUnitOfWork);

            newSpecialism.Taxonomies = referenceTaxonomies;
            newSpecialism.NodeSpecialisms = scaffoldNoseSpesh.ToList();
            dataUnitOfWork.Update(newSpecialism);
        }

        /// <summary>
        /// The create scaffold.
        /// </summary>
        /// <param name="newNode">
        /// The new node.
        /// </param>
        public static void CreateScaffold(Node newNode, IDataUnitOfWork dataUnitOfWork)
        {
            // make new node, create node specialisms for default specialism, create tree node, add tree node to bottom of default model/default taxonomy 
            var referenceSpecialism = dataUnitOfWork.GetItem<Specialism>(t => t.IsScaffold);
            var referenceTemplate = dataUnitOfWork.GetItem<Template>(t => t.TemplateId == -1);
            var referenceTaxonomy = referenceTemplate.Taxonomies.First(t => t.IsScaffold);
            var referenceParentTreeNode = referenceTaxonomy.TreeNodes.Single(n => n.ParentTreeNodeId == null);
            var referenceSiblings =
                referenceTaxonomy.TreeNodes.Where(tn => tn.ParentTreeNodeId == referenceParentTreeNode.TreeNodeId)
                                 .ToList();

            var scaffoldTreeNode = ScaffoldTreeNode(referenceParentTreeNode, newNode, dataUnitOfWork);

            var scaffoldNodeSpecialism = ScaffoldNodeSpecialism(referenceSiblings, referenceSpecialism, newNode,
                                                                dataUnitOfWork);

            newNode.NodeSpecialisms = scaffoldNodeSpecialism.ToList();
            newNode.TreeNodes.Add(scaffoldTreeNode);
            dataUnitOfWork.Update(newNode);
        }

        public static bool ScaffoldExists(IDataUnitOfWork dataUnitOfWork)
        {
            return dataUnitOfWork.Exists<Template>(t => t.TemplateId == -1);
        }

        /// <summary>
        /// The create default structure.
        /// </summary>
        public static void CreateDefaultStructure(IDataUnitOfWork dataUnitOfWork)
        {
            if (ScaffoldExists(dataUnitOfWork))
            {
                return;
            }
            var newDefaultTemplate = new Template
                                         {
                                             DocumentLink = string.Empty,
                                             Name = "Default Template",
                                             TemplateId = -1,
                                             IsScaffold = true
                                         };
            var newDefaultTaxonomy = new Taxonomy
                                         {
                                             TemplateId = -1,
                                             IsScaffold = true,
                                             TaxonomyId = -1,
                                             Title = "Default Taxonomy"
                                         };

            var newDefaultSpecialism = new Specialism
                                           {
                                               IsScaffold = true,
                                               SpecialismId = -1,
                                               SpecialismTitle = "Default Specialism"
                                           };
            var newDefaultRootNode = new Node
                                         {
                                             AllowMultiSelectChildren = true,
                                             NodeDescription = "The root node",
                                             NodeId = -1,
                                             NodeTitle = "Root"
                                         };

            var newDefaultNodeSpecialism = new NodeSpecialism
                                               {
                                                   DocumentLink = string.Empty,
                                                   Guidelines = "Don't delete this node definition.",
                                                   NodeId = -1,
                                                   NodeSpecialismId = -1,
                                                   IsScaffold = true,
                                                   SequenceOrder = 0,
                                                   SpecialismId = -1
                                               };
            var newDefaultRootTreeNode = new TreeNode
                                             {
                                                 IsScaffold = true,
                                                 NodeId = -1,
                                                 ParentTreeNodeId = null,
                                                 TaxonomyId = -1,
                                                 TreeNodeId = -1
                                             };

            // Default Templaing structure, all references made properly for completness - mapping here is both forward navigation properties and backdown the same relationship from the other side.
            // Basicall everythign shoudl reference each other. 
            newDefaultTemplate.Taxonomies.Add(newDefaultTaxonomy);

            newDefaultTaxonomy.Template = newDefaultTemplate;
            newDefaultTaxonomy.TreeNodes.Add(newDefaultRootTreeNode);
            newDefaultTaxonomy.Specialisms.Add(newDefaultSpecialism);

            newDefaultRootTreeNode.Node = newDefaultRootNode;
            newDefaultRootTreeNode.Taxonomy = newDefaultTaxonomy;

            newDefaultSpecialism.Taxonomies.Add(newDefaultTaxonomy);
            newDefaultSpecialism.NodeSpecialisms.Add(newDefaultNodeSpecialism);

            newDefaultNodeSpecialism.Specialism = newDefaultSpecialism;
            newDefaultNodeSpecialism.Node = newDefaultRootNode;

            newDefaultRootNode.TreeNodes.Add(newDefaultRootTreeNode);
            newDefaultRootNode.NodeSpecialisms.Add(newDefaultNodeSpecialism);

            // Adding them to respective repositories.
            dataUnitOfWork.Create(newDefaultNodeSpecialism);

            dataUnitOfWork.Create(newDefaultSpecialism);

            dataUnitOfWork.Create(newDefaultTaxonomy);

            dataUnitOfWork.Create(newDefaultTemplate);

            dataUnitOfWork.Create(newDefaultRootTreeNode);

            dataUnitOfWork.Create(newDefaultRootNode);
        }

        /// <summary>
        /// The scaffold taxonomy.
        /// </summary>
        /// <param name="template">
        /// The template.
        /// </param>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        private static Taxonomy ScaffoldTaxonomy(Template template, IDataUnitOfWork dataUnitOfWork)
        {
            return new Taxonomy
                       {
                           IsScaffold = true,
                           TaxonomyId = dataUnitOfWork.GetNextId<Taxonomy>(i => i.TaxonomyId),
                           TemplateId = template.TemplateId,
                           Template = template,
                           Title = string.Format("Scaffold for {0} Template", template.Name)
                       };
        }

        /// <summary>
        /// The scaffold node specialism.
        /// </summary>
        /// <param name="referenceSiblings">
        /// The reference siblings.
        /// </param>
        /// <param name="referenceSpecialism">
        /// The reference specialism.
        /// </param>
        /// <param name="newNode">
        /// The new node.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        private static IEnumerable<NodeSpecialism> ScaffoldNodeSpecialism(IEnumerable<TreeNode> referenceSiblings,
                                                                          Specialism referenceSpecialism, Node newNode,
                                                                          IDataUnitOfWork dataUnitOfWork)
        {
            var newSequenceNo = referenceSiblings.Count() + 1;
            return referenceSpecialism.NodeSpecialisms.Select(ns => new NodeSpecialism
                                                                        {
                                                                            IsScaffold = true,
                                                                            DocumentLink = string.Empty,
                                                                            Guidelines =
                                                                                "This is the default ordering of nodes for new taxonomies.",
                                                                            Node = newNode,
                                                                            NodeId = newNode.NodeId,
                                                                            NodeSpecialismId =
                                                                                dataUnitOfWork.GetNextId<NodeSpecialism>
                                                                                (i => i.NodeSpecialismId),
                                                                            SequenceOrder = newSequenceNo,
                                                                            Specialism = referenceSpecialism,
                                                                            SpecialismId =
                                                                                referenceSpecialism.SpecialismId
                                                                        }).ToList();
        }

        /// <summary>
        /// The scaffold node specialism.
        /// </summary>
        /// <param name="referenceNodeSpecialism">
        /// The reference node specialism.
        /// </param>
        /// <param name="newSpecialism">
        /// The new specialism.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{NodeSpecialism}"/>.
        /// </returns>
        private static IEnumerable<NodeSpecialism> ScaffoldNodeSpecialism(
            IEnumerable<NodeSpecialism> referenceNodeSpecialism, Specialism newSpecialism,
            IDataUnitOfWork dataUnitOfWork)
        {
            return referenceNodeSpecialism.Select(ns => new NodeSpecialism
                                                            {
                                                                IsScaffold = true,
                                                                DocumentLink = ns.DocumentLink,
                                                                Guidelines =
                                                                    "This is the default ordering of nodes for new taxonomies.",
                                                                Node = ns.Node,
                                                                NodeId = ns.NodeId,
                                                                NodeSpecialismId =
                                                                    dataUnitOfWork.GetNextId<NodeSpecialism>(
                                                                        i => i.NodeSpecialismId),
                                                                SequenceOrder = ns.SequenceOrder,
                                                                Specialism = newSpecialism,
                                                                SpecialismId = newSpecialism.SpecialismId
                                                            }).ToList();
        }

        /// <summary>
        /// The scaffold tree node.
        /// </summary>
        /// <param name="referenceTreeNodes">
        /// The reference tree nodes.
        /// </param>
        /// <param name="scaffoldTaxonomy">
        /// The scaffold taxonomy.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{TreeNode}"/>.
        /// </returns>
        private static IEnumerable<TreeNode> ScaffoldTreeNode(IEnumerable<TreeNode> referenceTreeNodes,
                                                              Taxonomy scaffoldTaxonomy, IDataUnitOfWork dataUnitOfWork)
        {
            return referenceTreeNodes.Select(tn => new TreeNode
                                                       {
                                                           IsScaffold = true,
                                                           NodeId = tn.NodeId,
                                                           Node = tn.Node,
                                                           ParentTreeNodeId = tn.ParentTreeNodeId,
                                                           Taxonomy = scaffoldTaxonomy,
                                                           TaxonomyId = scaffoldTaxonomy.TaxonomyId,
                                                           TreeNodeId =
                                                               dataUnitOfWork.GetNextId<TreeNode>(i => i.TreeNodeId)
                                                       }).ToList();
        }

        /// <summary>
        /// The scaffold tree node.
        /// </summary>
        /// <param name="referenceParentNode">
        /// The reference parent node.
        /// </param>
        /// <param name="newNode">
        /// The new node.
        /// </param>
        /// <returns>
        /// The <see cref="TreeNode"/>.
        /// </returns>
        private static TreeNode ScaffoldTreeNode(TreeNode referenceParentNode, Node newNode,
                                                 IDataUnitOfWork dataUnitOfWork)
        {
            return new TreeNode
                       {
                           IsScaffold = true,
                           NodeId = newNode.NodeId,
                           Node = newNode,
                           ParentTreeNodeId = referenceParentNode.ParentTreeNodeId,
                           Taxonomy = referenceParentNode.Taxonomy,
                           TaxonomyId = referenceParentNode.TaxonomyId,
                           TreeNodeId = dataUnitOfWork.GetNextId<TreeNode>(i => i.TreeNodeId)
                       };
        }
    }
}