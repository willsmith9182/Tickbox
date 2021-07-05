namespace Tickbox.Web.Models.View
{
    /// <summary>
    ///     The tree node view model.
    /// </summary>
    public class TreeNodeViewModel
    {
        /// <summary>
        ///     Gets a value indicating whether is root node.
        /// </summary>
        public bool IsRootNode
        {
            get { return ParentTreeNodeId == null; }
        }

        /// <summary>
        ///     Gets or sets the taxonomy id.
        /// </summary>
        public int TaxonomyId { get; set; }

        /// <summary>
        ///     Gets or sets the tree node id.
        /// </summary>
        public int TreeNodeId { get; set; }

        /// <summary>
        ///     Gets or sets the parent tree node id.
        /// </summary>
        public int? ParentTreeNodeId { get; set; }

        /// <summary>
        ///     Gets or sets the node id.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is scaffold.
        /// </summary>
        public bool IsScaffold { get; set; }
    }
}