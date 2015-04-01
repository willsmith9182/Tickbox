// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeSpecialismWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The nodeSpecialism wrapper.
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
    /// The nodeSpecialism wrapper.
    /// </summary>
    public class NodeSpecialismWrapper : WrapperBase, INodeSpecialismWrapper
    {



        #region Implementation of INodeSpecialismWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public NodeSpecialismWrapper(IComitable dataUnitOfWork, INotify notifier)
            : base(dataUnitOfWork, notifier)
        {
        }

        public IEnumerable<NodeSpecialism> GetAll()
        {
            var items = this.dataUnitOfWork.GetAll<NodeSpecialism>();
            this.notifier.Add<DebugNotification>(string.Format("Total items retrieved:{0}", items.Count()), "Get All Node Specialisms");
            return items;
        }

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="NodeSpecialism"/>.
        /// </returns>
        public NodeSpecialism CreateNew()
        {
            return new NodeSpecialism
            {
                NodeSpecialismId = -1
            };
        }

        /// <summary>
        /// The get nodeSpecialism.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialism"/>.
        /// </returns>
        public NodeSpecialism GetItem(int id)
        {
            try
            {
                var item = this.dataUnitOfWork.GetItem<NodeSpecialism>(i => i.NodeSpecialismId == id);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Sp: {1} /n Node: {2}", item.NodeSpecialismId, item.Specialism.SpecialismTitle, item.Node.NodeTitle), "Get Node Specialism");
                return item;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Node Specialism with Id{{{0}}} cannot be found.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DataNotFoundException<NodeSpecialism>(id, e);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="NodeSpecialism"/>.
        /// </returns>
        public NodeSpecialism Create(NodeSpecialism item, bool immediateSave)
        {
            try
            {
                item.NodeSpecialismId = this.dataUnitOfWork.GetNextId<NodeSpecialism>(i => i.NodeSpecialismId);
                this.dataUnitOfWork.Create(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Sp: {1} /n Node: {2}", item.NodeSpecialismId, item.Specialism.SpecialismTitle, item.Node.NodeTitle), "Create Node Specialism");
                this.Save(immediateSave, new SuccessNotification { Message = "NodeSpecialism created.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create Node Specialism, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseCreateException<NodeSpecialism>(item.NodeSpecialismId, e);
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
        /// The <see cref="NodeSpecialism"/>.
        /// </returns>
        public NodeSpecialism Update(NodeSpecialism item, bool immediateSave)
        {
            try
            {
                this.dataUnitOfWork.Update(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Sp: {1} /n Node: {2}", item.NodeSpecialismId, item.Specialism.SpecialismTitle, item.Node.NodeTitle), "Update Node Specialism");
                this.Save(immediateSave, new SuccessNotification { Message = "NodeSpecialism updated.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to update Node Specialism, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseUpdateException<NodeSpecialism>(item.NodeSpecialismId, e);
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
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Sp: {1} /n Node: {2}", item.NodeSpecialismId, item.Specialism.SpecialismTitle, item.Node.NodeTitle), "Delete Node Specialism");
                this.Save(immediateSave, new SuccessNotification { Message = "NodeSpecialism deleted.", Title = "Save" });

            }
            catch (DataNotFoundException<NodeSpecialism>)
            {
                throw;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Unable to delete Node Specialism, please try again.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseDeleteException<NodeSpecialism>(id, e);
            }
        }

        #endregion
    }
}
