using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Products
{
    public class ProductoInfoToCompraDetalladaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioPorCaja { get; set; }
        public ProductoInfoToCompraDetalladaDTO(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre!;
            PrecioUnitario = producto.Precio_Unitario;
            PrecioPorCaja = producto.Precio_Caja;
        }
    }
}