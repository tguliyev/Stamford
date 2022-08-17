using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stamford.Models;

namespace admin.Controllers
{
    [Route("[controller]")]
    public class test : Controller
    {
        private readonly ILogger<test> _logger;

        private readonly StamfordDBContext _context;

        public test(ILogger<test> logger ,StamfordDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}