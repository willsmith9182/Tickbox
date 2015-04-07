// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialismViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tickbox.Web.Models.View
{
    /// <summary>
    /// The specialism view model.
    /// </summary>
    public class SpecialismViewModel
    {
        /// <summary>
        /// Gets or sets the specialism id.
        /// </summary>
        public int SpecialismId { get; set; }

        /// <summary>
        /// Gets or sets the specialism title.
        /// </summary>
        public string SpecialismTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is scaffold.
        /// </summary>
        public bool IsScaffold { get; set; }
    }
}