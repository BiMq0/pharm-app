using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Products
{
    public class ProductoToNewCompraDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Clinico { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }
        public ProductoToNewCompraDTO(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre!;
            Nombre_Clinico = producto.Nombre_Clinico!;
            Precio_Unitario = producto.Precio_Unitario;
            Precio_Caja = producto.Precio_Caja;
        }
    }
}