using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.ViewModels;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;
        public LoginController(IHttpClientFactory httpClient, IConfiguration congif) 
        {
            _httpClient= httpClient;
            _config= congif;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginDTO loginDTO)
        {
            var baseApi = new BaseApi(_httpClient);
            var login = await baseApi.PostToApi("Authenticate/Login", loginDTO) as OkObjectResult;

            if (login != null && login.Value != null)
            {
                var resultLoginArr = login.Value.ToString().Split(';');

                if (resultLoginArr != null)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, resultLoginArr[1]),
                        new Claim(ClaimTypes.Role, resultLoginArr[2]),
                        new Claim(ClaimTypes.Email, resultLoginArr[3]),
                    };

                    identity.AddClaims(claims);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddHours(24)
                    });

                    HttpContext.Session.SetString("Token", resultLoginArr[0]);
                    var homeViewModel = new HomeViewModel();
                    homeViewModel.Token = resultLoginArr[0];
                    homeViewModel.AjaxUrl = _config["ServiceUrl:AjaxUrl"];
                    

                    return View("~/Views/Home/Index.cshtml", homeViewModel);
                }
            }

            return RedirectToAction("Login", "Login");
        }

        public async Task<IActionResult> CerrarSesion()
		{
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
		}
	}
}
