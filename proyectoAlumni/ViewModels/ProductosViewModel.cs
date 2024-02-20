using Data.DTO;

namespace Web.ViewModels
{
    public class ProductosViewModel
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public IFormFile? formFile { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }

        public static implicit operator ProductosViewModel(ProductosDTO procutosDto)
        {
            var productos = new ProductosViewModel();

            productos.IdProducto = procutosDto.IdProducto;
            productos.Precio = procutosDto.Precio;
            productos.Descripcion = procutosDto.Descripcion;
            productos.Activo = procutosDto.Activo;
            productos.Imagen = procutosDto.Imagen;
            productos.Stock = procutosDto.Stock;

            return productos;
        }
    }
}
