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

    public IActionResult AboutUs() {
        return View();
    }

    public IActionResult Contact() {
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
