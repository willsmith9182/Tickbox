using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions
{
    /// <summary>
    ///     The notification.
    /// </summary>
    public abstract class Notification
    {
        /// <summary>
        ///     Initialises a new instance of the <see cref="Notification" /> class.
        /// </summary>
        /// <param name="type">
        ///     The type.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        protected Notification(string preTitle, char spacer, bool hasClose, bool hasUndo, NotificationType type)
        {
            Type = type;
            HasUndo = hasUndo;
            HasClose = hasClose;
            Spacer = spacer;
            PreTitle = preTitle;
        }

        /// <summary>
        ///     The message.
        /// </summary>
        public string Message { get; set; }

        public string PreTitle { get; private set; }
        public string Title { get; set; }
        public char Spacer { get; private set; }
        public bool HasClose { get; private set; }
        public bool HasUndo { get; private set; }
        public NotificationLevel Level { get; protected set; }

        /// <summary>
        ///     The type.
        /// </summary>
        public NotificationType Type { get; private set; }
    }
}