using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamford.Models;

namespace Stamford.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StamfordDBContext _context;
    private const int POST_NUM = 5;

    public HomeController(ILogger<HomeController> logger, StamfordDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(int pageNum = 0)
    {
        int postCount = _context.Posts.Count();
        int pageCount = (postCount % POST_NUM) > 0 ? (postCount / POST_NUM) + 1 : postCount / POST_NUM;
        pageNum = pageNum < 0 || pageNum > pageCount ? 0 : pageNum;

        List<Post> posts = _context.Posts
            .OrderByDescending(p => p.Id)
            .Include(post => post.PostAssets)
            .ThenInclude(postAsset => postAsset.Image)
            .Skip(pageNum * POST_NUM)
            .Take(POST_NUM)
            .ToList();

        ViewData["pageCount"] = pageCount;
        ViewData["pageNum"] = pageNum;
        ViewData["POST_NUM"] = POST_NUM;
        return View(posts);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(string message, string name, string email, string subject)
    {
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

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
