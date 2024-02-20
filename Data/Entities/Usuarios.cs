using Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Mail { get; set; }
        [ForeignKey("Roles")]
        public int Id_Role { get; set; }
        public int Codigo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public Roles Roles { get; set; }

        public static implicit operator Usuarios(UsuarioDTO usuarioDTO)
        {
            Usuarios newUser = new Usuarios();

            newUser.IdUsuario = usuarioDTO.IdUsuario;
            newUser.Nombre = usuarioDTO.Nombre;
            newUser.Apellido = usuarioDTO.Apellido;
            newUser.Activo = usuarioDTO.Activo;
            newUser.Clave = usuarioDTO.Clave;
            newUser.Codigo = usuarioDTO.Codigo;
            newUser.Mail = usuarioDTO.Mail;
            newUser.Id_Role = usuarioDTO.Id_Role;
            newUser.Fecha_Nacimiento = usuarioDTO.Fecha_Nacimiento;

            return newUser;
        }
    }
}
