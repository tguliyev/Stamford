using Microsoft.AspNetCore.Mvc;

public class GraduateController : Controller {

    public GraduateController()
    {
        
    }

    public IActionResult Index() {
        return View();
    }
}