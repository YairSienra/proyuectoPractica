using API.Servcices;
using Data.DTO;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly ProductosService _service;
        public ProductoController() 
        {
            _service = new ProductosService();
        }

        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<List<Productos>> GetAll()
        {
            var lista = await _service.BuscarLista();

            return lista;
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<bool> GuardarProducto(ProductosDTO request)
        {
            return await _service.Guardar(request);
        }

        [HttpPost]
        [Route("EliminarProductos")]
        public async Task<bool> GuardarEstado(ProductosDTO producto)
        {
            var lista = await _service.Eliminar(producto);

            return lista;
        }
    }
}
