using Mehdime.Entity;

namespace Tickbox.Core.Service
{
    public class ServiceBase
    {
        private readonly IDbContextScopeFactory _scopeFactory;

        public ServiceBase(IDbContextScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected IDbContextScopeFactory ScopeFactory
        {
            get { return _scopeFactory; }
        }
    }
}