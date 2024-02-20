using Data.DTO;
using Data.Entities;
using Data.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Servcices
{
    public class UsuariosService
    {
        private readonly UsuarioManager _manager;

        public UsuariosService()
        {
            _manager = new UsuarioManager();
        }
        public  Task<List<Usuarios>> BuscarLista()
        {
            var lista = _manager.BuscarLista();

            return  lista;
        }

		public Task<Usuarios> BuscarUsuario(LoginDTO loginDTO)
		{
			var usuario = _manager.BuscarUsuario(loginDTO.Email, loginDTO.Password);

            return usuario;
		}

		public async Task<bool> Guardar(UsuarioDTO request)
        {
            Usuarios usuarios = request;

            return await _manager.Guardar(usuarios, usuarios.IdUsuario);
        }

        public Task<bool> Eliminar(UsuarioDTO usuariio)
        {
            var usuarioEliminado = _manager.Eliminar(usuariio);

            return usuarioEliminado;
        }
    }
}
