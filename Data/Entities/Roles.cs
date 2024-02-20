using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Roles
    {
        [Key]
        public int IdRole { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator Roles(RolesDTO rolesDto)
        {
            var role = new Roles();

            role.IdRole = rolesDto.IdRole;
            role.Nombre = rolesDto.Nombre;
            role.Activo = rolesDto.Activo;

            return role;
        }
    }
}
