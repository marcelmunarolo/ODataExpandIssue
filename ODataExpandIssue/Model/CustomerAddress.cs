namespace ODataExpandIssue.Model
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int Type { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}