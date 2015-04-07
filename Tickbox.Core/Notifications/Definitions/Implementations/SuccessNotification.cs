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
    public class SuccessNotification : Notification
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public SuccessNotification()
            : base("Success", ':', true, false, NotificationType.Success)
        {
            this.Level =NotificationLevel.Save;
        }
    }
}
