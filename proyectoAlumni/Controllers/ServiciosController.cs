using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Servicios()
        {
            return View();
        }

        private readonly IHttpClientFactory _httpClient;
        public ServiciosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IActionResult> ServiciosAddPartial([FromBody] ServiciosDTO serviciosDTO)
        {
            ServiciosViewModel Servicios = new ServiciosViewModel();

            if (serviciosDTO != null)
            {
                Servicios = serviciosDTO;
            }

            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", Servicios);
        }

        public async Task<IActionResult> GuardarServicios(ServiciosDTO serviciosDTO)
        {
            var baseApi = new BaseApi(_httpClient);

            await baseApi.PostToApi("Servicios/GuardarServicios", serviciosDTO);

            return View("~/Views/Servicios/Servicios.cshtml");
        }

        public async Task<IActionResult> EliminarServicio([FromBody] ServiciosDTO serviciosDTO)
        {
            var baseApi = new BaseApi(_httpClient);

            await baseApi.PostToApi("Servicios/EliminarServicios", serviciosDTO);

            return View("~/Views/Servicios/Servicios.cshtml");
        }
    }
}
