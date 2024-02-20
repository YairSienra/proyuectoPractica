using Data.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }

        public static implicit operator Productos(ProductosDTO productosDto)
        {
            var productos = new Productos();

            productos.IdProducto = productosDto.IdProducto;
            productos.Precio = productosDto.Precio;
            productos.Descripcion = productosDto.Descripcion;
            productos.Activo = productosDto.Activo;
            productos.Imagen = productosDto.Imagen;
            productos.Stock = productosDto.Stock;

            return productos;
        }
    }
}
