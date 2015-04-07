// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tickbox.Web.Models.View
{
    /// <summary>
    /// The menu model.
    /// </summary>
    public class MenuViewModel
    {
        public bool HasTemplates { get; set; }

        public bool HasSpecialisms { get; set; }

        public bool HasTaxonomies { get; set; }
    }
}