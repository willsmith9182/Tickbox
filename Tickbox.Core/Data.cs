using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Mehdime.Entity;
using TickBox.Data;
using TickBox.Data.Context;


namespace Tickbox.Core
{
    internal interface IRepo<TSet>
        where TSet : class
    {
        // find methods
        // uses single or default
        TSet FindBy(Expression<Func<TSet, bool>> pred);
        // where
        IQueryable<TSet> Find(Expression<Func<TSet, bool>> pred);
        // where
        IQueryable<TSet> Find(Expression<Func<TSet, int, bool>> pred);

        void Add(TSet item);
        void Add(IEnumerable<TSet> items);

        void Remove(TSet item);
        void Remove(IEnumerable<TSet> items);
    }

    public class NodeModel
    {

    }

    internal interface INodeRepo : IRepo<Node>
    {
        IList<NodeModel> GetNodes();
    }

    internal class NodeRepo : RepoBase<Node, TickBoxEntities>, INodeRepo
    {
        public NodeRepo(IAmbientDbContextLocator contextLocator)
            : base(contextLocator)
        {
        }

        public IList<NodeModel> GetNodes()
        {

        }
    }


    internal abstract class RepoBase<TSet, TCxt> : IRepo<TSet>
        where TCxt : DbContext
        where TSet : class
    {
        private readonly IAmbientDbContextLocator _contextLocator;

        protected RepoBase(IAmbientDbContextLocator contextLocator)
        {
            _contextLocator = contextLocator;
        }

        // Gets the underlying context for the repo enabling custom queries in derrived types
        protected TCxt Context { get { return _contextLocator.Get<TCxt>(); } }
        // gets the underlying Set from the underlying context enabling custom queries in derived types. 
        protected IDbSet<TSet> Entities { get { return _contextLocator.Get<TCxt>().Set<TSet>(); } }

        public TSet FindBy(Expression<Func<TSet, bool>> pred)
        {
            return _contextLocator.Get<TCxt>().Set<TSet>().SingleOrDefault(pred);
        }

        public IQueryable<TSet> Find(Expression<Func<TSet, bool>> pred)
        {
            return _contextLocator.Get<TCxt>().Set<TSet>().Where(pred);
        }
        public IQueryable<TSet> Find(Expression<Func<TSet, int, bool>> pred)
        {
            return _contextLocator.Get<TCxt>().Set<TSet>().Where(pred);
        }

        protected T CustomSetQuery<T>(Func<IDbSet<TSet>, T> pred)
        {
            return pred(_contextLocator.Get<TCxt>().Set<TSet>());
        }

        protected T CustomQuery<T>(Func<TCxt, T> pred)
        {
            return pred(_contextLocator.Get<TCxt>());
        }

        public void Add(TSet item)
        {
            _contextLocator.Get<TCxt>().Set<TSet>().Add(item);
        }

        public void Add(IEnumerable<TSet> items)
        {
            _contextLocator.Get<TCxt>().Set<TSet>().RemoveRange(items);
        }

        public void Remove(TSet item)
        {
            _contextLocator.Get<TCxt>().Set<TSet>().Remove(item);
        }

        public void Remove(IEnumerable<TSet> items)
        {
            _contextLocator.Get<TCxt>().Set<TSet>().AddRange(items);
        }
    }

    internal class DatabaseNotRegisteredException : Exception
    {
        public DatabaseNotRegisteredException(Type dbType)
            : base(string.Format("Database {0} has not been registered in app setup.", dbType.Name))
        {
        }

        public DatabaseNotRegisteredException(SerializationInfo sInfo, StreamingContext cxt)
            : base(sInfo, cxt)
        {
        }
    }

    internal class DbContextFactory : IDbContextFactory
    {
        private readonly Dictionary<Type, Func<DbContext>> _registeredDatabases = new Dictionary<Type, Func<DbContext>>();

        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            Func<DbContext> factory;
            var cxtType = typeof(TDbContext);
            if (_registeredDatabases.TryGetValue(cxtType, out factory))
            {
                // explicit cast ok.
                return (TDbContext)factory();
            }
            throw new DatabaseNotRegisteredException(cxtType);
        }


        public void RegisterDb<T>(Func<T> factory) where T : DbContext
        {
            _registeredDatabases[typeof(T)] = factory;
        }

    }



}
