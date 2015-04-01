using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using TickBox.Data.Context;

namespace Tickbox.Core
{
    internal interface IRepo<T> where T : class
    {
        // will call single or default
        T FindBy(Expression<Func<T,bool>> pred);
        IList<T> Find(Expression<Func<IQueryable<T>, IQueryable<T>>> pred);
        void Add(T item);
        void Remove(T item);
    }

    internal interface IInternalRepo<in T>
    {
        void PersistNewItem(T item);
        void PersistUpdatedItem(T item);
        void PersistDeletedItem(T item);
    }

    internal interface IUnitOfWork
    {
        IQueryable<T> GetDataSet<T>();
        void RegisterAdded<T>(T entity, IInternalRepo<T> repository);
        void RegisterChanged<T>(T entity, IInternalRepo<T> repository);
        void RegisterRemoved<T>(T entity, IInternalRepo<T> repository);
        void Commit();
    }

  
}
