//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvolveCentral.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicationLogItem
    {
        public int Id { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public Nullable<int> MemberAccountId { get; set; }
        public Nullable<int> AdministratorAccountId { get; set; }
    
        public virtual AdministratorAccountItem AdministratorAccountItem { get; set; }
    }
}
