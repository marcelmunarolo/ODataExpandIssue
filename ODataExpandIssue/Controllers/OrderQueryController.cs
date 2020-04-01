using System.Linq;
using Microsoft.AspNet.OData;
using ODataExpandIssue.Data;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Controllers
{
    public class OrderQueryController : ODataController
    {
        private readonly MyDbContext _context;

        public OrderQueryController(MyDbContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 100)] // Do not work
        //[EnableQuery] // Works
        public virtual IQueryable<Order> Get()
        {
            return _context.Orders;
        }
    }
}