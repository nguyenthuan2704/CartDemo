using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartDemo;
using CartDemo.Models;
using CartDemo.Library;

namespace CartDemo.Controllers
{
    public class CartController : Controller
    {
        private CartEntities2 db = new CartEntities2();
        XCart xcart = new XCart();
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> listCart = xcart.GetCart();
            return View("Index",listCart);
        }

        public ActionResult AddToCart(int productid)
        {
            Product product = db.Products.Find(productid);//Chi tiết sản phẩm
            Cart cart = new Cart(product.Id,product.Brandname,product.Avatar,product.Price,1);//Thêm sp vào giỏ hàng
            List<Cart> listCart = xcart.AddCart(cart);
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult CartDelete(int productid)
        {
            xcart.DeleteCart(productid);
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult CartDeleteAll()
        {
            xcart.DeleteCart();
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult CartUpdate(FormCollection formCollection)
        {
            if(!string.IsNullOrEmpty(formCollection["update"]))
            {
                var listqty = formCollection["qty"];
                var listarr = listqty.Split(',');
                xcart.UpdateCart(listarr);                
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}