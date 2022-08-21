using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace admin.Views.Shared
{
    public class _Layout : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string url { get; set; }
        private readonly ILogger<_Layout> _logger;

        public _Layout(ILogger<_Layout> logger)
        {
             ViewData["username"] = HttpContext.Session.GetString("username");
              ViewData["url"] = HttpContext.Session.GetString("url");
            _logger = logger;
        }

        public void OnGet()
        {
        
        var name = HttpContext.Session.GetString("username");
        var imgurl = HttpContext.Session.GetString("url");

        Username = name;
        url = imgurl;


        _logger.LogInformation("Session Name: {Name}", name);
        _logger.LogInformation("Session Age: {Age}", url);
        }
    }
}