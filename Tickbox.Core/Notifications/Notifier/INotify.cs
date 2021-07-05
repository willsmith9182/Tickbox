using System.Collections.ObjectModel;
using Tickbox.Core.Notifications.Definitions;

namespace Tickbox.Core.Notifications.Notifier
{
    /// <summary>
    ///     The Notify interface.
    /// </summary>
    public interface INotify
    {
        /// <summary>
        ///     Gets the notifications.
        /// </summary>
        ReadOnlyCollection<Notification> Notifications { get; }

        void Add<T>(string message, string title) where T : Notification, new();
        void Add(Notification notification);
        void SetVerbosity(NotificationLevel level);

        /// <summary>
        ///     The is dirty.
        /// </summary>
        void IsDirty();
    }
}