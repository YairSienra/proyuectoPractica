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
    public class ServiciosManager : BaseManager<Servicios>
    {
        public async override Task<List<Servicios>> BuscarLista()
        {
            return await contextoSingleton.Servicios.Where(x => x.Activo != false).ToListAsync();
        }

        public async Task<bool> Eliminar(ServiciosDTO request)
        {
            var servicioFounded = await contextoSingleton.Servicios.FirstOrDefaultAsync(x => x.IdServicio == request.IdServicio && x.Activo == true);

            servicioFounded.Activo = false;

            contextoSingleton.Servicios.Update(servicioFounded);

            var transactSQL = await contextoSingleton.SaveChangesAsync();

            if (transactSQL > 0)
            {
                return true;
            }

            return false;
        }
    }
}
