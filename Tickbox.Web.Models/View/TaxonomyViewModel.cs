using System.ComponentModel.DataAnnotations;

namespace Tickbox.Web.Models.View
{
    /// <summary>
    ///     The taxonomy view model.
    /// </summary>
    public class TaxonomyViewModel
    {
        /// <summary>
        ///     Gets or sets the taxonomy id.
        /// </summary>
        [Required]
        public int TaxonomyId { get; set; }

        /// <summary>
        ///     Gets or sets the template id.
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is scaffold.
        /// </summary>
        public bool IsScaffold { get; set; }
    }
}