using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Tickbox.Core.Cache;
using Tickbox.Core.Notifications.Definitions;

namespace Tickbox.Core.Notifications.Notifier
{
    /// <summary>
    ///     The notifier.
    /// </summary>
    public class Notifier : INotify
    {
        /// <summary>
        ///     The dictionary name.
        /// </summary>
        private const string DictionaryName = "Notifications";

        private const string Verbosity = "NotifyLevel";
        private readonly ICache<NotfierVerbosityHolder> notificationLevel;
        private readonly ICache<List<Notification>> notificationsCache;

        /// <summary>
        ///     Initialises a new instance of the <see cref="Notifier" /> class.
        /// </summary>
        /// <exception cref="NoNullAllowedException">
        ///     thrown if session is ever null.
        /// </exception>
        public Notifier(ICacheFactory cacheFactory)
        {
            notificationsCache = cacheFactory.CreateCache<List<Notification>>(DictionaryName);
            notificationLevel = cacheFactory.CreateCache<NotfierVerbosityHolder>(Verbosity);
        }

        #region Implementation of INotify

        /// <summary>
        ///     Gets the notifications.
        /// </summary>
        public ReadOnlyCollection<Notification> Notifications
        {
            get
            {
                return new ReadOnlyCollection<Notification>(
                    notificationsCache.RetrieveItem()
                        .Where(i => (int) i.Level >= (int) notificationLevel.RetrieveItem().Level)
                        .ToList());
            }
        }


        public void Add<T>(string message, string title) where T : Notification, new()
        {
            var item = notificationsCache.RetrieveItem();
            item.Add(new T {Message = message, Title = title});
            notificationsCache.SetItem(item);
        }

        public void Add(Notification notification)
        {
            var item = notificationsCache.RetrieveItem();
            item.Add(notification);
            notificationsCache.SetItem(item);
        }

        public void SetVerbosity(NotificationLevel level)
        {
            notificationLevel.SetItem(new NotfierVerbosityHolder {Level = level});
        }

        /// <summary>
        ///     The purge.
        /// </summary>
        public void IsDirty()
        {
            notificationsCache.Reset();
        }

        #endregion
    }
}