using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace Stamford.Controllers;
public class PostController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly StamfordDBContext _context;

    public PostController(ILogger<HomeController> logger, StamfordDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(int postId) {
        ViewData["context"] = _context;
        ViewData["postId"] = postId;
        return View();
    }
}