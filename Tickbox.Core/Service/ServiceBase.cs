using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;

namespace Tickbox.Core.Service
{
    public class ServiceBase
    {
        private readonly IDbContextScopeFactory _scopeFactory;
        protected IDbContextScopeFactory ScopeFactory { get { return _scopeFactory; } }

        public ServiceBase(IDbContextScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

    }
}
