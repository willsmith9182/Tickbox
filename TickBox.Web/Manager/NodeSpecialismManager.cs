// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeSpecialismManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The nodeSpecialism manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.NodeSpecialism;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The nodeSpecialism manager.
    /// </summary>
    public class NodeSpecialismManager : INodeSpecialismManager
    {
        /// <summary>
        /// The nodeSpecialism mapper.
        /// </summary>
        private readonly IMapper<NodeSpecialism, NodeSpecialismViewModel> nodeSpecialismMapper;

        /// <summary>
        /// The nodeSpecialism wrapper.
        /// </summary>
        private readonly INodeSpecialismWrapper nodeSpecialismWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="NodeSpecialismManager"/> class.
        /// </summary>
        /// <param name="nodeSpecialismMapper">
        /// The nodeSpecialism mapper.
        /// </param>
        /// <param name="nodeSpecialismWrapper">
        /// The nodeSpecialism wrapper.
        /// </param>
        public NodeSpecialismManager(IMapper<NodeSpecialism, NodeSpecialismViewModel> nodeSpecialismMapper, INodeSpecialismWrapper nodeSpecialismWrapper)
        {
            this.nodeSpecialismMapper = nodeSpecialismMapper;
            this.nodeSpecialismWrapper = nodeSpecialismWrapper;
        }

        #region Implementation of INodeSpecialismManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="NodeSpecialismViewModel"/>.
        /// </returns>
        public NodeSpecialismViewModel GetModel()
        {
            return this.nodeSpecialismMapper.Map(this.nodeSpecialismWrapper.CreateNew());
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialismViewModel"/>.
        /// </returns>
        public NodeSpecialismViewModel GetModel(int id)
        {
            return this.nodeSpecialismMapper.Map(this.nodeSpecialismWrapper.GetItem(id));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Create(NodeSpecialismViewModel model)
        {
            return this.nodeSpecialismWrapper.Create(this.nodeSpecialismMapper.Reverse(model), true).NodeSpecialismId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(NodeSpecialismViewModel model)
        {
            this.nodeSpecialismWrapper.Update(this.nodeSpecialismMapper.Reverse(model), true);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.nodeSpecialismWrapper.Delete(id, true);
        }

        #endregion
    }
}