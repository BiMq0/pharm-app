using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Products.Individual
{
    public class ProductoIndividualToLoteDTO
    {
        public int Id { get; set; }
        public Estados_ProductosIndividuales Estado { get; set; }
        public ProductoIndividualToLoteDTO(Producto_Individual productoIndividual)
        {
            Id = productoIndividual.Id;
            Estado = productoIndividual.Estado;
        }
        public ProductoIndividualToLoteDTO()
        {

        }
    }
}