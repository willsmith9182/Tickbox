using System;
using System.Collections.Generic;
using System.Data.Entity;
using Mehdime.Entity;
using Tickbox.Core.Exceptions;

namespace Tickbox.Core.DataAccess
{
    
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
