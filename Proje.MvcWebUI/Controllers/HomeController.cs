using Proje.MvcWebUI.Entity;
using Proje.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Proje.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();

        // GET: Home
        public ActionResult Index(int? id)
        {
            var urunler = context.Uruns
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Adi = i.Adi.Length > 20 ? i.Adi.Substring(0, 18) + "..." : i.Adi,
                    Aciklama = i.Aciklama.Length >50 ? i.Aciklama.Substring(0, 47) + "...":i.Aciklama,
                    SatisFiyat = i.SatisFiyat,
                    KategoriID = i.KategoriID,
                }).AsQueryable();
            if (id != null)
            {
                urunler=urunler.Where(i => i.KategoriID == id);
            }

            return View(urunler.ToList());
            
        }
        public ActionResult Details(int id)
        {
            return View(context.Uruns.Where(i =>i.Id==id).FirstOrDefault());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(context.Kategoris.ToList());
        }
    }
}