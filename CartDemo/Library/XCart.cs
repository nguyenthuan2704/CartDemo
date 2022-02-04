using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartDemo;
using CartDemo.Models;

namespace CartDemo.Library
{
    public class XCart
    {
        public List<Cart> AddCart(Cart cart)
        {
            List<Cart> listCart;
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                listCart = new List<Cart>();
                listCart.Add(cart);
                System.Web.HttpContext.Current.Session["MyCart"] = listCart;
            }
            else
            {
                listCart = (List<Cart>)System.Web.HttpContext.Current.Session["MyCart"];//Ép kiểu
                //Kiểm tra giỏ hàng có sp tương tự hay chưa
                if (listCart.Where(m => m.ProductId == cart.ProductId).Count() != 0)
                {
                    //Đã có sp
                    int vt = 0;
                    foreach (var item in listCart)
                    {
                        if (item.ProductId == cart.ProductId)
                        {
                            listCart[vt].Qty += 1;
                            listCart[vt].Amount = (listCart[vt].Qty * listCart[vt].ProductPrice);
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = listCart;
                }
                else
                {
                    //Chưa có sp
                    listCart.Add(cart);
                    System.Web.HttpContext.Current.Session["MyCart"] = listCart;
                }
            }
            return listCart;
        }
        public void UpdateCart(string[] arrqty)
        {
            List<Cart> listCart = this.GetCart();
            int vt = 0;
            foreach (Cart cart in listCart)
            {
                if (arrqty[vt].Equals("0"))
                {
                    this.DeleteCart(cart.ProductId);
                }
                else
                {
                    listCart[vt].Qty = int.Parse(arrqty[vt]);
                    listCart[vt].Amount = (listCart[vt].Qty * listCart[vt].ProductPrice);
                }
                vt++;
            }
            System.Web.HttpContext.Current.Session["MyCart"] = listCart;
        }

        public void DeleteCart(int? productid = null)
        {
            if (productid != null)
            {
                if (!System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
                {
                    List<Cart> listCart = (List<Cart>)System.Web.HttpContext.Current.Session["MyCart"];
                    int vt = 0;
                    foreach (var item in listCart)
                    {
                        if (item.ProductId == productid)
                        {
                            listCart.RemoveAt(vt);
                            break;
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = listCart;
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["MyCart"] = "";
            }
        }

        public List<Cart> GetCart()
        {
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                return null;
            }
            return (List<Cart>)System.Web.HttpContext.Current.Session["MyCart"];
        }
    }
}