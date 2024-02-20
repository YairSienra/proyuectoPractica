using Data.Base;
using Data.DTO;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class UsuarioManager : BaseManager<Usuarios>
    {
        public override async Task<List<Usuarios>> BuscarLista()
        {
            return await contextoSingleton.Usuarios.Where(x => x.Activo !=false).Include(x => x.Roles).ToListAsync();
        }

        public async Task<bool> Eliminar(UsuarioDTO usuarioDelete)
        {
            var usuario =  await contextoSingleton.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == usuarioDelete.IdUsuario && x.Activo == true);

            usuario.Activo = false;

            contextoSingleton.Usuarios.Update(usuario);

            var transactSQL = await contextoSingleton.SaveChangesAsync();

            if(transactSQL > 0)
            {
                return true;
            }

            return false;
        }
    }
}
