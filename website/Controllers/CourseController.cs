using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamford.Models;

namespace Stamford.Controllers;
public class CourseController : Controller {
    private StamfordDBContext _context;
    private const int ROW = 3;
    private const int COL = 3;

    public CourseController(StamfordDBContext context) {
        _context = context;
    }

    public async Task<IActionResult> Index(int pageNum = 0) {

        int postCount = _context.Courses.Count();
        int pageCount = (postCount % (ROW * COL)) > 0 ? (postCount / (ROW * COL)) + 1 : postCount / (ROW * COL);
        pageNum = pageNum < 0 || pageNum > pageCount ? 0 : pageNum;

        List<Course> courses = await _context.Courses
            .OrderByDescending(course => course.Id)
            .Include(course => course.Image)
            .Skip(pageNum * ROW * COL)
            .Take(ROW * COL)
            .ToListAsync();

        ViewData["ROW"] = ROW;
        ViewData["COL"] = COL;
        ViewData["pageNum"] = pageNum;
        ViewData["pageCount"] = pageCount;

        return View(courses);   
    }

    public IActionResult Course(int courseId) {
        ViewData["context"] = _context;
        ViewData["courseId"] = courseId;
        return View();
    }
}