namespace ODataExpandIssue.Model
{
    public class ProductSold
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int Order_Id { get; set; }
        public Product Product { get; set; }
        public int Product_Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}