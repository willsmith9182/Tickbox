// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Taxonomy view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Mapper.Mappings.Taxonomy
{
    /// <summary>
    /// The Taxonomy view model.
    /// </summary>
    public class Basic : IMappingProvider<Objects.Taxonomy, TaxonomyViewModel>
    {
        #region Implementation of IMappingProvider<Taxonomy,TaxonomyViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public Objects.Taxonomy CreateObject(TaxonomyViewModel item)
        {
            return new Objects.Taxonomy
                       {
                           IsScaffold = item.IsScaffold,
                           TaxonomyId = item.TaxonomyId,
                           TemplateId = item.TemplateId,
                           Title = item.Title
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Taxonomy"/>.
        /// </returns>
        public TaxonomyViewModel CreateObject(Objects.Taxonomy item)
        {
            return new TaxonomyViewModel
                       {
                           IsScaffold = item.IsScaffold,
                           TaxonomyId = item.TaxonomyId,
                           TemplateId = item.TemplateId,
                           Title = item.Title
                       };
        }

        #endregion
    }
}