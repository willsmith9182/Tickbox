namespace Tickbox.Core.Notifications.Notifier
{
    internal class NotfierVerbosityHolder
    {
        public NotfierVerbosityHolder()
        {
            Level = NotificationLevel.Verbose;
        }

        public NotificationLevel Level { get; set; }
    }
}