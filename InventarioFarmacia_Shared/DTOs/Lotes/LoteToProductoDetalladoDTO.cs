using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToProductoDetalladoDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public int CantidadProductos { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        public int CantidadProductosPorVencer { get; set; }
        public int CantidadProductosVendidos { get; set; }
        public int CantidadProductosVencidos { get; set; }
        public int CantidadProductosPendientes { get; set; }
        public LoteToProductoDetalladoDTO(Lote lote)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            Nro_Lote = lote.Nro_Lote!;
            CantidadProductos = lote.CantidadProductos;
            CantidadProductosDisponibles = lote.CantidadProductosDisponibles;
            CantidadProductosPorVencer = lote.CantidadProductosPorVencer;
            CantidadProductosVendidos = lote.CantidadProductosVendidos;
            CantidadProductosVencidos = lote.CantidadProductosVencidos;
            CantidadProductosPendientes = lote.CantidadProductosPendientes;
        }

        public LoteToProductoDetalladoDTO()
        {

        }
    }
}