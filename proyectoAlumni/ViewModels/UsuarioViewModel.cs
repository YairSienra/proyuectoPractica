using Data.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace Web.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Mail { get; set; }
        public int Id_Role { get; set; }
        public int Codigo { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<SelectListItem> ListaDeRoles { get; set; }
        
        public static implicit operator UsuarioViewModel(UsuarioDTO usuario)
        {
            var usuarioViewModel = new UsuarioViewModel();

            usuarioViewModel.IdUsuario = usuario.IdUsuario;
            usuarioViewModel.Nombre = usuario.Nombre;
            usuarioViewModel.Apellido = usuario.Apellido;
            usuarioViewModel.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
            usuarioViewModel.Mail = usuario.Mail;
            usuarioViewModel.Id_Role = usuario.Id_Role;
            usuarioViewModel.Password = usuario.Password;
            usuarioViewModel.Activo = usuario.Activo;

            return usuarioViewModel;
        }
    }
}
