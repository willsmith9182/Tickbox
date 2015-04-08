using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
