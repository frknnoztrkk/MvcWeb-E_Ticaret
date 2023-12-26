using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
          var kategoriler = new List<Kategori>()
          {
             new Kategori() {Adi="Apple",Aciklama="Apple Ürünleri"},
             new Kategori() {Adi="Samsung",Aciklama="Samsung Ürünleri"},
             new Kategori() {Adi="Xiaomi",Aciklama="Xiaomi Ürünleri"},
             new Kategori() {Adi="Huawei",Aciklama="Huawei Ürünleri"},
             new Kategori() {Adi="Apple",Aciklama="Apple Ürünleri"},
          };
            foreach (var a in kategoriler) 
            {
                context.Kategoris.Add(a);
            }
            context.SaveChanges();


           var urunler = new List<Urun>()
            {
                new Urun() {Adi=" iPhone 13 Kılıfı",Aciklama="iPhone için Kılıf Kamera Korumalı Magsafe Wireless Şarj Özellikli Şeffaf Kılıf",SatisFiyat= 130 ,KategoriID=1,Image ="6.jpg"},
                new Urun() {Adi=" Samsung Galaxy A54 5G kılıfı",Aciklama="360 derece darbeye dayanıklı kılıf tam koruma cep telefonu kılıfı Samsung A54 Rugged koruyucu kılıf, Galaxy A54 entegre ekran koruyuculu, siyah",SatisFiyat= 300 ,KategoriID=2,Image = "2.jpg"},
                new Urun() {Adi=" Xiaomi 13T Pro Kılıfı",Aciklama="darbeye dayanıklı zırh cep telefonu kılıfı, silikon ve sert polikarbonlu, koruyucu kılıf Cover Case Bumper, 360° halka standı ve objektif-koruma sürgüsü",SatisFiyat= 250 ,KategoriID=3,Image = "3.jpg"},

            };
            
            foreach (var b in urunler)
            {
                context.Uruns.Add(b);
            };
            context.SaveChanges();
            
            base.Seed(context);
        }


    }
}