﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OkulOtomasyonSistemi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbOkulOtomasyonEntities : DbContext
    {
        public DbOkulOtomasyonEntities()
            : base("name=DbOkulOtomasyonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Branslar> Branslar { get; set; }
        public virtual DbSet<Ilceler> Ilceler { get; set; }
        public virtual DbSet<Iller> Iller { get; set; }
        public virtual DbSet<Ogrenciler> Ogrenciler { get; set; }
        public virtual DbSet<Ogretmenler> Ogretmenler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Veliler> Veliler { get; set; }
        public virtual DbSet<OgrAyarlar> OgrAyarlar { get; set; }
        public virtual DbSet<OgrtAyarlar> OgrtAyarlar { get; set; }
    
        public virtual ObjectResult<AyarlarOgr_Result> AyarlarOgr()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AyarlarOgr_Result>("AyarlarOgr");
        }
    
        public virtual ObjectResult<AyarlarOgrt_Result> AyarlarOgrt()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AyarlarOgrt_Result>("AyarlarOgrt");
        }
    }
}