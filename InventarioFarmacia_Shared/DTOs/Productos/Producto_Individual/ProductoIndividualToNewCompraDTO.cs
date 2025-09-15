using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Products.Individual
{
    public class ProductoIndividualToNewCompraDTO
    {
        public int Id_Producto { get; set; }
        public int Id_Inventario { get; set; }
        public int Id_Lote { get; set; }
        public int Id_OrdenCompra { get; set; }
        public ProductoIndividualToNewCompraDTO() { }

        public ProductoIndividualToNewCompraDTO(Producto_Individual producto)
        {
            Id_Producto = producto.Id_Producto;
            Id_Inventario = producto.Id_Inventario;
            Id_Lote = producto.Id_Lote;
            Id_OrdenCompra = (int)producto.Id_OrdenCompra!;
        }
    }
}