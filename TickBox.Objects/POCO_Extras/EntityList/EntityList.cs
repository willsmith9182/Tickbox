// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityList.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The entity list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TickBox.Objects.EntityList
{
    /// <summary>
    /// The entity list.
    /// </summary>
    /// <typeparam name="TPoco">
    /// the poco type in the list
    /// </typeparam>
    public class EntityList<TPoco> : IEntityList<TPoco> where TPoco : class
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EntityList{TPoco}"/> class.
        /// </summary>
        /// <param name="creates">
        /// The creates.
        /// </param>
        /// <param name="updates">
        /// The updates.
        /// </param>
        /// <param name="deletes">
        /// The deletes.
        /// </param>
        public EntityList(IList<TPoco> creates, IList<TPoco> updates, IList<TPoco> deletes)
        {
            this.ToCreate = new ReadOnlyCollection<TPoco>(creates);
            this.ToUpdate = new ReadOnlyCollection<TPoco>(updates);
            this.ToDelete = new ReadOnlyCollection<TPoco>(deletes);
            this.Any = creates.Any() || updates.Any() || deletes.Any();
        }

        #region Implementation of IEntityList<TPoco>

        /// <summary>
        /// Gets a value indicating whether any.
        /// </summary>
        public bool Any { get; private set; }

        /// <summary>
        /// Gets the to create.
        /// </summary>
        public ReadOnlyCollection<TPoco> ToCreate { get; private set; }

        /// <summary>
        /// Gets the to update.
        /// </summary>
        public ReadOnlyCollection<TPoco> ToUpdate { get; private set; }

        /// <summary>
        /// Gets the to delete.
        /// </summary>
        public ReadOnlyCollection<TPoco> ToDelete { get; private set; }

        #endregion
    }
}
