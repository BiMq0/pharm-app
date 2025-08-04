using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoInfoToCategoria
    {
        public string? Nombre { get; set; }
        public string? Ruta_Imagen { get; set; }

        public ProductoInfoToCategoria(Producto producto)
        {
            Nombre = producto.Nombre;
            Ruta_Imagen = producto.Ruta_Imagen;
        }
    }
}