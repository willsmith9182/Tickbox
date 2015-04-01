// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityListGenerator.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The entity list generator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects.EntityList
{
    /// <summary>
    /// The entity list generator.
    /// </summary>
    /// <typeparam name="TPoco">
    /// the poco type
    /// </typeparam>
    public class EntityListGenerator<TPoco> : IEntityListGenerator<TPoco> where TPoco : class, IKeyComparable<TPoco>, IEquatable<TPoco>
    {
        #region Implementation of IEntityListGenerator<TPoco>

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
        public IEntityList<TPoco> Generate(ICollection<TPoco> mappedItems, ICollection<TPoco> databaseItems)
        {
            var create = mappedItems.Where(mi => !databaseItems.Any(mi.KeysMatch)).ToList();
            var update = mappedItems.Where(mi => databaseItems.Any(di => mi.KeysMatch(di) && mi.Equals(di))).ToList();
            var delete = databaseItems.Where(di => !mappedItems.Any(di.KeysMatch)).ToList();

            return new EntityList<TPoco>(create, update, delete);
        }

        #endregion
    }
}
