using System.Text.Json.Serialization;
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

        [JsonConstructor]
        public ProductoInfoCardDTO(int id, string? nombre, string? ruta_Imagen, decimal precio_Unitario, decimal precio_Caja, int stockTotal)
        {
            Id = id;
            Nombre = nombre;
            Ruta_Imagen = ruta_Imagen;
            Precio_Unitario = precio_Unitario;
            Precio_Caja = precio_Caja;
            StockTotal = stockTotal;
        }
    }
}
