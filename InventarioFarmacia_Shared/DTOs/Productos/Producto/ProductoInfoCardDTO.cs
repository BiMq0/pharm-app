using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoInfoCardDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ruta_Imagen { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }
        public int StockTotal { get; set; }


        public ProductoInfoCardDTO(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre;
            Ruta_Imagen = producto.Ruta_Imagen;
            Precio_Unitario = producto.Precio_Unitario;
            Precio_Caja = producto.Precio_Caja;
            StockTotal = producto.StockDisponible + producto.StockPorVencer;
        }
    }
}
