using Stamford.Models;
using admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class ExamController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<ExamController> _logger;

        public ExamController(ILogger<ExamController> logger,StamfordDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ExamStudent exam = new  ExamStudent();
            return View(exam);
        }
        [HttpPost]
        public IActionResult AddExam( ExamStudent es)
        {
            if(ModelState.IsValid){
                _context.ExamStudents.Add(es);
                _context.SaveChanges();
            }
            else {
                // ViewBag.ErrorMessage = ModelState.Values.FirstOrDefault(x=>x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
            }
            return RedirectToAction("Index","Exam",es);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}