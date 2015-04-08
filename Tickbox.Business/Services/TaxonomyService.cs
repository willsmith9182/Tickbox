using Mehdime.Entity;
using Tickbox.Core.Service;
using Tickbox.Data.Repository;

namespace Tickbox.Business.Services
{
    public class TaxonomyService : ServiceBase
    {
        private readonly ITaxonomyRepo _taxonomyRepo;
        public TaxonomyService(IDbContextScopeFactory scopeFactory, ITaxonomyRepo taxonomyRepo)
            : base(scopeFactory)
        {
            _taxonomyRepo = taxonomyRepo;
        }




    }
}
