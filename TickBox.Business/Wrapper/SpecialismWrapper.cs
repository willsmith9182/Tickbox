// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialismWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism wrapper.
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
    /// The specialism wrapper.
    /// </summary>
    public class SpecialismWrapper : WrapperBase, ISpecialismWrapper
    {
        #region Implementation of ISpecialismWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public SpecialismWrapper(IComitable dataUnitOfWork, INotify notifier)
            : base(dataUnitOfWork, notifier)
        {
        }

        public IEnumerable<Specialism> GetAll()
        {
            var items = this.dataUnitOfWork.GetAll<Specialism>();
            this.notifier.Add<DebugNotification>(string.Format("Total items retrieved:{0}", items.Count()), "Get All Specialisms");
            return items;
        }

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="Specialism"/>.
        /// </returns>
        public Specialism CreateNew()
        {
            return new Specialism
                       {
                           SpecialismId = -1
                       };
        }

        /// <summary>
        /// The get specialism.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Specialism"/>.
        /// </returns>
        public Specialism GetItem(int id)
        {
            try
            {
                var item = this.dataUnitOfWork.GetItem<Specialism>(i => i.SpecialismId == id);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.SpecialismId, item.SpecialismTitle), "Get Specialism");
                return item;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Specialism with Id{{{0}}} cannot be found.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DataNotFoundException<Specialism>(id, e);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Specialism"/>.
        /// </returns>
        public Specialism Create(Specialism item, bool immediateSave)
        {
            try
            {
                item.SpecialismId = this.dataUnitOfWork.GetNextId<Specialism>(i => i.SpecialismId);
                if (this.AutoCreateScaffolding)
                {
                    this.notifier.Add<DebugNotification>("Attempting to build scaffold following creation of specialism", "Scaffold");
                    Scaffolding.CreateScaffold(item, this.dataUnitOfWork);
                }
                this.dataUnitOfWork.Create(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: ID:{0}/n Title:{1}", item.SpecialismId, item.SpecialismTitle), "Create Specialism");
                this.Save(immediateSave, new SuccessNotification { Message = "Specialism created.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create Specialism, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseCreateException<Specialism>(item.SpecialismId, e);
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
        /// The <see cref="Specialism"/>.
        /// </returns>
        public Specialism Update(Specialism item, bool immediateSave)
        {
            try
            {
                this.dataUnitOfWork.Update(item);
                this.notifier.Add<DebugNotification>(string.Format("Sucessfully updated Specialism: {{{0}}} - {1}", item.SpecialismId, item.SpecialismTitle), "Data Update");
                this.Save(immediateSave, new SuccessNotification { Message = "Specialism updated.", Title = "Save" });

            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to update Node, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseUpdateException<Specialism>(item.SpecialismId, e);
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
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.SpecialismId, item.SpecialismTitle), "Delete Specialism");
                this.Save(immediateSave, new SuccessNotification { Message = "Specialism deleted.", Title = "Save" });

            }
            catch (DataNotFoundException<Specialism>)
            {
                throw;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to delete Specialism, please try again.", "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseDeleteException<NodeSpecialism>(id, e);
            }
        }

        #endregion


    }
}
