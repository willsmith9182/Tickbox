// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The template wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using TickBox.Objects;
using TickBox.Objects.Notifications;

namespace TickBox.Business
{
    /// <summary>
    /// The template wrapper.
    /// </summary>
    public class TemplateWrapper : WrapperBase, ITemplateWrapper
    {
        #region Implementation of ITemplateWrapper

        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        public TemplateWrapper(IComitable dataUnitOfWork, INotify notifier) : base(dataUnitOfWork, notifier)
        {
        }

        public IEnumerable<Template> GetAll()
        {
            var items = this.dataUnitOfWork.GetAll<Template>();
            this.notifier.Add<DebugNotification>(string.Format("Total items retrieved:{0}", items.Count()), "Get All Templates");
            return items;
        }

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="Template"/>.
        /// </returns>
        public Template CreateNew()
        {
            return new Template
                       {
                           TemplateId = -1,
                           DocumentLink = string.Empty,
                           IsScaffold = false,
                           Name = string.Empty,
                           Taxonomies = new List<Taxonomy>()
                       };
        }

        /// <summary>
        /// The get template.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Template"/>.
        /// </returns>
        public Template GetItem(int id)
        {
            try
            {
                var item = this.dataUnitOfWork.GetItem<Template>(i => i.TemplateId == id);
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Name: {1}", item.TemplateId, item.Name), "Get Template");
                return item;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>(string.Format("Template with Id{{{0}}} cannot be found.", id), "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DataNotFoundException<Template>(id, e);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Template"/>.
        /// </returns>
        public Template Create(Template item, bool immediateSave)
        {
            try
            {
                item.TemplateId = this.dataUnitOfWork.GetNextId<Template>(i => i.TemplateId);
                if (this.AutoCreateScaffolding)
                {
                    this.notifier.Add<DebugNotification>("Attempting to build scaffold following creation of Template", "Scaffold");
                    Scaffolding.CreateScaffold(item, this.dataUnitOfWork);

                }
                this.dataUnitOfWork.Create(item);
                this.notifier.Add<DebugNotification>(string.Format("Properties: ID:{0}/n Name:{1}", item.TemplateId, item.TemplateId), "Create Template");
                this.Save(immediateSave, new SuccessNotification { Message = "Taxonomy created.", Title = "Save" });
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to create Template, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseCreateException<Template>(item.TemplateId, e);
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
        /// The <see cref="Template"/>.
        /// </returns>
        public Template Update(Template item, bool immediateSave)
        {
            try
            {
                this.dataUnitOfWork.Update(item);
                this.notifier.Add<DebugNotification>(string.Format("Sucessfully updated Template: {{{0}}} - {1}", item.TemplateId, item.Name), "Data Update");
                this.Save(immediateSave, new SuccessNotification { Message = "Template updated.", Title = "Save" });

            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to update Template, please try again.", "Data Error");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseUpdateException<Template>(item.TemplateId, e);
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
                this.notifier.Add<DebugNotification>(string.Format("Properties: Id:{0} /n Name: {1}", item.TemplateId, item.Name), "Delete Template");
                this.Save(immediateSave, new SuccessNotification { Message = "Template deleted.", Title = "Save" });

            }
            catch (DataNotFoundException<Template>)
            {
                throw;
            }
            catch (Exception e)
            {
                this.notifier.Add<ErrorNotification>("Unable to delete Template, please try again.", "Data Not Found");
                this.notifier.Add<DebugNotification>(e.Message, "Exception Details");
                throw new DatabaseDeleteException<Template>(id, e);
            }
        }

        #endregion

        #region Implementation of ITemplateWrapper

        /// <summary>
        /// The create select list.
        /// </summary>
        /// <returns>
        /// The <see cref="SelectList"/>.
        /// </returns>
        public SelectList CreateSelectList()
        {
            return this.CreateSelectList(this.dataUnitOfWork.GetAll<Template>().ToList());
        }

        /// <summary>
        /// The create select list.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="System.Web.Mvc.SelectList"/>.
        /// </returns>
        public SelectList CreateSelectList(ICollection<Template> items)
        {
            return new SelectList(
                items.Select(tm => new SelectListItem
                                                {
                                                    Text = tm.Name,
                                                    Value = tm.TemplateId.ToString(CultureInfo.InvariantCulture)
                                                }),
                                                "Value",
                                                "Text");
        }

        #endregion
    }
}
