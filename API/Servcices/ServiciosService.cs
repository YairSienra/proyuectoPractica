using Data.DTO;
using Data.Entities;
using Data.Managers;

namespace API.Servcices
{
    public class ServiciosService
    {
        private readonly ServiciosManager _manager;

        public ServiciosService()
        {
            _manager = new ServiciosManager();
        }

        public Task<List<Servicios>> BuscarRoles()
        {
            var lista = _manager.BuscarLista();

            return lista;
        }

        public async Task<bool> Guardar(ServiciosDTO request)
        {
            var servicios = new Servicios();
            servicios = request;
            return await _manager.Guardar(request, request.IdServicio);
        }

        public Task<bool> Eliminar(ServiciosDTO request)
        {
            var rolEliminado = _manager.Eliminar(request);

            return rolEliminado;
        }
    }
}
