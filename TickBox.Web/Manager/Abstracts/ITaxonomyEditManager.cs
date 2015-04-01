// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaxonomyEditManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The TaxonomyEditManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The TaxonomyEditManager interface.
    /// </summary>
    public interface ITaxonomyEditManager
    {
        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TaxonomyEditViewModel"/>.
        /// </returns>
        TaxonomyEditViewModel GetModel();

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TaxonomyEditViewModel"/>.
        /// </returns>
        TaxonomyEditViewModel GetModel(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Create(TaxonomyEditViewModel model);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        void Update(TaxonomyEditViewModel model);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
