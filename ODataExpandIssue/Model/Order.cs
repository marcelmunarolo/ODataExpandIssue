using System.Collections.Generic;

namespace ODataExpandIssue.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Shipment { get; set; }
        public decimal ShipmentValue { get; set; }
        public decimal Discount { get; set; }
        public Customer Customer { get; set; }
        public int Customer_Id { get; set; }
        public ICollection<ProductSold> ProductsSold { get; set; } = new HashSet<ProductSold>();
    }
}