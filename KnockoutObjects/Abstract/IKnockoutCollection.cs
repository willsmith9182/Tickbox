// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnockoutCollection.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Provides basic functionality for a Knockout View Model Collection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KnockoutObjects
{
    /// <summary>
    /// Provides basic functionality for a Knockout View Model Collection 
    /// </summary>
    public interface IKnockoutCollection
    {
        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Gets a value indicating whether has changes.
        /// </summary>
        bool HasChanges { get; }

        /// <summary>
        /// Gets a value indicating whether has been saved.
        /// </summary>
        bool HasBeenSaved { get; }

        /// <summary>
        /// Gets a value indicating whether is in edit.
        /// </summary>
        bool IsInEdit { get; }

        /// <summary>
        /// The update collection state.
        /// </summary>
        /// <param name="updateType">
        /// The update Type.
        /// </param>
        void UpdateCollectionState(Enums.ModelUpdateType updateType);
    }
}
