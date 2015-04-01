// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The TreeNode view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.TreeNode;

namespace TickBox.Web.Mapper.Mappings.TreeNode
{
    /// <summary>
    /// The TreeNode view model.
    /// </summary>
    public class Basic : IMappingProvider<Objects.TreeNode, TreeNodeViewModel>
    {
        #region Implementation of IMappingProvider<TreeNode,TreeNodeViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TreeNode"/>.
        /// </returns>
        public Objects.TreeNode CreateObject(TreeNodeViewModel item)
        {
            return new Objects.TreeNode
                       {
                           IsScaffold = item.IsScaffold,
                           NodeId = item.NodeId,
                           ParentTreeNodeId = item.ParentTreeNodeId,
                           TaxonomyId = item.TaxonomyId,
                           TreeNodeId = item.TreeNodeId
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TreeNode"/>.
        /// </returns>
        public TreeNodeViewModel CreateObject(Objects.TreeNode item)
        {
            return new TreeNodeViewModel
                       {
                           IsScaffold = item.IsScaffold,
                           NodeId = item.NodeId,
                           ParentTreeNodeId = item.TaxonomyId,
                           TaxonomyId = item.TaxonomyId,
                           TreeNodeId = item.TreeNodeId
                       };
        }

        #endregion
    }
}