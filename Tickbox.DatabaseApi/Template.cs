//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tickbox.DatabaseApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Template
    {
        public Template()
        {
            this.Taxonomy = new HashSet<Taxonomy>();
        }
    
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string DocumentLink { get; set; }
        public bool IsScaffold { get; set; }
        public bool IsMaster { get; set; }
    
        public virtual ICollection<Taxonomy> Taxonomy { get; set; }
    }
}