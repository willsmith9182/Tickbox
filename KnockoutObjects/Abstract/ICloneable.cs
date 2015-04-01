// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICloneable.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Cloneable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KnockoutObjects
{
    /// <summary>
    /// The Cloneable interface.
    /// </summary>
    /// <typeparam name="TModelType">
    /// The model type
    /// </typeparam>
    public interface ICloneable<out TModelType>
    {
        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="TModelType"/>.
        /// </returns>
        TModelType Clone();
    }
}
