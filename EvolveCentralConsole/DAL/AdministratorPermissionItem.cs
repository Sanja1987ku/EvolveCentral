//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvolveCentralConsole.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdministratorPermissionItem
    {
        public AdministratorPermissionItem()
        {
            this.AdministratorRoleItems = new HashSet<AdministratorRoleItem>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsSelectable { get; set; }
    
        public virtual ICollection<AdministratorRoleItem> AdministratorRoleItems { get; set; }
    }
}