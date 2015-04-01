// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotify.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Notify interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace TickBox.Objects.Notifications
{
    /// <summary>
    /// The Notify interface.
    /// </summary>
    public interface INotify
    {
        /// <summary>
        /// Gets the notifications.
        /// </summary>
        ReadOnlyCollection<INotification> Notifications { get; }

        void Add<T>(string message, string title) where T : INotification, new();

        void Add(INotification notification);

        void SetVerbosity(NotificationLevel level);

        /// <summary>
        /// The is dirty.
        /// </summary>
        void IsDirty();
    }
}
