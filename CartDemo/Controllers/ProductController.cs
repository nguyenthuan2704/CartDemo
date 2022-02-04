using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartDemo;
using System.Net;

namespace CartDemo.Controllers
{
    public class ProductController : Controller
    {
        private CartEntities2 db = new CartEntities2();
        // GET: Product
        public ActionResult Index()
        {            
            return View(db.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            //ViewBag.Image = product.Images;
            return View(product);
        }
    }
}