// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomyWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The taxonomy wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using TickBox.Business.Scaffold;
using TickBox.Objects;
using TickBox.Objects.Notifications;

namespace TickBox.Business
{
    /// <summary>
    /// The taxonomy wrapper.
    /// </summary>
    public class TaxonomyWrapper : WrapperBase, ITaxonomyWrapper
    {
        #region Implementation of ITaxonomyWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public TaxonomyWrapper(IComitable dataUnitOfWork, INotify notifier)
            : base(dataUnitOfWork, notifier)
        {
        }

        public IEnumerable<Taxonomy> GetAll()
        {
            var items = this.dataUnitOfWork.GetAll<Taxonomy>();
            this.notifier.Add<DebugNotification>(string.Format("Total items retrieved:{0}", items.Count()), "Get All Taxonomies");
            return items;
        }

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public Taxonomy CreateNew()
        {
            return new Taxonomy
                       {
                           TaxonomyId = -1
                       };
        }

        /// <summary>
        /// The get taxonomy.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public Taxonomy GetItem(int id)
        {
            try
            {
                var item = this.dataUnitOfWork.GetItem<Taxonomy>(i => i.TaxonomyId == id);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.TaxonomyId, item.Title), "Get Taxonomy");
                return item;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Taxonomy with Id{{{0}}} cannot be found.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DataNotFoundException<Taxonomy>(id, e);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public Taxonomy Create(Taxonomy item, bool immediateSave)
        {
            try
            {
                item.TaxonomyId = this.dataUnitOfWork.GetNextId<Taxonomy>(i => i.TaxonomyId);

                if (this.AutoCreateScaffolding)
                {
                    this.notifier.Add<DebugNotification>("Attempting to build scaffold following creation of taxonomy", "Scaffold");
                    Scaffolding.CreateScaffold(item, this.dataUnitOfWork);
                }
                this.dataUnitOfWork.Create(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: ID:{0}/n Title:{1}", item.TaxonomyId, item.Title), "Create Taxonomy");
                this.Save(immediateSave, new SuccessNotification { Message = "Taxonomy created.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create Taxonomy, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseCreateException<Taxonomy>(item.TaxonomyId, e);
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
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public Taxonomy Update(Taxonomy item, bool immediateSave)
        {
            try
            {
                this.dataUnitOfWork.Update(item);
                this.notifier.Add<DebugNotification>(string.Format("Sucessfully updated Taxonomy: {{{0}}} - {1}", item.TaxonomyId, item.Title), "Data Update");
                this.Save(immediateSave, new SuccessNotification { Message = "Taxonomy updated.", Title = "Save" });

            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to update Taxonomy, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseUpdateException<Taxonomy>(item.TaxonomyId, e);
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
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Title: {1}", item.TaxonomyId, item.Title), "Delete Taxonomy");
                this.Save(immediateSave, new SuccessNotification { Message = "Taxonomy deleted.", Title = "Save" });

            }
            catch (DataNotFoundException<Taxonomy>)
            {
                throw;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to delete Taxonomy, please try again.", "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseDeleteException<Taxonomy>(id, e);
            }
        }

        #endregion
    }
}
