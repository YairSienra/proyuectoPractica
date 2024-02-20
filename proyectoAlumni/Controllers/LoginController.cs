using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient) 
        {
            _httpClient= httpClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LogginSession(LoginDTO loginDTO)
        {
            var baseApi = new BaseApi(_httpClient);

            var login = await baseApi.PostToApi("Aunthenticate/Login", loginDTO);

            if(login == null)
                return RedirectToAction("Login", "Login");
            else
                return View("~/Views/Home/Index.cshtml");
        }
    }
}
