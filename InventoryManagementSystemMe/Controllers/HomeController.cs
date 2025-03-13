using System.Diagnostics;
using InventoryManagementSystemMe.Models;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystemMe.Data; // Ensure you include the namespace for your DbContext


namespace InventoryManagementSystemMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryManagementContext _context; // Inject database context
        
        public HomeController(ILogger<HomeController> logger, InventoryManagementContext context)
        {
            _logger = logger;
            _context = context;
            
        }


        public IActionResult Index(string searchQuery)
        {
            var products = _context.Products.AsQueryable(); // Get all products

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.Where(p => p.ProductName.Contains(searchQuery));
            }

            return View(products.ToList()); // Pass filtered products to the view
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
