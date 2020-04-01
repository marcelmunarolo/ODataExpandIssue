using System;
using System.Collections.Generic;

namespace ODataExpandIssue.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset StartPromotion { get; set; }
        public DateTimeOffset EndPromotion { get; set; }
        public Category Category { get; set; }
        public int Category_Id { get; set; }
        public ICollection<ProductSold> ProductsSold { get; set; } = new HashSet<ProductSold>();
    }
}