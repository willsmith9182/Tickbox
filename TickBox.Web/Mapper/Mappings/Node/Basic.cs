// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the NodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Node;

namespace TickBox.Web.Mapper.Mappings.Node
{
    /// <summary>
    /// The node view model.
    /// </summary>
    public class Basic : IMappingProvider<Objects.Node, NodeViewModel>
    {
        #region Implementation of IMappingProvider<Node,NodeViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        public Objects.Node CreateObject(NodeViewModel item)
        {
            return new Objects.Node
                       {
                           AllowMultiSelectChildren = item.AllowMultiSelectChildren,
                           NodeDescription = item.NodeDescription,
                           NodeId = item.NodeId,
                           NodeTitle = item.NodeTitle
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="NodeViewModel"/>.
        /// </returns>
        public NodeViewModel CreateObject(Objects.Node item)
        {
            return new NodeViewModel
                       {
                           AllowMultiSelectChildren = item.AllowMultiSelectChildren,
                           NodeDescription = item.NodeDescription,
                           NodeId = item.NodeId,
                           NodeTitle = item.NodeTitle
                       };
        }

        #endregion
    }
}
