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
    public class ProductosManager : BaseManager<Productos>
    {
        public async override Task<List<Productos>> BuscarLista()
        {
            return await contextoSingleton.Productos.Where(x => x.Activo != false).ToListAsync();
        }

        public async Task<bool> Eliminar(ProductosDTO productoDelete)
        {
            var producto = await contextoSingleton.Productos.FirstOrDefaultAsync(x => x.IdProducto == productoDelete.IdProducto && x.Activo == true);

            producto.Activo = false;

            contextoSingleton.Productos.Update(producto);

            var transactSQL = await contextoSingleton.SaveChangesAsync();

            if (transactSQL > 0)
            {
                return true;
            }

            return false;
        }
    }
}
