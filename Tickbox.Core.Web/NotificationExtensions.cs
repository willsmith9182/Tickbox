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
using Tickbox.Core.Notifications.Definitions;
using Tickbox.Core.Web.Cache;
using Tickbox.Core.Web.Session;

namespace Tickbox.Core.Web
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
        public static ReadOnlyCollection<Notification> Notifications(this HtmlHelper htmlHelper)
        {
            var sessionHook = new SessionStoreBase(new HttpContextWrapper(HttpContext.Current));
            var cache = new WebCacheFactory(sessionHook);
            var notifier = new Notifications.Notifier.Notifier(cache);
            return notifier.Notifications;
        }
    }
}
