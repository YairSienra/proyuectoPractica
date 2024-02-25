using Commons.Helpers;
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
        public  async Task<List<Usuarios>> BuscarLista()
        {
            var lista = _manager.BuscarLista();

            foreach (var x in lista.Result.ToList())
            {
                x.Password = EncryptHelper.Decrypt(x.Password);
            }
            return  lista.Result.ToList();
        }

		public async Task<Usuarios?> BuscarUsuario(LoginDTO loginDTO)
		{
			var usuario =  await _manager.BuscarUsuario(loginDTO.Mail, loginDTO.Password);

            return usuario;
		}

		public async Task<bool> Guardar(UsuarioDTO request)
        {
            Usuarios usuarios = request;
            usuarios.Password = EncryptHelper.Encrypt(usuarios.Password);
            return await _manager.Guardar(usuarios, usuarios.IdUsuario);
        }

        public Task<bool> Eliminar(UsuarioDTO usuariio)
        {
            var usuarioEliminado = _manager.Eliminar(usuariio);

            return usuarioEliminado;
        }
    }
}
