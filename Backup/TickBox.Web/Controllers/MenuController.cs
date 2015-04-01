// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using PerpetuumSoft.Knockout;
using TickBox.Objects.Http;
using TickBox.Objects.Notifications;
using TickBox.Web.Manager;
using TickBox.Web.Models.Menu;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The menu controller.
    /// </summary>
    [TickboxAction]
    public class MenuController : KnockoutController
    {
        /// <summary>
        /// The notifier.
        /// </summary>
        private readonly INotify notifier;

        /// <summary>
        /// The menu wrapper.
        /// </summary>
        private readonly IMenuManager menuManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="notifier">
        /// The notifier.
        /// </param>
        /// <param name="menuManager">
        /// The menu manager.
        /// </param>
        public MenuController(INotify notifier, IMenuManager menuManager)
        {
            this.notifier = notifier;
            this.menuManager = menuManager;

        }

        /// <summary>
        /// The menu.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        public PartialViewResult Menu()
        {
            var vm = this.menuManager.GetMenu();
            return this.PartialView(vm);
        }
    }
}
