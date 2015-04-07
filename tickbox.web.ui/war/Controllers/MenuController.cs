// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Web.Http;
using System.Web.Mvc;
using Tickbox.Core.Notifications.Notifier;
using Tickbox.Web.Controllers.Extensions;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    /// The menu controller.
    /// </summary>
    [TickboxAction]
    public class MenuController : ApiController
    {
        /// <summary>
        /// The notifier.
        /// </summary>
        private readonly INotify notifier;



        /// <summary>
        /// Initialises a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="notifier">
        /// The notifier.
        /// </param>
        /// <param name="menuManager">
        /// The menu manager.
        /// </param>
        public MenuController(INotify notifier)
        {
            this.notifier = notifier;
        }

        /// <summary>
        /// The menu.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        public PartialViewResult Menu()
        {
            //var vm = this.menuManager.GetMenu();
            return null; //null);//vm);
        }
    }
}
