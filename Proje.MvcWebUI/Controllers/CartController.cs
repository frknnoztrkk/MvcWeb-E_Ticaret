using Proje.MvcWebUI.Entity;
using Proje.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace Proje.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {

            var urun = db.Uruns.FirstOrDefault(i => i.Id == Id);
            if (urun != null)
            {
                GetCart().AddProduct(urun, 1);
            }

            return RedirectToAction("index");
        }

        public ActionResult RemoveFromCart(int Id)
        {

            var urun = db.Uruns.FirstOrDefault(i => i.Id == Id);
            if (urun != null)
            {
                GetCart().DeleteUrun(urun);
            }

            return RedirectToAction("index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde Ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString();
            order.Total = (double)cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Hazırlanıyor;
            order.Username = User.Identity.Name;

            order.AdresBasligi = entity.AdresBasligi;   
            order.Adres=entity.Adres;
            order.Sehir = entity.Sehir;
            order.Ilce = entity.Ilce;
            order.PostaKodu = entity.PostaKodu;

            order.Orderlines = new List<OrderLine>();
            foreach (var pr in cart.CartLines) 
            { 
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.SatisFiyat = (double)(pr.Quantity * pr.Urun.SatisFiyat);
                orderline.ProductId = pr.Urun.Id;

                order.Orderlines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}
