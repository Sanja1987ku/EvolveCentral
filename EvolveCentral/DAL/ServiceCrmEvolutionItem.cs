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
    
    public partial class ServiceCrmEvolutionItem
    {
        public ServiceCrmEvolutionItem()
        {
            this.ServiceCrmEvolutionDetailHistoryItems = new HashSet<ServiceCrmEvolutionDetailHistoryItem>();
            this.ServiceCrmEvolutionDetailItems = new HashSet<ServiceCrmEvolutionDetailItem>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ServiceTemplateCrmEvolutionId { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Connection_DatabaseName { get; set; }
        public string Connection_DatabaseServer { get; set; }
        public string Connection_DatabaseUserName { get; set; }
        public string Connection_DatabasePassword { get; set; }
        public string DatabaseName_Source { get; set; }
        public string DatabaseName_Destination { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public Nullable<bool> LastSyncSuccessful { get; set; }
        public bool IsActive { get; set; }
    
        public virtual CompanyItem CompanyItem { get; set; }
        public virtual ICollection<ServiceCrmEvolutionDetailHistoryItem> ServiceCrmEvolutionDetailHistoryItems { get; set; }
        public virtual ICollection<ServiceCrmEvolutionDetailItem> ServiceCrmEvolutionDetailItems { get; set; }
        public virtual ServiceTemplateCrmEvolutionItem ServiceTemplateCrmEvolutionItem { get; set; }
    }
}
