using System.Collections.Generic;

namespace ODataExpandIssue.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}