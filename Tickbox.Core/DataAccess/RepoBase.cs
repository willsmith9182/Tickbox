﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Mehdime.Entity;


namespace Tickbox.Core.DataAccess
{
    public abstract class RepoBase<TSet, TCxt> : IRepo<TSet>
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
            foreach (var i in items)
            {
                this.Add(i);
            }
            
        }

        public void Remove(TSet item)
        {
            _contextLocator.Get<TCxt>().Set<TSet>().Remove(item);
        }

        public void Remove(IEnumerable<TSet> items)
        {
            foreach (var i in items)
            {
                this.Remove(i);
            }
        }
    }
}
