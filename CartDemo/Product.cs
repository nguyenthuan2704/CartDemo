//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CartDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
        }
    
        public int Id { get; set; }
        public string Brandname { get; set; }
        public decimal Price { get; set; }
        public string Descriptions { get; set; }
        public string Hardware { get; set; }
        public string Avatar { get; set; }
    
        public virtual ICollection<Image> Images { get; set; }
    }
}
