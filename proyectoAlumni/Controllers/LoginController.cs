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

        public async Task<IActionResult> Ingresar(LoginDTO loginDTO)
        {
            object dataLogin;

            var baseApi = new BaseApi(_httpClient);
            var login = await baseApi.PostToApi("Authenticate/Login", loginDTO) as OkObjectResult;
            var resultLogin = login?.Value == "" ? dataLogin = null : dataLogin = login.Value;

            if(dataLogin != null)
				return View("~/Views/Home/Index.cshtml");
            else
			    return RedirectToAction("Login", "Login");  
        }

		public async Task<IActionResult> CerrarSesion()
		{
            return RedirectToAction("Login", "Login");
		}
	}
}
