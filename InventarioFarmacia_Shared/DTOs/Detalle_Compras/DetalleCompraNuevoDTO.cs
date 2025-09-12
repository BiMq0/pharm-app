using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.DTOs.Products.Individual;
namespace InventarioFarmacia_Shared.DTOs.ShopDetails
{
    public class DetalleCompraNuevoDTO
    {
        public int Id_Compra { get; set; }
        public int Id_ProductoIndividual { get; set; }
        public decimal Precio { get; set; }
    }
}