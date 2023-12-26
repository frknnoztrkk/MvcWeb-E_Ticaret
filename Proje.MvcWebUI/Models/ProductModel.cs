using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal SatisFiyat { get; set; }
        public string Image {  get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<int> MarkaID { get; set; }
    }
}