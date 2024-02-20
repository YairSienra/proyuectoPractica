using Data.DTO;
using Data.Entities;
using Data.Managers;

namespace API.Servcices
{
    public class ProductosService
    {
        private readonly ProductosManager _manager;

        public ProductosService() 
        {
            _manager = new ProductosManager();
        }

        public Task<List<Productos>> BuscarLista()
        {
            var lista = _manager.BuscarLista();

            return lista;
        }

        public async Task<bool> Guardar(ProductosDTO request)
        {
            Productos productos = request;

            return await _manager.Guardar(productos, request.IdProducto);
        }

        public Task<bool> Eliminar(ProductosDTO request)
        {
            var usuarioEliminado = _manager.Eliminar(request);

            return usuarioEliminado;
        }
    }
}
