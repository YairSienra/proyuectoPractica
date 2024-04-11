using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public async Task<IActionResult> Ingresar(LoginDTO loginDTO)
        {
            object dataLogin;
      

            var baseApi = new BaseApi(_httpClient);
            var login = await baseApi.PostToApi("Authenticate/Login", loginDTO) as OkObjectResult;
            var resultLogin = login?.Value == "" ? dataLogin = null : dataLogin = login.Value;

            if(dataLogin != null)
            {
                var resultLoginArr = login.Value.ToString().Split(';');

                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                List<Claim> claims = new() 
                {
                   new(ClaimTypes.Name, resultLoginArr[1]),
                   new(ClaimTypes.Role, resultLoginArr[2]),
                   //new(ClaimTypes.Email, resultLoginArr[3]),
                };

                identity.AddClaims(claims);

                ClaimsPrincipal calimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, calimsPrincipal, new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.Now.AddHours(24)
                });
                
                return View("~/Views/Home/Index.cshtml");
            }

            else
			    return RedirectToAction("Login", "Login");  
        }

		public async Task<IActionResult> CerrarSesion()
		{
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
		}
	}
}
