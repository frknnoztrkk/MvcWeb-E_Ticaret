﻿using Proje.MvcWebUI.Entity;
using Proje.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.MvcWebUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {

            var orders = db.Orders.Select(i => new AdminOrderModel()
            {

                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count=i.Orderlines.Count

            }).OrderByDescending(i =>i.OrderDate).ToList();


            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    Username=i.Username,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Sehir = i.Sehir,
                    Ilce = i.Ilce,
                    PostaKodu = i.PostaKodu,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Adi,
                        Quantity = a.Quantity,
                        SatisFiyat = a.SatisFiyat,
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        } 

        public ActionResult UpdateOrderState(int OrderId,EnumOrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState= orderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new {id=OrderId});
            }

            return View();
        }
    }
}