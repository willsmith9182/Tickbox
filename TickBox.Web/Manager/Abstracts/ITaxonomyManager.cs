// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaxonomyManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The TaxonomyManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The TaxonomyManager interface.
    /// </summary>
    public interface ITaxonomyManager
    {
        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TaxonomyViewModel"/>.
        /// </returns>
        TaxonomyViewModel GetModel();

        IEnumerable<TaxonomyViewModel> GetAll();

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TaxonomyViewModel"/>.
        /// </returns>
        TaxonomyViewModel GetModel(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Create(TaxonomyViewModel model);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        void Update(TaxonomyViewModel model);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
