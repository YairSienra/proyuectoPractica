using System.ComponentModel.DataAnnotations.Schema;

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
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}
