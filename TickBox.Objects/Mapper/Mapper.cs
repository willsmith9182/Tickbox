// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects
{
    /// <summary>
    /// The mapper.
    /// </summary>
    /// <typeparam name="TData">
    /// map from poco
    /// </typeparam>
    /// <typeparam name="TView">
    /// map to view model
    /// </typeparam>
    public class Mapper<TData, TView> : IMapper<TData, TView>
        where TData : class, new()
        where TView : class, new()
    {
        /// <summary>
        /// The mapping provider.
        /// </summary>
        private readonly IMappingProvider<TData, TView> mappingProvider;

        /// <summary>
        /// Initialises a new instance of the <see cref="Mapper{TData,TView}"/> class.
        /// </summary>
        /// <param name="mappingProvider">
        /// The mapping provider.
        /// </param>
        public Mapper(IMappingProvider<TData, TView> mappingProvider)
        {
            this.mappingProvider = mappingProvider;
        }

        #region Implementation of IMap<TData,TView>

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TView"/>.
        /// </returns>
        public TView Map(TData item)
        {
            return this.mappingProvider.CreateObject(item);
        }

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="ICollection{TView}"/>.
        /// </returns>
        public ICollection<TView> Map(ICollection<TData> items)
        {
            return items.Select(this.Map).ToList();
        }

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TView"/>.
        /// </returns>
        public TData Reverse(TView item)
        {
            return this.mappingProvider.CreateObject(item);
        }

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="ICollection{TView}"/>.
        /// </returns>
        public ICollection<TData> Reverse(ICollection<TView> items)
        {
            return items.Select(this.Reverse).ToList();
        }

        #endregion
    }
}
