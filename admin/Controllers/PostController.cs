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
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tupple = (new PostViewModel(), new AssetViewModel());
            return View(tupple);
        }
        [HttpPost]
        public IActionResult AddPost([Bind(Prefix = "Item1")] PostViewModel post, [Bind(Prefix = "Item2")] AssetViewModel asset){
            System.Console.WriteLine($"{post.Content} {post.Title}");
            System.Console.WriteLine($"{asset.Url}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}