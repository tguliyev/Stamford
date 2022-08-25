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
            var tupple = (new Post());
            return View(tupple);
        }
        //[HttpPost]
        // public IActionResult AddPost(Post post, IFormFile userfile)
        // {
        //     try
        //     {
        //         if (ModelState.IsValid)
        //         {
        //             string filename = userfile.FileName;
        //             filename = Path.GetFileName(filename);
        //             string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images", filename);
        //             using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
        //             {
        //                 userfile.CopyToAsync(stream);
        //                 ViewBag.Message = "File Uploaded";
        //                 Asset asset = new Asset();
        //                 asset.Url = filename;
        //                 post.CreatedDate = DateTime.Now;
        //                 _context.Assets.Add(asset);
        //                 _context.Posts.Add(post);
        //                 _context.SaveChanges();
        //                 PostAsset postAsset = new PostAsset();
        //                 postAsset.Imageid = asset.Id;
        //                 postAsset.Postid = post.Id;
        //                 _context.PostAssets.Add(postAsset);
        //                 _context.SaveChanges();
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ViewBag.Message = "Alinmadi " + ex.Message.ToString();
        //     }
        //     return RedirectToAction("Index", "Post");
        // }
        [HttpPost]
        public IActionResult AddPost(Post post, List<IFormFile> userfile)
        {
            Image image = new Image();
            try
            {
                if (ModelState.IsValid && userfile != null)
                {
                    post.CreatedDate = DateTime.Now;
                    _context.Posts.Add(post);
                    _context.SaveChanges();
                    foreach(var formFile in userfile){
                        // if(formFile.Length > 0){
                        //     string filename = formFile.FileName;
                        //     filename = Path.GetFileName(filename);
                        //     string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(),   "wwwroot\\assets\\images", filename);
                        //     using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                        //     {
                        //         formFile.CopyToAsync(stream);
                        //         ViewBag.Message = "File Uploaded";
                        //         Asset asset = new Asset();
                        //         asset.Url = filename;
                        //         _context.Assets.Add(asset);
                        //         _context.SaveChanges();
                        //         PostAsset postAsset = new PostAsset();
                        //         postAsset.Imageid = asset.Id;
                        //         postAsset.Postid = post.Id;
                        //         _context.PostAssets.Add(postAsset);
                        //         _context.SaveChanges();
                        //     }
                        // }
                        
                        var url = image.UploadImage(formFile);
                        if(url!=""){
                             Asset asset = new Asset();
                             asset.Url = url;
                             _context.Assets.Add(asset);
                             _context.SaveChanges();
                             PostAsset postAsset = new PostAsset();
                             postAsset.Imageid = asset.Id;
                             postAsset.Postid = post.Id;
                             _context.PostAssets.Add(postAsset);
                             _context.SaveChanges();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Alinmadi " + ex.Message.ToString();
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