﻿using API.Servcices;
using Data.DTO;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
    [Authorize]
    public class ServiciosController : Controller
    {
        private readonly ServiciosService _service;
        public ServiciosController()
        {
            _service = new ServiciosService();
        }

        [HttpGet]
		[Route("BuscarServicios")]
        public async Task<List<Servicios>> GetAll()
        {
            var lista = await _service.BuscarRoles();

            return lista;
        }

        [HttpPost]
        [Authorize]
        [Route("GuardarServicios")]
        public async Task<bool> GuardarUsuario(ServiciosDTO request)
        {
            return await _service.Guardar(request);
        }

        [HttpPost]
        [Authorize]
        [Route("EliminarServicios")]
        public async Task<bool> Guardar(ServiciosDTO usuario)
        {
            var lista = await _service.Eliminar(usuario);

            return lista;
        }
    }
}
