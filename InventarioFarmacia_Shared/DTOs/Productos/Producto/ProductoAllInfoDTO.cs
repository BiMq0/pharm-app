using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoAllInfoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nombre_Clinico { get; set; }
        public string? Ruta_Imagen { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }

        public ICollection<ProductoIndividualToProductoAllInfoDTO> ProductosIndividuales { get; set; } = new List<ProductoIndividualToProductoAllInfoDTO>();
        public ICollection<CategoriaToProductoDTO> Categorias { get; set; } = new List<CategoriaToProductoDTO>();

        public int StockDisponible => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE);

        public int StockVendido => ProductosIndividuales
            .Count(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO);

        public int StockVencido => ProductosIndividuales
            .Count(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO);

        public int StockPorVencer => ProductosIndividuales
            .Count(pi => pi.Estado == Estados_ProductosIndividuales.POR_VENCER);
        public bool TieneStockBajo => StockDisponible < 20;

        public ProductoAllInfoDTO(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre;
            Nombre_Clinico = producto.Nombre_Clinico;
            Ruta_Imagen = producto.Ruta_Imagen;
            Precio_Unitario = producto.Precio_Unitario;
            Precio_Caja = producto.Precio_Caja;

            if (producto.ProductosIndividuales != null)
            {
                ProductosIndividuales = producto.ProductosIndividuales.Select(pi => new ProductoIndividualToProductoAllInfoDTO(pi)).ToList();
            }
        }
    }
}