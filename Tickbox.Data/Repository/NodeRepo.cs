using Mehdime.Entity;
using Tickbox.Core.DataAccess;

using Tickbox.DatabaseApi;

namespace Tickbox.Data.Repository
{
    internal class NodeRepo : RepoBase<Node, TickboxDatabaseEntities>, INodeRepo
    {
        public NodeRepo(IAmbientDbContextLocator contextLocator)
            : base(contextLocator)
        {
        }
    }
}