using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public UsuariosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult UsuariosAddPartial()
        {
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml");
        }

        public IActionResult GuardarUsuario(UsuarioDTO newUsuario)
        {
            var baseApi = new BaseApi(_httpClient);

            var users = baseApi.PostUsuario("Usuarios/GuardarUsuario", newUsuario);

            return View("~/Views/Usuarios/Usuarios.cshtml");
        }
    }
}
