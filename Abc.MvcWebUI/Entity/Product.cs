using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyat")]
        public double Price { get; set; }
        [DisplayName("Ürün Stok")]

        public int Stock { get; set; }
        [DisplayName("Ürün Görsel")]

        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}