using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
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
            


            var tupple = new Post();
            return View(tupple);
        }
        [HttpPost]
        public IActionResult AddPost(Post post,IFormFile userfile){
            try
            {
                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images", filename);
                using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                {
                    userfile.CopyToAsync(stream);
                    ViewBag.Message = "File Uploaded";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Xuy Blet" + ex.Message.ToString();
            }
            return RedirectToAction("Index","Post");
        } 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}