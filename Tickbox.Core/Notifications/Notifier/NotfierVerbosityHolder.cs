namespace Tickbox.Core.Notifications.Notifier
{
    internal class NotfierVerbosityHolder
    {
        public NotfierVerbosityHolder()
        {
            this.Level = NotificationLevel.Verbose;
        }

        public NotificationLevel Level { get; set; }
    }
}