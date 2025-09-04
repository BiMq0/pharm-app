using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.DTOs.Products.Individual
{
    public class ProductoIndividualToNewCompraDTO
    {
        public int Id_Producto { get; set; }
        public int Id_Inventario { get; set; }
        public int Id_Lote { get; set; }
        public ProductoIndividualToNewCompraDTO() { }
    }
}