// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Mapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace TickBox.Objects
{
    /// <summary>
    /// The Mapper interface.
    /// </summary>
    /// <typeparam name="TData">
    /// map from poco
    /// </typeparam>
    /// <typeparam name="TView">
    /// map to view model
    /// </typeparam>
    public interface IMapper<TData, TView>
        where TData : class, new()
        where TView : class, new()
    {
        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TView"/>.
        /// </returns>
        TView Map(TData item);

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="ICollection{TTo}"/>.
        /// </returns>
        ICollection<TView> Map(ICollection<TData> items);

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TView"/>.
        /// </returns>
        TData Reverse(TView item);

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="ICollection{TTo}"/>.
        /// </returns>
        ICollection<TData> Reverse(ICollection<TView> items);
    }
}
