﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganikUrunZincirTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrganikUrunDBContext : DbContext
    {
        public OrganikUrunDBContext()
            : base("name=OrganikUrunDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Denetleme> Denetlemes { get; set; }
        public virtual DbSet<Depolama> Depolamas { get; set; }
        public virtual DbSet<Nakliye> Nakliyes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sati> Satis { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}