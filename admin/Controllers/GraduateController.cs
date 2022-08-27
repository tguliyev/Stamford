using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace admin.Controllers
{
    public class GraduateController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<GraduateController> _logger;

        public GraduateController(ILogger<GraduateController> logger,StamfordDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}