// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityList.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The EntityList interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace TickBox.Objects.EntityList
{
    /// <summary>
    /// The EntityList interface.
    /// </summary>
    /// <typeparam name="TPoco">
    /// the poco to split into create update delete lists
    /// </typeparam>
    public interface IEntityList<TPoco> where TPoco : class
    {
        /// <summary>
        /// Gets a value indicating whether there are any actual changes in any one of the <see cref="IEntityList{TPoco}.ToCreate"/>, <see cref="IEntityList{TPoco}.ToUpdate"/> or <see cref="IEntityList{TPoco}.ToDelete"/> lists.
        /// </summary>
        bool Any { get; }

        /// <summary>
        /// Gets the to create.
        /// </summary>
        ReadOnlyCollection<TPoco> ToCreate { get; }

        /// <summary>
        /// Gets the to update.
        /// </summary>
        ReadOnlyCollection<TPoco> ToUpdate { get; }

        /// <summary>
        /// Gets the to delete.
        /// </summary>
        ReadOnlyCollection<TPoco> ToDelete { get; }
    }
}
