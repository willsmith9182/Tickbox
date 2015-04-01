// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The template view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;

namespace TickBox.Web.Models.Template
{
    /// <summary>
    /// The template view model.
    /// </summary>
    public class TemplateViewModel
    {
       /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

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