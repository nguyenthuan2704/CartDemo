using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartDemo.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }

        public Cart() { }
        public Cart(int productid,string productname,string productimage,decimal productprice,int qty) 
        {
            this.ProductId = productid;
            this.ProductName = productname;
            this.ProductImage = productimage;
            this.ProductPrice = productprice;
            this.Qty = qty;
            this.Amount = productprice * qty;
        }

    }
}