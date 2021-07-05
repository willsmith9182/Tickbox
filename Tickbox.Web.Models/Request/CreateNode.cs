namespace Tickbox.Web.Models.Request
{
    public class CreateNode
    {
        public string NodeTitle { get; set; }
        public string NodeDesc { get; set; }
        public bool ChildrenMultiSelect { get; set; }
        public int TaxonomyId { get; set; }
        public int ParentTreeNodeId { get; set; }
    }
}