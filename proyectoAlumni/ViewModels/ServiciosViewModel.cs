using Data.DTO;

namespace Web.ViewModels
{
    public class ServiciosViewModel
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator ServiciosViewModel(ServiciosDTO serviciosDTO)
        {
            var servicios = new ServiciosViewModel();
            servicios.IdServicio = serviciosDTO.IdServicio;
            servicios.Nombre = serviciosDTO.Nombre;
            servicios.Activo = serviciosDTO.Activo;

            return servicios;
        }
    }
}
