using System.Collections.Generic;

namespace ODataExpandIssue.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}