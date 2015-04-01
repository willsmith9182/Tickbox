// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITemplateWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The TemplateWrapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Mvc;

namespace TickBox.Objects
{
    /// <summary>
    /// The TemplateWrapper interface.
    /// </summary>
    public interface ITemplateWrapper :IWrapper<Template>
    {
        /// <summary>
        /// The create select list.
        /// </summary>
        /// <returns>
        /// The <see cref="SelectList"/>.
        /// </returns>
        SelectList CreateSelectList();

        /// <summary>
        /// The create select list.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="SelectList"/>.
        /// </returns>
        SelectList CreateSelectList(ICollection<Template> items);
    }
}
