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
        var hashpassword = Hash.CreateMD5Hash(user.Password);

        var admin = _context.Admins.Where(a=>a.Password == hashpassword && a.Email == user.Email).ToList();

        var url = _context.Assets.Where(i=>i.Id==admin[0].Imageid).Select(i=>i.Url).ToList();
        if (admin.Count==1){
            HttpContext.Session.SetString("username", admin[0].Username);
            HttpContext.Session.SetString("url", url[0]);
            return View();
            }
        else return RedirectToAction("Index", "Login");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
