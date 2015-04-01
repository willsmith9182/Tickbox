// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGenericRepository.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The GenericRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects
{
    /// <summary>
    /// The GenericRepository interface.
    /// </summary>
    /// <typeparam name="TDataType">
    /// entity type
    /// </typeparam>
    [Obsolete("Repositories have been replaced by unit of work.")]
    public interface IRepository<TDataType>
        where TDataType : class
    {
        int GetNextId(Func<TDataType, int> del);

        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="del">
        /// The expression to to identify the item.
        /// </param>
        /// <returns>
        /// The <see cref="TDataType"/>.
        /// </returns>
        TDataType GetItem(Func<TDataType, bool> del);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TDataType> GetAll();

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="tracking">
        /// The tracking.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TDataType> GetAll(bool tracking);

        /// <summary>
        /// The create, adds a given poco to the relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Create(TDataType item);

        /// <summary>
        /// The create, adds an <see cref="IList{TDataType}"/> to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The pocos to create.
        /// </param>
        void Create(IList<TDataType> items);

        /// <summary>
        /// The update, adds a given poco back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Update(TDataType item);

        /// <summary>
        /// The update, adds an <see cref="IList{TDataType}"/> back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void Update(IList<TDataType> items);

        /// <summary>
        /// The delete, removes a given poco from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Delete(TDataType item);

        /// <summary>
        /// The delete, removes an <see cref="IList{TDataType}"/> from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void Delete(IList<TDataType> items);
    }
}
