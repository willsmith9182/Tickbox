// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomyEditViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The taxonomy edit view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Mvc;
using TickBox.Web.Models.Specialism;

namespace TickBox.Web.Models.Taxonomy
{
    /// <summary>
    /// The taxonomy view model.
    /// </summary>
    public class TaxonomyEditViewModel : TaxonomyViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TaxonomyEditViewModel"/> class.
        /// </summary>
        public TaxonomyEditViewModel()
        {
            this.AvailableTemplates = new SelectList(new List<string>());
            this.AvailableSpecialisms= new List<SpecialismCheckBoxViewModel>();
        }

        /// <summary>
        /// Gets or sets the available taxonomies.
        /// </summary>
        public SelectList AvailableTemplates { get; set; }

        /// <summary>
        /// Gets or sets the available specialisms.
        /// </summary>
        public List<SpecialismCheckBoxViewModel> AvailableSpecialisms { get; set; }
    }
}