using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions.Implementations
{
    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class InfoNotification : Notification
    {
        public InfoNotification()
            : base("Info", '-', true, true, NotificationType.Info)
        {
            Level = NotificationLevel.Info;
        }
    }
}