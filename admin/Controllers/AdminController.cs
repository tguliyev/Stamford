using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
namespace admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<AdminController> _logger;
        private Admin CurrentAdmin { get; set; }

        public AdminController(ILogger<AdminController> logger, StamfordDBContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        public IActionResult Home()
        {

            Admin admin = new();
            return View(admin);
        }
        [HttpPost]
        public IActionResult ExhangeProfile(Admin admin, IFormFile userfile)
        {
            User user = new User();
            var email = HttpContext.Session.GetString("mail");
            var password = HttpContext.Session.GetString("password");
            CurrentAdmin = user.CurrentUser(email, password, _context);
            Image image = new Image();
            bool isValid = false;
            var value = ModelState.Values.ToList();
            var state = value[2].ValidationState;

            for (int i = 0; i < value.Count; i++)
            {
                if (i == 2) continue;
                else
                {
                    if (value[i].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid) isValid = true;
                }
            }

            if (state == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid && isValid)
            {
                CurrentAdmin.Email = admin.Email;
                CurrentAdmin.Password = Hash.CreateMD5Hash(admin.Password);
                CurrentAdmin.Username = admin.Username;
                _context.SaveChanges();
            }
            else if (state == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid && isValid)
            {
                var url = image.UploadImage(userfile);

                var profilepicture = _context.Assets.FirstOrDefault(i => i.Url == url);
                Asset? asset=null;
                if(profilepicture == null){
                    asset = new Asset();
                    if (url != "") asset.Url = url;
                    image.UploadImagetoDatabase(asset,_context);
                }
                else asset = profilepicture;
                
                CurrentAdmin.Imageid = asset.Id;
                CurrentAdmin.Email = admin.Email;
                CurrentAdmin.Password = Hash.CreateMD5Hash(admin.Password);
                CurrentAdmin.Username = admin.Username;
                _context.SaveChanges();
            }

            return RedirectToAction("Home", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}