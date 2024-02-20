using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
