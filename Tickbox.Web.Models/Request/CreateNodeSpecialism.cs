namespace Tickbox.Web.Models.Request
{
    public class CreateNodeSpecialism
    {
        public int NodeId { get; set; }
        public int SpecialismId { get; set; }
        public string Guidelines { get; set; }
        public string DocumentLink { get; set; }
    }
}