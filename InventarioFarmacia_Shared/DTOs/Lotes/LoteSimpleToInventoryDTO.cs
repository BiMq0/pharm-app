using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteSimpleToInventoryDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public string? Nro_Lote { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        public int CantidadProductosVencidos { get; set; }
        public int CantidadProductosPorVencer { get; set; }
        [JsonIgnore]
        public ProductoInfoToInventoryDTO? Producto { get; set; }

        public LoteSimpleToInventoryDTO()
        {

        }

        public LoteSimpleToInventoryDTO(Lote lote, int inventarioId)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Nro_Lote = lote.Nro_Lote;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            CantidadProductosDisponibles = lote.ProductosDisponibles.Where(pi => pi.Id_Inventario == inventarioId).Count();
            CantidadProductosVencidos = lote.ProductosVencidos.Where(pi => pi.Id_Inventario == inventarioId).Count();
            CantidadProductosPorVencer = lote.ProductosPorVencer.Where(pi => pi.Id_Inventario == inventarioId).Count();
            Producto = new ProductoInfoToInventoryDTO(lote.Producto!);
        }
    }
}