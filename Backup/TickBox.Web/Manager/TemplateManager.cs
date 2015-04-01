// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The template manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Template;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The template manager.
    /// </summary>
    public class TemplateManager : ITemplateManager<TemplateViewModel>
    {
        /// <summary>
        /// The template mapper.
        /// </summary>
        private readonly IMapper<Template, TemplateViewModel> templateMapper;

        /// <summary>
        /// The template wrapper.
        /// </summary>
        private readonly ITemplateWrapper templateWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="TemplateManager"/> class.
        /// </summary>
        /// <param name="templateMapper">
        /// The template mapper.
        /// </param>
        /// <param name="templateWrapper">
        /// The template wrapper.
        /// </param>
        public TemplateManager(IMapper<Template, TemplateViewModel> templateMapper, ITemplateWrapper templateWrapper)
        {
            this.templateMapper = templateMapper;
            this.templateWrapper = templateWrapper;
        }

        #region Implementation of ITemplateManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TemplateViewModel"/>.
        /// </returns>
        public TemplateViewModel GetModel()
        {
            return this.templateMapper.Map(this.templateWrapper.CreateNew());
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TemplateViewModel"/>.
        /// </returns>
        public TemplateViewModel GetModel(int id)
        {
            return this.templateMapper.Map(this.templateWrapper.GetItem(id));
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
        public int Create(TemplateViewModel model)
        {
            return this.templateWrapper.Create(this.templateMapper.Reverse(model), true).TemplateId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(TemplateViewModel model)
        {
            this.templateWrapper.Update(this.templateMapper.Reverse(model), true);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.templateWrapper.Delete(id, true);
        }

        #endregion
    }
}