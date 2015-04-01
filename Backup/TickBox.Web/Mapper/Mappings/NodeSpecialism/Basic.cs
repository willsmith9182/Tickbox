// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The basic.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.NodeSpecialism;

namespace TickBox.Web.Mapper.Mappings.NodeSpecialism
{
    /// <summary>
    /// The basic.
    /// </summary>
    public class Basic : IMappingProvider<Objects.NodeSpecialism, NodeSpecialismViewModel>
    {
        #region Implementation of IMappingProvider<NodeSpecialism,NodeSpecialismViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialism"/>.
        /// </returns>
        public Objects.NodeSpecialism CreateObject(NodeSpecialismViewModel item)
        {
            return new Objects.NodeSpecialism
                       {
                           DocumentLink = item.DocumentLink,
                           IsScaffold = item.IsScaffold,
                           Guidelines = item.Guidelines,
                           NodeId = item.NodeId,
                           SpecialismId = item.SpecialismId,
                           NodeSpecialismId = item.NodeSpecialismId,
                           SequenceOrder = item.SequenceOrder
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialismViewModel"/>.
        /// </returns>
        public NodeSpecialismViewModel CreateObject(Objects.NodeSpecialism item)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}