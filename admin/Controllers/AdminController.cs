using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
namespace admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger,StamfordDBContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        public IActionResult Home()
        {
            var email = HttpContext.Session.GetString("mail");
            var password = HttpContext.Session.GetString("password");
            Admin admin = _context.Admins.Where(a=>a.Password == password && a.Email == email).ToList()[0];
            return View(admin);
        }
        [HttpPost]
        public IActionResult ExhangeProfile(Admin admin,IFormFile userfile)
        {
            if(userfile == null){
               var oldadmin = _context.Admins.Where(a=>a.Username == admin.Username && a.Email == admin.Email).ToList()[0];
                System.Console.WriteLine(oldadmin.Id);
                _context.SaveChanges();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}