using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToCompraRegistroDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public int CantidadProductosPedidos { get; set; }

        public LoteToCompraRegistroDTO(Lote lote)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            Nro_Lote = lote.Nro_Lote!;
            CantidadProductosPedidos = lote.CantidadProductosPendientes;
        }

        public LoteToCompraRegistroDTO()
        {

        }
    }
}