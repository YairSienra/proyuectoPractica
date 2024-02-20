using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class ProductosDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public IFormFile? formFile { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }
    }
}
