// -----------------------------------------------------------------------
// <copyright file="DebugNotification.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions.Implementations
{
    /// <summary>
    /// TODO: Update summary.
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
            this.Level = highLevel ? NotificationLevel.Default : NotificationLevel.Verbose;
        }
    }
}
