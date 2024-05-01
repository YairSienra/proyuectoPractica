using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        public IActionResult Roles()
        {
            return View();
        }

        private readonly IHttpClientFactory _httpClient;
        public RolesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> RolesAddPartial([FromBody] RolesDTO rolDto)
        {
            RolesViewModel roles = new RolesViewModel();

            if (rolDto != null)
            {
                roles = rolDto;
            }

            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", roles);
        }

        public IActionResult GuardarRol(RolesDTO rolDto)
        {
            var baseApi = new BaseApi(_httpClient);

            baseApi.PostToApi("Roles/GuardarRol", rolDto);

            return View("~/Views/Roles/Roles.cshtml");
        }

        public IActionResult EliminarRol([FromBody] RolesDTO rolDto)
        {
            var baseApi = new BaseApi(_httpClient);

            baseApi.PostToApi("Roles/EliminarRol", rolDto);

            return View("~/Views/Roles/Roles.cshtml");
        }
    }
}
