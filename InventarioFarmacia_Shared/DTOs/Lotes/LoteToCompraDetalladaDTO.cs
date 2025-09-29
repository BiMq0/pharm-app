using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToCompraDetalladaDTO
    {
        public int Id { get; set; }
        public string? Nro_Lote { get; set; }
        public int CantidadProductosPedidos { get; set; }
        [JsonIgnore]
        public ProductoInfoToCompraDetalladaDTO? Producto { get; set; }

        public LoteToCompraDetalladaDTO()
        {

        }

        public LoteToCompraDetalladaDTO(Lote lote, int compraId)
        {
            Id = lote.Id;
            Nro_Lote = lote.Nro_Lote;
            CantidadProductosPedidos = lote.ProductosPendientes.Where(pi => pi.Id_OrdenCompra == compraId).Count();
            Producto = new ProductoInfoToCompraDetalladaDTO(lote.Producto!);
        }
    }
}