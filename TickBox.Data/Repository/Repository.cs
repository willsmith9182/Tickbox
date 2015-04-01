// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the GenericRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TickBox.Data.Context;
using TickBox.Objects;

namespace TickBox.Data
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TDataType">
    /// the entity type.
    /// </typeparam>
    [Obsolete("Repositories have been replaced by unit of work.")]
    public class Repository<TDataType> : IRepository<TDataType>, IDisposable where TDataType : class
    {
        /// <summary>
        /// The context.
        /// </summary>
        protected readonly TickBoxEntities Context;

        /// <summary>
        /// The current id.
        /// </summary>
        private int currentId;

        /// <summary>
        /// Initialises a new instance of the <see cref="Repository{TDataType}"/> class.
        /// </summary>
        /// <param name="contextProvider">
        /// The context provider.
        /// </param>
        public Repository(TickBoxEntities context)
        {
            var existsInContext = true;
            this.currentId = -1;
            this.Context = context;

            try
            {
                var test = this.Context.Set<TDataType>();
                if (test == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                existsInContext = false;
            }

            if (!existsInContext)
            {
                throw new InvalidOperationException(string.Format("Type doest not exist in the context, unable to generate a repository for {0}", typeof(TDataType).Name));
            }
        }

        #region Implementation of IGenericRepository<TDataType>

        /// <summary>
        /// The get next id.
        /// </summary>
        /// <param name="del">
        /// The expression to look up next id. 
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NoAvailalbeIdsException">
        /// thrown if the number of id's in the table exceeds <see cref="int.MaxValue"/>.
        /// </exception>
        public int GetNextId(Func<TDataType, int> del)
        {
            if (this.currentId == -1)
            {
                this.currentId = this.Context.Set<TDataType>().Max(del);
            }

            if (this.currentId < int.MaxValue)
            {
                this.currentId++;
                return this.currentId;
            }

            throw new NoAvailalbeIdsException(string.Format("No availalbe Id's for new {0}", typeof(TDataType).Name));
        }

        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="del">
        /// The expression to to identify the item.
        /// </param>
        /// <returns>
        /// The <see cref="TDataType"/>.
        /// </returns>
        public virtual TDataType GetItem(Func<TDataType, bool> del)
        {
            return this.Context.Set<TDataType>().Single(del);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public virtual IQueryable<TDataType> GetAll()
        {
            return this.GetAll(true);
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
        public virtual IQueryable<TDataType> GetAll(bool tracking)
        {
            return tracking ? this.GetAll() : this.Context.Set<TDataType>().AsNoTracking();
        }

        /// <summary>
        /// The create, adds a given poco to the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Create(TDataType item)
        {
            this.Context.Set<TDataType>().Add(item);
        }

        /// <summary>
        /// The create, adds an <see cref="IList{TDataType}"/> to the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="items">
        /// The pocos to create.
        /// </param>
        public void Create(IList<TDataType> items)
        {
            items.ToList().ForEach(this.Create);
        }

        /// <summary>
        /// The update, adds a given poco back into context in a modified state to the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Update(TDataType item)
        {
            this.Context.Set<TDataType>().Attach(item);
            this.Context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// The update, adds an <see cref="IList{TDataType}"/> back into context in a modified state to the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public void Update(IList<TDataType> items)
        {
            items.ToList().ForEach(this.Create);
        }

        /// <summary>
        /// The delete, removes a given poco from the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Delete(TDataType item)
        {
            this.Context.Set<TDataType>().Remove(item);
        }

        /// <summary>
        /// The delete, removes an <see cref="IList{TDataType}"/> from the supplied <see cref="IDbSet{TDataType}"/>.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public void Delete(IList<TDataType> items)
        {
            items.ToList().ForEach(this.Delete);
        }

        #endregion

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {

            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context.Dispose();
            }
        }

    }
}