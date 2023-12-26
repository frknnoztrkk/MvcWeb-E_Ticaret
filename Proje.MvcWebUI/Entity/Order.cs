﻿using Proje.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }


        public string Username { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLine> Orderlines { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
        public double SatisFiyat { get; set; }

        public int ProductId { get; set; }
        public virtual Urun Product { get; set; }
    }
}