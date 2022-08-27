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
        return View();
        
    }
    [HttpPost]
    public IActionResult Panel(User user)
    {
        var hashpassword = Hash.CreateMD5Hash(user.Password);

        var admin = _context.Admins.Where(a=>a.Password == hashpassword && a.Email == user.Email).ToList();

        if (admin.Count==1){
            var url = _context.Assets.Where(i=>i.Id==admin[0].Imageid).Select(i=>i.Url).ToList();

            // string jsonString = JsonSerializer.Serialize(admin[0]);

            string jsonString = JsonConvert.SerializeObject(admin[0], Formatting.Indented);

            HttpContext.Session.SetString("admin", jsonString);

            TempData["Admin"] = HttpContext.Session.GetString("admin");

            return RedirectToAction("Home", "Admin");
        }
        else return RedirectToAction("Index", "Login");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
