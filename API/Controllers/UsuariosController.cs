using API.Interfaces;
using API.Servcices;
using Data.DTO;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _service;

        public UsuariosController()
        {
            _service = new UsuariosService();
        }

        [HttpGet]
        [Route("BuscarUsuarios")]
        public async Task<List<Usuarios>> GetAll()
        {
            var lista =  await _service.BuscarLista();

            return lista;
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<bool> GuardarUsuario(UsuarioDTO request)
        {
           return  await _service.Guardar(request);
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<bool> Guardar(UsuarioDTO usuario)
        {
            var lista = await _service.Eliminar(usuario);

            return lista;
        }
    }
}
