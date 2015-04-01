// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMappingProvider.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The MappingProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TickBox.Objects
{
    /// <summary>
    /// The MappingProvider interface.
    /// </summary>
    /// <typeparam name="TData">
    /// the poco type
    /// </typeparam>
    /// <typeparam name="TView">
    /// the view model type
    /// </typeparam>
    public interface IMappingProvider<TData, TView>
        where TData : class
        where TView : class
    {
        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TData"/>.
        /// </returns>
        TData CreateObject(TView item);

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TView"/>.
        /// </returns>
        TView CreateObject(TData item);
    }
}
