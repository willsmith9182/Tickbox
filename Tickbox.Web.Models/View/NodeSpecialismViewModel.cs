// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeSpecialismViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the NodeSpecialismViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Tickbox.Web.Models.View
{
    /// <summary>
    /// The node specialism model.
    /// </summary>
    public class NodeSpecialismViewModel
    {
        /// <summary>
        /// Gets or sets the node specialism id.
        /// </summary>
        public int NodeSpecialismId { get; set; }

        /// <summary>
        /// Gets or sets the node id.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// Gets or sets the specialism id.
        /// </summary>
        public int SpecialismId { get; set; }

        /// <summary>
        /// Gets or sets the sequence order.
        /// </summary>
        public int SequenceOrder { get; set; }

        /// <summary>
        /// Gets or sets the guidelines.
        /// </summary>
        public string Guidelines { get; set; }

        /// <summary>
        /// Gets or sets the document link.
        /// </summary>
        public string DocumentLink { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is scaffold.
        /// </summary>
        public bool IsScaffold { get; set; }
    }
}