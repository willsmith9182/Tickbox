// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The node manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Node;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The node manager.
    /// </summary>
    public class NodeManager : INodeManager
    {
        /// <summary>
        /// The node mapper.
        /// </summary>
        private readonly IMapper<Node, NodeViewModel> nodeMapper;

        /// <summary>
        /// The node wrapper.
        /// </summary>
        private readonly INodeWrapper nodeWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="NodeManager"/> class.
        /// </summary>
        /// <param name="nodeMapper">
        /// The node mapper.
        /// </param>
        /// <param name="nodeWrapper">
        /// The node wrapper.
        /// </param>
        public NodeManager(IMapper<Node, NodeViewModel> nodeMapper, INodeWrapper nodeWrapper)
        {
            this.nodeMapper = nodeMapper;
            this.nodeWrapper = nodeWrapper;
        }

        #region Implementation of INodeManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="NodeViewModel"/>.
        /// </returns>
        public NodeViewModel GetModel()
        {
            return this.nodeMapper.Map(this.nodeWrapper.CreateNew());
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="NodeViewModel"/>.
        /// </returns>
        public NodeViewModel GetModel(int id)
        {
            return this.nodeMapper.Map(this.nodeWrapper.GetItem(id));
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
        public int Create(NodeViewModel model)
        {
            return this.nodeWrapper.Create(this.nodeMapper.Reverse(model),true).NodeId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(NodeViewModel model)
        {
            this.nodeWrapper.Update(this.nodeMapper.Reverse(model),true);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.nodeWrapper.Delete(id,true);
        }

        #endregion
    }
}