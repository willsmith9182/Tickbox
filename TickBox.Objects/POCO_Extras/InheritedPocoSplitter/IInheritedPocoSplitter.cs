// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInheritedPocoSplitter.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The InheritedPocoSplitter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace TickBox.Objects
{
    /// <summary>
    /// The InheritedPocoSplitter interface.
    /// </summary>
    /// <typeparam name="TBasePoco">
    /// base poco from context
    /// </typeparam>
    public interface IInheritedPocoSplitter<TBasePoco> where TBasePoco : class, IBaseEntity
    {
        /// <summary>
        /// The get derived type.
        /// </summary>
        /// <typeparam name="TPocoType">
        /// derived type of poco to retrieve
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICollection{TPocoType}"/>.
        /// </returns>
        ICollection<TPocoType> GetDerivedType<TPocoType>() where TPocoType : class, TBasePoco, IInheritedPoco<TBasePoco>;

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Remove(TBasePoco item);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="TPocoType">
        /// derived type of poco to add to collection
        /// </typeparam>
        void Add<TPocoType>(TPocoType item) where TPocoType : class, TBasePoco, IInheritedPoco<TBasePoco>;

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection{TBasePoco}"/>.
        /// </returns>
        ICollection<TBasePoco> GetAll();
    }
}
