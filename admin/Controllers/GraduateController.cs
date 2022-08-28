using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;

namespace admin.Controllers
{
    public class GraduateController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<GraduateController> _logger;

        public GraduateController(ILogger<GraduateController> logger, StamfordDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["Admin"] = HttpContext.Session.GetString("admin");
            ViewData["context"] = _context;
            Graduate graduate = new Graduate();
            return View(graduate);
        }

        //AddGraduate
        [HttpPost]
        public IActionResult AddGraduate(Graduate graduate, IFormFile userfile, string course)
        {
            var value = ModelState.Values.ToList();
            bool isValid = false;
            for (int i = 0; i < value.Count; i++)
            {
                if (i == 1) continue;
                else
                {
                    if (value[i].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid) isValid = true;
                }
            }

            if (isValid)
            {
                var courseid = Convert.ToInt32(course.Split('-', ' ')[0]);

                Image image = new Image();

                var url = image.UploadImage(userfile);
                Asset? asset = null;
                var profilephoto = image.CheckPhoto(url, _context);
                if (profilephoto == null)
                {
                    asset = new Asset();
                    asset.Url = url;
                    image.UploadImagetoDatabase(asset, _context);
                }
                else asset = profilephoto;

                graduate.ImageId = asset.Id;
                graduate.CourseId = courseid;
                _context.Graduates.Add(graduate);
                _context.SaveChanges();
                ViewData["Graduate"] = "Hersey Ela oldu";
            }
            return RedirectToAction("Index", "Graduate");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}