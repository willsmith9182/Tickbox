using System.Collections.Generic;
using System.Web.Http;
using Tickbox.Core.Notifications.Notifier;
using Tickbox.Web.Controllers.Extensions;
using Tickbox.Web.Models.View;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    ///     The home controller.
    /// </summary>
    [TickboxAction]
    public class HomeController : ApiController
    {
        /// <summary>
        ///     The notifier.
        /// </summary>
        private readonly INotify notifier;

        /// <summary>
        ///     Initialises a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="notifier">
        ///     The notifier.
        /// </param>
        /// <param name="menuManager">
        ///     The menu manager.
        /// </param>
        /// <param name="scaffoldWrapper">
        ///     The scaffolder.
        /// </param>
        public HomeController(INotify notifier)
        {
            this.notifier = notifier;
        }

        [HttpPost]
        public List<MenuViewModel> Index(MenuViewModel i)
        {
            return null; //();
        }
    }
}