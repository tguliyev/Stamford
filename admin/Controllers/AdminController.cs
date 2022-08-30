using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Stamford.Models;
namespace admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly StamfordDBContext _context;
        private readonly ILogger<AdminController> _logger;

        private static int _code = 0;

        private static string newpassw = "";

        public AdminController(ILogger<AdminController> logger, StamfordDBContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        public IActionResult Index()
        {
            Admin admin = new();
            return View(admin);
        }
        [HttpPost]
        public IActionResult ExhangeProfile(Admin admin, IFormFile userfile)
        {

            string? username = HttpContext.Session.GetString("username");
            bool isValid = false;
            var value = ModelState.Values.ToList();
            var state = value[2].ValidationState;
            Admin? currentadmin = null;
            if (username != null)
            {
                currentadmin = _context.Admins.Where(a => a.Username == username).FirstOrDefault();
            }

            for (int i = 0; i < value.Count; i++)
            {
                if (i == 2) continue;
                else
                {
                    if (value[i].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        isValid = false;
                        break;
                    }
                    else isValid = true;
                }
            }

            if (state == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid && isValid)
            {
                currentadmin.Email = admin.Email;
                currentadmin.Password = Hash.CreateMD5Hash(admin.Password);
                currentadmin.Username = admin.Username;
                _context.SaveChanges();
                HttpContext.Session.SetString("username", admin.Username);
                TempData["success"] = "Dəyişəkliklər əlavə olundu";
            }
            else if (state == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid && isValid)
            {
                Image image = new Image();
                var url = image.UploadImage(userfile);
                Asset asset = new Asset();
                asset.Url = url.Result;
                image.UploadImagetoDatabase(asset, _context);
                currentadmin.Imageid = asset.Id;
                currentadmin.Email = admin.Email;
                currentadmin.Password = Hash.CreateMD5Hash(admin.Password);
                currentadmin.Username = admin.Username;
                _context.SaveChanges();
                HttpContext.Session.SetString("username", admin.Username);
                HttpContext.Session.SetString("url", asset.Url);
                TempData["username"] = HttpContext.Session.GetString("username");
                TempData["url"] = HttpContext.Session.GetString("url");
                TempData["success"] = "Dəyişəkliklər əlavə olundu";
            }
            else{
                 TempData["validation"]= ModelState.Values.FirstOrDefault(x=>x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
            }

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult ExchangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExchangePassword(string oldpass,string newpass,string retry)
        {
            if(ModelState.IsValid){
                var pass = Hash.CreateMD5Hash(oldpass);
                Admin? admin = _context.Admins.Where(a=>a.Password == pass).FirstOrDefault();
                if(admin!=null && newpass == retry){
                    newpassw = newpass;
                    return RedirectToAction("SetGmailAccount", "Admin");
                }
                else{
                    TempData["pass"] = "Yeni və ya köhnə şifrəni kontrol eliyin";
                    return RedirectToAction("ExchangePassword", "Admin");
                }
            }
            else{
                
                 return RedirectToAction("ExchangePassword", "Admin");
            }
        }
        public IActionResult SetGmailAccount(){
            Random rand = new Random();
            _code = rand.Next(10000,99999);
            System.Console.WriteLine(_code);
            string? email = HttpContext.Session.GetString("gmail");
            Email.SendCodeWithEmail(email,_code);
            return View();

        }
        [HttpPost]
        public IActionResult SetGmailAccount(string code)
        {
            if(Convert.ToInt32(code)==_code){
                string? email = HttpContext.Session.GetString("gmail");
                Admin? admin = _context.Admins.Where(a=>a.Email == email).FirstOrDefault();
                admin.Password = Hash.CreateMD5Hash(newpassw);
                _context.SaveChanges();
                TempData["Changed"] = "Şifrə dəyişdirildi";
            }
            else{
                TempData["NoChanged"] = "Kod yanlışdır";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}