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
    public class Edit : IMappingProvider<Objects.Taxonomy, TaxonomyEditViewModel>
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
        public Objects.Taxonomy CreateObject(TaxonomyEditViewModel item)
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
        public TaxonomyEditViewModel CreateObject(Objects.Taxonomy item)
        {
            return new TaxonomyEditViewModel
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