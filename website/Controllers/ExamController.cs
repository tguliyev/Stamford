using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamford.Models;

namespace Stamford.Controllers;
public class ExamController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StamfordDBContext _context;

    public ExamController(ILogger<HomeController> logger, StamfordDBContext context) {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index() {
        return View(false);
    }

    [HttpPost]
    public async Task<IActionResult> Result(string studentCode) {
        ExamStudent? examStudent = await _context.ExamStudents.FirstOrDefaultAsync(es => es.Code == studentCode);
        return examStudent == null ? View("Index", true) : View(examStudent);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
