// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationExtensions.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The notification extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using TickBox.Objects.Http;

namespace TickBox.Objects.Notifications
{
    /// <summary>
    /// The notification extensions.
    /// </summary>
    public static class NotificationExtensions
    {
        /// <summary>
        /// The notifications. HTML extension method for ease access to notifications collections.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <returns>
        /// The <see cref="ReadOnlyCollection{Notification}"/>.
        /// </returns>
        public static ReadOnlyCollection<INotification> Notifications(this HtmlHelper htmlHelper)
        {
            var sessionHook = new SessionStoreBase(new HttpContextWrapper(HttpContext.Current));
            var cache = new CacheFactory(sessionHook);
            var notifier = new Notifier(cache);
            return notifier.Notifications;
        }
    }
}
