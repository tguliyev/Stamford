using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

public class GraduateController : Controller
{

    private StamfordDBContext _context;

    public GraduateController(StamfordDBContext context)
    {
        _context = context;
    }

    public IActionResult Index(int pageNum)
    {
        ViewData["context"] = _context;
        ViewData["pageNum"] = pageNum;
        return View();
    }
}