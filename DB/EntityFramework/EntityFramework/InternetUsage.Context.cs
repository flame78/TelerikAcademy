﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InternetUsageEntities : DbContext
    {
        public InternetUsageEntities()
            : base("name=InternetUsageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Browser> Browsers { get; set; }
        public virtual DbSet<InternetUsageRecord> InternetUsageRecords { get; set; }
        public virtual DbSet<MacAdress> MacAdresses { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
    }
}
