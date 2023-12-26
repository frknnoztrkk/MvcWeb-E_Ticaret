using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        { 
            
        }
      
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<SiparisDurum> SipsarisDurums { get;}
        public DbSet<SatisDetay> SatisDetays { get; set; }
        public DbSet<Satis> Satiss { get; set; }
        public DbSet<Resim> Resims { get; set; }
        public DbSet<OzellikTip> OzellikTips { get; set; }
        public DbSet<MusteriAdres> MusteriAdress { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Kargo> Kargos { get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }


    }
}