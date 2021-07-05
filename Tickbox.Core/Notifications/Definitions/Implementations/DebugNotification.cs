using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions.Implementations
{
    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class DebugNotification : Notification
    {
        public DebugNotification()
            : this(false)
        {
        }

        public DebugNotification(bool highLevel)
            : base("Debug", '~', true, false, NotificationType.Debug)
        {
            Level = highLevel ? NotificationLevel.Default : NotificationLevel.Verbose;
        }
    }
}