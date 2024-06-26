﻿using API.Servcices;
using Commons.Helpers;
using Data.DTO;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly UsuariosService _usuarioService;
        private readonly IConfiguration _config;

        public AuthenticateController(IConfiguration config)
        {
            _usuarioService = new UsuariosService();
            _config = config;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            loginDTO.Password = EncryptHelper.Encrypt(loginDTO.Password);
            var validarUsuario = await _usuarioService.BuscarUsuario(loginDTO);

            if (validarUsuario != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, validarUsuario.Nombre),
                    new Claim(ClaimTypes.DateOfBirth, validarUsuario.Fecha_Nacimiento.ToString()),
                    new Claim(ClaimTypes.Role, validarUsuario.Roles.Nombre),
                    new Claim(ClaimTypes.Email, validarUsuario.Mail),
                };

                var token = CreateToken(claims);

                var reloadedToken = new JwtSecurityTokenHandler().WriteToken(token).ToString() + ";" + validarUsuario.Nombre + ";" + validarUsuario.Roles.Nombre + ";" + validarUsuario.Mail;

				return Ok(reloadedToken);
            }
            else
            {
                return Unauthorized();
            }
        }


        private JwtSecurityToken CreateToken (List<Claim> data)
        {
            var firma = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Firma"]));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(24),
                claims: data,
                signingCredentials: new SigningCredentials(
                   key: firma, 
                   algorithm: SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
