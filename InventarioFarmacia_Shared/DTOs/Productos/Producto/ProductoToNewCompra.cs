using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Productos.Products
{
    public class ProductoToNewCompra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Clinico { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }
        public ProductoToNewCompra(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre!;
            Nombre_Clinico = producto.Nombre_Clinico!;
            Precio_Unitario = producto.Precio_Unitario;
            Precio_Caja = producto.Precio_Caja;
        }
    }
}