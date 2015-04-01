// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityListGenerator.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The EntityListGenerator interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace TickBox.Objects.EntityList
{
    /// <summary>
    /// The EntityListGenerator interface.
    /// </summary>
    /// <typeparam name="TPoco">
    /// the poco to create lists 
    /// </typeparam>
    public interface IEntityListGenerator<TPoco> where TPoco : class, IKeyComparable<TPoco>, IEquatable<TPoco>
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="mappedItems">
        /// The mapped items.
        /// </param>
        /// <param name="databaseItems">
        /// The database items.
        /// </param>
        /// <returns>
        /// The <see cref="IEntityList{TPoco}"/>.
        /// </returns>
        IEntityList<TPoco> Generate(ICollection<TPoco> mappedItems, ICollection<TPoco> databaseItems);
    }
}
