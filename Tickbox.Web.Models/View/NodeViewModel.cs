using System.ComponentModel.DataAnnotations;

namespace Tickbox.Web.Models.View
{
    /// <summary>
    ///     The node view model.
    /// </summary>
    public class NodeViewModel
    {
        /// <summary>
        ///     Gets or sets the node id.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        ///     Gets or sets the node title.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "Title can be no more than 100 characters.")]
        public string NodeTitle { get; set; }

        /// <summary>
        ///     Gets or sets the node description.
        /// </summary>
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "You must provide a description")]
        public string NodeDescription { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether allow multi select children.
        /// </summary>
        public bool AllowMultiSelectChildren { get; set; }

        public int TaxonomyId { get; set; }
        public int? ParentId { get; set; }

        public bool IsRootNode
        {
            get { return ParentId == null; }
        }
    }
}