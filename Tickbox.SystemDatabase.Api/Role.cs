//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tickbox.SystemDatabase.Api
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.User = new HashSet<User>();
        }
    
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }
    
        public virtual ICollection<User> User { get; set; }
    }
}
