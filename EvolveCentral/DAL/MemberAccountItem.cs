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
    
    public partial class MemberAccountItem
    {
        public int Id { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public System.DateTime RegisteredOn { get; set; }
        public Nullable<System.DateTime> LastLogonOn { get; set; }
        public bool IsActive { get; set; }
    
        public virtual CompanyItem CompanyItem { get; set; }
    }
}
