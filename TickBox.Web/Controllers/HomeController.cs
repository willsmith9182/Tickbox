// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using PerpetuumSoft.Knockout;
using TickBox.Objects.Notifications;
using TickBox.Web.Manager;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The home controller.
    /// </summary>
    [TickboxAction]
    public class HomeController : KnockoutController
    {
        /// <summary>
        /// The notifier.
        /// </summary>
        private readonly INotify notifier;

        /// <summary>
        /// The menu wrapper.
        /// </summary>
        private readonly IMenuManager menuManager;

        private readonly IScaffoldManager scaffoldManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="notifier">
        /// The notifier.
        /// </param>
        /// <param name="menuManager">
        /// The menu manager.
        /// </param>
        /// <param name="scaffoldWrapper">
        /// The scaffolder.
        /// </param>
        public HomeController(INotify notifier, IMenuManager menuManager, IScaffoldManager scaffoldManager)
        {
            this.notifier = notifier;
            this.menuManager = menuManager;
            this.scaffoldManager = scaffoldManager;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            this.scaffoldManager.CreateDefaultScaffold();
            return this.View();
        }
    }
}
