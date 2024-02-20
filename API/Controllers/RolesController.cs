using API.Servcices;
using Data.DTO;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _service;
        public RolesController() 
        {
            _service = new RolesService();
        }

        [HttpGet]
        [Route("BuscarRoles")]
        public async Task<List<Roles>> GetAll()
        {
            var lista = await _service.BuscarRoles();

            return lista;
        }

        [HttpPost]
        [Route("GuardarRol")]
        public async Task<bool> GuardarUsuario(RolesDTO request)
        {
            return await _service.Guardar(request);
        }

        [HttpPost]
        [Route("EliminarRol")]
        public async Task<bool> Guardar(RolesDTO usuario)
        {
            var lista = await _service.Eliminar(usuario);

            return lista;
        }
    }
}
