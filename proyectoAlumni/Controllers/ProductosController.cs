using Data.Base;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Productos()
        {
            return View();
        }

        private readonly IHttpClientFactory _httpClient;
        public ProductosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> ProductosAddPartial([FromBody] ProductosDTO productoDto)
        {
            ProductosViewModel productos = new ProductosViewModel();

            if (productoDto != null)
            {
                productos = productoDto;
            }

            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", productos);
        }

        public IActionResult GuardarProductos(ProductosDTO productoDto)
        {
            var baseApi = new BaseApi(_httpClient);

            if(productoDto.formFile != null && productoDto.formFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    productoDto.formFile.CopyTo(ms);
                    var imgBytes = ms.ToArray();
                    productoDto.Imagen = Convert.ToBase64String(imgBytes);
                }
            }
                
            productoDto.formFile = null;

            baseApi.PostUsuario("Producto/GuardarProducto", productoDto);

            return View("~/Views/Productos/Productos.cshtml");
        }

        public IActionResult EliminarProductos([FromBody] ProductosDTO productoDto)
        {
            var baseApi = new BaseApi(_httpClient);

            baseApi.PostUsuario("Producto/EliminarProductos", productoDto);

            return View("~/Views/Productos/Productos.cshtml");
        }
    }
}
