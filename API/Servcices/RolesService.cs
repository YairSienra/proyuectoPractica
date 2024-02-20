using Data.DTO;
using Data.Entities;
using Data.Managers;

namespace API.Servcices
{
    public class RolesService
    {
        private readonly RolesManager _manager;

        public RolesService()
        {
            _manager = new RolesManager();
        }

        public Task<List<Roles>> BuscarRoles()
        {
            var lista = _manager.BuscarLista();

            return lista;
        }

        public async Task<bool> Guardar(RolesDTO request)
        {
            var roles = new Roles();
            roles = request;
            return await _manager.Guardar(request, request.IdRole);
        }

        public Task<bool> Eliminar(RolesDTO rol)
        {
            var rolEliminado = _manager.Eliminar(rol);

            return rolEliminado;
        }
    }
}
