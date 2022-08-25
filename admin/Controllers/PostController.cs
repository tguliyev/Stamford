using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
namespace admin.Controllers
{
    public class PostController : Controller
    {
        private StamfordDBContext _Content;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, StamfordDBContext Content)
        {
            _logger = logger;
            _Content = Content;
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
        //                 _Content.Assets.Add(asset);
        //                 _Content.Posts.Add(post);
        //                 _Content.SaveChanges();
        //                 PostAsset postAsset = new PostAsset();
        //                 postAsset.Imageid = asset.Id;
        //                 postAsset.Postid = post.Id;
        //                 _Content.PostAssets.Add(postAsset);
        //                 _Content.SaveChanges();
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
            try
            {
                if (ModelState.IsValid && userfile != null)
                {
                    post.CreatedDate = DateTime.Now;
                    _Content.Posts.Add(post);
                    _Content.SaveChanges();
                    foreach(var formFile in userfile){
                        if(formFile.Length > 0){
                            string filename = formFile.FileName;
                            filename = Path.GetFileName(filename);
                            string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(),   "wwwroot\\assets\\images", filename);
                            using (var stream = new FileStream(uploadfilepath, FileMode.OpenOrCreate))
                            {
                                formFile.CopyToAsync(stream);
                                ViewBag.Message = "File Uploaded";
                                Asset asset = new Asset();
                                asset.Url = filename;
                                _Content.Assets.Add(asset);
                                _Content.SaveChanges();
                                PostAsset postAsset = new PostAsset();
                                postAsset.Imageid = asset.Id;
                                postAsset.Postid = post.Id;
                                _Content.PostAssets.Add(postAsset);
                                _Content.SaveChanges();
                            }
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