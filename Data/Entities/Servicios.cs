using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Servicios
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator Servicios(ServiciosDTO serviciosDTO)
        {
            var servicio = new Servicios();

            servicio.IdServicio = serviciosDTO.IdServicio;
            servicio.Nombre = serviciosDTO.Nombre;
            servicio.Activo = serviciosDTO.Activo;

            return servicio;
        }
    }
}
