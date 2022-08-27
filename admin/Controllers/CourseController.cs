using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stamford.Models;

namespace admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, StamfordDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Course course = new Course();
            return View(course);
        }
        [HttpPost]
        public IActionResult AddCourse(Course course, IFormFile userfile)
        {
            var value = ModelState.Values.ToList();
            bool isValid = false;
            for (int i = 0; i < value.Count; i++)
            {
                if (i == 2) continue;
                else
                {
                    if (value[i].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid) isValid = true;
                }
            }
            if (isValid)
            {
                Image image = new Image();
                Asset? asset = null;
                var url = image.UploadImage(userfile);
                var courseimage = _context.Assets.FirstOrDefault(i => i.Url == url);
                if (courseimage == null)
                {
                    if (url != "")
                    {
                        asset = new Asset();
                        asset.Url = url;
                        image.UploadImagetoDatabase(asset,_context);
                    }
                }
                else asset = courseimage;

                course.ImageId = asset.Id;
                _context.Courses.Add(course);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Course");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}