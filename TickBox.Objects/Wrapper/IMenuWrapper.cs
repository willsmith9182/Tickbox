// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMenuWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The MenuWrapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace TickBox.Objects
{
    /// <summary>
    /// The MenuWrapper interface.
    /// </summary>
    public interface IMenuWrapper
    {
        /// <summary>
        /// The get taxonomies.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Taxonomy}"/>.
        /// </returns>
        bool HasTaxonomies();

        /// <summary>
        /// The get templates.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Template}"/>.
        /// </returns>
        bool HasTemplates();

        /// <summary>
        /// The get specialisms.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Specialism}"/>.
        /// </returns>
        bool HasSpecialisms();
    }
}
