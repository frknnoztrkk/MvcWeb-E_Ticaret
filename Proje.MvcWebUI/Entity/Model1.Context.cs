﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proje.MvcWebUI.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVC_eTicaretEntities : DbContext
    {
        public MVC_eTicaretEntities()
            : base("name=MVC_eTicaretEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kargo> Kargo { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<MusteriAdres> MusteriAdres { get; set; }
        public virtual DbSet<OzellikTip> OzellikTip { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<SatisDetay> SatisDetay { get; set; }
        public virtual DbSet<SiparisDurum> SiparisDurum { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
    }
}