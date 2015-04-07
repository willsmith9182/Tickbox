// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The notification controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Mvc;
using Tickbox.Core.Notifications.Notifier;
using Tickbox.Web.Controllers.Extensions;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    /// The notification controller.
    /// </summary>
    [TickboxAction]
    public class NotificationController : ApiController
    {
        /// <summary>
        /// The notifier.
        /// </summary>
        private readonly INotify notifier;

        /// <summary>
        /// Initialises a new instance of the <see cref="NotificationController"/> class.
        /// </summary>
        /// <param name="notifier">
        /// The notifier.
        /// </param>
        public NotificationController(INotify notifier)
        {
            this.notifier = notifier;
        }

        /// <summary>
        /// The notifications.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public PartialViewResult Notifications()
        {
            return null;

        }

        /// <summary>
        /// The notifications json.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult NotificationsJson()
        {
            return null;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult SetNotificationLevel(int level)
        {
            var levelEnum = (NotificationLevel)level;
            this.notifier.SetVerbosity(levelEnum);

            return null; //this.Json(new { Success = true });
        }
    }
}
