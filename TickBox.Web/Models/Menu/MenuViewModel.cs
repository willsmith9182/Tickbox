// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using TickBox.Web.Models.Specialism;
using TickBox.Web.Models.Taxonomy;
using TickBox.Web.Models.Template;

namespace TickBox.Web.Models.Menu
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