using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace Stamford.Controllers;
public class CourseController : Controller {
    private StamfordDBContext _context;

    public CourseController(StamfordDBContext context) {
        _context = context;
    }

    public IActionResult Index(int pageNum = 0) {
        ViewData["context"] = _context;
        ViewData["pageNum"] = pageNum;
        return View();    
    }

    public IActionResult Course(int courseId) {
        ViewData["context"] = _context;
        ViewData["courseId"] = courseId;
        return View();
    }
}