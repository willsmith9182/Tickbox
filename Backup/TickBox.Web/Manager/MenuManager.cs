// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Objects.Http;
using TickBox.Web.Mapper;
using TickBox.Web.Models.Menu;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The menu manager.
    /// </summary>
    public class MenuManager : IMenuManager
    {

        /// <summary>
        /// The menu wrapper.
        /// </summary>
        private readonly IMenuWrapper menuWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="MenuManager"/> class.
        /// </summary>
        /// <param name="menuMapper">
        /// The menu mapper.
        /// </param>
        /// <param name="menuWrapper">
        /// The menu wrapper.
        /// </param>
        public MenuManager(IMenuWrapper menuWrapper)
        {
            this.menuWrapper = menuWrapper;
        }

        #region Implementation of IMenuManager

        /// <summary>
        /// The get menu.
        /// </summary>
        /// <returns>
        /// The <see cref="MenuViewModel"/>.
        /// </returns>
        public MenuViewModel GetMenu()
        {
            return new MenuViewModel
                       {
                           HasSpecialisms = this.menuWrapper.HasSpecialisms(),
                           HasTemplates = this.menuWrapper.HasTemplates(),
                           HasTaxonomies = this.menuWrapper.HasTaxonomies()
                       };
        }

        #endregion
    }
}