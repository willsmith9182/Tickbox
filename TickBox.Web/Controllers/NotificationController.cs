// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The notification controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Mvc;
using PerpetuumSoft.Knockout;
using TickBox.Objects.Notifications;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The notification controller.
    /// </summary>
    [TickboxAction]
    public class NotificationController : KnockoutController
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
        [HttpGet]
        public PartialViewResult Notifications()
        {
            var result = this.PartialView(this.notifier.Notifications);
            this.notifier.IsDirty();
            return result;
        }

        /// <summary>
        /// The notifications json.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult NotificationsJson()
        {
            var result = this.PartialView("Notifications", this.notifier.Notifications);
            this.notifier.IsDirty();
            return result;
        }

        [HttpPost]
        public JsonResult SetNotificationLevel(int level)
        {
            var levelEnum = (NotificationLevel)level;
            this.notifier.SetVerbosity(levelEnum);
            return this.Json(new { Success = true });
        }
    }
}
