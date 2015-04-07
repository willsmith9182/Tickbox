using Tickbox.Core.DataAccess;
using Tickbox.DatabaseApi;

namespace Tickbox.Data.Repository
{
    public interface INodeRepo : IRepo<Node>
    {
       // IList<NodeModel> GetNodes();
    }
    public interface ITemplateRepo : IRepo<Template>
    {
        // IList<NodeModel> GetNodes();
    }
    public interface ITaxonomyRepo : IRepo<Taxonomy>
    {
        
    }
    public interface ISpecialismRepo : IRepo<Specialism>
    {
        // IList<NodeModel> GetNodes();
    }
    public interface ITreeNodeRepo : IRepo<TreeNode>
    {
        // IList<NodeModel> GetNodes();
    }
}
