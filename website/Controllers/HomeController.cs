using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace Stamford.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StamfordDBContext _context;

    public HomeController(ILogger<HomeController> logger, StamfordDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(int pageNum = 0)
    {
        ViewData["context"] = _context;
        ViewData["pageNum"] = pageNum;
        return View();
    }

    public IActionResult About() {
        return View();
    }

    public IActionResult Contact() {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(string message, string name, string email, string subject) {
        Console.WriteLine(message);
        Console.WriteLine(name);
        Console.WriteLine(email);
        Console.WriteLine(subject);
        return View();
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
