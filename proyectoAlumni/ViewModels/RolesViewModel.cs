using Data.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class RolesViewModel
    {
        public int IdRole { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator RolesViewModel(RolesDTO rolDto)
        {
            var roles = new RolesViewModel();

            roles.IdRole = rolDto.IdRole;
            roles.Nombre = rolDto.Nombre; 
            roles.Activo = rolDto.Activo;

            return roles;
        }
    }
}
