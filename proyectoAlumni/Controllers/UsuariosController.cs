using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> UsuariosAddPartial([FromBody] UsuarioDTO usuario)
        {
            UsuarioViewModel usuarios = new UsuarioViewModel();

            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.GetApi("Roles/BuscarRoles");
            var rolesResult = roles as OkObjectResult;

            if (usuario != null)
            {
                usuarios = usuario;
            }

            if (rolesResult != null) 
            {
                var listaRoles = JsonConvert.DeserializeObject<List<RolesDTO>>(rolesResult.Value.ToString());

                var listRolesItems = new List<SelectListItem>();

                foreach (var role in listaRoles)
                {
                    listRolesItems.Add(new SelectListItem() { Text = role.Nombre , Value = role.IdRole.ToString()});
                }

                usuarios.ListaDeRoles = listRolesItems;
            }
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuarios);
        }

        public IActionResult GuardarUsuario(UsuarioDTO newUsuario)
        {
            var baseApi = new BaseApi(_httpClient);

            baseApi.PostToApi("Usuarios/GuardarUsuario", newUsuario);

            return View("~/Views/Usuarios/Usuarios.cshtml");
        }

        public IActionResult EliminarUsuario([FromBody] UsuarioDTO usuario)
        {
            var baseApi = new BaseApi(_httpClient);

            baseApi.PostToApi("Usuarios/EliminarUsuario", usuario);

            return View("~/Views/Usuarios/Usuarios.cshtml");
        }
    }
}
