﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class entitiesEvolveCentralConsole : DbContext
    {
        public entitiesEvolveCentralConsole()
            : base("name=entitiesEvolveCentralConsole")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AdministratorAccountItem> AdministratorAccountItems { get; set; }
        public DbSet<AdministratorPermissionItem> AdministratorPermissionItems { get; set; }
        public DbSet<AdministratorRoleItem> AdministratorRoleItems { get; set; }
        public DbSet<ApplicationLogItem> ApplicationLogItems { get; set; }
        public DbSet<ApplicationSettingsItem> ApplicationSettingsItems { get; set; }
        public DbSet<CompanyItem> CompanyItems { get; set; }
        public DbSet<MemberAccountItem> MemberAccountItems { get; set; }
        public DbSet<ServiceCrmEvolutionDetailHistoryItem> ServiceCrmEvolutionDetailHistoryItems { get; set; }
        public DbSet<ServiceCrmEvolutionDetailItem> ServiceCrmEvolutionDetailItems { get; set; }
        public DbSet<ServiceCrmEvolutionItem> ServiceCrmEvolutionItems { get; set; }
        public DbSet<ServiceTemplateCrmEvolutionDetailItem> ServiceTemplateCrmEvolutionDetailItems { get; set; }
        public DbSet<ServiceTemplateCrmEvolutionItem> ServiceTemplateCrmEvolutionItems { get; set; }
        public DbSet<ServiceTypeItem> ServiceTypeItems { get; set; }
        public DbSet<SyncLogCrmEvolutionDetailItem> SyncLogCrmEvolutionDetailItems { get; set; }
        public DbSet<SyncLogCrmEvolutionItem> SyncLogCrmEvolutionItems { get; set; }
    }
}
