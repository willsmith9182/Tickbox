// -----------------------------------------------------------------------
// <copyright file="InfoNotification.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TickBox.Objects.Notifications
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class InfoNotification : Notification
    {
        public InfoNotification()
            : base( "Info",  '-', true, true, NotificationType.Info)
        {
            this.Level =NotificationLevel.Info;
        }
    }
}
