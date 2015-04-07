// -----------------------------------------------------------------------
// <copyright file="ErrorNotification.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions.Implementations
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ErrorNotification : Notification
    {
        public ErrorNotification()
            : base("Error", '|', false, false, NotificationType.Error)
        {
            this.Level = NotificationLevel.Error;
        }
    }
}
