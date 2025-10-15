using Microsoft.AspNetCore.Mvc;

namespace SupportFlow.FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
