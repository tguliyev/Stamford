using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using admin.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace admin.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger<ExamController> _logger;

        public ExamController(ILogger<ExamController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ExamStudent exam = new ExamStudent();
            return View(exam);
        }
        [HttpPost]
        public IActionResult AddExam(ExamStudent es)
        {
            if(ModelState.IsValid){

            }
            return RedirectToAction("Index","Exam");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}