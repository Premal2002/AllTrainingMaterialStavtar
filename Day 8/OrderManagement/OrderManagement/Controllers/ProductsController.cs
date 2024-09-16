using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly AppDbContext _dbContext;

        public ProductsController(ILogger<ProductsController> logger,AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "getcustomers")]
        public List<Order> Get()
        {
            return _dbContext.Customers
                .SelectMany(c => c.Orders)
                .Include(x=> x.Invoice)
                .Include(x=> x.OrderProducts)
                .ThenInclude(x => x.Product)
                .ToList();
        }
    }
}
