using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace Stamford.Controllers;
public class ExamController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StamfordDBContext _context;

    public ExamController(ILogger<HomeController> logger, StamfordDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string studentCode) {
        Console.WriteLine(studentCode);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
