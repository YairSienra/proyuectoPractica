using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public abstract class BaseManager<T> where T : class
    {
        protected static ApplicationDbContext _context;

        public static ApplicationDbContext contextoSingleton
        {
            get
            {
                if (_context == null)
                {
                    _context = new ApplicationDbContext();
                }
                return _context;
            }
        }

        public abstract Task<List<T>> BuscarLista();


        public async Task<bool> Guardar(T entity, int Id)
        {
            if (Id == 0)
                contextoSingleton.Entry(entity).State = EntityState.Added;

            else
            {
                var typed = entity.GetType();
                switch (typed.Name)
                {
                    // Primero, busca si la entidad ya está en el contexto.
                    case "Usuarios":
                        var userEntity = contextoSingleton.Set<Usuarios>().Local.FirstOrDefault(x => x.IdUsuario == Id);
                        if (userEntity != null)
                            // Si existe, establece el estado de la entidad existente a EntityState.Detached.
                            contextoSingleton.Entry(userEntity).State = EntityState.Detached;
                        break;

                    case "Roles":
                        var rolEntity = contextoSingleton.Set<Roles>().Local.FirstOrDefault(x => x.IdRole == Id);
                        if (rolEntity != null)
                            // Si existe, establece el estado de la entidad existente a EntityState.Detached.
                            contextoSingleton.Entry(rolEntity).State = EntityState.Detached;
                        break;

                    case "Productos":
                        var productoEntity = contextoSingleton.Set<Productos>().Local.FirstOrDefault(x => x.IdProducto == Id);
                        if (productoEntity != null)
                            // Si existe, establece el estado de la entidad existente a EntityState.Detached.
                            contextoSingleton.Entry(productoEntity).State = EntityState.Detached;
                        break;

                    case "Servicios":
                        var servicioEntity = contextoSingleton.Set<Servicios>().Local.FirstOrDefault(x => x.IdServicio == Id);
                        if (servicioEntity != null)
                            // Si existe, establece el estado de la entidad existente a EntityState.Detached.
                            contextoSingleton.Entry(servicioEntity).State = EntityState.Detached;
                        break;
                }

                contextoSingleton.Entry(entity).State = EntityState.Modified;
            }

            var result = await contextoSingleton.SaveChangesAsync() > 0;

            if (result)
            {
                contextoSingleton.Entry(entity).State = EntityState.Detached;
                return true;
            }
            return false;
        }
    }
}
