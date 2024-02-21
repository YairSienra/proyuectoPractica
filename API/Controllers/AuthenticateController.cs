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

        public AuthenticateController()
        {
            _usuarioService = new UsuariosService();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var validarUsuario = await _usuarioService.BuscarUsuario(loginDTO);

            return Ok(validarUsuario);
        }
    }
}
