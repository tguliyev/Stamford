using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamford.Models;

public class GraduateController : Controller
{
    private StamfordDBContext _context;
    private const int ROW = 3;
    private const int COL = 4;

    public GraduateController(StamfordDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int pageNum = 0)
    {
        int postCount = _context.Graduates.Count();
        int pageCount = (postCount % (ROW * COL)) > 0 ? (postCount / (ROW * COL)) + 1 : postCount / (ROW * COL);
        pageNum = pageNum < 0 || pageNum > pageCount ? 0 : pageNum;

        List<Graduate> graduates = await _context.Graduates
            .OrderByDescending(graduate => graduate.Id)
            .Include(graduate => graduate.Image)
            .Include(graduate => graduate.Course)
            .Skip(pageNum * ROW * COL)
            .Take(ROW * COL)
            .ToListAsync();

        ViewData["ROW"] = ROW;
        ViewData["COL"] = COL;
        ViewData["pageNum"] = pageNum;
        ViewData["pageCount"] = pageCount;

        return View(graduates);
    }
}