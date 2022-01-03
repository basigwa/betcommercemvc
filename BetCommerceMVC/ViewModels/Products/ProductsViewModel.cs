using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetCommerceMVC.ViewModels.Products
{
    public class ProductsViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
        public string ProductThumb { get; set; }
        public string ProductImage { get; set; }
    }
}