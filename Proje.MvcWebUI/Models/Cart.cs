using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proje.MvcWebUI.Entity;

namespace Proje.MvcWebUI.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        { 
            get { return _cartLines; }
        }

        public void AddProduct(Urun urun, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Urun.Id == urun.Id);
            if (line==null)
            {
                _cartLines.Add(new CartLine() {Urun= urun , Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteUrun(Urun urun)
        {
            _cartLines.RemoveAll(i => i.Urun.Id == urun.Id);
        }

        public decimal Total()
        {
            return _cartLines.Sum(i => i.Urun.SatisFiyat * i.Quantity);
        }

        public void  Clear()
        {
            _cartLines.Clear();
        } 
    }

    public class CartLine
    {
        public Urun Urun { get; set; }
        public int Quantity { get; set; }
    }
}