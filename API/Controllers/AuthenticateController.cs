using API.Servcices;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly UsuariosService _usuarioService;

        public AuthenticateController(UsuariosService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var validarUsuario = _usuarioService.BuscarUsuario(loginDTO);

            return Ok(validarUsuario);
        }
    }
}
