using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
namespace admin.Controllers
{
    public class PostController : Controller
    {
        private StamfordDBContext _context;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, StamfordDBContext Content)
        {
            _logger = logger;
            _context = Content;
        }

        public IActionResult Index()
        {
            var tupple = new Post();
            return View(tupple);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(Post post, List<IFormFile> userfile)
        {
            Image image = new Image();
            if (ModelState.IsValid && userfile != null)
            {
                post.CreatedDate = DateTime.Now;
                _context.Posts.Add(post);
                _context.SaveChanges();
                foreach (var formFile in userfile)
                {
                    var url = await image.UploadImage(formFile);
                    Asset asset = new Asset();
                    asset.Url = url;
                    image.UploadImagetoDatabase(asset, _context);
                    PostAsset postAsset = new PostAsset();
                    postAsset.Imageid = asset.Id;
                    postAsset.Postid = post.Id;
                    _context.PostAssets.Add(postAsset);
                    _context.SaveChanges();
                    TempData["success"] = "Paylaşım əlavə olundu";
                }
            }
            else{
                TempData["validation"] = ModelState.Values.FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
            }


            return RedirectToAction("Index", "Post");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}