using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tickbox.Core.DataAccess
{
    public interface IRepo<TSet>
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
}
