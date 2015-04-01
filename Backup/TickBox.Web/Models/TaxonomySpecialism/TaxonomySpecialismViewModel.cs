// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomySpecialismViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the TaxonomySpecialismViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TickBox.Web.Models.TaxonomySpecialism
{
    /// <summary>
    /// The taxonomy specialism view model.
    /// </summary>
    public class TaxonomySpecialismViewModel
    {
        /// <summary>
        /// Gets a value indicating whether is new.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return !this.TaxonomySpecialismId.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the taxonomy specialism id.
        /// </summary>
        public int? TaxonomySpecialismId { get; set; }

        /// <summary>
        /// Gets or sets the specialism id.
        /// </summary>
        public int SpecialismId { get; set; }

        /// <summary>
        /// Gets or sets the taxonomy id.
        /// </summary>
        public int TaxonomyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is scaffold.
        /// </summary>
        public bool IsScaffold { get; set; }
    }
}