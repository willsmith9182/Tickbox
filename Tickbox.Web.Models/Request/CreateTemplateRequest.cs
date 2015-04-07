using System.Collections.Generic;

namespace Tickbox.Web.Models.Request
{
    public class CreateTemplate
    {
        public string TemplateName { get; set; }
        public string DocumentLink { get; set; }
    }

    public class CreateSpecialism
    {
        public string SpecialismDesc { get; set; }
    }

    public class CreateNodeSpecialism
    {
        public int NodeId { get; set; }
        public int SpecialismId { get; set; }
        public string Guidelines { get; set; }
        public string DocumentLink { get; set; }
    }

    public class CreateNode
    {
        public string NodeTitle { get; set; }
        public string NodeDesc { get; set; }
        public bool ChildrenMultiSelect { get; set; }
        public int TaxonomyId { get; set; }
        public int ParentTreeNodeId { get; set; }

    }




}
