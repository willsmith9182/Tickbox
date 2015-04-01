// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the GenericRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using TickBox.Data.Context;
using TickBox.Objects;

namespace TickBox.Data
{
    /// <summary>
    /// The scaffold repository.
    /// </summary>
    /// <typeparam name="TDataType">
    /// the entity type.
    /// </typeparam>
    [Obsolete("Repositories have been replaced by unit of work.")]
    public class ScaffoldRepository<TDataType> : Repository<TDataType>, IScaffoldRepository<TDataType> where TDataType : class, IScaffold
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScaffoldRepository{TDataType}"/> class.
        /// </summary>
        /// <param name="contextProvider">
        /// The context provider.
        /// </param>
        public ScaffoldRepository(TickBoxEntities context)
            : base(context)
        {
        }

        #region Implementation of IGenericRepository<TDataType>

        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="del">
        /// The expression to to identify the item.
        /// </param>
        /// <returns>
        /// The <see cref="TDataType"/>.
        /// </returns>
        public override TDataType GetItem(Func<TDataType, bool> del)
        {
            return this.Context.Set<TDataType>().Where(i => i.IsScaffold).Single(del);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public override IQueryable<TDataType> GetAll()
        {
            return this.Context.Set<TDataType>().Where(i => i.IsScaffold);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="tracking">
        /// The tracking.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public override IQueryable<TDataType> GetAll(bool tracking)
        {
            return tracking ? this.GetAll().Where(i => i.IsScaffold) : this.Context.Set<TDataType>().AsNoTracking().Where(i => i.IsScaffold);
        }

        #endregion
    }
}