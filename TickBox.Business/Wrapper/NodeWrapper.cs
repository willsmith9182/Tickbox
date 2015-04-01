// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The node wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using TickBox.Objects;
using TickBox.Objects.Notifications;

namespace TickBox.Business
{
    /// <summary>
    /// The node wrapper.
    /// </summary>
    public class NodeWrapper : WrapperBase, INodeWrapper
    {


        #region Implementation of INodeWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public NodeWrapper(IComitable dataUnitOfWork, INotify notifier)
            : base(dataUnitOfWork, notifier)
        {
        }

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        public Node CreateNew()
        {
            return new Node
                       {
                           NodeId = -1
                       };
        }

        /// <summary>
        /// The get node.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        public Node GetItem(int id)
        {
            try
            {
                var item = this.dataUnitOfWork.GetItem<Node>(i => i.NodeId == id);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.NodeId, item.NodeTitle), "Get Node");
                return item;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Node with Id{{{0}}} cannot be found.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DataNotFoundException<Node>(id, e);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        public Node Create(Node item, bool immediateSave)
        {
            try
            {
                item.NodeId = this.dataUnitOfWork.GetNextId<Node>(i => i.NodeId);
                if (this.AutoCreateScaffolding)
                {
                    this.notifier.Add<DebugNotification>("Attempting to build scaffold following creation of node", "Scaffold");
                    Scaffolding.CreateScaffold(item, this.dataUnitOfWork);

                }
                this.dataUnitOfWork.Create(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: ID:{0}/n Title:{1}", item.NodeId, item.NodeTitle), "Create Node");
                this.Save(immediateSave, new SuccessNotification { Message = "Node created.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create Node, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseCreateException<Node>(item.NodeId, e);
            }

            return item;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Node"/>.
        /// </returns>
        public Node Update(Node item, bool immediateSave)
        {
            try
            {
                this.dataUnitOfWork.Update(item);
                this.notifier.Add<DebugNotification>(string.Format("Sucessfully updated Node: {{{0}}} - {1}", item.NodeId, item.NodeTitle), "Data Update");
                this.Save(immediateSave, new SuccessNotification { Message = "Node updated.", Title = "Save" });

            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to update Node, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseUpdateException<Node>(item.NodeId, e);
            }

            return item;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id, bool immediateSave)
        {
            try
            {
                var item = this.GetItem(id);
                this.dataUnitOfWork.Delete(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.NodeId, item.NodeTitle), "Delete Node");
                this.Save(immediateSave, new SuccessNotification { Message = "Node deleted.", Title = "Save" });

            }
            catch (DataNotFoundException<Node>)
            {
                throw;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Unable to delete Node, please try again.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseDeleteException<NodeSpecialism>(id, e);
            }
        }

        public IEnumerable<Node> GetAll()
        {
            var items = this.dataUnitOfWork.GetAll<Node>();
            this.notifier.Add<DebugNotification>(string.Format("Total items retrieved:{0}", items.Count()), "Get All Nodes");
            return items;
        }
        #endregion
    }
}
