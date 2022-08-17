using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
using System.Linq;
using admin.Models;

namespace admin.Controllers;

public class LoginController : Controller
{

    private readonly ILogger<LoginController> _logger;

    private readonly StamfordDBContext _context;

    public LoginController(ILogger<LoginController> logger, StamfordDBContext context)
    {
        _logger = logger;
        _context = context;

    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Panel(User user)
    {
        
        if (user.Email == "tamerlaailn7@gmail.com" && user.Password == "123456")return View();
        else return RedirectToAction("Index", "Login");
  
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
