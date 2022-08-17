using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace admin.Controllers
{
    [Route("[controller]")]
    public class AdminPanel : Controller
    {
        private readonly ILogger<AdminPanel> _logger;

        public AdminPanel(ILogger<AdminPanel> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User user = new User();
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}