// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Notifier.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The notifier.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Tickbox.Core.Cache;
using Tickbox.Core.Notifications.Definitions;

namespace Tickbox.Core.Notifications.Notifier
{
    public enum NotificationLevel
    {
        Verbose = -1,
        Default = 0,
        Info = 1,
        Save = 2,
        Error = 9
    }

    internal class NotfierVerbosityHolder
    {
        public NotfierVerbosityHolder()
        {
            this.Level = NotificationLevel.Verbose;
        }

        public NotificationLevel Level { get; set; }
    }

    /// <summary>
    /// The notifier.
    /// </summary>
    public class Notifier : INotify
    {
        /// <summary>
        /// The dictionary name.
        /// </summary>
        private const string DictionaryName = "Notifications";

        private const string Verbosity = "NotifyLevel";

        private readonly ICache<List<Notification>> notificationsCache;

        private readonly ICache<NotfierVerbosityHolder> notificationLevel;

        /// <summary>
        /// Initialises a new instance of the <see cref="Notifier"/> class.
        /// </summary>
        /// <exception cref="NoNullAllowedException">
        /// thrown if session is ever null.
        /// </exception>
        public Notifier(ICacheFactory cacheFactory)
        {
            this.notificationsCache = cacheFactory.CreateCache<List<Notification>>(DictionaryName);
            this.notificationLevel = cacheFactory.CreateCache<NotfierVerbosityHolder>(Verbosity);
        }

        #region Implementation of INotify

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        public ReadOnlyCollection<Notification> Notifications
        {
            get
            {
                return new ReadOnlyCollection<Notification>(
                            this.notificationsCache.RetrieveItem()
                            .Where(i => (int)i.Level >= (int)this.notificationLevel.RetrieveItem().Level)
                            .ToList());
            }
        }


        public void Add<T>(string message, string title) where T : Notification, new()
        {
            var item = this.notificationsCache.RetrieveItem();
            item.Add(new T { Message = message, Title = title });
            this.notificationsCache.SetItem(item);
        }

        public void Add(Notification notification)
        {
            var item = this.notificationsCache.RetrieveItem();
            item.Add(notification);
            this.notificationsCache.SetItem(item);
        }

        public void SetVerbosity(NotificationLevel level)
        {
            this.notificationLevel.SetItem(new NotfierVerbosityHolder { Level = level });
        }

        /// <summary>
        /// The purge.
        /// </summary>
        public void IsDirty()
        {
            this.notificationsCache.Reset();
        }

        #endregion
    }
}