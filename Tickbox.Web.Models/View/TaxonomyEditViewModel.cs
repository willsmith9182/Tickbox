using System.Collections.Generic;

namespace Tickbox.Web.Models.View
{
    /// <summary>
    ///     The taxonomy view model.
    /// </summary>
    public class TaxonomyEditViewModel : TaxonomyViewModel
    {
        /// <summary>
        ///     Initialises a new instance of the <see cref="TaxonomyEditViewModel" /> class.
        /// </summary>
        public TaxonomyEditViewModel()
        {
            // this.AvailableTemplates = new SelectList(new List<string>());
            AvailableSpecialisms = new List<SpecialismCheckBoxViewModel>();
        }

        /// <summary>
        ///     Gets or sets the available taxonomies.
        /// </summary>
        /// <summary>
        ///     Gets or sets the available specialisms.
        /// </summary>
        public List<SpecialismCheckBoxViewModel> AvailableSpecialisms { get; set; }
    }
}