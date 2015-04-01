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

    public abstract class EFUnitOfWorkBase<T> : IDataUnitOfWork where T : DbContext
    {
        private readonly T _context;
        private bool _comitted = false;
        private readonly Dictionary<Type, int> unitIdList = new Dictionary<Type, int>();

        protected EFUnitOfWorkBase(T context)
        {
            _context = context;
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            try
            {
                this._context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DatabaseConcurrencyException(ex);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && (ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("-20999")))
                {
                    throw new DatabaseConcurrencyException(ex);
                }

                throw new DatabaseException(ex);
            }
        }


        public abstract int GetNextId<TDataType>(Func<TDataType, int> del) where TDataType : class, IEntity;
        public abstract TDataType GetItem<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity;
        public abstract TDataType GetItemScaffold<TDataType>(Func<TDataType, bool> del) where TDataType : class, IScaffold;
        public abstract IQueryable<TDataType> GetAllScaffold<TDataType>() where TDataType : class, IScaffold;
        public abstract IQueryable<TDataType> GetAllScaffold<TDataType>(bool tracking) where TDataType : class, IScaffold;
        public abstract IQueryable<TDataType> GetAll<TDataType>() where TDataType : class, IEntity;
        public abstract IQueryable<TDataType> GetAll<TDataType>(bool tracking) where TDataType : class, IEntity;
        public abstract void Create<TDataType>(TDataType item) where TDataType : class, IEntity;
        public abstract void Create<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;
        public abstract void Update<TDataType>(TDataType item) where TDataType : class, IEntity;
        public abstract void Update<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;
        public abstract void Delete<TDataType>(TDataType item) where TDataType : class, IEntity;
        public abstract void Delete<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;
        public abstract bool Exists<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity;


    }


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EfUnitOfWork : IDataUnitOfWork
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TickBoxEntities context;

        private bool _comitted = false;
        private readonly Dictionary<Type, int> unitIdList = new Dictionary<Type, int>();

       

        /// <summary>
        /// Initialises a new instance of the <see cref="EfUnitOfWork"/> class.
        /// </summary>
        /// <param name="contextProvider">
        /// The context provider.
        /// </param>
        public EfUnitOfWork(IContextProvider contextProvider)
        {
            this.context = contextProvider.GetContext();
        }

        /// <summary>
        /// The get next id.
        /// </summary>
        /// <param name="del">
        /// The del.
        /// </param>
        /// <typeparam name="TDataType">
        /// </typeparam>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetNextId<TDataType>(Func<TDataType, int> del) where TDataType : class, IEntity
        {
            if (!this.unitIdList.ContainsKey(typeof(TDataType)))
            {
                this.unitIdList.Add(typeof(TDataType), this.context.Set<TDataType>().Max(del));
            }

            var tempMax = this.unitIdList[typeof(TDataType)];
            if (tempMax < int.MaxValue)
            {
                this.unitIdList[typeof(TDataType)] = ++tempMax;
                return tempMax;
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
        public TDataType GetItem<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity
        {
            return this.context.Set<TDataType>().Single(del);
        }

        public TDataType GetItemScaffold<TDataType>(Func<TDataType, bool> del) where TDataType : class, IScaffold
        {
            return this.context.Set<TDataType>().Where(i => i.IsScaffold).Single(del);
        }

        public IQueryable<TDataType> GetAllScaffold<TDataType>() where TDataType : class, IScaffold
        {
            return this.GetAllScaffold<TDataType>(true);
        }

        public IQueryable<TDataType> GetAllScaffold<TDataType>(bool tracking) where TDataType : class, IScaffold
        {
            return tracking
                        ? this.context.Set<TDataType>().Where(i => i.IsScaffold)
                        : this.context.Set<TDataType>().AsNoTracking().Where(i => i.IsScaffold);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable{T}"/>.
        /// </returns>
        public IQueryable<TDataType> GetAll<TDataType>() where TDataType : class, IEntity
        {
            return this.GetAll<TDataType>(true);
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
        public IQueryable<TDataType> GetAll<TDataType>(bool tracking) where TDataType : class, IEntity
        {
            return tracking
                        ? this.context.Set<TDataType>()
                        : this.context.Set<TDataType>().AsNoTracking();
        }

        /// <summary>
        /// The create, adds a given poco to the relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Create<TDataType>(TDataType item) where TDataType : class, IEntity
        {
            this.context.Set<TDataType>().Add(item);
        }

        /// <summary>
        /// The create, adds an <see cref="IList{T}"/> to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The pocos to create.
        /// </param>
        public void Create<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity
        {
            foreach (var item in items)
            {
                this.Create(item);
            }
        }

        /// <summary>
        /// The update, adds a given poco back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Update<TDataType>(TDataType item) where TDataType : class, IEntity
        {
            this.context.Set<TDataType>().Attach(item);
            this.context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// The update, adds an <see cref="IList{TDataType}"/> back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public void Update<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity
        {
            foreach (var item in items)
            {
                this.Update(item);
            }
        }

        /// <summary>
        /// The delete, removes a given poco from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Delete<TDataType>(TDataType item) where TDataType : class, IEntity
        {
            this.context.Set<TDataType>().Remove(item);
        }

        /// <summary>
        /// The delete, removes an <see cref="IList{TDataType}"/> from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public void Delete<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity
        {
            foreach (var item in items)
            {
                this.Delete(item);
            }
        }

        

        /// <summary>
        /// The exists.
        /// </summary>
        /// <param name="del">
        /// The del.
        /// </param>
        /// <typeparam name="TDataType">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Exists<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity
        {
            return this.context.Set<TDataType>().Count(del) > 0;
        }
    }
}
