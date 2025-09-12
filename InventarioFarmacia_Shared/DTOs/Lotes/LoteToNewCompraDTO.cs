using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToNewCompraDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public int? Id_LastOrdenCompra { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public int Cantidad_Productos { get; set; }

        public LoteToNewCompraDTO(Lote lote)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            Nro_Lote = lote.Nro_Lote!;
            Cantidad_Productos = lote.CantidadProductos;
        }
        public LoteToNewCompraDTO() { }
    }
}