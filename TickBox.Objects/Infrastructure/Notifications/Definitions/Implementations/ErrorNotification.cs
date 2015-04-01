// -----------------------------------------------------------------------
// <copyright file="ErrorNotification.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TickBox.Objects.Notifications
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
