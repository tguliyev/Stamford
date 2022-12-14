using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
using admin.Models;
using System.Text.Json;
using Newtonsoft.Json;

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
        HttpContext.Session.Clear();
        return View();

    }
    [HttpPost]
    public IActionResult Panel(User user)
    {
        var hashpassword = Hash.CreateMD5Hash(user.Password);

        var admin = _context.Admins.Where(a => a.Password == hashpassword && a.Email == user.Email).FirstOrDefault();

        if (admin != null)
        {
            string? url = _context.Assets.Where(i => i.Id == admin.Imageid).Select(i => i.Url).FirstOrDefault();
            HttpContext.Session.SetString("username",admin.Username);
            HttpContext.Session.SetString("gmail",admin.Email);
            HttpContext.Session.SetString("url",url);
            return RedirectToAction("Index", "Admin");
        }
        else
        {
            TempData["mjg"] = "Şifrə və ya Mail address yanlışdır";
            return RedirectToAction("Index", "Login");
        }
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
