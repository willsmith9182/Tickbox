// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITemplateManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The TemplateManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Web.Models.Template;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The TemplateManager interface.
    /// </summary>
    /// <typeparam name="TModelType">
    /// version of view model to use
    /// </typeparam>
    public interface ITemplateManager<TModelType>
    {
        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TemplateViewModel"/>.
        /// </returns>
        TModelType GetModel();

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TemplateViewModel"/>.
        /// </returns>
        TModelType GetModel(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Create(TModelType model);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        void Update(TModelType model);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
