// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMenuManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The MenuManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Web.Models.Menu;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The MenuManager interface.
    /// </summary>
    public interface IMenuManager
    {
        /// <summary>
        /// The get menu.
        /// </summary>
        /// <returns>
        /// The <see cref="MenuViewModel"/>.
        /// </returns>
        MenuViewModel GetMenu();
    }
}
