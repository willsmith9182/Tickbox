// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Notification.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The notification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Core.Notifications.Definitions
{
    /// <summary>
    /// The notification.
    /// </summary>
    public abstract class Notification
    {
        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        public string PreTitle { get; private set; }

        public string Title { get; set; }

        public char Spacer { get; private set; }

        public bool HasClose { get; private set; }

        public bool HasUndo { get; private set; }

        public NotificationLevel Level { get; protected set; }

        /// <summary>
        /// The type.
        /// </summary>
        public NotificationType Type { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        protected Notification(string preTitle, char spacer, bool hasClose, bool hasUndo, NotificationType type)
        {
            this.Type = type;
            this.HasUndo = hasUndo;
            this.HasClose = hasClose;
            this.Spacer = spacer;
            this.PreTitle = preTitle;

        }
    }
}