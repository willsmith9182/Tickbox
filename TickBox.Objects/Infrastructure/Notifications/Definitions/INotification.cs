
namespace TickBox.Objects.Notifications
{
    public interface INotification
    {
        /// <summary>
        /// The message.
        /// </summary>
        string Message { get; set; }

        string PreTitle { get; }
        string Title { get; set; }
        char Spacer { get; }
        bool HasClose { get; }
        bool HasUndo { get; }

        /// <summary>
        /// The type.
        /// </summary>
        NotificationType Type { get; }

        NotificationLevel Level { get; }
    }
}
