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
    public class RolesManager : BaseManager<Roles>
    {
        public async override Task<List<Roles>> BuscarLista()
        {
            return await contextoSingleton.Roles.Where(x => x.Activo != false).ToListAsync();
        }

        public async Task<bool> Eliminar(RolesDTO rol)
        {
            var rolFounded = await contextoSingleton.Roles.FirstOrDefaultAsync(x => x.IdRole == rol.IdRole && x.Activo == true);

            rolFounded.Activo = false;

            contextoSingleton.Roles.Update(rolFounded);

            var transactSQL = await contextoSingleton.SaveChangesAsync();

            if (transactSQL > 0)
            {
                return true;
            }

            return false;
        }
    }
}
