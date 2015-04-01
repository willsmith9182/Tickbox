// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContextProvider.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The ContextProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Data.Context;

namespace TickBox.Data
{
    /// <summary>
    /// The ContextProvider interface.
    /// </summary>
    public interface IContextProvider
    {
        /// <summary>
        /// The get context.
        /// </summary>
        /// <returns>
        /// The <see cref="TickBoxEntities"/>.
        /// </returns>
        TickBoxEntities GetContext();
    }
}
