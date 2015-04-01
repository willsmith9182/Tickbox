// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INodeSpecialismManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The NodeSpecialismManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Web.Models.NodeSpecialism;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The NodeSpecialismManager interface.
    /// </summary>
    public interface INodeSpecialismManager
    {
        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="NodeSpecialismViewModel"/>.
        /// </returns>
        NodeSpecialismViewModel GetModel();

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialismViewModel"/>.
        /// </returns>
        NodeSpecialismViewModel GetModel(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Create(NodeSpecialismViewModel model);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        void Update(NodeSpecialismViewModel model);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
